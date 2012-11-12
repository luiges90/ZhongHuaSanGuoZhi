using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		System.Drawing;
using		System.Windows.Forms;
using System.Xml;
using System.ComponentModel;




namespace WorldOfTheThreeKingdoms.GameForms
{
    internal enum Difficulty
    {
        beginner,
        easy,
        normal,
        hard,
        veryhard,
        custom
    }

    public class formOptions : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private CheckBox cbAdditionalPersonAvailable;
        private CheckBox cbCommonPersonAvailable;
        private CheckBox cbDrawMapVeil;
        private CheckBox cbDrawTroopAnimation;
        private CheckBox cbHintPopulation;
        private CheckBox cbHintPopulationUnder1000;
        private CheckBox cbIdealTendencyValid;
        private CheckBox cbMilitaryKindSpeedValid;
        private CheckBox cbMultipleResource;
        private CheckBox cbNoHintOnSmallFacility;
        private CheckBox cbPersonNaturalDeath;
        private CheckBox cbPlayBattleSound;
        private CheckBox cbPlayerPersonAvailable;
        private CheckBox cbPlayMusic;
        private CheckBox cbPlayNormalSound;
        private CheckBox cbPopulationRecruitmentLimit;
        private CheckBox cbRunWhileNotFocused;
        private CheckBox cbSingleSelectionOneClick;
        private CheckBox cbSkyEye;
        private XmlDocument commonDoc = new XmlDocument();
        private IContainer components = null;
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
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label zainanbiaoqian;
        private XmlDocument parameterDoc = new XmlDocument();
        private TabPage tabPageAIParameter;
        private TabPage tabPageEnvironment;
        private TabPage tabPageParameter;
        private TabPage tabPagePerson;
        private TextBox tbAIArchitectureDamageRate;
        private TextBox tbAIFoodRate;
        private TextBox tbAIFundRate;
        private TextBox tbAIRecruitmentSpeedRate;
        private TextBox tbAITrainingSpeedRate;
        private TextBox tbAITroopDefenceRate;
        private TextBox tbAITroopOffenceRate;
        private TextBox tbArchitectureDamageRate;
        private TextBox tbBuyFoodAgriculture;
        private TextBox tbChangeCapitalCost;
        private TextBox tbClearFieldAgricultureCostUnit;
        private TextBox tbClearFieldFundCostUnit;
        private TextBox tbConvincePersonCost;
        private TextBox tbDefaultPopulationDevelopingRate;
        private TextBox tbDestroyArchitectureCost;
        private TextBox tbFindTreasureChance;
        private TextBox tbFireDamageScale;
        private TextBox tbFollowedLeaderDefenceRateIncrement;
        private TextBox tbFollowedLeaderOffenceRateIncrement;
        private TextBox tbFoodRate;
        private TextBox tbFoodToFundDivisor;
        private TextBox tbFundRate;
        private TextBox tbFundToFoodMultiple;
        private TextBox tbGossipArchitectureCost;
        private TextBox tbHireNoFactionPersonCost;
        private TextBox tbInstigateArchitectureCost;
        private TextBox tbInternalFundCost;
        private TextBox tbInternalRate;
        private TextBox tbLearnSkillDays;
        private TextBox tbLearnStuntDays;
        private TextBox tbLearnTitleDays;
        private TextBox tbRecruitmentDomination;
        private TextBox tbRecruitmentFundCost;
        private TextBox tbRecruitmentMorale;
        private TextBox tbRecruitmentRate;
        private TextBox tbRewardPersonCost;
        private TextBox tbSellFoodCommerce;
        private TextBox tbSendSpyCost;
        private TextBox tbSurroundArchitectureDominationUnit;
        private TextBox tbTrainingRate;
        private TextBox tbTroopDamageRate;
        private TextBox tbTroopMoveSpeed;
        private TabControl tcOptions;
        private CheckBox cbPinPointAtPlayer;
        private CheckBox cbIgnoreStrategyTendency;
        private CheckBox cbCreateChildren;
        private TextBox zainanfashengjilv;
        private CheckBox cbDoAutoSave;
        private CheckBox cbCreateChildrenIgnoreLimit;
        private CheckBox cbInternalSurplusRateForPlayer;
        private CheckBox cbInternalSurplusRateForAI;
        private TextBox tbGetChildrenRate;
        private Label label43;
        private TextBox tbAIExecutionRate;
        private CheckBox cbAIExecuteBetterOfficer;
        private Label label44;
        private TextBox tbMaxExperience;
        private CheckBox cbLockChildrenLoyalty;
        private CheckBox cbAIAutoTakePlayerCaptives;
        private CheckBox cbAIAutoTakeNoFactionPerson;
        private CheckBox cbAIAutoTakeNoFactionCaptives;
        private CheckBox cbAIAutoTakePlayerCaptiveOnlyUnfull;
        private Label label45;
        private TextBox tbDialogShowTime;
        private Label label46;
        private TextBox tbTechniquePointMultiple;
        private CheckBox cbPermitFactionMerge;
        private GroupBox groupBox1;
        private RadioButton rbHard;
        private RadioButton rbNormal;
        private RadioButton rbEasy;
        private RadioButton rbBeginner;
        private RadioButton rbVeryhard;
        private RadioButton rbCustom;
        private Label label47;
        private TextBox tbLeadershipOffenceRate;
        private CheckBox checkLiangdaoXitong;
        private CheckBox wujiangYoukenengDuli;
        private TextBox tbBattleSpeed;
        private Label label48;
        private Label getChildrenRateLabel;

        public formOptions()
        {
            this.InitializeComponent();
            this.LoadCommonDoc();
            this.LoadParameterDoc();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SaveCommonDoc();
            this.SaveParameterDoc();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tabPageEnvironment = new System.Windows.Forms.TabPage();
            this.wujiangYoukenengDuli = new System.Windows.Forms.CheckBox();
            this.checkLiangdaoXitong = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbVeryhard = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.rbBeginner = new System.Windows.Forms.RadioButton();
            this.cbPermitFactionMerge = new System.Windows.Forms.CheckBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbDialogShowTime = new System.Windows.Forms.TextBox();
            this.cbMilitaryKindSpeedValid = new System.Windows.Forms.CheckBox();
            this.cbPopulationRecruitmentLimit = new System.Windows.Forms.CheckBox();
            this.cbHintPopulationUnder1000 = new System.Windows.Forms.CheckBox();
            this.cbHintPopulation = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTroopMoveSpeed = new System.Windows.Forms.TextBox();
            this.cbNoHintOnSmallFacility = new System.Windows.Forms.CheckBox();
            this.cbSingleSelectionOneClick = new System.Windows.Forms.CheckBox();
            this.cbMultipleResource = new System.Windows.Forms.CheckBox();
            this.cbSkyEye = new System.Windows.Forms.CheckBox();
            this.cbDrawTroopAnimation = new System.Windows.Forms.CheckBox();
            this.cbDrawMapVeil = new System.Windows.Forms.CheckBox();
            this.cbPlayBattleSound = new System.Windows.Forms.CheckBox();
            this.cbPlayNormalSound = new System.Windows.Forms.CheckBox();
            this.cbPlayMusic = new System.Windows.Forms.CheckBox();
            this.cbRunWhileNotFocused = new System.Windows.Forms.CheckBox();
            this.zainanbiaoqian = new System.Windows.Forms.Label();
            this.zainanfashengjilv = new System.Windows.Forms.TextBox();
            this.cbDoAutoSave = new System.Windows.Forms.CheckBox();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.cbLockChildrenLoyalty = new System.Windows.Forms.CheckBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tbMaxExperience = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tbFollowedLeaderDefenceRateIncrement = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tbFollowedLeaderOffenceRateIncrement = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbLearnTitleDays = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tbLearnStuntDays = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbLearnSkillDays = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tbFindTreasureChance = new System.Windows.Forms.TextBox();
            this.cbIdealTendencyValid = new System.Windows.Forms.CheckBox();
            this.cbPersonNaturalDeath = new System.Windows.Forms.CheckBox();
            this.cbPlayerPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbAdditionalPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbCommonPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbCreateChildren = new System.Windows.Forms.CheckBox();
            this.cbCreateChildrenIgnoreLimit = new System.Windows.Forms.CheckBox();
            this.tbGetChildrenRate = new System.Windows.Forms.TextBox();
            this.getChildrenRateLabel = new System.Windows.Forms.Label();
            this.tabPageParameter = new System.Windows.Forms.TabPage();
            this.label47 = new System.Windows.Forms.Label();
            this.tbLeadershipOffenceRate = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tbTechniquePointMultiple = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tbFireDamageScale = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbSurroundArchitectureDominationUnit = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbFoodToFundDivisor = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbFundToFoodMultiple = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbSellFoodCommerce = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbBuyFoodAgriculture = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbClearFieldAgricultureCostUnit = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbClearFieldFundCostUnit = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbGossipArchitectureCost = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbInstigateArchitectureCost = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbDestroyArchitectureCost = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbSendSpyCost = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbRewardPersonCost = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbConvincePersonCost = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbHireNoFactionPersonCost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbChangeCapitalCost = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbRecruitmentMorale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRecruitmentDomination = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRecruitmentFundCost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbInternalFundCost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDefaultPopulationDevelopingRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbArchitectureDamageRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTroopDamageRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFoodRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFundRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRecruitmentRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTrainingRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInternalRate = new System.Windows.Forms.TextBox();
            this.tabPageAIParameter = new System.Windows.Forms.TabPage();
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakePlayerCaptives = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakeNoFactionPerson = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakeNoFactionCaptives = new System.Windows.Forms.CheckBox();
            this.cbAIExecuteBetterOfficer = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tbAIExecutionRate = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbAITrainingSpeedRate = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tbAIRecruitmentSpeedRate = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbAITroopDefenceRate = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbAIArchitectureDamageRate = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbAITroopOffenceRate = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbAIFoodRate = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbAIFundRate = new System.Windows.Forms.TextBox();
            this.cbPinPointAtPlayer = new System.Windows.Forms.CheckBox();
            this.cbIgnoreStrategyTendency = new System.Windows.Forms.CheckBox();
            this.cbInternalSurplusRateForPlayer = new System.Windows.Forms.CheckBox();
            this.cbInternalSurplusRateForAI = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.tbBattleSpeed = new System.Windows.Forms.TextBox();
            this.tcOptions.SuspendLayout();
            this.tabPageEnvironment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.tabPageParameter.SuspendLayout();
            this.tabPageAIParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tabPageEnvironment);
            this.tcOptions.Controls.Add(this.tabPagePerson);
            this.tcOptions.Controls.Add(this.tabPageParameter);
            this.tcOptions.Controls.Add(this.tabPageAIParameter);
            this.tcOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tcOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcOptions.Location = new System.Drawing.Point(0, 0);
            this.tcOptions.Multiline = true;
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(453, 448);
            this.tcOptions.TabIndex = 0;
            // 
            // tabPageEnvironment
            // 
            this.tabPageEnvironment.Controls.Add(this.tbBattleSpeed);
            this.tabPageEnvironment.Controls.Add(this.label48);
            this.tabPageEnvironment.Controls.Add(this.wujiangYoukenengDuli);
            this.tabPageEnvironment.Controls.Add(this.checkLiangdaoXitong);
            this.tabPageEnvironment.Controls.Add(this.groupBox1);
            this.tabPageEnvironment.Controls.Add(this.cbPermitFactionMerge);
            this.tabPageEnvironment.Controls.Add(this.label45);
            this.tabPageEnvironment.Controls.Add(this.tbDialogShowTime);
            this.tabPageEnvironment.Controls.Add(this.cbMilitaryKindSpeedValid);
            this.tabPageEnvironment.Controls.Add(this.cbPopulationRecruitmentLimit);
            this.tabPageEnvironment.Controls.Add(this.cbHintPopulationUnder1000);
            this.tabPageEnvironment.Controls.Add(this.cbHintPopulation);
            this.tabPageEnvironment.Controls.Add(this.label1);
            this.tabPageEnvironment.Controls.Add(this.tbTroopMoveSpeed);
            this.tabPageEnvironment.Controls.Add(this.cbNoHintOnSmallFacility);
            this.tabPageEnvironment.Controls.Add(this.cbSingleSelectionOneClick);
            this.tabPageEnvironment.Controls.Add(this.cbMultipleResource);
            this.tabPageEnvironment.Controls.Add(this.cbSkyEye);
            this.tabPageEnvironment.Controls.Add(this.cbDrawTroopAnimation);
            this.tabPageEnvironment.Controls.Add(this.cbDrawMapVeil);
            this.tabPageEnvironment.Controls.Add(this.cbPlayBattleSound);
            this.tabPageEnvironment.Controls.Add(this.cbPlayNormalSound);
            this.tabPageEnvironment.Controls.Add(this.cbPlayMusic);
            this.tabPageEnvironment.Controls.Add(this.cbRunWhileNotFocused);
            this.tabPageEnvironment.Controls.Add(this.zainanbiaoqian);
            this.tabPageEnvironment.Controls.Add(this.zainanfashengjilv);
            this.tabPageEnvironment.Controls.Add(this.cbDoAutoSave);
            this.tabPageEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnvironment.Name = "tabPageEnvironment";
            this.tabPageEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnvironment.Size = new System.Drawing.Size(445, 422);
            this.tabPageEnvironment.TabIndex = 0;
            this.tabPageEnvironment.Text = "环境";
            this.tabPageEnvironment.UseVisualStyleBackColor = true;
            this.tabPageEnvironment.Click += new System.EventHandler(this.tabPageEnvironment_Click);
            // 
            // wujiangYoukenengDuli
            // 
            this.wujiangYoukenengDuli.AutoSize = true;
            this.wujiangYoukenengDuli.Location = new System.Drawing.Point(260, 60);
            this.wujiangYoukenengDuli.Name = "wujiangYoukenengDuli";
            this.wujiangYoukenengDuli.Size = new System.Drawing.Size(108, 16);
            this.wujiangYoukenengDuli.TabIndex = 106;
            this.wujiangYoukenengDuli.Text = "武将有可能独立";
            this.wujiangYoukenengDuli.UseVisualStyleBackColor = true;
            // 
            // checkLiangdaoXitong
            // 
            this.checkLiangdaoXitong.AutoSize = true;
            this.checkLiangdaoXitong.Location = new System.Drawing.Point(260, 38);
            this.checkLiangdaoXitong.Name = "checkLiangdaoXitong";
            this.checkLiangdaoXitong.Size = new System.Drawing.Size(72, 16);
            this.checkLiangdaoXitong.TabIndex = 105;
            this.checkLiangdaoXitong.Text = "粮道系统";
            this.checkLiangdaoXitong.UseVisualStyleBackColor = true;
            this.checkLiangdaoXitong.CheckedChanged += new System.EventHandler(this.checkLiangdaoXitong_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCustom);
            this.groupBox1.Controls.Add(this.rbVeryhard);
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbNormal);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Controls.Add(this.rbBeginner);
            this.groupBox1.Location = new System.Drawing.Point(253, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 151);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏难度";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(7, 129);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(47, 16);
            this.rbCustom.TabIndex = 5;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "自订";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbVeryhard
            // 
            this.rbVeryhard.AutoSize = true;
            this.rbVeryhard.Location = new System.Drawing.Point(7, 107);
            this.rbVeryhard.Name = "rbVeryhard";
            this.rbVeryhard.Size = new System.Drawing.Size(47, 16);
            this.rbVeryhard.TabIndex = 4;
            this.rbVeryhard.TabStop = true;
            this.rbVeryhard.Text = "修罗";
            this.rbVeryhard.UseVisualStyleBackColor = true;
            this.rbVeryhard.CheckedChanged += new System.EventHandler(this.veryhardSelected);
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(7, 85);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(47, 16);
            this.rbHard.TabIndex = 3;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "超级";
            this.rbHard.UseVisualStyleBackColor = true;
            this.rbHard.CheckedChanged += new System.EventHandler(this.hardSelected);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(6, 63);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(47, 16);
            this.rbNormal.TabIndex = 2;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "上级";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.normalSelected);
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Location = new System.Drawing.Point(6, 41);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(47, 16);
            this.rbEasy.TabIndex = 1;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "初级";
            this.rbEasy.UseVisualStyleBackColor = true;
            this.rbEasy.CheckedChanged += new System.EventHandler(this.easySelected);
            // 
            // rbBeginner
            // 
            this.rbBeginner.AutoSize = true;
            this.rbBeginner.Location = new System.Drawing.Point(6, 19);
            this.rbBeginner.Name = "rbBeginner";
            this.rbBeginner.Size = new System.Drawing.Size(47, 16);
            this.rbBeginner.TabIndex = 0;
            this.rbBeginner.TabStop = true;
            this.rbBeginner.Text = "入门";
            this.rbBeginner.UseVisualStyleBackColor = true;
            this.rbBeginner.CheckedChanged += new System.EventHandler(this.beginnerSelected);
            // 
            // cbPermitFactionMerge
            // 
            this.cbPermitFactionMerge.AutoSize = true;
            this.cbPermitFactionMerge.Location = new System.Drawing.Point(20, 325);
            this.cbPermitFactionMerge.Name = "cbPermitFactionMerge";
            this.cbPermitFactionMerge.Size = new System.Drawing.Size(96, 16);
            this.cbPermitFactionMerge.TabIndex = 103;
            this.cbPermitFactionMerge.Text = "容许势力合并";
            this.cbPermitFactionMerge.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(258, 89);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(89, 12);
            this.label45.TabIndex = 102;
            this.label45.Text = "对话窗显示时间";
            // 
            // tbDialogShowTime
            // 
            this.tbDialogShowTime.Location = new System.Drawing.Point(353, 86);
            this.tbDialogShowTime.MaxLength = 2;
            this.tbDialogShowTime.Name = "tbDialogShowTime";
            this.tbDialogShowTime.Size = new System.Drawing.Size(27, 22);
            this.tbDialogShowTime.TabIndex = 101;
            this.tbDialogShowTime.Text = "0";
            // 
            // cbMilitaryKindSpeedValid
            // 
            this.cbMilitaryKindSpeedValid.AutoSize = true;
            this.cbMilitaryKindSpeedValid.Location = new System.Drawing.Point(20, 303);
            this.cbMilitaryKindSpeedValid.Name = "cbMilitaryKindSpeedValid";
            this.cbMilitaryKindSpeedValid.Size = new System.Drawing.Size(96, 16);
            this.cbMilitaryKindSpeedValid.TabIndex = 15;
            this.cbMilitaryKindSpeedValid.Text = "部队速率有效";
            this.cbMilitaryKindSpeedValid.UseVisualStyleBackColor = true;
            // 
            // cbPopulationRecruitmentLimit
            // 
            this.cbPopulationRecruitmentLimit.AutoSize = true;
            this.cbPopulationRecruitmentLimit.Location = new System.Drawing.Point(20, 281);
            this.cbPopulationRecruitmentLimit.Name = "cbPopulationRecruitmentLimit";
            this.cbPopulationRecruitmentLimit.Size = new System.Drawing.Size(156, 16);
            this.cbPopulationRecruitmentLimit.TabIndex = 14;
            this.cbPopulationRecruitmentLimit.Text = "人口小于兵力时禁止征兵";
            this.cbPopulationRecruitmentLimit.UseVisualStyleBackColor = true;
            // 
            // cbHintPopulationUnder1000
            // 
            this.cbHintPopulationUnder1000.AutoSize = true;
            this.cbHintPopulationUnder1000.Location = new System.Drawing.Point(20, 259);
            this.cbHintPopulationUnder1000.Name = "cbHintPopulationUnder1000";
            this.cbHintPopulationUnder1000.Size = new System.Drawing.Size(168, 16);
            this.cbHintPopulationUnder1000.TabIndex = 13;
            this.cbHintPopulationUnder1000.Text = "提示1000人以下的人口迁移";
            this.cbHintPopulationUnder1000.UseVisualStyleBackColor = true;
            // 
            // cbHintPopulation
            // 
            this.cbHintPopulation.AutoSize = true;
            this.cbHintPopulation.Location = new System.Drawing.Point(20, 237);
            this.cbHintPopulation.Name = "cbHintPopulation";
            this.cbHintPopulation.Size = new System.Drawing.Size(108, 16);
            this.cbHintPopulation.TabIndex = 12;
            this.cbHintPopulation.Text = "提示人口的迁移";
            this.cbHintPopulation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "部队移动速度（数字越大则越慢）";
            // 
            // tbTroopMoveSpeed
            // 
            this.tbTroopMoveSpeed.Location = new System.Drawing.Point(209, 350);
            this.tbTroopMoveSpeed.MaxLength = 1;
            this.tbTroopMoveSpeed.Name = "tbTroopMoveSpeed";
            this.tbTroopMoveSpeed.Size = new System.Drawing.Size(27, 22);
            this.tbTroopMoveSpeed.TabIndex = 10;
            this.tbTroopMoveSpeed.Text = "0";
            // 
            // cbNoHintOnSmallFacility
            // 
            this.cbNoHintOnSmallFacility.AutoSize = true;
            this.cbNoHintOnSmallFacility.Location = new System.Drawing.Point(20, 215);
            this.cbNoHintOnSmallFacility.Name = "cbNoHintOnSmallFacility";
            this.cbNoHintOnSmallFacility.Size = new System.Drawing.Size(168, 16);
            this.cbNoHintOnSmallFacility.TabIndex = 9;
            this.cbNoHintOnSmallFacility.Text = "不提示小型设施的建设完成";
            this.cbNoHintOnSmallFacility.UseVisualStyleBackColor = true;
            // 
            // cbSingleSelectionOneClick
            // 
            this.cbSingleSelectionOneClick.AutoSize = true;
            this.cbSingleSelectionOneClick.Location = new System.Drawing.Point(20, 193);
            this.cbSingleSelectionOneClick.Name = "cbSingleSelectionOneClick";
            this.cbSingleSelectionOneClick.Size = new System.Drawing.Size(216, 16);
            this.cbSingleSelectionOneClick.TabIndex = 8;
            this.cbSingleSelectionOneClick.Text = "从某列表中选择单一项时单击即确定";
            this.cbSingleSelectionOneClick.UseVisualStyleBackColor = true;
            // 
            // cbMultipleResource
            // 
            this.cbMultipleResource.AutoSize = true;
            this.cbMultipleResource.Location = new System.Drawing.Point(20, 171);
            this.cbMultipleResource.Name = "cbMultipleResource";
            this.cbMultipleResource.Size = new System.Drawing.Size(96, 16);
            this.cbMultipleResource.TabIndex = 7;
            this.cbMultipleResource.Text = "资源收入加倍";
            this.cbMultipleResource.UseVisualStyleBackColor = true;
            // 
            // cbSkyEye
            // 
            this.cbSkyEye.AutoSize = true;
            this.cbSkyEye.Location = new System.Drawing.Point(20, 149);
            this.cbSkyEye.Name = "cbSkyEye";
            this.cbSkyEye.Size = new System.Drawing.Size(96, 16);
            this.cbSkyEye.TabIndex = 6;
            this.cbSkyEye.Text = "默认开启天眼";
            this.cbSkyEye.UseVisualStyleBackColor = true;
            // 
            // cbDrawTroopAnimation
            // 
            this.cbDrawTroopAnimation.AutoSize = true;
            this.cbDrawTroopAnimation.Location = new System.Drawing.Point(20, 127);
            this.cbDrawTroopAnimation.Name = "cbDrawTroopAnimation";
            this.cbDrawTroopAnimation.Size = new System.Drawing.Size(96, 16);
            this.cbDrawTroopAnimation.TabIndex = 5;
            this.cbDrawTroopAnimation.Text = "显示部队动画";
            this.cbDrawTroopAnimation.UseVisualStyleBackColor = true;
            // 
            // cbDrawMapVeil
            // 
            this.cbDrawMapVeil.AutoSize = true;
            this.cbDrawMapVeil.Location = new System.Drawing.Point(20, 105);
            this.cbDrawMapVeil.Name = "cbDrawMapVeil";
            this.cbDrawMapVeil.Size = new System.Drawing.Size(96, 16);
            this.cbDrawMapVeil.TabIndex = 4;
            this.cbDrawMapVeil.Text = "显示地图烟幕";
            this.cbDrawMapVeil.UseVisualStyleBackColor = true;
            // 
            // cbPlayBattleSound
            // 
            this.cbPlayBattleSound.AutoSize = true;
            this.cbPlayBattleSound.Location = new System.Drawing.Point(20, 83);
            this.cbPlayBattleSound.Name = "cbPlayBattleSound";
            this.cbPlayBattleSound.Size = new System.Drawing.Size(96, 16);
            this.cbPlayBattleSound.TabIndex = 3;
            this.cbPlayBattleSound.Text = "播放战斗音效";
            this.cbPlayBattleSound.UseVisualStyleBackColor = true;
            // 
            // cbPlayNormalSound
            // 
            this.cbPlayNormalSound.AutoSize = true;
            this.cbPlayNormalSound.Location = new System.Drawing.Point(20, 61);
            this.cbPlayNormalSound.Name = "cbPlayNormalSound";
            this.cbPlayNormalSound.Size = new System.Drawing.Size(96, 16);
            this.cbPlayNormalSound.TabIndex = 2;
            this.cbPlayNormalSound.Text = "播放一般音效";
            this.cbPlayNormalSound.UseVisualStyleBackColor = true;
            // 
            // cbPlayMusic
            // 
            this.cbPlayMusic.AutoSize = true;
            this.cbPlayMusic.Location = new System.Drawing.Point(20, 39);
            this.cbPlayMusic.Name = "cbPlayMusic";
            this.cbPlayMusic.Size = new System.Drawing.Size(72, 16);
            this.cbPlayMusic.TabIndex = 1;
            this.cbPlayMusic.Text = "播放音乐";
            this.cbPlayMusic.UseVisualStyleBackColor = true;
            // 
            // cbRunWhileNotFocused
            // 
            this.cbRunWhileNotFocused.AutoSize = true;
            this.cbRunWhileNotFocused.Location = new System.Drawing.Point(20, 17);
            this.cbRunWhileNotFocused.Name = "cbRunWhileNotFocused";
            this.cbRunWhileNotFocused.Size = new System.Drawing.Size(180, 16);
            this.cbRunWhileNotFocused.TabIndex = 0;
            this.cbRunWhileNotFocused.Text = "游戏窗体失去焦点时继续运行";
            this.cbRunWhileNotFocused.UseVisualStyleBackColor = true;
            // 
            // zainanbiaoqian
            // 
            this.zainanbiaoqian.AutoSize = true;
            this.zainanbiaoqian.Location = new System.Drawing.Point(18, 378);
            this.zainanbiaoqian.Name = "zainanbiaoqian";
            this.zainanbiaoqian.Size = new System.Drawing.Size(194, 12);
            this.zainanbiaoqian.TabIndex = 11;
            this.zainanbiaoqian.Text = "灾难发生几率（发生几率为1/此数）";
            // 
            // zainanfashengjilv
            // 
            this.zainanfashengjilv.Location = new System.Drawing.Point(220, 373);
            this.zainanfashengjilv.Name = "zainanfashengjilv";
            this.zainanfashengjilv.Size = new System.Drawing.Size(50, 22);
            this.zainanfashengjilv.TabIndex = 11;
            this.zainanfashengjilv.Text = "3000";
            // 
            // cbDoAutoSave
            // 
            this.cbDoAutoSave.AutoSize = true;
            this.cbDoAutoSave.Location = new System.Drawing.Point(260, 16);
            this.cbDoAutoSave.Name = "cbDoAutoSave";
            this.cbDoAutoSave.Size = new System.Drawing.Size(72, 16);
            this.cbDoAutoSave.TabIndex = 100;
            this.cbDoAutoSave.Text = "自动存档";
            this.cbDoAutoSave.UseVisualStyleBackColor = true;
            // 
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.cbLockChildrenLoyalty);
            this.tabPagePerson.Controls.Add(this.label44);
            this.tabPagePerson.Controls.Add(this.tbMaxExperience);
            this.tabPagePerson.Controls.Add(this.label42);
            this.tabPagePerson.Controls.Add(this.tbFollowedLeaderDefenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.label41);
            this.tabPagePerson.Controls.Add(this.tbFollowedLeaderOffenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.label37);
            this.tabPagePerson.Controls.Add(this.tbLearnTitleDays);
            this.tabPagePerson.Controls.Add(this.label38);
            this.tabPagePerson.Controls.Add(this.tbLearnStuntDays);
            this.tabPagePerson.Controls.Add(this.label39);
            this.tabPagePerson.Controls.Add(this.tbLearnSkillDays);
            this.tabPagePerson.Controls.Add(this.label36);
            this.tabPagePerson.Controls.Add(this.tbFindTreasureChance);
            this.tabPagePerson.Controls.Add(this.cbIdealTendencyValid);
            this.tabPagePerson.Controls.Add(this.cbPersonNaturalDeath);
            this.tabPagePerson.Controls.Add(this.cbPlayerPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbAdditionalPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbCommonPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbCreateChildren);
            this.tabPagePerson.Controls.Add(this.cbCreateChildrenIgnoreLimit);
            this.tabPagePerson.Controls.Add(this.tbGetChildrenRate);
            this.tabPagePerson.Controls.Add(this.getChildrenRateLabel);
            this.tabPagePerson.Location = new System.Drawing.Point(4, 22);
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePerson.Size = new System.Drawing.Size(445, 422);
            this.tabPagePerson.TabIndex = 1;
            this.tabPagePerson.Text = "人物";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // cbLockChildrenLoyalty
            // 
            this.cbLockChildrenLoyalty.AutoSize = true;
            this.cbLockChildrenLoyalty.Location = new System.Drawing.Point(281, 18);
            this.cbLockChildrenLoyalty.Name = "cbLockChildrenLoyalty";
            this.cbLockChildrenLoyalty.Size = new System.Drawing.Size(132, 16);
            this.cbLockChildrenLoyalty.TabIndex = 26;
            this.cbLockChildrenLoyalty.Text = "生下的子女绝对忠诚";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(19, 371);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(53, 12);
            this.label44.TabIndex = 25;
            this.label44.Text = "最大经验";
            // 
            // tbMaxExperience
            // 
            this.tbMaxExperience.Location = new System.Drawing.Point(78, 368);
            this.tbMaxExperience.Name = "tbMaxExperience";
            this.tbMaxExperience.Size = new System.Drawing.Size(71, 22);
            this.tbMaxExperience.TabIndex = 24;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(19, 288);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(113, 12);
            this.label42.TabIndex = 23;
            this.label42.Text = "追随将领防御力加成";
            // 
            // tbFollowedLeaderDefenceRateIncrement
            // 
            this.tbFollowedLeaderDefenceRateIncrement.Location = new System.Drawing.Point(143, 285);
            this.tbFollowedLeaderDefenceRateIncrement.Name = "tbFollowedLeaderDefenceRateIncrement";
            this.tbFollowedLeaderDefenceRateIncrement.Size = new System.Drawing.Size(71, 22);
            this.tbFollowedLeaderDefenceRateIncrement.TabIndex = 22;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(19, 261);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(113, 12);
            this.label41.TabIndex = 21;
            this.label41.Text = "追随将领攻击力加成";
            // 
            // tbFollowedLeaderOffenceRateIncrement
            // 
            this.tbFollowedLeaderOffenceRateIncrement.Location = new System.Drawing.Point(143, 258);
            this.tbFollowedLeaderOffenceRateIncrement.Name = "tbFollowedLeaderOffenceRateIncrement";
            this.tbFollowedLeaderOffenceRateIncrement.Size = new System.Drawing.Size(71, 22);
            this.tbFollowedLeaderOffenceRateIncrement.TabIndex = 20;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(19, 233);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(77, 12);
            this.label37.TabIndex = 19;
            this.label37.Text = "修习称号时间";
            // 
            // tbLearnTitleDays
            // 
            this.tbLearnTitleDays.Location = new System.Drawing.Point(111, 230);
            this.tbLearnTitleDays.Name = "tbLearnTitleDays";
            this.tbLearnTitleDays.Size = new System.Drawing.Size(71, 22);
            this.tbLearnTitleDays.TabIndex = 18;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(19, 207);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 12);
            this.label38.TabIndex = 17;
            this.label38.Text = "修习特技时间";
            // 
            // tbLearnStuntDays
            // 
            this.tbLearnStuntDays.Location = new System.Drawing.Point(111, 202);
            this.tbLearnStuntDays.Name = "tbLearnStuntDays";
            this.tbLearnStuntDays.Size = new System.Drawing.Size(71, 22);
            this.tbLearnStuntDays.TabIndex = 16;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(19, 177);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(77, 12);
            this.label39.TabIndex = 15;
            this.label39.Text = "修习技能时间";
            // 
            // tbLearnSkillDays
            // 
            this.tbLearnSkillDays.Location = new System.Drawing.Point(111, 174);
            this.tbLearnSkillDays.Name = "tbLearnSkillDays";
            this.tbLearnSkillDays.Size = new System.Drawing.Size(71, 22);
            this.tbLearnSkillDays.TabIndex = 14;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(17, 150);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(209, 12);
            this.label36.TabIndex = 13;
            this.label36.Text = "宝物发现概率（数字越大越容易发现）";
            // 
            // tbFindTreasureChance
            // 
            this.tbFindTreasureChance.Location = new System.Drawing.Point(232, 147);
            this.tbFindTreasureChance.MaxLength = 2;
            this.tbFindTreasureChance.Name = "tbFindTreasureChance";
            this.tbFindTreasureChance.Size = new System.Drawing.Size(25, 22);
            this.tbFindTreasureChance.TabIndex = 12;
            this.tbFindTreasureChance.Text = "10";
            // 
            // cbIdealTendencyValid
            // 
            this.cbIdealTendencyValid.AutoSize = true;
            this.cbIdealTendencyValid.Location = new System.Drawing.Point(19, 124);
            this.cbIdealTendencyValid.Name = "cbIdealTendencyValid";
            this.cbIdealTendencyValid.Size = new System.Drawing.Size(120, 16);
            this.cbIdealTendencyValid.TabIndex = 4;
            this.cbIdealTendencyValid.Text = "出仕相性考虑有效";
            this.cbIdealTendencyValid.UseVisualStyleBackColor = true;
            // 
            // cbPersonNaturalDeath
            // 
            this.cbPersonNaturalDeath.AutoSize = true;
            this.cbPersonNaturalDeath.Location = new System.Drawing.Point(19, 102);
            this.cbPersonNaturalDeath.Name = "cbPersonNaturalDeath";
            this.cbPersonNaturalDeath.Size = new System.Drawing.Size(72, 16);
            this.cbPersonNaturalDeath.TabIndex = 3;
            this.cbPersonNaturalDeath.Text = "年龄有效";
            this.cbPersonNaturalDeath.UseVisualStyleBackColor = true;
            // 
            // cbPlayerPersonAvailable
            // 
            this.cbPlayerPersonAvailable.AutoSize = true;
            this.cbPlayerPersonAvailable.Location = new System.Drawing.Point(19, 80);
            this.cbPlayerPersonAvailable.Name = "cbPlayerPersonAvailable";
            this.cbPlayerPersonAvailable.Size = new System.Drawing.Size(172, 16);
            this.cbPlayerPersonAvailable.TabIndex = 2;
            this.cbPlayerPersonAvailable.Text = "玩家人物登场（9000-9999）";
            this.cbPlayerPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbAdditionalPersonAvailable
            // 
            this.cbAdditionalPersonAvailable.AutoSize = true;
            this.cbAdditionalPersonAvailable.Location = new System.Drawing.Point(19, 58);
            this.cbAdditionalPersonAvailable.Name = "cbAdditionalPersonAvailable";
            this.cbAdditionalPersonAvailable.Size = new System.Drawing.Size(172, 16);
            this.cbAdditionalPersonAvailable.TabIndex = 1;
            this.cbAdditionalPersonAvailable.Text = "附加人物登场（8000-8999）";
            this.cbAdditionalPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbCommonPersonAvailable
            // 
            this.cbCommonPersonAvailable.AutoSize = true;
            this.cbCommonPersonAvailable.Location = new System.Drawing.Point(19, 18);
            this.cbCommonPersonAvailable.Name = "cbCommonPersonAvailable";
            this.cbCommonPersonAvailable.Size = new System.Drawing.Size(172, 16);
            this.cbCommonPersonAvailable.TabIndex = 0;
            this.cbCommonPersonAvailable.Text = "一般人物登场（0000-4999）";
            this.cbCommonPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbCreateChildren
            // 
            this.cbCreateChildren.AutoSize = true;
            this.cbCreateChildren.Location = new System.Drawing.Point(19, 37);
            this.cbCreateChildren.Name = "cbCreateChildren";
            this.cbCreateChildren.Size = new System.Drawing.Size(172, 16);
            this.cbCreateChildren.TabIndex = 10;
            this.cbCreateChildren.Text = "生成虚拟子嗣（5000-6999）";
            // 
            // cbCreateChildrenIgnoreLimit
            // 
            this.cbCreateChildrenIgnoreLimit.AutoSize = true;
            this.cbCreateChildrenIgnoreLimit.Location = new System.Drawing.Point(19, 315);
            this.cbCreateChildrenIgnoreLimit.Name = "cbCreateChildrenIgnoreLimit";
            this.cbCreateChildrenIgnoreLimit.Size = new System.Drawing.Size(156, 16);
            this.cbCreateChildrenIgnoreLimit.TabIndex = 10;
            this.cbCreateChildrenIgnoreLimit.Text = "虚拟子嗣能力可超越上限";
            // 
            // tbGetChildrenRate
            // 
            this.tbGetChildrenRate.Location = new System.Drawing.Point(216, 338);
            this.tbGetChildrenRate.Name = "tbGetChildrenRate";
            this.tbGetChildrenRate.Size = new System.Drawing.Size(71, 22);
            this.tbGetChildrenRate.TabIndex = 16;
            // 
            // getChildrenRateLabel
            // 
            this.getChildrenRateLabel.AutoSize = true;
            this.getChildrenRateLabel.Location = new System.Drawing.Point(19, 342);
            this.getChildrenRateLabel.Name = "getChildrenRateLabel";
            this.getChildrenRateLabel.Size = new System.Drawing.Size(197, 12);
            this.getChildrenRateLabel.TabIndex = 15;
            this.getChildrenRateLabel.Text = "怀孕机率（数字愈大怀孕机率愈低）";
            // 
            // tabPageParameter
            // 
            this.tabPageParameter.Controls.Add(this.label47);
            this.tabPageParameter.Controls.Add(this.tbLeadershipOffenceRate);
            this.tabPageParameter.Controls.Add(this.label46);
            this.tabPageParameter.Controls.Add(this.tbTechniquePointMultiple);
            this.tabPageParameter.Controls.Add(this.label40);
            this.tabPageParameter.Controls.Add(this.tbFireDamageScale);
            this.tabPageParameter.Controls.Add(this.label33);
            this.tabPageParameter.Controls.Add(this.tbSurroundArchitectureDominationUnit);
            this.tabPageParameter.Controls.Add(this.label27);
            this.tabPageParameter.Controls.Add(this.tbFoodToFundDivisor);
            this.tabPageParameter.Controls.Add(this.label26);
            this.tabPageParameter.Controls.Add(this.tbFundToFoodMultiple);
            this.tabPageParameter.Controls.Add(this.label25);
            this.tabPageParameter.Controls.Add(this.tbSellFoodCommerce);
            this.tabPageParameter.Controls.Add(this.label24);
            this.tabPageParameter.Controls.Add(this.tbBuyFoodAgriculture);
            this.tabPageParameter.Controls.Add(this.label23);
            this.tabPageParameter.Controls.Add(this.tbClearFieldAgricultureCostUnit);
            this.tabPageParameter.Controls.Add(this.label22);
            this.tabPageParameter.Controls.Add(this.tbClearFieldFundCostUnit);
            this.tabPageParameter.Controls.Add(this.label20);
            this.tabPageParameter.Controls.Add(this.tbGossipArchitectureCost);
            this.tabPageParameter.Controls.Add(this.label21);
            this.tabPageParameter.Controls.Add(this.tbInstigateArchitectureCost);
            this.tabPageParameter.Controls.Add(this.label19);
            this.tabPageParameter.Controls.Add(this.tbDestroyArchitectureCost);
            this.tabPageParameter.Controls.Add(this.label18);
            this.tabPageParameter.Controls.Add(this.tbSendSpyCost);
            this.tabPageParameter.Controls.Add(this.label17);
            this.tabPageParameter.Controls.Add(this.tbRewardPersonCost);
            this.tabPageParameter.Controls.Add(this.label16);
            this.tabPageParameter.Controls.Add(this.tbConvincePersonCost);
            this.tabPageParameter.Controls.Add(this.label15);
            this.tabPageParameter.Controls.Add(this.tbHireNoFactionPersonCost);
            this.tabPageParameter.Controls.Add(this.label14);
            this.tabPageParameter.Controls.Add(this.tbChangeCapitalCost);
            this.tabPageParameter.Controls.Add(this.label13);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentMorale);
            this.tabPageParameter.Controls.Add(this.label12);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentDomination);
            this.tabPageParameter.Controls.Add(this.label11);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentFundCost);
            this.tabPageParameter.Controls.Add(this.label10);
            this.tabPageParameter.Controls.Add(this.tbInternalFundCost);
            this.tabPageParameter.Controls.Add(this.label9);
            this.tabPageParameter.Controls.Add(this.tbDefaultPopulationDevelopingRate);
            this.tabPageParameter.Controls.Add(this.label8);
            this.tabPageParameter.Controls.Add(this.tbArchitectureDamageRate);
            this.tabPageParameter.Controls.Add(this.label7);
            this.tabPageParameter.Controls.Add(this.tbTroopDamageRate);
            this.tabPageParameter.Controls.Add(this.label6);
            this.tabPageParameter.Controls.Add(this.tbFoodRate);
            this.tabPageParameter.Controls.Add(this.label5);
            this.tabPageParameter.Controls.Add(this.tbFundRate);
            this.tabPageParameter.Controls.Add(this.label4);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentRate);
            this.tabPageParameter.Controls.Add(this.label3);
            this.tabPageParameter.Controls.Add(this.tbTrainingRate);
            this.tabPageParameter.Controls.Add(this.label2);
            this.tabPageParameter.Controls.Add(this.tbInternalRate);
            this.tabPageParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameter.Name = "tabPageParameter";
            this.tabPageParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameter.Size = new System.Drawing.Size(445, 422);
            this.tabPageParameter.TabIndex = 2;
            this.tabPageParameter.Text = "参数";
            this.tabPageParameter.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(194, 388);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(137, 12);
            this.label47.TabIndex = 59;
            this.label47.Text = "统率对部队防御影响参数";
            // 
            // tbLeadershipOffenceRate
            // 
            this.tbLeadershipOffenceRate.Location = new System.Drawing.Point(348, 385);
            this.tbLeadershipOffenceRate.Name = "tbLeadershipOffenceRate";
            this.tbLeadershipOffenceRate.Size = new System.Drawing.Size(71, 22);
            this.tbLeadershipOffenceRate.TabIndex = 58;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(8, 388);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 12);
            this.label46.TabIndex = 57;
            this.label46.Text = "技巧点乘数";
            // 
            // tbTechniquePointMultiple
            // 
            this.tbTechniquePointMultiple.Location = new System.Drawing.Point(102, 385);
            this.tbTechniquePointMultiple.Name = "tbTechniquePointMultiple";
            this.tbTechniquePointMultiple.Size = new System.Drawing.Size(71, 22);
            this.tbTechniquePointMultiple.TabIndex = 56;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 252);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(65, 12);
            this.label40.TabIndex = 55;
            this.label40.Text = "火焰伤害率";
            // 
            // tbFireDamageScale
            // 
            this.tbFireDamageScale.Location = new System.Drawing.Point(102, 249);
            this.tbFireDamageScale.Name = "tbFireDamageScale";
            this.tbFireDamageScale.Size = new System.Drawing.Size(71, 22);
            this.tbFireDamageScale.TabIndex = 54;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(8, 225);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 53;
            this.label33.Text = "围城统治单位";
            // 
            // tbSurroundArchitectureDominationUnit
            // 
            this.tbSurroundArchitectureDominationUnit.Location = new System.Drawing.Point(102, 222);
            this.tbSurroundArchitectureDominationUnit.Name = "tbSurroundArchitectureDominationUnit";
            this.tbSurroundArchitectureDominationUnit.Size = new System.Drawing.Size(71, 22);
            this.tbSurroundArchitectureDominationUnit.TabIndex = 52;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 360);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 12);
            this.label27.TabIndex = 51;
            this.label27.Text = "粮草换资金除数";
            // 
            // tbFoodToFundDivisor
            // 
            this.tbFoodToFundDivisor.Location = new System.Drawing.Point(102, 357);
            this.tbFoodToFundDivisor.Name = "tbFoodToFundDivisor";
            this.tbFoodToFundDivisor.Size = new System.Drawing.Size(71, 22);
            this.tbFoodToFundDivisor.TabIndex = 50;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 333);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 12);
            this.label26.TabIndex = 49;
            this.label26.Text = "资金换粮草乘数";
            // 
            // tbFundToFoodMultiple
            // 
            this.tbFundToFoodMultiple.Location = new System.Drawing.Point(102, 330);
            this.tbFundToFoodMultiple.Name = "tbFundToFoodMultiple";
            this.tbFundToFoodMultiple.Size = new System.Drawing.Size(71, 22);
            this.tbFundToFoodMultiple.TabIndex = 48;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 306);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 12);
            this.label25.TabIndex = 47;
            this.label25.Text = "卖粮所需商业";
            // 
            // tbSellFoodCommerce
            // 
            this.tbSellFoodCommerce.Location = new System.Drawing.Point(102, 303);
            this.tbSellFoodCommerce.Name = "tbSellFoodCommerce";
            this.tbSellFoodCommerce.Size = new System.Drawing.Size(71, 22);
            this.tbSellFoodCommerce.TabIndex = 46;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 279);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 12);
            this.label24.TabIndex = 45;
            this.label24.Text = "买粮所需农业";
            // 
            // tbBuyFoodAgriculture
            // 
            this.tbBuyFoodAgriculture.Location = new System.Drawing.Point(102, 276);
            this.tbBuyFoodAgriculture.Name = "tbBuyFoodAgriculture";
            this.tbBuyFoodAgriculture.Size = new System.Drawing.Size(71, 22);
            this.tbBuyFoodAgriculture.TabIndex = 44;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(254, 360);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 43;
            this.label23.Text = "清野农业单位";
            // 
            // tbClearFieldAgricultureCostUnit
            // 
            this.tbClearFieldAgricultureCostUnit.Location = new System.Drawing.Point(348, 357);
            this.tbClearFieldAgricultureCostUnit.Name = "tbClearFieldAgricultureCostUnit";
            this.tbClearFieldAgricultureCostUnit.Size = new System.Drawing.Size(71, 22);
            this.tbClearFieldAgricultureCostUnit.TabIndex = 42;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(254, 333);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 12);
            this.label22.TabIndex = 41;
            this.label22.Text = "清野资金单位";
            // 
            // tbClearFieldFundCostUnit
            // 
            this.tbClearFieldFundCostUnit.Location = new System.Drawing.Point(348, 330);
            this.tbClearFieldFundCostUnit.Name = "tbClearFieldFundCostUnit";
            this.tbClearFieldFundCostUnit.Size = new System.Drawing.Size(71, 22);
            this.tbClearFieldFundCostUnit.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(254, 306);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 12);
            this.label20.TabIndex = 39;
            this.label20.Text = "流言所需资金";
            // 
            // tbGossipArchitectureCost
            // 
            this.tbGossipArchitectureCost.Location = new System.Drawing.Point(348, 303);
            this.tbGossipArchitectureCost.Name = "tbGossipArchitectureCost";
            this.tbGossipArchitectureCost.Size = new System.Drawing.Size(71, 22);
            this.tbGossipArchitectureCost.TabIndex = 38;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(254, 279);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 37;
            this.label21.Text = "煽动所需资金";
            // 
            // tbInstigateArchitectureCost
            // 
            this.tbInstigateArchitectureCost.Location = new System.Drawing.Point(348, 276);
            this.tbInstigateArchitectureCost.Name = "tbInstigateArchitectureCost";
            this.tbInstigateArchitectureCost.Size = new System.Drawing.Size(71, 22);
            this.tbInstigateArchitectureCost.TabIndex = 36;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(254, 252);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 35;
            this.label19.Text = "破坏所需资金";
            // 
            // tbDestroyArchitectureCost
            // 
            this.tbDestroyArchitectureCost.Location = new System.Drawing.Point(348, 249);
            this.tbDestroyArchitectureCost.Name = "tbDestroyArchitectureCost";
            this.tbDestroyArchitectureCost.Size = new System.Drawing.Size(71, 22);
            this.tbDestroyArchitectureCost.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 225);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 33;
            this.label18.Text = "间谍所需资金";
            // 
            // tbSendSpyCost
            // 
            this.tbSendSpyCost.Location = new System.Drawing.Point(348, 222);
            this.tbSendSpyCost.Name = "tbSendSpyCost";
            this.tbSendSpyCost.Size = new System.Drawing.Size(71, 22);
            this.tbSendSpyCost.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(254, 198);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 31;
            this.label17.Text = "褒奖所需资金";
            // 
            // tbRewardPersonCost
            // 
            this.tbRewardPersonCost.Location = new System.Drawing.Point(348, 195);
            this.tbRewardPersonCost.Name = "tbRewardPersonCost";
            this.tbRewardPersonCost.Size = new System.Drawing.Size(71, 22);
            this.tbRewardPersonCost.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(254, 171);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "说服所需资金";
            // 
            // tbConvincePersonCost
            // 
            this.tbConvincePersonCost.Location = new System.Drawing.Point(348, 168);
            this.tbConvincePersonCost.Name = "tbConvincePersonCost";
            this.tbConvincePersonCost.Size = new System.Drawing.Size(71, 22);
            this.tbConvincePersonCost.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(254, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "录用资金单位";
            // 
            // tbHireNoFactionPersonCost
            // 
            this.tbHireNoFactionPersonCost.Location = new System.Drawing.Point(348, 141);
            this.tbHireNoFactionPersonCost.Name = "tbHireNoFactionPersonCost";
            this.tbHireNoFactionPersonCost.Size = new System.Drawing.Size(71, 22);
            this.tbHireNoFactionPersonCost.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(254, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 25;
            this.label14.Text = "迁都资金单位";
            // 
            // tbChangeCapitalCost
            // 
            this.tbChangeCapitalCost.Location = new System.Drawing.Point(348, 114);
            this.tbChangeCapitalCost.Name = "tbChangeCapitalCost";
            this.tbChangeCapitalCost.Size = new System.Drawing.Size(71, 22);
            this.tbChangeCapitalCost.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(254, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "补充最小民心";
            // 
            // tbRecruitmentMorale
            // 
            this.tbRecruitmentMorale.Location = new System.Drawing.Point(348, 87);
            this.tbRecruitmentMorale.Name = "tbRecruitmentMorale";
            this.tbRecruitmentMorale.Size = new System.Drawing.Size(71, 22);
            this.tbRecruitmentMorale.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(254, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "补充最小统治";
            // 
            // tbRecruitmentDomination
            // 
            this.tbRecruitmentDomination.Location = new System.Drawing.Point(348, 60);
            this.tbRecruitmentDomination.Name = "tbRecruitmentDomination";
            this.tbRecruitmentDomination.Size = new System.Drawing.Size(71, 22);
            this.tbRecruitmentDomination.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "补充资金单位";
            // 
            // tbRecruitmentFundCost
            // 
            this.tbRecruitmentFundCost.Location = new System.Drawing.Point(348, 33);
            this.tbRecruitmentFundCost.Name = "tbRecruitmentFundCost";
            this.tbRecruitmentFundCost.Size = new System.Drawing.Size(71, 22);
            this.tbRecruitmentFundCost.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "内政资金单位";
            // 
            // tbInternalFundCost
            // 
            this.tbInternalFundCost.Location = new System.Drawing.Point(348, 6);
            this.tbInternalFundCost.Name = "tbInternalFundCost";
            this.tbInternalFundCost.Size = new System.Drawing.Size(71, 22);
            this.tbInternalFundCost.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "人口默认增长率";
            // 
            // tbDefaultPopulationDevelopingRate
            // 
            this.tbDefaultPopulationDevelopingRate.Location = new System.Drawing.Point(102, 195);
            this.tbDefaultPopulationDevelopingRate.Name = "tbDefaultPopulationDevelopingRate";
            this.tbDefaultPopulationDevelopingRate.Size = new System.Drawing.Size(71, 22);
            this.tbDefaultPopulationDevelopingRate.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "建筑伤害率";
            // 
            // tbArchitectureDamageRate
            // 
            this.tbArchitectureDamageRate.Location = new System.Drawing.Point(102, 168);
            this.tbArchitectureDamageRate.Name = "tbArchitectureDamageRate";
            this.tbArchitectureDamageRate.Size = new System.Drawing.Size(71, 22);
            this.tbArchitectureDamageRate.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "部队伤害率";
            // 
            // tbTroopDamageRate
            // 
            this.tbTroopDamageRate.Location = new System.Drawing.Point(102, 141);
            this.tbTroopDamageRate.Name = "tbTroopDamageRate";
            this.tbTroopDamageRate.Size = new System.Drawing.Size(71, 22);
            this.tbTroopDamageRate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "粮草收入率";
            // 
            // tbFoodRate
            // 
            this.tbFoodRate.Location = new System.Drawing.Point(102, 114);
            this.tbFoodRate.Name = "tbFoodRate";
            this.tbFoodRate.Size = new System.Drawing.Size(71, 22);
            this.tbFoodRate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "资金收入率";
            // 
            // tbFundRate
            // 
            this.tbFundRate.Location = new System.Drawing.Point(102, 87);
            this.tbFundRate.Name = "tbFundRate";
            this.tbFundRate.Size = new System.Drawing.Size(71, 22);
            this.tbFundRate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "补充速率";
            // 
            // tbRecruitmentRate
            // 
            this.tbRecruitmentRate.Location = new System.Drawing.Point(102, 60);
            this.tbRecruitmentRate.Name = "tbRecruitmentRate";
            this.tbRecruitmentRate.Size = new System.Drawing.Size(71, 22);
            this.tbRecruitmentRate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "训练速率";
            // 
            // tbTrainingRate
            // 
            this.tbTrainingRate.Location = new System.Drawing.Point(102, 33);
            this.tbTrainingRate.Name = "tbTrainingRate";
            this.tbTrainingRate.Size = new System.Drawing.Size(71, 22);
            this.tbTrainingRate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "内政速率";
            // 
            // tbInternalRate
            // 
            this.tbInternalRate.Location = new System.Drawing.Point(102, 6);
            this.tbInternalRate.Name = "tbInternalRate";
            this.tbInternalRate.Size = new System.Drawing.Size(71, 22);
            this.tbInternalRate.TabIndex = 0;
            // 
            // tabPageAIParameter
            // 
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakePlayerCaptiveOnlyUnfull);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakePlayerCaptives);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakeNoFactionPerson);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakeNoFactionCaptives);
            this.tabPageAIParameter.Controls.Add(this.cbAIExecuteBetterOfficer);
            this.tabPageAIParameter.Controls.Add(this.label43);
            this.tabPageAIParameter.Controls.Add(this.tbAIExecutionRate);
            this.tabPageAIParameter.Controls.Add(this.label34);
            this.tabPageAIParameter.Controls.Add(this.tbAITrainingSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.label35);
            this.tabPageAIParameter.Controls.Add(this.tbAIRecruitmentSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.label32);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopDefenceRate);
            this.tabPageAIParameter.Controls.Add(this.label28);
            this.tabPageAIParameter.Controls.Add(this.tbAIArchitectureDamageRate);
            this.tabPageAIParameter.Controls.Add(this.label29);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopOffenceRate);
            this.tabPageAIParameter.Controls.Add(this.label30);
            this.tabPageAIParameter.Controls.Add(this.tbAIFoodRate);
            this.tabPageAIParameter.Controls.Add(this.label31);
            this.tabPageAIParameter.Controls.Add(this.tbAIFundRate);
            this.tabPageAIParameter.Controls.Add(this.cbPinPointAtPlayer);
            this.tabPageAIParameter.Controls.Add(this.cbIgnoreStrategyTendency);
            this.tabPageAIParameter.Controls.Add(this.cbInternalSurplusRateForPlayer);
            this.tabPageAIParameter.Controls.Add(this.cbInternalSurplusRateForAI);
            this.tabPageAIParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageAIParameter.Name = "tabPageAIParameter";
            this.tabPageAIParameter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAIParameter.Size = new System.Drawing.Size(445, 422);
            this.tabPageAIParameter.TabIndex = 3;
            this.tabPageAIParameter.Text = "电脑";
            this.tabPageAIParameter.UseVisualStyleBackColor = true;
            // 
            // cbAIAutoTakePlayerCaptiveOnlyUnfull
            // 
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.AutoSize = true;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Location = new System.Drawing.Point(262, 102);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Name = "cbAIAutoTakePlayerCaptiveOnlyUnfull";
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Size = new System.Drawing.Size(150, 16);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.TabIndex = 48;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Text = "只限忠诚不满100的俘虏";
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.UseVisualStyleBackColor = true;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakePlayerCaptives
            // 
            this.cbAIAutoTakePlayerCaptives.AutoSize = true;
            this.cbAIAutoTakePlayerCaptives.Location = new System.Drawing.Point(244, 72);
            this.cbAIAutoTakePlayerCaptives.Name = "cbAIAutoTakePlayerCaptives";
            this.cbAIAutoTakePlayerCaptives.Size = new System.Drawing.Size(180, 16);
            this.cbAIAutoTakePlayerCaptives.TabIndex = 47;
            this.cbAIAutoTakePlayerCaptives.Text = "电脑必成功说服玩家势力俘虏";
            this.cbAIAutoTakePlayerCaptives.UseVisualStyleBackColor = true;
            this.cbAIAutoTakePlayerCaptives.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakeNoFactionPerson
            // 
            this.cbAIAutoTakeNoFactionPerson.AutoSize = true;
            this.cbAIAutoTakeNoFactionPerson.Location = new System.Drawing.Point(244, 44);
            this.cbAIAutoTakeNoFactionPerson.Name = "cbAIAutoTakeNoFactionPerson";
            this.cbAIAutoTakeNoFactionPerson.Size = new System.Drawing.Size(180, 16);
            this.cbAIAutoTakeNoFactionPerson.TabIndex = 46;
            this.cbAIAutoTakeNoFactionPerson.Text = "电脑必成功说服城中在野武将";
            this.cbAIAutoTakeNoFactionPerson.UseVisualStyleBackColor = true;
            this.cbAIAutoTakeNoFactionPerson.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakeNoFactionCaptives
            // 
            this.cbAIAutoTakeNoFactionCaptives.AutoSize = true;
            this.cbAIAutoTakeNoFactionCaptives.Location = new System.Drawing.Point(244, 17);
            this.cbAIAutoTakeNoFactionCaptives.Name = "cbAIAutoTakeNoFactionCaptives";
            this.cbAIAutoTakeNoFactionCaptives.Size = new System.Drawing.Size(168, 16);
            this.cbAIAutoTakeNoFactionCaptives.TabIndex = 45;
            this.cbAIAutoTakeNoFactionCaptives.Text = "电脑必成功说服没势力俘虏";
            this.cbAIAutoTakeNoFactionCaptives.UseVisualStyleBackColor = true;
            this.cbAIAutoTakeNoFactionCaptives.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIExecuteBetterOfficer
            // 
            this.cbAIExecuteBetterOfficer.AutoSize = true;
            this.cbAIExecuteBetterOfficer.Location = new System.Drawing.Point(10, 335);
            this.cbAIExecuteBetterOfficer.Name = "cbAIExecuteBetterOfficer";
            this.cbAIExecuteBetterOfficer.Size = new System.Drawing.Size(144, 16);
            this.cbAIExecuteBetterOfficer.TabIndex = 44;
            this.cbAIExecuteBetterOfficer.Text = "电脑优先处斩能力高者";
            this.cbAIExecuteBetterOfficer.UseVisualStyleBackColor = true;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 311);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(221, 12);
            this.label43.TabIndex = 43;
            this.label43.Text = "电脑处斩机率（数值越大处斩几率越高）";
            // 
            // tbAIExecutionRate
            // 
            this.tbAIExecutionRate.Location = new System.Drawing.Point(235, 308);
            this.tbAIExecutionRate.Name = "tbAIExecutionRate";
            this.tbAIExecutionRate.Size = new System.Drawing.Size(71, 22);
            this.tbAIExecutionRate.TabIndex = 42;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(8, 154);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(77, 12);
            this.label34.TabIndex = 27;
            this.label34.Text = "电脑训练速度";
            // 
            // tbAITrainingSpeedRate
            // 
            this.tbAITrainingSpeedRate.Location = new System.Drawing.Point(132, 151);
            this.tbAITrainingSpeedRate.Name = "tbAITrainingSpeedRate";
            this.tbAITrainingSpeedRate.Size = new System.Drawing.Size(71, 22);
            this.tbAITrainingSpeedRate.TabIndex = 24;
            this.tbAITrainingSpeedRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(8, 181);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 25;
            this.label35.Text = "电脑征兵速度";
            // 
            // tbAIRecruitmentSpeedRate
            // 
            this.tbAIRecruitmentSpeedRate.Location = new System.Drawing.Point(132, 178);
            this.tbAIRecruitmentSpeedRate.Name = "tbAIRecruitmentSpeedRate";
            this.tbAIRecruitmentSpeedRate.Size = new System.Drawing.Size(71, 22);
            this.tbAIRecruitmentSpeedRate.TabIndex = 26;
            this.tbAIRecruitmentSpeedRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 99);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 12);
            this.label32.TabIndex = 23;
            this.label32.Text = "电脑部队防御力乘数";
            // 
            // tbAITroopDefenceRate
            // 
            this.tbAITroopDefenceRate.Location = new System.Drawing.Point(132, 96);
            this.tbAITroopDefenceRate.Name = "tbAITroopDefenceRate";
            this.tbAITroopDefenceRate.Size = new System.Drawing.Size(71, 22);
            this.tbAITroopDefenceRate.TabIndex = 20;
            this.tbAITroopDefenceRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 126);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 12);
            this.label28.TabIndex = 21;
            this.label28.Text = "电脑建筑伤害率乘数";
            // 
            // tbAIArchitectureDamageRate
            // 
            this.tbAIArchitectureDamageRate.Location = new System.Drawing.Point(132, 123);
            this.tbAIArchitectureDamageRate.Name = "tbAIArchitectureDamageRate";
            this.tbAIArchitectureDamageRate.Size = new System.Drawing.Size(71, 22);
            this.tbAIArchitectureDamageRate.TabIndex = 22;
            this.tbAIArchitectureDamageRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 72);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(113, 12);
            this.label29.TabIndex = 19;
            this.label29.Text = "电脑部队攻击力乘数";
            // 
            // tbAITroopOffenceRate
            // 
            this.tbAITroopOffenceRate.Location = new System.Drawing.Point(132, 69);
            this.tbAITroopOffenceRate.Name = "tbAITroopOffenceRate";
            this.tbAITroopOffenceRate.Size = new System.Drawing.Size(71, 22);
            this.tbAITroopOffenceRate.TabIndex = 18;
            this.tbAITroopOffenceRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 45);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 12);
            this.label30.TabIndex = 17;
            this.label30.Text = "电脑粮草收入率";
            // 
            // tbAIFoodRate
            // 
            this.tbAIFoodRate.Location = new System.Drawing.Point(132, 42);
            this.tbAIFoodRate.Name = "tbAIFoodRate";
            this.tbAIFoodRate.Size = new System.Drawing.Size(71, 22);
            this.tbAIFoodRate.TabIndex = 16;
            this.tbAIFoodRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(89, 12);
            this.label31.TabIndex = 15;
            this.label31.Text = "电脑资金收入率";
            // 
            // tbAIFundRate
            // 
            this.tbAIFundRate.Location = new System.Drawing.Point(132, 15);
            this.tbAIFundRate.Name = "tbAIFundRate";
            this.tbAIFundRate.Size = new System.Drawing.Size(71, 22);
            this.tbAIFundRate.TabIndex = 14;
            this.tbAIFundRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbPinPointAtPlayer
            // 
            this.cbPinPointAtPlayer.AutoSize = true;
            this.cbPinPointAtPlayer.Location = new System.Drawing.Point(8, 205);
            this.cbPinPointAtPlayer.Name = "cbPinPointAtPlayer";
            this.cbPinPointAtPlayer.Size = new System.Drawing.Size(144, 16);
            this.cbPinPointAtPlayer.TabIndex = 40;
            this.cbPinPointAtPlayer.Text = "电脑视玩家为最大敌人";
            this.cbPinPointAtPlayer.UseVisualStyleBackColor = true;
            this.cbPinPointAtPlayer.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbIgnoreStrategyTendency
            // 
            this.cbIgnoreStrategyTendency.AutoSize = true;
            this.cbIgnoreStrategyTendency.Location = new System.Drawing.Point(8, 280);
            this.cbIgnoreStrategyTendency.Name = "cbIgnoreStrategyTendency";
            this.cbIgnoreStrategyTendency.Size = new System.Drawing.Size(156, 16);
            this.cbIgnoreStrategyTendency.TabIndex = 41;
            this.cbIgnoreStrategyTendency.Text = "忽略电脑君主的战略倾向";
            this.cbIgnoreStrategyTendency.UseVisualStyleBackColor = true;
            // 
            // cbInternalSurplusRateForPlayer
            // 
            this.cbInternalSurplusRateForPlayer.AutoSize = true;
            this.cbInternalSurplusRateForPlayer.Location = new System.Drawing.Point(8, 227);
            this.cbInternalSurplusRateForPlayer.Name = "cbInternalSurplusRateForPlayer";
            this.cbInternalSurplusRateForPlayer.Size = new System.Drawing.Size(144, 16);
            this.cbInternalSurplusRateForPlayer.TabIndex = 41;
            this.cbInternalSurplusRateForPlayer.Text = "收入缩减率对玩家有效";
            this.cbInternalSurplusRateForPlayer.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbInternalSurplusRateForAI
            // 
            this.cbInternalSurplusRateForAI.AutoSize = true;
            this.cbInternalSurplusRateForAI.Location = new System.Drawing.Point(8, 249);
            this.cbInternalSurplusRateForAI.Name = "cbInternalSurplusRateForAI";
            this.cbInternalSurplusRateForAI.Size = new System.Drawing.Size(144, 16);
            this.cbInternalSurplusRateForAI.TabIndex = 41;
            this.cbInternalSurplusRateForAI.Text = "收入缩减率对电脑有效";
            this.cbInternalSurplusRateForAI.UseVisualStyleBackColor = true;
            this.cbInternalSurplusRateForAI.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(293, 454);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(374, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(257, 114);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(53, 12);
            this.label48.TabIndex = 107;
            this.label48.Text = "战斗速度";
            // 
            // tbBattleSpeed
            // 
            this.tbBattleSpeed.Location = new System.Drawing.Point(316, 111);
            this.tbBattleSpeed.MaxLength = 2;
            this.tbBattleSpeed.Name = "tbBattleSpeed";
            this.tbBattleSpeed.Size = new System.Drawing.Size(27, 22);
            this.tbBattleSpeed.TabIndex = 108;
            this.tbBattleSpeed.Text = "1";
            // 
            // formOptions
            // 
            this.ClientSize = new System.Drawing.Size(453, 485);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcOptions);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "游戏设置";
            this.tcOptions.ResumeLayout(false);
            this.tabPageEnvironment.ResumeLayout(false);
            this.tabPageEnvironment.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPagePerson.ResumeLayout(false);
            this.tabPagePerson.PerformLayout();
            this.tabPageParameter.ResumeLayout(false);
            this.tabPageParameter.PerformLayout();
            this.tabPageAIParameter.ResumeLayout(false);
            this.tabPageAIParameter.PerformLayout();
            this.ResumeLayout(false);

        }


        private void LoadCommonDoc()
        {
            doNotSetDifficultyToCustom = true;
            this.commonDoc.Load("GameData/GlobalVariables.xml");
            XmlNode nextSibling = this.commonDoc.FirstChild.NextSibling;
            this.cbRunWhileNotFocused.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("RunWhileNotFocused").Value);
            this.cbPlayMusic.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayMusic").Value);
            this.cbPlayNormalSound.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayNormalSound").Value);
            this.cbPlayBattleSound.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayBattleSound").Value);
            this.cbDrawMapVeil.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawMapVeil").Value);
            this.cbDrawTroopAnimation.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawTroopAnimation").Value);
            this.cbSkyEye.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("SkyEye").Value);
            this.cbMultipleResource.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("MultipleResource").Value);
            this.cbSingleSelectionOneClick.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("SingleSelectionOneClick").Value);
            this.cbNoHintOnSmallFacility.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("NoHintOnSmallFacility").Value);
            this.cbHintPopulation.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulation").Value);
            this.cbHintPopulationUnder1000.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulationUnder1000").Value);
            this.cbPopulationRecruitmentLimit.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PopulationRecruitmentLimit").Value);
            this.cbMilitaryKindSpeedValid.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("MilitaryKindSpeedValid").Value);
            this.tbTroopMoveSpeed.Text = nextSibling.Attributes.GetNamedItem("TroopMoveSpeed").Value;
            this.cbCommonPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("CommonPersonAvailable").Value);
            this.cbAdditionalPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AdditionalPersonAvailable").Value);
            this.cbPlayerPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayerPersonAvailable").Value);
            this.cbPersonNaturalDeath.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PersonNaturalDeath").Value);
            this.cbIdealTendencyValid.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("IdealTendencyValid").Value);
            this.cbPinPointAtPlayer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PinPointAtPlayer").Value);
            this.cbIgnoreStrategyTendency.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("IgnoreStrategyTendency").Value);
            this.cbCreateChildren.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildren").Value);
            this.zainanfashengjilv.Text = nextSibling.Attributes.GetNamedItem("zainanfashengjilv").Value;
            this.cbDoAutoSave.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("doAutoSave").Value);
            this.cbCreateChildrenIgnoreLimit.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildrenIgnoreLimit").Value);
            this.cbInternalSurplusRateForPlayer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForPlayer").Value);
            this.cbInternalSurplusRateForAI.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForAI").Value);
            this.tbGetChildrenRate.Text = nextSibling.Attributes.GetNamedItem("getChildrenRate").Value;
            this.tbAIExecutionRate.Text = nextSibling.Attributes.GetNamedItem("AIExecutionRate").Value;
            this.cbAIExecuteBetterOfficer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIExecuteBetterOfficer").Value);
            this.tbMaxExperience.Text = nextSibling.Attributes.GetNamedItem("maxExperience").Value;
            this.cbLockChildrenLoyalty.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("lockChildrenLoyalty").Value);
            this.cbAIAutoTakeNoFactionCaptives.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionCaptives").Value);
            this.cbAIAutoTakeNoFactionPerson.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionPerson").Value);
            this.cbAIAutoTakePlayerCaptives.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptives").Value);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptiveOnlyUnfull").Value);
            this.tbDialogShowTime.Text = nextSibling.Attributes.GetNamedItem("DialogShowTime").Value;
            this.tbTechniquePointMultiple.Text = nextSibling.Attributes.GetNamedItem("TechniquePointMultiple").Value;
            this.cbPermitFactionMerge.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PermitFactionMerge").Value);
            this.tbLeadershipOffenceRate.Text = nextSibling.Attributes.GetNamedItem("LeadershipOffenceRate").Value;
            doNotSetDifficultyToCustom = false;
            this.changeDifficultySelection((Difficulty) Enum.Parse(typeof(Difficulty), nextSibling.Attributes.GetNamedItem("GameDifficulty").Value));
            this.checkLiangdaoXitong.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("LiangdaoXitong").Value);
            this.wujiangYoukenengDuli.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("WujiangYoukenengDuli").Value);
            this.tbBattleSpeed.Text = nextSibling.Attributes.GetNamedItem("FastBattleSpeed").Value;
        }

        private void LoadParameterDoc()
        {
            doNotSetDifficultyToCustom = true;
            this.parameterDoc.Load("GameData/GameParameters.xml");
            XmlNode nextSibling = this.parameterDoc.FirstChild.NextSibling;
            this.tbFindTreasureChance.Text = nextSibling.Attributes.GetNamedItem("FindTreasureChance").Value;
            this.tbLearnSkillDays.Text = nextSibling.Attributes.GetNamedItem("LearnSkillDays").Value;
            this.tbLearnStuntDays.Text = nextSibling.Attributes.GetNamedItem("LearnStuntDays").Value;
            this.tbLearnTitleDays.Text = nextSibling.Attributes.GetNamedItem("LearnTitleDays").Value;
            this.tbFollowedLeaderOffenceRateIncrement.Text = nextSibling.Attributes.GetNamedItem("FollowedLeaderOffenceRateIncrement").Value;
            this.tbFollowedLeaderDefenceRateIncrement.Text = nextSibling.Attributes.GetNamedItem("FollowedLeaderDefenceRateIncrement").Value;
            this.tbInternalRate.Text = nextSibling.Attributes.GetNamedItem("InternalRate").Value;
            this.tbTrainingRate.Text = nextSibling.Attributes.GetNamedItem("TrainingRate").Value;
            this.tbRecruitmentRate.Text = nextSibling.Attributes.GetNamedItem("RecruitmentRate").Value;
            this.tbFundRate.Text = nextSibling.Attributes.GetNamedItem("FundRate").Value;
            this.tbFoodRate.Text = nextSibling.Attributes.GetNamedItem("FoodRate").Value;
            this.tbTroopDamageRate.Text = nextSibling.Attributes.GetNamedItem("TroopDamageRate").Value;
            this.tbArchitectureDamageRate.Text = nextSibling.Attributes.GetNamedItem("ArchitectureDamageRate").Value;
            this.tbDefaultPopulationDevelopingRate.Text = nextSibling.Attributes.GetNamedItem("DefaultPopulationDevelopingRate").Value;
            this.tbSurroundArchitectureDominationUnit.Text = nextSibling.Attributes.GetNamedItem("SurroundArchitectureDominationUnit").Value;
            this.tbFireDamageScale.Text = nextSibling.Attributes.GetNamedItem("FireDamageScale").Value;
            this.tbBuyFoodAgriculture.Text = nextSibling.Attributes.GetNamedItem("BuyFoodAgriculture").Value;
            this.tbSellFoodCommerce.Text = nextSibling.Attributes.GetNamedItem("SellFoodCommerce").Value;
            this.tbFundToFoodMultiple.Text = nextSibling.Attributes.GetNamedItem("FundToFoodMultiple").Value;
            this.tbFoodToFundDivisor.Text = nextSibling.Attributes.GetNamedItem("FoodToFundDivisor").Value;
            this.tbInternalFundCost.Text = nextSibling.Attributes.GetNamedItem("InternalFundCost").Value;
            this.tbRecruitmentFundCost.Text = nextSibling.Attributes.GetNamedItem("RecruitmentFundCost").Value;
            this.tbRecruitmentDomination.Text = nextSibling.Attributes.GetNamedItem("RecruitmentDomination").Value;
            this.tbRecruitmentMorale.Text = nextSibling.Attributes.GetNamedItem("RecruitmentMorale").Value;
            this.tbChangeCapitalCost.Text = nextSibling.Attributes.GetNamedItem("ChangeCapitalCost").Value;
            this.tbHireNoFactionPersonCost.Text = nextSibling.Attributes.GetNamedItem("HireNoFactionPersonCost").Value;
            this.tbConvincePersonCost.Text = nextSibling.Attributes.GetNamedItem("ConvincePersonCost").Value;
            this.tbRewardPersonCost.Text = nextSibling.Attributes.GetNamedItem("RewardPersonCost").Value;
            this.tbSendSpyCost.Text = nextSibling.Attributes.GetNamedItem("SendSpyCost").Value;
            this.tbDestroyArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("DestroyArchitectureCost").Value;
            this.tbInstigateArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("InstigateArchitectureCost").Value;
            this.tbGossipArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("GossipArchitectureCost").Value;
            this.tbClearFieldFundCostUnit.Text = nextSibling.Attributes.GetNamedItem("ClearFieldFundCostUnit").Value;
            this.tbClearFieldAgricultureCostUnit.Text = nextSibling.Attributes.GetNamedItem("ClearFieldAgricultureCostUnit").Value;
            this.tbAIFundRate.Text = nextSibling.Attributes.GetNamedItem("AIFundRate").Value;
            this.tbAIFoodRate.Text = nextSibling.Attributes.GetNamedItem("AIFoodRate").Value;
            this.tbAITroopOffenceRate.Text = nextSibling.Attributes.GetNamedItem("AITroopOffenceRate").Value;
            this.tbAITroopDefenceRate.Text = nextSibling.Attributes.GetNamedItem("AITroopDefenceRate").Value;
            this.tbAIArchitectureDamageRate.Text = nextSibling.Attributes.GetNamedItem("AIArchitectureDamageRate").Value;
            this.tbAITrainingSpeedRate.Text = nextSibling.Attributes.GetNamedItem("AITrainingSpeedRate").Value;
            this.tbAIRecruitmentSpeedRate.Text = nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedRate").Value;
            doNotSetDifficultyToCustom = false;
        }

        private void SaveCommonDoc()
        {
            XmlNode nextSibling = this.commonDoc.FirstChild.NextSibling;
            nextSibling.Attributes.GetNamedItem("RunWhileNotFocused").Value = this.cbRunWhileNotFocused.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayMusic").Value = this.cbPlayMusic.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayNormalSound").Value = this.cbPlayNormalSound.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayBattleSound").Value = this.cbPlayBattleSound.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("DrawMapVeil").Value = this.cbDrawMapVeil.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("DrawTroopAnimation").Value = this.cbDrawTroopAnimation.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("SkyEye").Value = this.cbSkyEye.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("MultipleResource").Value = this.cbMultipleResource.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("SingleSelectionOneClick").Value = this.cbSingleSelectionOneClick.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("NoHintOnSmallFacility").Value = this.cbNoHintOnSmallFacility.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("HintPopulation").Value = this.cbHintPopulation.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("HintPopulationUnder1000").Value = this.cbHintPopulationUnder1000.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PopulationRecruitmentLimit").Value = this.cbPopulationRecruitmentLimit.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("MilitaryKindSpeedValid").Value = this.cbMilitaryKindSpeedValid.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("TroopMoveSpeed").Value = this.tbTroopMoveSpeed.Text;
            nextSibling.Attributes.GetNamedItem("CommonPersonAvailable").Value = this.cbCommonPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AdditionalPersonAvailable").Value = this.cbAdditionalPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayerPersonAvailable").Value = this.cbPlayerPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PersonNaturalDeath").Value = this.cbPersonNaturalDeath.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("IdealTendencyValid").Value = this.cbIdealTendencyValid.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PinPointAtPlayer").Value = this.cbPinPointAtPlayer.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("IgnoreStrategyTendency").Value = this.cbIgnoreStrategyTendency.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("createChildren").Value = this.cbCreateChildren.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("zainanfashengjilv").Value = this.zainanfashengjilv.Text;
            nextSibling.Attributes.GetNamedItem("doAutoSave").Value = this.cbDoAutoSave.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("createChildrenIgnoreLimit").Value = this.cbCreateChildrenIgnoreLimit.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("internalSurplusRateForPlayer").Value = this.cbInternalSurplusRateForPlayer.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("internalSurplusRateForAI").Value = this.cbInternalSurplusRateForAI.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("getChildrenRate").Value = this.tbGetChildrenRate.Text;
            nextSibling.Attributes.GetNamedItem("AIExecutionRate").Value = this.tbAIExecutionRate.Text;
            nextSibling.Attributes.GetNamedItem("AIExecuteBetterOfficer").Value = this.cbAIExecuteBetterOfficer.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("maxExperience").Value = this.tbMaxExperience.Text;
            nextSibling.Attributes.GetNamedItem("lockChildrenLoyalty").Value = this.cbLockChildrenLoyalty.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionCaptives").Value = this.cbAIAutoTakeNoFactionCaptives.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionPerson").Value = this.cbAIAutoTakeNoFactionPerson.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptives").Value = this.cbAIAutoTakePlayerCaptives.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptiveOnlyUnfull").Value = this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("DialogShowTime").Value = this.tbDialogShowTime.Text;
            nextSibling.Attributes.GetNamedItem("TechniquePointMultiple").Value = this.tbTechniquePointMultiple.Text;
            nextSibling.Attributes.GetNamedItem("PermitFactionMerge").Value = this.cbPermitFactionMerge.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("GameDifficulty").Value = this.getDifficultyFromRadio.ToString();
            nextSibling.Attributes.GetNamedItem("LeadershipOffenceRate").Value = this.tbLeadershipOffenceRate.Text;
            nextSibling.Attributes.GetNamedItem("LiangdaoXitong").Value = this.checkLiangdaoXitong.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("WujiangYoukenengDuli").Value = this.wujiangYoukenengDuli.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("FastBattleSpeed").Value = this.tbBattleSpeed.Text;
            this.commonDoc.Save("GameData/GlobalVariables.xml");
        }

        private void SaveParameterDoc()
        {
            XmlNode nextSibling = this.parameterDoc.FirstChild.NextSibling;
            nextSibling.Attributes.GetNamedItem("FindTreasureChance").Value = this.tbFindTreasureChance.Text;
            nextSibling.Attributes.GetNamedItem("LearnSkillDays").Value = this.tbLearnSkillDays.Text;
            nextSibling.Attributes.GetNamedItem("LearnStuntDays").Value = this.tbLearnStuntDays.Text;
            nextSibling.Attributes.GetNamedItem("LearnTitleDays").Value = this.tbLearnTitleDays.Text;
            nextSibling.Attributes.GetNamedItem("FollowedLeaderOffenceRateIncrement").Value = this.tbFollowedLeaderOffenceRateIncrement.Text;
            nextSibling.Attributes.GetNamedItem("FollowedLeaderDefenceRateIncrement").Value = this.tbFollowedLeaderDefenceRateIncrement.Text;
            nextSibling.Attributes.GetNamedItem("InternalRate").Value = this.tbInternalRate.Text;
            nextSibling.Attributes.GetNamedItem("TrainingRate").Value = this.tbTrainingRate.Text;
            nextSibling.Attributes.GetNamedItem("RecruitmentRate").Value = this.tbRecruitmentRate.Text;
            nextSibling.Attributes.GetNamedItem("FundRate").Value = this.tbFundRate.Text;
            nextSibling.Attributes.GetNamedItem("FoodRate").Value = this.tbFoodRate.Text;
            nextSibling.Attributes.GetNamedItem("TroopDamageRate").Value = this.tbTroopDamageRate.Text;
            nextSibling.Attributes.GetNamedItem("ArchitectureDamageRate").Value = this.tbArchitectureDamageRate.Text;
            nextSibling.Attributes.GetNamedItem("DefaultPopulationDevelopingRate").Value = this.tbDefaultPopulationDevelopingRate.Text;
            nextSibling.Attributes.GetNamedItem("SurroundArchitectureDominationUnit").Value = this.tbSurroundArchitectureDominationUnit.Text;
            nextSibling.Attributes.GetNamedItem("FireDamageScale").Value = this.tbFireDamageScale.Text;
            nextSibling.Attributes.GetNamedItem("BuyFoodAgriculture").Value = this.tbBuyFoodAgriculture.Text;
            nextSibling.Attributes.GetNamedItem("SellFoodCommerce").Value = this.tbSellFoodCommerce.Text;
            nextSibling.Attributes.GetNamedItem("FundToFoodMultiple").Value = this.tbFundToFoodMultiple.Text;
            nextSibling.Attributes.GetNamedItem("FoodToFundDivisor").Value = this.tbFoodToFundDivisor.Text;
            nextSibling.Attributes.GetNamedItem("InternalFundCost").Value = this.tbInternalFundCost.Text;
            nextSibling.Attributes.GetNamedItem("RecruitmentFundCost").Value = this.tbRecruitmentFundCost.Text;
            nextSibling.Attributes.GetNamedItem("RecruitmentDomination").Value = this.tbRecruitmentDomination.Text;
            nextSibling.Attributes.GetNamedItem("RecruitmentMorale").Value = this.tbRecruitmentMorale.Text;
            nextSibling.Attributes.GetNamedItem("ChangeCapitalCost").Value = this.tbChangeCapitalCost.Text;
            nextSibling.Attributes.GetNamedItem("HireNoFactionPersonCost").Value = this.tbHireNoFactionPersonCost.Text;
            nextSibling.Attributes.GetNamedItem("ConvincePersonCost").Value = this.tbConvincePersonCost.Text;
            nextSibling.Attributes.GetNamedItem("RewardPersonCost").Value = this.tbRewardPersonCost.Text;
            nextSibling.Attributes.GetNamedItem("SendSpyCost").Value = this.tbSendSpyCost.Text;
            nextSibling.Attributes.GetNamedItem("DestroyArchitectureCost").Value = this.tbDestroyArchitectureCost.Text;
            nextSibling.Attributes.GetNamedItem("InstigateArchitectureCost").Value = this.tbInstigateArchitectureCost.Text;
            nextSibling.Attributes.GetNamedItem("GossipArchitectureCost").Value = this.tbGossipArchitectureCost.Text;
            nextSibling.Attributes.GetNamedItem("ClearFieldFundCostUnit").Value = this.tbClearFieldFundCostUnit.Text;
            nextSibling.Attributes.GetNamedItem("ClearFieldAgricultureCostUnit").Value = this.tbClearFieldAgricultureCostUnit.Text;
            nextSibling.Attributes.GetNamedItem("AIFundRate").Value = this.tbAIFundRate.Text;
            nextSibling.Attributes.GetNamedItem("AIFoodRate").Value = this.tbAIFoodRate.Text;
            nextSibling.Attributes.GetNamedItem("AITroopOffenceRate").Value = this.tbAITroopOffenceRate.Text;
            nextSibling.Attributes.GetNamedItem("AITroopDefenceRate").Value = this.tbAITroopDefenceRate.Text;
            nextSibling.Attributes.GetNamedItem("AIArchitectureDamageRate").Value = this.tbAIArchitectureDamageRate.Text;
            nextSibling.Attributes.GetNamedItem("AITrainingSpeedRate").Value = this.tbAITrainingSpeedRate.Text;
            nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedRate").Value = this.tbAIRecruitmentSpeedRate.Text;
            this.parameterDoc.Save("GameData/GameParameters.xml");
        }


        private Difficulty getDifficultyFromRadio
        {
            get
            {
                if (this.rbBeginner.Checked)
                {
                    return Difficulty.beginner;
                }
                else if (this.rbEasy.Checked)
                {
                    return Difficulty.easy;
                }
                else if (this.rbNormal.Checked)
                {
                    return Difficulty.normal;
                }
                else if (this.rbHard.Checked)
                {
                    return Difficulty.hard;
                }
                else if (this.rbVeryhard.Checked)
                {
                    return Difficulty.veryhard;
                }
                else if (this.rbCustom.Checked)
                {
                    return Difficulty.custom;
                }
                return Difficulty.custom;
            }
        }

        private void changeDifficultySelection(Difficulty d)
        {
            this.rbBeginner.Checked = false;
            this.rbEasy.Checked = false;
            this.rbNormal.Checked = false;
            this.rbHard.Checked = false;
            this.rbVeryhard.Checked = false;
            this.rbCustom.Checked = false;
            switch (d)
            {
                case Difficulty.beginner: this.rbBeginner.Checked = true; break;
                case Difficulty.easy: this.rbEasy.Checked = true; break;
                case Difficulty.normal: this.rbNormal.Checked = true; break;
                case Difficulty.hard: this.rbHard.Checked = true; break;
                case Difficulty.veryhard: this.rbVeryhard.Checked = true; break;
                case Difficulty.custom: this.rbCustom.Checked = true; break;
                default: this.rbCustom.Checked = true; break;
            }
        }

        private void beginnerSelected(object sender, EventArgs e)
        {
            if (rbBeginner.Checked)
            {
                this.setDifficultyParameters(Difficulty.beginner);
            }
        }

        private void easySelected(object sender, EventArgs e)
        {
            if (rbEasy.Checked)
            {
                this.setDifficultyParameters(Difficulty.easy);
            }
        }

        private void normalSelected(object sender, EventArgs e)
        {
            if (rbNormal.Checked)
            {
                this.setDifficultyParameters(Difficulty.normal);
            }
        }

        private void hardSelected(object sender, EventArgs e)
        {
            if (rbHard.Checked)
            {
                this.setDifficultyParameters(Difficulty.hard);
            }
        }

        private void veryhardSelected(object sender, EventArgs e)
        {
            if (rbVeryhard.Checked)
            {
                this.setDifficultyParameters(Difficulty.veryhard);
            }
        }

        private void setDifficultyParameters(Difficulty d)
        {
            doNotSetDifficultyToCustom = true;
            switch (d)
            {
                case Difficulty.beginner:
                    this.tbAIFundRate.Text = "0.7";
                    this.tbAIFoodRate.Text = "0.7";
                    this.tbAIArchitectureDamageRate.Text = "0.7";
                    this.tbAITroopOffenceRate.Text = "0.7";
                    this.tbAITroopDefenceRate.Text = "0.7";
                    this.tbAIRecruitmentSpeedRate.Text = "0.7";
                    this.tbAITrainingSpeedRate.Text = "0.7";
                    this.cbPinPointAtPlayer.Checked = false;
                    this.cbInternalSurplusRateForPlayer.Checked = false;
                    this.cbInternalSurplusRateForAI.Checked = true;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    break;
                case Difficulty.easy:
                    this.tbAIFundRate.Text = "1.0";
                    this.tbAIFoodRate.Text = "1.0";
                    this.tbAIArchitectureDamageRate.Text = "1.0";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.0";
                    this.tbAIRecruitmentSpeedRate.Text = "1.0";
                    this.tbAITrainingSpeedRate.Text = "1.0";
                    this.cbPinPointAtPlayer.Checked = false;
                    this.cbInternalSurplusRateForPlayer.Checked = false;
                    this.cbInternalSurplusRateForAI.Checked = false;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    break;
                case Difficulty.normal:
                    this.tbAIFundRate.Text = "1.5";
                    this.tbAIFoodRate.Text = "1.5";
                    this.tbAIArchitectureDamageRate.Text = "1.0";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.0";
                    this.tbAIRecruitmentSpeedRate.Text = "1.2";
                    this.tbAITrainingSpeedRate.Text = "1.2";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = false;
                    this.cbInternalSurplusRateForAI.Checked = false;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    break;
                case Difficulty.hard:
                    this.tbAIFundRate.Text = "2.0";
                    this.tbAIFoodRate.Text = "2.0";
                    this.tbAIArchitectureDamageRate.Text = "1.0";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.0";
                    this.tbAIRecruitmentSpeedRate.Text = "1.5";
                    this.tbAITrainingSpeedRate.Text = "1.5";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = false;
                    this.cbInternalSurplusRateForAI.Checked = false;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = true;
                    this.cbAIAutoTakeNoFactionPerson.Checked = true;
                    this.cbAIAutoTakePlayerCaptives.Checked = true;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = true;
                    break;
                case Difficulty.veryhard:
                    this.tbAIFundRate.Text = "5.0";
                    this.tbAIFoodRate.Text = "5.0";
                    this.tbAIArchitectureDamageRate.Text = "1.2";
                    this.tbAITroopOffenceRate.Text = "1.2";
                    this.tbAITroopDefenceRate.Text = "1.2";
                    this.tbAIRecruitmentSpeedRate.Text = "2.0";
                    this.tbAITrainingSpeedRate.Text = "2.0";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = true;
                    this.cbInternalSurplusRateForAI.Checked = false;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = true;
                    this.cbAIAutoTakeNoFactionPerson.Checked = true;
                    this.cbAIAutoTakePlayerCaptives.Checked = true;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    break;
            }
            doNotSetDifficultyToCustom = false;
        }

        private bool doNotSetDifficultyToCustom = false;
        private void setDifficultyToCustom(object sender, EventArgs e)
        {
            if (!doNotSetDifficultyToCustom)
            {
                changeDifficultySelection(Difficulty.custom);
            }
        }

        private void tabPageEnvironment_Click(object sender, EventArgs e)
        {

        }

        private void checkLiangdaoXitong_CheckedChanged(object sender, EventArgs e)
        {

        }

    }

 

}
