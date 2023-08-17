using Spss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedatamConverter
{
	public partial class frmMain : Form
	{
		SpssDataDocument fatherFile;
		SpssDataDocument motherFile;
		string tAge;
		string tPersonaId;
		string tRelation;
		string tSex;

		public frmMain()
		{
			InitializeComponent();
		}
		DateTime time;
		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void ReadHousehold(SpssDataDocument doc)
		{
			int lastHousehold = 0;
			List<Dictionary<string, int>> family = new List<Dictionary<string, int>>();
			foreach(SpssCase row in doc.Cases)
			{
				int houseId = 0;
				try
				{
					houseId = GetInt(row, txtVarHouseholdId.Text);
				}
				catch (SpssException ex)
				{
					if (ex.SpssResultCode == ReturnCode.SPSS_FILE_END)
						break;
				}
				if (houseId != lastHousehold)
				{
					if (family.Count > 0)
						ProcessFamily(family);
					family = new List<Dictionary<string, int>>();
					lastHousehold = houseId;
					if (houseId % 100 == 0)
					{ 
						lblStatus.Text = houseId.ToString() + " "+ ((TimeSpan)(DateTime.Now - time)).TotalSeconds.ToString();
						time = DateTime.Now;
						Application.DoEvents();
					}
				}
				family.Add(ConvertRow(row));
			}
			if (family.Count > 0)
				ProcessFamily(family);
		}

		private Dictionary<string, int> ConvertRow(SpssCase row)
		{
			Dictionary<string, int> ret = new Dictionary<string, int>();
			ret[tAge] = GetInt(row, tAge);
			ret[tPersonaId] = GetInt(row, tPersonaId);
			ret[tRelation] = GetInt(row, tRelation);
			ret[tSex] = GetInt(row, tSex);
			return ret;
		}

		private int GetInt(Dictionary<string, int> row, string col)
		{
			return row[col];
		}
		private int GetInt(SpssCase row, string col)
		{
			return int.Parse(GetString(row, col));
		}
		private string GetString(SpssCase row, string col)
		{
			return row[col].ToString();
		}

		private void ProcessFamily(List<Dictionary<string, int>> family)
		{
			// Busca  los niños
			var children = GetChildren(family);
			foreach (var child in children)
				IdentifyParents(family, child);
		}

		private void IdentifyParents(List<Dictionary<string, int>> family, Dictionary<string, int> child)
		{
			bool fatherConsistentConfidence;
			bool motherConsistentConfidence;
			int age = GetInt(child, tAge);
			var father = GetParent2010Match(true, family, child, out fatherConsistentConfidence);
			var mother = GetParent2010Match(false, family, child, out motherConsistentConfidence);
			if (father != null)
				WriteCase(GetInt(child, tPersonaId), age, true, GetInt(father, tPersonaId), fatherConsistentConfidence);
			if (mother != null)
				WriteCase(GetInt(child, tPersonaId), age, false, GetInt(mother, tPersonaId), motherConsistentConfidence);
		}

		private void WriteCase(int childId, int childAge, bool isFather, int parentId, bool consistentConfidence)
		{
			SpssDataDocument file;
			if (isFather)
				file = fatherFile;
			else
				file = motherFile;
			var row = file.Cases.New();
			row["PERSONA_REF_ID_CHILD"] = childId;
			row["PERSONA_REF_ID_PARENT"] = parentId;
			row["CHILD_AGE"] = childAge;
			row["PARENT_CONSISTENT"] = (consistentConfidence ? 1 : 2);
			
			row.Commit();
		}

		private Dictionary<string, int> GetParent2010Match(bool getMale, List<Dictionary<string, int>> family, Dictionary<string, int> child, out bool consistentConfidence)
		{
			int relation = GetInt(child, tRelation);
			int age = GetInt(child, tAge);
			bool dummy;
			switch (relation)
			{
				case (int) Relation2010Enum.Jefe:
				case (int) Relation2010Enum.Conyuge:
					return GetMemberWithRelationAndAgeSpan(getMale, age,
											family, out consistentConfidence, Relation2010Enum.Padre_Madre_Suegro);

				case (int) Relation2010Enum.Hijo_Hijastro:
				case (int) Relation2010Enum.Yerno_Nuera:
					return GetMemberWithRelationAndAgeSpan(getMale, age,
											family, out consistentConfidence, Relation2010Enum.Jefe, Relation2010Enum.Conyuge);

				case (int) Relation2010Enum.Nieto:
					return GetMemberWithRelationAndAgeSpan(getMale, age,
											family, out consistentConfidence, Relation2010Enum.Hijo_Hijastro, Relation2010Enum.Yerno_Nuera);
				case (int) Relation2010Enum.Padre_Madre_Suegro:
					consistentConfidence = false;
					return null;
				case (int) Relation2010Enum.Otros_familiares:
					consistentConfidence = false;
					return GetMemberWithRelationAndAgeSpan(getMale, age,
						family, out dummy, Relation2010Enum.Otros_familiares);
				case (int) Relation2010Enum.Otros_no_familiares:
					consistentConfidence = false;
					return GetMemberWithRelationAndAgeSpan(getMale, age,
						family, out dummy, Relation2010Enum.Otros_no_familiares);
				case (int) Relation2010Enum.Servicio_doméstico_y_sus_familiares:
					consistentConfidence = false;
					return GetMemberWithRelationAndAgeSpan(getMale, age,
						family, out dummy, Relation2010Enum.Servicio_doméstico_y_sus_familiares);
				default:
					consistentConfidence = false;
					return null;
			}
		}

		private Dictionary<string, int> GetMemberWithRelationAndAgeSpan(bool getMale, int age, 
			List<Dictionary<string, int>> family, out bool consistentConfidence, Relation2010Enum relacion1, Relation2010Enum relacion2 = Relation2010Enum.Ninguna)
		{
			List<Dictionary<string, int>> candidates = new List<Dictionary<string, int>>();
			int targetSexCode = (getMale ? 1 : 2);
			foreach (Dictionary<string, int> row in family)
			{
				if (GetInt(row, tSex) == targetSexCode)
				{ 
					int relationRow = GetInt(row, tRelation);
					if ((relationRow == (int) relacion1 
						|| relationRow == (int) relacion2) && GetInt(row, tAge) - age >= 14  
						)
							candidates.Add(row);
				}
			}
			consistentConfidence = candidates.Count == 1;
			if (candidates.Count > 0)
				return candidates[new Random().Next(0, candidates.Count - 1)];
			else
				return null;
		}

		List<Dictionary<string, int>> GetChildren (List<Dictionary<string, int>> members)
		{
			List<Dictionary<string, int>> ret = new List<Dictionary<string, int>>();
			foreach (Dictionary<string, int> row in members)
			{
				if (GetInt(row, tAge) < 16) ret.Add(row);
			}
			return ret;
		}
		protected SpssDataDocument Open(string file)
		{
			SpssDataDocument doc = SpssDataDocument.Open(file, SpssFileAccess.Read);

			fatherFile = CreateSpssFile(file + ".fathers.sav");
			motherFile = CreateSpssFile(file + ".mothers.sav");

			return doc;
		}

		private SpssDataDocument CreateSpssFile(string file)
		{
			if (File.Exists(file))
				File.Delete(file);
			var doc = SpssDataDocument.Create(file);
			// agrega las variables
			SpssNumericVariable child = new SpssNumericVariable();
			child.Name = "PERSONA_REF_ID_CHILD";
			doc.Variables.Add(child);
			SpssNumericVariable age = new SpssNumericVariable();
			age.Name = "CHILD_AGE";
			age.Label = "Edad";
			doc.Variables.Add(age);
			SpssNumericVariable parent = new SpssNumericVariable();
			parent.Name = "PERSONA_REF_ID_PARENT";
			doc.Variables.Add(parent);
			SpssNumericVariable consistency = new SpssNumericVariable();
			consistency.Name = "PARENT_CONSISTENT";
			consistency.ValueLabels.Add(1, "Si");
			consistency.ValueLabels.Add(2, "No");
			doc.Variables.Add(consistency);
			// Listo
			doc.CommitDictionary();
			return doc;
		}


		private void btnProcess_Click(object sender, EventArgs e)
		{
			tAge = txtVarAge.Text;
			tPersonaId = txtVarPersonaId.Text;
			tRelation = txtVarRelation.Text;
			tSex = txtVarSex.Text;

			SpssDataDocument doc = null;
			try
			{
				time = DateTime.Now;
				doc = Open(txtFile.Text);
				ReadHousehold(doc);
				doc.Close();
				motherFile.Close();
				fatherFile.Close();
				MessageBox.Show(this, "Done!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
			finally
			{
				safeClose(doc);
				safeClose(motherFile);
				safeClose(fatherFile);
			}
		}

		private void safeClose(SpssDataDocument doc)
		{
			if (doc != null && doc.IsClosed == false)
				doc.Close();
		}
	}
}
