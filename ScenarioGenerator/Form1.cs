using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using GameGlobal;
using GameObjects;
using GameObjects.PersonDetail;

namespace ScenarioGenerator
{
    public partial class Form1 : Form
    {
        private GameScenario scen = new GameScenario(null);
        private String openedFileName;
        private String commonDataFileName;
        private OleDbConnectionStringBuilder connectionStringBuilder;

        public Form1()
        {
            InitializeComponent();

            this.connectionStringBuilder = new OleDbConnectionStringBuilder();
            this.connectionStringBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            this.commonDataFileName = Application.StartupPath + "/GameData/Common/CommonData.mdb";
            this.connectionStringBuilder.DataSource = this.commonDataFileName;
            new GlobalVariables().InitialGlobalVariables();
            new Parameters().InitializeGameParameters();
            this.scen.GameCommonData.LoadFromDatabase(this.connectionStringBuilder.ConnectionString, this.scen);
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            this.openScenFileDialog.InitialDirectory = ".";
            if (this.openScenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblFilename.Text = "正讀取劇本檔案......";

                this.connectionStringBuilder.DataSource = this.openScenFileDialog.FileName;
                this.openedFileName = this.openScenFileDialog.FileName;
                this.scen.LoadGameScenarioFromDatabase(this.connectionStringBuilder.ConnectionString);

                updateUIByScenario();

                btnGenerate.Enabled = true;
            }
        }

        private void updateUIByScenario()
        {
            lblFilename.Text = this.scen.ScenarioTitle;

            PersonGeneratorSetting setting = ((PersonGeneratorSetting)this.scen.GameCommonData.PersonGeneratorSetting);

            tbFemaleChance.Text = setting.femaleChance.ToString();
            tbBornYearLo.Text = setting.bornLo.ToString();
            tbBornYearHi.Text = setting.bornHi.ToString();
            tbDebutAgeLo.Text = setting.debutLo.ToString();
            tbDebutAgeHi.Text = setting.debutHi.ToString();
            tbAgeLo.Text = setting.dieLo.ToString();
            tbAgeHi.Text = setting.dieHi.ToString();

            List<GameObject> types = this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects;

            lblPersonType0.Text = ((PersonGeneratorType)types[0]).Name;
            lblPersonType1.Text = ((PersonGeneratorType)types[1]).Name;
            lblPersonType2.Text = ((PersonGeneratorType)types[2]).Name;
            lblPersonType3.Text = ((PersonGeneratorType)types[3]).Name;
            lblPersonType4.Text = ((PersonGeneratorType)types[4]).Name;
            lblPersonType5.Text = ((PersonGeneratorType)types[5]).Name;
            lblPersonType6.Text = ((PersonGeneratorType)types[6]).Name;
            lblPersonType7.Text = ((PersonGeneratorType)types[7]).Name;
            lblPersonType8.Text = ((PersonGeneratorType)types[8]).Name;
            lblPersonType9.Text = ((PersonGeneratorType)types[9]).Name;

            tbPersonType0.Text = ((PersonGeneratorType)types[0]).generationChance.ToString();
            tbPersonType1.Text = ((PersonGeneratorType)types[1]).generationChance.ToString();
            tbPersonType2.Text = ((PersonGeneratorType)types[2]).generationChance.ToString();
            tbPersonType3.Text = ((PersonGeneratorType)types[3]).generationChance.ToString();
            tbPersonType4.Text = ((PersonGeneratorType)types[4]).generationChance.ToString();
            tbPersonType5.Text = ((PersonGeneratorType)types[5]).generationChance.ToString();
            tbPersonType6.Text = ((PersonGeneratorType)types[6]).generationChance.ToString();
            tbPersonType7.Text = ((PersonGeneratorType)types[7]).generationChance.ToString();
            tbPersonType8.Text = ((PersonGeneratorType)types[8]).generationChance.ToString();
            tbPersonType9.Text = ((PersonGeneratorType)types[9]).generationChance.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblFilename.Text = "正生成劇本...";

            generateScenario();

            lblFilename.Text = "正保存劇本...";

            String date = DateTime.Now.ToString("yyyy-MM-dd");
            this.scen.ScenarioTitle += "﹝生成於" + date + "﹞";

            String generatedFileName = this.openedFileName.Substring(0, this.openedFileName.Length - 4) + "-" + date + ".mdb";

            File.Copy(Application.StartupPath + "/GameData/Common/SaveTemplate.mdb", generatedFileName);

            this.connectionStringBuilder.DataSource = generatedFileName;
            this.scen.SaveGameScenarioToDatabase(this.connectionStringBuilder.ConnectionString, true, true);

            MessageBox.Show("劇本已生成，檔案為" + generatedFileName);

            lblFilename.Text = this.openedFileName;
        }

        private void generateScenario()
        {
            try
            {
                deletePerson();
                deleteArchitecture();

                generatePerson();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("無效輸入：" + ex.Message);
            }
        }

        private void deleteArchitecture()
        {
            int toDeleteCnt = GameObject.Random(int.Parse(tbDeleteArchitectureLo.Text), int.Parse(tbDeleteArchitectureHi.Text));
            int toDeletePopulationLo = int.Parse(tbDeleteArchitecturePopulationLo.Text);
            int toDeletePopulationHi = int.Parse(tbDeleteArchitecturePopulationHi.Text);

            if (toDeleteCnt == 0) return;

            ArchitectureList candidates = new ArchitectureList();
            foreach (Architecture a in this.scen.Architectures)
            {
                if (a.PopulationCeiling >= toDeletePopulationLo && a.PopulationCeiling <= toDeletePopulationHi)
                {
                    candidates.Add(a);
                }
            }

            GameObjectList toDelete = candidates.GetRandomList();
            GameObjectList list = this.scen.Architectures.GetList();
            int deleted = 0;
            foreach (Architecture a in list)
            {
                if (toDelete.GameObjects.Contains(a))
                {
                    if (a.BelongedFaction != null)
                    {
                        Architecture moveTo = a.BelongedFaction.Capital;
                        if (a == moveTo) continue;
                        foreach (Person p in a.Persons)
                        {
                            p.MoveToArchitecture(a);
                            p.ArrivingDays = 0;
                        }
                    }
                    this.scen.Architectures.Remove(a);
                    deleted++;
                    if (toDeleteCnt <= deleted) break;

                    this.scen.ClearPersonStatusCache();
                }
            }

            this.scen.ClearPersonStatusCache();

            foreach (Architecture architecture2 in this.scen.Architectures)
            {
                architecture2.AILandLinks.Clear();
                architecture2.AIWaterLinks.Clear();
            }
            foreach (Architecture architecture2 in this.scen.Architectures)
            {
                architecture2.FindLinks(this.scen.Architectures);
            }
        }

        private void deletePerson()
        {
            int toDeleteCnt = GameObject.Random(int.Parse(tbDeletePersonLo.Text), int.Parse(tbDeletePersonHi.Text));
            int toDeleteAbyLo = int.Parse(tbDeletePersonAbyLo.Text);
            int toDeleteAbyHi = int.Parse(tbDeletePersonAbyHi.Text);
            int toDeleteTotalAbyLo = int.Parse(tbDeletePersonTAbyLo.Text);
            int toDeleteTotalAbyHi = int.Parse(tbDeletePersonTAbyHi.Text);

            if (toDeleteCnt == 0) return;

            bool allowDeleteKing = cbDeleteLeader.Checked;

            PersonList candidates = new PersonList();
            foreach (Person p in this.scen.Persons)
            {
                if (p.BelongedFaction != null && p.BelongedFaction.Leader == p) continue;
                if (p.Command <= toDeleteAbyHi && p.Strength <= toDeleteAbyHi && p.Intelligence <= toDeleteAbyHi && p.Politics <= toDeleteAbyHi && p.Glamour <= toDeleteAbyHi &&
                    p.Command >= toDeleteAbyLo && p.Strength >= toDeleteAbyLo && p.Intelligence >= toDeleteAbyLo && p.Politics >= toDeleteAbyLo && p.Glamour >= toDeleteAbyLo)
                {
                    candidates.Add(p);
                }
                if (p.Strength + p.Command + p.Intelligence + p.Politics + p.Glamour <= toDeleteTotalAbyHi &&
                    p.Strength + p.Command + p.Intelligence + p.Politics + p.Glamour >= toDeleteTotalAbyLo)
                {
                    candidates.Add(p);
                }
            }

            GameObjectList toDelete = candidates.GetRandomList();
            GameObjectList list = this.scen.Persons.GetList();
            int deleted = 0;
            foreach (Person p in list)
            {
                if (p.BelongedFaction != null && p.BelongedFaction.PersonCount > 1)
                {
                    if (toDelete.GameObjects.Contains(p))
                    {
                        this.scen.Persons.Remove(p);
                        deleted++;
                        if (toDeleteCnt <= deleted) break;
                    }
                }
            }

            this.scen.ClearPersonStatusCache();
        }

        private void generatePerson()
        {
            this.scen.GameCommonData.PersonGeneratorSetting.bornLo = int.Parse(tbBornYearLo.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.bornHi = int.Parse(tbBornYearHi.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.debutLo = int.Parse(tbDebutAgeLo.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.debutHi = int.Parse(tbDebutAgeHi.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.dieLo = int.Parse(tbAgeLo.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.dieHi = int.Parse(tbAgeHi.Text);
            this.scen.GameCommonData.PersonGeneratorSetting.debutAtLeast = int.Parse(tbDebutAtLeast.Text);

            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[0]).generationChance = int.Parse(tbPersonType0.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[1]).generationChance = int.Parse(tbPersonType1.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[2]).generationChance = int.Parse(tbPersonType2.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[3]).generationChance = int.Parse(tbPersonType3.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[4]).generationChance = int.Parse(tbPersonType4.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[5]).generationChance = int.Parse(tbPersonType5.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[6]).generationChance = int.Parse(tbPersonType6.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[7]).generationChance = int.Parse(tbPersonType7.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[8]).generationChance = int.Parse(tbPersonType8.Text);
            ((PersonGeneratorType)this.scen.GameCommonData.AllPersonGeneratorTypes.GameObjects[9]).generationChance = int.Parse(tbPersonType9.Text);

            int count = GameObject.Random(int.Parse(tbAddPersonLo.Text), int.Parse(tbAddPersonHi.Text));

            int joinChance = int.Parse(tbJoinedFactionChance.Text);
            for (int i = 0; i < count; ++i)
            {
                bool joined = GameObject.Chance(joinChance);

                Architecture location = null;
                if (joined)
                {
                    ArchitectureList candidates = new ArchitectureList();
                    foreach (Architecture j in scen.Architectures)
                    {
                        if (j.BelongedFaction != null)
                        {
                            candidates.Add(j);
                        }
                    }
                    if (candidates.Count > 0)
                    {
                        location = (Architecture)candidates.GetRandomObject();
                    }
                    else
                    {
                        joined = false;
                    }
                }

                if (!joined)
                {
                    location = (Architecture)scen.Architectures.GetRandomObject();
                }

                Person p = Person.createPerson(scen, location, null, false);
                if (joined && location.BelongedFaction != null)
                {
                    p.ChangeFaction(location.BelongedFaction);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
