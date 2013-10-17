namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.ArchitectureDetail;
    using GameObjects.Conditions;
    using GameObjects.FactionDetail;
    using GameObjects.Influences;
    using GameObjects.MapDetail;
    using GameObjects.PersonDetail;
    using GameObjects.SectionDetail;
    using GameObjects.TroopDetail;
    using GameObjects.TroopDetail.EventEffect;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;
    using System.Reflection;
    using System.Data;
    using System.Data.OleDb;

    public class CommonData
    {
        public ArchitectureKindTable AllArchitectureKinds = new ArchitectureKindTable();
        public AttackDefaultKindList AllAttackDefaultKinds = new AttackDefaultKindList();
        public AttackTargetKindList AllAttackTargetKinds = new AttackTargetKindList();
        public BiographyTable AllBiographies = new BiographyTable();
        public CastDefaultKindList AllCastDefaultKinds = new CastDefaultKindList();
        public CastTargetKindList AllCastTargetKinds = new CastTargetKindList();
        public List<CharacterKind> AllCharacterKinds = new List<CharacterKind>();
        public List<Color> AllColors = new List<Color>();
        public CombatMethodTable AllCombatMethods = new CombatMethodTable();
        public ConditionKindTable AllConditionKinds = new ConditionKindTable();
        public ConditionTable AllConditions = new ConditionTable();
        public FacilityKindTable AllFacilityKinds = new FacilityKindTable();
        public zainanzhongleibiao suoyouzainanzhonglei = new zainanzhongleibiao();
        public guanjuezhongleibiao suoyouguanjuezhonglei = new guanjuezhongleibiao();
        public GameObjectList AllIdealTendencyKinds = new GameObjectList();
        public InfluenceKindTable AllInfluenceKinds = new InfluenceKindTable();
        public InfluenceTable AllInfluences = new InfluenceTable();
        public InformationKindList AllInformationKinds = new InformationKindList();
        public MilitaryKindTable AllMilitaryKinds = new MilitaryKindTable();

        public SectionAIDetailTable AllSectionAIDetails = new SectionAIDetailTable();
        public SkillTable AllSkills = new SkillTable();
        public StratagemTable AllStratagems = new StratagemTable();
        public StuntTable AllStunts = new StuntTable();
        public TechniqueTable AllTechniques = new TechniqueTable();
        public TerrainDetailTable AllTerrainDetails = new TerrainDetailTable();
        public TextMessageTable AllTextMessages = new TextMessageTable();
        public AnimationTable AllTileAnimations = new AnimationTable();
        public TitleTable AllTitles = new TitleTable();
        public TitleKindTable AllTitleKinds = new TitleKindTable();
        public AnimationTable AllTroopAnimations = new AnimationTable();
        public EventEffectKindTable AllTroopEventEffectKinds = new EventEffectKindTable();
        public EventEffectTable AllTroopEventEffects = new EventEffectTable();
        public GameObjects.ArchitectureDetail.EventEffect.EventEffectKindTable AllEventEffectKinds = new GameObjects.ArchitectureDetail.EventEffect.EventEffectKindTable();
        public GameObjects.ArchitectureDetail.EventEffect.EventEffectTable AllEventEffects = new GameObjects.ArchitectureDetail.EventEffect.EventEffectTable();
        public CombatNumberGenerator NumberGenerator = new CombatNumberGenerator();
        public TroopAnimation TroopAnimations = new TroopAnimation();

        public void Clear()
        {
            this.AllArchitectureKinds.Clear();
            this.AllAttackDefaultKinds.Clear();
            this.AllAttackTargetKinds.Clear();
            this.AllBiographies.Clear();
            this.AllCastDefaultKinds.Clear();
            this.AllCastTargetKinds.Clear();
            this.AllCharacterKinds.Clear();
            this.AllColors.Clear();
            this.AllCombatMethods.Clear();
            this.AllConditionKinds.Clear();
            this.AllConditions.Clear();
            this.AllEventEffectKinds.Clear();
            this.AllEventEffects.Clear();
            this.AllFacilityKinds.Clear();
            this.AllIdealTendencyKinds.Clear();
            this.AllInfluenceKinds.Clear();
            this.AllInfluences.Clear();
            this.AllInformationKinds.Clear();
            this.AllMilitaryKinds.Clear();
            this.AllSectionAIDetails.Clear();
            this.AllSkills.Clear();
            this.AllStratagems.Clear();
            this.AllStunts.Clear();
            this.AllTechniques.Clear();
            this.AllTerrainDetails.Clear();
            this.AllTextMessages.Clear();
            this.AllTileAnimations.Clear();
            this.AllTitles.Clear();
            this.AllTitleKinds.Clear();
            this.AllTroopAnimations.Clear();
            this.AllTroopEventEffectKinds.Clear();
            this.AllTroopEventEffects.Clear();
            this.suoyouguanjuezhonglei.Clear();
            this.suoyouzainanzhonglei.Clear();
        }

        public bool LoadFromDatabase(string connectionString)
        {
            int num;
            Animation animation;
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbDataReader reader = new OleDbCommand("Select * From TerrainDetail", connection).ExecuteReader();
            while (reader.Read())
            {
                TerrainDetail terrainDetail = new TerrainDetail();
                terrainDetail.ID = (short)reader["ID"];
                terrainDetail.Name = reader["Name"].ToString();
                terrainDetail.GraphicLayer = (int)reader["GraphicLayer"];
                terrainDetail.ViewThrough = (bool)reader["ViewThrough"];
                terrainDetail.RoutewayBuildFundCost = (int)reader["RoutewayBuildFundCost"];
                terrainDetail.RoutewayActiveFundCost = (int)reader["RoutewayActiveFundCost"];
                terrainDetail.RoutewayBuildWorkCost = (int)reader["RoutewayBuildWorkCost"];
                terrainDetail.RoutewayConsumptionRate = (float)reader["RoutewayConsumptionRate"];
                terrainDetail.FoodDeposit = (int)reader["FoodDeposit"];
                terrainDetail.FoodRegainDays = (int)reader["FoodRegainDays"];
                terrainDetail.FoodSpringRate = (float)reader["FoodSpringRate"];
                terrainDetail.FoodSummerRate = (float)reader["FoodSummerRate"];
                terrainDetail.FoodAutumnRate = (float)reader["FoodAutumnRate"];
                terrainDetail.FoodWinterRate = (float)reader["FoodWinterRate"];
                terrainDetail.FireDamageRate = (float)reader["FireDamageRate"];
                this.AllTerrainDetails.AddTerrainDetail(terrainDetail);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Color", connection).ExecuteReader();
            while (reader.Read())
            {
                Color item = new Color();
                item.PackedValue = uint.Parse(reader["Code"].ToString());
                this.AllColors.Add(item);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From IdealTendencyKind", connection).ExecuteReader();
            while (reader.Read())
            {
                IdealTendencyKind t = new IdealTendencyKind();
                t.ID = (short)reader["ID"];
                t.Name = reader["Name"].ToString();
                t.Offset = (short)reader["Offset"];
                this.AllIdealTendencyKinds.Add(t);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From CharacterKind", connection).ExecuteReader();
            while (reader.Read())
            {
                CharacterKind kind2 = new CharacterKind();
                kind2.ID = (short)reader["ID"];
                kind2.Name = reader["Name"].ToString();
                kind2.IntelligenceRate = (float)reader["IntelligenceRate"];
                kind2.ChallengeChance = (short)reader["ChallengeChance"];
                kind2.ControversyChance = (short)reader["ControversyChance"];
                this.AllCharacterKinds.Add(kind2);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From ArchitectureKind", connection).ExecuteReader();
            while (reader.Read())
            {
                ArchitectureKind architectureKind = new ArchitectureKind();
                architectureKind.ID = (short)reader["ID"];
                architectureKind.Name = reader["Name"].ToString();
                architectureKind.AgricultureBase = (short)reader["AgricultureBase"];
                architectureKind.AgricultureUnit = (short)reader["AgricultureUnit"];
                architectureKind.CommerceBase = (short)reader["CommerceBase"];
                architectureKind.CommerceUnit = (short)reader["CommerceUnit"];
                architectureKind.TechnologyBase = (short)reader["TechnologyBase"];
                architectureKind.TechnologyUnit = (short)reader["TechnologyUnit"];
                architectureKind.DominationBase = (short)reader["DominationBase"];
                architectureKind.DominationUnit = (short)reader["DominationUnit"];
                architectureKind.MoraleBase = (short)reader["MoraleBase"];
                architectureKind.MoraleUnit = (short)reader["MoraleUnit"];
                architectureKind.EnduranceBase = (short)reader["EnduranceBase"];
                architectureKind.EnduranceUnit = (short)reader["EnduranceUnit"];
                architectureKind.PopulationBase = (int)reader["PopulationBase"];
                architectureKind.PopulationUnit = (int)reader["PopulationUnit"];
                architectureKind.PopulationBoundary = (int)reader["PopulationBoundary"];
                architectureKind.ViewDistance = (short)reader["ViewDistance"];
                architectureKind.ViewDistanceIncrementDivisor = (short)reader["VDIncrementDivisor"];
                architectureKind.HasObliqueView = (bool)reader["HasObliqueView"];
                architectureKind.HasLongView = (bool)reader["HasLongView"];
                architectureKind.HasPopulation = (bool)reader["HasPopulation"];
                architectureKind.HasAgriculture = (bool)reader["HasAgriculture"];
                architectureKind.HasCommerce = (bool)reader["HasCommerce"];
                architectureKind.HasTechnology = (bool)reader["HasTechnology"];
                architectureKind.HasDomination = (bool)reader["HasDomination"];
                architectureKind.HasMorale = (bool)reader["HasMorale"];
                architectureKind.HasEndurance = (bool)reader["HasEndurance"];
                architectureKind.HasHarbor = (bool)reader["HasHarbor"];
                architectureKind.FacilityPositionUnit = (short)reader["FacilityPositionUnit"];
                architectureKind.FundMaxUnit = (int)reader["FundMaxUnit"];
                architectureKind.FoodMaxUnit = (int)reader["FoodMaxUnit"];
                try
                {
                    architectureKind.CountToMerit = (bool)reader["CountToMerit"];
                }
                catch (Exception)
                {
                    architectureKind.CountToMerit = architectureKind.ID == 1 ? true : false;
                }
                this.AllArchitectureKinds.AddArchitectureKind(architectureKind);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From SectionAIDetail", connection).ExecuteReader();
            while (reader.Read())
            {
                SectionAIDetail sectionAIDetail = new SectionAIDetail();
                sectionAIDetail.ID = (short)reader["ID"];
                sectionAIDetail.Name = reader["Name"].ToString();
                sectionAIDetail.Description = reader["Description"].ToString();
                sectionAIDetail.OrientationKind = (SectionOrientationKind)((short)reader["OrientationKind"]);
                sectionAIDetail.AutoRun = (bool)reader["AutoRun"];
                sectionAIDetail.ValueAgriculture = (bool)reader["ValueAgriculture"];
                sectionAIDetail.ValueCommerce = (bool)reader["ValueCommerce"];
                sectionAIDetail.ValueTechnology = (bool)reader["ValueTechnology"];
                sectionAIDetail.ValueDomination = (bool)reader["ValueDomination"];
                sectionAIDetail.ValueMorale = (bool)reader["ValueMorale"];
                sectionAIDetail.ValueEndurance = (bool)reader["ValueEndurance"];
                sectionAIDetail.ValueTraining = (bool)reader["ValueTraining"];
                sectionAIDetail.ValueRecruitment = (bool)reader["ValueRecruitment"];
                sectionAIDetail.ValueNewMilitary = (bool)reader["ValueNewMilitary"];
                sectionAIDetail.ValueOffensiveCampaign = (bool)reader["ValueOffensiveCampaign"];
                sectionAIDetail.AllowInvestigateTactics = (bool)reader["AllowInvestigateTactics"];
                sectionAIDetail.AllowOffensiveTactics = (bool)reader["AllowOffensiveTactics"];
                sectionAIDetail.AllowPersonTactics = (bool)reader["AllowPersonTactics"];
                sectionAIDetail.AllowOffensiveCampaign = (bool)reader["AllowOffensiveCampaign"];
                sectionAIDetail.AllowFundTransfer = (bool)reader["AllowFundTransfer"];
                sectionAIDetail.AllowFoodTransfer = (bool)reader["AllowFoodTransfer"];
                sectionAIDetail.AllowMilitaryTransfer = (bool)reader["AllowMilitaryTransfer"];
                try
                {
                    sectionAIDetail.AllowFacilityRemoval = (bool)reader["AllowFacilityRemoval"];
                }
                catch
                {
                    sectionAIDetail.AllowFacilityRemoval = true;
                }
                this.AllSectionAIDetails.AddSectionAIDetail(sectionAIDetail);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From InfluenceKind", connection).ExecuteReader();
            while (reader.Read())
            {
                num = (short)reader["ID"];
                InfluenceKind ik = InfluenceKindFactory.CreateInfluenceKindByID(num);
                if (ik != null)
                {
                    ik.ID = num;
                    ik.Type = (InfluenceType)((short)reader["Type"]);
                    ik.Name = reader["Name"].ToString();
                    try
                    {
                        ik.Combat = (bool)reader["Combat"];
                    }
                    catch
                    {
                        ik.Combat = true;
                    }
                    this.AllInfluenceKinds.AddInfluenceKind(ik);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Influence", connection).ExecuteReader();
            while (reader.Read())
            {
                Influence influence = new Influence();
                influence.ID = (short)reader["ID"];
                influence.Name = reader["Name"].ToString();
                influence.Description = reader["Description"].ToString();
                influence.Parameter = reader["Parameter"].ToString();
                influence.Parameter2 = reader["Parameter2"].ToString();
                influence.Kind = this.AllInfluenceKinds.GetInfluenceKind((short)reader["Kind"]);
                if (influence.Kind != null)
                {
                    this.AllInfluences.AddInfluence(influence);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From ConditionKind", connection).ExecuteReader();
            while (reader.Read())
            {
                num = (short)reader["ID"];
                ConditionKind ck = ConditionKindFactory.CreateConditionKindByID(num);
                if (ck != null)
                {
                    ck.ID = num;
                    ck.Name = reader["Name"].ToString();
                    this.AllConditionKinds.AddConditionKind(ck);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Condition", connection).ExecuteReader();
            while (reader.Read())
            {
                Condition condition = new Condition();
                condition.ID = (short)reader["ID"];
                condition.Name = reader["Name"].ToString();
                condition.Parameter = reader["Parameter"].ToString();
                condition.Parameter2 = reader["Parameter2"].ToString();
                condition.Kind = this.AllConditionKinds.GetConditionKind((short)reader["Kind"]);
                this.AllConditions.AddCondition(condition);
            }
            connection.Close();

            ///


            connection.Open();
            reader = new OleDbCommand("Select * From TroopEventEffectKind", connection).ExecuteReader();
            while (reader.Read())
            {
                num = (short)reader["ID"];
                EventEffectKind e = EventEffectKindFactory.CreateEventEffectKindByID(num);
                if (e != null)
                {
                    e.ID = num;
                    e.Name = reader["Name"].ToString();
                    this.AllTroopEventEffectKinds.AddEventEffectKind(e);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From TroopEventEffect", connection).ExecuteReader();
            while (reader.Read())
            {
                GameObjects.TroopDetail.EventEffect.EventEffect effect = new GameObjects.TroopDetail.EventEffect.EventEffect();
                effect.ID = (short)reader["ID"];
                effect.Name = reader["Name"].ToString();
                effect.Parameter = reader["Parameter"].ToString();
                effect.Kind = this.AllTroopEventEffectKinds.GetEventEffectKind((short)reader["Kind"]);
                this.AllTroopEventEffects.AddEventEffect(effect);
            }
            connection.Close();

            //////////////////////////////////////////////////////////

            connection.Open();
            reader = new OleDbCommand("Select * From EventEffectKind", connection).ExecuteReader();
            while (reader.Read())
            {
                num = (short)reader["ID"];
                GameObjects.ArchitectureDetail.EventEffect.EventEffectKind e = GameObjects.ArchitectureDetail.EventEffect.EventEffectKindFactory.CreateEventEffectKindByID(num);
                if (e != null)
                {
                    e.ID = num;
                    e.Name = reader["Name"].ToString();
                    this.AllEventEffectKinds.AddEventEffectKind(e);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From EventEffect", connection).ExecuteReader();
            while (reader.Read())
            {
                GameObjects.ArchitectureDetail.EventEffect.EventEffect effect = new GameObjects.ArchitectureDetail.EventEffect.EventEffect();
                effect.ID = (short)reader["ID"];
                effect.Name = reader["Name"].ToString();
                effect.Parameter = reader["Parameter"].ToString();
                effect.Parameter2 = reader["Parameter2"].ToString();
                effect.Kind = this.AllEventEffectKinds.GetEventEffectKind((short)reader["Kind"]);
                this.AllEventEffects.AddEventEffect(effect);
            }
            connection.Close();

            //////

            connection.Open();
            reader = new OleDbCommand("Select * From FacilityKind", connection).ExecuteReader();
            while (reader.Read())
            {
                FacilityKind facilityKind = new FacilityKind();
                facilityKind.ID = (short)reader["ID"];
                facilityKind.Name = reader["Name"].ToString();
                try
                {
                    facilityKind.AILevel = (float)reader["AILevel"];
                }
                catch
                {
                    facilityKind.AILevel = 1;
                }
                facilityKind.PositionOccupied = (int)reader["PositionOccupied"];
                facilityKind.TechnologyNeeded = (int)reader["TechnologyNeeded"];
                facilityKind.FundCost = (int)reader["FundCost"];
                facilityKind.PointCost = (int)reader["PointCost"];
                facilityKind.MaintenanceCost = (int)reader["MaintenanceCost"];
                facilityKind.Days = (short)reader["Days"];
                facilityKind.Endurance = (int)reader["Endurance"];
                facilityKind.UniqueInArchitecture = (bool)reader["UniqueInArchitecture"];
                facilityKind.UniqueInFaction = (bool)reader["UniqueInFaction"];
                facilityKind.PopulationRelated = (bool)reader["PopulationRelated"];
                facilityKind.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                facilityKind.rongna = (short)reader["rongna"];
                facilityKind.bukechaichu = (bool)reader["bukechaichu"];
                facilityKind.Conditions.LoadFromString(this.AllConditions, reader["Conditions"].ToString());
                this.AllFacilityKinds.AddFacilityKind(facilityKind);
            }
            connection.Close();

            ///////////////////////////////////////////////////////////////////////
            connection.Open();
            reader = new OleDbCommand("Select * From DisasterKind", connection).ExecuteReader();
            while (reader.Read())
            {
                zainanzhongleilei zainanzhonglei = new zainanzhongleilei();

                zainanzhonglei.ID = (short)reader["ID"];
                zainanzhonglei.Name = reader["名称"].ToString();
                zainanzhonglei.shijianxiaxian = (short)reader["时间下限"];
                zainanzhonglei.shijianshangxian = (short)reader["时间上限"];

                zainanzhonglei.renkoushanghai = (short)reader["人口伤害"];
                zainanzhonglei.tongzhishanghai = (short)reader["统治伤害"];
                zainanzhonglei.naijiushanghai = (short)reader["耐久伤害"];
                zainanzhonglei.nongyeshanghai = (short)reader["农业伤害"];
                zainanzhonglei.shangyeshanghai = (short)reader["商业伤害"];
                zainanzhonglei.jishushanghai = (short)reader["技术伤害"];
                zainanzhonglei.minxinshanghai = (short)reader["民心伤害"];

                this.suoyouzainanzhonglei.Addzainanzhonglei(zainanzhonglei);
            }

            connection.Close();

            ///////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////
            connection.Open();
            reader = new OleDbCommand("Select * From guanjuezhonglei", connection).ExecuteReader();
            while (reader.Read())
            {
                guanjuezhongleilei guanjuedezhonglei = new guanjuezhongleilei();

                guanjuedezhonglei.ID = (short)reader["ID"];
                guanjuedezhonglei.Name = reader["名称"].ToString();
                guanjuedezhonglei.shengwangshangxian = (int)reader["声望上限"];
                guanjuedezhonglei.xuyaogongxiandu = (int)reader["需要贡献度"];

                guanjuedezhonglei.xuyaochengchi = (short)reader["需要城池"];


                this.suoyouguanjuezhonglei.Addguanjuedezhonglei(guanjuedezhonglei);
            }

            connection.Close();

            ///////////////////////////////////////////////////////////////////////


            connection.Open();
            reader = new OleDbCommand("Select * From Technique", connection).ExecuteReader();
            while (reader.Read())
            {
                Technique technique = new Technique();
                technique.ID = (short)reader["ID"];
                technique.Kind = (short)reader["Kind"];
                technique.DisplayRow = (short)reader["DisplayRow"];
                technique.DisplayCol = (short)reader["DisplayCol"];
                technique.Name = reader["Name"].ToString();
                technique.Description = reader["Description"].ToString();
                technique.PreID = (short)reader["PreID"];
                technique.PostID = (short)reader["PostID"];
                technique.Reputation = (int)reader["Reputation"];
                technique.FundCost = (int)reader["FundCost"];
                technique.PointCost = (int)reader["PointCost"];
                technique.Days = (short)reader["Days"];
                technique.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                this.AllTechniques.AddTechnique(technique);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Skill", connection).ExecuteReader();
            while (reader.Read())
            {
                Skill skill = new Skill();
                skill.ID = (short)reader["ID"];
                skill.DisplayRow = (short)reader["DisplayRow"];
                skill.DisplayCol = (short)reader["DisplayCol"];
                skill.Kind = (short)reader["Kind"];
                skill.Level = (short)reader["Level"];
                skill.Combat = (bool)reader["Combat"];
                skill.Name = reader["Name"].ToString();
                skill.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                skill.Conditions.LoadFromString(this.AllConditions, reader["Conditions"].ToString());
                this.AllSkills.AddSkill(skill);
            }
            connection.Close();
            connection.Open();
            try
            {
                reader = new OleDbCommand("Select * From TitleKind", connection).ExecuteReader();
                while (reader.Read())
                {
                    TitleKind tk = new TitleKind();
                    tk.ID = (short)reader["ID"];
                    tk.Name = reader["KName"].ToString();
                    tk.Combat = (bool)reader["Combat"];
                    tk.StudyDay = (short)reader["StudyDay"];
                    this.AllTitleKinds.AddTitleKind(tk);
                }
            }
            catch
            {
                TitleKind tk = new TitleKind();
                tk.ID = 1;
                tk.Name = "个人称号";
                tk.Combat = false;
                tk.StudyDay = 60;
                this.AllTitleKinds.AddTitleKind(tk);
                tk = new TitleKind();
                tk.ID = 2;
                tk.Name = "战斗称号";
                tk.Combat = true;
                tk.StudyDay = 60;
                this.AllTitleKinds.AddTitleKind(tk);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Title", connection).ExecuteReader();
            while (reader.Read())
            {
                Title title = new Title();
                title.ID = (short)reader["ID"];
                title.Kind = ((short)reader["Kind"]);
                title.Level = (short)reader["Level"];
                title.Combat = (bool)reader["Combat"];
                title.Name = reader["Name"].ToString();
                title.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                title.Conditions.LoadFromString(this.AllConditions, reader["Conditions"].ToString());
                if (this.AllTitleKinds.GetTitleKind(title.Kind) != null)
                {
                    title.KindName = this.AllTitleKinds.GetTitleKind(title.Kind).Name;
                    this.AllTitles.AddTitle(title);
                }
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From MilitaryKind", connection).ExecuteReader();
            while (reader.Read())
            {
                MilitaryKind militaryKind = new MilitaryKind();
                militaryKind.ID = (short)reader["ID"];
                militaryKind.Type = (MilitaryType)((short)reader["Type"]);
                militaryKind.Name = reader["Name"].ToString();
                militaryKind.Description = reader["Description"].ToString();
                militaryKind.Merit = (short)reader["Merit"];
                militaryKind.Speed = (short)reader["Speed"];
                militaryKind.TitleInfluence = (short)reader["TitleInfluence"];
                militaryKind.CreateCost = (int)reader["CreateCost"];
                militaryKind.CreateTechnology = (int)reader["CreateTechnology"];
                militaryKind.IsShell = (bool)reader["IsShell"];
                militaryKind.CreateBesideWater = (bool)reader["CreateBesideWater"];
                militaryKind.Offence = (short)reader["Offence"];
                militaryKind.Defence = (short)reader["Defence"];
                militaryKind.OffenceRadius = (short)reader["OffenceRadius"];
                militaryKind.CounterOffence = (bool)reader["CounterOffence"];
                militaryKind.BeCountered = (bool)reader["BeCountered"];
                militaryKind.ObliqueOffence = (bool)reader["ObliqueOffence"];
                militaryKind.ArrowOffence = (bool)reader["ArrowOffence"];
                militaryKind.AirOffence = (bool)reader["AirOffence"];
                militaryKind.ContactOffence = (bool)reader["ContactOffence"];
                militaryKind.OffenceOnlyBeforeMove = (bool)reader["OffenceOnlyBeforeMove"];
                militaryKind.ArchitectureDamageRate = (float)reader["ArchitectureDamageRate"];
                militaryKind.ArchitectureCounterDamageRate = (float)reader["ArchitectureCounterDamageRate"];
                militaryKind.StratagemRadius = (short)reader["StratagemRadius"];
                militaryKind.ObliqueStratagem = (bool)reader["ObliqueStratagem"];
                militaryKind.ViewRadius = (short)reader["ViewRadius"];
                militaryKind.ObliqueView = (bool)reader["ObliqueView"];
                militaryKind.Movability = (short)reader["Movability"];
                militaryKind.OneAdaptabilityKind = (short)reader["OneAdaptabilityKind"];
                militaryKind.PlainAdaptability = (short)reader["PlainAdaptability"];
                militaryKind.GrasslandAdaptability = (short)reader["GrasslandAdaptability"];
                militaryKind.ForrestAdaptability = (short)reader["ForrestAdaptability"];
                militaryKind.MarshAdaptability = (short)reader["MarshAdaptability"];
                militaryKind.MountainAdaptability = (short)reader["MountainAdaptability"];
                militaryKind.WaterAdaptability = (short)reader["WaterAdaptability"];
                militaryKind.RidgeAdaptability = (short)reader["RidgeAdaptability"];
                militaryKind.WastelandAdaptability = (short)reader["WastelandAdaptability"];
                militaryKind.DesertAdaptability = (short)reader["DesertAdaptability"];
                militaryKind.CliffAdaptability = (short)reader["CliffAdaptability"];
                militaryKind.PlainRate = (float)reader["PlainRate"];
                militaryKind.GrasslandRate = (float)reader["GrasslandRate"];
                militaryKind.ForrestRate = (float)reader["ForrestRate"];
                militaryKind.MarshRate = (float)reader["MarshRate"];
                militaryKind.MountainRate = (float)reader["MountainRate"];
                militaryKind.WaterRate = (float)reader["WaterRate"];
                militaryKind.RidgeRate = (float)reader["RidgeRate"];
                militaryKind.WastelandRate = (float)reader["WastelandRate"];
                militaryKind.DesertRate = (float)reader["DesertRate"];
                militaryKind.CliffRate = (float)reader["CliffRate"];
                militaryKind.InjuryChance = (short)reader["InjuryRate"];
                try
                {
                    militaryKind.FireDamageRate = (float)reader["FireDamageRate"];
                    militaryKind.RecruitLimit = (int)reader["RecruitLimit"];
                }
                catch
                {
                    try
                    {
                        militaryKind.FireDamageRate = (bool)reader["AfraidOfFire"] ? 3.0f : 1.0f;
                        militaryKind.RecruitLimit = (bool)reader["Unique"] ? 1 : 1000;
                    }
                    catch
                    {
                        militaryKind.FireDamageRate = 1.0f;
                        militaryKind.RecruitLimit = 10000;
                    }
                }
                militaryKind.FoodPerSoldier = (short)reader["FoodPerSoldier"];
                militaryKind.RationDays = (int)reader["RationDays"];
                militaryKind.PointsPerSoldier = (int)reader["PointsPerSoldier"];
                militaryKind.MinScale = (int)reader["MinScale"];
                militaryKind.MaxScale = (int)reader["MaxScale"];
                militaryKind.OffencePerScale = (short)reader["OffencePerScale"];
                militaryKind.DefencePerScale = (short)reader["DefencePerScale"];
                militaryKind.CanLevelUp = (bool)reader["CanLevelUp"];
                militaryKind.LevelUpKindID = (short)reader["LevelUpKindID"];
                militaryKind.LevelUpExperience = (int)reader["LevelUpExperience"];
                militaryKind.OffencePer100Experience = (short)reader["OffencePer100Experience"];
                militaryKind.DefencePer100Experience = (short)reader["DefencePer100Experience"];
                militaryKind.AttackDefaultKind = (TroopAttackDefaultKind)((short)reader["AttackDefaultKind"]);
                militaryKind.AttackTargetKind = (TroopAttackTargetKind)((short)reader["AttackTargetKind"]);
                militaryKind.CastDefaultKind = (TroopCastDefaultKind)((short)reader["CastDefaultKind"]);
                militaryKind.CastTargetKind = (TroopCastTargetKind)((short)reader["CastTargetKind"]);
                militaryKind.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                militaryKind.zijinshangxian = (int)reader["zijinshangxian"];
                this.AllMilitaryKinds.AddMilitaryKind(militaryKind);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From MilitaryKind", connection).ExecuteReader();
            while (reader.Read())
            {
                MilitaryKind current = this.AllMilitaryKinds.GetMilitaryKindList().GetGameObject((short)reader["ID"]) as MilitaryKind;
                current.successor = new MilitaryKindTable();
                current.successor.LoadFromString(this.AllMilitaryKinds, reader["Successor"].ToString());
            }
            connection.Close();

            connection.Open();
            reader = new OleDbCommand("Select * From InformationKind", connection).ExecuteReader();
            while (reader.Read())
            {
                InformationKind kind9 = new InformationKind();
                kind9.ID = (short)reader["ID"];
                kind9.Level = (InformationLevel)((short)reader["iLevel"]);
                kind9.Oblique = (bool)reader["Oblique"];
                kind9.Radius = (short)reader["Radius"];
                kind9.CostFund = (int)reader["CostFund"];
                this.AllInformationKinds.Add(kind9);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From AttackDefaultKind", connection).ExecuteReader();
            while (reader.Read())
            {
                AttackDefaultKind kind10 = new AttackDefaultKind();
                kind10.ID = (short)reader["ID"];
                kind10.Name = reader["Name"].ToString();
                this.AllAttackDefaultKinds.Add(kind10);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From AttackTargetKind", connection).ExecuteReader();
            while (reader.Read())
            {
                AttackTargetKind kind11 = new AttackTargetKind();
                kind11.ID = (short)reader["ID"];
                kind11.Name = reader["Name"].ToString();
                this.AllAttackTargetKinds.Add(kind11);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From CombatMethod", connection).ExecuteReader();
            while (reader.Read())
            {
                CombatMethod combatMethod = new CombatMethod();
                combatMethod.ID = (short)reader["ID"];
                combatMethod.Name = reader["Name"].ToString();
                combatMethod.Description = reader["Description"].ToString();
                combatMethod.Combativity = (short)reader["Combativity"];
                combatMethod.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                combatMethod.AttackDefault = this.AllAttackDefaultKinds.GetGameObject((short)reader["AttackDefault"]) as AttackDefaultKind;
                combatMethod.AttackTarget = this.AllAttackTargetKinds.GetGameObject((short)reader["AttackTarget"]) as AttackTargetKind;
                combatMethod.ArchitectureTarget = (bool)reader["ArchitectureTarget"];
                combatMethod.CastConditions.LoadFromString(this.AllConditions, reader["CastConditions"].ToString());
                combatMethod.ViewingHostile = (bool)reader["ViewingHostile"];
                combatMethod.AnimationKind = (TileAnimationKind)((short)reader["AnimationKind"]);
                this.AllCombatMethods.AddCombatMethod(combatMethod);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Stunt", connection).ExecuteReader();
            while (reader.Read())
            {
                Stunt stunt = new Stunt();
                stunt.ID = (short)reader["ID"];
                stunt.Name = reader["Name"].ToString();
                stunt.Combativity = (short)reader["Combativity"];
                stunt.Period = (short)reader["Period"];
                stunt.Animation = (short)reader["Animation"];
                stunt.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                stunt.CastConditions.LoadFromString(this.AllConditions, reader["CastConditions"].ToString());
                stunt.LearnConditions.LoadFromString(this.AllConditions, reader["LearnConditions"].ToString());
                stunt.AIConditions.LoadFromString(this.AllConditions, reader["AIConditions"].ToString());
                this.AllStunts.AddStunt(stunt);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From CastDefaultKind", connection).ExecuteReader();
            while (reader.Read())
            {
                CastDefaultKind kind12 = new CastDefaultKind();
                kind12.ID = (short)reader["ID"];
                kind12.Name = reader["Name"].ToString();
                this.AllCastDefaultKinds.Add(kind12);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From CastTargetKind", connection).ExecuteReader();
            while (reader.Read())
            {
                CastTargetKind kind13 = new CastTargetKind();
                kind13.ID = (short)reader["ID"];
                kind13.Name = reader["Name"].ToString();
                this.AllCastTargetKinds.Add(kind13);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Stratagem", connection).ExecuteReader();
            while (reader.Read())
            {
                Stratagem stratagem = new Stratagem();
                stratagem.ID = (short)reader["ID"];
                stratagem.Name = reader["Name"].ToString();
                stratagem.Description = reader["Description"].ToString();
                stratagem.Combativity = (short)reader["Combativity"];
                stratagem.Chance = (short)reader["Chance"];
                stratagem.TechniquePoint = (int)reader["TechniquePoint"];
                stratagem.Friendly = (bool)reader["Friendly"];
                stratagem.Self = (bool)reader["Self"];
                stratagem.AnimationKind = (TileAnimationKind)((short)reader["AnimationKind"]);
                stratagem.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                stratagem.CastDefault = this.AllCastDefaultKinds.GetGameObject((short)reader["CastDefault"]) as CastDefaultKind;
                stratagem.CastTarget = this.AllCastTargetKinds.GetGameObject((short)reader["CastTarget"]) as CastTargetKind;
                stratagem.ArchitectureTarget = (bool)reader["ArchitectureTarget"];
                stratagem.RequireInfluenceToUse = (bool)reader["RequireInfluneceToUse"];
                this.AllStratagems.AddStratagem(stratagem);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From TroopAnimation", connection).ExecuteReader();
            while (reader.Read())
            {
                animation = new Animation();
                animation.ID = (short)reader["ID"];
                animation.Name = reader["Name"].ToString();
                animation.FrameCount = (short)reader["FrameCount"];
                animation.StayCount = (short)reader["StayCount"];
                this.AllTroopAnimations.AddAnimation(animation);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From TileAnimation", connection).ExecuteReader();
            while (reader.Read())
            {
                animation = new Animation();
                animation.ID = (short)reader["ID"];
                animation.Name = reader["Name"].ToString();
                animation.FrameCount = (short)reader["FrameCount"];
                animation.StayCount = (short)reader["StayCount"];
                animation.Back = (bool)reader["Back"];
                this.AllTileAnimations.AddAnimation(animation);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From Biography", connection).ExecuteReader();
            while (reader.Read())
            {
                Biography biography = new Biography();
                biography.ID = (short)reader["ID"];
                biography.Brief = reader["Brief"].ToString();
                biography.Romance = reader["Romance"].ToString();
                biography.History = reader["History"].ToString();
                biography.FactionColor = (short)reader["FactionColor"];
                biography.MilitaryKinds.LoadFromString(this.AllMilitaryKinds, reader["MilitaryKinds"].ToString());
                this.AllBiographies.AddBiography(biography);
            }
            connection.Close();
            connection.Open();
            reader = new OleDbCommand("Select * From TextMessage", connection).ExecuteReader();
            while (reader.Read())
            {
                TextMessage textMessage = new TextMessage();
                textMessage.ID = (short)reader["ID"];
                StaticMethods.LoadFromString(textMessage.CriticalStrike, reader["CriticalStrike"].ToString());
                StaticMethods.LoadFromString(textMessage.CriticalStrikeOnArchitecture, reader["CriticalStrikeOnArchitecture"].ToString());
                StaticMethods.LoadFromString(textMessage.ReceiveCriticalStrike, reader["ReceiveCriticalStrike"].ToString());
                StaticMethods.LoadFromString(textMessage.Surround, reader["Surround"].ToString());
                StaticMethods.LoadFromString(textMessage.Rout, reader["Rout"].ToString());
                StaticMethods.LoadFromString(textMessage.DualInitiativeWin, reader["DualInitiativeWin"].ToString());
                StaticMethods.LoadFromString(textMessage.DualPassiveWin, reader["DualPassiveWin"].ToString());
                StaticMethods.LoadFromString(textMessage.ControversyInitiativeWin, reader["ControversyInitiativeWin"].ToString());
                StaticMethods.LoadFromString(textMessage.ControversyPassiveWin, reader["ControversyPassiveWin"].ToString());
                StaticMethods.LoadFromString(textMessage.Chaos, reader["Chaos"].ToString());
                StaticMethods.LoadFromString(textMessage.DeepChaos, reader["DeepChaos"].ToString());
                StaticMethods.LoadFromString(textMessage.CastDeepChaos, reader["CastDeepChaos"].ToString());
                StaticMethods.LoadFromString(textMessage.RecoverFromChaos, reader["RecoverFromChaos"].ToString());
                StaticMethods.LoadFromString(textMessage.TrappedByStratagem, reader["TrappedByStratagem"].ToString());
                StaticMethods.LoadFromString(textMessage.HelpedByStratagem, reader["HelpedByStratagem"].ToString());
                StaticMethods.LoadFromString(textMessage.ResistHarmfulStratagem, reader["ResistHarmfulStratagem"].ToString());
                StaticMethods.LoadFromString(textMessage.ResistHelpfulStratagem, reader["ResistHelpfulStratagem"].ToString());
                StaticMethods.LoadFromString(textMessage.AntiAttack, reader["AntiAttack"].ToString());
                StaticMethods.LoadFromString(textMessage.BreakWall, reader["BreakWall"].ToString());
                StaticMethods.LoadFromString(textMessage.OutburstAngry, reader["OutburstAngry"].ToString());
                StaticMethods.LoadFromString(textMessage.OutburstQuiet, reader["OutburstQuiet"].ToString());
                this.AllTextMessages.AddTextMessage(textMessage);
            }
            connection.Close();

            return true;
        }

        public void SaveToDatabase(string connectionString)
        {
            DataRow current;
            int num2;
            IEnumerator enumerator;
            OleDbConnection selectConnection = new OleDbConnection(connectionString);
            DataSet dataSet = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Biography", selectConnection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Fill(dataSet, "Biography");
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            List<int> list = new List<int>();
            int num = 0;
            //using (enumerator = dataSet.Tables["Biography"].Rows.GetEnumerator())
            enumerator = dataSet.Tables["Biography"].Rows.GetEnumerator();
            {
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    Biography biography = null;
                    num2 = (short) current["ID"];
                    dictionary.Add(num2, num2);
                    if (this.AllBiographies.Biographys.TryGetValue(num2, out biography))
                    {
                        current.BeginEdit();
                        current["Brief"] = biography.Brief;
                        current["Romance"] = biography.Romance;
                        current["History"] = biography.History;
                        current["FactionColor"] = biography.FactionColor;
                        current["MilitaryKinds"] = biography.MilitaryKinds.SaveToString();
                        current.EndEdit();
                    }
                    num++;
                }
            }
            
            foreach (int num3 in list)
            {
                dataSet.Tables["Biography"].Rows[num3].Delete();
            }
            foreach (Biography biography in this.AllBiographies.Biographys.Values)
            {
                if (!dictionary.ContainsKey(biography.ID))
                {
                    current = dataSet.Tables["Biography"].NewRow();
                    current.BeginEdit();
                    current["ID"] = biography.ID;
                    current["Brief"] = biography.Brief;
                    current["Romance"] = biography.Romance;
                    current["History"] = biography.History;
                    current["FactionColor"] = biography.FactionColor;
                    current["MilitaryKinds"] = biography.MilitaryKinds.SaveToString();
                    current.EndEdit();
                    dataSet.Tables["Biography"].Rows.Add(current);
                }
            }
            adapter.Update(dataSet, "Biography");
            dataSet.Clear();
            adapter = new OleDbDataAdapter("Select * from TextMessage", selectConnection);
            builder = new OleDbCommandBuilder(adapter);
            adapter.Fill(dataSet, "TextMessage");
            dictionary.Clear();
            list.Clear();
            num = 0;
            //using (enumerator = dataSet.Tables["TextMessage"].Rows.GetEnumerator())
            enumerator = dataSet.Tables["TextMessage"].Rows.GetEnumerator();
            {
                while (enumerator.MoveNext())
                {
                    current = (DataRow) enumerator.Current;
                    TextMessage message = null;
                    num2 = (short) current["ID"];
                    dictionary.Add(num2, num2);
                    if (this.AllTextMessages.TextMessages.TryGetValue(num2, out message))
                    {
                        current.BeginEdit();
                        current["CriticalStrike"] = StaticMethods.SaveToString(message.CriticalStrike);
                        current["ReceiveCriticalStrike"] = StaticMethods.SaveToString(message.ReceiveCriticalStrike);
                        current["OutburstAngry"] = StaticMethods.SaveToString(message.OutburstAngry);
                        current["OutburstQuiet"] = StaticMethods.SaveToString(message.OutburstQuiet);
                        current["RecoverFromChaos"] = StaticMethods.SaveToString(message.RecoverFromChaos);
                        current["ResistHarmfulStratagem"] = StaticMethods.SaveToString(message.ResistHarmfulStratagem);
                        current["ResistHelpfulStratagem"] = StaticMethods.SaveToString(message.ResistHelpfulStratagem);
                        current["Rout"] = StaticMethods.SaveToString(message.Rout);
                        current["AntiAttack"] = StaticMethods.SaveToString(message.AntiAttack);
                        current["BreakWall"] = StaticMethods.SaveToString(message.BreakWall);
                        current["CastDeepChaos"] = StaticMethods.SaveToString(message.CastDeepChaos);
                        current["Chaos"] = StaticMethods.SaveToString(message.Chaos);
                        current["CriticalStrikeOnArchitecture"] = StaticMethods.SaveToString(message.CriticalStrikeOnArchitecture);
                        current["DeepChaos"] = StaticMethods.SaveToString(message.DeepChaos);
                        current["DualInitiativeWin"] = StaticMethods.SaveToString(message.DualInitiativeWin);
                        current["DualPassiveWin"] = StaticMethods.SaveToString(message.DualPassiveWin);
                        current["ControversyInitiativeWin"] = StaticMethods.SaveToString(message.ControversyInitiativeWin);
                        current["ControversyPassiveWin"] = StaticMethods.SaveToString(message.ControversyPassiveWin);
                        current["HelpedByStratagem"] = StaticMethods.SaveToString(message.HelpedByStratagem);
                        current["Surround"] = StaticMethods.SaveToString(message.Surround);
                        current["TrappedByStratagem"] = StaticMethods.SaveToString(message.TrappedByStratagem);
                        current.EndEdit();
                    }
                    num++;
                }
            }
            foreach (int num3 in list)
            {
                dataSet.Tables["TextMessage"].Rows[num3].Delete();
            }
            foreach (TextMessage message in this.AllTextMessages.TextMessages.Values)
            {
                if (!dictionary.ContainsKey(message.ID))
                {
                    current = dataSet.Tables["TextMessage"].NewRow();
                    current.BeginEdit();
                    current["ID"] = message.ID;
                    current["CriticalStrike"] = StaticMethods.SaveToString(message.CriticalStrike);
                    current["ReceiveCriticalStrike"] = StaticMethods.SaveToString(message.ReceiveCriticalStrike);
                    current["OutburstAngry"] = StaticMethods.SaveToString(message.OutburstAngry);
                    current["OutburstQuiet"] = StaticMethods.SaveToString(message.OutburstQuiet);
                    current["RecoverFromChaos"] = StaticMethods.SaveToString(message.RecoverFromChaos);
                    current["ResistHarmfulStratagem"] = StaticMethods.SaveToString(message.ResistHarmfulStratagem);
                    current["ResistHelpfulStratagem"] = StaticMethods.SaveToString(message.ResistHelpfulStratagem);
                    current["Rout"] = StaticMethods.SaveToString(message.Rout);
                    current["AntiAttack"] = StaticMethods.SaveToString(message.AntiAttack);
                    current["BreakWall"] = StaticMethods.SaveToString(message.BreakWall);
                    current["CastDeepChaos"] = StaticMethods.SaveToString(message.CastDeepChaos);
                    current["Chaos"] = StaticMethods.SaveToString(message.Chaos);
                    current["CriticalStrikeOnArchitecture"] = StaticMethods.SaveToString(message.CriticalStrikeOnArchitecture);
                    current["DeepChaos"] = StaticMethods.SaveToString(message.DeepChaos);
                    current["DualInitiativeWin"] = StaticMethods.SaveToString(message.DualInitiativeWin);
                    current["DualPassiveWin"] = StaticMethods.SaveToString(message.DualPassiveWin);
                    current["HelpedByStratagem"] = StaticMethods.SaveToString(message.HelpedByStratagem);
                    current["Surround"] = StaticMethods.SaveToString(message.Surround);
                    current["TrappedByStratagem"] = StaticMethods.SaveToString(message.TrappedByStratagem);
                    current.EndEdit();
                    dataSet.Tables["TextMessage"].Rows.Add(current);
                }
            }
            adapter.Update(dataSet, "TextMessage");
            dataSet.Clear();
        }

        public void DeleteCommonDataTables(string connectionString)
        {
            using (OleDbConnection selectConnection = new OleDbConnection(connectionString))
            {
                selectConnection.Open();

                new OleDbCommand("drop table ArchitectureKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table AttackDefaultKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table AttackTargetKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Biography", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table CastDefaultKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table CastTargetKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table CharacterKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Color", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table CombatMethod", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Condition", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table ConditionKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table DisasterKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table EventEffect", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table EventEffectKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table FacilityKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table guanjuezhonglei", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table IdealTendencyKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Influence", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table InfluenceKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table InformationKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table MilitaryKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table SectionAIDetail", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Skill", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Stratagem", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Stunt", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Technique", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TerrainDetail", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TextMessage", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TileAnimation", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table Title", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TroopAnimation", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TroopEventEffect", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table TroopEventEffectKind", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table GlobalVariables", selectConnection).ExecuteNonQuery();
                new OleDbCommand("drop table GameParameters", selectConnection).ExecuteNonQuery();

                selectConnection.Close();
            }
        }

        public void SaveAllToDatabase(string connectionString)
        {
            List<int> storedIds = new List<int>();
            using (OleDbConnection selectConnection = new OleDbConnection(connectionString))
            {
                selectConnection.Open();
                DataSet dataSet = new DataSet();
                DataRow row = null;
                OleDbDataAdapter adapter;
                OleDbCommandBuilder builder;

                new OleDbCommand("Delete from ArchitectureKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from ArchitectureKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "ArchitectureKind");
                dataSet.Tables["ArchitectureKind"].Rows.Clear();
                storedIds.Clear();
                foreach (ArchitectureKind i in this.AllArchitectureKinds.ArchitectureKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["ArchitectureKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["AgricultureBase"] = i.AgricultureBase;
                    row["AgricultureUnit"] = i.AgricultureUnit;
                    row["CommerceBase"] = i.CommerceBase;
                    row["CommerceUnit"] = i.CommerceUnit;
                    row["TechnologyBase"] = i.TechnologyBase;
                    row["TechnologyUnit"] = i.TechnologyUnit;
                    row["DominationBase"] = i.DominationBase;
                    row["DominationUnit"] = i.DominationUnit;
                    row["MoraleBase"] = i.MoraleBase;
                    row["MoraleUnit"] = i.MoraleUnit;
                    row["EnduranceBase"] = i.EnduranceBase;
                    row["EnduranceUnit"] = i.EnduranceUnit;
                    row["PopulationBase"] = i.PopulationBase;
                    row["PopulationUnit"] = i.PopulationUnit;
                    row["PopulationBoundary"] = i.PopulationBoundary;
                    row["ViewDistance"] = i.ViewDistance;
                    row["VDIncrementDivisor"] = i.ViewDistanceIncrementDivisor;
                    row["HasObliqueView"] = i.HasObliqueView;
                    row["HasLongView"] = i.HasLongView;
                    row["HasPopulation"] = i.HasPopulation;
                    row["HasAgriculture"] = i.HasAgriculture;
                    row["HasCommerce"] = i.HasCommerce;
                    row["HasTechnology"] = i.HasTechnology;
                    row["HasDomination"] = i.HasDomination;
                    row["HasMorale"] = i.HasMorale;
                    row["HasEndurance"] = i.HasEndurance;
                    row["HasHarbor"] = i.HasHarbor;
                    row["FacilityPositionUnit"] = i.FacilityPositionUnit;
                    row["FundMaxUnit"] = i.FundMaxUnit;
                    row["FoodMaxUnit"] = i.FoodMaxUnit;
                    row["CountToMerit"] = i.CountToMerit;
                    row.EndEdit();
                    dataSet.Tables["ArchitectureKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "ArchitectureKind");
                dataSet.Clear();

                new OleDbCommand("Delete from AttackDefaultKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from AttackDefaultKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "AttackDefaultKind");
                dataSet.Tables["AttackDefaultKind"].Rows.Clear();
                storedIds.Clear();
                foreach (AttackDefaultKind i in this.AllAttackDefaultKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["AttackDefaultKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["AttackDefaultKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "AttackDefaultKind");
                dataSet.Clear();

                new OleDbCommand("Delete from AttackTargetKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from AttackTargetKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "AttackTargetKind");
                dataSet.Tables["AttackTargetKind"].Rows.Clear();
                storedIds.Clear();
                foreach (AttackTargetKind i in this.AllAttackTargetKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["AttackTargetKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["AttackTargetKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "AttackTargetKind");
                dataSet.Clear();

                new OleDbCommand("Delete from Biography", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Biography", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Biography");
                dataSet.Tables["Biography"].Rows.Clear();
                storedIds.Clear();
                foreach (Biography i in this.AllBiographies.Biographys.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Biography"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Brief"] = i.Brief;
                    row["Romance"] = i.Romance;
                    row["History"] = i.History;
                    row["FactionColor"] = i.FactionColor;
                    row["MilitaryKinds"] = i.MilitaryKinds.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Biography"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Biography");
                dataSet.Clear();

                new OleDbCommand("Delete from CastDefaultKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from CastDefaultKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "CastDefaultKind");
                dataSet.Tables["CastDefaultKind"].Rows.Clear();
                storedIds.Clear();
                foreach (CastDefaultKind i in this.AllCastDefaultKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["CastDefaultKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["CastDefaultKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "CastDefaultKind");
                dataSet.Clear();

                new OleDbCommand("Delete from CastTargetKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from CastTargetKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "CastTargetKind");
                dataSet.Tables["CastTargetKind"].Rows.Clear();
                storedIds.Clear();
                foreach (CastTargetKind i in this.AllCastTargetKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["CastTargetKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["CastTargetKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "CastTargetKind");
                dataSet.Clear();

                new OleDbCommand("Delete from CharacterKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from CharacterKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "CharacterKind");
                dataSet.Tables["CharacterKind"].Rows.Clear();
                storedIds.Clear();
                foreach (CharacterKind i in this.AllCharacterKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["CharacterKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["IntelligenceRate"] = i.IntelligenceRate;
                    row["ChallengeChance"] = i.ChallengeChance;
                    row["ControversyChance"] = i.ControversyChance;
                    row.EndEdit();
                    dataSet.Tables["CharacterKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "CharacterKind");
                dataSet.Clear();

                new OleDbCommand("Delete from Color", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Color", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Color");
                dataSet.Tables["Color"].Rows.Clear();
                int j = 1;
                foreach (Color i in this.AllColors)
                {
                    row = dataSet.Tables["Color"].NewRow();
                    row.BeginEdit();
                    row["ID"] = j;
                    row["Code"] = i.PackedValue;
                    j++;
                    row.EndEdit();
                    dataSet.Tables["Color"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Color");
                dataSet.Clear();

                new OleDbCommand("Delete from CombatMethod", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from CombatMethod", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "CombatMethod");
                dataSet.Tables["CombatMethod"].Rows.Clear();
                storedIds.Clear();
                foreach (CombatMethod i in this.AllCombatMethods.CombatMethods.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["CombatMethod"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["Combativity"] = i.Combativity;
                    row["Influences"] = i.Influences.SaveToString();
                    row["AttackDefault"] = i.AttackDefault.ID;
                    row["AttackTarget"] = i.AttackTarget.ID;
                    row["ArchitectureTarget"] = i.ArchitectureTarget;
                    row["CastConditions"] = i.CastConditions.SaveToString();
                    row["ViewingHostile"] = i.ViewingHostile;
                    row["AnimationKind"] = i.AnimationKind;
                    row.EndEdit();
                    dataSet.Tables["CombatMethod"].Rows.Add(row);
                }
                adapter.Update(dataSet, "CombatMethod");
                dataSet.Clear();

                new OleDbCommand("Delete from Condition", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Condition", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Condition");
                dataSet.Tables["Condition"].Rows.Clear();
                storedIds.Clear();
                foreach (Condition i in this.AllConditions.Conditions.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    if (i.Kind == null) continue;
                    row = dataSet.Tables["Condition"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Kind"] = i.Kind.ID;
                    row["Name"] = i.Name;
                    row["Parameter"] = i.Parameter;
                    row["Parameter2"] = i.Parameter2;
                    row.EndEdit();
                    dataSet.Tables["Condition"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Condition");
                dataSet.Clear();

                new OleDbCommand("Delete from ConditionKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from ConditionKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "ConditionKind");
                dataSet.Tables["ConditionKind"].Rows.Clear();
                storedIds.Clear();
                foreach (ConditionKind i in this.AllConditionKinds.ConditionKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["ConditionKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["ConditionKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "ConditionKind");
                dataSet.Clear();

                new OleDbCommand("Delete from DisasterKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from DisasterKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "DisasterKind");
                dataSet.Tables["DisasterKind"].Rows.Clear();
                storedIds.Clear();
                foreach (zainanzhongleilei i in this.suoyouzainanzhonglei.zainanzhongleizidian.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["DisasterKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["名称"] = i.Name;
                    row["时间下限"] = i.shijianxiaxian;
                    row["时间上限"] = i.shijianshangxian;
                    row["人口伤害"] = i.renkoushanghai;
                    row["统治伤害"] = i.tongzhishanghai;
                    row["耐久伤害"] = i.naijiushanghai;
                    row["农业伤害"] = i.nongyeshanghai;
                    row["商业伤害"] = i.shangyeshanghai;
                    row["技术伤害"] = i.jishushanghai;
                    row["民心伤害"] = i.minxinshanghai;
                    row.EndEdit();
                    dataSet.Tables["DisasterKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "DisasterKind");
                dataSet.Clear();

                new OleDbCommand("Delete from EventEffect", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from EventEffect", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "EventEffect");
                dataSet.Tables["EventEffect"].Rows.Clear();
                storedIds.Clear();
                foreach (GameObjects.ArchitectureDetail.EventEffect.EventEffect i in this.AllEventEffects.EventEffects.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    if (i.Kind == null) continue;
                    row = dataSet.Tables["EventEffect"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Parameter"] = i.Parameter;
                    row["Parameter2"] = i.Parameter2;
                    row["Kind"] = i.Kind.ID;
                    row.EndEdit();
                    dataSet.Tables["EventEffect"].Rows.Add(row);
                }
                adapter.Update(dataSet, "EventEffect");
                dataSet.Clear();

                new OleDbCommand("Delete from EventEffectKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from EventEffectKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "EventEffectKind");
                dataSet.Tables["EventEffectKind"].Rows.Clear();
                storedIds.Clear();
                foreach (GameObjects.ArchitectureDetail.EventEffect.EventEffectKind i in this.AllEventEffectKinds.EventEffectKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["EventEffectKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["EventEffectKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "EventEffectKind");
                dataSet.Clear();

                new OleDbCommand("Delete from FacilityKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from FacilityKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "FacilityKind");
                dataSet.Tables["FacilityKind"].Rows.Clear();
                storedIds.Clear();
                foreach (FacilityKind i in this.AllFacilityKinds.FacilityKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["FacilityKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    try
                    {
                        row["AILevel"] = i.AILevel;
                    }
                    catch
                    {
                    }
                    row["PositionOccupied"] = i.PositionOccupied;
                    row["TechnologyNeeded"] = i.TechnologyNeeded;
                    row["FundCost"] = i.FundCost;
                    row["MaintenanceCost"] = i.MaintenanceCost;
                    row["PointCost"] = i.PointCost;
                    row["Days"] = i.Days;
                    row["Endurance"] = i.Endurance;
                    row["UniqueInArchitecture"] = i.UniqueInArchitecture;
                    row["UniqueInFaction"] = i.UniqueInFaction;
                    row["PopulationRelated"] = i.PopulationRelated;
                    row["Influences"] = i.Influences.SaveToString();
                    row["Conditions"] = i.Conditions.SaveToString();
                    row["rongna"] = i.rongna;
                    row["bukechaichu"] = i.bukechaichu;
                    row.EndEdit();
                    dataSet.Tables["FacilityKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "FacilityKind");
                dataSet.Clear();

                new OleDbCommand("Delete from guanjuezhonglei", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from guanjuezhonglei", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "guanjuezhonglei");
                dataSet.Tables["guanjuezhonglei"].Rows.Clear();
                storedIds.Clear();
                foreach (guanjuezhongleilei i in this.suoyouguanjuezhonglei.guanjuedezhongleizidian.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["guanjuezhonglei"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["名称"] = i.Name;
                    row["声望上限"] = i.shengwangshangxian;
                    row["需要贡献度"] = i.xuyaogongxiandu;
                    row["需要城池"] = i.xuyaochengchi;
                    row.EndEdit();
                    dataSet.Tables["guanjuezhonglei"].Rows.Add(row);
                }
                adapter.Update(dataSet, "guanjuezhonglei");
                dataSet.Clear();

                new OleDbCommand("Delete from IdealTendencyKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from IdealTendencyKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "IdealTendencyKind");
                dataSet.Tables["IdealTendencyKind"].Rows.Clear();
                storedIds.Clear();
                foreach (IdealTendencyKind i in this.AllIdealTendencyKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["IdealTendencyKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Offset"] = i.Offset;
                    row.EndEdit();
                    dataSet.Tables["IdealTendencyKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "IdealTendencyKind");
                dataSet.Clear();

                new OleDbCommand("Delete from Influence", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Influence", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Influence");
                dataSet.Tables["Influence"].Rows.Clear();
                storedIds.Clear();
                foreach (Influence i in this.AllInfluences.Influences.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    if (i.Kind == null) continue;
                    row = dataSet.Tables["Influence"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Kind"] = i.Kind.ID;
                    row["Description"] = i.Description;
                    row["Parameter"] = i.Parameter;
                    row["Parameter2"] = i.Parameter2;
                    row.EndEdit();
                    dataSet.Tables["Influence"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Influence");
                dataSet.Clear();

                new OleDbCommand("Delete from InfluenceKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from InfluenceKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "InfluenceKind");
                dataSet.Tables["InfluenceKind"].Rows.Clear();
                storedIds.Clear();
                foreach (InfluenceKind i in this.AllInfluenceKinds.InfluenceKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["InfluenceKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Type"] = i.Type;
                    row["Combat"] = i.Combat;
                    row.EndEdit();
                    dataSet.Tables["InfluenceKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "InfluenceKind");
                dataSet.Clear();

                new OleDbCommand("Delete from InformationKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from InformationKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "InformationKind");
                dataSet.Tables["InformationKind"].Rows.Clear();
                storedIds.Clear();
                foreach (InformationKind i in this.AllInformationKinds)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["InformationKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["iLevel"] = (int)i.Level;
                    row["Radius"] = i.Radius;
                    row["Oblique"] = i.Oblique;
                    row["CostFund"] = i.CostFund;
                    row.EndEdit();
                    dataSet.Tables["InformationKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "InformationKind");
                dataSet.Clear();

                new OleDbCommand("Delete from MilitaryKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from MilitaryKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "MilitaryKind");
                dataSet.Tables["MilitaryKind"].Rows.Clear();
                storedIds.Clear();
                foreach (MilitaryKind i in this.AllMilitaryKinds.MilitaryKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["MilitaryKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Type"] = (int) i.Type;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["Merit"] = i.Merit;
                    row["Successor"] = i.successor.SaveToString();
                    row["Speed"] = i.Speed;
                    row["TitleInfluence"] = i.TitleInfluence;
                    row["CreateCost"] = i.CreateCost;
                    row["CreateTechnology"] = i.CreateTechnology;
                    row["IsShell"] = i.IsShell;
                    row["CreateBesideWater"] = i.CreateBesideWater;
                    row["Offence"] = i.Offence;
                    row["Defence"] = i.Defence;
                    row["OffenceRadius"] = i.OffenceRadius;
                    row["CounterOffence"] = i.CounterOffence;
                    row["BeCountered"] = i.BeCountered;
                    row["ObliqueOffence"] = i.ObliqueOffence;
                    row["ArrowOffence"] = i.ArrowOffence;
                    row["AirOffence"] = i.AirOffence;
                    row["ContactOffence"] = i.ContactOffence;
                    row["OffenceOnlyBeforeMove"] = i.OffenceOnlyBeforeMove;
                    row["ArchitectureDamageRate"] = i.ArchitectureDamageRate;
                    row["architectureCounterDamageRate"] = i.ArchitectureCounterDamageRate;
                    row["StratagemRadius"] = i.StratagemRadius;
                    row["ObliqueStratagem"] = i.ObliqueStratagem;
                    row["ViewRadius"] = i.ViewRadius;
                    row["ObliqueView"] = i.ObliqueView;
                    row["InjuryRate"] = i.InjuryChance;
                    row["Movability"] = i.Movability;
                    row["OneAdaptabilityKind"] = i.OneAdaptabilityKind;
                    row["PlainAdaptability"] = i.PlainAdaptability;
                    row["GrasslandAdaptability"] = i.GrasslandAdaptability;
                    row["ForrestAdaptability"] = i.ForrestAdaptability;
                    row["MarshAdaptability"] = i.MarshAdaptability;
                    row["MountainAdaptability"] = i.MountainAdaptability;
                    row["WaterAdaptability"] = i.WaterAdaptability;
                    row["RidgeAdaptability"] = i.RidgeAdaptability;
                    row["WastelandAdaptability"] = i.WastelandAdaptability;
                    row["DesertAdaptability"] = i.DesertAdaptability;
                    row["CliffAdaptability"] = i.CliffAdaptability;
                    row["PlainRate"] = i.PlainRate;
                    row["GrasslandRate"] = i.GrasslandRate;
                    row["ForrestRate"] = i.ForrestRate;
                    row["MarshRate"] = i.MarshRate;
                    row["MountainRate"] = i.MountainRate;
                    row["WaterRate"] = i.WaterRate;
                    row["RidgeRate"] = i.RidgeRate;
                    row["WastelandRate"] = i.WastelandRate;
                    row["DesertRate"] = i.DesertRate;
                    row["CliffRate"] = i.CliffRate;
                    row["FireDamageRate"] = i.FireDamageRate;
                    row["RecruitLimit"] = i.RecruitLimit;
                    row["FoodPerSoldier"] = i.FoodPerSoldier;
                    row["MinScale"] = i.MinScale;
                    row["RationDays"] = i.RationDays;
                    row["PointsPerSoldier"] = i.PointsPerSoldier;
                    row["OffencePerScale"] = i.OffencePerScale;
                    row["DefencePerScale"] = i.DefencePerScale;
                    row["MaxScale"] = i.MaxScale;
                    row["CanLevelUp"] = i.CanLevelUp;
                    row["LevelUpKindID"] = i.LevelUpKindID;
                    row["LevelUpExperience"] = i.LevelUpExperience;
                    row["OffencePer100Experience"] = i.OffencePer100Experience;
                    row["DefencePer100Experience"] = i.DefencePer100Experience;
                    row["AttackDefaultKind"] = (int) i.AttackDefaultKind;
                    row["AttackTargetKind"] = (int) i.AttackTargetKind;
                    row["CastDefaultKind"] = (int) i.CastDefaultKind;
                    row["CastTargetKind"] = (int) i.CastTargetKind;
                    row["Influences"] = i.Influences.SaveToString();
                    row["zijinshangxian"] = i.zijinshangxian;
                    row.EndEdit();
                    dataSet.Tables["MilitaryKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "MilitaryKind");
                dataSet.Clear();

                new OleDbCommand("Delete from SectionAIDetail", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from SectionAIDetail", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "SectionAIDetail");
                dataSet.Tables["SectionAIDetail"].Rows.Clear();
                storedIds.Clear();
                foreach (SectionAIDetail i in this.AllSectionAIDetails.SectionAIDetails.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["SectionAIDetail"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["OrientationKind"] = i.OrientationKind;
                    row["AutoRun"] = i.AutoRun;
                    row["ValueAgriculture"] = i.ValueAgriculture;
                    row["ValueCommerce"] = i.ValueCommerce;
                    row["ValueTechnology"] = i.ValueTechnology;
                    row["ValueDomination"] = i.ValueDomination;
                    row["ValueMorale"] = i.ValueMorale;
                    row["ValueEndurance"] = i.ValueEndurance;
                    row["ValueTraining"] = i.ValueTraining;
                    row["ValueRecruitment"] = i.ValueRecruitment;
                    row["ValueNewMilitary"] = i.ValueNewMilitary;
                    row["ValueOffensiveCampaign"] = i.ValueOffensiveCampaign;
                    row["AllowInvestigateTactics"] = i.AllowInvestigateTactics;
                    row["AllowOffensiveTactics"] = i.AllowOffensiveTactics;
                    row["AllowPersonTactics"] = i.AllowPersonTactics;
                    row["AllowOffensiveCampaign"] = i.AllowOffensiveCampaign;
                    row["AllowFundTransfer"] = i.AllowFundTransfer;
                    row["AllowFoodTransfer"] = i.AllowFoodTransfer;
                    row["AllowMilitaryTransfer"] = i.AllowMilitaryTransfer;
                    row["AllowFacilityRemoval"] = i.AllowFacilityRemoval;
                    row.EndEdit();
                    dataSet.Tables["SectionAIDetail"].Rows.Add(row);
                }
                adapter.Update(dataSet, "SectionAIDetail");
                dataSet.Clear();

                new OleDbCommand("Delete from Skill", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Skill", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "Skill");
                dataSet.Tables["Skill"].Rows.Clear();
                storedIds.Clear();
                foreach (Skill i in this.AllSkills.Skills.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Skill"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["DisplayRow"] = i.DisplayRow;
                    row["DisplayCol"] = i.DisplayCol;
                    row["Kind"] = i.Kind;
                    row["Level"] = i.Level;
                    row["Combat"] = i.Combat;
                    row["Prerequisite"] = i.Prerequisite;
                    row["Influences"] = i.Influences.SaveToString();
                    row["Conditions"] = i.Conditions.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Skill"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Skill");
                dataSet.Clear();

                new OleDbCommand("Delete from Stratagem", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Stratagem", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Stratagem");
                dataSet.Tables["Stratagem"].Rows.Clear();
                storedIds.Clear();
                foreach (Stratagem i in this.AllStratagems.Stratagems.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Stratagem"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["Combativity"] = i.Combativity;
                    row["Chance"] = i.Chance;
                    row["TechniquePoint"] = i.TechniquePoint;
                    row["Friendly"] = i.Friendly;
                    row["Self"] = i.Self;
                    row["AnimationKind"] = i.AnimationKind;
                    row["Influences"] = i.Influences.SaveToString();
                    row["CastDefault"] = i.CastDefault == null ? 0 : i.CastDefault.ID;
                    row["CastTarget"] = i.CastTarget == null ? 1 : i.CastTarget.ID;
                    row["ArchitectureTarget"] = i.ArchitectureTarget;
                    row["RequireInfluneceToUse"] = i.RequireInfluenceToUse;
                    row.EndEdit();
                    dataSet.Tables["Stratagem"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Stratagem");
                dataSet.Clear();

                new OleDbCommand("Delete from Stunt", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Stunt", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Stunt");
                dataSet.Tables["Stunt"].Rows.Clear();
                storedIds.Clear();
                foreach (Stunt i in this.AllStunts.Stunts.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Stunt"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Combativity"] = i.Combativity;
                    row["Period"] = i.Period;
                    row["Animation"] = i.Animation;
                    row["Influences"] = i.Influences.SaveToString();
                    row["CastConditions"] = i.CastConditions.SaveToString();
                    row["LearnConditions"] = i.LearnConditions.SaveToString();
                    row["AIConditions"] = i.AIConditions.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Stunt"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Stunt");
                dataSet.Clear();

                new OleDbCommand("Delete from Technique", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Technique", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Technique");
                dataSet.Tables["Technique"].Rows.Clear();
                storedIds.Clear();
                foreach (Technique i in this.AllTechniques.Techniques.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Technique"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["DisplayRow"] = i.DisplayRow;
                    row["DisplayCol"] = i.DisplayCol;
                    row["Kind"] = i.Kind;
                    row["Description"] = i.Description;
                    row["PreID"] = i.PreID;
                    row["PostID"] = i.PostID;
                    row["Reputation"] = i.Reputation;
                    row["FundCost"] = i.FundCost;
                    row["PointCost"] = i.PointCost;
                    row["Days"] = i.Days;
                    row["Influences"] = i.Influences.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Technique"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Technique");
                dataSet.Clear();

                new OleDbCommand("Delete from TerrainDetail", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TerrainDetail", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TerrainDetail");
                dataSet.Tables["TerrainDetail"].Rows.Clear();
                storedIds.Clear();
                foreach (TerrainDetail i in this.AllTerrainDetails.TerrainDetails.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TerrainDetail"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["GraphicLayer"] = i.GraphicLayer;
                    row["ViewThrough"] = i.ViewThrough;
                    row["RoutewayBuildFundCost"] = i.RoutewayBuildWorkCost;
                    row["RoutewayActiveFundCost"] = i.RoutewayActiveFundCost;
                    row["RoutewayBuildWorkCost"] = i.RoutewayBuildWorkCost;
                    row["RoutewayConsumptionRate"] = i.RoutewayConsumptionRate;
                    row["FoodDeposit"] = i.FoodDeposit;
                    row["FoodRegainDays"] = i.FoodRegainDays;
                    row["FoodSpringRate"] = i.FoodSpringRate;
                    row["FoodSummerRate"] = i.FoodSummerRate;
                    row["FoodAutumnRate"] = i.FoodAutumnRate;
                    row["FoodWinterRate"] = i.FoodWinterRate;
                    row["FireDamageRate"] = i.FireDamageRate;
                    row.EndEdit();
                    dataSet.Tables["TerrainDetail"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TerrainDetail");
                dataSet.Clear();

                new OleDbCommand("Delete from TextMessage", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TextMessage", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TextMessage");
                dataSet.Tables["TextMessage"].Rows.Clear();
                storedIds.Clear();
                foreach (TextMessage message in this.AllTextMessages.TextMessages.Values)
                {
                    if (storedIds.Contains(message.ID)) continue;
                    storedIds.Add(message.ID);
                    DataRow current = dataSet.Tables["TextMessage"].NewRow();
                    current.BeginEdit();
                    current["ID"] = message.ID;
                    current["CriticalStrike"] = StaticMethods.SaveToString(message.CriticalStrike);
                    current["ReceiveCriticalStrike"] = StaticMethods.SaveToString(message.ReceiveCriticalStrike);
                    current["OutburstAngry"] = StaticMethods.SaveToString(message.OutburstAngry);
                    current["OutburstQuiet"] = StaticMethods.SaveToString(message.OutburstQuiet);
                    current["RecoverFromChaos"] = StaticMethods.SaveToString(message.RecoverFromChaos);
                    current["ResistHarmfulStratagem"] = StaticMethods.SaveToString(message.ResistHarmfulStratagem);
                    current["ResistHelpfulStratagem"] = StaticMethods.SaveToString(message.ResistHelpfulStratagem);
                    current["Rout"] = StaticMethods.SaveToString(message.Rout);
                    current["AntiAttack"] = StaticMethods.SaveToString(message.AntiAttack);
                    current["BreakWall"] = StaticMethods.SaveToString(message.BreakWall);
                    current["CastDeepChaos"] = StaticMethods.SaveToString(message.CastDeepChaos);
                    current["Chaos"] = StaticMethods.SaveToString(message.Chaos);
                    current["CriticalStrikeOnArchitecture"] = StaticMethods.SaveToString(message.CriticalStrikeOnArchitecture);
                    current["DeepChaos"] = StaticMethods.SaveToString(message.DeepChaos);
                    current["DualInitiativeWin"] = StaticMethods.SaveToString(message.DualInitiativeWin);
                    current["DualPassiveWin"] = StaticMethods.SaveToString(message.DualPassiveWin);
                    current["HelpedByStratagem"] = StaticMethods.SaveToString(message.HelpedByStratagem);
                    current["Surround"] = StaticMethods.SaveToString(message.Surround);
                    current["TrappedByStratagem"] = StaticMethods.SaveToString(message.TrappedByStratagem);
                    current.EndEdit();
                    dataSet.Tables["TextMessage"].Rows.Add(current);
                }
                adapter.Update(dataSet, "TextMessage");
                dataSet.Clear();

                new OleDbCommand("Delete from TileAnimation", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TileAnimation", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TileAnimation");
                dataSet.Tables["TileAnimation"].Rows.Clear();
                storedIds.Clear();
                foreach (Animation i in this.AllTileAnimations.Animations.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TileAnimation"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["FrameCount"] = i.FrameCount;
                    row["StayCount"] = i.StayCount;
                    row["Back"] = i.Back;
                    row.EndEdit();
                    dataSet.Tables["TileAnimation"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TileAnimation");
                dataSet.Clear();

                new OleDbCommand("Delete from Title", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Title", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "Title");
                dataSet.Tables["Title"].Rows.Clear();
                storedIds.Clear();
                foreach (Title i in this.AllTitles.Titles.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["Title"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Kind"] = (int)i.Kind;
                    row["Level"] = i.Level;
                    row["Combat"] = i.Combat;
                    row["Name"] = i.Name;
                    row["Description"] = i.Description;
                    row["Prerequisite"] = i.Prerequisite;
                    row["Influences"] = i.Influences.SaveToString();
                    row["Conditions"] = i.Conditions.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Title"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Title");
                dataSet.Clear();

                new OleDbCommand("Delete from TitleKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TitleKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "TitleKind");
                dataSet.Tables["TitleKind"].Rows.Clear();
                storedIds.Clear();
                foreach (TitleKind i in this.AllTitleKinds.TitleKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TitleKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["KName"] = i.Name;
                    row["Combat"] = i.Combat;
                    row["StudyDay"] = i.StudyDay;
                    row.EndEdit();
                    dataSet.Tables["TitleKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TitleKind");
                dataSet.Clear();

                new OleDbCommand("Delete from TroopAnimation", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TroopAnimation", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TroopAnimation");
                dataSet.Tables["TroopAnimation"].Rows.Clear();
                storedIds.Clear();
                foreach (Animation i in this.AllTroopAnimations.Animations.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TroopAnimation"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["FrameCount"] = i.FrameCount;
                    row["StayCount"] = i.StayCount;
                    row.EndEdit();
                    dataSet.Tables["TroopAnimation"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TroopAnimation");
                dataSet.Clear();

                new OleDbCommand("Delete from TroopEventEffect", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TroopEventEffect", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TroopEventEffect");
                dataSet.Tables["TroopEventEffect"].Rows.Clear();
                storedIds.Clear();
                foreach (GameObjects.TroopDetail.EventEffect.EventEffect i in this.AllTroopEventEffects.EventEffects.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TroopEventEffect"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row["Parameter"] = i.Parameter;
                    row["Kind"] = i.Kind.ID;
                    row.EndEdit();
                    dataSet.Tables["TroopEventEffect"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TroopEventEffect");
                dataSet.Clear();

                new OleDbCommand("Delete from TroopEventEffectKind", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from TroopEventEffectKind", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TroopEventEffectKind");
                dataSet.Tables["TroopEventEffectKind"].Rows.Clear();
                storedIds.Clear();
                foreach (GameObjects.TroopDetail.EventEffect.EventEffectKind i in this.AllTroopEventEffectKinds.EventEffectKinds.Values)
                {
                    if (storedIds.Contains(i.ID)) continue;
                    storedIds.Add(i.ID);
                    row = dataSet.Tables["TroopEventEffectKind"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Name"] = i.Name;
                    row.EndEdit();
                    dataSet.Tables["TroopEventEffectKind"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TroopEventEffectKind");
                dataSet.Clear();

                new OleDbCommand("Delete from GameParameters", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from GameParameters", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "GameParameters");
                dataSet.Tables["GameParameters"].Rows.Clear();
                foreach (FieldInfo i in typeof(Parameters).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if (i.IsLiteral) continue;

                    row = dataSet.Tables["GameParameters"].NewRow();
                    row.BeginEdit();
                    row["Name"] = i.Name;
                    try
                    {
                        row["Value"] = (int)i.GetValue(null);
                    }
                    catch (InvalidCastException)
                    {
                        try
                        {
                            row["Value"] = (double)i.GetValue(null);
                        }
                        catch (InvalidCastException)
                        {
                            row["Value"] = i.GetValue(null).ToString();
                        }
                    }
                    row.EndEdit();
                    dataSet.Tables["GameParameters"].Rows.Add(row);
                }
                adapter.Update(dataSet, "GameParameters");
                dataSet.Clear();

                new OleDbCommand("Delete from GlobalVariables", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from GlobalVariables", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                adapter.Fill(dataSet, "GlobalVariables");
                dataSet.Tables["GlobalVariables"].Rows.Clear();
                foreach (FieldInfo i in typeof(GlobalVariables).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if (i.IsLiteral) continue;

                    if (GlobalVariables.getFieldsExcludedFromSave().Contains(i.Name)) continue;

                    row = dataSet.Tables["GlobalVariables"].NewRow();
                    row.BeginEdit();
                    row["Name"] = i.Name;
                    try
                    {
                        row["Value"] = (int)i.GetValue(null);
                    }
                    catch (InvalidCastException)
                    {
                        try
                        {
                            row["Value"] = (double)i.GetValue(null);
                        }
                        catch (InvalidCastException)
                        {
                            row["Value"] = i.GetValue(null).ToString();
                        }
                    }
                    row.EndEdit();
                    dataSet.Tables["GlobalVariables"].Rows.Add(row);
                }
                adapter.Update(dataSet, "GlobalVariables");
                dataSet.Clear();

                selectConnection.Close();
            }
        }
    }
}

