using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using		GameObjects;


using		System.Data;
using		System.Drawing;
using		System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data.OleDb;




namespace WorldOfTheThreeKingdoms.GameForms

{
    public class formSelectScenario : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private CheckedListBox clbFactions;
        private IContainer components = null;
        private FactionList currentFactions;
        private BindingSource gameScenarioBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lbScenarios;
        public string ScenarioPath;
        private List<string> ScenarioPaths = new List<string>();
        public List<int> SelectedFactionIDs = new List<int>();
        private PictureBox pictureBox1;
        private TextBox tbScenarioDescription;

        public formSelectScenario()
        {
            this.InitializeComponent();
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/ScenarioSelect/Select.wav");
            player.Play();
            this.btnOK.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/OKButtonSelected.png");
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            this.btnOK.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/OKButton.png");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/ScenarioSelect/OK.wav");
            player.Play();
            pictureBox1.Image = Image.FromFile("Resources/ScenarioSelect/OKButtonPressed.png");           
            if (this.lbScenarios.SelectedIndex >= 0)
            {
                this.ScenarioPath = this.ScenarioPaths[this.lbScenarios.SelectedIndex];
                foreach (int num in this.clbFactions.CheckedIndices)
                {
                    this.SelectedFactionIDs.Add(this.currentFactions[num].ID);
                }
                if (this.SelectedFactionIDs.Count == 0)
                {
                    GameGlobal.GlobalVariables.SkyEye = true;
                }
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择剧本。");
            }
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/ScenarioSelect/Select.wav");
            player.Play();
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/CancelButtonSelected.png");
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/CancelButton.png");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/ScenarioSelect/NO.wav");
            player.Play();
            base.DialogResult = DialogResult.No;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void formSelectScenario_Load(object sender, EventArgs e)
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            label1.Image = Image.FromFile("Resources/ScenarioSelect/Scenarios.png");
            label2.Image = Image.FromFile("Resources/ScenarioSelect/Factions.png");
            label3.Image = Image.FromFile("Resources/ScenarioSelect/ScenarioDescription.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("Resources/ScenarioSelect/Background.png");
            this.btnOK.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/OKButton.png");
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/CancelButton.png");
            this.BackgroundImage = Image.FromFile("Resources/ScenarioSelect/Background.jpg");
            string path = "GameData/Scenario/";
            if (!Directory.Exists(path))
            {
                base.Close();
            }
            foreach (string str2 in Directory.GetFiles(path))
            {
                FileInfo info = new FileInfo(str2);
                if (info.Extension.Equals(".mdb"))
                {
                    this.ScenarioPaths.Add(str2);
                    this.SetScenarioDisplayText(str2);
                }
            }
        }

        private void formSelectScenario_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }




        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbScenarios = new System.Windows.Forms.ListBox();
            this.clbFactions = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameScenarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbScenarioDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScenarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScenarios
            // 
            this.lbScenarios.FormattingEnabled = true;
            this.lbScenarios.ItemHeight = 12;
            this.lbScenarios.Location = new System.Drawing.Point(12, 37);
            this.lbScenarios.Name = "lbScenarios";
            this.lbScenarios.Size = new System.Drawing.Size(371, 196);
            this.lbScenarios.TabIndex = 0;
            this.lbScenarios.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectScenario_MouseClick);
            this.lbScenarios.SelectedIndexChanged += new System.EventHandler(this.lbScenarios_SelectedIndexChanged);
            // 
            // clbFactions
            // 
            this.clbFactions.CheckOnClick = true;
            this.clbFactions.FormattingEnabled = true;
            this.clbFactions.Location = new System.Drawing.Point(389, 37);
            this.clbFactions.Name = "clbFactions";
            this.clbFactions.Size = new System.Drawing.Size(293, 324);
            this.clbFactions.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(393, 370);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 45);
            this.btnOK.TabIndex = 2;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseEnter += new System.EventHandler(this.btnOK_MouseEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(543, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 45);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(398, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 5;
            // 
            // gameScenarioBindingSource
            // 
            this.gameScenarioBindingSource.DataSource = typeof(GameObjects.GameScenario);
            // 
            // tbScenarioDescription
            // 
            this.tbScenarioDescription.BackColor = System.Drawing.SystemColors.Window;
            this.tbScenarioDescription.Location = new System.Drawing.Point(12, 272);
            this.tbScenarioDescription.Multiline = true;
            this.tbScenarioDescription.Name = "tbScenarioDescription";
            this.tbScenarioDescription.ReadOnly = true;
            this.tbScenarioDescription.Size = new System.Drawing.Size(370, 143);
            this.tbScenarioDescription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 440);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // formSelectScenario
            // 
            this.ClientSize = new System.Drawing.Size(700, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbScenarioDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.clbFactions);
            this.Controls.Add(this.lbScenarios);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSelectScenario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择剧本";
            this.Load += new System.EventHandler(this.formSelectScenario_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectScenario_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.gameScenarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lbScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCurrentScenario(this.ScenarioPaths[this.lbScenarios.SelectedIndex]);
        }

        private void SetCurrentScenario(string filename)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            OleDbConnection dbConnection = new OleDbConnection(builder.ConnectionString);
            string gameScenarioDescription = GameScenario.GetGameScenarioDescription(dbConnection);
            this.tbScenarioDescription.Text = gameScenarioDescription;
            this.currentFactions = GameScenario.GetGameScenarioFactions(dbConnection);
            this.clbFactions.Items.Clear();
            foreach (Faction faction in this.currentFactions)
            {
                this.clbFactions.Items.Add(faction.Name);
            }
        }

        private void SetScenarioDisplayText(string filename)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            OleDbConnection dbConnection = new OleDbConnection(builder.ConnectionString);
            string gameScenarioSurveyText = GameScenario.GetGameScenarioSurveyText(dbConnection);
            this.lbScenarios.Items.Add(gameScenarioSurveyText);
        }


    }

 

}
