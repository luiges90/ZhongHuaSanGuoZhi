namespace ScenarioGenerator
{
    partial class Form1
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
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.openScenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddPersonLo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddPersonHi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFemaleChance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBornYearHi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBornYearLo = new System.Windows.Forms.TextBox();
            this.tbDebutAgeHi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDebutAgeLo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAgeHi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAgeLo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbJoinedFactionChance = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadScenario
            // 
            this.btnLoadScenario.Location = new System.Drawing.Point(12, 12);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScenario.TabIndex = 0;
            this.btnLoadScenario.Text = "讀取劇本";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(93, 17);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(89, 12);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "請選擇劇本檔案";
            // 
            // openScenFileDialog
            // 
            this.openScenFileDialog.FileName = "openFileDialog1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(646, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "生成劇本";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbJoinedFactionChance);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbAgeHi);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.tbAgeLo);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tbDebutAgeHi);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbDebutAgeLo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbBornYearHi);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbBornYearLo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbFemaleChance);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbAddPersonHi);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbAddPersonLo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(701, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "人物";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(709, 319);
            this.tabControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "增加人物數量";
            // 
            // tbAddPersonLo
            // 
            this.tbAddPersonLo.Location = new System.Drawing.Point(117, 6);
            this.tbAddPersonLo.Name = "tbAddPersonLo";
            this.tbAddPersonLo.Size = new System.Drawing.Size(63, 22);
            this.tbAddPersonLo.TabIndex = 1;
            this.tbAddPersonLo.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // tbAddPersonHi
            // 
            this.tbAddPersonHi.Location = new System.Drawing.Point(209, 6);
            this.tbAddPersonHi.Name = "tbAddPersonHi";
            this.tbAddPersonHi.Size = new System.Drawing.Size(63, 22);
            this.tbAddPersonHi.TabIndex = 3;
            this.tbAddPersonHi.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "生成女武將機率";
            // 
            // tbFemaleChance
            // 
            this.tbFemaleChance.Location = new System.Drawing.Point(117, 34);
            this.tbFemaleChance.Name = "tbFemaleChance";
            this.tbFemaleChance.Size = new System.Drawing.Size(63, 22);
            this.tbFemaleChance.TabIndex = 5;
            this.tbFemaleChance.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生年：劇本年後";
            // 
            // tbBornYearHi
            // 
            this.tbBornYearHi.Location = new System.Drawing.Point(209, 90);
            this.tbBornYearHi.Name = "tbBornYearHi";
            this.tbBornYearHi.Size = new System.Drawing.Size(63, 22);
            this.tbBornYearHi.TabIndex = 9;
            this.tbBornYearHi.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "至";
            // 
            // tbBornYearLo
            // 
            this.tbBornYearLo.Location = new System.Drawing.Point(117, 90);
            this.tbBornYearLo.Name = "tbBornYearLo";
            this.tbBornYearLo.Size = new System.Drawing.Size(63, 22);
            this.tbBornYearLo.TabIndex = 7;
            this.tbBornYearLo.Text = "-10";
            // 
            // tbDebutAgeHi
            // 
            this.tbDebutAgeHi.Location = new System.Drawing.Point(209, 118);
            this.tbDebutAgeHi.Name = "tbDebutAgeHi";
            this.tbDebutAgeHi.Size = new System.Drawing.Size(63, 22);
            this.tbDebutAgeHi.TabIndex = 13;
            this.tbDebutAgeHi.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "至";
            // 
            // tbDebutAgeLo
            // 
            this.tbDebutAgeLo.Location = new System.Drawing.Point(117, 118);
            this.tbDebutAgeLo.Name = "tbDebutAgeLo";
            this.tbDebutAgeLo.Size = new System.Drawing.Size(63, 22);
            this.tbDebutAgeLo.TabIndex = 11;
            this.tbDebutAgeLo.Text = "15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "登場年齡";
            // 
            // tbAgeHi
            // 
            this.tbAgeHi.Location = new System.Drawing.Point(209, 146);
            this.tbAgeHi.Name = "tbAgeHi";
            this.tbAgeHi.Size = new System.Drawing.Size(63, 22);
            this.tbAgeHi.TabIndex = 17;
            this.tbAgeHi.Text = "90";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "至";
            // 
            // tbAgeLo
            // 
            this.tbAgeLo.Location = new System.Drawing.Point(117, 146);
            this.tbAgeLo.Name = "tbAgeLo";
            this.tbAgeLo.Size = new System.Drawing.Size(63, 22);
            this.tbAgeLo.TabIndex = 15;
            this.tbAgeLo.Text = "30";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "壽命";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "年";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "仕官機率";
            // 
            // tbJoinedFactionChance
            // 
            this.tbJoinedFactionChance.Location = new System.Drawing.Point(117, 62);
            this.tbJoinedFactionChance.Name = "tbJoinedFactionChance";
            this.tbJoinedFactionChance.Size = new System.Drawing.Size(63, 22);
            this.tbJoinedFactionChance.TabIndex = 20;
            this.tbJoinedFactionChance.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 372);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnLoadScenario);
            this.Name = "Form1";
            this.Text = "劇本隨機化";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.OpenFileDialog openScenFileDialog;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddPersonHi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddPersonLo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFemaleChance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDebutAgeHi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDebutAgeLo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBornYearHi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBornYearLo;
        private System.Windows.Forms.TextBox tbAgeHi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAgeLo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbJoinedFactionChance;
        private System.Windows.Forms.Label label11;
    }
}

