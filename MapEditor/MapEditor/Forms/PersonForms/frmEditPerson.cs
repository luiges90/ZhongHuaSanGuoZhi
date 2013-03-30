namespace MapEditor.Forms.PersonForms
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.PersonDetail;
    using MapEditor;
    using MapEditor.Forms;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditPerson : Form
    {
        public PersonList AllPersons;
        private Button btnAddClosePerson;
        private Button btnAddHatedPersons;
        private Button btnAddStunt;
        private Button btnApply;
        private Button btnApplySkills;
        private Button btnCancelCombatlTitle;
        private Button btnCancelPersonalTitle;
        private Button btnChangePortrait;
        private Button btnDeleteAllStunt;
        private Button btnDeleteSelectedStunt;
        private Button btnRemoveClosePerson;
        private Button btnRemoveHatedPersons;
        private Button btnSaveTextMessage;
        private ComboBox cbAllStunt;
        private ComboBox cbAmbition;
        private ComboBox cbBornRegion;
        private ComboBox cbCharacter;
        private ComboBox cbCombatTitle;
        private ComboBox cbDeadReason;
        private ComboBox cbFactionColor;
        private ComboBox cbIdealTendency;
        private CheckBox cbOnlySelectFromTheNew;
        private ComboBox cbPersonalLoyalty;
        private ComboBox cbPersonalTitle;
        private ComboBox cbQualification;
        private ComboBox cbStrategyTendency;
        private ComboBox cbValuationOnGovernment;
        private CheckedListBox clb00;
        private CheckedListBox clb01;
        private CheckedListBox clb02;
        private CheckedListBox clb03;
        private CheckedListBox clb04;
        private CheckedListBox clb05;
        private CheckedListBox clb06;
        private CheckedListBox clb07;
        private CheckedListBox clb08;
        private CheckedListBox clb09;
        private CheckedListBox clb10;
        private CheckedListBox clb11;
        private IContainer components = null;
        private GroupBox gbClosePersons;
        private GroupBox gbHatedPersons;
        private GroupBox gbSkills;
        private GroupBox gbStunt;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label9;
        private ListBox lbClosePersons;
        private ListBox lbHatedPersons;
        private ListBox lbStunt;
        public formMapEditor MainForm;
        private bool multiEdit = false;
        private PictureBox pbHead;
        private Person person;
        public PersonList Persons;
        private RichTextBox rtbAntiAttack;
        private RichTextBox rtbBiographyBrief;
        private RichTextBox rtbBiographyHistory;
        private RichTextBox rtbBiographyRomance;
        private RichTextBox rtbBreakWall;
        private RichTextBox rtbCastDeepChaos;
        private RichTextBox rtbChaos;
        private RichTextBox rtbControversyInitiativeWin;
        private RichTextBox rtbControversyPassiveWin;
        private RichTextBox rtbCriticalStrike;
        private RichTextBox rtbCriticalStrikeOnArchitecture;
        private RichTextBox rtbDeepChaos;
        private RichTextBox rtbDualInitiativeWin;
        private RichTextBox rtbDualPassiveWin;
        private RichTextBox rtbHelpedByStratagem;
        private RichTextBox rtbOutburstAngry;
        private RichTextBox rtbOutburstQuiet;
        private RichTextBox rtbReceiveCriticalStrike;
        private RichTextBox rtbRecoverFromChaos;
        private RichTextBox rtbResistHarmfulStratagem;
        private RichTextBox rtbResistHelpfulStratagem;
        private RichTextBox rtbRout;
        private RichTextBox rtbSurround;
        private RichTextBox rtbTrappedByStratagem;
        private StatusStrip ssInfo;
        private TabControl tabPerson;
        private TextBox tbAvailableLocation;
        private TextBox tbAvailableYear;
        private TextBox tbBornYear;
        private TextBox tbBraveness;
        private TextBox tbBrother;
        private TextBox tbCalledName;
        private TextBox tbCalmness;
        private TextBox tbCommand;
        private TextBox tbCommandExperience;
        private TextBox tbDeadYear;
        private TextBox tbFather;
        private TextBox tbGeneration;
        private TextBox tbGivenName;
        private TextBox tbGlamour;
        private TextBox tbGlamourExperience;
        private TextBox tbIdeal;
        private TextBox tbIntelligence;
        private TextBox tbIntelligenceExperience;
        private TextBox tbLoyalty;
        private TextBox tbMother;
        private TextBox tbOldFactionID;
        private TextBox tbPic;
        private TextBox tbPolitics;
        private TextBox tbPoliticsExperience;
        private TextBox tbProhibitedFactionID;
        private TextBox tbSpouse;
        private TextBox tbStrain;
        private TextBox tbStrength;
        private TextBox tbStrengthExperience;
        private TextBox tbSurName;
        private TabPage tpBasic;
        private TabPage tpSkill;
        private TabPage tpTextMessage;
        private ToolStripStatusLabel tsslIDtoName;

        public frmEditPerson()
        {
            this.InitializeComponent();
        }

        private void btnAddClosePerson_Click(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.AllPersons;
                list.ShowDialog();
                foreach (int num in list.IDList)
                {
                    this.lbClosePersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                }
            }
        }

        private void btnAddHatedPersons_Click(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.AllPersons;
                list.ShowDialog();
                foreach (int num in list.IDList)
                {
                    this.lbHatedPersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                }
            }
        }

        private void btnAddStunt_Click(object sender, EventArgs e)
        {
            Stunt selectedItem = this.cbAllStunt.SelectedItem as Stunt;
            if (selectedItem != null)
            {
                if (this.person.Stunts.GetStunt(selectedItem.ID) == null)
                {
                    this.person.Stunts.AddStunt(selectedItem);
                }
                this.RefreshStuntList();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.multiEdit)
            {
                foreach (Person person in this.Persons)
                {
                }
            }
            else
            {
                this.SavePersonBasicData(this.person);
            }
        }

        private void btnApplySkills_Click(object sender, EventArgs e)
        {
            if (this.multiEdit)
            {
                foreach (Person person in this.Persons)
                {
                }
            }
            else
            {
                this.SavePersonSkills(this.person);
                this.person.PersonalTitle = this.cbPersonalTitle.SelectedItem as Title;
                this.person.CombatTitle = this.cbCombatTitle.SelectedItem as Title;
            }
        }

        private void btnCancelCombatlTitle_Click(object sender, EventArgs e)
        {
            this.cbCombatTitle.SelectedItem = null;
        }

        private void btnCancelPersonalTitle_Click(object sender, EventArgs e)
        {
            this.cbPersonalTitle.SelectedItem = null;
        }

        private void btnChangePortrait_Click(object sender, EventArgs e)
        {
            frmSelectPortrait portrait = new frmSelectPortrait();
            portrait.MainForm = this.MainForm;
            portrait.person = this.person;
            portrait.OnlySelectFromNew = this.cbOnlySelectFromTheNew.Checked;
            if (portrait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbPic.Text = this.person.PictureIndex.ToString();
                this.pbHead.Image = this.MainForm.GetPersonPortrait(this.person.PictureIndex);
            }
        }

        private void btnDeleteAllStunt_Click(object sender, EventArgs e)
        {
            this.person.Stunts.Clear();
            this.RefreshStuntList();
        }

        private void btnDeleteSelectedStunt_Click(object sender, EventArgs e)
        {
            Stunt selectedItem = this.lbStunt.SelectedItem as Stunt;
            if (selectedItem != null)
            {
                this.person.Stunts.Stunts.Remove(selectedItem.ID);
                this.RefreshStuntList();
            }
        }

        private void btnRemoveClosePerson_Click(object sender, EventArgs e)
        {
            if (this.lbClosePersons.SelectedIndex >= 0)
            {
                this.lbClosePersons.Items.RemoveAt(this.lbClosePersons.SelectedIndex);
            }
        }

        private void btnRemoveHatedPersons_Click(object sender, EventArgs e)
        {
            if (this.lbHatedPersons.SelectedIndex >= 0)
            {
                this.lbHatedPersons.Items.RemoveAt(this.lbHatedPersons.SelectedIndex);
            }
        }

        private void btnSaveTextMessage_Click(object sender, EventArgs e)
        {
            StaticMethods.LoadFromString(this.person.PersonTextMessage.CriticalStrike, this.rtbCriticalStrike.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.CriticalStrikeOnArchitecture, this.rtbCriticalStrikeOnArchitecture.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.DeepChaos, this.rtbDeepChaos.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.DualInitiativeWin, this.rtbDualInitiativeWin.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.DualPassiveWin, this.rtbDualPassiveWin.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.ControversyInitiativeWin, this.rtbControversyInitiativeWin.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.ControversyPassiveWin, this.rtbControversyPassiveWin.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.AntiAttack, this.rtbAntiAttack.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.BreakWall, this.rtbBreakWall.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.CastDeepChaos, this.rtbCastDeepChaos.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.Chaos, this.rtbChaos.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.HelpedByStratagem, this.rtbHelpedByStratagem.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.OutburstAngry, this.rtbOutburstAngry.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.OutburstQuiet, this.rtbOutburstQuiet.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.ReceiveCriticalStrike, this.rtbReceiveCriticalStrike.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.RecoverFromChaos, this.rtbRecoverFromChaos.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.ResistHarmfulStratagem, this.rtbResistHarmfulStratagem.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.ResistHelpfulStratagem, this.rtbResistHelpfulStratagem.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.Rout, this.rtbRout.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.Surround, this.rtbSurround.Text);
            StaticMethods.LoadFromString(this.person.PersonTextMessage.TrappedByStratagem, this.rtbTrappedByStratagem.Text);
        }

        private void cbFactionColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Microsoft.Xna.Framework.Graphics.Color color = (Microsoft.Xna.Framework.Graphics.Color) this.cbFactionColor.Items[e.Index];
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.FromArgb((int) color.PackedValue), (float) e.Bounds.Height), e.Bounds.Left, e.Bounds.Top + (e.Bounds.Height / 2), e.Bounds.Right, e.Bounds.Top + (e.Bounds.Height / 2));
        }

        private void cbFactionColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.FactionColor = this.cbFactionColor.SelectedIndex;
            Microsoft.Xna.Framework.Graphics.Color color = this.person.Scenario.GameCommonData.AllColors[this.person.PersonBiography.FactionColor];
            this.cbFactionColor.BackColor = System.Drawing.Color.FromArgb((int) color.PackedValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmEditPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (base.Owner is frmPersonList)
            {
                (base.Owner as frmPersonList).EditPersonTabIndex = this.tabPerson.SelectedIndex;
            }
        }

        private void frmEditPerson_Load(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count > 0))
            {
                if (this.Persons.Count == 1)
                {
                    this.person = this.Persons[0] as Person;
                    this.multiEdit = false;
                    this.InitializeTabData();
                }
                else
                {
                    this.person = null;
                    this.multiEdit = true;
                    this.tabPerson.TabPages.Remove(this.tpBasic);
                }
            }
        }

        private void InitializeComponent()
        {
            this.tpSkill = new TabPage();
            this.gbStunt = new GroupBox();
            this.btnDeleteAllStunt = new Button();
            this.btnDeleteSelectedStunt = new Button();
            this.btnAddStunt = new Button();
            this.cbAllStunt = new ComboBox();
            this.lbStunt = new ListBox();
            this.btnCancelCombatlTitle = new Button();
            this.btnCancelPersonalTitle = new Button();
            this.label53 = new Label();
            this.cbCombatTitle = new ComboBox();
            this.label52 = new Label();
            this.cbPersonalTitle = new ComboBox();
            this.btnApplySkills = new Button();
            this.gbSkills = new GroupBox();
            this.label51 = new Label();
            this.clb08 = new CheckedListBox();
            this.label50 = new Label();
            this.clb07 = new CheckedListBox();
            this.label49 = new Label();
            this.clb04 = new CheckedListBox();
            this.label48 = new Label();
            this.clb05 = new CheckedListBox();
            this.label47 = new Label();
            this.clb01 = new CheckedListBox();
            this.label44 = new Label();
            this.label43 = new Label();
            this.label42 = new Label();
            this.label41 = new Label();
            this.label40 = new Label();
            this.label39 = new Label();
            this.clb11 = new CheckedListBox();
            this.clb10 = new CheckedListBox();
            this.clb09 = new CheckedListBox();
            this.clb06 = new CheckedListBox();
            this.clb03 = new CheckedListBox();
            this.clb02 = new CheckedListBox();
            this.clb00 = new CheckedListBox();
            this.tpBasic = new TabPage();
            this.label57 = new Label();
            this.rtbBiographyHistory = new RichTextBox();
            this.label56 = new Label();
            this.rtbBiographyRomance = new RichTextBox();
            this.label46 = new Label();
            this.cbOnlySelectFromTheNew = new CheckBox();
            this.btnChangePortrait = new Button();
            this.pbHead = new PictureBox();
            this.label55 = new Label();
            this.cbIdealTendency = new ComboBox();
            this.label54 = new Label();
            this.rtbBiographyBrief = new RichTextBox();
            this.tbAvailableLocation = new TextBox();
            this.label45 = new Label();
            this.ssInfo = new StatusStrip();
            this.tsslIDtoName = new ToolStripStatusLabel();
            this.btnApply = new Button();
            this.gbHatedPersons = new GroupBox();
            this.btnRemoveHatedPersons = new Button();
            this.btnAddHatedPersons = new Button();
            this.lbHatedPersons = new ListBox();
            this.gbClosePersons = new GroupBox();
            this.btnRemoveClosePerson = new Button();
            this.btnAddClosePerson = new Button();
            this.lbClosePersons = new ListBox();
            this.cbCharacter = new ComboBox();
            this.label38 = new Label();
            this.cbFactionColor = new ComboBox();
            this.tbProhibitedFactionID = new TextBox();
            this.label36 = new Label();
            this.tbOldFactionID = new TextBox();
            this.label37 = new Label();
            this.label35 = new Label();
            this.cbStrategyTendency = new ComboBox();
            this.label34 = new Label();
            this.cbValuationOnGovernment = new ComboBox();
            this.label33 = new Label();
            this.cbQualification = new ComboBox();
            this.label32 = new Label();
            this.cbAmbition = new ComboBox();
            this.label31 = new Label();
            this.cbPersonalLoyalty = new ComboBox();
            this.tbGeneration = new TextBox();
            this.label30 = new Label();
            this.tbBrother = new TextBox();
            this.label25 = new Label();
            this.tbSpouse = new TextBox();
            this.label26 = new Label();
            this.tbMother = new TextBox();
            this.label27 = new Label();
            this.tbFather = new TextBox();
            this.label28 = new Label();
            this.tbStrain = new TextBox();
            this.label29 = new Label();
            this.label24 = new Label();
            this.cbBornRegion = new ComboBox();
            this.tbLoyalty = new TextBox();
            this.label23 = new Label();
            this.tbCalmness = new TextBox();
            this.label22 = new Label();
            this.tbBraveness = new TextBox();
            this.label21 = new Label();
            this.tbGlamourExperience = new TextBox();
            this.label16 = new Label();
            this.tbPoliticsExperience = new TextBox();
            this.label17 = new Label();
            this.tbIntelligenceExperience = new TextBox();
            this.label18 = new Label();
            this.tbCommandExperience = new TextBox();
            this.label19 = new Label();
            this.tbStrengthExperience = new TextBox();
            this.label20 = new Label();
            this.tbGlamour = new TextBox();
            this.label15 = new Label();
            this.tbPolitics = new TextBox();
            this.label14 = new Label();
            this.tbIntelligence = new TextBox();
            this.label13 = new Label();
            this.tbCommand = new TextBox();
            this.label12 = new Label();
            this.tbStrength = new TextBox();
            this.label11 = new Label();
            this.label10 = new Label();
            this.cbDeadReason = new ComboBox();
            this.tbDeadYear = new TextBox();
            this.label7 = new Label();
            this.tbBornYear = new TextBox();
            this.label8 = new Label();
            this.tbAvailableYear = new TextBox();
            this.label9 = new Label();
            this.label6 = new Label();
            this.tbIdeal = new TextBox();
            this.label5 = new Label();
            this.tbPic = new TextBox();
            this.label4 = new Label();
            this.tbCalledName = new TextBox();
            this.label3 = new Label();
            this.tbGivenName = new TextBox();
            this.label2 = new Label();
            this.tbSurName = new TextBox();
            this.label1 = new Label();
            this.tabPerson = new TabControl();
            this.tpTextMessage = new TabPage();
            this.label59 = new Label();
            this.rtbControversyPassiveWin = new RichTextBox();
            this.label79 = new Label();
            this.rtbControversyInitiativeWin = new RichTextBox();
            this.btnSaveTextMessage = new Button();
            this.label58 = new Label();
            this.label78 = new Label();
            this.rtbOutburstQuiet = new RichTextBox();
            this.label77 = new Label();
            this.rtbOutburstAngry = new RichTextBox();
            this.label76 = new Label();
            this.rtbBreakWall = new RichTextBox();
            this.label75 = new Label();
            this.rtbAntiAttack = new RichTextBox();
            this.label74 = new Label();
            this.rtbResistHelpfulStratagem = new RichTextBox();
            this.label73 = new Label();
            this.rtbResistHarmfulStratagem = new RichTextBox();
            this.label72 = new Label();
            this.rtbHelpedByStratagem = new RichTextBox();
            this.label71 = new Label();
            this.rtbTrappedByStratagem = new RichTextBox();
            this.label70 = new Label();
            this.rtbRecoverFromChaos = new RichTextBox();
            this.label69 = new Label();
            this.rtbCastDeepChaos = new RichTextBox();
            this.label68 = new Label();
            this.rtbDeepChaos = new RichTextBox();
            this.label67 = new Label();
            this.rtbChaos = new RichTextBox();
            this.label66 = new Label();
            this.rtbDualPassiveWin = new RichTextBox();
            this.label65 = new Label();
            this.rtbDualInitiativeWin = new RichTextBox();
            this.label64 = new Label();
            this.rtbRout = new RichTextBox();
            this.label63 = new Label();
            this.rtbSurround = new RichTextBox();
            this.label62 = new Label();
            this.rtbReceiveCriticalStrike = new RichTextBox();
            this.label61 = new Label();
            this.rtbCriticalStrikeOnArchitecture = new RichTextBox();
            this.label60 = new Label();
            this.rtbCriticalStrike = new RichTextBox();
            this.tpSkill.SuspendLayout();
            this.gbStunt.SuspendLayout();
            this.gbSkills.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((ISupportInitialize) this.pbHead).BeginInit();
            this.ssInfo.SuspendLayout();
            this.gbHatedPersons.SuspendLayout();
            this.gbClosePersons.SuspendLayout();
            this.tabPerson.SuspendLayout();
            this.tpTextMessage.SuspendLayout();
            base.SuspendLayout();
            this.tpSkill.Controls.Add(this.gbStunt);
            this.tpSkill.Controls.Add(this.btnCancelCombatlTitle);
            this.tpSkill.Controls.Add(this.btnCancelPersonalTitle);
            this.tpSkill.Controls.Add(this.label53);
            this.tpSkill.Controls.Add(this.cbCombatTitle);
            this.tpSkill.Controls.Add(this.label52);
            this.tpSkill.Controls.Add(this.cbPersonalTitle);
            this.tpSkill.Controls.Add(this.btnApplySkills);
            this.tpSkill.Controls.Add(this.gbSkills);
            this.tpSkill.Location = new Point(4, 0x16);
            this.tpSkill.Name = "tpSkill";
            this.tpSkill.Padding = new Padding(3);
            this.tpSkill.Size = new Size(0x341, 0x243);
            this.tpSkill.TabIndex = 1;
            this.tpSkill.Text = "技能";
            this.tpSkill.UseVisualStyleBackColor = true;
            this.gbStunt.Controls.Add(this.btnDeleteAllStunt);
            this.gbStunt.Controls.Add(this.btnDeleteSelectedStunt);
            this.gbStunt.Controls.Add(this.btnAddStunt);
            this.gbStunt.Controls.Add(this.cbAllStunt);
            this.gbStunt.Controls.Add(this.lbStunt);
            this.gbStunt.Location = new Point(620, 0x12);
            this.gbStunt.Name = "gbStunt";
            this.gbStunt.Size = new Size(200, 0x1af);
            this.gbStunt.TabIndex = 160;
            this.gbStunt.TabStop = false;
            this.gbStunt.Text = "战斗特技列表";
            this.btnDeleteAllStunt.Location = new Point(0x67, 0x187);
            this.btnDeleteAllStunt.Name = "btnDeleteAllStunt";
            this.btnDeleteAllStunt.Size = new Size(0x5b, 0x17);
            this.btnDeleteAllStunt.TabIndex = 4;
            this.btnDeleteAllStunt.Text = "删除全部";
            this.btnDeleteAllStunt.UseVisualStyleBackColor = true;
            this.btnDeleteAllStunt.Click += new EventHandler(this.btnDeleteAllStunt_Click);
            this.btnDeleteSelectedStunt.Location = new Point(6, 0x187);
            this.btnDeleteSelectedStunt.Name = "btnDeleteSelectedStunt";
            this.btnDeleteSelectedStunt.Size = new Size(0x5b, 0x17);
            this.btnDeleteSelectedStunt.TabIndex = 3;
            this.btnDeleteSelectedStunt.Text = "删除选中";
            this.btnDeleteSelectedStunt.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedStunt.Click += new EventHandler(this.btnDeleteSelectedStunt_Click);
            this.btnAddStunt.Location = new Point(0x87, 0x161);
            this.btnAddStunt.Name = "btnAddStunt";
            this.btnAddStunt.Size = new Size(0x37, 0x17);
            this.btnAddStunt.TabIndex = 2;
            this.btnAddStunt.Text = "添加";
            this.btnAddStunt.UseVisualStyleBackColor = true;
            this.btnAddStunt.Click += new EventHandler(this.btnAddStunt_Click);
            this.cbAllStunt.FormattingEnabled = true;
            this.cbAllStunt.Location = new Point(6, 0x163);
            this.cbAllStunt.Name = "cbAllStunt";
            this.cbAllStunt.Size = new Size(0x79, 20);
            this.cbAllStunt.TabIndex = 1;
            this.lbStunt.FormattingEnabled = true;
            this.lbStunt.ItemHeight = 12;
            this.lbStunt.Location = new Point(6, 20);
            this.lbStunt.Name = "lbStunt";
            this.lbStunt.Size = new Size(0xb8, 0x13c);
            this.lbStunt.TabIndex = 0;
            this.btnCancelCombatlTitle.Location = new Point(0xf5, 0x1eb);
            this.btnCancelCombatlTitle.Name = "btnCancelCombatlTitle";
            this.btnCancelCombatlTitle.Size = new Size(0x4b, 0x17);
            this.btnCancelCombatlTitle.TabIndex = 0x9f;
            this.btnCancelCombatlTitle.Text = "取消称号";
            this.btnCancelCombatlTitle.UseVisualStyleBackColor = true;
            this.btnCancelCombatlTitle.Click += new EventHandler(this.btnCancelCombatlTitle_Click);
            this.btnCancelPersonalTitle.Location = new Point(0xf5, 0x1d3);
            this.btnCancelPersonalTitle.Name = "btnCancelPersonalTitle";
            this.btnCancelPersonalTitle.Size = new Size(0x4b, 0x17);
            this.btnCancelPersonalTitle.TabIndex = 0x9e;
            this.btnCancelPersonalTitle.Text = "取消称号";
            this.btnCancelPersonalTitle.UseVisualStyleBackColor = true;
            this.btnCancelPersonalTitle.Click += new EventHandler(this.btnCancelPersonalTitle_Click);
            this.label53.AutoSize = true;
            this.label53.Location = new Point(0x1c, 0x1f0);
            this.label53.Name = "label53";
            this.label53.Size = new Size(0x35, 12);
            this.label53.TabIndex = 0x9d;
            this.label53.Text = "战斗称号";
            this.cbCombatTitle.FormattingEnabled = true;
            this.cbCombatTitle.Location = new Point(90, 0x1ed);
            this.cbCombatTitle.MaxDropDownItems = 20;
            this.cbCombatTitle.Name = "cbCombatTitle";
            this.cbCombatTitle.Size = new Size(0x95, 20);
            this.cbCombatTitle.TabIndex = 0x9c;
            this.label52.AutoSize = true;
            this.label52.Location = new Point(0x1c, 470);
            this.label52.Name = "label52";
            this.label52.Size = new Size(0x35, 12);
            this.label52.TabIndex = 0x9b;
            this.label52.Text = "个人称号";
            this.cbPersonalTitle.FormattingEnabled = true;
            this.cbPersonalTitle.Location = new Point(90, 0x1d3);
            this.cbPersonalTitle.MaxDropDownItems = 20;
            this.cbPersonalTitle.Name = "cbPersonalTitle";
            this.cbPersonalTitle.Size = new Size(0x95, 20);
            this.cbPersonalTitle.TabIndex = 0x9a;
            this.btnApplySkills.Location = new Point(0x2df, 0x213);
            this.btnApplySkills.Name = "btnApplySkills";
            this.btnApplySkills.Size = new Size(0x4b, 0x17);
            this.btnApplySkills.TabIndex = 0x99;
            this.btnApplySkills.Text = "应用修改";
            this.btnApplySkills.UseVisualStyleBackColor = true;
            this.btnApplySkills.Click += new EventHandler(this.btnApplySkills_Click);
            this.gbSkills.Controls.Add(this.label51);
            this.gbSkills.Controls.Add(this.clb08);
            this.gbSkills.Controls.Add(this.label50);
            this.gbSkills.Controls.Add(this.clb07);
            this.gbSkills.Controls.Add(this.label49);
            this.gbSkills.Controls.Add(this.clb04);
            this.gbSkills.Controls.Add(this.label48);
            this.gbSkills.Controls.Add(this.clb05);
            this.gbSkills.Controls.Add(this.label47);
            this.gbSkills.Controls.Add(this.clb01);
            this.gbSkills.Controls.Add(this.label44);
            this.gbSkills.Controls.Add(this.label43);
            this.gbSkills.Controls.Add(this.label42);
            this.gbSkills.Controls.Add(this.label41);
            this.gbSkills.Controls.Add(this.label40);
            this.gbSkills.Controls.Add(this.label39);
            this.gbSkills.Controls.Add(this.clb11);
            this.gbSkills.Controls.Add(this.clb10);
            this.gbSkills.Controls.Add(this.clb09);
            this.gbSkills.Controls.Add(this.clb06);
            this.gbSkills.Controls.Add(this.clb03);
            this.gbSkills.Controls.Add(this.clb02);
            this.gbSkills.Controls.Add(this.clb00);
            this.gbSkills.Location = new Point(0x16, 0x12);
            this.gbSkills.Name = "gbSkills";
            this.gbSkills.Size = new Size(0x250, 0x1af);
            this.gbSkills.TabIndex = 6;
            this.gbSkills.TabStop = false;
            this.gbSkills.Text = "技能列表";
            this.label51.AutoSize = true;
            this.label51.Location = new Point(0x18, 240);
            this.label51.Name = "label51";
            this.label51.Size = new Size(0x1d, 12);
            this.label51.TabIndex = 30;
            this.label51.Text = "领兵";
            this.clb08.CheckOnClick = true;
            this.clb08.ColumnWidth = 70;
            this.clb08.FormattingEnabled = true;
            this.clb08.Items.AddRange(new object[] { "练步", "练弩", "练骑", "练水", "练器", "保护", "爱卒" });
            this.clb08.Location = new Point(0x44, 0xec);
            this.clb08.MultiColumn = true;
            this.clb08.Name = "clb08";
            this.clb08.Size = new Size(0x1fd, 36);
            this.clb08.TabIndex = 0x1d;
            this.label50.AutoSize = true;
            this.label50.Location = new Point(0x18, 0xd6);
            this.label50.Name = "label50";
            this.label50.Size = new Size(0x1d, 12);
            this.label50.TabIndex = 0x1c;
            this.label50.Text = "器械";
            this.clb07.CheckOnClick = true;
            this.clb07.ColumnWidth = 70;
            this.clb07.FormattingEnabled = true;
            this.clb07.Items.AddRange(new object[] { "冲车", "井栏", "投石", "粉碎", "箭岚", "巨石", "坚固" });
            this.clb07.Location = new Point(0x44, 210);
            this.clb07.MultiColumn = true;
            this.clb07.Name = "clb07";
            this.clb07.Size = new Size(0x1fd, 36);
            this.clb07.TabIndex = 0x1b;
            this.label49.AutoSize = true;
            this.label49.Location = new Point(0x18, 0x88);
            this.label49.Name = "label49";
            this.label49.Size = new Size(0x1d, 12);
            this.label49.TabIndex = 0x1a;
            this.label49.Text = "弩兵";
            this.clb04.CheckOnClick = true;
            this.clb04.ColumnWidth = 70;
            this.clb04.FormattingEnabled = true;
            this.clb04.Items.AddRange(new object[] { "火矢", "贯穿", "散射", "致命", "善攻", "善守", "燎原" });
            this.clb04.Location = new Point(0x44, 0x84);
            this.clb04.MultiColumn = true;
            this.clb04.Name = "clb04";
            this.clb04.Size = new Size(0x1fd, 36);
            this.clb04.TabIndex = 0x19;
            this.label48.AutoSize = true;
            this.label48.Location = new Point(0x18, 0xa2);
            this.label48.Name = "label48";
            this.label48.Size = new Size(0x1d, 12);
            this.label48.TabIndex = 0x18;
            this.label48.Text = "骑兵";
            this.clb05.CheckOnClick = true;
            this.clb05.ColumnWidth = 70;
            this.clb05.FormattingEnabled = true;
            this.clb05.Items.AddRange(new object[] { "进击", "冲击", "突击", "纵横", "善攻", "善守", "雷霆" });
            this.clb05.Location = new Point(0x44, 0x9e);
            this.clb05.MultiColumn = true;
            this.clb05.Name = "clb05";
            this.clb05.Size = new Size(0x1fd, 36);
            this.clb05.TabIndex = 0x17;
            this.label47.AutoSize = true;
            this.label47.Location = new Point(0x18, 0x38);
            this.label47.Name = "label47";
            this.label47.Size = new Size(0x23, 12);
            this.label47.TabIndex = 0x16;
            this.label47.Text = "内政2";
            this.clb01.CheckOnClick = true;
            this.clb01.ColumnWidth = 70;
            this.clb01.FormattingEnabled = true;
            this.clb01.Items.AddRange(new object[] { "开垦", "商才", "发明", "威严", "仁德", "筑城", "补充" });
            this.clb01.Location = new Point(0x44, 0x34);
            this.clb01.MultiColumn = true;
            this.clb01.Name = "clb01";
            this.clb01.Size = new Size(0x1fd, 36);
            this.clb01.TabIndex = 0x15;
            this.label44.AutoSize = true;
            this.label44.Location = new Point(0x18, 0x123);
            this.label44.Name = "label44";
            this.label44.Size = new Size(0x1d, 12);
            this.label44.TabIndex = 18;
            this.label44.Text = "策略";
            this.label43.AutoSize = true;
            this.label43.Location = new Point(0x18, 0x10a);
            this.label43.Name = "label43";
            this.label43.Size = new Size(0x1d, 12);
            this.label43.TabIndex = 17;
            this.label43.Text = "计略";
            this.label42.AutoSize = true;
            this.label42.Location = new Point(0x18, 0xbc);
            this.label42.Name = "label42";
            this.label42.Size = new Size(0x1d, 12);
            this.label42.TabIndex = 16;
            this.label42.Text = "水军";
            this.label41.AutoSize = true;
            this.label41.Location = new Point(0x18, 110);
            this.label41.Name = "label41";
            this.label41.Size = new Size(0x1d, 12);
            this.label41.TabIndex = 15;
            this.label41.Text = "步兵";
            this.label40.AutoSize = true;
            this.label40.Location = new Point(0x18, 0x54);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x1d, 12);
            this.label40.TabIndex = 14;
            this.label40.Text = "行军";
            this.label39.AutoSize = true;
            this.label39.Location = new Point(0x18, 30);
            this.label39.Name = "label39";
            this.label39.Size = new Size(0x23, 12);
            this.label39.TabIndex = 13;
            this.label39.Text = "内政1";
            this.clb11.CheckOnClick = true;
            this.clb11.ColumnWidth = 70;
            this.clb11.FormattingEnabled = true;
            this.clb11.Items.AddRange(new object[] { "医治" });
            this.clb11.Location = new Point(0x44, 0x13A);
            this.clb11.MultiColumn = true;
            this.clb11.Name = "clb11";
            this.clb11.Size = new Size(0x1fd, 36);
            this.clb11.TabIndex = 12;
            this.clb10.CheckOnClick = true;
            this.clb10.ColumnWidth = 70;
            this.clb10.FormattingEnabled = true;
            this.clb10.Items.AddRange(new object[] { "情报", "间谍", "破坏", "煽动", "流言", "搜索", "说服" });
            this.clb10.Location = new Point(0x44, 0x120);
            this.clb10.MultiColumn = true;
            this.clb10.Name = "clb10";
            this.clb10.Size = new Size(0x1fd, 36);
            this.clb10.TabIndex = 11;

            this.clb09.CheckOnClick = true;
            this.clb09.ColumnWidth = 70;
            this.clb09.FormattingEnabled = true;
            this.clb09.Items.AddRange(new object[] { "攻心", "扰乱", "侦查", "埋伏", "火攻", "防火", "鼓舞" });
            this.clb09.Location = new Point(0x44, 0x106);
            this.clb09.MultiColumn = true;
            this.clb09.Name = "clb09";
            this.clb09.Size = new Size(0x1fd, 36);
            this.clb09.TabIndex = 10;
            this.clb06.CheckOnClick = true;
            this.clb06.ColumnWidth = 70;
            this.clb06.FormattingEnabled = true;
            this.clb06.Items.AddRange(new object[] { "涉水", "穿梭", "箭雨", "猛撞", "善攻", "善守", "水战" });
            this.clb06.Location = new Point(0x44, 0xb8);
            this.clb06.MultiColumn = true;
            this.clb06.Name = "clb06";
            this.clb06.Size = new Size(0x1fd, 36);
            this.clb06.TabIndex = 9;
            this.clb03.CheckOnClick = true;
            this.clb03.ColumnWidth = 70;
            this.clb03.FormattingEnabled = true;
            this.clb03.Items.AddRange(new object[] { "大盾", "枪阵", "旋风", "坚阵", "善攻", "善守", "破甲" });
            this.clb03.Location = new Point(0x44, 0x6a);
            this.clb03.MultiColumn = true;
            this.clb03.Name = "clb03";
            this.clb03.Size = new Size(0x1fd, 36);
            this.clb03.TabIndex = 8;
            this.clb02.CheckOnClick = true;
            this.clb02.ColumnWidth = 70;
            this.clb02.FormattingEnabled = true;
            this.clb02.Items.AddRange(new object[] { "驰骋", "穿林", "翻山", "操舵", "强行", "推进", "负载" });
            this.clb02.Location = new Point(0x44, 80);
            this.clb02.MultiColumn = true;
            this.clb02.Name = "clb02";
            this.clb02.Size = new Size(0x1fd, 36);
            this.clb02.TabIndex = 7;
            this.clb00.CheckOnClick = true;
            this.clb00.ColumnWidth = 70;
            this.clb00.FormattingEnabled = true;
            this.clb00.Items.AddRange(new object[] { "农业", "商业", "技术", "统治", "民心", "耐久", "训练" });
            this.clb00.Location = new Point(0x44, 0x1a);
            this.clb00.MultiColumn = true;
            this.clb00.Name = "clb00";
            this.clb00.Size = new Size(0x1fd, 36);
            this.clb00.TabIndex = 6;
            this.tpBasic.Controls.Add(this.label57);
            this.tpBasic.Controls.Add(this.rtbBiographyHistory);
            this.tpBasic.Controls.Add(this.label56);
            this.tpBasic.Controls.Add(this.rtbBiographyRomance);
            this.tpBasic.Controls.Add(this.label46);
            this.tpBasic.Controls.Add(this.cbOnlySelectFromTheNew);
            this.tpBasic.Controls.Add(this.btnChangePortrait);
            this.tpBasic.Controls.Add(this.pbHead);
            this.tpBasic.Controls.Add(this.label55);
            this.tpBasic.Controls.Add(this.cbIdealTendency);
            this.tpBasic.Controls.Add(this.label54);
            this.tpBasic.Controls.Add(this.rtbBiographyBrief);
            this.tpBasic.Controls.Add(this.tbAvailableLocation);
            this.tpBasic.Controls.Add(this.label45);
            this.tpBasic.Controls.Add(this.ssInfo);
            this.tpBasic.Controls.Add(this.btnApply);
            this.tpBasic.Controls.Add(this.gbHatedPersons);
            this.tpBasic.Controls.Add(this.gbClosePersons);
            this.tpBasic.Controls.Add(this.cbCharacter);
            this.tpBasic.Controls.Add(this.label38);
            this.tpBasic.Controls.Add(this.cbFactionColor);
            this.tpBasic.Controls.Add(this.tbProhibitedFactionID);
            this.tpBasic.Controls.Add(this.label36);
            this.tpBasic.Controls.Add(this.tbOldFactionID);
            this.tpBasic.Controls.Add(this.label37);
            this.tpBasic.Controls.Add(this.label35);
            this.tpBasic.Controls.Add(this.cbStrategyTendency);
            this.tpBasic.Controls.Add(this.label34);
            this.tpBasic.Controls.Add(this.cbValuationOnGovernment);
            this.tpBasic.Controls.Add(this.label33);
            this.tpBasic.Controls.Add(this.cbQualification);
            this.tpBasic.Controls.Add(this.label32);
            this.tpBasic.Controls.Add(this.cbAmbition);
            this.tpBasic.Controls.Add(this.label31);
            this.tpBasic.Controls.Add(this.cbPersonalLoyalty);
            this.tpBasic.Controls.Add(this.tbGeneration);
            this.tpBasic.Controls.Add(this.label30);
            this.tpBasic.Controls.Add(this.tbBrother);
            this.tpBasic.Controls.Add(this.label25);
            this.tpBasic.Controls.Add(this.tbSpouse);
            this.tpBasic.Controls.Add(this.label26);
            this.tpBasic.Controls.Add(this.tbMother);
            this.tpBasic.Controls.Add(this.label27);
            this.tpBasic.Controls.Add(this.tbFather);
            this.tpBasic.Controls.Add(this.label28);
            this.tpBasic.Controls.Add(this.tbStrain);
            this.tpBasic.Controls.Add(this.label29);
            this.tpBasic.Controls.Add(this.label24);
            this.tpBasic.Controls.Add(this.cbBornRegion);
            this.tpBasic.Controls.Add(this.tbLoyalty);
            this.tpBasic.Controls.Add(this.label23);
            this.tpBasic.Controls.Add(this.tbCalmness);
            this.tpBasic.Controls.Add(this.label22);
            this.tpBasic.Controls.Add(this.tbBraveness);
            this.tpBasic.Controls.Add(this.label21);
            this.tpBasic.Controls.Add(this.tbGlamourExperience);
            this.tpBasic.Controls.Add(this.label16);
            this.tpBasic.Controls.Add(this.tbPoliticsExperience);
            this.tpBasic.Controls.Add(this.label17);
            this.tpBasic.Controls.Add(this.tbIntelligenceExperience);
            this.tpBasic.Controls.Add(this.label18);
            this.tpBasic.Controls.Add(this.tbCommandExperience);
            this.tpBasic.Controls.Add(this.label19);
            this.tpBasic.Controls.Add(this.tbStrengthExperience);
            this.tpBasic.Controls.Add(this.label20);
            this.tpBasic.Controls.Add(this.tbGlamour);
            this.tpBasic.Controls.Add(this.label15);
            this.tpBasic.Controls.Add(this.tbPolitics);
            this.tpBasic.Controls.Add(this.label14);
            this.tpBasic.Controls.Add(this.tbIntelligence);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.tbCommand);
            this.tpBasic.Controls.Add(this.label12);
            this.tpBasic.Controls.Add(this.tbStrength);
            this.tpBasic.Controls.Add(this.label11);
            this.tpBasic.Controls.Add(this.label10);
            this.tpBasic.Controls.Add(this.cbDeadReason);
            this.tpBasic.Controls.Add(this.tbDeadYear);
            this.tpBasic.Controls.Add(this.label7);
            this.tpBasic.Controls.Add(this.tbBornYear);
            this.tpBasic.Controls.Add(this.label8);
            this.tpBasic.Controls.Add(this.tbAvailableYear);
            this.tpBasic.Controls.Add(this.label9);
            this.tpBasic.Controls.Add(this.label6);
            this.tpBasic.Controls.Add(this.tbIdeal);
            this.tpBasic.Controls.Add(this.label5);
            this.tpBasic.Controls.Add(this.tbPic);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.tbCalledName);
            this.tpBasic.Controls.Add(this.label3);
            this.tpBasic.Controls.Add(this.tbGivenName);
            this.tpBasic.Controls.Add(this.label2);
            this.tpBasic.Controls.Add(this.tbSurName);
            this.tpBasic.Controls.Add(this.label1);
            this.tpBasic.Location = new Point(4, 0x16);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new Padding(3);
            this.tpBasic.Size = new Size(0x341, 0x243);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "基本";
            this.tpBasic.UseVisualStyleBackColor = true;
            this.label57.AutoSize = true;
            this.label57.Location = new Point(0x110, 0x1d5);
            this.label57.Name = "label57";
            this.label57.Size = new Size(0x1d, 12);
            this.label57.TabIndex = 0xa7;
            this.label57.Text = "历史";
            this.rtbBiographyHistory.BackColor = SystemColors.Window;
            this.rtbBiographyHistory.Location = new Point(0x13f, 0x1bd);
            this.rtbBiographyHistory.Name = "rtbBiographyHistory";
            this.rtbBiographyHistory.Size = new Size(0x1e8, 0x3f);
            this.rtbBiographyHistory.TabIndex = 0xa6;
            this.rtbBiographyHistory.Text = "";
            this.rtbBiographyHistory.TextChanged += new EventHandler(this.rtbBiographyHistory_TextChanged);
            this.label56.AutoSize = true;
            this.label56.Location = new Point(0x110, 0x192);
            this.label56.Name = "label56";
            this.label56.Size = new Size(0x1d, 12);
            this.label56.TabIndex = 0xa5;
            this.label56.Text = "演义";
            this.rtbBiographyRomance.BackColor = SystemColors.Window;
            this.rtbBiographyRomance.Location = new Point(0x13f, 0x179);
            this.rtbBiographyRomance.Name = "rtbBiographyRomance";
            this.rtbBiographyRomance.Size = new Size(0x1e8, 0x3e);
            this.rtbBiographyRomance.TabIndex = 0xa4;
            this.rtbBiographyRomance.Text = "";
            this.rtbBiographyRomance.TextChanged += new EventHandler(this.rtbBiographyRomance_TextChanged);
            this.label46.AutoSize = true;
            this.label46.Location = new Point(0x110, 0x146);
            this.label46.Name = "label46";
            this.label46.Size = new Size(0x1d, 12);
            this.label46.TabIndex = 0xa3;
            this.label46.Text = "简介";
            this.cbOnlySelectFromTheNew.AutoSize = true;
            this.cbOnlySelectFromTheNew.Checked = true;
            this.cbOnlySelectFromTheNew.CheckState = CheckState.Checked;
            this.cbOnlySelectFromTheNew.Location = new Point(0x2ad, 200);
            this.cbOnlySelectFromTheNew.Name = "cbOnlySelectFromTheNew";
            this.cbOnlySelectFromTheNew.Size = new Size(0x90, 0x10);
            this.cbOnlySelectFromTheNew.TabIndex = 0xa2;
            this.cbOnlySelectFromTheNew.Text = "只从新武将头像中选择";
            this.cbOnlySelectFromTheNew.UseVisualStyleBackColor = true;
            this.btnChangePortrait.Location = new Point(0x2f0, 0xab);
            this.btnChangePortrait.Name = "btnChangePortrait";
            this.btnChangePortrait.Size = new Size(0x4b, 0x17);
            this.btnChangePortrait.TabIndex = 0xa1;
            this.btnChangePortrait.Text = "更换头像";
            this.btnChangePortrait.UseVisualStyleBackColor = true;
            this.btnChangePortrait.Click += new EventHandler(this.btnChangePortrait_Click);
            this.pbHead.ErrorImage = null;
            this.pbHead.InitialImage = null;
            this.pbHead.Location = new Point(690, 3);
            this.pbHead.Name = "pbHead";
            this.pbHead.Size = new Size(0x89, 0xa2);
            this.pbHead.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbHead.TabIndex = 160;
            this.pbHead.TabStop = false;
            this.label55.AutoSize = true;
            this.label55.Location = new Point(0x1fd, 13);
            this.label55.Name = "label55";
            this.label55.Size = new Size(0x35, 12);
            this.label55.TabIndex = 0x9e;
            this.label55.Text = "仕官倾向";
            this.cbIdealTendency.FormattingEnabled = true;
            this.cbIdealTendency.Location = new Point(0x239, 10);
            this.cbIdealTendency.Name = "cbIdealTendency";
            this.cbIdealTendency.Size = new Size(0x65, 20);
            this.cbIdealTendency.TabIndex = 0x9f;
            this.label54.AutoSize = true;
            this.label54.Location = new Point(0x10d, 0x127);
            this.label54.Name = "label54";
            this.label54.Size = new Size(0x29, 12);
            this.label54.TabIndex = 0x9d;
            this.label54.Text = "列传：";
            this.rtbBiographyBrief.BackColor = SystemColors.Window;
            this.rtbBiographyBrief.Location = new Point(0x13f, 310);
            this.rtbBiographyBrief.Name = "rtbBiographyBrief";
            this.rtbBiographyBrief.Size = new Size(0x1e8, 0x3d);
            this.rtbBiographyBrief.TabIndex = 0x9c;
            this.rtbBiographyBrief.Text = "";
            this.rtbBiographyBrief.TextChanged += new EventHandler(this.rtbBiographyBrief_TextChanged);
            this.tbAvailableLocation.Location = new Point(0x169, 0x106);
            this.tbAvailableLocation.MaxLength = 4;
            this.tbAvailableLocation.Name = "tbAvailableLocation";
            this.tbAvailableLocation.Size = new Size(0x3b, 0x15);
            this.tbAvailableLocation.TabIndex = 0x9b;
            this.tbAvailableLocation.TextAlign = HorizontalAlignment.Right;
            this.label45.AutoSize = true;
            this.label45.Location = new Point(0x12e, 0x109);
            this.label45.Name = "label45";
            this.label45.Size = new Size(0x35, 12);
            this.label45.TabIndex = 0x9a;
            this.label45.Text = "登场地点";
            this.ssInfo.Items.AddRange(new ToolStripItem[] { this.tsslIDtoName });
            this.ssInfo.Location = new Point(3, 0x22a);
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.Size = new Size(0x33b, 0x16);
            this.ssInfo.TabIndex = 0x99;
            this.ssInfo.Text = "信息";
            this.tsslIDtoName.Name = "tsslIDtoName";
            this.tsslIDtoName.Size = new Size(0, 0x11);
            this.tsslIDtoName.TextAlign = ContentAlignment.MiddleLeft;
            this.btnApply.Location = new Point(0x2dc, 0x202);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new Size(0x4b, 0x17);
            this.btnApply.TabIndex = 0x98;
            this.btnApply.Text = "应用修改";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new EventHandler(this.btnApply_Click);
            this.gbHatedPersons.Controls.Add(this.btnRemoveHatedPersons);
            this.gbHatedPersons.Controls.Add(this.btnAddHatedPersons);
            this.gbHatedPersons.Controls.Add(this.lbHatedPersons);
            this.gbHatedPersons.Location = new Point(0x85, 0x12d);
            this.gbHatedPersons.Name = "gbHatedPersons";
            this.gbHatedPersons.Size = new Size(0x70, 0xe1);
            this.gbHatedPersons.TabIndex = 0x97;
            this.gbHatedPersons.TabStop = false;
            this.gbHatedPersons.Text = "厌恶人物列表";
            this.btnRemoveHatedPersons.Location = new Point(0x3f, 20);
            this.btnRemoveHatedPersons.Name = "btnRemoveHatedPersons";
            this.btnRemoveHatedPersons.Size = new Size(0x29, 0x17);
            this.btnRemoveHatedPersons.TabIndex = 0x4a;
            this.btnRemoveHatedPersons.Text = "删除";
            this.btnRemoveHatedPersons.UseVisualStyleBackColor = true;
            this.btnRemoveHatedPersons.Click += new EventHandler(this.btnRemoveHatedPersons_Click);
            this.btnAddHatedPersons.Location = new Point(7, 20);
            this.btnAddHatedPersons.Name = "btnAddHatedPersons";
            this.btnAddHatedPersons.Size = new Size(0x29, 0x17);
            this.btnAddHatedPersons.TabIndex = 0x49;
            this.btnAddHatedPersons.Text = "添加";
            this.btnAddHatedPersons.UseVisualStyleBackColor = true;
            this.btnAddHatedPersons.Click += new EventHandler(this.btnAddHatedPersons_Click);
            this.lbHatedPersons.FormattingEnabled = true;
            this.lbHatedPersons.ItemHeight = 12;
            this.lbHatedPersons.Location = new Point(8, 0x31);
            this.lbHatedPersons.Name = "lbHatedPersons";
            this.lbHatedPersons.Size = new Size(0x61, 160);
            this.lbHatedPersons.TabIndex = 0x48;
            this.gbClosePersons.Controls.Add(this.btnRemoveClosePerson);
            this.gbClosePersons.Controls.Add(this.btnAddClosePerson);
            this.gbClosePersons.Controls.Add(this.lbClosePersons);
            this.gbClosePersons.Location = new Point(13, 0x12d);
            this.gbClosePersons.Name = "gbClosePersons";
            this.gbClosePersons.Size = new Size(0x70, 0xe1);
            this.gbClosePersons.TabIndex = 150;
            this.gbClosePersons.TabStop = false;
            this.gbClosePersons.Text = "亲近人物列表";
            this.btnRemoveClosePerson.Location = new Point(0x3f, 20);
            this.btnRemoveClosePerson.Name = "btnRemoveClosePerson";
            this.btnRemoveClosePerson.Size = new Size(0x29, 0x17);
            this.btnRemoveClosePerson.TabIndex = 0x4a;
            this.btnRemoveClosePerson.Text = "删除";
            this.btnRemoveClosePerson.UseVisualStyleBackColor = true;
            this.btnRemoveClosePerson.Click += new EventHandler(this.btnRemoveClosePerson_Click);
            this.btnAddClosePerson.Location = new Point(7, 20);
            this.btnAddClosePerson.Name = "btnAddClosePerson";
            this.btnAddClosePerson.Size = new Size(0x29, 0x17);
            this.btnAddClosePerson.TabIndex = 0x49;
            this.btnAddClosePerson.Text = "添加";
            this.btnAddClosePerson.UseVisualStyleBackColor = true;
            this.btnAddClosePerson.Click += new EventHandler(this.btnAddClosePerson_Click);
            this.lbClosePersons.FormattingEnabled = true;
            this.lbClosePersons.ItemHeight = 12;
            this.lbClosePersons.Location = new Point(7, 0x31);
            this.lbClosePersons.Name = "lbClosePersons";
            this.lbClosePersons.Size = new Size(0x61, 160);
            this.lbClosePersons.TabIndex = 0x48;
            this.cbCharacter.FormattingEnabled = true;
            this.cbCharacter.Items.AddRange(new object[] { "未定义", "鲁莽", "小心", "高傲", "坚韧", "稳健", "冷静" });
            this.cbCharacter.Location = new Point(0x1b1, 150);
            this.cbCharacter.Name = "cbCharacter";
            this.cbCharacter.Size = new Size(0x52, 20);
            this.cbCharacter.TabIndex = 0x7a;
            this.cbCharacter.Text = "未定义";
            this.label38.AutoSize = true;
            this.label38.Location = new Point(0x211, 0x99);
            this.label38.Name = "label38";
            this.label38.Size = new Size(0x35, 12);
            this.label38.TabIndex = 0x4f;
            this.label38.Text = "势力颜色";
            this.cbFactionColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbFactionColor.FormattingEnabled = true;
            this.cbFactionColor.Location = new Point(0x24c, 150);
            this.cbFactionColor.Name = "cbFactionColor";
            this.cbFactionColor.Size = new Size(0x52, 0x16);
            this.cbFactionColor.TabIndex = 0x7b;
            this.cbFactionColor.DrawItem += new DrawItemEventHandler(this.cbFactionColor_DrawItem);
            this.cbFactionColor.SelectedIndexChanged += new EventHandler(this.cbFactionColor_SelectedIndexChanged);
            this.tbProhibitedFactionID.Location = new Point(0xde, 0x106);
            this.tbProhibitedFactionID.MaxLength = 4;
            this.tbProhibitedFactionID.Name = "tbProhibitedFactionID";
            this.tbProhibitedFactionID.Size = new Size(0x3b, 0x15);
            this.tbProhibitedFactionID.TabIndex = 0x95;
            this.tbProhibitedFactionID.TextAlign = HorizontalAlignment.Right;
            this.tbProhibitedFactionID.MouseHover += new EventHandler(this.tbProhibitedFactionID_MouseHover);
            this.label36.AutoSize = true;
            this.label36.Location = new Point(0x8b, 0x109);
            this.label36.Name = "label36";
            this.label36.Size = new Size(0x4d, 12);
            this.label36.TabIndex = 0x92;
            this.label36.Text = "禁止出仕势力";
            this.tbOldFactionID.Location = new Point(0x3a, 0x106);
            this.tbOldFactionID.MaxLength = 4;
            this.tbOldFactionID.Name = "tbOldFactionID";
            this.tbOldFactionID.Size = new Size(0x3b, 0x15);
            this.tbOldFactionID.TabIndex = 0x94;
            this.tbOldFactionID.TextAlign = HorizontalAlignment.Right;
            this.tbOldFactionID.MouseHover += new EventHandler(this.tbOldFactionID_MouseHover);
            this.label37.AutoSize = true;
            this.label37.Location = new Point(11, 0x109);
            this.label37.Name = "label37";
            this.label37.Size = new Size(0x29, 12);
            this.label37.TabIndex = 0x93;
            this.label37.Text = "旧势力";
            this.label35.AutoSize = true;
            this.label35.Location = new Point(0x1f0, 0xe4);
            this.label35.Name = "label35";
            this.label35.Size = new Size(0x35, 12);
            this.label35.TabIndex = 0x90;
            this.label35.Text = "战略倾向";
            this.cbStrategyTendency.FormattingEnabled = true;
            this.cbStrategyTendency.Items.AddRange(new object[] { "统一全国", "统一地区", "统一州", "维持现状" });
            this.cbStrategyTendency.Location = new Point(0x22f, 0xe1);
            this.cbStrategyTendency.Name = "cbStrategyTendency";
            this.cbStrategyTendency.Size = new Size(0x52, 20);
            this.cbStrategyTendency.TabIndex = 0x91;
            this.cbStrategyTendency.Text = "统一全国";
            this.label34.AutoSize = true;
            this.label34.Location = new Point(0x176, 0xe4);
            this.label34.Name = "label34";
            this.label34.Size = new Size(0x1d, 12);
            this.label34.TabIndex = 0x8e;
            this.label34.Text = "汉室";
            this.cbValuationOnGovernment.FormattingEnabled = true;
            this.cbValuationOnGovernment.Items.AddRange(new object[] { "无视", "普通", "重视" });
            this.cbValuationOnGovernment.Location = new Point(0x19e, 0xe1);
            this.cbValuationOnGovernment.Name = "cbValuationOnGovernment";
            this.cbValuationOnGovernment.Size = new Size(0x39, 20);
            this.cbValuationOnGovernment.TabIndex = 0x8f;
            this.cbValuationOnGovernment.Text = "普通";
            this.label33.AutoSize = true;
            this.label33.Location = new Point(0xf7, 0xe4);
            this.label33.Name = "label33";
            this.label33.Size = new Size(0x1d, 12);
            this.label33.TabIndex = 140;
            this.label33.Text = "起用";
            this.cbQualification.FormattingEnabled = true;
            this.cbQualification.Items.AddRange(new object[] { "任意", "能力", "功绩", "名声", "义理" });
            this.cbQualification.Location = new Point(0x11f, 0xe1);
            this.cbQualification.Name = "cbQualification";
            this.cbQualification.Size = new Size(0x42, 20);
            this.cbQualification.TabIndex = 0x8d;
            this.cbQualification.Text = "任意";
            this.label32.AutoSize = true;
            this.label32.Location = new Point(0x7d, 0xe4);
            this.label32.Name = "label32";
            this.label32.Size = new Size(0x1d, 12);
            this.label32.TabIndex = 0x8a;
            this.label32.Text = "野心";
            this.cbAmbition.FormattingEnabled = true;
            this.cbAmbition.Items.AddRange(new object[] { "很低", "低", "普通", "高", "很高" });
            this.cbAmbition.Location = new Point(0xa5, 0xe1);
            this.cbAmbition.Name = "cbAmbition";
            this.cbAmbition.Size = new Size(0x3b, 20);
            this.cbAmbition.TabIndex = 0x8b;
            this.cbAmbition.Text = "普通";
            this.label31.AutoSize = true;
            this.label31.Location = new Point(9, 0xe4);
            this.label31.Name = "label31";
            this.label31.Size = new Size(0x1d, 12);
            this.label31.TabIndex = 0x88;
            this.label31.Text = "义理";
            this.cbPersonalLoyalty.FormattingEnabled = true;
            this.cbPersonalLoyalty.Items.AddRange(new object[] { "很低", "低", "普通", "高", "很高" });
            this.cbPersonalLoyalty.Location = new Point(0x31, 0xe1);
            this.cbPersonalLoyalty.Name = "cbPersonalLoyalty";
            this.cbPersonalLoyalty.Size = new Size(0x3b, 20);
            this.cbPersonalLoyalty.TabIndex = 0x89;
            this.cbPersonalLoyalty.Text = "普通";
            this.tbGeneration.Location = new Point(0x263, 0xbb);
            this.tbGeneration.MaxLength = 2;
            this.tbGeneration.Name = "tbGeneration";
            this.tbGeneration.Size = new Size(0x3b, 0x15);
            this.tbGeneration.TabIndex = 0x87;
            this.tbGeneration.TextAlign = HorizontalAlignment.Right;
            this.label30.AutoSize = true;
            this.label30.Location = new Point(0x23b, 190);
            this.label30.Name = "label30";
            this.label30.Size = new Size(0x1d, 12);
            this.label30.TabIndex = 0x86;
            this.label30.Text = "世代";
            this.tbBrother.Location = new Point(0x1f2, 0xbb);
            this.tbBrother.MaxLength = 4;
            this.tbBrother.Name = "tbBrother";
            this.tbBrother.Size = new Size(0x3b, 0x15);
            this.tbBrother.TabIndex = 0x85;
            this.tbBrother.TextAlign = HorizontalAlignment.Right;
            this.tbBrother.MouseHover += new EventHandler(this.tbBrother_MouseHover);
            this.label25.AutoSize = true;
            this.label25.Location = new Point(0x1ca, 190);
            this.label25.Name = "label25";
            this.label25.Size = new Size(0x1d, 12);
            this.label25.TabIndex = 0x84;
            this.label25.Text = "义兄";
            this.tbSpouse.Location = new Point(380, 0xbb);
            this.tbSpouse.MaxLength = 4;
            this.tbSpouse.Name = "tbSpouse";
            this.tbSpouse.Size = new Size(0x3b, 0x15);
            this.tbSpouse.TabIndex = 0x83;
            this.tbSpouse.TextAlign = HorizontalAlignment.Right;
            this.tbSpouse.MouseHover += new EventHandler(this.tbSpouse_MouseHover);
            this.label26.AutoSize = true;
            this.label26.Location = new Point(340, 190);
            this.label26.Name = "label26";
            this.label26.Size = new Size(0x1d, 12);
            this.label26.TabIndex = 130;
            this.label26.Text = "配偶";
            this.tbMother.Location = new Point(0x108, 0xbb);
            this.tbMother.MaxLength = 4;
            this.tbMother.Name = "tbMother";
            this.tbMother.Size = new Size(0x3b, 0x15);
            this.tbMother.TabIndex = 0x81;
            this.tbMother.TextAlign = HorizontalAlignment.Right;
            this.tbMother.MouseHover += new EventHandler(this.tbMother_MouseHover);
            this.label27.AutoSize = true;
            this.label27.Location = new Point(0xe0, 190);
            this.label27.Name = "label27";
            this.label27.Size = new Size(0x1d, 12);
            this.label27.TabIndex = 0x80;
            this.label27.Text = "母亲";
            this.tbFather.Location = new Point(0x9c, 0xbb);
            this.tbFather.MaxLength = 4;
            this.tbFather.Name = "tbFather";
            this.tbFather.Size = new Size(0x3b, 0x15);
            this.tbFather.TabIndex = 0x7f;
            this.tbFather.TextAlign = HorizontalAlignment.Right;
            this.tbFather.MouseHover += new EventHandler(this.tbFather_MouseHover);
            this.label28.AutoSize = true;
            this.label28.Location = new Point(0x74, 190);
            this.label28.Name = "label28";
            this.label28.Size = new Size(0x1d, 12);
            this.label28.TabIndex = 0x7e;
            this.label28.Text = "父亲";
            this.tbStrain.Location = new Point(0x31, 0xbb);
            this.tbStrain.MaxLength = 4;
            this.tbStrain.Name = "tbStrain";
            this.tbStrain.Size = new Size(0x3b, 0x15);
            this.tbStrain.TabIndex = 0x7d;
            this.tbStrain.TextAlign = HorizontalAlignment.Right;
            this.tbStrain.MouseHover += new EventHandler(this.tbStrain_MouseHover);
            this.label29.AutoSize = true;
            this.label29.Location = new Point(9, 190);
            this.label29.Name = "label29";
            this.label29.Size = new Size(0x1d, 12);
            this.label29.TabIndex = 0x7c;
            this.label29.Text = "血缘";
            this.label24.AutoSize = true;
            this.label24.Location = new Point(11, 50);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x29, 12);
            this.label24.TabIndex = 0x79;
            this.label24.Text = "出生地";
            this.cbBornRegion.FormattingEnabled = true;
            this.cbBornRegion.Items.AddRange(new object[] { "幽州", "冀州", "青徐", "兖豫", "司隶", "京兆", "凉州", "扬州", "荆北", "荆南", "益州", "南中", "交州", "夷州" });
            this.cbBornRegion.Location = new Point(0x3a, 0x2f);
            this.cbBornRegion.Name = "cbBornRegion";
            this.cbBornRegion.Size = new Size(0x52, 20);
            this.cbBornRegion.TabIndex = 0x56;
            this.cbBornRegion.Text = "幽州";
            this.tbLoyalty.Location = new Point(0x13f, 150);
            this.tbLoyalty.MaxLength = 4;
            this.tbLoyalty.Name = "tbLoyalty";
            this.tbLoyalty.Size = new Size(0x3b, 0x15);
            this.tbLoyalty.TabIndex = 120;
            this.tbLoyalty.TextAlign = HorizontalAlignment.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new Point(0x110, 0x99);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x29, 12);
            this.label23.TabIndex = 0x77;
            this.label23.Text = "忠诚度";
            this.tbCalmness.Location = new Point(0xba, 150);
            this.tbCalmness.MaxLength = 2;
            this.tbCalmness.Name = "tbCalmness";
            this.tbCalmness.Size = new Size(0x3b, 0x15);
            this.tbCalmness.TabIndex = 0x76;
            this.tbCalmness.TextAlign = HorizontalAlignment.Right;
            this.label22.AutoSize = true;
            this.label22.Location = new Point(0x8b, 0x99);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x29, 12);
            this.label22.TabIndex = 0x75;
            this.label22.Text = "冷静度";
            this.tbBraveness.Location = new Point(0x3a, 150);
            this.tbBraveness.MaxLength = 2;
            this.tbBraveness.Name = "tbBraveness";
            this.tbBraveness.Size = new Size(0x3b, 0x15);
            this.tbBraveness.TabIndex = 0x74;
            this.tbBraveness.TextAlign = HorizontalAlignment.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new Point(11, 0x99);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x29, 12);
            this.label21.TabIndex = 0x73;
            this.label21.Text = "勇猛度";
            this.tbGlamourExperience.Location = new Point(0x1fb, 0x71);
            this.tbGlamourExperience.MaxLength = 4;
            this.tbGlamourExperience.Name = "tbGlamourExperience";
            this.tbGlamourExperience.Size = new Size(0x3b, 0x15);
            this.tbGlamourExperience.TabIndex = 0x72;
            this.tbGlamourExperience.TextAlign = HorizontalAlignment.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new Point(0x1d3, 0x74);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x1d, 12);
            this.label16.TabIndex = 0x71;
            this.label16.Text = "魅经";
            this.tbPoliticsExperience.Location = new Point(0x185, 0x71);
            this.tbPoliticsExperience.MaxLength = 4;
            this.tbPoliticsExperience.Name = "tbPoliticsExperience";
            this.tbPoliticsExperience.Size = new Size(0x3b, 0x15);
            this.tbPoliticsExperience.TabIndex = 0x70;
            this.tbPoliticsExperience.TextAlign = HorizontalAlignment.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new Point(0x15d, 0x74);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1d, 12);
            this.label17.TabIndex = 0x6f;
            this.label17.Text = "政经";
            this.tbIntelligenceExperience.Location = new Point(0x111, 0x71);
            this.tbIntelligenceExperience.MaxLength = 4;
            this.tbIntelligenceExperience.Name = "tbIntelligenceExperience";
            this.tbIntelligenceExperience.Size = new Size(0x3b, 0x15);
            this.tbIntelligenceExperience.TabIndex = 110;
            this.tbIntelligenceExperience.TextAlign = HorizontalAlignment.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new Point(0xe9, 0x74);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x1d, 12);
            this.label18.TabIndex = 0x6d;
            this.label18.Text = "智经";
            this.tbCommandExperience.Location = new Point(0xa5, 0x71);
            this.tbCommandExperience.MaxLength = 4;
            this.tbCommandExperience.Name = "tbCommandExperience";
            this.tbCommandExperience.Size = new Size(0x3b, 0x15);
            this.tbCommandExperience.TabIndex = 0x6c;
            this.tbCommandExperience.TextAlign = HorizontalAlignment.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new Point(0x7d, 0x74);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x1d, 12);
            this.label19.TabIndex = 0x6b;
            this.label19.Text = "统经";
            this.tbStrengthExperience.Location = new Point(0x3a, 0x71);
            this.tbStrengthExperience.MaxLength = 4;
            this.tbStrengthExperience.Name = "tbStrengthExperience";
            this.tbStrengthExperience.Size = new Size(0x3b, 0x15);
            this.tbStrengthExperience.TabIndex = 0x6a;
            this.tbStrengthExperience.TextAlign = HorizontalAlignment.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new Point(0x12, 0x74);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x1d, 12);
            this.label20.TabIndex = 0x69;
            this.label20.Text = "武经";
            this.tbGlamour.Location = new Point(0x1fb, 0x56);
            this.tbGlamour.MaxLength = 4;
            this.tbGlamour.Name = "tbGlamour";
            this.tbGlamour.Size = new Size(0x3b, 0x15);
            this.tbGlamour.TabIndex = 0x68;
            this.tbGlamour.TextAlign = HorizontalAlignment.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new Point(0x1d3, 0x59);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1d, 12);
            this.label15.TabIndex = 0x67;
            this.label15.Text = "魅力";
            this.tbPolitics.Location = new Point(0x185, 0x56);
            this.tbPolitics.MaxLength = 4;
            this.tbPolitics.Name = "tbPolitics";
            this.tbPolitics.Size = new Size(0x3b, 0x15);
            this.tbPolitics.TabIndex = 0x66;
            this.tbPolitics.TextAlign = HorizontalAlignment.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new Point(0x15d, 0x59);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1d, 12);
            this.label14.TabIndex = 0x65;
            this.label14.Text = "政治";
            this.tbIntelligence.Location = new Point(0x111, 0x56);
            this.tbIntelligence.MaxLength = 4;
            this.tbIntelligence.Name = "tbIntelligence";
            this.tbIntelligence.Size = new Size(0x3b, 0x15);
            this.tbIntelligence.TabIndex = 100;
            this.tbIntelligence.TextAlign = HorizontalAlignment.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0xe9, 0x59);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x1d, 12);
            this.label13.TabIndex = 0x63;
            this.label13.Text = "智谋";
            this.tbCommand.Location = new Point(0xa5, 0x56);
            this.tbCommand.MaxLength = 4;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new Size(0x3b, 0x15);
            this.tbCommand.TabIndex = 0x62;
            this.tbCommand.TextAlign = HorizontalAlignment.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0x7d, 0x59);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x1d, 12);
            this.label12.TabIndex = 0x61;
            this.label12.Text = "统率";
            this.tbStrength.Location = new Point(0x3a, 0x56);
            this.tbStrength.MaxLength = 4;
            this.tbStrength.Name = "tbStrength";
            this.tbStrength.Size = new Size(0x3b, 0x15);
            this.tbStrength.TabIndex = 0x60;
            this.tbStrength.TextAlign = HorizontalAlignment.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new Point(0x12, 0x59);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x1d, 12);
            this.label11.TabIndex = 0x5f;
            this.label11.Text = "武勇";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x224, 0x33);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x1d, 12);
            this.label10.TabIndex = 0x5d;
            this.label10.Text = "死因";
            this.cbDeadReason.FormattingEnabled = true;
            this.cbDeadReason.Items.AddRange(new object[] { "自然死亡", "被杀死", "郁郁而终", "操劳过度" });
            this.cbDeadReason.Location = new Point(0x24c, 0x30);
            this.cbDeadReason.Name = "cbDeadReason";
            this.cbDeadReason.Size = new Size(0x52, 20);
            this.cbDeadReason.TabIndex = 0x5e;
            this.cbDeadReason.Text = "自然死亡";
            this.tbDeadYear.Location = new Point(0x1d5, 0x2f);
            this.tbDeadYear.MaxLength = 4;
            this.tbDeadYear.Name = "tbDeadYear";
            this.tbDeadYear.Size = new Size(0x3b, 0x15);
            this.tbDeadYear.TabIndex = 0x5c;
            this.tbDeadYear.TextAlign = HorizontalAlignment.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x1a6, 50);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x29, 12);
            this.label7.TabIndex = 0x58;
            this.label7.Text = "死亡年";
            this.tbBornYear.Location = new Point(0x152, 0x2f);
            this.tbBornYear.MaxLength = 4;
            this.tbBornYear.Name = "tbBornYear";
            this.tbBornYear.Size = new Size(0x3b, 0x15);
            this.tbBornYear.TabIndex = 0x5b;
            this.tbBornYear.TextAlign = HorizontalAlignment.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x123, 50);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x29, 12);
            this.label8.TabIndex = 0x57;
            this.label8.Text = "出生年";
            this.tbAvailableYear.Location = new Point(210, 0x2f);
            this.tbAvailableYear.MaxLength = 4;
            this.tbAvailableYear.Name = "tbAvailableYear";
            this.tbAvailableYear.Size = new Size(0x3b, 0x15);
            this.tbAvailableYear.TabIndex = 90;
            this.tbAvailableYear.TextAlign = HorizontalAlignment.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0xa3, 50);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x29, 12);
            this.label9.TabIndex = 0x59;
            this.label9.Text = "出场年";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x18e, 0x99);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1d, 12);
            this.label6.TabIndex = 0x4c;
            this.label6.Text = "性格";
            this.tbIdeal.Location = new Point(0x1b3, 9);
            this.tbIdeal.MaxLength = 4;
            this.tbIdeal.Name = "tbIdeal";
            this.tbIdeal.Size = new Size(0x3b, 0x15);
            this.tbIdeal.TabIndex = 0x55;
            this.tbIdeal.TextAlign = HorizontalAlignment.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(400, 12);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x1d, 12);
            this.label5.TabIndex = 0x4d;
            this.label5.Text = "相性";
            this.tbPic.Location = new Point(0x13f, 9);
            this.tbPic.MaxLength = 4;
            this.tbPic.Name = "tbPic";
            this.tbPic.Size = new Size(0x3b, 0x15);
            this.tbPic.TabIndex = 0x54;
            this.tbPic.TextAlign = HorizontalAlignment.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x106, 12);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 0x4a;
            this.label4.Text = "头像序号";
            this.tbCalledName.Location = new Point(0xc6, 9);
            this.tbCalledName.MaxLength = 6;
            this.tbCalledName.Name = "tbCalledName";
            this.tbCalledName.Size = new Size(40, 0x15);
            this.tbCalledName.TabIndex = 0x53;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xaf, 12);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x11, 12);
            this.label3.TabIndex = 0x4b;
            this.label3.Text = "字";
            this.tbGivenName.Location = new Point(0x76, 9);
            this.tbGivenName.MaxLength = 6;
            this.tbGivenName.Name = "tbGivenName";
            this.tbGivenName.Size = new Size(40, 0x15);
            this.tbGivenName.TabIndex = 0x52;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x5f, 12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x11, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "名";
            this.tbSurName.Location = new Point(0x29, 9);
            this.tbSurName.MaxLength = 6;
            this.tbSurName.Name = "tbSurName";
            this.tbSurName.Size = new Size(40, 0x15);
            this.tbSurName.TabIndex = 0x51;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x11, 12);
            this.label1.TabIndex = 0x4e;
            this.label1.Text = "姓";
            this.tabPerson.Controls.Add(this.tpBasic);
            this.tabPerson.Controls.Add(this.tpSkill);
            this.tabPerson.Controls.Add(this.tpTextMessage);
            this.tabPerson.Dock = DockStyle.Fill;
            this.tabPerson.Location = new Point(0, 0);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.SelectedIndex = 0;
            this.tabPerson.Size = new Size(0x349, 0x25d);
            this.tabPerson.TabIndex = 0x4a;
            this.tpTextMessage.Controls.Add(this.label59);
            this.tpTextMessage.Controls.Add(this.rtbControversyPassiveWin);
            this.tpTextMessage.Controls.Add(this.label79);
            this.tpTextMessage.Controls.Add(this.rtbControversyInitiativeWin);
            this.tpTextMessage.Controls.Add(this.btnSaveTextMessage);
            this.tpTextMessage.Controls.Add(this.label58);
            this.tpTextMessage.Controls.Add(this.label78);
            this.tpTextMessage.Controls.Add(this.rtbOutburstQuiet);
            this.tpTextMessage.Controls.Add(this.label77);
            this.tpTextMessage.Controls.Add(this.rtbOutburstAngry);
            this.tpTextMessage.Controls.Add(this.label76);
            this.tpTextMessage.Controls.Add(this.rtbBreakWall);
            this.tpTextMessage.Controls.Add(this.label75);
            this.tpTextMessage.Controls.Add(this.rtbAntiAttack);
            this.tpTextMessage.Controls.Add(this.label74);
            this.tpTextMessage.Controls.Add(this.rtbResistHelpfulStratagem);
            this.tpTextMessage.Controls.Add(this.label73);
            this.tpTextMessage.Controls.Add(this.rtbResistHarmfulStratagem);
            this.tpTextMessage.Controls.Add(this.label72);
            this.tpTextMessage.Controls.Add(this.rtbHelpedByStratagem);
            this.tpTextMessage.Controls.Add(this.label71);
            this.tpTextMessage.Controls.Add(this.rtbTrappedByStratagem);
            this.tpTextMessage.Controls.Add(this.label70);
            this.tpTextMessage.Controls.Add(this.rtbRecoverFromChaos);
            this.tpTextMessage.Controls.Add(this.label69);
            this.tpTextMessage.Controls.Add(this.rtbCastDeepChaos);
            this.tpTextMessage.Controls.Add(this.label68);
            this.tpTextMessage.Controls.Add(this.rtbDeepChaos);
            this.tpTextMessage.Controls.Add(this.label67);
            this.tpTextMessage.Controls.Add(this.rtbChaos);
            this.tpTextMessage.Controls.Add(this.label66);
            this.tpTextMessage.Controls.Add(this.rtbDualPassiveWin);
            this.tpTextMessage.Controls.Add(this.label65);
            this.tpTextMessage.Controls.Add(this.rtbDualInitiativeWin);
            this.tpTextMessage.Controls.Add(this.label64);
            this.tpTextMessage.Controls.Add(this.rtbRout);
            this.tpTextMessage.Controls.Add(this.label63);
            this.tpTextMessage.Controls.Add(this.rtbSurround);
            this.tpTextMessage.Controls.Add(this.label62);
            this.tpTextMessage.Controls.Add(this.rtbReceiveCriticalStrike);
            this.tpTextMessage.Controls.Add(this.label61);
            this.tpTextMessage.Controls.Add(this.rtbCriticalStrikeOnArchitecture);
            this.tpTextMessage.Controls.Add(this.label60);
            this.tpTextMessage.Controls.Add(this.rtbCriticalStrike);
            this.tpTextMessage.Location = new Point(4, 0x16);
            this.tpTextMessage.Name = "tpTextMessage";
            this.tpTextMessage.Size = new Size(0x341, 0x243);
            this.tpTextMessage.TabIndex = 2;
            this.tpTextMessage.Text = "个性话语";
            this.tpTextMessage.UseVisualStyleBackColor = true;
            this.label59.AutoSize = true;
            this.label59.Location = new Point(8, 0xe1);
            this.label59.Name = "label59";
            this.label59.Size = new Size(0x35, 12);
            this.label59.TabIndex = 0x3f;
            this.label59.Text = "被动论战";
            this.rtbControversyPassiveWin.AcceptsTab = true;
            this.rtbControversyPassiveWin.Location = new Point(0x61, 0xde);
            this.rtbControversyPassiveWin.Name = "rtbControversyPassiveWin";
            this.rtbControversyPassiveWin.Size = new Size(0x227, 0x15);
            this.rtbControversyPassiveWin.TabIndex = 0x22;
            this.rtbControversyPassiveWin.Text = "";
            this.label79.AutoSize = true;
            this.label79.Location = new Point(8, 0xc6);
            this.label79.Name = "label79";
            this.label79.Size = new Size(0x35, 12);
            this.label79.TabIndex = 0x3d;
            this.label79.Text = "主动论战";
            this.rtbControversyInitiativeWin.AcceptsTab = true;
            this.rtbControversyInitiativeWin.Location = new Point(0x61, 0xc3);
            this.rtbControversyInitiativeWin.Name = "rtbControversyInitiativeWin";
            this.rtbControversyInitiativeWin.Size = new Size(0x227, 0x15);
            this.rtbControversyInitiativeWin.TabIndex = 0x21;
            this.rtbControversyInitiativeWin.Text = "";
            this.btnSaveTextMessage.Location = new Point(0x2d9, 0x220);
            this.btnSaveTextMessage.Name = "btnSaveTextMessage";
            this.btnSaveTextMessage.Size = new Size(0x4b, 0x17);
            this.btnSaveTextMessage.TabIndex = 0x3b;
            this.btnSaveTextMessage.Text = "保存修改";
            this.btnSaveTextMessage.UseVisualStyleBackColor = true;
            this.btnSaveTextMessage.Click += new EventHandler(this.btnSaveTextMessage_Click);
            this.label58.Location = new Point(0x298, 15);
            this.label58.Margin = new Padding(3);
            this.label58.Name = "label58";
            this.label58.Size = new Size(0x98, 0x27);
            this.label58.TabIndex = 0x3a;
            this.label58.Text = "每种对话可以设置为多句，只需要用空格符分割每句。";
            this.label78.AutoSize = true;
            this.label78.Location = new Point(8, 0x225);
            this.label78.Name = "label78";
            this.label78.Size = new Size(0x35, 12);
            this.label78.TabIndex = 0x39;
            this.label78.Text = "沉静状态";
            this.rtbOutburstQuiet.AcceptsTab = true;
            this.rtbOutburstQuiet.Location = new Point(0x61, 0x222);
            this.rtbOutburstQuiet.Name = "rtbOutburstQuiet";
            this.rtbOutburstQuiet.Size = new Size(0x227, 0x15);
            this.rtbOutburstQuiet.TabIndex = 0x38;
            this.rtbOutburstQuiet.Text = "";
            this.label77.AutoSize = true;
            this.label77.Location = new Point(8, 0x20a);
            this.label77.Name = "label77";
            this.label77.Size = new Size(0x35, 12);
            this.label77.TabIndex = 0x37;
            this.label77.Text = "愤怒状态";
            this.rtbOutburstAngry.AcceptsTab = true;
            this.rtbOutburstAngry.Location = new Point(0x61, 0x207);
            this.rtbOutburstAngry.Name = "rtbOutburstAngry";
            this.rtbOutburstAngry.Size = new Size(0x227, 0x15);
            this.rtbOutburstAngry.TabIndex = 0x36;
            this.rtbOutburstAngry.Text = "";
            this.label76.AutoSize = true;
            this.label76.Location = new Point(8, 0x1ef);
            this.label76.Name = "label76";
            this.label76.Size = new Size(0x35, 12);
            this.label76.TabIndex = 0x35;
            this.label76.Text = "攻破城墙";
            this.rtbBreakWall.AcceptsTab = true;
            this.rtbBreakWall.Location = new Point(0x61, 0x1ec);
            this.rtbBreakWall.Name = "rtbBreakWall";
            this.rtbBreakWall.Size = new Size(0x227, 0x15);
            this.rtbBreakWall.TabIndex = 0x34;
            this.rtbBreakWall.Text = "";
            this.label75.AutoSize = true;
            this.label75.Location = new Point(8, 0x1d4);
            this.label75.Name = "label75";
            this.label75.Size = new Size(0x35, 12);
            this.label75.TabIndex = 0x33;
            this.label75.Text = "抵抗攻击";
            this.rtbAntiAttack.AcceptsTab = true;
            this.rtbAntiAttack.Location = new Point(0x61, 0x1d1);
            this.rtbAntiAttack.Name = "rtbAntiAttack";
            this.rtbAntiAttack.Size = new Size(0x227, 0x15);
            this.rtbAntiAttack.TabIndex = 50;
            this.rtbAntiAttack.Text = "";
            this.label74.AutoSize = true;
            this.label74.Location = new Point(8, 0x1b9);
            this.label74.Name = "label74";
            this.label74.Size = new Size(0x4d, 12);
            this.label74.TabIndex = 0x31;
            this.label74.Text = "抵抗友好计略";
            this.rtbResistHelpfulStratagem.AcceptsTab = true;
            this.rtbResistHelpfulStratagem.Location = new Point(0x61, 0x1b6);
            this.rtbResistHelpfulStratagem.Name = "rtbResistHelpfulStratagem";
            this.rtbResistHelpfulStratagem.Size = new Size(0x227, 0x15);
            this.rtbResistHelpfulStratagem.TabIndex = 0x30;
            this.rtbResistHelpfulStratagem.Text = "";
            this.label73.AutoSize = true;
            this.label73.Location = new Point(8, 0x19e);
            this.label73.Name = "label73";
            this.label73.Size = new Size(0x4d, 12);
            this.label73.TabIndex = 0x2f;
            this.label73.Text = "抵抗敌军计略";
            this.rtbResistHarmfulStratagem.AcceptsTab = true;
            this.rtbResistHarmfulStratagem.Location = new Point(0x61, 0x19b);
            this.rtbResistHarmfulStratagem.Name = "rtbResistHarmfulStratagem";
            this.rtbResistHarmfulStratagem.Size = new Size(0x227, 0x15);
            this.rtbResistHarmfulStratagem.TabIndex = 0x2e;
            this.rtbResistHarmfulStratagem.Text = "";
            this.label72.AutoSize = true;
            this.label72.Location = new Point(8, 0x183);
            this.label72.Name = "label72";
            this.label72.Size = new Size(0x41, 12);
            this.label72.TabIndex = 0x2d;
            this.label72.Text = "被计略帮助";
            this.rtbHelpedByStratagem.AcceptsTab = true;
            this.rtbHelpedByStratagem.Location = new Point(0x61, 0x180);
            this.rtbHelpedByStratagem.Name = "rtbHelpedByStratagem";
            this.rtbHelpedByStratagem.Size = new Size(0x227, 0x15);
            this.rtbHelpedByStratagem.TabIndex = 0x2c;
            this.rtbHelpedByStratagem.Text = "";
            this.label71.AutoSize = true;
            this.label71.Location = new Point(8, 360);
            this.label71.Name = "label71";
            this.label71.Size = new Size(0x1d, 12);
            this.label71.TabIndex = 0x2b;
            this.label71.Text = "中计";
            this.rtbTrappedByStratagem.AcceptsTab = true;
            this.rtbTrappedByStratagem.Location = new Point(0x61, 0x165);
            this.rtbTrappedByStratagem.Name = "rtbTrappedByStratagem";
            this.rtbTrappedByStratagem.Size = new Size(0x227, 0x15);
            this.rtbTrappedByStratagem.TabIndex = 0x2a;
            this.rtbTrappedByStratagem.Text = "";
            this.label70.AutoSize = true;
            this.label70.Location = new Point(8, 0x14d);
            this.label70.Name = "label70";
            this.label70.Size = new Size(0x35, 12);
            this.label70.TabIndex = 0x29;
            this.label70.Text = "混乱恢复";
            this.rtbRecoverFromChaos.AcceptsTab = true;
            this.rtbRecoverFromChaos.Location = new Point(0x61, 330);
            this.rtbRecoverFromChaos.Name = "rtbRecoverFromChaos";
            this.rtbRecoverFromChaos.Size = new Size(0x227, 0x15);
            this.rtbRecoverFromChaos.TabIndex = 40;
            this.rtbRecoverFromChaos.Text = "";
            this.label69.AutoSize = true;
            this.label69.Location = new Point(8, 0x132);
            this.label69.Name = "label69";
            this.label69.Size = new Size(0x35, 12);
            this.label69.TabIndex = 0x27;
            this.label69.Text = "计略致乱";
            this.rtbCastDeepChaos.AcceptsTab = true;
            this.rtbCastDeepChaos.Location = new Point(0x61, 0x12f);
            this.rtbCastDeepChaos.Name = "rtbCastDeepChaos";
            this.rtbCastDeepChaos.Size = new Size(0x227, 0x15);
            this.rtbCastDeepChaos.TabIndex = 0x26;
            this.rtbCastDeepChaos.Text = "";
            this.label68.AutoSize = true;
            this.label68.Location = new Point(8, 0x117);
            this.label68.Name = "label68";
            this.label68.Size = new Size(0x35, 12);
            this.label68.TabIndex = 0x25;
            this.label68.Text = "深度混乱";
            this.rtbDeepChaos.AcceptsTab = true;
            this.rtbDeepChaos.Location = new Point(0x61, 0x114);
            this.rtbDeepChaos.Name = "rtbDeepChaos";
            this.rtbDeepChaos.Size = new Size(0x227, 0x15);
            this.rtbDeepChaos.TabIndex = 0x24;
            this.rtbDeepChaos.Text = "";
            this.label67.AutoSize = true;
            this.label67.Location = new Point(8, 0xfc);
            this.label67.Name = "label67";
            this.label67.Size = new Size(0x35, 12);
            this.label67.TabIndex = 0x23;
            this.label67.Text = "进入混乱";
            this.rtbChaos.AcceptsTab = true;
            this.rtbChaos.Location = new Point(0x61, 0xf9);
            this.rtbChaos.Name = "rtbChaos";
            this.rtbChaos.Size = new Size(0x227, 0x15);
            this.rtbChaos.TabIndex = 0x22;
            this.rtbChaos.Text = "";
            this.label66.AutoSize = true;
            this.label66.Location = new Point(8, 0xab);
            this.label66.Name = "label66";
            this.label66.Size = new Size(0x35, 12);
            this.label66.TabIndex = 0x21;
            this.label66.Text = "被动单挑";
            this.rtbDualPassiveWin.AcceptsTab = true;
            this.rtbDualPassiveWin.Location = new Point(0x61, 0xa8);
            this.rtbDualPassiveWin.Name = "rtbDualPassiveWin";
            this.rtbDualPassiveWin.Size = new Size(0x227, 0x15);
            this.rtbDualPassiveWin.TabIndex = 0x20;
            this.rtbDualPassiveWin.Text = "";
            this.label65.AutoSize = true;
            this.label65.Location = new Point(8, 0x90);
            this.label65.Name = "label65";
            this.label65.Size = new Size(0x35, 12);
            this.label65.TabIndex = 0x1f;
            this.label65.Text = "主动单挑";
            this.rtbDualInitiativeWin.AcceptsTab = true;
            this.rtbDualInitiativeWin.Location = new Point(0x61, 0x8d);
            this.rtbDualInitiativeWin.Name = "rtbDualInitiativeWin";
            this.rtbDualInitiativeWin.Size = new Size(0x227, 0x15);
            this.rtbDualInitiativeWin.TabIndex = 30;
            this.rtbDualInitiativeWin.Text = "";
            this.label64.AutoSize = true;
            this.label64.Location = new Point(8, 0x75);
            this.label64.Name = "label64";
            this.label64.Size = new Size(0x35, 12);
            this.label64.TabIndex = 0x1d;
            this.label64.Text = "击破部队";
            this.rtbRout.AcceptsTab = true;
            this.rtbRout.Location = new Point(0x61, 0x72);
            this.rtbRout.Name = "rtbRout";
            this.rtbRout.Size = new Size(0x227, 0x15);
            this.rtbRout.TabIndex = 0x1c;
            this.rtbRout.Text = "";
            this.label63.AutoSize = true;
            this.label63.Location = new Point(8, 90);
            this.label63.Name = "label63";
            this.label63.Size = new Size(0x35, 12);
            this.label63.TabIndex = 0x1b;
            this.label63.Text = "包围攻击";
            this.rtbSurround.AcceptsTab = true;
            this.rtbSurround.Location = new Point(0x61, 0x57);
            this.rtbSurround.Name = "rtbSurround";
            this.rtbSurround.Size = new Size(0x227, 0x15);
            this.rtbSurround.TabIndex = 0x1a;
            this.rtbSurround.Text = "";
            this.label62.AutoSize = true;
            this.label62.Location = new Point(8, 0x3f);
            this.label62.Name = "label62";
            this.label62.Size = new Size(0x29, 12);
            this.label62.TabIndex = 0x19;
            this.label62.Text = "被暴击";
            this.rtbReceiveCriticalStrike.AcceptsTab = true;
            this.rtbReceiveCriticalStrike.Location = new Point(0x61, 60);
            this.rtbReceiveCriticalStrike.Name = "rtbReceiveCriticalStrike";
            this.rtbReceiveCriticalStrike.Size = new Size(0x227, 0x15);
            this.rtbReceiveCriticalStrike.TabIndex = 0x18;
            this.rtbReceiveCriticalStrike.Text = "";
            this.label61.AutoSize = true;
            this.label61.Location = new Point(8, 0x24);
            this.label61.Name = "label61";
            this.label61.Size = new Size(0x35, 12);
            this.label61.TabIndex = 0x17;
            this.label61.Text = "暴击建筑";
            this.rtbCriticalStrikeOnArchitecture.AcceptsTab = true;
            this.rtbCriticalStrikeOnArchitecture.Location = new Point(0x61, 0x21);
            this.rtbCriticalStrikeOnArchitecture.Name = "rtbCriticalStrikeOnArchitecture";
            this.rtbCriticalStrikeOnArchitecture.Size = new Size(0x227, 0x15);
            this.rtbCriticalStrikeOnArchitecture.TabIndex = 0x16;
            this.rtbCriticalStrikeOnArchitecture.Text = "";
            this.label60.AutoSize = true;
            this.label60.Location = new Point(8, 9);
            this.label60.Name = "label60";
            this.label60.Size = new Size(0x35, 12);
            this.label60.TabIndex = 0x15;
            this.label60.Text = "暴击部队";
            this.rtbCriticalStrike.AcceptsTab = true;
            this.rtbCriticalStrike.Location = new Point(0x61, 6);
            this.rtbCriticalStrike.Name = "rtbCriticalStrike";
            this.rtbCriticalStrike.Size = new Size(0x227, 0x15);
            this.rtbCriticalStrike.TabIndex = 20;
            this.rtbCriticalStrike.Text = "";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x349, 0x25d);
            base.Controls.Add(this.tabPerson);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditPerson";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "编辑人物属性";
            base.Load += new EventHandler(this.frmEditPerson_Load);
            base.FormClosed += new FormClosedEventHandler(this.frmEditPerson_FormClosed);
            this.tpSkill.ResumeLayout(false);
            this.tpSkill.PerformLayout();
            this.gbStunt.ResumeLayout(false);
            this.gbSkills.ResumeLayout(false);
            this.gbSkills.PerformLayout();
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((ISupportInitialize) this.pbHead).EndInit();
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.gbHatedPersons.ResumeLayout(false);
            this.gbClosePersons.ResumeLayout(false);
            this.tabPerson.ResumeLayout(false);
            this.tpTextMessage.ResumeLayout(false);
            this.tpTextMessage.PerformLayout();
            base.ResumeLayout(false);
        }

        private void InitializeSkillData(Person p)
        {
            foreach (Skill skill in p.Skills.Skills.Values)
            {
                switch (skill.ID)
                {
                    case 0:
                        this.clb00.SetItemChecked(0, true);
                        break;

                    case 1:
                        this.clb00.SetItemChecked(1, true);
                        break;

                    case 2:
                        this.clb00.SetItemChecked(2, true);
                        break;

                    case 3:
                        this.clb00.SetItemChecked(3, true);
                        break;

                    case 4:
                        this.clb00.SetItemChecked(4, true);
                        break;

                    case 5:
                        this.clb00.SetItemChecked(5, true);
                        break;

                    case 6:
                        this.clb00.SetItemChecked(6, true);
                        break;

                    case 10:
                        this.clb01.SetItemChecked(0, true);
                        break;

                    case 11:
                        this.clb01.SetItemChecked(1, true);
                        break;

                    case 12:
                        this.clb01.SetItemChecked(2, true);
                        break;

                    case 13:
                        this.clb01.SetItemChecked(3, true);
                        break;

                    case 14:
                        this.clb01.SetItemChecked(4, true);
                        break;

                    case 15:
                        this.clb01.SetItemChecked(5, true);
                        break;

                    case 0x10:
                        this.clb01.SetItemChecked(6, true);
                        break;

                    case 20:
                        this.clb02.SetItemChecked(0, true);
                        break;

                    case 0x15:
                        this.clb02.SetItemChecked(1, true);
                        break;

                    case 0x16:
                        this.clb02.SetItemChecked(2, true);
                        break;

                    case 0x17:
                        this.clb02.SetItemChecked(3, true);
                        break;

                    case 0x18:
                        this.clb02.SetItemChecked(4, true);
                        break;

                    case 0x19:
                        this.clb02.SetItemChecked(5, true);
                        break;

                    case 0x1a:
                        this.clb02.SetItemChecked(6, true);
                        break;

                    case 30:
                        this.clb03.SetItemChecked(0, true);
                        break;

                    case 0x1f:
                        this.clb03.SetItemChecked(1, true);
                        break;

                    case 0x20:
                        this.clb03.SetItemChecked(2, true);
                        break;

                    case 0x21:
                        this.clb03.SetItemChecked(3, true);
                        break;

                    case 0x22:
                        this.clb03.SetItemChecked(4, true);
                        break;

                    case 0x23:
                        this.clb03.SetItemChecked(5, true);
                        break;

                    case 0x24:
                        this.clb03.SetItemChecked(6, true);
                        break;

                    case 40:
                        this.clb04.SetItemChecked(0, true);
                        break;

                    case 0x29:
                        this.clb04.SetItemChecked(1, true);
                        break;

                    case 0x2a:
                        this.clb04.SetItemChecked(2, true);
                        break;

                    case 0x2b:
                        this.clb04.SetItemChecked(3, true);
                        break;

                    case 0x2c:
                        this.clb04.SetItemChecked(4, true);
                        break;

                    case 0x2d:
                        this.clb04.SetItemChecked(5, true);
                        break;

                    case 0x2e:
                        this.clb04.SetItemChecked(6, true);
                        break;

                    case 50:
                        this.clb05.SetItemChecked(0, true);
                        break;

                    case 0x33:
                        this.clb05.SetItemChecked(1, true);
                        break;

                    case 0x34:
                        this.clb05.SetItemChecked(2, true);
                        break;

                    case 0x35:
                        this.clb05.SetItemChecked(3, true);
                        break;

                    case 0x36:
                        this.clb05.SetItemChecked(4, true);
                        break;

                    case 0x37:
                        this.clb05.SetItemChecked(5, true);
                        break;

                    case 0x38:
                        this.clb05.SetItemChecked(6, true);
                        break;

                    case 60:
                        this.clb06.SetItemChecked(0, true);
                        break;

                    case 0x3d:
                        this.clb06.SetItemChecked(1, true);
                        break;

                    case 0x3e:
                        this.clb06.SetItemChecked(2, true);
                        break;

                    case 0x3f:
                        this.clb06.SetItemChecked(3, true);
                        break;

                    case 0x40:
                        this.clb06.SetItemChecked(4, true);
                        break;

                    case 0x41:
                        this.clb06.SetItemChecked(5, true);
                        break;

                    case 0x42:
                        this.clb06.SetItemChecked(6, true);
                        break;

                    case 70:
                        this.clb07.SetItemChecked(0, true);
                        break;

                    case 0x47:
                        this.clb07.SetItemChecked(1, true);
                        break;

                    case 0x48:
                        this.clb07.SetItemChecked(2, true);
                        break;

                    case 0x49:
                        this.clb07.SetItemChecked(3, true);
                        break;

                    case 0x4a:
                        this.clb07.SetItemChecked(4, true);
                        break;

                    case 0x4b:
                        this.clb07.SetItemChecked(5, true);
                        break;

                    case 0x4c:
                        this.clb07.SetItemChecked(6, true);
                        break;

                    case 80:
                        this.clb08.SetItemChecked(0, true);
                        break;

                    case 0x51:
                        this.clb08.SetItemChecked(1, true);
                        break;

                    case 0x52:
                        this.clb08.SetItemChecked(2, true);
                        break;

                    case 0x53:
                        this.clb08.SetItemChecked(3, true);
                        break;

                    case 0x54:
                        this.clb08.SetItemChecked(4, true);
                        break;

                    case 0x55:
                        this.clb08.SetItemChecked(5, true);
                        break;

                    case 0x56:
                        this.clb08.SetItemChecked(6, true);
                        break;

                    case 90:
                        this.clb09.SetItemChecked(0, true);
                        break;

                    case 0x5b:
                        this.clb09.SetItemChecked(1, true);
                        break;

                    case 0x5c:
                        this.clb09.SetItemChecked(2, true);
                        break;

                    case 0x5d:
                        this.clb09.SetItemChecked(3, true);
                        break;

                    case 0x5e:
                        this.clb09.SetItemChecked(4, true);
                        break;

                    case 0x5f:
                        this.clb09.SetItemChecked(5, true);
                        break;

                    case 0x60:
                        this.clb09.SetItemChecked(6, true);
                        break;

                    case 100:
                        this.clb10.SetItemChecked(0, true);
                        break;

                    case 0x65:
                        this.clb10.SetItemChecked(1, true);
                        break;

                    case 0x66:
                        this.clb10.SetItemChecked(2, true);
                        break;

                    case 0x67:
                        this.clb10.SetItemChecked(3, true);
                        break;

                    case 0x68:
                        this.clb10.SetItemChecked(4, true);
                        break;

                    case 0x69:
                        this.clb10.SetItemChecked(5, true);
                        break;

                    case 0x6a:
                        this.clb10.SetItemChecked(6, true);
                        break;

                    case 110:
                        this.clb11.SetItemChecked(0, true);
                        break;
                }
            }
        }

        private void InitializeStuntData(Person p)
        {
            foreach (Stunt stunt in p.Stunts.Stunts.Values)
            {
                this.lbStunt.Items.Add(stunt);
            }
            foreach (Stunt stunt in p.Scenario.GameCommonData.AllStunts.Stunts.Values)
            {
                this.cbAllStunt.Items.Add(stunt);
            }
        }

        private void InitializeTabData()
        {
            if (this.person != null)
            {
                    Biography biography = this.MainForm.Scenario.GameCommonData.AllBiographies.GetBiography(this.person.ID);
                    if (biography == null)
                    {
                        biography = new Biography();
                        biography.ID = this.person.ID;
                        biography.Scenario = this.person.Scenario;
                        biography.FactionColor = 0;
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0));
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(1));
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(2));
                        this.person.Scenario.GameCommonData.AllBiographies.AddBiography(biography);
                    }
                    this.person.PersonBiography = biography;
                    TextMessage textMessage = this.MainForm.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID);
                    if (textMessage == null)
                    {
                        textMessage = new TextMessage();
                        textMessage.ID = this.person.ID;
                        textMessage.Scenario = this.person.Scenario;
                        this.person.Scenario.GameCommonData.AllTextMessages.AddTextMessage(textMessage);
                    }
                    this.person.PersonTextMessage = textMessage;
                    this.tbSurName.Text = this.person.SurName;
                    this.tbGivenName.Text = this.person.GivenName;
                    this.tbCalledName.Text = this.person.CalledName;
                    this.tbPic.Text = this.person.PictureIndex.ToString();
                    this.pbHead.Image = this.MainForm.GetPersonPortrait(this.person.PictureIndex);
                    this.tbIdeal.Text = this.person.Ideal.ToString();
                    this.cbIdealTendency.Items.Clear();
                    foreach (IdealTendencyKind kind in this.person.Scenario.GameCommonData.AllIdealTendencyKinds)
                    {
                        this.cbIdealTendency.Items.Add(kind);
                    }
                    try
                    {
                        this.cbIdealTendency.SelectedIndex = this.person.IdealTendency.ID;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbBornRegion.SelectedIndex = (int)this.person.BornRegion;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbAvailableLocation.Text = this.person.AvailableLocation.ToString();
                    this.tbAvailableYear.Text = this.person.YearAvailable.ToString();
                    this.tbBornYear.Text = this.person.YearBorn.ToString();
                    this.tbDeadYear.Text = this.person.YearDead.ToString();
                    try
                    {
                        this.cbDeadReason.SelectedIndex = (int)this.person.DeadReason;
                    } 
                    catch (ArgumentOutOfRangeException) { }
                    this.tbStrength.Text = this.person.BaseStrength.ToString();
                    this.tbCommand.Text = this.person.BaseCommand.ToString();
                    this.tbIntelligence.Text = this.person.BaseIntelligence.ToString();
                    this.tbPolitics.Text = this.person.BasePolitics.ToString();
                    this.tbGlamour.Text = this.person.BaseGlamour.ToString();
                    this.tbStrengthExperience.Text = this.person.StrengthExperience.ToString();
                    this.tbCommandExperience.Text = this.person.CommandExperience.ToString();
                    this.tbIntelligenceExperience.Text = this.person.IntelligenceExperience.ToString();
                    this.tbPoliticsExperience.Text = this.person.PoliticsExperience.ToString();
                    this.tbGlamourExperience.Text = this.person.GlamourExperience.ToString();
                    this.tbBraveness.Text = this.person.Braveness.ToString();
                    this.tbCalmness.Text = this.person.Calmness.ToString();
                    this.tbLoyalty.Text = this.person.Loyalty.ToString();
                    try 
                    {
                        this.cbCharacter.SelectedIndex = this.person.Character.ID;
                    } 
                    catch (ArgumentOutOfRangeException) { }
                    foreach (Microsoft.Xna.Framework.Graphics.Color color in this.person.Scenario.GameCommonData.AllColors)
                    {
                        this.cbFactionColor.Items.Add(color);
                    }
                    Microsoft.Xna.Framework.Graphics.Color color3 = this.person.Scenario.GameCommonData.AllColors[this.person.PersonBiography.FactionColor];
                    System.Drawing.Color color2 = System.Drawing.Color.FromArgb((int)color3.PackedValue);
                    try
                    {
                        this.cbFactionColor.SelectedIndex = this.cbFactionColor.Items.IndexOf(color2);
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbFactionColor.BackColor = color2;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbStrain.Text = this.person.Strain.ToString();
                    this.tbFather.Text = this.person.Father.ToString();
                    this.tbMother.Text = this.person.Mother.ToString();
                    this.tbSpouse.Text = this.person.Spouse.ToString();
                    this.tbBrother.Text = this.person.Brother.ToString();
                    this.tbGeneration.Text = this.person.Generation.ToString();
                    try
                    {
                        this.cbPersonalLoyalty.SelectedIndex = (int)this.person.PersonalLoyalty;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try 
                    {
                        this.cbAmbition.SelectedIndex = (int)this.person.Ambition;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbQualification.SelectedIndex = (int)this.person.Qualification;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbValuationOnGovernment.SelectedIndex = (int)this.person.ValuationOnGovernment;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbStrategyTendency.SelectedIndex = (int)this.person.StrategyTendency;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbOldFactionID.Text = this.person.OldFactionID.ToString();
                    this.tbProhibitedFactionID.Text = this.person.ProhibitedFactionID.ToString();
                    try
                    {
                        foreach (int num in this.person.ClosePersons)
                        {
                            this.lbClosePersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                        }
                        foreach (int num in this.person.HatedPersons)
                        {
                            this.lbHatedPersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                        }
                    }
                    catch
                    {
                    }
                    if (this.person.PersonBiography != null)
                    {
                        this.rtbBiographyBrief.Text = this.person.PersonBiography.Brief;
                        this.rtbBiographyRomance.Text = this.person.PersonBiography.Romance;
                        this.rtbBiographyHistory.Text = this.person.PersonBiography.History;
                    }
                    else
                    {
                        this.rtbBiographyBrief.Enabled = false;
                        this.rtbBiographyRomance.Enabled = false;
                        this.rtbBiographyHistory.Enabled = false;
                    }
                    this.InitializeSkillData(this.person);
                    this.InitializeStuntData(this.person);
                    this.InitializeTitleData(this.person);
                    this.rtbCriticalStrike.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.CriticalStrike);
                    this.rtbCriticalStrikeOnArchitecture.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.CriticalStrikeOnArchitecture);
                    this.rtbReceiveCriticalStrike.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.ReceiveCriticalStrike);
                    this.rtbSurround.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.Surround);
                    this.rtbRout.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.Rout);
                    this.rtbDualInitiativeWin.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.DualInitiativeWin);
                    this.rtbDualPassiveWin.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.DualPassiveWin);
                    this.rtbControversyInitiativeWin.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.ControversyInitiativeWin);
                    this.rtbControversyPassiveWin.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.ControversyPassiveWin);
                    this.rtbChaos.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.Chaos);
                    this.rtbDeepChaos.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.DeepChaos);
                    this.rtbCastDeepChaos.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.CastDeepChaos);
                    this.rtbRecoverFromChaos.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.RecoverFromChaos);
                    this.rtbTrappedByStratagem.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.TrappedByStratagem);
                    this.rtbHelpedByStratagem.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.HelpedByStratagem);
                    this.rtbResistHarmfulStratagem.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.ResistHarmfulStratagem);
                    this.rtbResistHelpfulStratagem.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.ResistHelpfulStratagem);
                    this.rtbAntiAttack.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.AntiAttack);
                    this.rtbBreakWall.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.BreakWall);
                    this.rtbOutburstAngry.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.OutburstAngry);
                    this.rtbOutburstQuiet.Text = StaticMethods.SaveToString(this.person.PersonTextMessage.OutburstQuiet);
            }
        }

        private void InitializeTitleData(Person p)
        {
            foreach (Title title in p.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                if (title.Kind == TitleKind.个人)
                {
                    this.cbPersonalTitle.Items.Add(title);
                }
                else if (title.Kind == TitleKind.战斗)
                {
                    this.cbCombatTitle.Items.Add(title);
                }
            }
            if (p.PersonalTitle != null)
            {
                this.cbPersonalTitle.SelectedItem = p.PersonalTitle;
            }
            if (p.CombatTitle != null)
            {
                this.cbCombatTitle.SelectedItem = p.CombatTitle;
            }
        }

        private void RefreshStuntList()
        {
            this.lbStunt.Items.Clear();
            foreach (Stunt stunt in this.person.Stunts.Stunts.Values)
            {
                this.lbStunt.Items.Add(stunt);
            }
        }

        private void rtbBiographyBrief_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.Brief = this.rtbBiographyBrief.Text;
        }

        private void rtbBiographyHistory_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.History = this.rtbBiographyHistory.Text;
        }

        private void rtbBiographyRomance_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.Romance = this.rtbBiographyRomance.Text;
        }

        private void SavePersonBasicData(Person p)
        {
            try
            {
                p.SurName = this.tbSurName.Text;
                p.GivenName = this.tbGivenName.Text;
                p.CalledName = this.tbCalledName.Text;
                p.PictureIndex = int.Parse(this.tbPic.Text);
                p.Ideal = int.Parse(this.tbIdeal.Text);
                p.IdealTendency = this.cbIdealTendency.SelectedItem as IdealTendencyKind;
                p.BornRegion = (PersonBornRegion) this.cbBornRegion.SelectedIndex;
                p.AvailableLocation = int.Parse(this.tbAvailableLocation.Text);
                p.YearAvailable = int.Parse(this.tbAvailableYear.Text);
                p.YearBorn = int.Parse(this.tbBornYear.Text);
                p.YearDead = int.Parse(this.tbDeadYear.Text);
                p.DeadReason = (PersonDeadReason) this.cbDeadReason.SelectedIndex;
                p.Strength = int.Parse(this.tbStrength.Text);
                p.Command = int.Parse(this.tbCommand.Text);
                p.Intelligence = int.Parse(this.tbIntelligence.Text);
                p.Politics = int.Parse(this.tbPolitics.Text);
                p.Glamour = int.Parse(this.tbGlamour.Text);
                p.StrengthExperience = int.Parse(this.tbStrengthExperience.Text);
                p.CommandExperience = int.Parse(this.tbCommandExperience.Text);
                p.IntelligenceExperience = int.Parse(this.tbIntelligenceExperience.Text);
                p.PoliticsExperience = int.Parse(this.tbPoliticsExperience.Text);
                p.GlamourExperience = int.Parse(this.tbGlamourExperience.Text);
                p.Braveness = int.Parse(this.tbBraveness.Text);
                p.Calmness = int.Parse(this.tbCalmness.Text);
                p.Loyalty = int.Parse(this.tbLoyalty.Text);
                p.Character = p.Scenario.GameCommonData.AllCharacterKinds[this.cbCharacter.SelectedIndex];
                p.Strain = int.Parse(this.tbStrain.Text);
                p.Father = int.Parse(this.tbFather.Text);
                p.Mother = int.Parse(this.tbMother.Text);
                p.Spouse = int.Parse(this.tbSpouse.Text);
                p.Brother = int.Parse(this.tbBrother.Text);
                p.Generation = int.Parse(this.tbGeneration.Text);
                p.PersonalLoyalty = (int) this.cbPersonalLoyalty.SelectedIndex;
                p.Ambition = (int) this.cbAmbition.SelectedIndex;
                p.Qualification = (PersonQualification) this.cbQualification.SelectedIndex;
                p.ValuationOnGovernment = (PersonValuationOnGovernment) this.cbValuationOnGovernment.SelectedIndex;
                p.StrategyTendency = (PersonStrategyTendency) this.cbStrategyTendency.SelectedIndex;
                p.OldFactionID = int.Parse(this.tbOldFactionID.Text);
                p.ProhibitedFactionID = int.Parse(this.tbProhibitedFactionID.Text);
                p.ClosePersons.Clear();
                foreach (string str in this.lbClosePersons.Items)
                {
                    p.ClosePersons.Add(int.Parse(str.Substring(0, str.IndexOf(" "))));
                }
                p.HatedPersons.Clear();
                foreach (string str in this.lbHatedPersons.Items)
                {
                    p.HatedPersons.Add(int.Parse(str.Substring(0, str.IndexOf(" "))));
                }
            }
            catch
            {
                MessageBox.Show("请输入正确的数据格式。");
            }
        }

        private void SavePersonSkills(Person p)
        {
            p.Skills.Clear();
            foreach (int num in this.clb00.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num));
            }
            foreach (int num in this.clb01.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 10));
            }
            foreach (int num in this.clb02.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 20));
            }
            foreach (int num in this.clb03.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 30));
            }
            foreach (int num in this.clb04.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 40));
            }
            foreach (int num in this.clb05.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 50));
            }
            foreach (int num in this.clb06.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 60));
            }
            foreach (int num in this.clb07.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 70));
            }
            foreach (int num in this.clb08.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 80));
            }
            foreach (int num in this.clb09.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 90));
            }
            foreach (int num in this.clb10.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 100));
            }
            foreach (int num in this.clb11.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 110));
            }
        }

        public void SetTabIndex(int index)
        {
            this.tabPerson.SelectedIndex = index;
        }

        private void tbBrother_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的义兄是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbBrother.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbFather_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的父亲是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbFather.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbMother_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的母亲是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbMother.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbOldFactionID_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的上一个君主是：" + (this.AllPersons.GetGameObject(int.Parse(this.tbOldFactionID.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbProhibitedFactionID_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "不能加入" + (this.AllPersons.GetGameObject(int.Parse(this.tbProhibitedFactionID.Text)) as Person).Name + "的势力";
                }
                catch
                {
                }
            }
        }

        private void tbSpouse_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的配偶是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbSpouse.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbStrain_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "属于" + (this.AllPersons.GetGameObject(int.Parse(this.tbStrain.Text)) as Person).Name + "一脉";
                }
                catch
                {
                }
            }
        }
    }
}

