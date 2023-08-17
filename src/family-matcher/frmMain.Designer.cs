namespace RedatamConverter
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtVarHouseholdId = new System.Windows.Forms.TextBox();
			this.txtVarAge = new System.Windows.Forms.TextBox();
			this.txtVarRelation = new System.Windows.Forms.TextBox();
			this.btnProcess = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.txtVarPersonaId = new System.Windows.Forms.TextBox();
			this.txtVarSex = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtVarHouseholdId
			// 
			this.txtVarHouseholdId.Location = new System.Drawing.Point(167, 97);
			this.txtVarHouseholdId.Name = "txtVarHouseholdId";
			this.txtVarHouseholdId.Size = new System.Drawing.Size(100, 20);
			this.txtVarHouseholdId.TabIndex = 0;
			this.txtVarHouseholdId.Text = "HOGAR_REF_ID";
			// 
			// txtVarAge
			// 
			this.txtVarAge.Location = new System.Drawing.Point(167, 175);
			this.txtVarAge.Name = "txtVarAge";
			this.txtVarAge.Size = new System.Drawing.Size(100, 20);
			this.txtVarAge.TabIndex = 1;
			this.txtVarAge.Text = "P03";
			// 
			// txtVarRelation
			// 
			this.txtVarRelation.Location = new System.Drawing.Point(167, 123);
			this.txtVarRelation.Name = "txtVarRelation";
			this.txtVarRelation.Size = new System.Drawing.Size(100, 20);
			this.txtVarRelation.TabIndex = 2;
			this.txtVarRelation.Text = "P01";
			// 
			// btnProcess
			// 
			this.btnProcess.Location = new System.Drawing.Point(273, 40);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(75, 23);
			this.btnProcess.TabIndex = 3;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// txtFile
			// 
			this.txtFile.Location = new System.Drawing.Point(167, 42);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(100, 20);
			this.txtFile.TabIndex = 4;
			this.txtFile.Text = @"V:\redatam\Conversiones REDATAM\Argentina 2010\Ampliada 2010\PERSONA-CABA.sav";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(164, 17);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(32, 13);
			this.lblStatus.TabIndex = 5;
			this.lblStatus.Text = "Listo.";
			// 
			// txtVarPersonaId
			// 
			this.txtVarPersonaId.Location = new System.Drawing.Point(167, 71);
			this.txtVarPersonaId.Name = "txtVarPersonaId";
			this.txtVarPersonaId.Size = new System.Drawing.Size(100, 20);
			this.txtVarPersonaId.TabIndex = 6;
			this.txtVarPersonaId.Text = "PERSONA_REF_ID";
			// 
			// txtVarSex
			// 
			this.txtVarSex.Location = new System.Drawing.Point(167, 149);
			this.txtVarSex.Name = "txtVarSex";
			this.txtVarSex.Size = new System.Drawing.Size(100, 20);
			this.txtVarSex.TabIndex = 7;
			this.txtVarSex.Text = "P02";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Sexo:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Edad:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Relación:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(37, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Identificador de hogar:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(37, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Identificador de persona:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(37, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Archivo:";
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnProcess;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 261);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtVarSex);
			this.Controls.Add(this.txtVarPersonaId);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.txtVarRelation);
			this.Controls.Add(this.txtVarAge);
			this.Controls.Add(this.txtVarHouseholdId);
			this.Name = "frmMain";
			this.Text = "Analiza hogares";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtVarHouseholdId;
		private System.Windows.Forms.TextBox txtVarAge;
		private System.Windows.Forms.TextBox txtVarRelation;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.TextBox txtVarPersonaId;
		private System.Windows.Forms.TextBox txtVarSex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}