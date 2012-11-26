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
        public AnimationTable AllTroopAnimations = new AnimationTable();
        public EventEffectKindTable AllTroopEventEffectKinds = new EventEffectKindTable();
        public EventEffectTable AllTroopEventEffects = new EventEffectTable();
        public GameObjects.ArchitectureDetail.EventEffect.EventEffectKindTable AllEventEffectKinds = new GameObjects.ArchitectureDetail.EventEffect.EventEffectKindTable();
        public GameObjects.ArchitectureDetail.EventEffect.EventEffectTable AllEventEffects = new GameObjects.ArchitectureDetail.EventEffect.EventEffectTable();
        public CombatNumberGenerator NumberGenerator = new CombatNumberGenerator();
        public TroopAnimation TroopAnimations = new TroopAnimation();

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
                this.AllInfluences.AddInfluence(influence);
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
            reader = new OleDbCommand("Select * From Title", connection).ExecuteReader();
            while (reader.Read())
            {
                Title title = new Title();
                title.ID = (short)reader["ID"];
                title.Kind = (TitleKind)((short)reader["Kind"]);
                title.Level = (short)reader["Level"];
                title.Combat = (bool)reader["Combat"];
                title.Name = reader["Name"].ToString();
                title.Influences.LoadFromString(this.AllInfluences, reader["Influences"].ToString());
                title.Conditions.LoadFromString(this.AllConditions, reader["Conditions"].ToString());
                this.AllTitles.AddTitle(title);
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
                militaryKind.AfraidOfFire = (bool)reader["AfraidOfFire"];
                militaryKind.Unique = (bool)reader["Unique"];
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
                kind9.Days = (short)reader["Days"];
                kind9.CoolDown = (short)reader["CoolDown"];
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
    }
}

