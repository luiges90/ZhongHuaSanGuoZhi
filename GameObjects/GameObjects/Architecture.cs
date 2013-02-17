namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.ArchitectureDetail;
    using GameObjects.FactionDetail;
    using GameObjects.Influences;
    using GameObjects.MapDetail;
    using GameObjects.PersonDetail;
    using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    //using GameFreeText;

    public class Architecture : GameObject
    {
        private int militaryPopulation=0;
        internal bool TodayPersonArriveNote=false;
        private int agriculture;
        public int CaptionID=0;
        //private bool shoudongluyongshibai=false;
        public  bool HasManualHire = false;

        public Dictionary<int, LinkNode> AIAllLinkNodes = new Dictionary<int, LinkNode>();
        public ArchitectureList AILandLinks = new ArchitectureList();
        public string AILandLinksString;
        private Queue<AILinkProcedureDetail> AILinkProcedureDetails = new Queue<AILinkProcedureDetail>();
        public ArchitectureList AIWaterLinks = new ArchitectureList();
        public string AIWaterLinksString;
        public GameArea ArchitectureArea = new GameArea();
        private bool autoHiring;
        public bool AutoRefillFoodInLongViewArea;
        private bool autoRewarding;
        private bool autoSearching;
        private bool autoWorking;
        private GameArea baseFoodSurplyArea;
        public Faction BelongedFaction = null;
        public Section BelongedSection = null;
        public MilitaryList BeMergedMilitaryList = new MilitaryList();
        public GameObjectList BuildableFacilityKindList = new GameObjectList();
        private int buildingDaysLeft;
        private int buildingFacility = -1;
        public MilitaryList CampaignMilitaryList = new MilitaryList();
        public ArchitectureList ChangeCapitalArchitectureList = new ArchitectureList();
        public InfluenceTable Characteristics = new InfluenceTable();
        public ArchitectureList ClosestArchitectures;
        public int CombativityOfRecruitment = 50;
        private int commerce;
        private GameArea contactArea;
        public bool CriticalHostile;
        public bool DayAvoidInfluenceByBattle;
        public bool DayAvoidInternalDecrementOnBattle;
        public bool DayAvoidPopulationEscape;
        public int DayLearnTitleDay;
        public bool DayLocationLoyaltyNoChange;
        public float DayRateIncrementOfInternal;
        public CombatNumberItemList DecrementNumberList = new CombatNumberItemList(CombatNumberDirection.下);
        public Legion DefensiveLegion;
        public int DefensiveLegionID;
        private int domination;
        private int endurance;
        public FacilityList Facilities = new FacilityList();
        private bool facilityEnabled;
        private int food;
        public bool FrontLine;
        private int fund;
        internal List<FundPack> FundPacks = new List<FundPack>();
        private bool hireFinished;
        public bool HostileLine;
        public CombatNumberItemList IncrementNumberList = new CombatNumberItemList(CombatNumberDirection.上);
        public int IncrementOfAgricultureCeiling;
        public int IncrementOfAgriculturePerDay;
        public int IncrementOfCombativityInViewArea;
        public int IncrementOfCommerceCeiling;
        public int IncrementOfCommercePerDay;
        public int IncrementOfDominationPerDay;
        public int IncrementOfEnduranceCeiling;
        public int IncrementOfDominationCeiling;
        public int IncrementOfMoraleCeiling;
        public int IncrementOfEndurancePerDay;
        public int IncrementOfFacilityPositionCount;
        public int IncrementOfFactionReputationPerDay;
        public int IncrementOfFactionTechniquePointPerDay;
        public int IncrementOfMonthFood;
        public int IncrementOfMonthFund;
        public int IncrementOfMoralePerDay;
        public int IncrementOfTechnologyCeiling;
        public int IncrementOfTechnologyPerDay;
        public int IncrementOfViewRadius;
        public int IncrementOfFundCeiling = 0;
        public int IncrementOfFoodCeiling = 0;
        private int informationCoolDown;
        private bool isStrategicCenter;
        internal  bool JustAttacked = false;
        private ArchitectureKind kind;
        public MilitaryList LevelUpMilitaryList = new MilitaryList();
        public State LocationState;
        private GameArea longViewArea = null;
        public MilitaryList MergeMilitaryList = new MilitaryList();
        public MilitaryList Militaries = new MilitaryList();
        private int morale;
        public int MoraleOfRecruitment = 50;
        public int MultipleOfRecovery = 1;
        public int MultipleOfTraining = 1;
        public MilitaryKindList NewMilitaryKindList = new MilitaryKindList();
        public bool NoCounterStrikeInArchitecture;
        public bool orientationFrontLine;
        public ArchitectureList OtherArchitectureList = new ArchitectureList();
        private int PathRoutewayID = -1;
        public Architecture PlanArchitecture;
        public int PlanArchitectureID;
        public FacilityKind PlanFacilityKind;
        public int PlanFacilityKindID;
        private int population;
        internal List<PopulationPack> PopulationPacks = new List<PopulationPack>();
        public MilitaryKindTable PrivateMilitaryKinds = new MilitaryKindTable();
        public float RateIncrementOfPopulationCeiling;
        public float RateIncrementOfMonthFood;
        public float RateIncrementOfMonthFund;
        public float RateIncrementOfNewBubingTroopDefence;
        public float RateIncrementOfNewBubingTroopOffence;
        public float RateIncrementOfNewNubingTroopDefence;
        public float RateIncrementOfNewNubingTroopOffence;
        public float RateIncrementOfNewQibingTroopDefence;
        public float RateIncrementOfNewQibingTroopOffence;
        public float RateIncrementOfNewQixieTroopDefence;
        public float RateIncrementOfNewQixieTroopOffence;
        public float RateIncrementOfNewShuijunTroopDefence;
        public float RateIncrementOfNewShuijunTroopOffence;
        public double RateIncrementOfPopulationDevelop;
        public float RateOfClearField = 1f;
        public float RateOfConvincePerson = 1f;
        public float RateOfDestroyArchitecture = 1f;
        public float RateOfFacilityEnduranceDown = 1f;
        public float RateOfFoodReduceRate = 1f;
        public float RateOfGossipArchitecture = 1f;
        public float RateOfHirePerson = 1f;
        public float RateOfInstigateArchitecture = 1f;
        public float RateOfInternal = 1f;
        public float RateOfNewBubingMilitaryFundCost = 1f;
        public float RateOfNewNubingMilitaryFundCost = 1f;
        public float RateOfNewQibingMilitaryFundCost = 1f;
        public float RateOfNewQixieMilitaryFundCost = 1f;
        public float RateOfNewShuijunMilitaryFundCost = 1f;
        public float RateOfRewardPerson = 1f;
        public float RateOfRoutewayBuildFundCost = 1f;
        public float RateOfSpyArchitecture = 1f;
        public int RecentlyAttacked;
        public int RecentlyBreaked;
        public MilitaryList RecruitmentMilitaryList = new MilitaryList();
        public CaptiveList RedeemCaptiveList = new CaptiveList();
        public GameObjectList ResetDiplomaticRelationList = new GameObjectList();
        public PersonList RewardPersonList = new PersonList();
        public Troop RobberTroop;
        public int RobberTroopID;
        private Dictionary<int, Architecture> RoutewayDestinationArchitectures = new Dictionary<int, Architecture>();
        private Queue<RoutewayProcedureDetail> RoutewayProcedures = new Queue<RoutewayProcedureDetail>();
        public RoutewayList Routeways = new RoutewayList();
        public MilitaryList ShelledMilitaryList = new MilitaryList();
        private bool showNumber;
        internal List<SpyPack> SpyPacks = new List<SpyPack>();
        private float surplusRate;
        private int technology;
        public SpyMessage TodayNewMilitarySpyMessage;
        public SpyMessage TodayNewTroopSpyMessage;
        public int TotalFriendlyForce;
        public int TotalHostileForce;
        public MilitaryList TrainingMilitaryList = new MilitaryList();
        public ArchitectureList TransferArchitectureList = new ArchitectureList();
        public Architecture TransferFoodArchitecture;
        public int TransferFoodArchitectureID;
        public Architecture TransferFundArchitecture;
        public int TransferFundArchitectureID;
        public bool TroopershipAvailable;
        private GameArea viewArea = null;
        public zainanlei zainan = new zainanlei();
        public Texture2D CaptionTexture;
        public bool noFactionFrontline;
        public int captureChance;
        public int noEscapeChance;
        public int captiveLoyaltyFallThreshold;
        public int captiveLoyaltyExtraFall;
        public bool noFundToSustainFacility;
        public int facilityEnduranceIncrease;
        public Dictionary<int, int> disasterChanceDecrease = new Dictionary<int, int>();
        public Dictionary<int, int> disasterChanceIncrease = new Dictionary<int, int>();
        public Dictionary<int, float> disasterDamageRateDecrease = new Dictionary<int, float>();
        public float militaryPopulationRateIncrease;
        public float enduranceDecreaseRateDrop;

        public float ExperienceRate;

        public float facilityConstructionTimeRateDecrease = 0;

        public event BeginRecentlyAttacked OnBeginRecentlyAttacked;

        public event FacilityCompleted OnFacilityCompleted;

        public event fashengzainan Onfashengzainan;

        public event HirePerson OnHirePerson;

        public event MilitaryCreate OnMilitaryCreate;

        public event PopulationEnter OnPopulationEnter;

        public event PopulationEscape OnPopulationEscape;

        public event ReleaseCaptiveAfterOccupied OnReleaseCaptiveAfterOccupied;

        public event RewardPersons OnRewardPersons;

        public CaptiveList Captives
        {
            get
            {
                CaptiveList result = new CaptiveList();
                foreach (Captive i in base.Scenario.Captives)
                {
                    if (i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList Persons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList MovingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Moving && i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList NoFactionPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.NoFaction && i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList NoFactionMovingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.NoFactionMoving && i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList feiziliebiao
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Princess && i.LocationArchitecture == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList zhenzaiWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.赈灾 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList AgricultureWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.农业 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList CommerceWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.商业 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList TechnologyWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.技术 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList DominationWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.统治 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList MoraleWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.民心 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList EnduranceWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.耐久 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList TrainingWorkingPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if (i.Status == PersonStatus.Normal && i.LocationArchitecture == this && i.WorkKind == ArchitectureWorkKind.训练 && i.LocationTroop == null)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public MilitaryList ZhengzaiBuchongDeBiandui()
        {
            MilitaryList zhengzaiBuchongDeBiandui = new MilitaryList();
            foreach (Military military in this.Militaries )
            {
                if (military.RecruitmentPerson != null)
                {
                    zhengzaiBuchongDeBiandui.AddMilitary(military);
                }
            }
            return zhengzaiBuchongDeBiandui;
        }

        public int MilitaryPopulation
        {
            get
            {
                return this.militaryPopulation;
            }
            set
            {
                this.militaryPopulation = value;
            }
        }

        private void AddAllAILink(int level, int levelMax, Architecture root, List<Architecture> path)
        {
            path.Add(root);
            if (root != this)
            {
                double num = 0.0;
                for (int i = 1; i < path.Count; i++)
                {
                    num += base.Scenario.GetDistance(path[i - 1].ArchitectureArea, path[i].ArchitectureArea);
                }
                if (!this.AIAllLinkNodes.ContainsKey(root.ID))
                {
                    LinkNode node = new LinkNode();
                    node.A = root;
                    node.Level = level;
                    foreach (Architecture architecture in path)
                    {
                        node.Path.Add(architecture);
                    }
                    node.Distance = num;
                    this.AIAllLinkNodes.Add(root.ID, node);
                }
                else if ((this.AIAllLinkNodes[root.ID].Level == level) && (this.AIAllLinkNodes[root.ID].Distance > num))
                {
                    this.AIAllLinkNodes[root.ID].Distance = num;
                    this.AIAllLinkNodes[root.ID].Path.Clear();
                    foreach (Architecture architecture in path)
                    {
                        this.AIAllLinkNodes[root.ID].Path.Add(architecture);
                    }
                }
                else if (this.AIAllLinkNodes[root.ID].Level > level)
                {
                    this.AIAllLinkNodes[root.ID].Level = level;
                    this.AIAllLinkNodes[root.ID].Path.Clear();
                    foreach (Architecture architecture in path)
                    {
                        this.AIAllLinkNodes[root.ID].Path.Add(architecture);
                    }
                }
            }
            if (level < levelMax)
            {
                foreach (Architecture architecture in root.GetAILinks())
                {
                    this.AILinkProcedureDetails.Enqueue(new AILinkProcedureDetail(level + 1, architecture, path));
                }
            }
        }

        public String BuildingFacilityName
        {
            get
            {
                int type = BuildingFacility;
                GameObjectList fkl = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKindList();

                foreach (FacilityKind i in fkl)
                {
                    if (type == i.ID)
                    {
                        return i.Name;
                    }
                }
                return "——";
            }
        }

        public String SheshiMiaoshu
        {
            get
            {
                int type = BuildingFacility;
                GameObjectList fkl = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKindList();

                foreach (FacilityKind i in fkl)
                {
                    if (type == i.ID)
                    {
                        return i.Name;
                    }
                }

                if (this.FacilityPositionCount>0 && this.FacilityPositionLeft <= 0)
                {
                    return "已建满";
                }

                return this.FacilityPositionString ;
            }
        }



        public void AddBaseSupplyingArchitecture()
        {
            foreach (Point point in this.BaseFoodSurplyArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddSupplyingArchitecture(this);
                }
            }
        }

        private void AddCloseRoutewayDestinationArchitectures(Architecture a, float previousrate)
        {
            foreach (Routeway routeway in a.Routeways)
            {
                float minRate = 1f;
                if ((routeway.EndArchitecture != null) && routeway.IsActiveInArea(routeway.EndArchitecture.GetRoutewayStartArea(), out minRate))
                {
                    float rate = previousrate * (1f - (minRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures));
                    if (rate > routeway.EndArchitecture.surplusRate)
                    {
                        routeway.EndArchitecture.surplusRate = rate;
                        routeway.EndArchitecture.PathRoutewayID = routeway.ID;
                        if (!this.RoutewayDestinationArchitectures.ContainsKey(routeway.EndArchitecture.ID))
                        {
                            this.RoutewayDestinationArchitectures.Add(routeway.EndArchitecture.ID, routeway.EndArchitecture);
                        }
                        this.RoutewayProcedures.Enqueue(new RoutewayProcedureDetail(routeway.EndArchitecture, rate));
                    }
                }
            }
        }

        public void AddFundPack(int number, int days)
        {
            FundPack item = new FundPack(number, days);
            this.FundPacks.Add(item);
        }

        private void AddMessageToTodayMilitaryScaleSpyMessage(Military m)
        {
            this.CreateMilitaryScaleSpyMessage(m);
        }

        private void AddMessageToTodayNewMilitarySpyMessage(Military m)
        {
            if (this.TodayNewMilitarySpyMessage == null)
            {
                this.TodayNewMilitarySpyMessage = this.CreateNewMilitarySpyMessage(m);
            }
            else
            {
                this.TodayNewMilitarySpyMessage.Message3 = this.TodayNewMilitarySpyMessage.Message3 + "," + m.Name;
            }
        }

        private void AddMessageToTodayNewTroopSpyMessage(Troop t, bool hand)
        {
            if (this.TodayNewTroopSpyMessage == null)
            {
                this.TodayNewTroopSpyMessage = this.CreateNewTroopSpyMessage(t, hand);
            }
            else
            {
                this.TodayNewTroopSpyMessage.Message3 = this.TodayNewTroopSpyMessage.Message3 + "," + t.DisplayName;
            }
        }

        public void AddMilitary(Military military)
        {
            this.Militaries.AddMilitary(military);
            military.BelongedArchitecture = this;
        }

        private PersonList SelectSubOfficersToTroop(Troop t)
        {
            int personCnt = 1;
            PersonList result = new PersonList();
            result.Add(t.Leader);
            if (t.TroopIntelligence < (0x4b - t.Leader.Calmness))
            {
                foreach (Person person in this.Persons)
                {
                    if (person.WaitForFeiZi != null) continue;
                    if ((!person.Selected && (person.Intelligence >= (0x4b - t.Leader.Calmness))) && (!t.Persons.HasGameObject(person) && ((((person.Strength < t.TroopStrength) && ((person.Intelligence - t.TroopIntelligence) >= 10)) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        result.Add(person);
                        personCnt++;
                        break;
                    }
                }
            }
            if (t.TroopStrength < 0x4b)
            {
                foreach (Person person in this.Persons)
                {
                    if (person.WaitForFeiZi != null) continue;
                    if ((!person.Selected && (person.Strength >= 0x4b)) && ((!t.Persons.HasGameObject(person) && (person.ClosePersons.IndexOf(t.Leader.ID) >= 0)) && ((((person.Strength - t.TroopStrength) >= 10) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        result.Add(person);
                        personCnt++;
                        break;
                    }
                }
            }
            if (t.TroopCommand < 0x4b)
            {
                foreach (Person person in this.Persons)
                {
                    if (person.WaitForFeiZi != null) continue;
                    if ((!person.Selected && (person.Command >= 0x4b)) && ((!t.Persons.HasGameObject(person) && (person.ClosePersons.IndexOf(t.Leader.ID) >= 0)) && ((((person.Command - t.TroopCommand) >= 10) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        result.Add(person);
                        personCnt++;
                        break;
                    }
                }
            }
            foreach (Person person in this.Persons)
            {
                if (person.WaitForFeiZi != null) continue;
                if ((!person.Selected && !t.Persons.HasGameObject(person)) && ((person.FightingForce < t.Leader.FightingForce) && !person.HasLeaderValidCombatTitle))
                {
                    int incrementPerDayOfCombativity = t.IncrementPerDayOfCombativity;
                    bool immunityOfCaptive = t.ImmunityOfCaptive;
                    int routIncrementOfCombativity = t.RoutIncrementOfCombativity;
                    int attackDecrementOfCombativity = t.AttackDecrementOfCombativity;
                    int count = t.CombatMethods.Count;
                    int chanceIncrementOfCriticalStrike = t.ChanceIncrementOfCriticalStrike;
                    int chanceDecrementOfCriticalStrike = t.ChanceDecrementOfCriticalStrike;
                    int chanceIncrementOfChaosAfterCriticalStrike = t.ChanceIncrementOfChaosAfterCriticalStrike;
                    int avoidSurroundedChance = t.AvoidSurroundedChance;
                    int chaosAfterSurroundAttackChance = t.ChaosAfterSurroundAttackChance;
                    int chanceIncrementOfStratagem = t.ChanceIncrementOfStratagem;
                    int chanceDecrementOfStratagem = t.ChanceDecrementOfStratagem;
                    int chanceIncrementOfChaosAfterStratagem = t.ChanceIncrementOfChaosAfterStratagem;
                    foreach (Skill s in person.Skills.GetSkillList())
                    {
                        s.Influences.PurifyInfluence(this, Applier.Skill, s.ID);
                    }
                    if (person.PersonalTitle != null)
                    {
                        person.PersonalTitle.Influences.PurifyInfluence(this, Applier.PersonalTitle, 0);
                    }
                    if (person.CombatTitle != null)
                    {
                        person.CombatTitle.Influences.PurifyInfluence(this, Applier.CombatTitle, 0);
                    }
                    person.ApplySkills();
                    person.ApplyTitles();
                    if (((((((t.IncrementPerDayOfCombativity > incrementPerDayOfCombativity) || (t.ImmunityOfCaptive != immunityOfCaptive)) || ((t.RoutIncrementOfCombativity > routIncrementOfCombativity) || (t.AttackDecrementOfCombativity > attackDecrementOfCombativity))) || ((t.CombatMethods.Count > count) || (((t.TroopStrength >= 70) && (t.ChanceIncrementOfCriticalStrike > chanceIncrementOfCriticalStrike)) && (t.ChanceIncrementOfCriticalStrike <= 50)))) || (((((t.TroopCommand >= 70) && (t.ChanceDecrementOfCriticalStrike > chanceDecrementOfCriticalStrike)) && (t.ChanceDecrementOfCriticalStrike <= 50)) || (((t.ChanceIncrementOfCriticalStrike >= 10) && (t.ChanceIncrementOfChaosAfterCriticalStrike > chanceIncrementOfChaosAfterCriticalStrike)) && (t.ChanceIncrementOfChaosAfterCriticalStrike <= 100))) || (((t.AvoidSurroundedChance <= 80) && (t.AvoidSurroundedChance > avoidSurroundedChance)) || ((t.ChaosAfterSurroundAttackChance <= 20) && (t.ChaosAfterSurroundAttackChance > chaosAfterSurroundAttackChance))))) || ((((t.TroopIntelligence >= 70) && (t.ChanceIncrementOfStratagem > chanceIncrementOfStratagem)) && (t.ChanceIncrementOfStratagem <= 30)) || (((t.TroopIntelligence >= 70) && (t.ChanceDecrementOfStratagem > chanceDecrementOfStratagem)) && (t.ChanceDecrementOfStratagem <= 30)))) || (((t.TroopIntelligence >= 0x55) && (t.ChanceIncrementOfChaosAfterStratagem > chanceIncrementOfChaosAfterStratagem)) && (t.ChanceIncrementOfChaosAfterStratagem <= 100)))
                    {
                        person.Selected = true;
                        result.Add(person);
                        personCnt++;
                    }
                }
                if (personCnt >= 5) break;
            }
            return result;
        }

        internal void AddPopulationPack(int days, int population)
        {
            PopulationPack item = new PopulationPack(days, population);
            this.PopulationPacks.Add(item);
        }

        internal void AddSpyPack(Person person, int days)
        {
            SpyPack item = new SpyPack(person, days);
            this.SpyPacks.Add(item);
        }

        public bool AgricultureAvail()
        {
            return (this.Kind.HasAgriculture && this.HasPerson());
        }

        public void AI()
        {
            this.PrepareAI();
            this.AIHouGong();
            this.AIExecute();
            this.ClearFieldAI();
            this.AITreasure();
            this.AITrade();
            this.AIMilitary();
            this.AIFacility();
            this.DiplomaticRelationAI();
            this.AICampaign();
            this.OutsideTacticsAI();
            this.AIWork(false);
            this.InsideTacticsAI();
            this.AITransfer();
			ExtensionInterface.call("AIArchitecture", new Object[] { this.Scenario, this });
        }

        private void AIExecute()
        {
            if (base.Scenario.IsPlayer(this.BelongedFaction)) return;
            if (GlobalVariables.AIExecutionRate <= 0) return;

            //AI for executing officers. High ambition and low personal loyalty leads to higher chance of execution (rate lower => higher chance)
            int uncruelty = this.BelongedFaction.Leader.Uncruelty;
            if (uncruelty > Parameters.AIExecuteMaxUncreulty) return;

            //int leaderExecutionRate = uncruelty <= 2 ? 5 : uncruelty * uncruelty * uncruelty * 2;
            //int leaderExecutionRate = uncruelty * uncruelty * uncruelty * 4;
            foreach (Captive i in this.Captives)
            {
                if ((!i.CaptivePerson.RecruitableBy(this.BelongedFaction, (int) ((uncruelty - 2) * Parameters.AIExecutePersonIdealToleranceMultiply)) || this.BelongedFaction.Leader.HatedPersons.Contains(i.CaptivePersonID)) &&
                    GameObject.Random((int)(uncruelty * uncruelty * (GlobalVariables.AIExecuteBetterOfficer ? 100000.0 / i.CaptivePerson.Merit : i.CaptivePerson.Merit / 100000.0)
                        * (100.0 / GlobalVariables.AIExecutionRate))) == 0)  //处斩几率修改系数就可以，可设为小数
                {
                    if (!this.BelongedFaction.Leader.hasStrainTo(i.CaptivePerson))
                    {
                        
                        this.Scenario.GameScreen.xianshishijiantupian(this.Scenario.NeutralPerson, this.BelongedFaction.Leader.Name, "KillCaptive", "chuzhan.jpg", "chuzhan.wav", i.CaptivePerson.Name, true);

                        i.CaptivePerson.execute(this.BelongedFaction);

                        i.Clear();
                        break;
                    }
                }
            }
            /*foreach (Person i in this.Persons)
            {
                if (!i.RecruitableBy(this.BelongedFaction) &&
                    GameObject.Random((int)(leaderExecutionRate / 2 * (100000.0 / i.Merit))) == 0)
                {
                    i.execute(this.BelongedFaction.Leader);
                    break;
                }
            }*/
        }

        private void AIExtension()
        {
            if (this.BuildingFacility < 0)
            {
                foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKindList().GetRandomList())
                {
                    bool isExtension = false;
                    foreach (Influence i in kind.Influences.Influences.Values)
                    {
                        if (i.Kind.ID == 1000 || i.Kind.ID == 1001 || i.Kind.ID == 1002 || i.Kind.ID == 1003 || i.Kind.ID == 1020 || i.Kind.ID == 1050)
                        {
                            isExtension = true;
                            break;
                        }
                    }
                    if (isExtension){
                        if (this.BuildingFacility >= 0)
                        {
                            continue;
                        }
                        if (!(!kind.PopulationRelated || this.Kind.HasPopulation))
                        {
                            continue;
                        }
                        if (((kind.PointCost > this.BelongedFaction.TotalTechniquePoint) || (kind.TechnologyNeeded > this.Technology)))
                        {
                            continue;
                        }
                        if (kind.UniqueInArchitecture && this.ArchitectureHasFacilityKind(kind.ID))
                        {
                            continue;
                        }
                        if (this.FacilityPositionLeft < kind.PositionOccupied)
                        {
                            continue;
                        }
                        if (kind.UniqueInFaction && this.FactionHasFacilityKind(kind.ID))
                        {
                            continue;
                        }
                        bool conditionSatisfied = true;
                        foreach (Conditions.Condition j in kind.GetConditionList())
                        {
                            if (!j.CheckCondition(this))
                            {
                                conditionSatisfied = false;
                                break;
                            }
                        }
                        if (!conditionSatisfied)
                        {
                            continue;
                        }
                        if (kind.FundCost <= this.Fund)
                        {
                            FacilityKind facilityKind = kind;
                            this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                            this.BeginToBuildAFacility(facilityKind);
                        }
                        else if ((kind.FundCost - (this.Fund - this.EnoughFund)) / this.ExpectedFund + 1 <= kind.Days / 15)
                        {
                            this.PlanFacilityKind = kind;
                            if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                            {
                                this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                            }
                        }
                    }
                }
            }
        }

        private void AIFacility()
        {
            AIExtension();
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BuildingFacility < 0) && this.FacilityPositionCount > 0)
            {
                if (this.PlanFacilityKind != null)
                {
                    if (this.Technology >= this.PlanFacilityKind.TechnologyNeeded)
                    {
                        if ((this.Fund >= this.PlanFacilityKind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.DepositTechniquePointForFacility(this.PlanFacilityKind.PointCost);
                            this.BeginToBuildAFacility(this.PlanFacilityKind);
                            this.PlanFacilityKind = null;
                        }
                        else if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                    else
                    {
                        this.PlanFacilityKind = null;
                    }
                }
                else
                {
                    //remove useless facilities
                    if (this.BelongedSection != null && this.BelongedSection.AIDetail.AllowFacilityRemoval)
                    {
                        foreach (Facility i in this.Facilities)
                        {
                            if (i.Kind.AIValue(this) < 0 && !i.Kind.bukechaichu)
                            {
                                if (this.FacilityEnabled)
                                {
                                    i.Influences.PurifyInfluence(this, Applier.Facility, i.ID);
                                }
                                this.Facilities.Remove(i);
                                base.Scenario.Facilities.Remove(i);
                                break;
                            }
                        }
                    }
                    //choose facilities
                    double maxValue = double.MinValue;
                    FacilityKind toBuild = null;
                    List<Facility> toDestroy = new List<Facility>();
                    List<Facility> realToDestroy = new List<Facility>();
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKindList())
                    {
                        if (kind.bukechaichu) continue;
                        if (!(!kind.PopulationRelated || this.Kind.HasPopulation))
                        {
                            continue;
                        }
                        if (kind.UniqueInArchitecture && this.ArchitectureHasFacilityKind(kind.ID))
                        {
                            continue;
                        }
                        if (kind.UniqueInFaction && this.FactionHasFacilityKind(kind.ID))
                        {
                            continue;
                        }
                        foreach (Conditions.Condition i in kind.GetConditionList())
                        {
                            if (!i.CheckCondition(this))
                            {
                                continue;
                            }
                        }
                        if (kind.TechnologyNeeded > this.Technology)
                        {
                            continue;
                        }
                        double value = kind.AIValue(this);
                        if (value > 0)
                        {
                            int fundMonthToWait = (kind.FundCost - (this.Fund - this.EnoughFund)) / this.ExpectedFund + 1;
                            if (value > maxValue && GameObject.Chance((int) (100 - fundMonthToWait * Parameters.AIFacilityFundMonthWaitParam)))
                            {
                                if (this.FacilityPositionLeft < kind.PositionOccupied)
                                {
                                    if (this.BelongedSection.AIDetail.AllowFacilityRemoval)
                                    {
                                        int fpl = this.FacilityPositionLeft;
                                        toDestroy.Clear();
                                        foreach (Facility f in this.Facilities.GetRandomList())
                                        {
                                            if (value > f.Kind.AIValue(this) * Parameters.AIFacilityDestroyValueRate && !f.Kind.bukechaichu)
                                            {
                                                toDestroy.Add(f);
                                                fpl += f.Kind.PositionOccupied;
                                                if (fpl >= kind.PositionOccupied)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        if (fpl >= kind.PositionOccupied)
                                        {
                                            maxValue = value;
                                            toBuild = kind;
                                            realToDestroy = toDestroy;
                                        }
                                    }
                                }
                                else
                                {
                                    maxValue = value;
                                    toBuild = kind;
                                }
                            }
                        }
                    }
                    if (toBuild != null)
                    {
                        //if no space and the facility is good enough than others, remove others
                        foreach (Facility f in realToDestroy)
                        {
                            if (this.FacilityEnabled)
                            {
                                f.Influences.PurifyInfluence(this, Applier.Facility, f.ID);
                            }
                            this.Facilities.Remove(f);
                            base.Scenario.Facilities.Remove(f);
                        }
                        //actually build it, or put to plan if fund is not enough
                        if ((this.Fund >= toBuild.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= toBuild.PointCost))
                        {
                            FacilityKind facilityKind = toBuild;
                            this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                            this.BeginToBuildAFacility(facilityKind);
                        }
                        else
                        {
                            this.PlanFacilityKind = toBuild;
                            if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                            {
                                this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                            }

                        }
                    }
                    /*List<FacilityKind> list3 = new List<FacilityKind>();
                    int facilityPositionLeft = this.FacilityPositionLeft;
                    int iD = 10;
                    int num3 = 0;
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (((kind.ID > iD) && ((kind.ID / 10) == 1)) && (kind.TechnologyNeeded < this.Technology))
                        {
                            iD = kind.ID;
                        }
                        if (((kind.ID > num3) && ((kind.ID / 10) == 0)) && (kind.TechnologyNeeded < this.Technology))
                        {
                            num3 = kind.ID;
                        }
                    }
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (((kind.rongna > 0) || (((kind.ID / 10) == 0) && (kind.ID != num3))) || (((kind.ID / 10) == 1) && (kind.ID != iD)))
                        {
                            continue;
                        }
                        if ((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((this.Technology >= kind.TechnologyNeeded) && (facilityPositionLeft >= kind.PositionOccupied)))
                            && ((!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID)) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID))))
                            && ((kind.FrontLine && ((this.HostileLine || (this.FrontLine && GameObject.Chance(50))) || (!this.FrontLine && GameObject.Chance(10)))) || (!kind.FrontLine && ((!this.FrontLine || (!this.HostileLine && GameObject.Chance(50))) || (this.HostileLine && GameObject.Chance(5))))))
                        {
                            list.Add(kind);
                            if ((this.Fund >= kind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= kind.PointCost))
                            {
                                list2.Add(kind);
                            }
                        }
                    }
                    if (facilityPositionLeft <= 0)
                    {
                        foreach (Facility facility in this.Facilities.GetList())
                        {
                            if ((((this.Technology > facility.TechnologyNeeded) && this.FacilityIsPossibleOverTechnology(facility.TechnologyNeeded))
                                && ((this.Fund > (facility.FundCost * 10)) && (this.BelongedFaction.TechniquePoint > (facility.PointCost * 10))))
                                && (GameObject.Random(facility.Days * facility.PositionOccupied) < 20)
                                && !facility.Kind.bukechaichu)
                            {
                                if (list.IndexOf(facility.Kind) >= 0)
                                {
                                    continue;
                                }
                                list3.Add(facility.Kind);
                                if (this.FacilityEnabled)
                                {
                                    facility.Influences.PurifyInfluence(this);
                                }
                                this.Facilities.Remove(facility);
                                base.Scenario.Facilities.Remove(facility);
                            }
                        }
                        if (list3.Count == 0)
                        {
                            return;
                        }
                        facilityPositionLeft = this.FacilityPositionLeft;
                    }
                    if (list2.Count > 0)
                    {
                        FacilityKind facilityKind = list2[GameObject.Random(list2.Count)];
                        this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                        this.BeginToBuildAFacility(facilityKind);
                    }
                    else if (list.Count > 0)
                    {
                        this.PlanFacilityKind = list[GameObject.Random(list.Count)];
                        if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }*/
                }
            }
        }

        private void AIHouGong()
        {
            if (base.Scenario.IsPlayer(this.BelongedFaction)) return;
            if (this.HasHostileTroopsInView()) return;
            if (GlobalVariables.getChildrenRate <= 0) return;
            Person leader = this.BelongedFaction.Leader;
            int uncruelty = leader.Uncruelty;
            //build hougong
            int unAmbition = Enum.GetNames(typeof(PersonAmbition)).Length - (int)leader.Ambition;
            if (this.BelongedFaction.meinvkongjian() - this.BelongedFaction.feiziCount() <= 0 && (this.BuildingFacility < 0) && (this.PlanFacilityKind == null || this.PlanFacilityKind.rongna <= 0)
                && GameObject.Random((int) (GameObject.Square(unAmbition) * Parameters.AIBuildHougongUnambitionProbWeight + GameObject.Square(this.BelongedFaction.meinvkongjian()) * unAmbition * Parameters.AIBuildHougongSpaceBuiltProbWeight)) == 0)
            {
                if (((!this.FrontLine && !this.noFactionFrontline) || GameObject.Chance(Parameters.AILeaveFrontlineForHougongChance))
                    && (!this.HostileLine || GameObject.Chance(Parameters.AILeaveHostilelineForHougongChance))
                    && this.Kind.FacilityPositionUnit > 0 &&
                    this.Agriculture >= this.AgricultureCeiling * 9 / 10 && this.Commerce >= this.CommerceCeiling * 9 / 10 &&
                    this.Technology >= this.TechnologyCeiling * 9 / 10 && this.Endurance >= this.EnduranceCeiling * 9 / 10 &&
                    this.Domination >= this.DominationCeiling * 9 / 10 && this.Morale >= this.MoraleCeiling * 9 / 10)
                {
                    int maxHgSize = (12 - uncruelty) + Math.Max(0, this.FacilityPositionCount / this.Kind.FacilityPositionUnit - 5) + Parameters.AIBuildHougongMaxSizeAdd;
                    FacilityKind hougong = null;
                    foreach (FacilityKind fk in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if ((((!fk.PopulationRelated || this.Kind.HasPopulation) && ((this.Technology >= fk.TechnologyNeeded)))
                            && ((!fk.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID)) && (!fk.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID)))))
                        {
                            if (fk.rongna > 0 && fk.rongna < maxHgSize && GameObject.Chance(Parameters.AIBuildHougongSkipSizeChance))
                            {
                                if (hougong == null || hougong.rongna < fk.rongna)
                                {
                                    hougong = fk;
                                }
                            }
                        }
                    }
                    if (hougong != null)
                    {
                        int facilityPositionLeft = this.FacilityPositionLeft;
                        if (facilityPositionLeft < hougong.PositionOccupied && this.FacilityPositionCount >= hougong.PositionOccupied)
                        {
                            FacilityList fl = new FacilityList();
                            foreach (Facility f in this.Facilities)
                            {
                                if (!f.Kind.bukechaichu)
                                {
                                    fl.Add(f);
                                }
                            }

                            int totalRemovableSpace = 0;
                            foreach (Facility f in fl)
                            {
                                totalRemovableSpace += f.PositionOccupied;
                            }

                            if (totalRemovableSpace >= hougong.PositionOccupied && this.BelongedSection.AIDetail.AllowFacilityRemoval)
                            {
                                fl.PropertyName = "AIValue";
                                fl.IsNumber = true;
                                fl.SmallToBig = true;
                                fl.ReSort();

                                while (this.FacilityPositionLeft < hougong.PositionOccupied && fl.Count > 0)
                                {
                                    Facility f = fl[0] as Facility;
                                    if (this.FacilityEnabled)
                                    {
                                        f.Influences.PurifyInfluence(this, Applier.Facility, f.ID);
                                    }
                                    this.Facilities.Remove(f);
                                    base.Scenario.Facilities.Remove(f);
                                    fl.Remove(f);
                                }
                            }

                            /*foreach (Facility facility in this.Facilities.GetList())
                            {
                                if ((((this.Technology > facility.TechnologyNeeded) && this.FacilityIsPossibleOverTechnology(facility.TechnologyNeeded))
                                    && ((this.Fund > (facility.FundCost * 10)) && (this.BelongedFaction.TechniquePoint > (facility.PointCost * 10))))
                                    && (GameObject.Random(facility.Days * facility.PositionOccupied) < 20 * hougong.PositionOccupied)
                                    && !facility.Kind.bukechaichu)
                                {
                                    if (this.FacilityEnabled)
                                    {
                                        facility.Influences.PurifyInfluence(this);
                                    }
                                    this.Facilities.Remove(facility);
                                    base.Scenario.Facilities.Remove(facility);
                                }
                            }*/
                            facilityPositionLeft = this.FacilityPositionLeft;
                        }
                        if (facilityPositionLeft >= hougong.PositionOccupied)
                        {
                            if ((this.Fund >= hougong.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= hougong.PointCost))
                            {
                                this.PlanFacilityKind = null;
                                this.BelongedFaction.DepositTechniquePointForFacility(hougong.PointCost);
                                this.BeginToBuildAFacility(hougong);
                            }
                            else
                            {
                                this.PlanFacilityKind = hougong;
                                if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                                {
                                    this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                                }
                            }
                        }
                    }
                }
            }
            //nafei
            if (leader.WaitForFeiZi != null && leader.Status == PersonStatus.Normal)
            {
                if (this.meinvkongjian() - this.feiziliebiao.Count <= 0 || !this.BelongedFaction.Leader.isLegalFeiZi(leader.WaitForFeiZi))
                {
                    leader.WaitForFeiZi.WaitForFeiZi = null;
                    leader.WaitForFeiZi = null;
                } else if (this.fund >= 50000)
                {
                    if (leader.LocationArchitecture == this && leader.Status == PersonStatus.Normal && this.nvxingwujiang().GameObjects.Contains(leader.WaitForFeiZi))
                    {
                        leader.XuanZeMeiNv(leader.WaitForFeiZi);
                        leader.WaitForFeiZi.WaitForFeiZi = null;
                        leader.WaitForFeiZi = null;
                    }
                    else if (leader.WaitForFeiZi.BelongedFaction != this.BelongedFaction)
                    {
                        leader.WaitForFeiZi.WaitForFeiZi = null;
                        leader.WaitForFeiZi = null;
                    }
                }
            }
            else
            {
                if (!leader.IsCaptive && this.meinvkongjian() - this.feiziliebiao.Count > 0 && GameObject.Random(uncruelty - Parameters.AINafeiUncreultyProbAdd) == 0 && leader.LocationArchitecture != null && leader.Status == PersonStatus.Normal &&
                    (((!leader.LocationArchitecture.HostileLine || GameObject.Chance(Parameters.AILeaveHostilelineForHougongChance) || (leader.LocationArchitecture == this && GameObject.Chance(Parameters.AIHostilelineHougongChance)))
                    && (!leader.LocationArchitecture.FrontLine || GameObject.Chance(Parameters.AILeaveFrontlineForHougongChance) || (leader.LocationArchitecture == this && GameObject.Chance(Parameters.AIFrontlineHougongChance))))
                    || GameObject.Chance((int) Math.Round(Parameters.AIHougongArchitectureCountProbMultiply * Math.Pow(this.BelongedFaction.ArchitectureCount, Parameters.AIHougongArchitectureCountProbPower)))))
                {
                    PersonList candidate = new PersonList();
                    foreach (Person p in this.BelongedFaction.Persons)
                    {
                        Person spousePerson = p.Spouse == -1 ? null : base.Scenario.Persons.GetGameObject(p.Spouse) as Person;
                        if (p.Merit > ((unAmbition - 1) * Parameters.AINafeiAbilityThresholdRate) && leader.isLegalFeiZi(p) && p.LocationArchitecture != null && !p.IsCaptive && !p.HatedPersons.Contains(this.BelongedFaction.Leader.ID) &&
                            (spousePerson == null || spousePerson.ID == leader.ID || !spousePerson.Alive || (leader.PersonalLoyalty < (int) PersonLoyalty.很高 && spousePerson.Merit < p.Merit * ((int)leader.PersonalLoyalty * Parameters.AINafeiStealSpouseThresholdRateMultiply + Parameters.AINafeiStealSpouseThresholdRateAdd))) &&
                            (!GlobalVariables.PersonNaturalDeath || (p.Age >= 16 && p.Age <= Parameters.AINafeiMaxAgeThresholdAdd + (int)leader.Ambition * Parameters.AINafeiMaxAgeThresholdMultiply)))
                        {
                            candidate.Add(p);
                        }
                    }
                    candidate.PropertyName = "Merit";
                    candidate.IsNumber = true;
                    candidate.SmallToBig = false;
                    candidate.ReSort();
                    Person toTake = null;
                    foreach (Person p in candidate)
                    {
                        if ((!p.RecruitableBy(this.BelongedFaction, 0) && GameObject.Random((int)unAmbition) == 0) || GameObject.Chance((int) (Parameters.AINafeiSkipChanceAdd + (int)leader.Ambition * Parameters.AINafeiSkipChanceMultiply)))
                        {
                            toTake = p;
                            break;
                        }
                    }
                    if (toTake != null)
                    {
                        if (leader.LocationArchitecture != this && leader.Status == PersonStatus.Normal)
                        {
                            leader.MoveToArchitecture(this);
                            //leader.LocationArchitecture.RemovePerson(leader);
                            leader.WaitForFeiZi = toTake;
                        }
                        if (toTake.LocationArchitecture == this && toTake.Status == PersonStatus.Normal)
                        {
                            if (leader.LocationArchitecture == this && leader.Status == PersonStatus.Normal)
                            {
                                leader.XuanZeMeiNv(toTake);
                                toTake.WaitForFeiZi = null;
                                leader.WaitForFeiZi = null;
                            }
                            else
                            {
                                toTake.WaitForFeiZi = leader;
                            }
                        }
                        else
                        {
                            toTake.MoveToArchitecture(this);
                            //toTake.LocationArchitecture.RemovePerson(toTake);
                            toTake.WaitForFeiZi = leader;
                            leader.WaitForFeiZi = toTake;
                        }
                    }
                }
            }
            //chongxing
            if (!leader.IsCaptive && !leader.huaiyun && meifaxianhuaiyundefeiziliebiao().Count > 0 && leader.LocationArchitecture != null &&
                this.BelongedFaction.Leader.WaitForFeiZi == null && leader.Status == PersonStatus.Normal &&

                (
                GameObject.Chance((int) ((int)leader.Ambition * Parameters.AIChongxingChanceMultiply + Parameters.AIChongxingChanceAdd)) 
                ||
                GameObject.Chance((int)Math.Round(Parameters.AIHougongArchitectureCountProbMultiply * Math.Pow(this.BelongedFaction.ArchitectureCount, Parameters.AIHougongArchitectureCountProbPower)))
                )
                
                &&
                    
                   (((!leader.LocationArchitecture.HostileLine || GameObject.Chance(Parameters.AILeaveHostilelineForHougongChance) || (leader.LocationArchitecture == this && GameObject.Chance(Parameters.AIHostilelineHougongChance)))
                    && (!leader.LocationArchitecture.FrontLine || GameObject.Chance(Parameters.AILeaveFrontlineForHougongChance) || (leader.LocationArchitecture == this && GameObject.Chance(Parameters.AIFrontlineHougongChance))))
                    )
                )
            {
                if (leader.LocationArchitecture != this)
                {
                    bool stay = false;
                    PersonList candidate = leader.LocationArchitecture.meifaxianhuaiyundefeiziliebiao();
                    candidate.PropertyName = "Merit";
                    candidate.IsNumber = true;
                    candidate.SmallToBig = false;
                    candidate.ReSort();
                    foreach (Person p in candidate)
                    {
                        if ((GameObject.Random(leader.NumberOfChildren * (GlobalVariables.PersonNaturalDeath ? 1 : 0) + p.NumberOfChildren * 2) == 0 || GameObject.Chance(p.pregnantChance)) && leader.isLegalFeiZi(p))
                        {
                            stay = true;
                            leader.GoForHouGong(p);
                            break;
                        }
                    }
                    if (!stay)
                    {
                        leader.MoveToArchitecture(this);
                    }
                    //leader.LocationArchitecture.RemovePerson(leader);
                }
                else
                {
                    PersonList candidate = meifaxianhuaiyundefeiziliebiao();
                    candidate.PropertyName = "Merit";
                    candidate.IsNumber = true;
                    candidate.SmallToBig = false;
                    candidate.ReSort();
                    foreach (Person p in candidate)
                    {
                        if (GameObject.Random(leader.NumberOfChildren * (GlobalVariables.PersonNaturalDeath ? 1 : 0) + p.NumberOfChildren * 2) == 0 && leader.isLegalFeiZi(p))
                        {
                            leader.GoForHouGong(p);
                            break;
                        }
                    }
                }
            }
        }

        private int idleDays = 0;
        private void AIPersonTransfer()
        {
            int num2;
            if ((this.MilitaryCount == 0) && ((this.IsImportant || (this.AreaCount > 1)) || (this.Population > this.RecruitmentPopulationBoundary)))
            {
                this.AIRecruitment(false, false);
            }
            //if this city is falling, move people away
            if ((((this.BelongedFaction.ArchitectureCount > 1) && (this.PersonCount > this.MilitaryCount)) && (this.RecentlyAttacked > 0)) && ((this.Endurance == 0) || ((this.Endurance < 30) && GameObject.Chance(0x21))))
            {
                int num = this.PersonCount - this.MilitaryCount;
                GameObjectList list = this.Persons.GetList();
                if (list.Count > 1)
                {
                    list.IsNumber = true;
                    list.SmallToBig = true;
                    list.PropertyName = "FightingForce";
                    list.ReSort();
                }
                Architecture capital = this.BelongedFaction.Capital;
                ArchitectureList otherArchitectureList = base.Scenario.IsPlayer(this.BelongedFaction) ? this.BelongedSection.Architectures : this.GetOtherArchitectureList();
                if (capital == this)
                {
                    if (otherArchitectureList.Count > 1)
                    {
                        otherArchitectureList.IsNumber = true;
                        otherArchitectureList.PropertyName = "ArmyScaleWeighing";
                        otherArchitectureList.ReSort();
                    }
                    capital = otherArchitectureList[0] as Architecture;
                }
                Architecture dest = capital;
                double minDist = double.MaxValue;
                foreach (Architecture i in otherArchitectureList)
                {
                    double distance = base.Scenario.GetDistance(this.Position, i.Position);
                    if (distance < minDist && !(((i.PersonCount > i.MilitaryCount)) && (i.RecentlyAttacked > 0)) && ((i.Endurance == 0) || ((i.Endurance < 30) && GameObject.Chance(0x21))))
                    {
                        minDist = distance;
                        dest = i;
                    }
                }
                num2 = 0;
                while (num2 < num)
                {
                    Person p = list[num2] as Person;
                    if (!p.HasFollowingArmy && !p.HasLeadingArmy)
                    {
                        p.WaitForFeiZi = null;
                        p.MoveToArchitecture(dest);
                    }
                    num2++;
                }
            }
            else
            {
                if (this.HasHostileTroopsInView())
                {
                    idleDays = 0;
                    ArchitectureList otherArchitectureList = base.Scenario.IsPlayer(this.BelongedFaction) ? this.BelongedSection.Architectures : this.GetOtherArchitectureList();
                    do
                    {
                        Architecture src = null;
                        foreach (Architecture i in otherArchitectureList)
                        {
                            if (i == this) continue;
                            double minDist = double.MaxValue;
                            double distance = base.Scenario.GetDistance(this.Position, i.Position);
                            if (distance < minDist && (i.Endurance > 30 || !i.HasHostileTroopsInView()) && i != this && i.PersonCount > 0)
                            {
                                minDist = distance;
                                src = i;
                            }
                        }
                        if (src != null)
                        {
                            int num = src.FrontLine ? src.PersonCount - src.MilitaryCount : src.PersonCount;
                            if (src.HasHostileTroopsInView())
                            {
                                num /= 2;
                            }
                            GameObjectList list = src.Persons.GetList();
                            if (list.Count > 1)
                            {
                                list.IsNumber = true;
                                list.SmallToBig = false;
                                list.PropertyName = "Merit";
                                list.ReSort();
                            }
                            if (src != null)
                            {
                                num2 = 0;
                                while (num2 < num)
                                {
                                    Person p = list[num2] as Person;
                                    if (!p.HasFollowingArmy && !p.HasLeadingArmy && p.WaitForFeiZi == null)
                                    {
                                        p.MoveToArchitecture(this);
                                    }
                                    num2++;
                                }
                            }
                        } else break;
                        otherArchitectureList.Remove(src);
                    } while (otherArchitectureList.Count > 0 &&
                        this.PersonCount + this.MovingPersonCount < Math.Max(this.Fund / 1500, 6));
                }
                else
                {
                    if (this.IdlingPersonCount > this.PersonCount / 2)
                    {
                        idleDays++;
                        if (idleDays > 3 && this.PersonCount > 3)
                        {
                            ArchitectureList otherArchitectureList = base.Scenario.IsPlayer(this.BelongedFaction) ? this.BelongedSection.Architectures : this.BelongedFaction.Architectures;
                            Architecture dest = null;
                            foreach (Architecture i in otherArchitectureList)
                            {
                                double minDist = double.MaxValue;
                                double distance = base.Scenario.GetDistance(this.Position, i.Position);
                                if (distance < minDist && i.idleDays == 0 && (i.Endurance > 30 || !i.HasHostileTroopsInView()) && i != this)
                                {
                                    minDist = distance;
                                    dest = i;
                                }
                            }
                            int num = this.FrontLine ? this.PersonCount - this.MilitaryCount : this.PersonCount - 3;
                            GameObjectList list = this.Persons.GetList();
                            if (this.FrontLine)
                            {
                                if (list.Count > 1)
                                {
                                    list.IsNumber = true;
                                    list.SmallToBig = true;
                                    list.PropertyName = "FightingForce";
                                    list.ReSort();
                                }
                            }
                            if (dest != null)
                            {
                                num2 = 0;
                                while (num2 < num)
                                {
                                    Person p = list[num2] as Person;
                                    if (!p.HasFollowingArmy && !p.HasLeadingArmy && p.WaitForFeiZi == null)
                                    {
                                        p.MoveToArchitecture(dest);
                                    }
                                    num2++;
                                }
                            }
                        }
                    }
                    else
                    {
                        idleDays = 0;
                        if (this.FrontLine || this.noFactionFrontline)
                        {
                            ArchitectureList otherArchitectureList = base.Scenario.IsPlayer(this.BelongedFaction) ? this.BelongedSection.Architectures : this.GetOtherArchitectureList();
                            do
                            {
                                Architecture src = null;
                                foreach (Architecture i in otherArchitectureList)
                                {
                                    double minDist = double.MaxValue;
                                    double distance = base.Scenario.GetDistance(this.Position, i.Position);
                                    if (distance < minDist && (i.Endurance > 30 || !i.HasHostileTroopsInView()) && i != this && !i.FrontLine && !i.noFactionFrontline
                                        && i.PersonCount > this.PersonCount)
                                    {
                                        minDist = distance;
                                        src = i;
                                    }
                                }
                                if (src != null)
                                {
                                    int num = src.PersonCount / 2;
                                    GameObjectList list = src.Persons.GetList();
                                    if (list.Count > 1)
                                    {
                                        list.IsNumber = true;
                                        list.SmallToBig = false;
                                        list.PropertyName = "Merit";
                                        list.ReSort();
                                    }
                                    if (src != null)
                                    {
                                        num2 = 0;
                                        while (num2 < num)
                                        {
                                            Person p = list[num2] as Person;
                                            if (!p.HasFollowingArmy && !p.HasLeadingArmy && p.WaitForFeiZi == null)
                                            {
                                                p.MoveToArchitecture(this);
                                            }
                                            num2++;
                                        }
                                    }
                                }
                                else break;
                                otherArchitectureList.Remove(src);
                            } while (//this.PersonCount + this.MovingPersonCount < Math.Max(Math.Max(this.MilitaryCount * 2, this.Population / 10000), 6) && 
                                otherArchitectureList.Count > 0 && 
                                this.PersonCount + this.MovingPersonCount < this.MilitaryCount &&
                                this.PersonCount + this.MovingPersonCount < this.Fund / 3000);
                        }
                    }
                }

            }
        }

        private int transferCountDown = 0;

        private void AIResourceTransfer()
        {
            /*this.AIFundTransfer();
            this.AIFoodTransfer();*/

            if (this.PersonCount <= 0) return;

            if (this.Endurance < 30 && this.HasHostileTroopsInView())
            {
                int transferFood = this.Food - this.EnoughFood;
                int transferFund = this.Fund - this.EnoughFund;
                if (transferFood >= 1000000 || transferFund >= 10000)
                {
                    while ((transferFood > 0 || transferFund > 0) && this.PersonCount > 0)
                    {
                        if (transferFund < 0)
                        {
                            transferFund = 0;
                        }
                        if (transferFood < 0)
                        {
                            transferFood = 0;
                        }

                        // create transport
                        MilitaryKind mk;
                        base.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.TryGetValue(29, out mk);
                        this.CreateMilitary(mk);

                        Military transportTeam = null;
                        foreach (Military m in Militaries)
                        {
                            if (m.Kind.ID == 29 && (transportTeam == null || transportTeam.Quantity <= m.Quantity))
                            {
                                transportTeam = m;
                            }
                        }

                        // choose dest
                        Architecture dest = null;
                        foreach (LinkNode n in this.AIAllLinkNodes.Values)
                        {
                            if (n.A.BelongedFaction == this.BelongedFaction && !n.A.FrontLine)
                            {
                                dest = n.A;
                                break;
                            }
                        }
                        if (dest == null)
                        {
                            foreach (LinkNode n in this.AIAllLinkNodes.Values)
                            {
                                if (n.A.BelongedFaction == this.BelongedFaction && !n.A.HostileLine)
                                {
                                    dest = n.A;
                                    break;
                                }
                            }
                        }
                        if (dest == null)
                        {
                            List<Architecture> candidates = new List<Architecture>();
                            foreach (LinkNode n in this.AIAllLinkNodes.Values)
                            {
                                if (n.A.BelongedFaction == this.BelongedFaction && !n.A.HasHostileTroopsInView() && n.A != this)
                                {
                                    candidates.Add(n.A);
                                }
                            }
                            if (candidates.Count > 0){
                                dest = candidates[GameObject.Random(candidates.Count)];
                            }
                        }
                        if (dest == null) break;

                        // do transfer
                        int actualTransferFood = transferFood;
                        int actualTransferFund = transferFund;
                        if (transportTeam.Kind.MaxScale * transportTeam.Kind.FoodPerSoldier * transportTeam.Kind.RationDays < transferFood)
                        {
                            actualTransferFood = transportTeam.Kind.MaxScale * transportTeam.Kind.FoodPerSoldier * transportTeam.Kind.RationDays;
                        }
                        if (transportTeam.Kind.zijinshangxian < transferFund)
                        {
                            actualTransferFund = transportTeam.Kind.zijinshangxian;
                        }
                        transferFund -= actualTransferFund;
                        transferFood -= actualTransferFood;
                        this.BuildTransportTroop(dest, transportTeam, actualTransferFood, actualTransferFund);
                    }

                }
            }
            else
            {

                transferCountDown--;
                if (transferCountDown > 0) return;

                //transfer when
                //food or fund is adundant here and here is not frontline nor hostile line, or nearby no-income archs
                if (this.IsFoodAbundant || this.IsFundAbundant)
                {
                    if (!this.HasPerson())
                    {
                        if (!this.HasAnyPerson())
                        {
                            int minMerit = int.MaxValue;
                            Person personToMove = null;
                            foreach (Person p in this.BelongedFaction.Persons)
                            {
                                if (!p.IsCaptive && p.LocationArchitecture != null && p.Status == PersonStatus.Normal && p.LocationArchitecture.BelongedSection == this.BelongedSection && p.Merit < minMerit && p.BelongedArchitecture.PersonCount + p.BelongedArchitecture.MovingPersons.Count > 1)
                                {
                                    personToMove = p;
                                    minMerit = p.Merit;
                                }
                            }
                            if (personToMove != null && personToMove.WaitForFeiZi == null)
                            {

                                personToMove.MoveToArchitecture(this);
                                //personToMove.LocationArchitecture.RemovePerson(personToMove);
                                //base.Scenario.detectDuplication();
                            }
                        }
                    }
                    else /*if (GameObject.Chance(20))*/
                    {
                        //look for arch to transfer to, select the most needy base
                        LinkNode dest = null;
                        int min = int.MaxValue;
                        bool forceTransferIgnoreFrontline = false;
                        foreach (LinkNode node in this.AIAllLinkNodes.Values)
                        {
                            Architecture architecture = node.A;
                            if (!architecture.HostileLine && !architecture.FrontLine && !architecture.noFactionFrontline && architecture.ExpectedFund > 0 && architecture.ExpectedFood > 0)
                            {
                                continue;
                            }

                            //do not transport if the other has 2/3 full of food/fund, or the other side is falling
                            if (((architecture.Food < architecture.FoodCeiling / 3 * 2) || (architecture.Fund < architecture.FundCeiling / 3 * 2)) && (architecture.Endurance >= 30 || architecture.RecentlyAttacked <= 0))
                            {
                                //transfer to same section or other section when permitted
                                //and do not transport to empty base or even enemy bases, of course!
                                if (architecture.BelongedSection != null && architecture.BelongedFaction == this.BelongedFaction &&
                                    ((architecture.BelongedSection == this.BelongedSection) || (architecture.BelongedSection.AIDetail.AllowFundTransfer && ((architecture.BelongedSection.OrientationSection == this.BelongedSection) || (architecture.BelongedSection.OrientationSection == null)))))
                                {
                                    bool ok = true;
                                    foreach (Architecture a in node.Path)
                                    {
                                        if (a.BelongedFaction != this.BelongedFaction && a.BelongedFaction != null)
                                        {
                                            ok = false;
                                            break;
                                        }
                                    }
                                    if (ok)
                                    {
                                        int need = (!architecture.BuyFoodAvail() && !architecture.SellFoodAvail() ? Math.Min(architecture.Food, architecture.Fund * 100) * 2 : architecture.Food + architecture.Fund * 100) + (int)node.Distance * 10000;

                                        if (architecture.orientationFrontLine)
                                        {
                                            need /= 2;
                                        }
                                        if (architecture.FrontLine)
                                        {
                                            need /= 2;
                                        }
                                        if (architecture.HostileLine)
                                        {
                                            need /= 4;
                                        }
                                        if (!architecture.IsFoodEnough || !architecture.IsFundEnough)
                                        {
                                            need /= 2;
                                        }
                                        if ((architecture.ExpectedFood <= 50000 || architecture.ExpectedFund <= 500) &&
                                            ((!architecture.IsFundEnough || !architecture.IsFoodEnough) || ((!architecture.IsFundAbundant || !architecture.IsFoodAbundant) && this.IsFoodAbundant && this.IsFundAbundant)))
                                        {
                                            forceTransferIgnoreFrontline = true;
                                            need = 0; //force transfer if the target is incapable of getting any income and do not have enough food and fund
                                        }
                                        if (architecture.IsFoodAbundant || architecture.IsFundAbundant)
                                        {
                                            need *= 2;
                                        }
                                        if (need < min)
                                        {
                                            min = need;
                                            dest = node;
                                        }
                                    }
                                }
                            }
                        }
                        if (dest == null || ((this.HostileLine || this.FrontLine || this.noFactionFrontline) && !forceTransferIgnoreFrontline) ||
                            (this.ExpectedFood <= 50000 && this.ExpectedFund <= 500))
                        {
                            //no suitable candidates, forget about it.
                            //and do not transfer if this is frontline and there is no urgent need (force transfer) to other bases
                            //and do not transfer if there is no food or fund income (to prevent perpertual transport)
                            this.TransferFoodArchitecture = null;
                            return;
                        }

                        //compute food and fund needed to transfer
                        int transferFood = Math.Max(Math.Min(!this.HostileLine && !this.FrontLine ? this.Food - (int)(this.EnoughFood * 1.2) : this.Food - this.AbundantFood * 2, dest.A.FoodCeiling / 10 * 9 - dest.A.Food), 0);
                        int transferFund = Math.Max(Math.Min(!this.HostileLine && !this.FrontLine ? this.Fund - (int)(this.EnoughFund * 1.2) : this.Fund - this.AbundantFund * 2, dest.A.FundCeiling / 10 * 9 - dest.A.Fund), 0);
                        if (forceTransferIgnoreFrontline)
                        {
                            transferFood = Math.Min(Math.Max(transferFood, this.Food - (int)(this.EnoughFood * 1.2)), dest.A.FoodCeiling / 10 * 9 - dest.A.Food);
                            transferFund = Math.Min(Math.Max(transferFund, this.Fund - (int)(this.EnoughFund * 1.2)), dest.A.FundCeiling / 10 * 9 - dest.A.Fund);
                        }

                        if (transferFood < 1000000 && transferFund < 10000)
                        {
                            //do not attempt to transfer too little resources
                            this.TransferFoodArchitecture = null;
                            return;
                        }

                        //if there is transport team here, lets transport!
                        if (GlobalVariables.AINoTeamTransfer)
                        {
                            //if no transfer, just let the fund and food magically arrives ;)
                            this.Food -= transferFood;
                            this.Fund -= transferFund;
                            dest.A.Food += transferFood;
                            dest.A.Fund += transferFund;
                        }
                        else
                        {
                            Military transportTeam = null;
                            foreach (Military m in Militaries)
                            {
                                if (m.Kind.ID == 29 && (transportTeam == null || transportTeam.Quantity <= m.Quantity))
                                {
                                    transportTeam = m;
                                }
                            }
                            if (transportTeam != null)
                            {
                                //reduce amount of fund/food if it is not possible to transport that much of food at all
                                if (transportTeam.Kind.MaxScale * transportTeam.Kind.FoodPerSoldier * transportTeam.Kind.RationDays < transferFood)
                                {
                                    transferFood = transportTeam.Kind.MaxScale * transportTeam.Kind.FoodPerSoldier * transportTeam.Kind.RationDays;
                                }
                                if (transferFund > transportTeam.Kind.zijinshangxian)
                                {
                                    transferFund = transportTeam.Kind.zijinshangxian;
                                }
                                if ((transportTeam.Quantity > 0 && (this.RecentlyAttacked <= 0 || this.Endurance == 0 || transportTeam.Quantity >= transportTeam.Kind.MaxScale)) && transportTeam.Quantity * transportTeam.Kind.FoodPerSoldier * transportTeam.Kind.RationDays >= transferFood)
                                {
                                    //ensure enough crop for task
                                    if (transferFood >= transportTeam.Quantity * transportTeam.Kind.FoodPerSoldier * (dest.Distance / (transportTeam.Kind.Movability / (transportTeam.Kind.PlainAdaptability * 2))))
                                    {
                                        //build the troop
                                        this.BuildTransportTroop(dest.A, transportTeam, transferFood, transferFund);

                                        //and don't transfer within 3 days.
                                        transferCountDown = 3;
                                    }
                                    this.TransferFoodArchitecture = null;
                                }
                            }
                            else
                            {
                                //otherwise, get a new one
                                MilitaryKind mk;
                                base.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.TryGetValue(29, out mk);
                                this.CreateMilitary(mk);

                                //let AIWork to recruit this team

                                //and mark that we are going to transfer
                                this.TransferFoodArchitecture = dest.A;
                            }
                        }
                    }
                }
                else
                {
                    //condition failed, forget about transfering
                    this.TransferFoodArchitecture = null;
                }
            }
        }

        private void AIWork(bool forPlayer)
        {

            if (!forPlayer)
            {
                this.AIAutoHire();
            }
            this.StopAllWork();
            if (this.Fund < 100) return;

            PersonList zhenzaiPersons = new PersonList();
            PersonList agriculturePersons = new PersonList();
            PersonList commercePersons = new PersonList();
            PersonList technologyPersons = new PersonList();
            PersonList dominationPersons = new PersonList();
            PersonList moralePersons = new PersonList();
            PersonList endurancePersons = new PersonList();
            PersonList trainingPersons = new PersonList();
            PersonList recruitmentPersons = new PersonList();
            MilitaryList weighingMilitaries = new MilitaryList();

            if ((forPlayer || ((this.PlanArchitecture == null) || GameObject.Chance(10))) && this.HasPerson())
            {
                int num;
                this.ReSortAllWeighingList(zhenzaiPersons, agriculturePersons, commercePersons, technologyPersons, dominationPersons,
                                        moralePersons, endurancePersons, recruitmentPersons, trainingPersons, weighingMilitaries);
                bool isFundAbundant = this.IsFundAbundant;
                if (this.Fund < ((100 * this.AreaCount) + ((30 - base.Scenario.Date.Day) * this.FacilityMaintenanceCost)))
                {
                    MilitaryList trainingMilitaryList = this.GetTrainingMilitaryList();
                    if (trainingMilitaryList.Count > 0)
                    {
                        trainingMilitaryList.IsNumber = true;
                        trainingMilitaryList.PropertyName = "Weighing";
                        trainingMilitaryList.ReSort();
                        GameObjectList maxObjects = trainingPersons.GetMaxObjects(trainingMilitaryList.Count);
                        for (num = 0; num < maxObjects.Count; num++)
                        {
                            (maxObjects[num] as Person).WorkKind = ArchitectureWorkKind.训练;
                        }
                    }
                    int num2 = 0;
                    if ((GameObject.Chance(50) && this.Kind.HasDomination) && (this.Domination < (this.DominationCeiling * 0.8)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasEndurance) && (this.Endurance < (this.EnduranceCeiling * 0.2f)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasMorale) && (this.Morale < Parameters.RecruitmentMorale))
                    {
                        num2++;
                    }
                    if (num2 > 0)
                    {
                        for (num = 0; num < (this.Persons.Count - trainingMilitaryList.Count); num += num2)
                        {
                            foreach (Person person in dominationPersons)
                            {
                                person.WorkKind = ArchitectureWorkKind.统治;
                            }
                            foreach (Person person in endurancePersons)
                            {
                                person.WorkKind = ArchitectureWorkKind.耐久;
                            }
                            foreach (Person person in moralePersons)
                            {
                                person.WorkKind = ArchitectureWorkKind.民心;
                            }
                        }
                    }
                }
                else if ((GameObject.Chance(20) || !this.HasBuildingRouteway) || this.IsFundEnough)
                {
                    float num3;
                    bool flag2 = this.RecentlyAttacked > 0;
                    WorkRateList list3 = new WorkRateList();
                    if ((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) || GameObject.Chance(20))
                    {
                        if (!flag2 || !GameObject.Chance(80))
                        {
                            if (this.kezhenzai() && this.IsFundEnough && this.IsFoodEnough)
                            {
                                list3.AddWorkRate(new WorkRate(0, ArchitectureWorkKind.赈灾));
                            }
                            if (this.Kind.HasAgriculture && (this.Agriculture < this.AgricultureCeiling))
                            {
                                if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueAgriculture)
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Agriculture) / 4f) / ((float)this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Agriculture) / ((float)this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                            }
                            if (this.Kind.HasCommerce && (this.Commerce < this.CommerceCeiling))
                            {
                                if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueCommerce)
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Commerce) / 4f) / ((float)this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Commerce) / ((float)this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                            }
                            if (this.Kind.HasTechnology && (this.Technology < this.TechnologyCeiling))
                            {
                                if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueTechnology || (GameObject.Chance(50) && (this.IsStateAdmin || this.IsRegionCore)))
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Technology) / 4f) / ((float)this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Technology) / ((float)this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                            }
                        }
                        if (this.Kind.HasDomination && (this.Domination < this.DominationCeiling))
                        {
                            if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueDomination)
                            {
                                list3.AddWorkRate(new WorkRate(((((float)this.Domination) / 5f) / 4f) / ((float)this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Domination) / 5f) / ((float)this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                        }
                        if (this.Kind.HasMorale && (this.Morale < this.MoraleCeiling))
                        {
                            if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueMorale)
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Morale) / 4f) / ((float)this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Morale) / ((float)this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                        }
                        if (this.Kind.HasEndurance && (this.Endurance < this.EnduranceCeiling))
                        {
                            if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueEndurance)
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Endurance) / 4f) / ((float)this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Endurance) / ((float)this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                        }
                    }
                    MilitaryList list4 = this.GetTrainingMilitaryList();
                    if (list4.Count > 0)
                    {
                        if (flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.训练));
                        }
                        else
                        {
                            num3 = 0f;
                            foreach (Military military in list4)
                            {
                                num3 += ((float)military.TrainingWeighing) / ((float)military.MaxTrainingWeighing);
                            }
                            num3 /= (float)list4.Count;
                            if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueTraining)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.训练));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.训练));
                            }
                        }
                    }
                    MilitaryList recruitmentMilitaryList = null;
                    if (((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) && this.Kind.HasPopulation) && ((flag2 || (GameObject.Random(GameObject.Square(((int)this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0)) && this.RecruitmentAvail()))
                    {
                        bool lotsOfPopulation = GameObject.Chance((int) ((((((float)this.Population) / ((float)this.PopulationCeiling)) * 100f) - 50f) * 2.5));
                        recruitmentMilitaryList = this.GetRecruitmentMilitaryList();
                        if (this.ArmyScale < this.FewArmyScale)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if ((((this.IsFoodEnough &&
                            (((this.IsImportant || (this.AreaCount > 2)) && (this.Population > this.Kind.PopulationBoundary))
                                || (((this.AreaCount <= 2) && !this.IsImportant) && (this.Population > (this.RecruitmentPopulationBoundary / 2)))
                                || (this.ValueWater && this.HasShuijunMilitaryKind() && this.Population > 10000))
                            )
                            && (/*((this.BelongedSection != null && this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(60)) || GameObject.Chance(15)) &&*/
                            (GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length) >= (int)this.BelongedFaction.Leader.StrategyTendency)))
                            || lotsOfPopulation)
                            )
                        {
                            bool nearFrontline = this.FrontLine || this.HostileLine || this.noFactionFrontline;
                            if (!nearFrontline)
                            {
                                foreach (LinkNode a in this.AIAllLinkNodes.Values)
                                {
                                    if (a.Level <= 1 && (a.A.FrontLine || a.A.HostileLine || a.A.noFactionFrontline) && !a.A.Kind.HasPopulation)
                                    {
                                        nearFrontline = true;
                                        break;
                                    }
                                }
                            }
                            if ((this.ExpectedMilitaryPopulation - this.MilitaryPopulation <= this.PopulationDevelopingRate * this.PopulationCeiling * Parameters.AIRecruitPopulationCapMultiply *
                                    (nearFrontline ? 1.0 : Parameters.AIRecruitPopulationCapBackendMultiply) * (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueRecruitment ? 1.5 : 1) *
                                    (((Enum.GetNames(typeof(PersonStrategyTendency)).Length - (int)this.BelongedFaction.Leader.StrategyTendency)) * Parameters.AIRecruitPopulationCapStrategyTendencyMulitply + Parameters.AIRecruitPopulationCapStrategyTendencyAdd)
                                    * (this.HostileLine ? Parameters.AIRecruitPopulationCapHostilelineMultiply : 1))
                                || lotsOfPopulation)
                            {
                                num3 = 0f;
                                foreach (Military military in recruitmentMilitaryList)
                                {
                                    num3 += ((float)military.RecruitmentWeighing) / ((float)military.MaxRecruitmentWeighing);
                                }
                                num3 /= (float)recruitmentMilitaryList.Count;
                                if (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueRecruitment)
                                {
                                    list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.补充));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.补充));
                                }
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        for (num = 0; num < this.Persons.Count; num += list3.Count)
                        {
                            foreach (WorkRate rate in list3.RateList)
                            {
                                switch (rate.workKind)
                                {
                                    case ArchitectureWorkKind.农业:
                                        foreach (Person person in agriculturePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.AgricultureAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.农业;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.商业:
                                        foreach (Person person in commercePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.CommerceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.商业;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.技术:
                                        foreach (Person person in technologyPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.TechnologyAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.技术;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.统治:
                                        foreach (Person person in dominationPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.DominationAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.统治;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.民心:
                                        foreach (Person person in moralePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.MoraleAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.民心;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.耐久:
                                        foreach (Person person in endurancePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.EnduranceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.耐久;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.赈灾:
                                        foreach (Person person in zhenzaiPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.zhenzaiAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                person.WorkKind = ArchitectureWorkKind.赈灾;
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.训练:
                                        foreach (Person person in trainingPersons)
                                        {
                                            if (person.WorkKind == ArchitectureWorkKind.无)
                                            {
                                                list4.PropertyName = "Merit";
                                                list4.IsNumber = true;
                                                list4.SmallToBig = false;
                                                list4.ReSort();
                                                foreach (Military military in list4)
                                                {
                                                    if (military.RecruitmentPerson == null)
                                                    {
                                                        person.WorkKind = ArchitectureWorkKind.训练;
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.补充:
                                        foreach (Person person in recruitmentPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.RecruitmentAbility >= 120)))
                                            {
                                                if (recruitmentMilitaryList != null)
                                                {
                                                    //recruit transports first
                                                    bool recruited = false;
                                                    foreach (Military military in recruitmentMilitaryList)
                                                    {
                                                        if (military.KindID == 29)
                                                        {
                                                            person.RecruitMilitary(military);
                                                            recruited = true;
                                                            break;
                                                        }
                                                    }
                                                    if (!recruited)
                                                    {
                                                        //if no transports, recruit other kind
                                                        recruitmentMilitaryList.PropertyName = "Merit";
                                                        recruitmentMilitaryList.IsNumber = true;
                                                        recruitmentMilitaryList.SmallToBig = false;
                                                        recruitmentMilitaryList.ReSort();
                                                        foreach (Military military in recruitmentMilitaryList)
                                                        {
                                                            if (military.RecruitmentPerson == null)
                                                            {
                                                                person.RecruitMilitary(military);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if (!forPlayer)
                    {
                        if ((this.Kind.HasPopulation && (flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this))) &&
                            (flag2 || (this.Population > ((this.RecruitmentPopulationBoundary * (1 + (int)this.BelongedFaction.Leader.StrategyTendency * 0.5f)) + GameObject.Random(this.RecruitmentPopulationBoundary)))))
                        {
                            int unfullArmyCount = 0;
                            int unfullNavalArmyCount = 0;
                            foreach (Military military in this.Militaries)
                            {
                                if (military.Scales < ((((float)military.Kind.MaxScale) / ((float)military.Kind.MinScale)) * 0.75f) && military.Kind.ID != 29)
                                {
                                    unfullArmyCount++;
                                    if (military.Kind.Type == MilitaryType.水军)
                                    {
                                        unfullNavalArmyCount++;
                                    }
                                }
                            }
                            int unfullArmyCountThreshold;
                            if (this.IsFoodAbundant && this.IsFundAbundant)
                            {
                                unfullArmyCountThreshold = Math.Min((this.MilitaryPopulation) / Parameters.AINewMilitaryPopulationThresholdDivide + 1, (this.PersonCount + this.MovingPersonCount) / Parameters.AINewMilitaryPersonThresholdDivide + 1);
                            }
                            else
                            {
                                unfullArmyCountThreshold = 1;
                            }
                            if (unfullArmyCount < unfullArmyCountThreshold)
                            {
                                if (this.AIWaterLinks.Count > 0 && this.IsBesideWater && this.HasShuijunMilitaryKind() && (this.MilitaryCount == 0 || GameObject.Chance((int)(100 - this.ShuijunMilitaryCount / (double)this.MilitaryCount * 100))))
                                {
                                    this.AIRecruitment(true, false);
                                }
                                else
                                {
                                    int siegeCount = 0;
                                    foreach (Military m in this.Militaries)
                                    {
                                        if (m.Kind.Type == MilitaryType.器械)
                                        {
                                            siegeCount++;
                                        }
                                    }
                                    if (siegeCount < this.Militaries.Count / 3)
                                    {
                                        this.AIRecruitment(false, true);
                                    }
                                    else
                                    {
                                        this.AIRecruitment(false, false);
                                    }
                                }
                            }
                            else if (this.AIWaterLinks.Count > 0 && this.IsBesideWater && this.HasShuijunMilitaryKind() && this.ShuijunMilitaryCount < this.MilitaryCount / 2 && unfullNavalArmyCount < unfullArmyCountThreshold)
                            {
                                this.AIRecruitment(true, false);
                            }
                        }
                        if (this.TransferFoodArchitecture != null)
                        {
                            //find the military team
                            Military transportTeam = null;
                            foreach (Military m in Militaries)
                            {
                                if (m.Kind.ID == 29 && (transportTeam == null || transportTeam.Quantity <= m.Quantity) && m.Quantity <= m.Kind.MaxScale)
                                {
                                    transportTeam = m;
                                }
                            }
                            if (transportTeam != null)
                            {

                                //select an idle person to do the recruit
                                Person recruitTransportPerson = null;
                                foreach (Person p in this.Persons)
                                {
                                    if (p.WorkKind == ArchitectureWorkKind.无)
                                    {
                                        recruitTransportPerson = p;
                                    }
                                }
                                //if no idling person, select the lowest work ability
                                if (recruitTransportPerson == null)
                                {
                                    int min = int.MaxValue;
                                    foreach (Person p in this.Persons)
                                    {
                                        if (p.WorkAbility < min)
                                        {
                                            recruitTransportPerson = p;
                                            min = p.WorkAbility;
                                        }
                                    }
                                }

                                if ((((this.Population != 0) && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population))) && ((this.Fund >= (Parameters.RecruitmentFundCost * this.AreaCount)) && (this.Domination >= Parameters.RecruitmentDomination))) && (((this.Morale >= Parameters.RecruitmentMorale) && ((transportTeam.RecruitmentPerson != null) && (transportTeam.RecruitmentPerson.BelongedFaction != null))) && (transportTeam.Quantity < transportTeam.Kind.MaxScale)))
                                {
                                    recruitTransportPerson.RecruitMilitary(transportTeam);
                                }
                            }
                        }
                        //disband unused transports except one
                        MilitaryList ml = new MilitaryList();
                        foreach (Military m in Militaries)
                        {
                            if (m.Kind.ID == 29)
                            {
                                ml.Add(m);
                            }
                        }
                        if (ml.Count > 1)
                        {
                            Military minTroop = null;
                            int min = int.MaxValue;
                            foreach (Military m in ml)
                            {
                                if (m.Quantity < min)
                                {
                                    min = m.Quantity;
                                    minTroop = m;
                                }
                            }
                            this.DisbandMilitary(minTroop);
                        }
                    }
                }
            }
        }


        private void OutsideTacticsAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (((this.RecentlyAttacked <= 0) && this.HasPerson()) && this.IsFundEnough))
            {
                Architecture architecture2;
                int diplomaticRelation;
                Person firstHalfPerson;
                ArchitectureList list = new ArchitectureList();
                ArchitectureList list2 = new ArchitectureList();
                foreach (Architecture architecture in this.GetClosestArchitectures(20, 40))
                {
                    if (!this.BelongedFaction.IsArchitectureKnown(architecture))
                    {
                        list.Add(architecture);
                    }
                    else
                    {
                        list2.Add(architecture);
                    }
                }
                if (this.BelongedSection != null && (list.Count > 0) && this.BelongedSection.AIDetail.AllowInvestigateTactics)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Population";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    if ((((this.RecentlyAttacked <= 0) && (GameObject.Random(40) < GameObject.Random(list.Count))) && GameObject.Chance(20)) && this.InformationAvail())
                    {
                        architecture2 = list[GameObject.Random(list.Count / 2)] as Architecture;
                        if ((!this.BelongedFaction.IsArchitectureKnown(architecture2) || GameObject.Chance(20)) && ((architecture2.BelongedFaction != null) && (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10))))
                        {
                            diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                            if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                            {
                                firstHalfPerson = this.GetFirstHalfPerson("InformationAbility");
                                if ((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100))
                                {
                                    firstHalfPerson.CurrentInformationKind = this.GetFirstHalfInformationKind();
                                    if (firstHalfPerson.CurrentInformationKind != null)
                                    {
                                        firstHalfPerson.GoForInformation(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                    }
                                }
                            }
                        }
                    }
                    if (((this.PlanArchitecture == null) && (GameObject.Random(40) < GameObject.Random(list.Count))) && (this.HasPerson() && (GameObject.Random(this.Fund) >= this.SpyArchitectureFund)))
                    {
                        architecture2 = list[GameObject.Random(list.Count / 2)] as Architecture;
                        if ((!architecture2.HasFactionSpy(this.BelongedFaction) || GameObject.Chance(20)) && (((architecture2.BelongedFaction != null) && (GameObject.Random(architecture2.AreaCount + 4) >= 4)) && (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10))))
                        {
                            diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                            if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                            {
                                firstHalfPerson = this.GetFirstHalfPerson("SpyAbility");
                                if (((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100)) && (GameObject.Random(firstHalfPerson.SpyAbility) >= 200))
                                {
                                    firstHalfPerson.GoForSpy(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                }
                            }
                        }
                    }
                }
                if ((this.BelongedSection != null) && ((list2.Count > 0) && (this.PlanArchitecture == null)) && this.BelongedSection.AIDetail.AllowPersonTactics)
                {
                    if (list2.Count > 1)
                    {
                        list2.PropertyName = "PersonCount";
                        list2.IsNumber = true;
                        list2.ReSort();
                    }
                    if ((this.HasPerson() && (GameObject.Random(this.Fund) >= this.GossipArchitectureFund)) && GameObject.Chance(50))
                    {
                        ArchitectureList list3 = new ArchitectureList();
                        foreach (Architecture architecture in list2)
                        {
                            if ((architecture.BelongedFaction != this.BelongedFaction) && (architecture.BelongedFaction != null))
                            {
                                list3.Add(architecture);
                            }
                        }
                        if (list3.Count > 0)
                        {
                            architecture2 = list3[GameObject.Random(list3.Count / 2)] as Architecture;
                            if ((!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10)) && ((architecture2.Fund < architecture2.EnoughFund) || ((architecture2.Fund < architecture2.AbundantFund) && GameObject.Chance(20))))
                            {
                                diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                                if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                                {
                                    firstHalfPerson = this.GetFirstHalfPerson("GossipAbility");
                                    if (((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100)) && ((GameObject.Random(architecture2.GetGossipablePersonCount() + 4) >= 4) && (GameObject.Random(firstHalfPerson.GossipAbility) >= 200)))
                                    {
                                        firstHalfPerson.GoForGossip(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                    }
                                }
                            }
                        }
                    }
                    if ((this.HasPerson() && (GameObject.Random(this.Fund) >= this.ConvincePersonFund)) && GameObject.Chance(50))
                    {
                        ArchitectureList list4 = new ArchitectureList();
                        foreach (Architecture architecture in list2)
                        {
                            if (((architecture.BelongedFaction != this.BelongedFaction) && (architecture.BelongedFaction != null)) && architecture.HasPerson())
                            {
                                list4.Add(architecture);
                            }
                        }
                        foreach (Architecture architecture in this.BelongedFaction.Architectures)
                        {
                            if (architecture.HasCaptive())
                            {
                                list4.Add(architecture);
                            }
                        }
                        if (list4.Count > 0)
                        {
                            architecture2 = list4[GameObject.Random(list4.Count)] as Architecture;
                            if (architecture2.BelongedFaction == this.BelongedFaction)
                            {
                                Captive extremeLoyaltyCaptive = architecture2.GetLowestLoyaltyCaptiveRecruitable();
                                if ((((extremeLoyaltyCaptive != null) && (extremeLoyaltyCaptive.CaptivePerson != null)) && 
                                    ((extremeLoyaltyCaptive.Loyalty < 100 || (GlobalVariables.AIAutoTakePlayerCaptives && !GlobalVariables.AIAutoTakePlayerCaptiveOnlyUnfull && base.Scenario.IsPlayer(extremeLoyaltyCaptive.CaptiveFaction))))) 
                                    && (extremeLoyaltyCaptive.CaptiveFaction == null || extremeLoyaltyCaptive.CaptivePerson != extremeLoyaltyCaptive.CaptiveFaction.Leader))
                                {
                                    PersonList firstHalfPersonList = this.GetFirstHalfPersonList("ConvinceAbility");
                                    foreach (Person i in firstHalfPersonList)
                                    {
                                        if ((GameObject.Random(this.BelongedFaction.PersonCount) < 5 && i != null) || ((((i != null) && (!this.HasFollowedLeaderMilitary(i) || GameObject.Chance(33))) && (GameObject.Random(i.NonFightingNumber) > GameObject.Random(i.FightingNumber))) && (GameObject.Random(i.FightingNumber) < 100)) && ((GameObject.Random(i.ConvinceAbility) >= 200) && (GameObject.Random(i.ConvinceAbility) > GameObject.Random(extremeLoyaltyCaptive.Loyalty * 5))))
                                        {
                                            i.OutsideDestination = new Point?(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                            i.GoForConvince(extremeLoyaltyCaptive.CaptivePerson);
                                        }
                                    }
                                }
                            }
                            else if (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(50))
                            {
                                diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                                if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 50) <= GameObject.Random(50))) || (diplomaticRelation < 0))
                                {
                                    Person extremeLoyaltyPerson = architecture2.GetLowestLoyaltyPersonRecruitable();
                                    if ((extremeLoyaltyPerson != null) && ((extremeLoyaltyPerson.Loyalty < 100) && (extremeLoyaltyPerson.BelongedFaction != null)) && (extremeLoyaltyPerson != extremeLoyaltyPerson.BelongedFaction.Leader))
                                    {
                                        firstHalfPerson = this.GetFirstHalfPerson("ConvinceAbility");
                                        if ((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(20))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && ((GameObject.Random(firstHalfPerson.ConvinceAbility) >= 200) && (GameObject.Random(firstHalfPerson.ConvinceAbility) > GameObject.Random(extremeLoyaltyPerson.Loyalty * 5))))
                                        {
                                            firstHalfPerson.OutsideDestination = new Point?(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                            firstHalfPerson.GoForConvince(extremeLoyaltyPerson);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private PersonList GetFirstHalfPersonList(string propertyName)
        {
            PersonList list = new PersonList();
            if (this.Persons.Count > 0)
            {
                foreach (Person p in this.Persons)
                {
                    list.Add(p);
                }
                if (list.Count > 1)
                {
                    list.PropertyName = propertyName;
                    list.IsNumber = true;
                    list.ReSort();
                }
                list.GameObjects.RemoveRange(list.Count / 2, list.Count - list.Count / 2);
                return (list);
            }
            return null;
        }

        private void AIAutoHire()
        {
            if ((this.BelongedFaction != null) && (((!this.HireFinished && (this.NoFactionPersonCount > 0)) && (this.Fund >= this.HirePersonFund)) && (GameObject.Random(this.HirablePersonCount + 1) >= 1)))
            {
                this.HireNoFactionPerson();
            }
        }

        private void AIAutoReward()
        {
            if ((this.BelongedFaction != null) && (this.Fund >= this.RewardPersonFund))
            {
                this.RewardPersonsUnderLoyalty(100);
            }
        }

        private void AIAutoSearch()
        {
            if (this.HasHostileTroopsInView()) return;
            foreach (Person person in this.Persons.GetList())
            {
                if (person.WorkKind == ArchitectureWorkKind.无)
                {
                    person.GoForSearch();
                }
            }
        }

        public void AICampaign()
        {
            this.DefensiveCampaign();
            this.OffensiveCampaign();
        }
        /*
        private void AIFacility()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BuildingFacility < 0))
            {
                List<FacilityKind> list = new List<FacilityKind>();
                List<FacilityKind> list2 = new List<FacilityKind>();
                if (this.PlanFacilityKind != null)
                {
                    if (this.Technology >= this.PlanFacilityKind.TechnologyNeeded)
                    {
                        if ((this.Fund >= this.PlanFacilityKind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.DepositTechniquePointForFacility(this.PlanFacilityKind.PointCost);
                            this.BeginToBuildAFacility(this.PlanFacilityKind);
                            this.PlanFacilityKind = null;
                        }
                        else if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                    else
                    {
                        this.PlanFacilityKind = null;
                    }
                }
                else
                {
                    List<FacilityKind> list3 = new List<FacilityKind>();
                    int facilityPositionLeft = this.FacilityPositionLeft;
                    if (facilityPositionLeft <= 0)
                    {
                        foreach (Facility facility in this.Facilities.GetList())
                        {
                            if (((((this.Technology > facility.TechnologyNeeded) && this.FacilityIsPossibleOverTechnology(facility.TechnologyNeeded)) && (this.Fund > (facility.FundCost * 10))) && (this.BelongedFaction.TechniquePoint > (facility.PointCost * 10))) && (GameObject.Random(facility.Days * facility.PositionOccupied) < 20))
                            {
                                list3.Add(facility.Kind);
                                if (this.FacilityEnabled)
                                {
                                    facility.Influences.PurifyInfluence(this);
                                }
                                this.Facilities.Remove(facility);
                                base.Scenario.Facilities.Remove(facility);
                            }
                        }
                        if (list3.Count == 0)
                        {
                            return;
                        }
                        facilityPositionLeft = this.FacilityPositionLeft;
                    }
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (list3.IndexOf(kind) >= 0)
                        {
                            continue;
                        }
                        if (kind.rongna > 0) continue;  //不造美女设施

                        if (((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((this.Technology >= kind.TechnologyNeeded) && (facilityPositionLeft >= kind.PositionOccupied))) && (!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID))) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID))) && ((kind.FrontLine && ((this.HostileLine || (this.FrontLine && GameObject.Chance(50))) || (!this.FrontLine && GameObject.Chance(10)))) || (!kind.FrontLine && ((!this.FrontLine || (!this.HostileLine && GameObject.Chance(50))) || (this.HostileLine && GameObject.Chance(5))))))
                        {
                            list.Add(kind);
                            if ((this.Fund >= kind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= kind.PointCost))
                            {
                                list2.Add(kind);
                            }
                        }
                    }
                    if (list2.Count > 0)
                    {
                        FacilityKind facilityKind = list2[GameObject.Random(list2.Count)];
                        this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                        this.BeginToBuildAFacility(facilityKind);
                    }
                    else if (list.Count > 0)
                    {
                        this.PlanFacilityKind = list[GameObject.Random(list.Count)];
                        if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                }// end if (this.PlanFacilityKind != null)
            }
        }
        */

        /*
        private void AIFoodTransfer()
        {
            Routeway connectedRouteway;
            int food;
            if (this.IsFoodAbundant || ((!this.HostileLine && (!this.FrontLine || !GameObject.Chance(20))) && !GameObject.Chance(1)))
            {
                if (this.TransferFoodArchitecture != null)
                {
                    LinkNode node = null;
                    this.AIAllLinkNodes.TryGetValue(this.TransferFoodArchitecture.ID, out node);
                    if (node != null)
                    {
                        connectedRouteway = this.GetRouteway(node, true);
                        if ((connectedRouteway != null) && (connectedRouteway.LastPoint != null))
                        {
                            if (this.BelongedFaction != this.TransferFoodArchitecture.BelongedFaction)
                            {
                                connectedRouteway.RemoveAfterClose = true;
                                connectedRouteway.Close();
                                this.TransferFoodArchitecture = null;
                            }
                            else
                            {
                                connectedRouteway.DestinationToEnd();
                                if (connectedRouteway.EndArchitecture == this.TransferFoodArchitecture)
                                {
                                    food = this.Food - this.EnoughFood;
                                    if ((food >= 0x186a0) || (food > this.TransferFoodArchitecture.FoodCostPerDayOfAllMilitaries))
                                    {
                                        if (connectedRouteway.IsActive)
                                        {
                                            int abundantFood = this.TransferFoodArchitecture.AbundantFood;
                                            if (food > abundantFood)
                                            {
                                                food = abundantFood;
                                            }
                                            this.DecreaseFood(food);
                                            this.TransferFoodArchitecture.IncreaseFood((int) (food * (1f - (connectedRouteway.LastPoint.ConsumptionRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures))));
                                            this.TransferFoodArchitecture = null;
                                        }
                                        else if ((connectedRouteway.LastPoint.BuildFundCost * 2) <= this.Fund)
                                        {
                                            connectedRouteway.Building = true;
                                        }
                                    }
                                    else
                                    {
                                        this.TransferFoodArchitecture = null;
                                    }
                                }
                                else
                                {
                                    this.TransferFoodArchitecture = null;
                                }
                            }
                        }
                        else
                        {
                            this.TransferFoodArchitecture = null;
                        }
                    }
                    else
                    {
                        this.TransferFoodArchitecture = null;
                    }
                }
            }
            else
            {
                GameObjectList list = new GameObjectList();
                foreach (LinkNode node in this.AIAllLinkNodes.Values)
                {
                    if (node.Level > 3)
                    {
                        break;
                    }
                    if (node.A.BelongedFaction == this.BelongedFaction)
                    {
                        if (node.A.BelongedSection == this.BelongedSection)
                        {
                            list.Add(node.A);
                        }
                        else if (node.A.BelongedSection.AIDetail.AllowFoodTransfer && ((node.A.BelongedSection.OrientationSection == this.BelongedSection) || (node.A.BelongedSection.OrientationSection == null)))
                        {
                            list.Add(node.A);
                        }
                    }
                }
                if (list.Count > 1)
                {
                    list.PropertyName = "Food";
                    list.IsNumber = true;
                    list.ReSort();
                }
                foreach (Architecture architecture in list)
                {
                    connectedRouteway = architecture.GetConnectedRouteway(this);
                    if ((connectedRouteway == null) || (connectedRouteway.LastPoint == null))
                    {
                        connectedRouteway = this.GetConnectedRouteway(architecture);
                    }
                    if ((connectedRouteway != null) && (connectedRouteway.LastPoint != null))
                    {
                        food = 0;
                        if (architecture.IsFoodTwiceAbundant && (architecture.RecentlyAttacked <= 0))
                        {
                            food = (architecture.FoodCostPerDayOfAllMilitaries * 80) / 5;
                            if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                            {
                                food *= 2;
                                if (food > architecture.Food)
                                {
                                    food = architecture.Food;
                                }
                            }
                        }
                        else if (architecture.IsFoodAbundant && !architecture.HostileLine)
                        {
                            food = (architecture.FoodCostPerDayOfAllMilitaries * 40) / 5;
                            if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                            {
                                food *= 2;
                                if (food > architecture.Food)
                                {
                                    food = architecture.Food;
                                }
                            }
                        }
                        if (food >= 0x186a0)
                        {
                            architecture.DecreaseFood(food);
                            this.IncreaseFood((int) (food * (1f - (connectedRouteway.LastPoint.ConsumptionRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures))));
                        }
                        else
                        {
                            architecture.TransferFoodArchitecture = null;
                        }
                    }
                    else if (architecture.TransferFoodArchitecture == null)
                    {
                        if ((((architecture.RecentlyAttacked == 0) && (!architecture.HostileLine || GameObject.Chance(20))) && (architecture.Food >= ((architecture.EnoughFood + this.EnoughFood) + 0x186a0))) && ((this.TransferFoodArchitectureCount <= GameObject.Random(2)) && (architecture.Food >= 0x61a80)))
                        {
                            architecture.TransferFoodArchitecture = this;
                        }
                    }
                    else if ((((architecture.BelongedFaction != this.BelongedFaction) || (this.BelongedFaction != architecture.TransferFoodArchitecture.BelongedFaction)) || ((architecture.RecentlyAttacked > 0) || architecture.TransferFoodArchitecture.IsFoodAbundant)) || ((architecture.Food < (architecture.EnoughFood + ((this.EnoughFood * 3) / 2))) && (architecture.Food < 0x61a80)))
                    {
                        architecture.TransferFoodArchitecture = null;
                    }
                }
            }
        }

        private void AIFundTransfer()
        {
            int fund;
            if (!this.IsFundEnough)
            {
                int num = this.EnoughFund - this.Fund;
                int num2 = 0;
                GameObjectList list = new GameObjectList();
                foreach (Architecture architecture in this.GetOtherArchitectureList())
                {
                    if (architecture.BelongedSection == this.BelongedSection)
                    {
                        list.Add(architecture);
                    }
                    else if (architecture.BelongedSection.AIDetail.AllowFundTransfer && ((architecture.BelongedSection.OrientationSection == this.BelongedSection) || (architecture.BelongedSection.OrientationSection == null)))
                    {
                        list.Add(architecture);
                    }
                }
                foreach (Architecture architecture in list)
                {
                    fund = 0;
                    if (architecture.Fund > architecture.AbundantFund)
                    {
                        fund = 0x3e8;
                        if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                        {
                            fund *= 2;
                            if (fund > architecture.Fund)
                            {
                                fund = architecture.Fund;
                            }
                        }
                    }
                    else if (architecture.Fund > architecture.EnoughFund)
                    {
                        fund = 500;
                        if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                        {
                            fund *= 2;
                            if (fund > architecture.Fund)
                            {
                                fund = architecture.Fund;
                            }
                        }
                    }
                    if (fund > 0)
                    {
                        architecture.DecreaseFund(fund);
                        this.AddFundPack(fund, base.Scenario.GetTranferFundDays(architecture, this));
                        num2 += fund;
                    }
                    if (num2 > num)
                    {
                        break;
                    }
                }
            }
            else if (((this.TransferFundArchitecture != null) && (this.TransferFundArchitecture.BelongedFaction == this.BelongedFaction)) && (this.TransferFundArchitecture.Fund < this.TransferFundArchitecture.FundCeiling))
            {
                fund = this.Fund - this.EnoughFund;
                if (fund > 500)
                {
                    this.DecreaseFund(fund);
                    this.TransferFundArchitecture.AddFundPack(fund, base.Scenario.GetTranferFundDays(this, this.TransferFundArchitecture));
                }
            }
            else if (this.BelongedSection != null && this.BelongedSection.AIDetail.AllowFundTransfer && this.IsFundAbundant)
            {
                foreach (Architecture architecture in this.GetOtherArchitectureList())
                {
                    if (!architecture.IsFundEnough)
                    {
                        fund = 0x3e8;
                        if (fund > this.Fund)
                        {
                            fund = this.Fund;
                        }
                        if (fund > 0)
                        {
                            this.DecreaseFund(fund);
                            architecture.AddFundPack(fund, base.Scenario.GetTranferFundDays(this, architecture));
                        }
                    }
                    if (!this.IsFundAbundant)
                    {
                        break;
                    }
                }
            }
        }


        */

        private Point? GetRandomStartingPosition(Troop troop)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            GameArea sourceArea = new GameArea();
            foreach (Point point in allAvailableArea.Area)
            {
                if (((base.Scenario.GetArchitectureByPosition(point) == this) && (base.Scenario.GetTroopByPosition(point) == null)) || troop.IsMovableOnPosition(point))
                {
                    sourceArea.Area.Add(point);
                }
            }
            if (sourceArea.Count == 0)
            {
                return null;
            }
            return sourceArea[GameObject.Random(sourceArea.Count)];
        }

        private Point? GetRandomStartingPosition(MilitaryKind mk)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            GameArea sourceArea = new GameArea();
            foreach (Point point in allAvailableArea.Area)
            {
                switch (base.Scenario.GetTerrainKindByPosition(point))
                {
                    case TerrainKind.山地:
                        if (mk.MountainAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.水域:
                        if (mk.WaterAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.平原:
                        if (mk.PlainAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.沙漠:
                        if (mk.DesertAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.峻岭:
                        if (mk.CliffAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.草原:
                        if (mk.GrasslandAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.荒地:
                        if (mk.WastelandAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.森林:
                        if (mk.ForrestAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.栈道:
                        if (mk.RidgeAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                    case TerrainKind.湿地:
                        if (mk.MarshAdaptability <= mk.Movability)
                        {
                            sourceArea.Area.Add(point);
                        }
                        break;
                }
            }
            if (sourceArea.Count == 0)
            {
                return null;
            }
            return sourceArea[GameObject.Random(sourceArea.Count)];
        }

        private Troop BuildTransportTroop(Architecture destination, Military military, int food, int fund)
        {
            Troop troop;
            int min = int.MaxValue;
            PersonList leader = new PersonList();
            foreach (Person p in this.Persons)
            {
                if (p.Merit < min)
                {
                    leader.Clear();
                    leader.Add(p);
                    min = p.Merit;
                }
            }
            if (leader.Count <= 0) return null;
            troop = Troop.CreateSimulateTroop(leader, military, this.Position);
            Point? nullable = this.GetRandomStartingPosition(troop);
            if (!nullable.HasValue)
            {
                return null;
            }
            troop = this.CreateTroop(leader, leader[0] as Person, military, food, nullable.Value);
            troop.WillArchitecture = destination;
            troop.zijin = fund;
            this.Fund -= fund;
            Legion legion = this.BelongedFaction.GetLegion(destination);
            if (legion == null)
            {
                legion = this.CreateOffensiveLegion(destination);
            }
            legion.AddTroop(troop);
            this.PostCreateTroop(troop, false);
            return troop;
        }

        private void AIMilitary()
        {
            foreach (Military military in this.GetLevelUpMilitaryList())
            {
                this.LevelUpMilitary(military);
            }
        }

        private void AIMilitaryTransfer()
        {
            if (this.HasHostileTroopsInView() || this.RecentlyAttacked > 0 || this.DefensiveLegion != null || !this.HasCampaignableMilitary()) return;
            if (this.HostileLine || this.FrontLine || this.noFactionFrontline) return;
            if (!this.IsFoodEnough) return;

            Person leader = this.BelongedFaction.Leader;
            int reserve = (int) (((leader.Calmness - leader.Braveness) * Parameters.AIBackendArmyReserveCalmBraveDifferenceMultiply +
                (5 - (int)leader.Ambition) * Parameters.AIBackendArmyReserveAmbitionMultiply)
                * Parameters.AIBackendArmyReserveMultiply + Parameters.AIBackendArmyReserveAdd);
            if (this.ArmyScale < reserve) return;

            if (!this.BelongedSection.AIDetail.AllowMilitaryTransfer && !this.BelongedSection.AIDetail.AllowOffensiveCampaign) return;

            int leastTroop = int.MaxValue;
            LinkNode target = null;
            foreach (LinkNode i in this.AIAllLinkNodes.Values)
            {
                if (i.Level > 1)
                {
                    break;
                }
                if (i.A.BelongedFaction != this.BelongedFaction) continue;

                if (!i.A.HostileLine && !i.A.FrontLine && !i.A.noFactionFrontline) continue;

                if (!this.BelongedSection.AIDetail.AllowMilitaryTransfer && i.A.BelongedSection != this.BelongedSection) continue;

                if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.军区 &&
                    this.BelongedSection.AIDetail.AllowMilitaryTransfer &&
                    i.A.BelongedSection != this.BelongedSection && i.A.BelongedSection != this.BelongedSection.OrientationSection) continue;

                if (!i.A.IsFoodEnough) continue;

                int weight = i.A.ArmyScale;

                if (i.A.orientationFrontLine)
                {
                    weight = (int) (weight * 0.5);
                }

                if (i.A.HostileLine)
                {
                    weight = (int) (weight * 0.75);
                }

                if (weight < leastTroop)
                {
                    target = i;
                    leastTroop = i.A.ArmyScale;
                }
            }

            /*if (target == null && GameObject.Random(10) == 0)
            {
                foreach (LinkNode i in this.AIAllLinkNodes.Values)
                {
                    if (i.Level > 1)
                    {
                        break;
                    }
                    if (i.A.BelongedFaction != this.BelongedFaction) continue;

                    if (!this.BelongedSection.AIDetail.AllowMilitaryTransfer && i.A.BelongedSection != this.BelongedSection) continue;

                    if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.军区 &&
                        this.BelongedSection.AIDetail.AllowMilitaryTransfer &&
                        i.A.BelongedSection != this.BelongedSection && i.A.BelongedSection != this.BelongedSection.OrientationSection) continue;

                    if (this.ArmyScale < i.A.ArmyScale / 1.5) continue;

                    if (!i.A.IsFoodEnough) continue;

                    int weight = i.A.ArmyScale;

                    if (i.A.orientationFrontLine)
                    {
                        weight = (int)(weight * 0.5);
                    }

                    if (i.A.HostileLine)
                    {
                        weight = (int)(weight * 0.75);
                    }

                    if (weight < leastTroop)
                    {
                        target = i;
                        leastTroop = i.A.ArmyScale;
                    }
                }
            }*/

            if (target != null)
            {
                MilitaryList leaderlessArmies = new MilitaryList();

                foreach (Military i in this.Militaries)
                {
                    if (i.FollowedLeader == null && (i.Leader == null || i.LeaderExperience < 10) && i.KindID != 29)
                    {
                        leaderlessArmies.Add(i);
                    }
                }

                if (leaderlessArmies.Count > this.Persons.Count + this.MovingPersons.Count)
                {
                    int minMerit = int.MaxValue;
                    Person personToMove = null;
                    foreach (Person p in this.BelongedFaction.Persons)
                    {
                        if (!p.IsCaptive && p.LocationArchitecture != null && p.LocationArchitecture.BelongedSection == this.BelongedSection && p.Status == PersonStatus.Normal 
                            && p.Merit < minMerit && p.BelongedArchitecture.PersonCount + p.BelongedArchitecture.MovingPersons.Count > 1)
                        {
                            personToMove = p;
                            minMerit = p.Merit;
                        }
                    }
                    if (personToMove != null && personToMove.WaitForFeiZi == null)
                    {
                        personToMove.MoveToArchitecture(this);
                    }
                }
                foreach (Military i in leaderlessArmies.GetRandomList())
                {
                    if (this.ArmyScale < reserve) break;
                    if (i.KindID == 29) continue;
                    if (GlobalVariables.AINoTeamTransfer && !target.A.FrontLine)
                    {
                        i.BelongedArchitecture = target.A;
                    }
                    else
                    {
                        this.BuildTroopForTransfer(i, target.A, target.Kind);
                    }
                }

                if (this.ArmyScale >= reserve)
                {
                    foreach (Military i in this.Militaries.GetRandomList())
                    {
                        if (this.ArmyScale < reserve) break;
                        if (this.Persons.Count <= 0) break;
                        if (i.KindID == 29) continue;
                        if (this.Persons.HasGameObject(i.Leader))
                        {
                            if (GlobalVariables.AINoTeamTransfer && !target.A.FrontLine)
                            {
                                i.BelongedArchitecture = target.A;
                            }
                            else
                            {
                                this.BuildTroopForTransfer(i, target.A, target.Kind);
                            }
                        }
                        else
                        {
                            Person armyLeader = i.FollowedLeader != null ? i.FollowedLeader : i.Leader;
                            if (armyLeader == null)
                            {
                                if (GlobalVariables.AINoTeamTransfer && !target.A.FrontLine)
                                {
                                    i.BelongedArchitecture = target.A;
                                }
                                else
                                {
                                    this.BuildTroopForTransfer(i, target.A, target.Kind);
                                }
                            } 
                            else if (!armyLeader.IsCaptive && armyLeader.LocationArchitecture != null && armyLeader.Status == PersonStatus.Normal && armyLeader.LocationArchitecture.BelongedSection == this.BelongedSection)
                            {
                                armyLeader.MoveToArchitecture(this);
                            }
                        }
                    }
                }
            }
        }

        private Troop BuildTroopForTransfer(Military military, Architecture destination, LinkKind linkkind)
        {
            if (linkkind == LinkKind.None)
            {
                return null;
            }
            if (!this.isArmyNavigableTo(linkkind, military))
            {
                return null;
            }
            if (this.Persons.Count == 0) return null;
            TroopList list = new TroopList();
            this.Persons.ClearSelected();
            if ((military.Scales > 5) && (military.Morale >= 80) && (military.Combativity >= 80) && (military.InjuryQuantity < military.Kind.MinScale) && !military.IsFewScaleNeedRetreat)
            {
                PersonList list2;
                Military military2 = military;
                if ((military2.FollowedLeader != null) && this.Persons.HasGameObject(military2.FollowedLeader) && military2.FollowedLeader.WaitForFeiZi == null && military2.FollowedLeader.LocationTroop == null)
                {
                    list2 = new PersonList();
                    list2.Add(military2.FollowedLeader);
                    military2.FollowedLeader.Selected = true;
                    Point? nullable = this.GetRandomStartingPosition(military2.Kind);
                    if (!nullable.HasValue)
                    {
                        return null;
                    }
                    
                    Troop troop = this.CreateTroop(list2, military2.FollowedLeader, military2, -1, nullable.Value);
                    troop.WillArchitecture = destination;
                    Legion legion = this.BelongedFaction.GetLegion(destination);
                    if (legion == null)
                    {
                        legion = this.CreateOffensiveLegion(destination);
                    }
                    legion.AddTroop(troop);
                    return troop;
                }
                if ((((military2.Leader != null) && (military2.LeaderExperience >= 10)) && (((military2.Leader.Strength >= 80) || (military2.Leader.Command >= 80)) || military2.Leader.HasLeaderValidCombatTitle))
                    && this.Persons.HasGameObject(military2.Leader) && military2.Leader.WaitForFeiZi == null && military2.Leader.LocationTroop == null)
                {
                    list2 = new PersonList();
                    list2.Add(military2.Leader);
                    military2.Leader.Selected = true;
                    Point? nullable = this.GetRandomStartingPosition(military2.Kind);
                    if (!nullable.HasValue)
                    {
                        return null;
                    }
                    Troop troop = this.CreateTroop(list2, military2.Leader, military2, -1, nullable.Value);
                    troop.WillArchitecture = destination;
                    Legion legion = this.BelongedFaction.GetLegion(destination);
                    if (legion == null)
                    {
                        legion = this.CreateOffensiveLegion(destination);
                    }
                    legion.AddTroop(troop);
                    return troop;
                }
                GameObjectList sortedList = this.Persons.GetList() as GameObjectList;
                sortedList.PropertyName = "FightingForce";
                sortedList.IsNumber = true;
                sortedList.SmallToBig = true;
                sortedList.ReSort();
                foreach (Person person in sortedList)
                {
                    if (!person.Selected && person.WaitForFeiZi == null && person.LocationTroop == null)
                    {
                        list2 = new PersonList();
                        list2.Add(person);
                        person.Selected = true;
                        Point? nullable = this.GetRandomStartingPosition(military2.Kind);
                        if (!nullable.HasValue)
                        {
                            break;
                        }
                        Troop troop = this.CreateTroop(list2, person, military2, -1, nullable.Value);
                        troop.WillArchitecture = destination;
                        Legion legion = this.BelongedFaction.GetLegion(destination);
                        if (legion == null)
                        {
                            legion = this.CreateOffensiveLegion(destination);
                        }
                        legion.AddTroop(troop);
                        return troop;
                    }
                }
            }
            return null;
        }


        private void AIMilitaryTransfer_OLD()
        {
            List<LinkNode> list;
            Routeway routeway;
            //if 
            //1. there is no person or 
            //2. has no hostile troop in view or 
            //3. is not recently attacked or
            //4. (has no campaignable military and no defensive legion and this arch is not important)
            //Then go on this branch for military transfer
            if (((!this.HasPerson() || !this.HasHostileTroopsInView()) || (this.RecentlyAttacked <= 0)) || ((!this.HasCampaignableMilitary() && (this.DefensiveLegion == null)) && !this.IsImportant))
            {
                //if there are hostile troop in view, do not transfer
                if (!this.HasHostileTroopsInView())
                {
                    LinkNode node;
                    if (this.BelongedSection != null && this.BelongedSection.AIDetail.AllowOffensiveCampaign)
                    {
                        //forget about transfer if offensive campaign allowed but there is no person, or no campaignable military, or has no space for any military to appear
                        if ((!this.HasPerson() || !this.HasCampaignableMilitary()) || (this.GetAllAvailableArea(false).Count == 0))
                        {
                            return;
                        }
                        foreach (Legion legion in this.BelongedFaction.Legions)
                        {
                            if ((((legion.WillArchitecture.BelongedFaction != null) && !this.BelongedFaction.IsFriendly(legion.WillArchitecture.BelongedFaction)) && this.BelongedFaction.IsArchitectureKnown(legion.WillArchitecture)) && (legion.Troops.Count < 30))
                            {
                                //if 
                                //1. there is no hostile troop in view, and
                                //2. allowed offensive campaign, and
                                //3. the legion is moving to some other faction, and
                                //4. the legion is moving to non-friendly faction, and
                                //5. the legion is moving to known arch, and
                                //6. the legion has less than 30 troops, and
                                //7. the legion is moving to arch which route from this arch exists, and
                                //8. the node is less than 2 cities away, and
                                //9. the legion has enough self-help army, and
                                //10. has less than double of hostile troop force, and
                                //then, build routeway to node and move to willarch
                                node = null;
                                if (this.AIAllLinkNodes.TryGetValue(legion.WillArchitecture.ID, out node))
                                {
                                    if ((node.Level > 2) || !this.IsSelfHelpArmyEnough(node))
                                    {
                                        continue;
                                    }
                                    if (legion.HasTroopWillArchitectureIsWillArchitecture && (legion.GetLegionTroopFightingForce() < (legion.GetLegionHostileTroopFightingForceInView() * 2)))
                                    {
                                        routeway = this.GetRouteway(node, true);
                                        if ((((routeway != null) && (routeway.LastPoint.ConsumptionRate <= 0.3f)) && (!routeway.ByPassHostileArchitecture && (this.Fund >= (routeway.LastPoint.BuildFundCost * 2)))) && this.IsSelfFoodEnough(node, routeway))
                                        {
                                            routeway.Building = true;
                                            this.BuildOffensiveTroop(legion.WillArchitecture, node.Kind, true);
                                            if (!(this.HasCampaignableMilitary() && (this.GetAllAvailableArea(false).Count != 0)))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((this.HasPerson() && this.HasCampaignableMilitary()) && (this.GetAllAvailableArea(false).Count != 0))
                    {
                        if ((((GameObject.Random(GameObject.Square(((int)this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0) && ((this.IsFoodAbundant || (this.IsFoodEnough && GameObject.Chance(0x21))) || GameObject.Chance(5))) && (((base.Scenario.Date.Season != GameSeason.冬) || GameObject.Chance(5)) && (!this.HostileLine || GameObject.Chance(10)))) && ((GameObject.Chance(20) && this.BelongedSection != null && this.BelongedSection.AIDetail.AllowMilitaryTransfer) || (this.BelongedSection != null && this.BelongedSection.AIDetail.ValueOffensiveCampaign && GameObject.Chance(50))))
                        {
                            //if
                            //1. there is person
                            //2. there is campaignable military
                            //3. there are space for military to appear
                            //4. 1/(stretagy tendency)^2 chance
                            //5. food is abundant or enough food with 33% chance or 5% chance
                            //6. season is not winter or 5% chance
                            //7. not at hostile line or 10% chance
                            //8. military transfer allowed and 20% chance, or offensive campaign allowed and 50% chance
                            //then, move military
                            GameObjectList list2 = null;
                            if ((this.BelongedSection.AIDetail.AllowMilitaryTransfer && (this.BelongedSection.OrientationSection != null)) && (this.BelongedSection.OrientationSection.BelongedFaction == this.BelongedFaction))
                            {
                                list2 = this.BelongedSection.OrientationSection.Architectures.GetList();
                            }
                            else
                            {
                                list2 = this.BelongedSection.Architectures.GetList();
                            }
                            foreach (Architecture architecture in list2.GetList())
                            {
                                if (architecture != this)
                                {
                                    node = null;
                                    this.AIAllLinkNodes.TryGetValue(architecture.ID, out node);
                                    if ((node == null) || (node.Level > 3) || node.Kind == LinkKind.Both || node.Kind == LinkKind.None)
                                    {
                                        list2.Remove(architecture);
                                    }
                                }
                            }
                            if (list2.Count > 0)
                            {
                                if (list2.Count > 1)
                                {
                                    list2.PropertyName = "InverseArmyScaleWeighing";
                                    list2.IsNumber = true;
                                    list2.ReSort();
                                }
                                Architecture destination = list2[0] as Architecture;
                                if (destination != this)
                                {
                                    node = null;
                                    this.AIAllLinkNodes.TryGetValue(destination.ID, out node);
                                    if ((node != null) && (destination.LandArmyScale < this.LandArmyScale || (destination.WaterArmyScale < this.WaterArmyScale && destination.Kind.HasHarbor)) && this.IsSelfMoveArmyEnough(node))
                                    {
                                        if (this.HasRouteway(node, true))
                                        {
                                            if ((this.BelongedSection.OrientationFaction == null) || (this.GetDistanceFromFaction(this.BelongedSection.OrientationFaction) > destination.GetDistanceFromFaction(this.BelongedSection.OrientationFaction)))
                                            {
                                                this.BuildOffensiveTroop(destination, node.Kind, false);
                                            }
                                            return;
                                        }
                                        if (list2.Count > 1)
                                        {
                                            list2.PropertyName = "Population";
                                            list2.IsNumber = true;
                                            list2.ReSort();
                                            if (list2[0] != destination)
                                            {
                                                destination = list2[0] as Architecture;
                                                this.AIAllLinkNodes.TryGetValue(destination.ID, out node);
                                                if ((node != null) && this.HasRouteway(node, true))
                                                {
                                                    this.BuildOffensiveTroop(destination, node.Kind, false);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        /*if ((GameObject.Random(GameObject.Square(((int)this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0)
                            && (((this.Fund < (100 * this.AreaCount)) && (this.ExpectedFund < (100 * this.AreaCount)))
                                || (
                                (((this.Domination > (this.DominationCeiling * 0.8)) && (this.Morale >= Parameters.RecruitmentMorale)) && (this.Endurance >= (this.EnduranceCeiling * 0.2f)))
                                && ((((((this.IsImportant && this.HostileLine) && (this.ArmyScale > this.LargeArmyScale)) || ((this.IsImportant && !this.HostileLine) && (this.ArmyScale > this.NormalArmyScale))) || (((!this.IsImportant && this.HostileLine) && (this.ArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && !this.HostileLine) && (this.ArmyScale > this.FewArmyScale))))
                                    || (this.Kind.HasPopulation && (this.ArmyQuantity > this.Population)))
                                    || (this.Kind.HasPopulation && (this.ArmyScale > (this.Population / 0x3e8)))))))
                        {
                            list = new List<LinkNode>();
                            foreach (LinkNode node_0a1 in this.AIAllLinkNodes.Values)
                            {
                                if (node_0a1.Level > 3)
                                {
                                    break;
                                }
                                if (((node_0a1.A.BelongedFaction == this.BelongedFaction)
                                    && ((node_0a1.A.RecentlyAttacked > 0) || GameObject.Chance(5)))
                                    && ((node_0a1.A.HasOffensiveMilitary()
                                    && ((node_0a1.A.BelongedSection == this.BelongedSection) || (this.BelongedSection != null && this.BelongedSection.AIDetail.AllowMilitaryTransfer && ((this.BelongedSection.OrientationSection == node_0a1.A.BelongedSection) || (this.BelongedSection.OrientationSection == null)))))
                                    && (node_0a1.A.IsFoodEnough
                                    && (((((node_0a1.A.IsImportant && node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.LargeArmyScale)) || ((node_0a1.A.IsImportant && !node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.NormalArmyScale))) || ((!node_0a1.A.IsImportant && node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.NormalArmyScale))) || ((!node_0a1.A.IsImportant && !node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.FewArmyScale))))))
                                {
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                    routeway = this.GetRouteway(node_0a1, true);
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                    if ((((routeway != null) && !routeway.ByPassHostileArchitecture) && (((routeway.LastPoint.BuildFundCost * 2) <= this.Fund) && (node_0a1.A.IsFoodAbundant || this.IsSelfFoodEnough(node_0a1, routeway)))) && ((node_0a1.A.Kind.HasPopulation && (node_0a1.A.HasHostileTroopsInView() || ((GameObject.Chance(10) && (node_0a1.A.ArmyQuantity < (node_0a1.A.Population / 2))) && (node_0a1.A.Population > (10000 * this.AreaCount))))) || (!node_0a1.A.Kind.HasPopulation && node_0a1.A.HasHostileTroopsInView())))
                                    {
                                        list.Add(node_0a1);
                                    }
                                }
                            }
                            if (list.Count > 0)
                            {
                                int num = -2147483648;
                                LinkNode node3 = null;
                                bool flag = false;
                                foreach (LinkNode node_0a2 in list)
                                {
                                    int num2 = node_0a2.A.Population / 0x2710;
                                    bool flag2 = node_0a2.A.RecentlyAttacked > 0;
                                    if (flag2)
                                    {
                                        num2 *= 10;
                                    }
                                    if (num2 > num)
                                    {
                                        num = num2;
                                        node3 = node_0a2;
                                        flag = flag2;
                                    }
                                }
                                if ((node3 != null) && (this.TargetingTroopCount(node3.A) < 4))
                                {
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                    routeway = this.GetRouteway(node3, true);
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                    if (routeway != null)
                                    {
                                        if (!routeway.IsActive && flag)
                                        {
                                            routeway.Building = true;
                                        }
                                        if (flag || GameObject.Chance(10))
                                        {
                                            this.BuildOffensiveTroop(node3.A, node3.Kind, node3.A.RecentlyAttacked > 0);
                                        }
                                    }
                                }
                            }
                        }*/
                        //111203: tranfer military from non-frontline to other bases
                        /*if ((GameObject.Random(GameObject.Square(((int)this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0))
                        {
                            if (!this.FrontLine && this.ArmyScale > this.NormalArmyScale)
                            {
                                List<LinkNode> candidate = new List<LinkNode>();
                                foreach (LinkNode i in this.AIAllLinkNodes.Values)
                                {
                                    //only do transfer to nearby bases
                                    if (i.Level > 1)
                                    {
                                        break;
                                    }
                                    if ((i.A.BelongedFaction == this.BelongedFaction)
                                        && ((i.A.BelongedSection == this.BelongedSection) || (this.BelongedSection.AIDetail.AllowMilitaryTransfer && ((this.BelongedSection.OrientationSection == i.A.BelongedSection) || (this.BelongedSection.OrientationSection == null))))
                                        && (i.A.IsFoodEnough)
                                        && (this.ArmyScale > i.A.ArmyScale)
                                        && (i.A.FrontLine))
                                    {
                                        this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                        routeway = this.GetRouteway(i, true);
                                        this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                        if ((routeway != null) && (!routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * 2) <= this.Fund))
                                        {
                                            candidate.Add(i);
                                        }
                                    }
                                }
                                if (candidate.Count > 0)
                                {
                                    int num = -2147483648;
                                    LinkNode node3 = null;
                                    bool flag = false;
                                    foreach (LinkNode node_0a2 in candidate)
                                    {
                                        int num2 = node_0a2.A.Population / 0x2710;
                                        bool flag2 = node_0a2.A.RecentlyAttacked > 0;
                                        if (flag2)
                                        {
                                            num2 *= 10;
                                        }
                                        if (num2 > num)
                                        {
                                            num = num2;
                                            node3 = node_0a2;
                                            flag = flag2;
                                        }
                                    }
                                    if ((node3 != null) && (this.TargetingTroopCount(node3.A) < 4))
                                    {
                                        this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                        routeway = this.GetRouteway(node3, true);
                                        this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                        if (routeway != null)
                                        {
                                            if (!routeway.IsActive && flag)
                                            {
                                                routeway.Building = true;
                                            }
                                            if (flag || GameObject.Chance(10))
                                            {
                                                //if it is trying to move across both land and water, consider only the first section and use that section!
                                                if (node3.Kind == LinkKind.None)
                                                {
                                                    List<Architecture> firstSectionOfPath = new List<Architecture>();
                                                    firstSectionOfPath.Add(node3.Path[0]);
                                                    firstSectionOfPath.Add(node3.Path[1]);
                                                    node3.Path = firstSectionOfPath;
                                                    node3.A = node3.Path[1];
                                                    node3.Level = 1;
                                                    node3.Distance = base.Scenario.GetDistance(node3.Path[0].ArchitectureArea, node3.Path[1].ArchitectureArea);
                                                    node3.Kind = this.CheckCampaignable(node3);
                                                }
                                                this.BuildOffensiveTroop(node3.A, node3.Kind, node3.A.RecentlyAttacked > 0);
                                            }
                                        }
                                    }
                                }
                            }
                        }*/
                    }
                }
            }
            else if ((((GameObject.Chance(20) || this.HasRelationUnderZeroHostileTroopsInView()) && ((this.IsImportant && (this.ArmyScale < this.NormalArmyScale)) || (!this.IsImportant && (this.ArmyScale < this.FewArmyScale)))) && ((this.Endurance >= (0.1 * this.EnduranceCeiling)) && ((this.IsImportant || !this.Kind.HasPopulation) || (this.Population >= (this.RecruitmentPopulationBoundary / 2))))) && (this.TargetingTroopCount(this) < 10))
            {
                LinkNode node2;
                list = new List<LinkNode>();
                foreach (LinkNode node in this.AIAllLinkNodes.Values)
                {
                    if (node.Level > 2)
                    {
                        break;
                    }
                    if (((((this.IsFriendly(node.A.BelongedFaction) && (node.A.BelongedSection != null)) && (node.A.BelongedSection.AIDetail != null)) && node.A.BelongedSection.AIDetail.AutoRun) && ((!node.A.HostileLine || GameObject.Chance(10)) && !node.A.HasHostileTroopsInView())) && this.IsNodeHelpArmyEnough(node))
                    {
                        node2 = null;
                        node.A.AIAllLinkNodes.TryGetValue(base.ID, out node2);
                        if (node2 != null)
                        {
                            routeway = node.A.GetRouteway(node2, true);
                            if ((((routeway != null) && !routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * 2) <= node.A.Fund)) && (this.IsFoodAbundant || this.IsNodeFoodEnough(node, routeway)))
                            {
                                list.Add(node);
                            }
                        }
                    }
                }
                if (list.Count > 0)
                {
                    foreach (LinkNode node in list)
                    {
                        node2 = null;
                        node.A.AIAllLinkNodes.TryGetValue(base.ID, out node2);
                        if (node2 != null)
                        {
                            routeway = node.A.GetRouteway(node2, true);
                            if (routeway != null)
                            {
                                if (!routeway.IsActive)
                                {
                                    routeway.Building = true;
                                }
                                node.A.BuildOffensiveTroop(this, node.Kind, true);
                                if (GameObject.Chance(10))
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }




        private void AIRecruitment(bool water, bool siege)
        {
            if (this.Population > 0)
            {
                MilitaryKind current;
                Dictionary<int, MilitaryKind>.ValueCollection.Enumerator enumerator;
                MilitaryKindList list = new MilitaryKindList();
                MilitaryKindList allMilitaries = new MilitaryKindList();
                using (enumerator = this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (current.ID == 29) continue;
                        if (current.Type == MilitaryType.水军 && this.AIWaterLinks.Count == 0) continue;
                        if (current.Type != MilitaryType.水军 && this.AILandLinks.Count == 0) continue;
                        if (((water && current.Type == MilitaryType.水军) || (!water && current.Type != MilitaryType.水军))
                            && ((siege && current.Type == MilitaryType.器械) || (!siege && current.Type != MilitaryType.器械))
                            && current.CreateAvail(this))
                        {
                            list.Add(current);
                        }
                        if (current.CreateAvail(this))
                        {
                            allMilitaries.Add(current);
                        }
                        /*if ((((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this)) && (current.ID != 29))
                        {
                            list.Add(current);
                        }*/
                    }
                }
                using (enumerator = this.PrivateMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (current.ID == 29) continue;
                        if (current.Type == MilitaryType.水军 && this.AIWaterLinks.Count == 0) continue;
                        if (current.Type != MilitaryType.水军 && this.AILandLinks.Count == 0) continue;
                        if (((water && current.Type == MilitaryType.水军) || (!water && current.Type != MilitaryType.水军))
                            && ((siege && current.Type == MilitaryType.器械) || (!siege && current.Type != MilitaryType.器械))
                            && current.CreateAvail(this))
                        {
                            list.Add(current);
                        }
                        if (current.CreateAvail(this))
                        {
                            allMilitaries.Add(current);
                        }
                        /*current = enumerator.Current;
                        if ((((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this)) && (current.ID != 29))
                        {
                            list.Add(current);
                        }*/
                    }
                }
                if (list.Count > 0)
                {
                    current = list[GameObject.Random(list.Count)] as MilitaryKind;
                    this.CreateMilitary(current.findSuccessorCreatable(list, this));
                }
                else if (allMilitaries.Count > 0)
                {
                    current = allMilitaries[GameObject.Random(allMilitaries.Count)] as MilitaryKind;
                    this.CreateMilitary(current.findSuccessorCreatable(allMilitaries, this));
                }
                    /*if (GameObject.Chance(90))
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                        int maxValue = list.Count / 2;
                        if (list.Count > 1)
                        {
                            for (int i = maxValue; i < list.Count; i++)
                            {
                                if ((list[i] as MilitaryKind).Merit == (list[i - 1] as MilitaryKind).Merit)
                                {
                                    maxValue++;
                                }
                            }
                        }
                        current = list[GameObject.Random(maxValue)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }
                    else
                    {
                        current = list[GameObject.Random(list.Count)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }*/
            }
        }



        public bool CompletelyDeveloped
        {
            get
            {
                return (this.Agriculture >= this.AgricultureCeiling && this.Commerce >= this.CommerceCeiling && this.Technology >= this.TechnologyCeiling &&
                    this.Domination >= this.DominationCeiling && this.Endurance >= this.EnduranceCeiling && this.Morale >= this.MoraleCeiling);
            }
        }



        private void AITrade()
        {
            if ((base.Scenario.Date.Day % Parameters.AITradePeriod) == 1)
            {
                int num;
                if (this.BuyFoodAvail())
                {
                    if (this.Fund > this.EnoughFund * 2 && !this.IsFoodEnough)
                    {
                        num = this.Fund - this.EnoughFund * 2;
                        if (num > 0)
                        {
                            this.BuyFood(num);
                        }
                    }
                    else if (this.Fund > this.AbundantFund * 2 && !this.IsFoodAbundant)
                    {
                        num = this.Fund - this.AbundantFund * 2;
                        if (num > 0)
                        {
                            this.BuyFood(num);
                        }
                    }
                    else if (this.Fund >= this.FundCeiling / 2 && this.Food < FoodCeiling / 2)
                    {
                        num = this.Fund - this.FundCeiling / 2;
                        if (num > 0)
                        {
                            this.BuyFood(num);
                        }
                    }
                    /*if ((((this.PlanArchitecture == null) && (this.PlanFacilityKind == null)) && (this.BelongedFaction.PlanTechniqueArchitecture != this)) && (((this.Fund >= (this.FundCeiling / 2)) || !this.IsFoodEnough) && this.IsFundAbundant))
                    {
                        num = this.Fund - this.AbundantFund;
                        if (num > 0)
                        {
                            this.BuyFood(num / 2);
                        }
                    }*/
                }
                else if (this.SellFoodAvail())
                {
                    if (!this.IsFundEnough && this.Food > this.EnoughFood * 2)
                    {
                        num = this.Food - this.EnoughFood * 2;
                        if (num > 0)
                        {
                            this.SellFood(num);
                        }
                    }
                    else if (!this.IsFundAbundant && this.Food > this.AbundantFood * 2)
                    {
                        num = this.Food - this.AbundantFood * 2;
                        if (num > 0)
                        {
                            this.SellFood(num);
                        }
                    }
                    else if (this.Fund < this.FundCeiling / 2 && this.Food >= FoodCeiling / 2)
                    {
                        num = this.Food - this.FoodCeiling / 2;
                        if (num > 0)
                        {
                            this.SellFood(num);
                        }
                    }
                }
                /*else if ((this.SellFoodAvail() && ((this.PlanArchitecture == null) && (this.TransferFoodArchitecture == null))) && (((!this.HostileLine && (this.Fund < (this.FundCeiling / 2))) && !this.IsFoodEnough) && this.IsFoodAbundant))
                {
                    num = this.Food - this.AbundantFood;
                    if (num > 0)
                    {
                        this.SellFood(num / 10);
                    }
                }*/
            }
        }

        private void AITransfer()
        {
            if (this.BelongedFaction.ArchitectureCount > 1)
            {
                this.AIMilitaryTransfer();
                this.AIPersonTransfer();
                this.AIResourceTransfer();
            }
        }

        private void AITreasure()
        {
            if (GameObject.Chance(Parameters.AITreasureChance) && !base.Scenario.IsPlayer(this.BelongedFaction))
            {
                if (this.HasTreasureToConfiscate())
                {
                    foreach (Person person in this.Persons.GetList())
                    {
                        if (((person != this.BelongedFaction.Leader) && (person.TreasureCount > 0)) && ((person.TreasureCount > Parameters.AITreasureCountMax) ||
                            ((((person.PersonalTitle == null) && GameObject.Chance(50)) || (((person.PersonalTitle != null) && (person.PersonalTitle.Level * Parameters.AITreasureCountCappedTitleLevelMultiply + Parameters.AITreasureCountCappedTitleLevelAdd <= person.TreasureCount)) && GameObject.Chance(25)))
                            && ((person.CombatTitle == null) || (((person.CombatTitle != null) && (person.CombatTitle.Level * Parameters.AITreasureCountCappedTitleLevelMultiply + Parameters.AITreasureCountCappedTitleLevelAdd <= person.TreasureCount)) && GameObject.Chance(50))))))
                        {
                            foreach (Treasure treasure in person.Treasures.GetRandomList())
                            {
                                person.ConfiscatedTreasure(treasure);
                                this.BelongedFaction.Leader.ReceiveTreasure(treasure);
                                break;
                            }
                        }
                    }
                }
                if (((this.BelongedFaction.Leader != null) && (this.BelongedFaction.Leader.TreasureCount > Parameters.AITreasureCountMax)) && this.HasTreasureToAward())
                {
                    GameObjectList list = this.Persons.GetList();
                    list.PropertyName = "FightingForce";
                    list.IsNumber = true;
                    list.ReSort();
                    foreach (Person person in list)
                    {
                        if ((person == this.BelongedFaction.Leader) || (person.TreasureCount != 0))
                        {
                            continue;
                        }
                        if ((((person.PersonalTitle != null) && (person.PersonalTitle.Level > 1)) && (person.CombatTitle != null)) && (person.CombatTitle.Level > 1)
                            && person.TreasureCount < person.PersonalTitle.Level * Parameters.AITreasureCountCappedTitleLevelMultiply + Parameters.AITreasureCountCappedTitleLevelAdd
                            && person.TreasureCount < person.CombatTitle.Level * Parameters.AITreasureCountCappedTitleLevelMultiply + Parameters.AITreasureCountCappedTitleLevelAdd)
                        {
                            foreach (Treasure treasure in this.BelongedFaction.Leader.Treasures.GetRandomList())
                            {
                                if (treasure.Worth < Parameters.AIGiveTreasureMaxWorth)
                                {
                                    this.BelongedFaction.Leader.LoseTreasure(treasure);
                                    person.AwardedTreasure(treasure);
                                    break;
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }
        /*
        private void AIWork()
        {
            this.AIAutoHire();
            this.StopAllWork();
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && this.HasPerson())
            {
                int num;
                this.ReSortAllWeighingList();
                bool isFundAbundant = this.IsFundAbundant;
                if (this.Fund < ((100 * this.AreaCount) + ((30 - base.Scenario.Date.Day) * this.FacilityMaintenanceCost)))
                {
                    MilitaryList trainingMilitaryList = this.GetTrainingMilitaryList();
                    if (trainingMilitaryList.Count > 0)
                    {
                        trainingMilitaryList.IsNumber = true;
                        trainingMilitaryList.PropertyName = "Weighing";
                        trainingMilitaryList.ReSort();
                        GameObjectList maxObjects = this.trainingPersons.GetMaxObjects(trainingMilitaryList.Count);
                        for (num = 0; num < maxObjects.Count; num++)
                        {
                            this.AddPersonToTrainingWork(maxObjects[num] as Person, trainingMilitaryList[num] as Military);
                        }
                    }
                    int num2 = 0;
                    if ((GameObject.Chance(50) && this.Kind.HasDomination) && (this.Domination < (this.DominationCeiling * 0.8)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasEndurance) && (this.Endurance < (this.EnduranceCeiling * 0.2f)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasMorale) && (this.Morale < Parameters.RecruitmentMorale))
                    {
                        num2++;
                    }
                    if (num2 > 0)
                    {
                        for (num = 0; num < (this.Persons.Count - trainingMilitaryList.Count); num += num2)
                        {
                            foreach (Person person in this.dominationPersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToDominationWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.endurancePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToEnduranceWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.moralePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToMoraleWorkingList(person);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((GameObject.Chance(20) || !this.HasBuildingRouteway) || this.IsFundEnough)
                {
                    float num3;
                    bool flag2 = this.RecentlyAttacked > 0;
                    WorkRateList list3 = new WorkRateList();
                    if ((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) || GameObject.Chance(20))
                    {
                        if (!flag2 || !GameObject.Chance(80))
                        {
                            if (this.Kind.HasAgriculture && (this.Agriculture < this.AgricultureCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueAgriculture)
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Agriculture) / 4f) / ((float) this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Agriculture) / ((float) this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                            }
                            if (this.Kind.HasCommerce && (this.Commerce < this.CommerceCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueCommerce)
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Commerce) / 4f) / ((float) this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Commerce) / ((float) this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                            }
                            if (this.Kind.HasTechnology && (this.Technology < this.TechnologyCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueTechnology || (GameObject.Chance(50) && (this.IsStateAdmin || this.IsRegionCore)))
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Technology) / 4f) / ((float) this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Technology) / ((float) this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                            }
                        }
                        if (this.Kind.HasDomination && (this.Domination < this.DominationCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueDomination)
                            {
                                list3.AddWorkRate(new WorkRate(((((float) this.Domination) / 5f) / 4f) / ((float) this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Domination) / 5f) / ((float) this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                        }
                        if (this.Kind.HasMorale && (this.Morale < this.MoraleCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueMorale)
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Morale) / 4f) / ((float) this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float) this.Morale) / ((float) this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                        }
                        if (this.Kind.HasEndurance && (this.Endurance < this.EnduranceCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueEndurance)
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Endurance) / 4f) / ((float) this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float) this.Endurance) / ((float) this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                        }
                    }
                    MilitaryList list4 = this.GetTrainingMilitaryList();
                    if (list4.Count > 0)
                    {
                        if (flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.训练));
                        }
                        else
                        {
                            num3 = 0f;
                            foreach (Military military in list4)
                            {
                                num3 += ((float) military.TrainingWeighing) / ((float) military.MaxTrainingWeighing);
                            }
                            num3 /= (float) list4.Count;
                            if (this.BelongedSection.AIDetail.ValueTraining)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.训练));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.训练));
                            }
                        }
                    }
                    MilitaryList recruitmentMilitaryList = null;
                    if (((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) && this.Kind.HasPopulation) && ((flag2 || (GameObject.Random(GameObject.Square(((int) this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0)) && this.RecruitmentAvail()))
                    {
                        recruitmentMilitaryList = this.GetRecruitmentMilitaryList();
                        if ((this.ArmyScale < this.FewArmyScale) && flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if (((this.ArmyScale < this.FewArmyScale) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(20)) || GameObject.Chance(5))) && this.IsFoodAbundant)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if ((((GameObject.Chance(1) || (this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(5))) && ((this.ArmyScale >= this.LargeArmyScale) && this.IsFoodAbundant)) || ((((this.ArmyScale < this.LargeArmyScale) && this.IsFoodEnough) && (((this.IsImportant || (this.AreaCount > 2)) && (this.Population > this.Kind.PopulationBoundary)) || (((this.AreaCount <= 2) && !this.IsImportant) && (this.Population > (this.RecruitmentPopulationBoundary / 2))))) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(60)) || GameObject.Chance(15)))) && (GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length) >=(int) this.BelongedFaction.Leader.StrategyTendency))
                        {
                            num3 = 0f;
                            foreach (Military military in recruitmentMilitaryList)
                            {
                                num3 += ((float) military.RecruitmentWeighing) / ((float) military.MaxRecruitmentWeighing);
                            }
                            num3 /= (float) recruitmentMilitaryList.Count;
                            if (this.BelongedSection.AIDetail.ValueRecruitment)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.补充));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.补充));
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        for (num = 0; num < this.Persons.Count; num += list3.Count)
                        {
                            foreach (WorkRate rate in list3.RateList)
                            {
                                switch (rate.workKind)
                                {
                                    case ArchitectureWorkKind.农业:
                                        foreach (Person person in this.agriculturePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.AgricultureAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToAgricultureWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.商业:
                                        foreach (Person person in this.commercePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.CommerceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToCommerceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.技术:
                                        foreach (Person person in this.technologyPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.TechnologyAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToTechnologyWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.统治:
                                        foreach (Person person in this.dominationPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.DominationAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToDominationWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.民心:
                                        foreach (Person person in this.moralePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.MoraleAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToMoraleWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.耐久:
                                        foreach (Person person in this.endurancePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.EnduranceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToEnduranceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.训练:
                                        foreach (Person person in this.trainingPersons)
                                        {
                                            if (person.WorkKind == ArchitectureWorkKind.无)
                                            {
                                                foreach (Military military in list4.GetRandomList())
                                                {
                                                    if (military.RecruitmentPersonID < 0)
                                                    {
                                                        this.AddPersonToTrainingWork(person, military);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.补充:
                                        foreach (Person person in this.recruitmentPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.RecruitmentAbility >= 120)))
                                            {
                                                if (recruitmentMilitaryList != null)
                                                {
                                                    foreach (Military military in recruitmentMilitaryList.GetRandomList())
                                                    {
                                                        if (military.TrainingPersonID < 0)
                                                        {
                                                            this.AddPersonToRecuitmentWork(person, military);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if (this.Kind.HasPopulation && (flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)))
                    {
                        if (((!flag2 && !this.BelongedSection.AIDetail.ValueNewMilitary) && !GameObject.Chance(10)) || (this.ArmyScale >= this.LargeArmyScale))
                        {
                            MilitaryList list6 = new MilitaryList();
                            foreach (Military military in this.Militaries)
                            {
                                if ((((military.Scales < 15) && (military.Quantity > 0)) && (military.Morale < (military.MoraleCeiling / 2))) && ((military.Kind.PointsPerSoldier <= 1) && (this.BelongedFaction.TechniquePoint > (military.Quantity * (military.Kind.PointsPerSoldier + 1)))))
                                {
                                    list6.Add(military);
                                }
                            }
                            foreach (Military military in list6)
                            {
                                this.DisbandMilitary(military);
                            }
                        }
                        else if (((this.Population > this.RecruitmentPopulationBoundary) || flag2) || ((this.Population >= 10000) && GameObject.Chance(5)))
                        {
                            bool flag3 = true;
                            foreach (Military military in this.Militaries)
                            {
                                if (military.Scales < 15)
                                {
                                    flag3 = false;
                                    break;
                                }
                            }
                            if (flag3)
                            {
                                this.AIRecruitment(false);
                            }
                            else if ((this.ValueWater && !this.HasShuijun()) && this.HasShuijunMilitaryKind())
                            {
                                this.AIRecruitment(true);
                            }
                        }
                    }
                }
            }
        }

        */

        public void AllEnter()
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction == this.BelongedFaction)) && troopByPosition.ControlAvail())
                {
                    troopByPosition.Enter(this);
                }
            }
        }

        public bool AllEnterAvail()
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction == this.BelongedFaction)) && troopByPosition.ControlAvail())
                {
                    return true;
                }
            }
            return false;
        }

        public void PurifyFactionInfluences()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        i.PurifyInfluence(this, Applier.Technique, t.ID);
                    }
                }
            }
        }

        public void ApplyFactionInfluences()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        i.ApplyInfluence(this, Applier.Technique, t.ID);
                    }
                }
            }
        }

        public void ApplyInfluences()
        {
            this.Characteristics.ApplyInfluence(this, Applier.Characteristics, 0);
            if (this.FacilityEnabled)
            {
                this.ApplyFacilityInfluences(false);
            }
        }

        public void ApplyFacilityInfluences(bool skipNoCostFacility)
        {
            foreach (Facility facility in this.Facilities)
            {
                if (!skipNoCostFacility || facility.MaintenanceCost > 0)
                {
                    facility.Influences.ApplyInfluence(this, Applier.Facility, facility.ID);
                }
            }
        }

        public bool ArchitectureHasFacilityKind(int id)
        {

            foreach (Facility facility in this.Facilities)
            {
                if (facility.KindID == id || this.BuildingFacility == id)
                {
                    return true;
                }
            }
            return false;
        }

        public string ArmyQuantityInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x2710);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x1388);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x3e8);

                case InformationLevel.全:
                    return this.ArmyQuantity.ToString();
            }
            return "----";
        }

        private void AutoDecrement()
        {
            /*if (!(((this.BelongedFaction == null) || (this.RecentlyAttacked <= 0)) || this.DayAvoidInternalDecrementOnBattle))
            {
                int maxValue = (this.RecentlyAttacked / 2) + 1;
                this.DecreaseAgriculture(GameObject.Random(maxValue));
                this.DecreaseCommerce(GameObject.Random(maxValue));
                this.DecreaseTechnology(GameObject.Random(maxValue));
                this.DecreaseMorale(GameObject.Random(maxValue));
            }*/
        }

        public bool AutoHiringAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        private void AutoIncrement()
        {
            if (this.IncrementOfAgriculturePerDay > 0)
            {
                this.IncreaseAgriculture(this.IncrementOfAgriculturePerDay);
            }
            if (this.IncrementOfCommercePerDay > 0)
            {
                this.IncreaseCommerce(this.IncrementOfCommercePerDay);
            }
            if (this.IncrementOfTechnologyPerDay > 0)
            {
                this.IncreaseTechnology(this.IncrementOfTechnologyPerDay);
            }
            if (this.IncrementOfDominationPerDay > 0)
            {
                this.IncreaseDomination(this.IncrementOfDominationPerDay);
            }
            if (this.IncrementOfMoralePerDay > 0)
            {
                this.IncreaseMorale(this.IncrementOfMoralePerDay);
            }
            if ((this.IncrementOfEndurancePerDay > 0) && !((this.Endurance <= 0) && this.HasContactHostileTroop(this.BelongedFaction)))
            {
                this.IncreaseEndurance(this.IncrementOfEndurancePerDay);
            }
            if ((this.IncrementOfFactionReputationPerDay > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseReputation(this.IncrementOfFactionReputationPerDay);
            }
            if ((this.IncrementOfFactionTechniquePointPerDay > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.IncrementOfFactionTechniquePointPerDay);
            }
            if ((this.Technology > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.Technology / 5);
            }
            if ((this.BelongedFaction == null) && ((this.RecentlyAttacked <= 0) && !this.HasHostileTroopsInArchitecture()))
            {
                if (this.Endurance < (50 * this.AreaCount))
                {
                    this.Endurance++;
                }
                if (this.Domination < 30)
                {
                    this.Domination++;
                }
            }
        }

        public bool AutoRewardingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public bool AutoSearchingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public bool AutoWorkingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public void BeginToBuildAFacility(FacilityKind facilityKind)
        {
            this.BuildingFacility = facilityKind.ID;
            this.BuildingDaysLeft = (int) (facilityKind.Days * (1 - this.facilityConstructionTimeRateDecrease));
            this.DecreaseFund(facilityKind.FundCost);
            if (this.BelongedFaction.TechniquePoint < facilityKind.PointCost)
            {
                this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost - this.BelongedFaction.TechniquePoint);
                if (this.BelongedFaction.TechniquePoint < facilityKind.PointCost)
                {
                    this.BelongedFaction.DepositTechniquePointForTechnique(facilityKind.PointCost - this.BelongedFaction.TechniquePoint);
                }
            }
            this.BelongedFaction.DecreaseTechniquePoint(facilityKind.PointCost);
            if (this.HasSpy)
            {
                this.CreateNewFacilitySpyMessage(facilityKind);
            }
			ExtensionInterface.call("StartBuildFacility", new Object[] { this.Scenario, this, facilityKind });
        }

        public void BuildFacility(FacilityKind facilityKind)
        {
            Facility facility = new Facility();
            facility.ID = base.Scenario.Facilities.GetFreeGameObjectID();
            facility.Scenario = base.Scenario;
            facility.KindID = facilityKind.ID;
            facility.Endurance = facilityKind.Endurance;
            this.Facilities.AddFacility(facility);
            base.Scenario.Facilities.AddFacility(facility);
            if (this.FacilityEnabled)
            {
                facility.Influences.ApplyInfluence(this, Applier.Facility, facility.ID);
            }
            if (this.OnFacilityCompleted != null)
            {
                this.OnFacilityCompleted(this, facility);
            }
			ExtensionInterface.call("BuiltFacility", new Object[] { this.Scenario, this, facilityKind });
        }

        public bool BuildFacilityAvail()
        {
            return ((this.BuildingFacility < 0) && (this.GetBuildableFacilityKindList().Count > 0));
        }

        private Troop BuildOffensiveTroop(Architecture destination, LinkKind linkkind, bool offensive)
        {
            Troop troop;
            if (linkkind == LinkKind.None)
            {
                return null;
            }
            TroopList list = new TroopList();
            this.Persons.ClearSelected();
            //Label_0309:
            foreach (Military military in this.Militaries.GetRandomList())
            {
                if (military.IsFewScaleNeedRetreat) continue;
                if (military.KindID == 29) continue; //never deal with transports in this function
                switch (linkkind)
                {
                    case LinkKind.Land:
                        {
                            if (military.Kind.Type != MilitaryType.水军)
                            {
                                break;
                            }
                            continue;
                        }
                    case LinkKind.Water:
                        {
                            //if ((military.Kind.Type == MilitaryType.水军) || (this.ValueWater && (!offensive || ((military.Quantity >= 0x1f40) && (GameObject.Random(military.Kind.Merit) <= 0)))))
                            if (GlobalVariables.LandArmyCanGoDownWater)
                            {
                                if (!offensive || (military.KindID != 28 && military.KindID != 29))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (military.Kind.Type == MilitaryType.水军)
                                {
                                    break;
                                }
                            }
                            continue;
                        }
                }
                if ((((military.Scales > 5) && (military.Morale >= 80)) && (military.Combativity >= 80)) && (military.InjuryQuantity < military.Kind.MinScale)
                    && (!offensive || (military.KindID != 29))) //do not use transport teams to attack
                {
                    TroopList candidates = this.AISelectPersonIntoTroop(this, military);
                    foreach (Troop t in candidates)
                    {
                        list.Add(t);
                    }
                }
            }
            if (list.Count > 0)
            {
                list.IsNumber = true;
                list.PropertyName = "SimulatingFightingForce";
                list.ReSort();
                foreach (Troop troop2 in list.GetList())
                {
                    bool personAlreadyOut = false;
                    foreach (Person p in troop2.Candidates)
                    {
                        if (p.LocationTroop != null)
                        {
                            personAlreadyOut = true;
                            break;
                        }
                    }
                    bool militaryOut = true;
                    foreach (Military m in this.Militaries)
                    {
                        if (troop2.Army == m)
                        {
                            militaryOut = false;
                            break;
                        }
                    }
                    if (personAlreadyOut) continue;
                    if (militaryOut) continue;
                    if (troop2.FightingForce < 10000 && offensive)
                    {
                        break;
                    }
                    Point? nullable = this.GetRandomStartingPosition(troop2);
                    if (!nullable.HasValue)
                    {
                        break;
                    }
                    Person leader = troop2.Candidates[0] as Person;
                    PersonList candidates = this.SelectSubOfficersToTroop(troop2);
                    troop = this.CreateTroop(candidates, leader, troop2.Army, -1, nullable.Value);
                    troop.WillArchitecture = destination;
                    Legion legion = this.BelongedFaction.GetLegion(destination);
                    if (legion == null)
                    {
                        legion = this.CreateOffensiveLegion(destination);
                    }
                    legion.AddTroop(troop);
                    this.PostCreateTroop(troop, false);
                }
            }
            return null;
        }

        internal bool IsSelfFoodEnoughForOffensive(LinkNode node, Routeway routeway)
        {
            MilitaryList cropConsumptionOrderedList = Militaries;
            cropConsumptionOrderedList.PropertyName = "FoodCostPerDay";
            cropConsumptionOrderedList.IsNumber = true;
            cropConsumptionOrderedList.ReSort();
            PersonList leaderablePersonList = new PersonList();
            foreach (Person p in this.Persons)
            {
                if (p.Command >= 40)
                {
                    leaderablePersonList.Add(p);
                }
            }
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    {
                        int crop = 0;
                        int troopCnt = 0;
                        foreach (Military m in cropConsumptionOrderedList)
                        {
                            if ((((m.Scales >= 3) && (m.Morale >= 80)) && (m.Combativity >= 80)) && (m.InjuryQuantity < m.Kind.MinScale) && m.Kind.Type != MilitaryType.水军)
                            {
                                crop += m.FoodCostPerDay;
                                troopCnt++;
                                if (troopCnt >= leaderablePersonList.Count) break;
                            }
                        }
                        if (routeway.LastPoint == null) return false;
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (crop * ((routeway.Length + 6) - (this.LandArmyScale / 8))));
                    }

                case LinkKind.Water:
                    {
                        int crop = 0;
                        int troopCnt = 0;
                        foreach (Military m in cropConsumptionOrderedList)
                        {
                            if ((((m.Scales >= 3) && (m.Morale >= 80)) && (m.Combativity >= 80)) && (m.InjuryQuantity < m.Kind.MinScale) && m.Kind.Type == MilitaryType.水军)
                            {
                                crop += m.FoodCostPerDay;
                                troopCnt++;
                                if (troopCnt >= leaderablePersonList.Count) break;
                            }
                        }
                        if (routeway.LastPoint == null) return false;
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (crop * ((routeway.Length + 6) - (this.WaterArmyScale / 8))));
                    }

                case LinkKind.Both:
                    {
                        int crop = 0;
                        int troopCnt = 0;
                        foreach (Military m in cropConsumptionOrderedList)
                        {
                            if ((((m.Scales >= 3) && (m.Morale >= 80)) && (m.Combativity >= 80)) && (m.InjuryQuantity < m.Kind.MinScale))
                            {
                                crop += m.FoodCostPerDay;
                                troopCnt++;
                                if (troopCnt >= leaderablePersonList.Count) break;
                            }
                        }
                        if (routeway.LastPoint == null) return false;
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (crop * ((routeway.Length + 6) - (this.ArmyScale / 8))));
                    }
            }
            return false;
        }

        public Routeway BuildRouteway(LinkNode node, bool hasEnd)
        {
            Point key = new Point(base.ID, node.A.ID);
            if (!this.BelongedFaction.ClosedRouteways.ContainsKey(key))
            {
                Point? nullable;
                Point? nullable2;
                base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), node.A.GetAIRoutewayEndPoints(this, true), out nullable, out nullable2);
                if (nullable.HasValue && nullable2.HasValue)
                {
                    this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = false;
                    this.BelongedFaction.RoutewayPathBuilder.MustUseWater = node.Kind == LinkKind.Water;
                    if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, hasEnd))
                    {
                        Routeway routeway = this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
                        routeway.DestinationArchitecture = node.A;
                        if (hasEnd)
                        {
                            routeway.EndArchitecture = node.A;
                        }
                        return routeway;
                    }
                    this.BelongedFaction.ClosedRouteways.Add(new Point(base.ID, node.A.ID), null);
                }
            }
            return null;
        }

        public Routeway BuildShortestRouteway(Architecture des, bool noWater)
        {
            Point? nullable;
            Point? nullable2;
            if (!noWater)
            {
                Point key = new Point(base.ID, des.ID);
                if (this.BelongedFaction.ClosedRouteways.ContainsKey(key))
                {
                    return null;
                }
            }
            base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), des.GetRoutewayStartPoints(), out nullable, out nullable2);
            if (nullable.HasValue && nullable2.HasValue)
            {
                this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = noWater;
                if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, true))
                {
                    Routeway routeway = this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
                    routeway.DestinationArchitecture = des;
                    routeway.EndArchitecture = des;
                    return routeway;
                }
                if (!noWater)
                {
                    this.BelongedFaction.ClosedRouteways.Add(new Point(base.ID, des.ID), null);
                }
            }
            return null;
        }

        public Routeway BuildShortestRouteway(Point point, bool noWater)
        {
            Point closestPoint = base.Scenario.GetClosestPoint(this.GetRoutewayStartPoints(), point);
            this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = noWater;
            if (this.BelongedFaction.RoutewayPathAvail(closestPoint, point, true))
            {
                return this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
            }
            return null;
        }

        public void BuyFood(int spendFund)
        {
            this.DecreaseFund(spendFund);
            this.IncreaseFood(spendFund * Parameters.FundToFoodMultiple);
			ExtensionInterface.call("BuyFood", new Object[] { this.Scenario, this });
        }

        public bool BuyFoodAvail()
        {
            return ((((this.Agriculture >= Parameters.BuyFoodAgriculture) && ((base.Scenario.Date.Season == GameSeason.夏) || (base.Scenario.Date.Season == GameSeason.秋))) && (this.Fund > 0)) && (this.Food < this.FoodCeiling));
        }

        public bool CampaignAvail()
        {
            if ((this.Persons.Count > 0) && (this.Militaries.Count > 0))
            {
                foreach (Military military in this.Militaries)
                {
                    if (((military.Quantity > 0) && (military.Morale > 0)) && (this.GetMilitaryCampaignArea(military).Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ChangeCapitalAvail()
        {
            return ((((this.BelongedFaction != null) && (this.BelongedFaction.ArchitectureCount > 1)) && this.IsCapital) && (this.Fund >= this.ChangeCapitalCost));
        }

        public bool SelectPrinceAvail()
        {
            return false;

            /*if (this.BelongedFaction != null && this.BelongedFaction.PrinceID==-1&& this.Fund>50000 && this.BelongedFaction.Leader.ChildrenCanBeSelectedAsPrince().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public bool BecomeEmperorLegallyAvail()
        {

            return this.BelongedFaction.BecomeEmperorLegallyAvail();
        }

        public bool SelfBecomeEmperorAvail()
        {
            return this.BelongedFaction.SelfBecomeEmperorAvail();
        }

        public void ChangeFaction(Faction faction)
        {
            this.ResetAuto();
            if ((faction != null) && base.Scenario.IsPlayer(faction))
            {
                this.AutoHiring = true;
                this.AutoRewarding = true;

            }
            if ((faction != null) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.Architectures.Remove(this);
                this.BelongedFaction.RemoveArchitectureKnownData(this);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    this.ClearRouteways();
                }
                else
                {
                    foreach (Routeway routeway in this.Routeways)
                    {
                        this.BelongedFaction.RemoveRouteway(routeway);
                    }
                }
                foreach (Military military in this.Militaries)
                {
                    this.BelongedFaction.RemoveMilitary(military);
                }
                this.PurifyFactionInfluences();
                this.BelongedFaction = null;
                faction.AddArchitecture(this);
                faction.AddArchitectureKnownData(this);
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (captive.CaptiveFaction == faction)
                    {
                        captive.CaptivePerson.Status = PersonStatus.Normal;
                        captive.CaptivePerson.BelongedCaptive = null;
                    }
                }
                this.InformationCoolDown = 0;
                foreach (Military military in this.Militaries)
                {
                    faction.AddMilitary(military);
                }
                foreach (Routeway routeway in this.Routeways)
                {
                    faction.AddRouteway(routeway);
                }
                faction.FirstSection.AddArchitecture(this);
                this.ApplyFactionInfluences();
            }
            if (faction != null)
            {
                //this.jianzhuqizi.qizidezi.Text = faction.ToString().Substring(0, 1);
            }
        }

        private void CheckAmbushTroop(Point p)
        {
            Troop troopByPosition = base.Scenario.GetTroopByPosition(p);
            if (((troopByPosition != null) && (troopByPosition.Status == TroopStatus.埋伏)) && !this.IsFriendly(troopByPosition.BelongedFaction))
            {
                this.DetectAmbush(troopByPosition, this.BelongedFaction.GetKnownAreaData(p));
            }
        }

        private void CheckBuildingFacility()
        {
            if (this.BuildingDaysLeft > 0)
            {
                this.BuildingDaysLeft--;
                if (this.BuildingDaysLeft == 0)
                {
                    FacilityKind facilityKind = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.BuildingFacility);
                    if (facilityKind != null)
                    {
                        this.BuildFacility(facilityKind);
                    }
                    this.BuildingFacility = -1;
                }
            }
        }

        public LinkKind CheckCampaignable(LinkNode node)
        {
            bool flag = true;
            bool flag2 = true;
            for (int i = 1; i < node.Path.Count; i++)
            {
                flag = flag && node.Path[i - 1].IsLandLink(node.Path[i]);
                flag2 = flag2 && node.Path[i - 1].IsWaterLink(node.Path[i]);
            }
            if (flag && flag2)
            {
                return LinkKind.Both;
            }
            if (flag)
            {
                return LinkKind.Land;
            }
            if (flag2)
            {
                return LinkKind.Water;
            }
            return LinkKind.None;
        }

        public void CheckIsFrontLine()
        {
            if (this.BelongedFaction == null) return;
            this.FrontLine = false;
            this.HostileLine = false;
            this.CriticalHostile = false;
            this.noFactionFrontline = false;
            this.orientationFrontLine = false;
            this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.35f;
            foreach (Architecture architecture in this.GetAILinks())
            {
                if (this.IsFriendly(architecture.BelongedFaction))
                {
                    continue;
                }
                if (architecture.BelongedFaction == null)
                {
                    noFactionFrontline = true;
                    continue;
                }
                this.FrontLine = true;
                int num = (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture.BelongedFaction.ID) + architecture.BelongedFaction.ArchitectureTotalSize) - this.BelongedFaction.ArchitectureTotalSize;
                if (num < 0)
                {
                    this.HostileLine = true;
                    if (num <= -200)
                    {
                        this.CriticalHostile = true;
                    }
                }
                if (this.BelongedSection != null && this.BelongedSection.OrientationFaction == architecture.BelongedFaction)
                {
                    this.orientationFrontLine = true;
                }
            }
            this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
        }

        private void CheckRobberTroop()
        {
            if (this.BelongedFaction != null)
            {
                if ((this.RobberTroop != null) && (this.RobberTroop.RecentlyFighting <= 0))
                {
                    this.RobberTroop.Destroy(true, true);
                    base.Scenario.Militaries.Remove(this.RobberTroop.Army);
                    base.Scenario.Troops.RemoveTroop(this.RobberTroop);
                    this.RobberTroop = null;
                }
            }
            else if (this.RobberTroop == null)
            {
                if ((this.JustAttacked && (this.Endurance > 0)) && !this.HasHostileTroopsInArchitecture())
                {
                    List<Point> orientations = new List<Point>();
                    foreach (Troop troop in this.GetHostileTroopsInView())
                    {
                        orientations.Add(troop.Position);
                    }
                    this.CreateRobberTroop(base.Scenario.GetClosestPosition(this.ArchitectureArea, orientations).Value);
                }
            }
            else if (!(((this.RecentlyAttacked > 0) || (this.RobberTroop.RecentlyFighting > 0)) || this.HasHostileTroopsInView()))
            {
                this.RobberTroop.Destroy(true, true);
                base.Scenario.Militaries.Remove(this.RobberTroop.Army);
                base.Scenario.Troops.RemoveTroop(this.RobberTroop);
                this.RobberTroop = null;
            }
        }

        public void ClearField()
        {
            if (this.Kind.HasAgriculture)
            {
                this.Agriculture -= this.ClearFieldAgricultureCost;
            }
            this.DecreaseFund(this.ClearFieldFundCost);
            int num = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                if ((base.Scenario.GetArchitectureByPosition(point) != null) || base.Scenario.NoFoodDictionary.HasPosition(point))
                {
                    continue;
                }
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition == null) || this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                {
                    TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                    if ((terrainDetailByPosition != null) && (terrainDetailByPosition.FoodDeposit > 0))
                    {
                        num += terrainDetailByPosition.GetRandomFood(base.Scenario.Date.Season);
                        base.Scenario.NoFoodDictionary.AddPosition(new NoFoodPosition(point, terrainDetailByPosition.RandomRegainDays));
                    }
                }
            }
            this.IncreaseFood(num / 4);
			ExtensionInterface.call("ClearField", new Object[] { this.Scenario, this });
        }

        private void ClearFieldAI()
        {
            if ((((((this.Endurance + this.Domination) - this.Agriculture) < 0) && (this.ArmyScale < this.NormalArmyScale)) && this.ClearFieldAvail()) && ((this.ClearFieldCredit / this.LongViewArea.Count) >= 0xc350))
            {
                float rationRate = 0f;
                int relationUnderZeroTroopFightingForceInView = this.GetRelationUnderZeroTroopFightingForceInView(out rationRate);
                if ((relationUnderZeroTroopFightingForceInView > 0) && ((rationRate < 0.2f) && (relationUnderZeroTroopFightingForceInView > ((this.GetFriendlyTroopFightingForceInView() + (this.FoodCostPerDayOfAllMilitaries * ((this.PersonCount < 10) ? this.PersonCount : 10))) * 2))))
                {
                    this.ClearField();
                }
            }
        }

        public bool ClearFieldAvail()
        {
            return false;
            if (this.Kind.HasAgriculture && (this.Agriculture <= this.ClearFieldAgricultureCost))
            {
                return false;
            }
            if (this.Fund < this.ClearFieldFundCost)
            {
                return false;
            }
            return true;
        }

        public void ClearFundPacks()
        {
            this.FundPacks.Clear();
        }

        internal void ClearPopulationPacks()
        {
            this.PopulationPacks.Clear();
        }

        public void ClearRouteways()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        foreach (Routeway routeway in architecture.HasRoutewayList(this))
                        {
                            routeway.RemoveAfterClose = true;
                        }
                    }
                }
            }
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                base.Scenario.RemoveRouteway(routeway);
            }
            this.Routeways.Clear();
        }

        internal void ClearSpyPacks()
        {
            this.SpyPacks.Clear();
        }

        private void ClearWork()
        {
            if (this.Agriculture >= this.AgricultureCeiling)
            {
                foreach (Person person in this.AgricultureWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }
            if (this.Commerce >= this.CommerceCeiling)
            {
                foreach (Person person in this.CommerceWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }
            if (this.Technology >= this.TechnologyCeiling)
            {
                foreach (Person person in this.TechnologyWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }
            /*        统治到顶时不停止工作
            if (this.Domination >= this.DominationCeiling)
            {
                foreach (Person person in this.DominationWorkingPersons)
                {
                    this.RemovePersonFromWorkingList(person);
                }
            }
            */

            if (this.Morale >= this.MoraleCeiling)
            {
                foreach (Person person in this.MoraleWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }
            if (this.Endurance >= this.EnduranceCeiling)
            {
                foreach (Person person in this.EnduranceWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }
            
            foreach (Military military in this.Militaries)
            {
                if (military.Quantity >= military.Kind.MaxScale||this.Domination<50||this.Morale<100)
                {
                    military.StopRecruitment();
                    
                }
            }

            if (suoyouJunduiDouYijingXunlianHao())
            {
                foreach (Person person in this.TrainingWorkingPersons)
                {
                    person.WorkKind = ArchitectureWorkKind.无;
                }
            }

        }
        private bool suoyouJunduiDouYijingXunlianHao()
        {
            bool JunduiDouYijingXunlianHao = true;
            foreach (Military military in this.Militaries)
            {
                if (military.Morale < military.MoraleCeiling || military.Combativity < military.CombativityCeiling)
                {
                    JunduiDouYijingXunlianHao = false;
                    break;
                }
            }
            return JunduiDouYijingXunlianHao;
        }

        public void CloseAllRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                routeway.Close();
            }
        }

        public bool CommerceAvail()
        {
            return (this.Kind.HasCommerce && this.HasPerson());
        }

        public bool ConvincePersonAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.ConvincePersonFund)) && (this.GetConvincePersonArchitectureArea().Count > 0));
        }

        public Legion CreateDefensiveLegion()
        {
            this.DefensiveLegion = new Legion();
            this.DefensiveLegion.Scenario = base.Scenario;
            this.DefensiveLegion.Kind = LegionKind.Defensive;
            this.DefensiveLegion.ID = base.Scenario.Legions.GetFreeGameObjectID();
            this.DefensiveLegion.StartArchitecture = this;
            this.DefensiveLegion.WillArchitecture = this;
            base.Scenario.Legions.AddLegionWithEvent(this.DefensiveLegion);
            this.BelongedFaction.AddLegion(this.DefensiveLegion);
            return this.DefensiveLegion;
        }

        private SpyMessage CreateHireNewPersonSpyMessage(Person person)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.HireNewPerson;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = person.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        public void CreateMilitary(MilitaryKind mk)
        {
            Military military = Military.Create(base.Scenario, this, mk);
            if (this.OnMilitaryCreate != null)
            {
                this.OnMilitaryCreate(this, military);
            }
            if (this.HasSpy)
            {
                this.AddMessageToTodayNewMilitarySpyMessage(military);
            }
        }

        private SpyMessage CreateMilitaryScaleSpyMessage(Military m)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.MilitaryScale;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = m.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Message5 = (m.Scales * m.Kind.MinScale).ToString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewFacilitySpyMessage(FacilityKind fk)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewFacility;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = fk.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewMilitarySpyMessage(Military m)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewMilitary;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = m.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewTroopSpyMessage(Troop t, bool hand)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewTroop;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = t.DisplayName;
            message.Message4 = base.Scenario.Date.ToDateString();
            if (hand)
            {
                message.Message5 = "不明";
            }
            else
            {
                message.Message5 = (t.WillArchitecture != null) ? t.WillArchitecture.Name : "不明";
            }
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        public Legion CreateOffensiveLegion(Architecture willArchitecture)
        {
            Legion legion = new Legion();
            legion.Scenario = base.Scenario;
            legion.Kind = LegionKind.Offensive;
            legion.StartArchitecture = this;
            legion.WillArchitecture = willArchitecture;
            legion.ID = base.Scenario.Legions.GetFreeGameObjectID();
            base.Scenario.Legions.AddLegionWithEvent(legion);
            this.BelongedFaction.AddLegion(legion);
            LinkNode node = null;
            if (this.AIAllLinkNodes.TryGetValue(willArchitecture.ID, out node))
            {
                legion.PreferredRouteway = this.GetRouteway(node, false);
            }
            return legion;
        }

        public void CreateRobberTroop(Point position)
        {
            Military military = new Military();
            military.Scenario = base.Scenario;
            military.ID = base.Scenario.Militaries.GetFreeGameObjectID();
            base.Scenario.Militaries.AddMilitary(military);
            military.Kind = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x15);
            military.Name = military.Kind.Name;
            military.Morale = military.MoraleCeiling;
            military.Combativity = military.CombativityCeiling;
            military.Quantity = (military.Kind.MinScale + (this.Population / 100)) * ((this.AreaCount / 2) + 2);
            if (military.Quantity > military.Kind.MaxScale)
            {
                military.Quantity = military.Kind.MaxScale;
            }
            GameObjectList persons = new GameObjectList();
            Person gameObject = base.Scenario.Persons.GetGameObject(0x1bc4) as Person;
            persons.Add(gameObject);
            Troop troop = this.CreateTroop(persons, gameObject, military, 0, position);
            troop.WillArchitecture = this;
            this.RobberTroop = troop;
			ExtensionInterface.call("CreateRobberTroop", new Object[] { this.Scenario, this, troop });
        }

        public Routeway CreateRouteway(Point p)
        {
            if (base.Scenario.GetTerrainDetailByPosition(p) != null)
            {
                Routeway routeway = new Routeway();
                routeway.Scenario = base.Scenario;
                routeway.ID = base.Scenario.Routeways.GetFreeGameObjectID();
                routeway.Scenario.Routeways.AddRoutewayWithEvent(routeway);
                this.BelongedFaction.AddRouteway(routeway);
                routeway.StartArchitecture = this;
                this.Routeways.Add(routeway);
                routeway.Extend(p);
                ArchitectureList routewayArchitecturesByPosition = base.Scenario.GetRoutewayArchitecturesByPosition(routeway, p);
                if (routewayArchitecturesByPosition.Count > 0)
                {
                    if (routewayArchitecturesByPosition.Count > 1)
                    {
                        routewayArchitecturesByPosition.PropertyName = "Food";
                        routewayArchitecturesByPosition.IsNumber = true;
                        routewayArchitecturesByPosition.SmallToBig = true;
                        routewayArchitecturesByPosition.ReSort();
                    }
                    routeway.EndArchitecture = routewayArchitecturesByPosition[0] as Architecture;
                    routeway.DestinationArchitecture = routeway.EndArchitecture;
                }
				ExtensionInterface.call("CreateRouteway", new Object[] { this.Scenario, this, routeway });
                return routeway;
            }
            return null;
        }

        public Routeway CreateRouteway(List<Point> pointlist)
        {
            int num2;
            Routeway routeway = new Routeway();
            routeway.Scenario = base.Scenario;
            routeway.ID = base.Scenario.Routeways.GetFreeGameObjectID();
            routeway.Scenario.Routeways.AddRoutewayWithEvent(routeway);
            this.BelongedFaction.AddRouteway(routeway);
            routeway.StartArchitecture = this;
            this.Routeways.Add(routeway);
            GameArea routewayStartPoints = this.GetRoutewayStartPoints();
            int num = 0;
            for (num2 = 0; num2 < pointlist.Count; num2++)
            {
                if (routewayStartPoints.HasPoint(pointlist[num2]))
                {
                    num = num2;
                }
            }
            for (num2 = num; num2 < pointlist.Count; num2++)
            {
                routeway.Extend(pointlist[num2]);
            }
			ExtensionInterface.call("CreateRouteway", new Object[] { this.Scenario, this, routeway });
            return routeway;
        }

        public Troop CreateTroop(GameObjectList persons, Person leader, Military military, int food, Point position)
        {
            return Troop.Create(this, persons, leader, military, food, position);
        }

        public bool CurrentPlayerOwned()
        {
            return ((GlobalVariables.SkyEye && this.HasFaction()) || (this.HasFaction() && (base.Scenario.NoCurrentPlayer || (this.BelongedFaction == base.Scenario.CurrentPlayer))));
        }

        public void DamageByGossip(int damage)
        {
            foreach (Person person in this.Persons)
            {
                if (/*(person.Loyalty <= 100) && */ (person != this.BelongedFaction.Leader))
                {
                    person.DecreaseLoyalty(StaticMethods.GetRandomValue((int)(damage * (int)(Enum.GetNames(typeof(PersonLoyalty)).Length - person.PersonalLoyalty) * (Math.Min(person.Loyalty, 100) / 100.0)), 100));
                }
            }
			ExtensionInterface.call("GossipDamage", new Object[] { this.Scenario, this, damage });
        }

        public void checkEvent()
        {
            foreach (Event e in base.Scenario.AllEvents.GetRandomList())
            {
                if (e.checkConditions(this))
                {
                    if (!base.Scenario.EventsToApply.ContainsKey(e))
                    {
                        base.Scenario.EventsToApply.Add(e, this);
                        e.ApplyEventDialogs(this);
                    }
                }
            }
        }

        public void DayEvent()
        {
            this.InformationDayEvent();
            this.FundPacksDayEvent();
            this.PopulationPacksDayEvent();
            this.SpyPacksDayEvent();
            this.characteristicsDoWork();
            this.HandleFacilities();
            this.ViewAreaEvent();
            this.StrategicCenterEffect();
            this.AutoDecrement();
            this.AutoIncrement();
            this.Sourrounded();
            this.ResetDayInfluence();
            this.CheckRobberTroop();
            this.PopulationEscapeEvent();
            this.FoodReduce();
            this.zainanshijian();
            this.captiveEscape();
            this.checkEvent();
            this.JustAttacked = false;
            ExpectedFoodCache = -1;
            ExpectedFundCache = -1;
            this.remindedAboutAttack = false;
        }

        private void captiveEscape()
        {
            foreach (Captive p in this.Captives.GetRandomList())
            {
                if (GameObject.Random((this.Domination * 10 + this.Morale) * 20) + 200 <= GameObject.Random(p.CaptivePerson.CaptiveAbility))
                {
                    if (!GameObject.Chance(noEscapeChance) || GameObject.Chance(p.CaptivePerson.captiveEscapeChance)){
                        p.CaptiveEscape();
                        break;
                    }
                }
            }
        }

        public void tingzhizhenzai()
        {
            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                person.WorkKind = ArchitectureWorkKind.无;
            }
        }

        private void zainanshijian()
        {

            if (this.youzainan)
            {
                this.DecreaseFood(this.zhenzaiWorkingPersons.Count * 3000);
                this.DecreaseFund(this.zhenzaiWorkingPersons.Count * 200);
                this.zhixingzainanshanghai();

                this.zainan.shengyutianshu--;
                this.zainan.shengyutianshu -= this.zhenzaijianshaotianshu();

                if (this.zainan.shengyutianshu <= 0)
                {
                    this.youzainan = false;
                    this.tingzhizhenzai();
                }

                if (this.Food <= 0 || this.Fund <= 0)
                {
                    this.tingzhizhenzai();
                }
            }
            else
            {
                if (GameObject.Random(GlobalVariables.zainanfashengjilv) == 0  && this.Kind.ID == 1)
                {
                    int kindID;
                    kindID = GameObject.Random(base.Scenario.GameCommonData.suoyouzainanzhonglei.Count);

                    bool doDisaster = true;
                    if (disasterChanceDecrease.ContainsKey(kindID))
                    {
                        if (GameObject.Chance(disasterChanceDecrease[kindID]))
                        {
                            doDisaster = false;
                        }
                    }
                    if (disasterChanceIncrease.ContainsKey(kindID))
                    {
                        if (GameObject.Chance(disasterChanceIncrease[kindID]))
                        {
                            doDisaster = true;
                        }
                    }

                    if (doDisaster)
                    {
                        this.zainan.zainanzhonglei = base.Scenario.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei(kindID);
                        this.zainan.shengyutianshu = this.zainan.zainanzhonglei.shijianxiaxian + GameObject.Random(this.zainan.zainanzhonglei.shijianshangxian - this.zainan.zainanzhonglei.shijianxiaxian);
                        this.youzainan = true;
						ExtensionInterface.call("DisasterHappened", new Object[] { this.Scenario, this, this.zainan });
                        foreach (Military military in this.Militaries)//发生灾难时不能补充
                        {
                            military.StopRecruitment();
                        }
                        this.Onfashengzainan(this, this.zainan.zainanzhonglei.ID);
                    }
                }
            }
        }

        private int zhenzaijianshaotianshu()
        {
            int tianshu;
            int zhenzainenglizonghe = 0;
            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                zhenzainenglizonghe += person.zhenzaiAbility;
            }
            float extraProb = (zhenzainenglizonghe % 3000) / 30.0f;
            tianshu = zhenzainenglizonghe / 3000;
            return tianshu + (GameObject.Chance((int) extraProb) ? 1 : 0);
        }

        private float jianzaixishu()
        {
            float xishu;
            int zhenzainenglizonghe=0;
            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                zhenzainenglizonghe += person.zhenzaiAbility;
            }
            xishu = 500.0f / zhenzainenglizonghe;
            if (xishu < 0.01f)
            {
                xishu = 0.01f;
            }
            if (xishu > 1f)
            {
                xishu = 1f;
            }
            return xishu;
        }

        private void zhixingzainanshanghai()
        {
            float rate = 1;
            if (disasterDamageRateDecrease.ContainsKey(this.zainan.ID))
            {
                rate = 1 - disasterDamageRateDecrease[this.zainan.ID];
                if (rate < 0) rate = 0;
            }
            this.DecreasePopulation((int) (this.zainan.zainanzhonglei.renkoushanghai *jianzaixishu() * rate));
            this.DecreaseDomination((int) (this.zainan.zainanzhonglei.tongzhishanghai * rate));
            this.xiajiangnaijiu((int) (this.zainan.zainanzhonglei.naijiushanghai * rate));
            this.DecreaseAgriculture((int) (this.zainan.zainanzhonglei.nongyeshanghai * rate));
            this.DecreaseCommerce((int) (this.zainan.zainanzhonglei.shangyeshanghai * rate));
            this.DecreaseTechnology((int) (this.zainan.zainanzhonglei.jishushanghai * rate));
            this.DecreaseMorale((int) (this.zainan.zainanzhonglei.minxinshanghai * jianzaixishu() * rate));
        }

        public void DecreaseAgriculture(int decrement)
        {
            this.Agriculture -= decrement;
            if (this.Agriculture < 0)
            {
                this.Agriculture = 0;
            }
        }

        public void DecreaseCommerce(int decrement)
        {
            this.Commerce -= decrement;
            if (this.Commerce < 0)
            {
                this.Commerce = 0;
            }
        }

        public int DecreaseDomination(int decrement)
        {
            int domination = decrement;
            if ((this.Domination - decrement) < 0)
            {
                domination = this.Domination;
            }
            this.Domination -= domination;
            return domination;
        }

        public void xiajiangnaijiu(int decrement)  //灾难下降耐久
        {
            this.Endurance -= decrement;
            if (this.Endurance < 0)
            {
                this.Endurance = 0;
            }
        }

        public int DecreaseEndurance(int decrement)
        {
            if (this.Endurance <= 0)
            {
                return 0;
            }
            if (this.IsCapital)
            {
                decrement = (decrement * 2) / 3;
            }
            decrement = (int) (decrement * (1 - enduranceDecreaseRateDrop));
            if (decrement <= 0)
            {
                decrement = 1;
            }
            int endurance = decrement;
            if ((this.Endurance - decrement) < 0)
            {
                endurance = this.Endurance;
            }
            this.Endurance -= endurance;
            this.SetRecentlyAttacked();
            this.DecreaseFacilityEndurance(endurance);
            if (this.Endurance == 0)
            {
                this.RecentlyBreaked = 30;
                this.WallStateChange();
            }
            return endurance;
        }

        public void DecreaseFacilityEndurance(int decrement)
        {
            if (decrement > 0)
            {
                this.Facilities.DecreaseEndurance((int) (decrement * this.RateOfFacilityEnduranceDown));
                foreach (Facility facility in this.Facilities.GetList())
                {
                    if (facility.Endurance <= 0)
                    {
                        this.DemolishFacility(facility);
                    }
                }
            }
        }

        public void DecreaseFood(int decrement)
        {
            this.food -= decrement;
            if (this.food < 0)
            {
                this.food = 0;
            }
        }

        public void DecreaseFund(int decrement)
        {
            this.fund -= decrement;
            if (this.fund < 0)
            {
                this.fund = 0;
            }
        }

        public void DecreaseMorale(int decrement)
        {
            this.Morale -= decrement;
            if (this.Morale < 0)
            {
                this.Morale = 0;
            }
        }

        public int DecreasePopulation(int decrement)
        {
            if (this.population < decrement)
            {
                decrement = this.population;
            }
            this.population -= decrement;
            return decrement;
        }

        public int DecreaseMilitaryPopulation(int decrement)
        {
            if (this.MilitaryPopulation  < decrement)
            {
                decrement = this.MilitaryPopulation ;
            }
            this.MilitaryPopulation -= decrement;
            return decrement;
        }


        public void DecreaseTechnology(int decrement)
        {
            this.Technology -= decrement;
            if (this.Technology < 0)
            {
                this.Technology = 0;
            }
        }

        private PersonList AISelectPersonIntoTroop_inner(Person leader, PersonList otherPersons, bool markSelected)
        {
            PersonList persons = new PersonList();
            persons.Add(leader);
            if (markSelected)
            {
                leader.Selected = true;
            }
            return persons;
        }

        private TroopList AISelectPersonIntoTroop(Architecture from, Military military)
        {
            TroopList result = new TroopList();
            if ((military.FollowedLeader != null) && from.Persons.HasGameObject(military.FollowedLeader) && military.FollowedLeader.LocationTroop == null)
            {
                result.Add(Troop.CreateSimulateTroop(this.AISelectPersonIntoTroop_inner(military.FollowedLeader, from.Persons, true), military, from.Position));
            }
            else if ((((military.Leader != null) && (military.LeaderExperience >= 10)) && (((military.Leader.Strength >= 80) || (military.Leader.Command >= 80)) || military.Leader.HasLeaderValidCombatTitle)) 
                && from.Persons.HasGameObject(military.Leader) && military.Leader.LocationTroop == null)
            {
                result.Add(Troop.CreateSimulateTroop(this.AISelectPersonIntoTroop_inner(military.Leader, from.Persons, true), military, from.Position));
            }
            else
            {
                foreach (Person person in from.Persons)
                {
                    if (!person.Selected)
                    {
                        result.Add(Troop.CreateSimulateTroop(this.AISelectPersonIntoTroop_inner(person, from.Persons, false), military, from.Position));
                    }
                }
            }
            return result;
        }

        private void DefensiveCampaign()
        {
            List<Point> orientations = new List<Point>();
            TroopList hostileTroopsInView = this.GetHostileTroopsInView();
            foreach (Troop troop in hostileTroopsInView)
            {
                orientations.Add(troop.Position);
            }

            if ((this.HasPerson() && this.HasCampaignableMilitary()) && (this.GetAllAvailableArea(false).Count != 0))
            {
                if (hostileTroopsInView.Count > 0)
                {
                    TroopList friendlyTroopsInView = this.GetFriendlyTroopsInView();
                    int troopSent = 0;
                    int militaryCount = this.MilitaryCount;
                    while ((troopSent < militaryCount) && (this.TotalFriendlyForce < (this.TotalHostileForce * 5)) && this.MilitaryCount > 0 && this.PersonCount > 0)
                    {
                        Troop troop2;
                        TroopList list4 = new TroopList();
                        bool isBesideWater = this.IsBesideWater;
                        foreach (Military military in this.Militaries.GetRandomList())
                        {
                            if (military.IsFewScaleNeedRetreat && this.Endurance >= 30) continue;
                            if ((isBesideWater || (military.Kind.Type != MilitaryType.水军)) && (((((this.Endurance < 30) || military.Kind.AirOffence) || (military.Scales >= 2)) && (military.Morale > 0x2d)) && ((this.Endurance < 30) || (military.InjuryQuantity < military.Kind.MinScale))))
                            {
                                TroopList candidates = this.AISelectPersonIntoTroop(this, military);
                                foreach (Troop t in candidates)
                                {
                                    list4.Add(t);
                                }
                            }
                        }
                        if (list4.Count > 0)
                        {
                            list4.IsNumber = true;
                            list4.PropertyName = "FightingForce";
                            list4.ReSort();
                            bool stopSendingTroop = false;
                            bool hasEvetSentTroop = false;
                            foreach (Troop troop in list4.GetList())
                            {
                                bool personAlreadyOut = false;
                                foreach (Person p in troop.Candidates)
                                {
                                    if (p.LocationTroop != null)
                                    {
                                        personAlreadyOut = true;
                                        break;
                                    }
                                }
                                bool militaryOut = true;
                                foreach (Military m in this.Militaries){
                                    if (troop.Army == m)
                                    {
                                        militaryOut = false;
                                        break;
                                    }
                                }
                                if (personAlreadyOut) continue;
                                if (militaryOut) continue;
                                if (((troop.FightingForce < 10000) && (troop.FightingForce < (((this.TotalHostileForce * 5) - this.TotalFriendlyForce) / 25))) && (troop.Army.Scales < 10))
                                {
                                    stopSendingTroop = true;
                                    break;
                                }

                                Point? nullable = this.GetCampaignPosition(troop, orientations, troop.Army.Scales > 0);
                                if (!nullable.HasValue)
                                {
                                    continue;
                                }
                                if (troop.Army.Kind.AirOffence && (troop.Army.Scales < 2))
                                {
                                    Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(nullable.Value);
                                    if ((architectureByPositionNoCheck == null) || (architectureByPositionNoCheck.Endurance == 0))
                                    {
                                        continue;
                                    }
                                }

                                hasEvetSentTroop = true;

                                Person leader = troop.Candidates[0] as Person;
                                PersonList candidates = this.SelectSubOfficersToTroop(troop);
                                troop2 = this.CreateTroop(candidates, leader, troop.Army, -1, nullable.Value);
                                troop2.WillArchitecture = this;
                                if (this.DefensiveLegion == null)
                                {
                                    this.CreateDefensiveLegion();
                                }
                                this.DefensiveLegion.AddTroop(troop2);
                                this.PostCreateTroop(troop2, false);
                                this.TotalFriendlyForce += troop2.FightingForce;
                                troopSent++;
                            }
                            if (stopSendingTroop) break;
                            if (!hasEvetSentTroop) break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            
            //not enough defensive troop, call for reinforcements!!
            if (this.TotalFriendlyForce < this.TotalHostileForce)
            {
                foreach (LinkNode i in this.AIAllLinkNodes.Values)
                {
                    if (i.Level > 1) break;
                    if (this.BelongedFaction == i.A.BelongedFaction && i.A.HasPerson() 
                        && i.A.BelongedSection.AIDetail.AutoRun)
                    {
                        int reserve;
                        if (this.Population > 0)
                        {
                            reserve = (int)(i.A.getArmyReserveForOffensive(null) * Math.Pow(i.A.Population / (double)this.Population, 0.15));
                        }
                        else
                        {
                            reserve = int.MaxValue;
                        }
                        while (i.A.ArmyScale > reserve)
                        {
                            bool troopAdded = false;
                            TroopList supportList = new TroopList();
                            Troop troop2;
                            foreach (Military military in i.A.Militaries.GetRandomList())
                            {
                                if (military.IsFewScaleNeedRetreat) continue;
                                if (military.KindID == 29) continue;
                                if (this.isArmyNavigableTo(i, military) && (military.Morale > 90) && (military.InjuryQuantity < military.Kind.MinScale))
                                {
                                    TroopList candidates = this.AISelectPersonIntoTroop(this, military);
                                    foreach (Troop t in candidates)
                                    {
                                        supportList.Add(t);
                                    }
                                }
                            }
                            if (supportList.Count <= 0)
                            {
                                break;
                            }
                            supportList.IsNumber = true;
                            supportList.PropertyName = "FightingForce";
                            supportList.ReSort();
                            foreach (Troop troop in supportList.GetList())
                            {
                                if ((troop.FightingForce < 10000) && (troop.Army.Scales < 10))
                                {
                                    continue;
                                }
                                Point? nullable = i.A.GetCampaignPosition(troop, orientations, troop.Army.Scales > 0);
                                if (!nullable.HasValue)
                                {
                                    continue;
                                }
                                Person leader = troop.Candidates[0] as Person;
                                PersonList candidates = i.A.SelectSubOfficersToTroop(troop);
                                troop2 = i.A.CreateTroop(candidates, leader, troop.Army, -1, nullable.Value);
                                troop2.WillArchitecture = this;
                                if (this.DefensiveLegion == null)
                                {
                                    this.CreateDefensiveLegion();
                                }
                                this.DefensiveLegion.AddTroop(troop2);
                                i.A.PostCreateTroop(troop2, false);
                                this.TotalFriendlyForce += troop2.FightingForce;
                                troopAdded = true;
                                break;
                            }
                            if (this.TotalFriendlyForce > this.TotalHostileForce) break;
                            //no troop could be added, give up.
                            if (!troopAdded) break;
                        }
                        if (this.TotalFriendlyForce > this.TotalHostileForce) break;
                    }
                }
            }
        }

        private bool isArmyNavigableTo(LinkKind kind, Military military)
        {
            return GlobalVariables.LandArmyCanGoDownWater ||
                ((kind == LinkKind.Land && military.Kind.Type != MilitaryType.水军) || (kind == LinkKind.Water && military.Kind.Type == MilitaryType.水军) || kind == LinkKind.Both);
        }

        private bool isArmyNavigableTo(LinkNode targetNode, Military military)
        {
            return GlobalVariables.LandArmyCanGoDownWater ||
                ((targetNode.Kind == LinkKind.Land && military.Kind.Type != MilitaryType.水军) || (targetNode.Kind == LinkKind.Water && military.Kind.Type == MilitaryType.水军) || targetNode.Kind == LinkKind.Both);
        }

        public void DemolishAllRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                base.Scenario.RemoveRouteway(routeway);
            }
        }

        public void DemolishFacility(Facility facility)
        {
            if (this.FacilityEnabled)
            {
                facility.Influences.PurifyInfluence(this, Applier.Facility, facility.ID);
            }
            this.Facilities.Remove(facility);
            base.Scenario.Facilities.Remove(facility);
			ExtensionInterface.call("FacilityDemolished", new Object[] { this.Scenario, this, facility });
        }

        public bool DestroyAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.DestroyArchitectureFund)) && (this.GetDestroyArchitectureArea().Count > 0));
        }

        public bool DetailAvail()
        {
            return (GlobalVariables.SkyEye || this.CurrentPlayerOwned());
        }

        private void DetectAmbush(Troop troop, InformationLevel level)
        {
            int chance = 40 - troop.Leader.Calmness;
            if (level <= InformationLevel.中)
            {
                if (troop.OnlyBeDetectedByHighLevelInformation)
                {
                    return;
                }
            }
            else
            {
                chance *= 3;
            }
            if (GameObject.Chance(chance))
            {
                troop.AmbushDetected(troop);
            }
        }

        private void DetectAmbushTroop()
        {
            if (this.BelongedFaction != null)
            {
                GameArea longViewArea = this.LongViewArea;
                foreach (Point point in longViewArea.Area)
                {
                    this.CheckAmbushTroop(point);
                }
            }
        }

        private void DevelopAgriculture()
        {
            if (this.Agriculture != this.AgricultureCeiling)
            {
                foreach (Person person in this.AgricultureWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.AgricultureAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.AddGlamourExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfAgricultureReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfAgricultureTechniquePoint) * 100);
                        this.IncreaseAgriculture(randomValue);
                    }
                }
            }
        }

        private void DevelopArmy()
        {
            foreach (Military military in this.Militaries)
            {
                military.Recovery(this.MultipleOfRecovery);
                
                this.RecruitmentMilitary(military);
            }
            this.TrainMilitary();
        }

        private void DevelopCommerce()
        {
            if (this.Commerce != this.CommerceCeiling)
            {
                foreach (Person person in this.CommerceWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.CommerceAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddIntelligenceExperience(randomValue);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.AddGlamourExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfCommerceReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfCommerceTechniquePoint) * 100);
                        this.IncreaseCommerce(randomValue);
                    }
                }
            }
        }

        public void DevelopDay()
        {
            if (this.kind.HasAgriculture)
            {
                this.DevelopAgriculture();
            }
            if (this.kind.HasCommerce)
            {
                this.DevelopCommerce();
            }
            if (this.kind.HasTechnology)
            {
                this.DevelopTechnology();
            }
            if (this.kind.HasDomination)
            {
                this.DevelopDomination();
            }
            if (this.kind.HasMorale)
            {
                this.DevelopMorale();
            }
            if (this.kind.HasEndurance)
            {
                this.DevelopEndurance();
            }
            if (this.kind.HasPopulation)
            {
                this.DevelopPopulation();
            }
            this.DevelopArmy();
            this.ClearWork();
        }

        public void DevelopDayNoFaction()
        {
            this.DevelopPopulation();
        }

        private void DevelopDomination()
        {
            if (this.Domination != this.DominationCeiling)
            {
                foreach (Person person in this.DominationWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.DominationAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddStrengthExperience(randomValue * 2);
                        person.AddCommandExperience(randomValue);
                        person.AddGlamourExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfDominationReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfDominationTechniquePoint) * 100);
                        this.IncreaseDomination(randomValue);
                    }
                }
            }
        }

        private void DevelopEndurance()
        {
            if ((this.Endurance != this.EnduranceCeiling) && ((this.Endurance != 0) || !this.HasContactHostileTroop(this.BelongedFaction)))
            {
                foreach (Person person in this.EnduranceWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.EnduranceAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddStrengthExperience(randomValue);
                        person.AddCommandExperience(randomValue);
                        person.AddIntelligenceExperience(randomValue);
                        person.AddPoliticsExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfEnduranceReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfEnduranceTechniquePoint) * 100);
                        this.IncreaseEndurance(randomValue);
                    }
                }
            }
        }

        public void DevelopFood()
        {
            this.IncreaseFood(this.ExpectedFood);
        }

        public void DevelopFund()
        {
            this.IncreaseFund(this.ExpectedFund);
        }

        public void DevelopMilitaryPopulation()
        {
            if (this.ExpectedMilitaryPopulation > 0)
            {
                this.IncreaseMilitaryPopulation(this.ExpectedMilitaryPopulation);
            }
        }

        private void DevelopMonth()
        {
            if (this.BelongedFaction != null)
            {
                if (this.Kind.HasAgriculture)
                {
                    this.DevelopFood();
                }
                if (this.Kind.HasCommerce)
                {
                    this.DevelopFund();
                }

            }
         
        }

        private void DevelopMorale()
        {
            if (this.Morale != this.MoraleCeiling)
            {
                foreach (Person person in this.MoraleWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.MoraleAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddCommandExperience(randomValue);
                        person.AddPoliticsExperience(randomValue);
                        person.AddGlamourExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfMoraleReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfMoraleTechniquePoint) * 100);
                        this.IncreaseMorale(randomValue);
                    }
                }
            }
        }

        private void DevelopPopulation()
        {
            double populationDevelopingRate = this.PopulationDevelopingRate;
            if (populationDevelopingRate != 0.0)
            {
                //this.IncreasePopulation(StaticMethods.GetRandomValue(this.population + (0x3e8 * this.AreaCount), (int) (1.0 / populationDevelopingRate)));
                this.IncreasePopulation(StaticMethods.GetBigRandomValue(this.PopulationCeiling + (1000 * this.AreaCount), (int)(1.0 / populationDevelopingRate)));

            }
        }

        public void DevelopSeason()
        {
            if (this.BelongedFaction != null)
            {

                if (this.Kind.HasPopulation && this.Kind.HasMorale)
                {
                    this.DevelopMilitaryPopulation();
                }
            }
        }

        private void DevelopTechnology()
        {
            if (this.Technology != this.TechnologyCeiling)
            {
                foreach (Person person in this.TechnologyWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.TechnologyAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddIntelligenceExperience(randomValue * 2);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfTechnologyReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfTechnologyTechniquePoint) * 100);
                        this.IncreaseTechnology(randomValue);
                    }
                }
            }
        }

        public void DevelopYear()
        {
        }

        private void DiplomaticRelationAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BelongedFaction != null))
            {
            }
        }

        public bool DisbandAvail()
        {
            return ((this.Militaries.Count > 0) && this.Kind.HasPopulation);
        }

        public void DisbandMilitary(Military m)
        {
            if (m.KindID != 29)
            {
                this.IncreasePopulation(m.Quantity);
            }
            this.RemoveMilitary(m);
            this.BelongedFaction.RemoveMilitary(m);
            base.Scenario.Militaries.Remove(m);
			ExtensionInterface.call("DisbandMilitary", new Object[] { this.Scenario, this, m });
        }

        public bool DisbandSectionAvail()
        {
            return (this.BelongedFaction.SectionCount > 1);
        }

        public bool DominationAvail()
        {
            return (this.Kind.HasDomination && this.HasPerson());
        }

        public string DominationInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 20);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 10);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 5);

                case InformationLevel.全:
                    return this.Domination.ToString();
            }
            return "----";
        }

        public bool EnduranceAvail()
        {
            return (this.Kind.HasEndurance && this.HasPerson());
        }

        public string EnduranceInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 500);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 200);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 100);

                case InformationLevel.全:
                    return this.Endurance.ToString();
            }
            return "----";
        }

        public bool FacilityBuildable(FacilityKind facilityKind)
        {
            if (this.BuildingFacility >= 0)
            {
                return false;
            }
            if (!(!facilityKind.PopulationRelated || this.Kind.HasPopulation))
            {
                return false;
            }
            if (((facilityKind.PointCost > this.BelongedFaction.TotalTechniquePoint) || (facilityKind.TechnologyNeeded > this.Technology)) || (facilityKind.FundCost > this.Fund))
            {
                return false;
            }
            if (facilityKind.UniqueInArchitecture && this.ArchitectureHasFacilityKind(facilityKind.ID))
            {
                return false;
            }
            if (this.FacilityPositionLeft < facilityKind.PositionOccupied)
            {
                return false;
            }
            if (facilityKind.UniqueInFaction && this.FactionHasFacilityKind(facilityKind.ID))
            {
                return false;
            }
            foreach (Conditions.Condition i in facilityKind.GetConditionList())
            {
                if (!i.CheckCondition(this))
                {
                    return false;
                }
            }
            return true;
        }

        private void FacilityDoWork()
        {
            foreach (Facility facility in this.Facilities)
            {
                if (this.FacilityEnabled || facility.MaintenanceCost <= 0)
                {
                    facility.DoWork(this);
                }
            }
        }

        private bool FacilityIsPossibleOverTechnology(int tech)
        {
            foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
            {
                if ((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((tech < kind.TechnologyNeeded) && (this.Technology >= kind.TechnologyNeeded))) && ((this.FacilityPositionCount >= kind.PositionOccupied) && (!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID)))) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID)))
                {
                    return true;
                }
            }
            return false;
        }

        private void FacilityMaintenance()
        {
            int facilityMaintenanceCost = noFundToSustainFacility ? 0 : this.FacilityMaintenanceCost;
            if (this.Fund >= facilityMaintenanceCost)
            {
                if (!this.FacilityEnabled)
                {
                    this.ApplyFacilityInfluences(true);
                }
                this.FacilityEnabled = true;
                this.DecreaseFund(facilityMaintenanceCost);
            }
            else
            {
                if (this.FacilityEnabled)
                {
                    this.PurifyFacilityInfluences();
                }
                this.FacilityEnabled = false;
            }
        }

        private void FacilityRecovery()
        {
            if (this.FacilityEnabled)
            {
                this.Facilities.RecoverEndurance(this.facilityEnduranceIncrease);
            }
        }

        public bool FactionHasCaptive()
        {
            return ((this.BelongedFaction != null) ? this.BelongedFaction.HasCaptive() : false);
        }

        public bool FactionHasFacilityKind(int id)
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture.ArchitectureHasFacilityKind(id) || architecture.BuildingFacility == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool FactionHasSelfCaptive()
        {
            return ((this.BelongedFaction != null) ? this.BelongedFaction.HasSelfCaptive() : false);
        }

        public bool FactionHasTreasure()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.BelongedFaction.Persons)
                {
                    if (person.TreasureCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool FindRouteway(LinkNode node, bool hasEnd, out float rate)
        {
            rate = 1f;
            Point key = new Point(base.ID, node.A.ID);
            if (!this.BelongedFaction.ClosedRouteways.ContainsKey(key))
            {
                Point? nullable;
                Point? nullable2;
                base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), node.A.GetAIRoutewayEndPoints(this, true), out nullable, out nullable2);
                if (nullable.HasValue && nullable2.HasValue)
                {
                    this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = node.Kind == LinkKind.Land;
                    if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, hasEnd))
                    {
                        rate = this.BelongedFaction.RoutewayPathBuilder.PathConsumptionRate;
                        return true;
                    }
                }
            }
            return false;
        }

        public void FoodReduce()
        {
            this.DecreaseFood((int) (this.Food * this.FoodReduceDayRate));
        }

        public void FundPacksDayEvent()
        {
            for (int i = this.FundPacks.Count - 1; i >= 0; i--)
            {
                FundPack local1 = this.FundPacks[i];
                local1.Days--;
                if (this.FundPacks[i].Days <= 0)
                {
                    this.IncreaseFund(this.FundPacks[i].Fund);
                    this.FundPacks.RemoveAt(i);
                }
            }
        }

        public void GenerateAllAILinkNodes(int levelMax)
        {
            this.AILinkProcedureDetails.Clear();
            this.AIAllLinkNodes.Clear();
            List<Architecture> path = new List<Architecture>();
            this.AILinkProcedureDetails.Enqueue(new AILinkProcedureDetail(0, this, path));
            while (this.AILinkProcedureDetails.Count > 0)
            {
                AILinkProcedureDetail detail = this.AILinkProcedureDetails.Dequeue();
                this.AddAllAILink(detail.Level, levelMax, detail.A, detail.Path);
            }
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                node.Kind = this.CheckCampaignable(node);
            }
        }

        public GameObjectList GetAILinks()
        {
            GameObjectList list = this.AILandLinks.GetList();
            foreach (Architecture architecture in this.AIWaterLinks)
            {
                if (list.GetGameObject(architecture.ID) == null)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public GameObjectList GetAILinks(int level)
        {
            GameObjectList list = new GameObjectList();
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level <= level)
                {
                    list.Add(node.A);
                }
            }
            return list;
        }

        public GameArea GetAIRoutewayEndPoints(Architecture a, bool nowater)
        {
            GameArea area = new GameArea();
            if (!this.IsFriendly(a.BelongedFaction))
            {
                foreach (Point point in this.ContactArea.Area)
                {
                    if (a.IsRoutewayPossible(point) && (!nowater || (base.Scenario.GetTerrainKindByPosition(point) != TerrainKind.水域)))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.GetRoutewayStartArea().Area)
                {
                    if (a.IsRoutewayPossible(point) && (!nowater || (base.Scenario.GetTerrainKindByPosition(point) != TerrainKind.水域)))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (a.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public GameArea GetAllAvailableArea(bool Square)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                if (base.Scenario.IsPositionEmpty(point) && base.Scenario.GetTerrainDetailByPosition(point) != null && base.Scenario.GetTerrainDetailByPosition(point).RoutewayConsumptionRate < 1)
                {
                    area.AddPoint(point);
                }
            }
            foreach (Point point in this.ArchitectureArea.Area)
            {
                if (!base.Scenario.PositionIsTroop(point) && base.Scenario.GetTerrainDetailByPosition(point) != null && base.Scenario.GetTerrainDetailByPosition(point).RoutewayConsumptionRate < 1)
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        public GameArea GetAllContactArea()
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                area.AddPoint(point);
            }
            foreach (Point point in this.ArchitectureArea.Area)
            {
                area.AddPoint(point);
            }
            return area;
        }

        public PersonList GetAllPersons()
        {
            PersonList list = new PersonList();
            foreach (Person person in this.Persons)
            {
                list.Add(person);
            }
            foreach (Person person in this.MovingPersons)
            {
                list.Add(person);
            }
            return list;
        }

        public TreasureList GetAllTreasureInArchitecture()
        {
            TreasureList list = new TreasureList();
            foreach (Person person in this.GetAllPersons())
            {
                person.AddTreasureToList(list);
            }
            return list;
        }

        public TreasureList GetAllTreasureInArchitectureExceptLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person != this.BelongedFaction.Leader)
                    {
                        person.AddTreasureToList(list);
                    }
                }
            }
            return list;
        }

        public TreasureList GetAllTreasureInFaction()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.BelongedFaction.Persons)
                {
                    person.AddTreasureToList(list);
                }
            }
            return list;
        }

        public GameArea GetAvailableContactArea(bool Square)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                if (base.Scenario.IsPositionEmpty(point))
                {
                    area.AddPoint(point);
                }
            }
            if (area.Count > 0)
            {
                return area;
            }
            return null;
        }

        public MilitaryList GetBeMergedMilitaryList(Military military)
        {
            this.BeMergedMilitaryList.Clear();
            foreach (Military military2 in this.MergeMilitaryList)
            {
                if ((military2 != military) && (military2.Kind == military.Kind))
                {
                    this.BeMergedMilitaryList.Add(military2);
                }
            }
            return this.BeMergedMilitaryList;
        }

        public GameObjectList GetBuildableFacilityKindList()
        {
            this.BuildableFacilityKindList.Clear();
            foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
            {
                if (this.FacilityBuildable(kind))
                {
                    this.BuildableFacilityKindList.Add(kind);
                }
            }
            return this.BuildableFacilityKindList;
        }

        public MilitaryList GetCampaignMilitaryList()
        {
            this.CampaignMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity > 0) && (military.Morale > 0))
                {
                    this.CampaignMilitaryList.AddMilitary(military);
                }
            }
            return this.CampaignMilitaryList;
        }

        public Point? GetCampaignPosition(Troop troop, List<Point> orientations, bool close)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            GameArea sourceArea = new GameArea();
            foreach (Point point in allAvailableArea.Area)
            {
                if (((base.Scenario.GetArchitectureByPosition(point) == this) && (base.Scenario.GetTroopByPosition(point) == null)) || troop.IsMovableOnPosition(point))
                {
                    sourceArea.Area.Add(point);
                }
            }
            GameArea highestFightingForceArea = troop.GetHighestFightingForceArea(sourceArea);
            if (highestFightingForceArea != null)
            {
                if (close)
                {
                    return base.Scenario.GetClosestPosition(highestFightingForceArea, orientations);
                }
                return base.Scenario.GetFarthestPosition(highestFightingForceArea, orientations);
            }
            return null;
        }

        public ArchitectureList GetChangeCapitalArchitectureList()
        {
            this.ChangeCapitalArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.ChangeCapitalArchitectureList.Add(architecture);
                    }
                }
            }
            return this.ChangeCapitalArchitectureList;
        }

        public void GetClosestArchitectures()
        {
            this.ClosestArchitectures = new ArchitectureList();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture != this)
                {
                    this.ClosestArchitectures.Add(architecture);
                }
            }
            this.QuickSortArchitecturesDistance(this.ClosestArchitectures, 0, this.ClosestArchitectures.Count - 1);
        }

        public ArchitectureList GetClosestArchitectures(int count, double maxDistance)
        {
            if (this.ClosestArchitectures == null)
            {
                this.GetClosestArchitectures();
            }
            ArchitectureList list = new ArchitectureList();
            if (count > this.ClosestArchitectures.Count)
            {
                count = this.ClosestArchitectures.Count;
            }
            for (int i = 0; i < count; i++)
            {
                if (base.Scenario.GetDistance(this.ArchitectureArea, (this.ClosestArchitectures[i] as Architecture).ArchitectureArea) <= maxDistance)
                {
                    list.Add(this.ClosestArchitectures[i]);
                }
                else
                {
                    break;
                }
            }
            if (list.Count == 0){
                list.Add(this.ClosestArchitectures[0]);
            }
            return list;
        }

        public ArchitectureList GetClosestArchitectures(int count)
        {
            return GetClosestArchitectures(count, double.MaxValue);
        }

        public Routeway GetConnectedRouteway(Architecture end)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if ((routeway.EndArchitecture == end) && routeway.IsActive)
                {
                    return routeway;
                }
            }
            return null;
        }

        public PersonList ConvinceDestinationPersonList = new PersonList();
        public PersonList GetConvinceDestinationPersonList(Faction faction)
        {
            PersonList result = new PersonList();
            if (this.BelongedFaction == faction)
            {
                foreach (Captive captive in this.Captives)
                {
                    result.Add(captive.CaptivePerson);
                }
            }
            else
            {
                foreach (Person person in this.Persons)
                {
                    result.Add(person);
                }
            }
            ConvinceDestinationPersonList = result;
            return result;
        }

        public GameArea GetPersonTransferArchitectureArea()
        {

            GameArea area = new GameArea();
            
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {

                if (architecture == this)
                {
                    continue;
                }


                foreach (Point point in architecture.ArchitectureArea.Area)
                {
                    area.AddPoint(point);
                }


            }
            return area;
        }


        public GameArea GetConvincePersonArchitectureArea()
        {
            GameArea area = new GameArea();
        //Label_0121:
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture.BelongedFaction == null)
                {
                    continue;
                }
                if (architecture.BelongedFaction == this.BelongedFaction)
                {
                    if (!architecture.HasCaptive())
                    {
                        //goto Label_0121;
                        continue;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
                else
                {
                    if (!architecture.HasPerson() || !this.BelongedFaction.IsArchitectureKnown(architecture))
                    {
                        continue;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public GameArea GetDestroyArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (!this.IsFriendly(architecture.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public int GetDistanceFromFaction(Faction faction)
        {
            if ((faction == null) || (faction.ArchitectureCount == 0))
            {
                return 0;
            }
            if (this.BelongedFaction == faction)
            {
                return 0;
            }
            if (this.ClosestArchitectures == null)
            {
                this.GetClosestArchitectures();
            }
            int num = 0;
            for (int i = 0; i < this.ClosestArchitectures.Count; i++)
            {
                if ((this.ClosestArchitectures[i] as Architecture).BelongedFaction == faction)
                {
                    num += (i * (this.ClosestArchitectures[i] as Architecture).Population) / 0x2710;
                }
            }
            if (this.BelongedFaction != null)
            {
                int diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, faction.ID);
                if (diplomaticRelation <= -200)
                {
                    num /= 4;
                }
                else if (diplomaticRelation < 0)
                {
                    num /= 1;
                }
            }
            return (num / faction.ArchitectureCount);
        }

        public int GetDistanceFromSection(Section section)
        {
            if ((section == null) || (section.ArchitectureCount == 0))
            {
                return 0;
            }
            if (this.BelongedSection == section)
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in section.Architectures)
            {
                LinkNode node = null;
                this.AIAllLinkNodes.TryGetValue(architecture.ID, out node);
                if (node != null)
                {
                    num += (int) (node.Level * node.Distance);
                }
                else
                {
                    num += 0x3e8;
                }
                num -= architecture.Population / 0x2710;
            }
            return (num / section.ArchitectureCount);
        }

        public Routeway GetExistingRouteway(Architecture destination)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    return routeway;
                }
            }
            return null;
        }

        public Captive GetLowestLoyaltyCaptiveRecruitable()
        {
            GameObjectList list = this.Captives.GetRandomList();
            int lowestLoyalty = int.MaxValue;
            Captive target = null;
            if (list.Count > 0)
            {
                foreach (Captive c in list)
                {
                    int idealOffset = Person.GetIdealOffset(c.CaptivePerson, this.BelongedFaction.Leader);
                    if ((!GlobalVariables.IdealTendencyValid || (idealOffset <= c.CaptivePerson.IdealTendency.Offset + (double)this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                        && (!c.CaptivePerson.HatedPersons.Contains(this.BelongedFaction.LeaderID)) && (!this.BelongedFaction.IsAlien || c.CaptivePerson.PersonalLoyalty < 2))
                    {
                        if (c.CaptivePerson.Loyalty < lowestLoyalty)
                        {
                            target = c;
                            lowestLoyalty = c.CaptivePerson.Loyalty;
                        }
                    }
                }
            }
            return target;
        }

        public Captive GetExtremeLoyaltyCaptive(bool low)
        {
            GameObjectList list = this.Captives.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "Loyalty";
                    list.IsNumber = true;
                    list.SmallToBig = low;
                    list.ReSort();
                }
                return (list[0] as Captive);
            }
            return null;
        }

        public Person GetLowestLoyaltyPersonRecruitable()
        {
            GameObjectList list = this.Persons.GetRandomList();
            int lowestLoyalty = int.MaxValue;
            Person target = null;
            if (list.Count > 0)
            {
                foreach (Person c in list)
                {
                    int idealOffset = Person.GetIdealOffset(c, this.BelongedFaction.Leader);
                    if ((!GlobalVariables.IdealTendencyValid || (idealOffset <= c.IdealTendency.Offset + (double)this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                        && (!c.HatedPersons.Contains(this.BelongedFaction.LeaderID)) && (!this.BelongedFaction.IsAlien || c.PersonalLoyalty < 2))
                    {
                        if (c.Loyalty < lowestLoyalty)
                        {
                            target = c;
                            lowestLoyalty = c.Loyalty;
                        }
                    }
                }
            }
            return target;
        }

        public Person GetExtremeLoyaltyPerson(bool low)
        {
            GameObjectList list = this.Persons.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "Loyalty";
                    list.IsNumber = true;
                    list.SmallToBig = low;
                    list.ReSort();
                }
                return (list[0] as Person);
            }
            return null;
        }

        public Person GetExtremePersonFromWorkingList(ArchitectureWorkKind workKind, bool highest)  //大概是选择在冒泡小窗口说话的人
        {
            PersonList agricultureWorkingPersons = null;
            int num2;
            int num3;
            int workAbility;
            switch (workKind)
            {
                case ArchitectureWorkKind.赈灾:
                    agricultureWorkingPersons = this.zhenzaiWorkingPersons;   
                    break;
                case ArchitectureWorkKind.训练:
                    agricultureWorkingPersons = this.TrainingWorkingPersons ;
                    break;
                case ArchitectureWorkKind.农业:
                    agricultureWorkingPersons = this.AgricultureWorkingPersons;
                    break;

                case ArchitectureWorkKind.商业:
                    agricultureWorkingPersons = this.CommerceWorkingPersons;
                    break;

                case ArchitectureWorkKind.技术:
                    agricultureWorkingPersons = this.TechnologyWorkingPersons;
                    break;

                case ArchitectureWorkKind.统治:
                    agricultureWorkingPersons = this.DominationWorkingPersons;
                    break;

                case ArchitectureWorkKind.民心:
                    agricultureWorkingPersons = this.MoraleWorkingPersons;
                    break;

                case ArchitectureWorkKind.耐久:
                    agricultureWorkingPersons = this.EnduranceWorkingPersons;
                    break;

                default:
                    return null;
            }
            if (agricultureWorkingPersons.Count == 0)
            {
                return null;
            }
            if (agricultureWorkingPersons.Count == 1)
            {
                return (agricultureWorkingPersons[0] as Person);
            }
            if (highest)
            {
                int num = 0;
                num2 = 0;
                for (num3 = 0; num3 < agricultureWorkingPersons.Count; num3++)
                {
                    workAbility = (agricultureWorkingPersons[num3] as Person).GetWorkAbility(workKind);
                    if (workAbility > num)
                    {
                        num = workAbility;
                        num2 = num3;
                    }
                }
                return (agricultureWorkingPersons[num2] as Person);
            }
            int num5 = 0x7fffffff;
            num2 = 0;
            for (num3 = 0; num3 < agricultureWorkingPersons.Count; num3++)
            {
                workAbility = (agricultureWorkingPersons[num3] as Person).GetWorkAbility(workKind);
                if (workAbility < num5)
                {
                    num5 = workAbility;
                    num2 = num3;
                }
            }
            return (agricultureWorkingPersons[num2] as Person);
        }

        public InformationKind GetFirstHalfInformationKind()
        {
            InformationKindList list = new InformationKindList();
            foreach (InformationKind kind in base.Scenario.GameCommonData.AllInformationKinds.GetAvailList(this))
            {
                if ((kind.Level <= InformationLevel.中) || GameObject.Chance(20))
                {
                    list.Add(kind);
                }
            }
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "FightingWeighing";
                    list.IsNumber = true;
                    list.ReSort();
                }
                return (list[GameObject.Random(list.Count / 2)] as InformationKind);
            }
            return null;
        }

        private Person GetFirstHalfPerson(string propertyName)
        {
            GameObjectList list = this.Persons.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = propertyName;
                    list.IsNumber = true;
                    list.ReSort();
                }
                return (list[GameObject.Random(list.Count / 2)] as Person);
            }
            return null;
        }

        internal int GetFriendlyTroopFightingForceInView()
        {
            int num = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                {
                    num += troopByPosition.FightingForce;
                }
            }
            return num;
        }

        public TroopList GetFriendlyTroopsInView()
        {
            GameArea longViewArea = this.LongViewArea;
            TroopList list = new TroopList();
            foreach (Point point in longViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && troopByPosition.IsFriendly(this.BelongedFaction))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        public int GetGossipablePersonCount()
        {
            int num = 0;
            foreach (Person person in this.Persons)
            {
                if ((person.Loyalty <= 100) && (person != this.BelongedFaction.Leader))
                {
                    num++;
                }
            }
            return num;
        }

        public GameArea GetGossipArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if ((((architecture.BelongedFaction != null) && !this.IsFriendly(architecture.BelongedFaction)) && architecture.HasPerson()) && this.BelongedFaction.IsArchitectureKnown(architecture))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public TroopList GetHostileTroopsInView()
        {
            GameArea viewArea = this.ViewArea;
            if ((this.RecentlyAttacked > 0) || (this.ArmyScale > this.LargeArmyScale))
            {
                viewArea = this.LongViewArea;
            }
            TroopList list = new TroopList();
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (!troopByPosition.IsFriendly(this.BelongedFaction) && (troopByPosition.Status != TroopStatus.埋伏)))
                {
                    int days = 1;
                    if ((((this.BelongedFaction != null) && (troopByPosition.BelongedFaction != null)) && (this.RecentlyAttacked <= 0)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) >= 0))
                    {
                        days = 0;
                    }
                    if (troopByPosition.DaysToReachPosition(base.Scenario.GetClosestPoint(this.ArchitectureArea, troopByPosition.Position), days))
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }


        public bool FindHostileTroopInView()
        {


            GameArea viewArea = this.LongViewArea;

            
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && troopByPosition.Army.KindID!=29 && (!troopByPosition.IsFriendly(this.BelongedFaction) && (troopByPosition.Status != TroopStatus.埋伏)))
                {
                    return true;
                }
            }
            return false;
        }

        public GameArea GetInstigateArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture.Kind.HasDomination && !this.IsFriendly(architecture.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetLevelUpMilitaryList()
        {
            this.LevelUpMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if (((military.InjuryQuantity == 0) && military.Kind.CanLevelUp) && (military.Experience >= military.Kind.LevelUpExperience))
                {
                    this.LevelUpMilitaryList.AddMilitary(military);
                }
            }
            return this.LevelUpMilitaryList;
        }

        public MilitaryList GetMergeMilitaryList()
        {
            this.MergeMilitaryList.Clear();
            for (int i = 0; i < this.Militaries.Count; i++)
            {
                Military t = this.Militaries[i] as Military;
                if ((t.Quantity != t.Kind.MaxScale) && (t.InjuryQuantity <= 0))
                {
                    foreach (Military military2 in this.Militaries)
                    {
                        if (((t != military2) && (t.Kind == military2.Kind)) && ((military2.Quantity < military2.Kind.MaxScale) && (military2.InjuryQuantity == 0)))
                        {
                            this.MergeMilitaryList.Add(t);
                            break;
                        }
                    }
                }
            }
            return this.MergeMilitaryList;
        }

        public GameArea GetMilitaryCampaignArea(Military military)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            military.ModifyAreaByTerrainAdaptablity(allAvailableArea);
            return allAvailableArea;
        }

        public MilitaryKindList GetNewMilitaryKindList()
        {
            this.NewMilitaryKindList.Clear();
            foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.CreateAvail(this))
                {
                    this.NewMilitaryKindList.Add(kind);
                }
            }
            foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.CreateAvail(this))
                {
                    this.NewMilitaryKindList.Add(kind);
                }
            }
            return this.NewMilitaryKindList;
        }

        public ArchitectureList GetOtherArchitectureList()
        {
            this.OtherArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.OtherArchitectureList.Add(architecture);
                    }
                }
            }
            return this.OtherArchitectureList;
        }


        public ArchitectureList jingongjianzhuliebiao()
        {
            ArchitectureList jianzhuliebiao=new ArchitectureList();
            if (base.Scenario.youhuangdi())
            {
                jianzhuliebiao.Add(base.Scenario.huangdisuozaijianzhu());
            }
            return jianzhuliebiao ;
        }

        public PersonList PersonConveneList = new PersonList();
        public PersonList GetPersonConveneList()
        {
            PersonList result = new PersonList();
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture != this)
                {
                    foreach (Person person in architecture.Persons)
                    {
                        result.Add(person);
                    }
                }
            }
            PersonConveneList = result;
            return result;
        }

        public PersonList GetPersonListExceptLeader()
        {
            PersonList list = new PersonList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person != this.BelongedFaction.Leader)
                    {
                        list.Add(person);
                    }
                }
            }
            return list;
        }

        public PersonList PersonStudySkillList = new PersonList();
        public PersonList GetPersonStudySkillList()
        {
            PersonList result = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableSkill)
                {
                    result.Add(person);
                }
            }
            PersonStudySkillList = result;
            return result;
        }

        public PersonList PersonStudyStuntList = new PersonList();
        public PersonList GetPersonStudyStuntList()
        {
            PersonList result = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableStunt)
                {
                    result.Add(person);
                }
            }
            PersonStudyStuntList = result;
            return result;
        }

        public PersonList PersonStudyTitleList = new PersonList();
        public PersonList GetPersonStudyTitleList()
        {
            PersonList result = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableTitle)
                {
                    result.Add(person);
                }
            }
            PersonStudyTitleList = result;
            return result;
        }

        public GameArea GetRealTroopEnterableArea(Troop troop)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.GetTroopEnterableArea(troop).Area)
            {
                //if (!base.Scenario.PositionIsTroop(point))
                //{
                    area.AddPoint(point);
                //}
            }
            return area;
        }

        public MilitaryList GetRecruitmentMilitaryList()
        {
            this.RecruitmentMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity < military.Kind.MaxScale) && (military.InjuryQuantity == 0))
                {
                    this.RecruitmentMilitaryList.AddMilitary(military);
                }
            }
            return this.RecruitmentMilitaryList;
        }

        public CaptiveList GetRedeemCaptiveList()
        {
            this.RedeemCaptiveList.Clear();
            foreach (Captive captive in this.BelongedFaction.SelfCaptives)
            {
                if ((captive.RansomArriveDays == 0) && (captive.Ransom <= this.Fund))
                {
                    this.RedeemCaptiveList.Add(captive);
                }
            }
            return this.RedeemCaptiveList;
        }

        internal int GetRelationUnderZeroTroopFightingForceInView(out float rationRate)
        {
            int num = 0;
            rationRate = 0f;
            int num2 = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) < 0))
                {
                    rationRate += ((float) troopByPosition.RationDaysLeft) / ((float) troopByPosition.RationDays);
                    num2++;
                    num += troopByPosition.FightingForce;
                }
            }
            if (num2 > 1)
            {
                rationRate /= (float) num2;
            }
            return num;
        }

        public GameObjectList GetResetDiplomaticRelationList()
        {
            this.ResetDiplomaticRelationList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (DiplomaticRelationDisplay display in base.Scenario.DiplomaticRelations.GetDiplomaticRelationDisplayListByFactionID(this.BelongedFaction.ID))
                {
                    if (display.Relation >= 300)
                    {
                        this.ResetDiplomaticRelationList.Add(display);
                    }
                }
            }
            return this.ResetDiplomaticRelationList;
        }

        public PersonList GetRewardPersons()
        {
            this.RewardPersonList.Clear();
            foreach (Person person in this.Persons)
            {
                if ((!person.RewardFinished && (person.Loyalty < 100)) && (person != this.BelongedFaction.Leader))
                {
                    this.RewardPersonList.Add(person);
                }
            }
            return this.RewardPersonList;
        }

        public Routeway GetRouteway(LinkNode node, bool hasEnd)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if ((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A)))
                {
                    return routeway;
                }
            }
            return this.BuildRouteway(node, hasEnd);
        }

        public ArchitectureList GetRoutewayDestinationArchitectureList()
        {
            this.RoutewayDestinationArchitectures.Clear();
            this.RoutewayProcedures.Clear();
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                architecture.surplusRate = 0f;
                architecture.PathRoutewayID = -1;
            }
            this.surplusRate = 1f;
            this.RoutewayProcedures.Enqueue(new RoutewayProcedureDetail(this, 1f));
            while (this.RoutewayProcedures.Count > 0)
            {
                RoutewayProcedureDetail detail = this.RoutewayProcedures.Dequeue();
                this.AddCloseRoutewayDestinationArchitectures(detail.Start, detail.PreviousRate);
            }
            return this.RoutewayDestinationArchitectureList;
        }

        public GameArea GetRoutewayStartArea()
        {
            return this.GetAllContactArea().GetContactArea(false);
        }

        public GameArea GetRoutewayStartPoints()
        {
            GameArea area = new GameArea();
            foreach (Point point in this.GetRoutewayStartArea().Area)
            {
                if (this.IsRoutewayPossible(point))
                {
                    area.AddPoint(point);
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.ContactArea.Area)
                {
                    if (this.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (this.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetShelledMilitaryList(MilitaryType militaryType)
        {
            this.ShelledMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if (((military.Quantity > 0) && (military.Morale > 0)) && (military.Kind.Type != militaryType))
                {
                    this.ShelledMilitaryList.AddMilitary(military);
                }
            }
            return this.ShelledMilitaryList;
        }

        public GameArea GetSpyArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if ((architecture.BelongedFaction != null) && (architecture.BelongedFaction != this.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetTrainingMilitaryList()
        {
            this.TrainingMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity > 0) && ((military.Morale < military.MoraleCeiling) || (military.Combativity < military.CombativityCeiling)))
                {
                    this.TrainingMilitaryList.AddMilitary(military);
                }
            }
            return this.TrainingMilitaryList;
        }

        public ArchitectureList GetTransferArchitectureList()
        {
            this.TransferArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.TransferArchitectureList.Add(architecture);
                    }
                }
            }
            return this.TransferArchitectureList;
        }

        public TreasureList GetTreasureListOfLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.Leader.AddTreasureToList(list);
            }
            return list;
        }

        public GameArea GetTroopEnterableArea(Troop troop)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ArchitectureArea.Area)
            {
                if (base.Scenario.GetWaterPositionMapCost(troop.Army.Kind.Type, point) < 3500)
                {
                    area.AddPoint(point);
                }
            }
            foreach (Point point in this.ContactArea.Area)
            {
                if (troop.IsMovableOnPosition(point) && (base.Scenario.GetWaterPositionMapCost(troop.Army.Kind.Type, point) < 3500))
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        public bool GossipAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.GossipArchitectureFund)) && (this.GetGossipArchitectureArea().Count > 0));
        }

        private void characteristicsDoWork()
        {
            foreach (Influence i in this.Characteristics.Influences.Values)
            {
                i.DoWork(this);
            }
        }

        private void HandleFacilities()
        {
            this.CheckBuildingFacility();
            this.FacilityMaintenance();
            this.FacilityRecovery();
            this.FacilityDoWork();
        }

        public bool HasAnyPerson()
        {
            return ((this.Persons.Count > 0) || (this.MovingPersons.Count > 0));
        }

        public bool HasCampaignableMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (((military.Quantity > 0) && (military.Morale > 0)) && (military.InjuryQuantity < military.Kind.MinScale))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasCaptive()
        {
            return (this.CaptiveCount > 0);
        }

        private bool HasCloserOffensiveArchitecture(LinkNode node, out Architecture closer)
        {
            closer = null;
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture != this)
                {
                    LinkNode node2 = null;
                    architecture.AIAllLinkNodes.TryGetValue(node.A.ID, out node2);
                    if (((node2 != null) && (node2.Level < node.Level)) && (node2.Kind != LinkKind.None))
                    {
                        closer = architecture;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasContactHostileTroop(Faction faction)
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !troopByPosition.IsFriendly(faction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEnoughForceOffensiveMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military) && (military.Scales >= 30))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasExperiencedLeaderMilitary(Person person)
        {
            foreach (Military military in this.Militaries)
            {
                if ((military.Leader == person) && (military.LeaderExperience >= 200))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasPrincess()
        {
            return (this.feiziliebiao.Count > 0);
        }

        public bool HasFacility()
        {
            return (this.FacilityCount > 0);
        }
        public bool HaskechaichuFacility()
        {
            return (this.kechaichudesheshi().Count > 0);
        }
        public bool HasFaction()
        {
            return (this.BelongedFaction != null);
        }

        public bool HasFactionInClose(Faction faction, int level)
        {
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level > level)
                {
                    return false;
                }
                if (node.A.BelongedFaction == faction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFactionSpy(Faction faction)
        {
            foreach (SpyPack pack in this.SpyPacks)
            {
                if (pack.SpyPerson.BelongedFaction == faction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFollowedLeaderMilitary(Person person)
        {
            foreach (Military military in this.Militaries)
            {
                if (military.FollowedLeader == person)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasHostileArchitectureOnPath(LinkNode node)
        {
            foreach (Architecture architecture in node.Path)
            {
                if (((architecture != this) && (architecture != node.A)) && !((architecture.BelongedFaction == null) || this.IsFriendly(architecture.BelongedFaction)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasHostileTroopsInArchitecture()
        {
            foreach (Point point in this.ArchitectureArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !troopByPosition.IsFriendly(this.BelongedFaction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasOwnFactionTroopsInArchitecture()
        {
            foreach (Point point in this.ArchitectureArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && troopByPosition.BelongedFaction == this.BelongedFaction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasHostileTroopsInView()
        {
            GameArea viewArea = this.ViewArea;
            if ((this.RecentlyAttacked > 0) || (this.ArmyScale > this.NormalArmyScale))
            {
                viewArea = this.LongViewArea;
            }
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (!troopByPosition.IsFriendly(this.BelongedFaction) && (troopByPosition.Status != TroopStatus.埋伏)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasOwnFactionTroopsInView()
        {
            GameArea viewArea = this.LongViewArea;
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (troopByPosition != null && troopByPosition.BelongedFaction == this.BelongedFaction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMilitary()
        {
            return (this.Militaries.Count > 0);
        }

        public bool HasMovingPerson()
        {
            return (this.MovingPersons.Count > 0);
        }

        public bool HasNoFactionPerson()
        {
            return (this.NoFactionPersonCount > 0);
        }

        public bool HasOffensiveMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasOffensiveSectionInClose(out Section section, int level)
        {
            section = null;
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level > level)
                {
                    return false;
                }
                if (((node.A.BelongedSection != null) && (node.A.BelongedSection.BelongedFaction == this.BelongedFaction)) && node.A.BelongedSection.AIDetail.ValueOffensiveCampaign)
                {
                    section = node.A.BelongedSection;
                    return true;
                }
            }
            return false;
        }

        public bool HasPerson()
        {
            return (this.Persons.Count > 0);
        }

        public bool HasRelationUnderZeroHostileTroopsInView()
        {
            if (this.BelongedFaction != null)
            {
                GameArea viewArea = this.ViewArea;
                if (this.Kind.HasLongView && (this.ArmyScale < this.NormalArmyScale))
                {
                    viewArea = this.LongViewArea;
                }
                foreach (Point point in viewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && (troopByPosition.Status != TroopStatus.埋伏)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) < 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasRouteway(Architecture destination)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasRouteway(LinkNode node, bool hasEnd)
        {
            float rate = 1f;
            foreach (Routeway routeway in this.Routeways)
            {
                if (((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A))) && (routeway.LastPoint.ConsumptionRate <= this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax))
                {
                    return true;
                }
            }
            return this.FindRouteway(node, hasEnd, out rate);
        }

        public bool HasRouteway(LinkNode node, bool hasEnd, out float rate)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A))) && (routeway.LastPoint.ConsumptionRate <= this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax))
                {
                    rate = routeway.LastPoint.ConsumptionRate;
                    return true;
                }
            }
            return this.FindRouteway(node, hasEnd, out rate);
        }

        public RoutewayList HasRoutewayList(Architecture destination)
        {
            RoutewayList list = new RoutewayList();
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    list.Add(routeway);
                }
            }
            return list;
        }

        public int Shuiju9nMilitaryCount
        {
            get
            {
                int r = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Kind.Type == MilitaryType.水军 && military.KindID != 28 && military.KindID != 29)
                    {
                        r++;
                    }
                }
                return r;
            }
        }

        public int ShuijunMilitaryCount
        {
            get
            {
                int result = 0;
                foreach (Military m in this.Militaries)
                {
                    if (m.Kind.Type == MilitaryType.水军)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public bool HasShuijun()
        {
            return ShuijunMilitaryCount > 0;
        }

        public bool HasShuijunMilitaryKind()
        {
            foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.Type == MilitaryType.水军 && kind.ID != 29 && kind.ID != 28)
                {
                    return true;
                }
            }
            foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.Type == MilitaryType.水军 && kind.ID != 29 && kind.ID != 28)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTreasure()
        {
            foreach (Person person in this.GetAllPersons())
            {
                if (person.TreasureCount > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTreasureToAward()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                if (this.PersonCount <= 1)
                {
                    return false;
                }
                if (this.Persons.GetGameObject(this.BelongedFaction.Leader.ID) == null)
                {
                    return false;
                }
                foreach (Person person in this.Persons)
                {
                    if ((person == this.BelongedFaction.Leader) && (person.TreasureCount > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasTreasureToConfiscate()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                if (this.Persons.GetGameObject(this.BelongedFaction.Leader.ID) == null)
                {
                    return false;
                }
                foreach (Person person in this.Persons)
                {
                    if ((person != this.BelongedFaction.Leader) && (person.TreasureCount > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasUnavailablePerson(PersonList personlist)
        {
            foreach (Person person in personlist)
            {
                if (person.LocationArchitecture == null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasWorkingPerson()
        {
            foreach (Person person in this.Persons)
            {
                if (person.WorkKind != ArchitectureWorkKind.无)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HigtViewTroop(Troop troop)
        {
            return (this.ViewArea.HasPoint(troop.Position) && (((this.BelongedFaction != null) && this.IsFriendly(troop.BelongedFaction)) || (troop.Status != TroopStatus.埋伏)));
        }

        public void HireNoFactionPerson()
        {
            PersonList personList = new PersonList();
            PersonList recruitablePeople = new PersonList();
            foreach (Person person in this.NoFactionPersons.GetList())
            {
                if ((person.BelongedFaction != null) || (person.LocationArchitecture != this))
                {
                    //this.RemoveNoFactionPerson(person);
                }
                else
                {
                    int idealOffset = Person.GetIdealOffset(person, this.BelongedFaction.Leader);
                    if (
                            ((!GlobalVariables.IdealTendencyValid || (idealOffset <= person.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                            && (!this.BelongedFaction.IsAlien || (int)person.PersonalLoyalty < 2)
                            && (!person.HatedPersons.Contains(this.BelongedFaction.LeaderID)))
                        || (!base.Scenario.IsPlayer(this.BelongedFaction) && GlobalVariables.AIAutoTakeNoFactionPerson)
                           )
                    {
                        recruitablePeople.Add(person);
                    }
                }
            }
            if (recruitablePeople.Count > 0)
            {
                foreach (Person toRecruit in recruitablePeople.GetRandomList())
                {
                    this.DecreaseFund(this.HirePersonFund);
                    if (!((toRecruit.BelongedFaction != null) || (toRecruit.LocationArchitecture != this)))
                    {
                        int idealOffset = Person.GetIdealOffset(toRecruit, this.BelongedFaction.Leader);
                        if (
                            ((!GlobalVariables.IdealTendencyValid || (idealOffset <= toRecruit.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                            && (GameObject.Random(idealOffset * idealOffset + 100) < 100)
                            && (!this.BelongedFaction.IsAlien || (int)toRecruit.PersonalLoyalty < 2)
                            && (!toRecruit.HatedPersons.Contains(this.BelongedFaction.LeaderID)))
                        || (!base.Scenario.IsPlayer(this.BelongedFaction) && GlobalVariables.AIAutoTakeNoFactionPerson)
                           )
                        {
                            if (toRecruit.ProhibitedFactionID != this.BelongedFaction.ID)
                            {
                                personList.Add(toRecruit);
                            }
                        }
                    }
                    if (this.Fund < this.HirePersonFund)
                    {
                        break;
                    }
                    /*if (GameObject.Random(recruitablePeople.Count) < 0)
                    {
                        break;
                    }*/
                }
            }
            foreach (Person person in personList)
            {
                person.ChangeFaction(this.BelongedFaction);
				ExtensionInterface.call("HirePerson", new Object[] { this.Scenario, this, person });
                this.Scenario.GameScreen.xianshishijiantupian(person, this.Name, "ArchitectureHirePerson", "", "", this.BelongedFaction.Name, false);
            }
            if (personList.Count > 0)
            {
                /*
                if (this.OnHirePerson != null)
                {
                    this.OnHirePerson(personList);
                }
                */
                if (this.HasSpy)
                {
                    this.CreateHireNewPersonSpyMessage(personList[GameObject.Random(personList.Count)] as Person);
                }
            }
            else if (personList.Count == 0)
            {
                if ((this.Scenario.CurrentPlayer != null) && this.BelongedFaction == this.Scenario.CurrentPlayer)
                {
                    //this.shoudongluyongshibai = true;
                }

            }
            this.HireFinished = true;
        }
        /*
        public void shoudongluyong()
        {
            this.shoudongluyongshibai = false;
            this.HireNoFactionPerson();
            if (this.shoudongluyongshibai)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.NoFactionPersons[0] as Person, "", "luyongshibai", "", "",true );

            }
            this.shoudongluyongshibai = false;
        }
        */
        public void ManualHire(Person person)
        {
                  
        
            this.DecreaseFund(this.HirePersonFund);
            
            
            
                if ((person.BelongedFaction != null) || (person.LocationArchitecture != this))
                {
                    //this.NoFactionPerson.Remove(person);
                    this.Scenario.GameScreen.xianshishijiantupian(person, "", "luyongshibai", "", "", true);

                }
                else
                {
                    int idealOffset = Person.GetIdealOffset(person, this.BelongedFaction.Leader);
                    if (GlobalVariables.IdealTendencyValid && idealOffset > person.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75)
                    {
                        this.Scenario.GameScreen.xianshishijiantupian(person, "", "LinianButong", "", "", true);

                    }
                    else if (
                            (!GlobalVariables.IdealTendencyValid || (idealOffset <= person.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                            && (GameObject.Random(idealOffset * idealOffset + 100) < 100)
                            && (!this.BelongedFaction.IsAlien || (int)person.PersonalLoyalty < 2)
                            && (!person.HatedPersons.Contains(this.BelongedFaction.LeaderID))
                           )
                    {
                        person.ChangeFaction(this.BelongedFaction);
						ExtensionInterface.call("HirePerson", new Object[] { this.Scenario, this, person });
						
                        this.Scenario.GameScreen.xianshishijiantupian(person, this.Name, "ArchitectureHirePerson", "", "", this.BelongedFaction.Name, false);
                        if (this.HasSpy)
                        {
                            this.CreateHireNewPersonSpyMessage(person );
                        }
                    }
                    else 
                    {
                         this.Scenario.GameScreen.xianshishijiantupian(person , "", "luyongshibai", "", "",true );

                    }
                }
            
            this.HireFinished = true;
            this.HasManualHire = true;
        }


        public void IncreaseAgriculture(int increment)
        {
            this.Agriculture += increment;
            if (this.Agriculture > this.AgricultureCeiling)
            {
                this.Agriculture = this.AgricultureCeiling;
            }
        }

        public void IncreaseCommerce(int increment)
        {
            this.Commerce += increment;
            if (this.Commerce > this.CommerceCeiling)
            {
                this.Commerce = this.CommerceCeiling;
            }
        }

        public int IncreaseDomination(int increment)
        {
            int num = increment;
            if ((this.Domination + increment) > this.DominationCeiling)
            {
                num = this.DominationCeiling - this.Domination;
            }
            this.Domination += num;
            return num;
        }

        public int IncreaseEndurance(int increment)
        {
            if (increment <= 0)
            {
                return 0;
            }
            int num = increment;
            if ((this.Endurance + increment) > this.EnduranceCeiling)
            {
                num = this.EnduranceCeiling - this.Endurance;
            }
            if (this.Endurance == 0)
            {
                this.Endurance += num;
                this.WallStateChange();
            }
            else
            {
                this.Endurance += num;
            }
            return num;
        }

        public void IncreaseFood(int increment)
        {
            if ((increment + this.food) > this.FoodCeiling)
            {
                increment = this.FoodCeiling - this.food;
            }
            this.food += increment;
            this.IncrementNumberList.AddNumber(increment, CombatNumberKind.粮草, this.Position);
            this.ShowNumber = true;
        }

        public void IncreaseFund(int increment)
        {
            if ((increment + this.fund) > this.FundCeiling)
            {
                increment = this.FundCeiling - this.fund;
            }
            this.fund += increment;
            this.IncrementNumberList.AddNumber(increment, CombatNumberKind.资金, this.Position);
            this.ShowNumber = true;
        }

        public void IncreaseMilitaryPopulation(int increment)
        {
            this.militaryPopulation += increment;
            if (this.militaryPopulation > (int) (this.Population * (0.1 + militaryPopulationRateIncrease)))
            {
                this.militaryPopulation = (int) (this.Population * (0.1 + militaryPopulationRateIncrease));
            }
        }



        public void IncreaseMorale(int increment)
        {
            this.Morale += increment;
            if (this.Morale > this.MoraleCeiling)
            {
                this.Morale = this.MoraleCeiling;
            }
        }

        public int IncreasePopulation(int increment)
        {
            if ((this.population + increment) > this.PopulationCeiling)
            {
                increment = this.PopulationCeiling - this.population;
            }
            this.population += increment;
            if (this.population < 0)
            {
                this.population = 0;
            }
            return increment;
        }

        public void IncreaseTechnology(int increment)
        {
            this.Technology += increment;
            if (this.Technology > this.TechnologyCeiling)
            {
                this.Technology = this.TechnologyCeiling;
            }
        }

        private void IncreaseViewAreaCombativity()
        {
            if (this.IncrementOfCombativityInViewArea > 0)
            {
                foreach (Point point in this.ViewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition != null) && this.IsFriendly(troopByPosition.BelongedFaction))
                    {
                        troopByPosition.IncreaseCombativity(this.IncrementOfCombativityInViewArea);
                    }
                }
            }
        }

        public bool InformationAvail()
        {
            return (((this.InformationCoolDown <= 0) && this.HasPerson()) && base.Scenario.GameCommonData.AllInformationKinds.HasAvailItem(this));
        }

        private void InformationDayEvent()
        {
            if (this.InformationCoolDown > 0)
            {
                this.InformationCoolDown--;
            }
        }

        private void InsideTacticsAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && this.HasPerson())
            {
                if (this.Fund >= this.RewardPersonFund)
                {
                    if (this.IsFundEnough)
                    {
                        this.RewardPersonsUnderLoyalty(100);
                    }
                    else
                    {
                        Person extremeLoyaltyPerson = this.GetExtremeLoyaltyPerson(true);
                        if (!((extremeLoyaltyPerson.Loyalty >= 0x63) || extremeLoyaltyPerson.RewardFinished))
                        {
                            this.RewardPerson(extremeLoyaltyPerson);
                        }
                    }
                }
                if (((this.RecentlyAttacked <= 0) && (this.PlanArchitecture == null)) && !this.HasHostileTroopsInView())
                {
                    //Label_0221:
                    foreach (Person person in this.Persons.GetList())
                    {
                        if (((!this.FrontLine || !GameObject.Chance(5)) && !GameObject.Chance(20)) || (GameObject.Random(base.Scenario.Date.Day) < GameObject.Random(30)))
                        {
                            continue;
                        }
                        if (GameObject.Chance(50) && person.HasLearnableSkill)
                        {
                            person.GoForStudySkill();
                        }
                        else if (GameObject.Chance(50))
                        {
                            Title higherLevelLearnableTitle = person.HigherLevelLearnableTitle;
                            if (higherLevelLearnableTitle != null)
                            {
                                person.GoForStudyTitle(higherLevelLearnableTitle);
                            }
                        }
                        else if (base.Scenario.GameCommonData.AllStunts.Count > person.StuntCount)
                        {
                            foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.GetStuntList().GetRandomList())
                            {
                                if ((person.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(person))
                                {
                                    person.GoForStudyStunt(stunt);
                                    break;
                                }
                            }
                            //Label_0220:;
                        }
                    }
                    foreach (Person person in this.Persons.GetList())
                    {
                        if (this.idleDays > 4)
                        {
                            if ((person.WaitForFeiZi == null) && (person.WorkKind == ArchitectureWorkKind.无) && ((((((this.HostileLine && GameObject.Chance(10)) && GameObject.Chance(this.Morale / 10)) || !this.HostileLine) && ((GameObject.Random(base.Scenario.Date.Day) < GameObject.Random(30)) && (!this.HasFollowedLeaderMilitary(person) || GameObject.Chance(10)))) && (GameObject.Random(person.NonFightingNumber) > GameObject.Random(person.FightingNumber))) && (!this.FrontLine || (GameObject.Random(person.FightingNumber) < 100))))
                            {
                                if (person.Loyalty >= 100)
                                {
                                    person.GoForSearch();
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool InstigateAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.InstigateArchitectureFund)) && (this.GetInstigateArchitectureArea().Count > 0));
        }

        public bool IsCaptiveInArchitecture(Captive captive)
        {
            return this.Captives.HasGameObject(captive);
        }

        public bool IsFriendly(Faction faction)
        {
            return ((this.BelongedFaction == faction) || ((this.BelongedFaction != null) && this.BelongedFaction.IsFriendly(faction)));
        }

        public bool IsFull()
        {
            return (((((this.Agriculture == this.AgricultureCeiling) && (this.Commerce == this.CommerceCeiling)) && ((this.Technology == this.TechnologyCeiling) && (this.Domination == this.DominationCeiling))) && (this.Morale == this.MoraleCeiling)) && (this.Endurance == this.EnduranceCeiling));
        }

        public bool IsGood()
        {
            return (((((this.Agriculture >= (this.AgricultureCeiling * 0.6)) && (this.Commerce >= (this.CommerceCeiling * 0.6))) && ((this.Technology >= (this.TechnologyCeiling * 0.6)) && (this.Domination >= (this.DominationCeiling * 0.8)))) && (this.Morale >= (this.MoraleCeiling * 0.6))) && (this.Endurance >= (this.EnduranceCeiling * 0.6)));
        }

        public bool IsHostile(Faction faction)
        {
            return ((this.BelongedFaction != null) && this.BelongedFaction.IsHostile(faction));
        }

        public bool IsLandLink(Architecture a)
        {
            return (this.AILandLinks.GetGameObject(a.ID) != null);
        }

        public bool IsMilitaryUnavailable(Military military)
        {
            return (military.BelongedArchitecture == null);
        }

        internal bool IsNodeFoodEnough(LinkNode node, Routeway routeway)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfLandMilitaries * ((routeway.Length + 6) - (node.A.LandArmyScale / 8))));

                case LinkKind.Water:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfWaterMilitaries * ((routeway.Length + 6) - (node.A.WaterArmyScale / 8))));

                case LinkKind.Both:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfAllMilitaries * ((routeway.Length + 6) - (node.A.ArmyScale / 8))));
            }
            return false;
        }

        internal bool IsNodeHelpArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return ((!node.A.IsImportant && (node.A.LandArmyScale >= node.A.FewArmyScale)) || (node.A.LandArmyScale >= node.A.NormalArmyScale));

                case LinkKind.Water:
                    return ((!node.A.IsImportant && (node.A.WaterArmyScale >= node.A.FewArmyScale)) || (node.A.WaterArmyScale >= node.A.NormalArmyScale));

                case LinkKind.Both:
                    return ((!node.A.IsImportant && (node.A.ArmyScale >= node.A.FewArmyScale)) || (node.A.ArmyScale >= node.A.NormalArmyScale));
            }
            return false;
        }

        public bool IsOffensiveMilitary(Military m)
        {
            return ((((m.Scales >= 3) && (m.Morale >= 80)) && (m.Combativity >= 80)) && (m.InjuryQuantity <= m.Kind.MinScale));
        }

        public bool IsOK()
        {
            return (((((this.Agriculture >= (this.AgricultureCeiling * 0.45)) && (this.Commerce >= (this.CommerceCeiling * 0.45))) && ((this.Technology >= (this.TechnologyCeiling * 0.45)) && (this.Domination >= (this.DominationCeiling * 0.7)))) && (this.Morale >= (this.MoraleCeiling * 0.45))) && (this.Endurance >= (this.EnduranceCeiling * 0.4)));
        }

        public bool IsRoutewayPossible(Point p)
        {
            if (base.Scenario.GetArchitectureByPosition(p) != null)
            {
                return false;
            }
            TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(p);
            return ((terrainDetailByPosition != null) && ((this.BelongedFaction == null) || ((this.BelongedFaction.RoutewayWorkForce >= terrainDetailByPosition.RoutewayBuildWorkCost) && (terrainDetailByPosition.RoutewayConsumptionRate < 1f))));
        }

        internal bool IsSelfFoodEnough(LinkNode node, Routeway routeway)
        {
            //if (routeway.LastPoint != null)   //临时加上，避免跳出
            {
                switch (node.Kind)
                {
                    case LinkKind.None:
                        return false;

                    case LinkKind.Land:
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfLandMilitaries * ((routeway.Length + 6) - (this.LandArmyScale / 8))));

                    case LinkKind.Water:
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfWaterMilitaries * ((routeway.Length + 6) - (this.WaterArmyScale / 8))));

                    case LinkKind.Both:
                        return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfAllMilitaries * ((routeway.Length + 6) - (this.ArmyScale / 8))));
                }
            }
            return false;
        }

        internal bool IsSelfHelpArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return ((!this.IsImportant && (this.LandArmyScale >= this.FewArmyScale)) || (this.LandArmyScale >= this.NormalArmyScale));

                case LinkKind.Water:
                    return ((!this.IsImportant && (this.WaterArmyScale >= this.FewArmyScale)) || (this.WaterArmyScale >= this.NormalArmyScale));

                case LinkKind.Both:
                    return ((!this.IsImportant && (this.ArmyScale >= this.FewArmyScale)) || (this.ArmyScale >= this.NormalArmyScale));
            }
            return false;
        }

        internal bool IsSelfMoveArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.LandArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.LandArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.LandArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.LandArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.LandArmyScale > this.FewArmyScale)));

                case LinkKind.Water:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.WaterArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.WaterArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.WaterArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.WaterArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.WaterArmyScale > this.FewArmyScale)));

                case LinkKind.Both:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.ArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.ArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.ArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.ArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.ArmyScale > this.FewArmyScale)));
            }
            return false;
        }

        internal bool IsSelfOffensiveArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((!base.Scenario.IsPlayer(node.A.BelongedFaction) && this.LandArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.LandArmyScale > node.A.ArmyScale))) || (!node.A.IsImportant && ((this.LandArmyScale * 2) > (node.A.ArmyScale * 3))));

                case LinkKind.Water:
                    return (((!base.Scenario.IsPlayer(node.A.BelongedFaction) && this.WaterArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.WaterArmyScale > node.A.ArmyScale))) || (!node.A.IsImportant && ((this.WaterArmyScale * 2) > (node.A.ArmyScale * 3))));

                case LinkKind.Both:
                    return (((!base.Scenario.IsPlayer(node.A.BelongedFaction) && this.ArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.ArmyScale > node.A.ArmyScale))) || ((!node.A.IsImportant && (this.ArmyScale > this.NormalArmyScale)) && ((this.ArmyScale * 2) > (node.A.ArmyScale * 3))));
            }
            return false;
        }

        public bool IsViewing(Point position)
        {
            return this.LongViewArea.HasPoint(position);
        }

        public bool IsWaterLink(Architecture a)
        {
            return (this.AIWaterLinks.GetGameObject(a.ID) != null);
        }

        public bool LevelUpAvail()
        {
            foreach (Military military in this.Militaries)
            {
                if (((military.InjuryQuantity == 0) && military.Kind.CanLevelUp) && (military.Experience >= military.Kind.LevelUpExperience))
                {
                    return true;
                }
            }
            return false;
        }

        public void LevelUpMilitary(Military m)
        {
            MilitaryKind militaryKind = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(m.Kind.LevelUpKindID);
            if (militaryKind != null)
            {
                int num = (m.Quantity * militaryKind.MinScale) / m.Kind.MinScale;
                int num2 = ((m.Experience - m.Kind.LevelUpExperience) * militaryKind.MinScale) / m.Kind.MinScale;
                this.IncreasePopulation(m.Quantity - num);
                m.Kind = militaryKind;
                m.Quantity = num;
                m.Experience = num2;
                m.Name = m.Kind.Name + "队";
				ExtensionInterface.call("LevelUpMilitary", new Object[] { this.Scenario, this, m });
            }
        }

        private int RoutewayPathBuilder_OnGetCost(Point position, out float consumptionRate)
        {
            GameArea singleton = new GameArea();
            singleton.AddPoint(position);

            consumptionRate = 0f;
            if (!base.Scenario.PositionOutOfRange(position))
            {
                int dist = (int) Math.Ceiling(Math.Min(Math.Min(base.Scenario.GetDistance(singleton, this.pathFinder.startingArchitecture.ArchitectureArea),
                    base.Scenario.GetDistance(singleton, this.pathFinder.targetArchitecture.ArchitectureArea)), 20));
                if (dist > 4)
                {
                    for (int i = -dist; i <= dist; ++i)
                    {
                        for (int j = Math.Abs(i) - dist; j <= dist - Math.Abs(i); ++j)
                        {
                            Point loc = new Point(position.X + i, position.Y + j);
                            Architecture landedArch = base.Scenario.GetArchitectureByPosition(loc);

                            if (landedArch != null && landedArch != this.pathFinder.startingArchitecture && landedArch != this.pathFinder.targetArchitecture)
                            {
                                return 1000;
                            }
                        }
                    }
                }

                TerrainDetail terrainDetailByPositionNoCheck = base.Scenario.GetTerrainDetailByPositionNoCheck(position);
                if (terrainDetailByPositionNoCheck != null)
                {
                    Architecture landedArch = base.Scenario.GetArchitectureByPosition(position);
                    if (landedArch != null && landedArch != this.pathFinder.startingArchitecture && landedArch != this.pathFinder.targetArchitecture)
                    {
                        return 1000;
                    } 
                    else if (landedArch == null)
                    {
                        if (this.pathFinder.MultipleWaterCost && !base.Scenario.IsWaterPositionRoutewayable(position))
                        {
                            return 1000;
                        }
                        if (this.pathFinder.MustUseWater && (terrainDetailByPositionNoCheck.ID != 6))
                        {
                            return 1000;
                        }
                    }
                    return 1;
                }
            }
            return 0x3e8;
        }

        private int RoutewayPathBuilder_OnGetPenalizedCost(Point position)
        {
            return 0;
        }

        public void FindLinks(ArchitectureList allArch)
        {
            pathFinder.OnGetCost += new RoutewayPathFinder.GetCost(RoutewayPathBuilder_OnGetCost);
            pathFinder.OnGetPenalizedCost += new RoutewayPathFinder.GetPenalizedCost(RoutewayPathBuilder_OnGetPenalizedCost);
            FindLandLinks(allArch, 50);
            FindWaterLinks(allArch, 50);
        }

        private GameArea GetLandTroopMovableArea()
        {
            GameArea a = new GameArea();
            foreach (Point i in this.ArchitectureArea.Area)
            {
                if (base.Scenario.GetTerrainDetailByPositionNoCheck(i).ID != 6)
                {
                    a.AddPoint(i);
                }
                else
                {
                    TerrainKind t1 = base.Scenario.GetTerrainKindByPosition(new Point(i.X - 1, i.Y));
                    TerrainKind t2 = base.Scenario.GetTerrainKindByPosition(new Point(i.X + 1, i.Y));
                    TerrainKind t3 = base.Scenario.GetTerrainKindByPosition(new Point(i.X, i.Y - 1));
                    TerrainKind t4 = base.Scenario.GetTerrainKindByPosition(new Point(i.X, i.Y + 1));
                    if (t1 != TerrainKind.水域 && t1 != TerrainKind.无)
                    {
                        a.AddPoint(i);
                    }
                    else if (t2 != TerrainKind.水域 && t2 != TerrainKind.无)
                    {
                        a.AddPoint(i);
                    }
                    else if (t3 != TerrainKind.水域 && t3 != TerrainKind.无)
                    {
                        a.AddPoint(i);
                    }
                    else if (t4 != TerrainKind.水域 && t4 != TerrainKind.无)
                    {
                        a.AddPoint(i);
                    } 
                }
            }
            return a;
        }

        private GameArea GetWaterTroopMovableArea()
        {
            return this.ArchitectureArea;
        }

        private RoutewayPathFinder pathFinder = new RoutewayPathFinder();
        private void FindLandLinks(ArchitectureList allArch, int maxDistance)
        {
            foreach (Architecture i in allArch)
            {
                if (i == this) continue;
                if (i.AILandLinks.GameObjects.Contains(this)) continue;
                if (base.Scenario.GetSimpleDistance(i.Position, this.Position) < maxDistance)
                {
                    pathFinder.ConsumptionMax = 0.7f;
                    pathFinder.startingArchitecture = this;
                    pathFinder.targetArchitecture = i;
                    pathFinder.MultipleWaterCost = !GlobalVariables.LandArmyCanGoDownWater;
                    pathFinder.MustUseWater = false;
                    Point? p1;
                    Point? p2;
                    base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetLandTroopMovableArea(), i.GetLandTroopMovableArea(), out p1, out p2);
                    if (p1.HasValue && p2.HasValue)
                    {
                        if (pathFinder.GetPath(p1.Value, p2.Value, true))
                        {
                            this.AILandLinks.Add(i);
                            i.AILandLinks.Add(this);
                        }
                    }
                }
            }
        }

        private void FindWaterLinks(ArchitectureList allArch, int maxDistance)
        {
            if (!this.IsBesideWater) return;
            foreach (Architecture i in allArch)
            {
                if (i == this) continue;
                if (!i.IsBesideWater) continue;
                if (i.AIWaterLinks.GameObjects.Contains(this)) continue;
                pathFinder.startingArchitecture = this;
                pathFinder.targetArchitecture = i;
                pathFinder.MultipleWaterCost = false;
                pathFinder.MustUseWater = true;
                if (base.Scenario.GetSimpleDistance(i.Position, this.Position) < maxDistance)
                {
                    pathFinder.ConsumptionMax = 0.7f;
                    Point? p1;
                    Point? p2;
                    base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetWaterTroopMovableArea(), i.GetWaterTroopMovableArea(), out p1, out p2);
                    if (p1.HasValue && p2.HasValue)
                    {
                        if (pathFinder.GetPath(p1.Value, p2.Value, true))
                        {
                            this.AIWaterLinks.Add(i);
                            i.AIWaterLinks.Add(this);
                        }
                    }
                }
            }
        }

        public void LoadAILandLinksFromString(ArchitectureList architectures, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.AILandLinks.Clear();
            foreach (string str in strArray)
            {
                Architecture gameObject = architectures.GetGameObject(int.Parse(str)) as Architecture;
                if (gameObject != null)
                {
                    this.AILandLinks.Add(gameObject);
                }
            }
        }

        public void LoadAIWaterLinksFromString(ArchitectureList architectures, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.AIWaterLinks.Clear();
            foreach (string str in strArray)
            {
                Architecture gameObject = architectures.GetGameObject(int.Parse(str)) as Architecture;
                if (gameObject != null)
                {
                    this.AIWaterLinks.Add(gameObject);
                }
            }
        }

        public void LoadCaptivesFromString(CaptiveList captives, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Captive gameObject = captives.GetGameObject(int.Parse(str)) as Captive;
                if (gameObject != null)
                {
                    gameObject.CaptivePerson.LocationArchitecture = this;
                    gameObject.CaptivePerson.LocationTroop = null;
                    gameObject.CaptivePerson.Status = PersonStatus.Captive;
                }
            }
        }

        public void LoadFacilitiesFromString(FacilityList facilities, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Facilities.Clear();
            foreach (string str in strArray)
            {
                Facility gameObject = facilities.GetGameObject(int.Parse(str)) as Facility;
                if (gameObject != null)
                {
                    this.Facilities.AddFacility(gameObject);
                }
            }
        }

        internal void LoadFundPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.FundPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.FundPacks.Add(new FundPack(int.Parse(strArray[i]), int.Parse(strArray[i + 1])));
            }
        }

        public void LoadMilitariesFromString(MilitaryList militaries, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Militaries.Clear();
            foreach (string str in strArray)
            {
                Military gameObject = militaries.GetGameObject(int.Parse(str)) as Military;
                if (gameObject != null)
                {
                    this.AddMilitary(gameObject);
                }
            }
        }

        public void LoadMovingPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null)
                {
                    t.LocationArchitecture = this;
                    t.LocationTroop = null;
                    t.Status = PersonStatus.Moving;
                    t.TargetArchitecture = this;
                }
            }
        }

        public void LoadNoFactionMovingPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null)
                {
                    t.LocationArchitecture = this;
                    t.LocationTroop = null;
                    t.Status = PersonStatus.NoFactionMoving;
                    t.TargetArchitecture = this;
                }
            }
        }

        public void LoadNoFactionPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Person person = persons[int.Parse(str)];
                if (person != null && !base.Scenario.isInCaptiveList(person.ID))
                {
                    person.LocationArchitecture = this;
                    person.LocationTroop = null;
                    person.Status = PersonStatus.NoFaction;
                }
            }
        }

        public void LoadfeiziPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Person person = persons[int.Parse(str)];
                if (person != null)
                {
                    person.LocationArchitecture = this;
                    person.LocationTroop = null;
                    person.Status = PersonStatus.Princess;
                    

                    /*if (person.suoshurenwu == -1)
                    {
                        person.suoshurenwu = this.BelongedFaction.LeaderID;
                    }*/
                }
            }
        }

        public void LoadPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null && !base.Scenario.isInCaptiveList(t.ID))
                {
                    t.LocationArchitecture = this;
                    t.LocationTroop = null;
                    t.Status = PersonStatus.Normal;
                }
            }
        }

        internal void LoadPopulationPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.PopulationPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.PopulationPacks.Add(new PopulationPack(int.Parse(strArray[i]), int.Parse(strArray[i + 1])));
            }
        }

        internal void LoadSpyPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.SpyPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                Person gameObject = base.Scenario.Persons.GetGameObject(int.Parse(strArray[i])) as Person;
                if (gameObject != null)
                {
                    this.SpyPacks.Add(new SpyPack(gameObject, int.Parse(strArray[i + 1])));
                }
            }
        }

        public bool MergeAvail()
        {
            for (int i = 0; i < this.Militaries.Count; i++)
            {
                Military military = this.Militaries[i] as Military;
                if ((military.Quantity != military.Kind.MaxScale) && (military.InjuryQuantity <= 0))
                {
                    foreach (Military military2 in this.Militaries)
                    {
                        if (((military != military2) && (military.Kind == military2.Kind)) && ((military2.Quantity < military2.Kind.MaxScale) && (military2.InjuryQuantity == 0)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void MonthEvent()
        {
            this.DevelopMonth();
        }

        public bool MoraleAvail()
        {
            return (this.Kind.HasMorale && this.HasPerson());
        }

        public bool NewMilitaryAvail()
        {
            if (this.BelongedFaction != null)
            {
                if (!this.Kind.HasPopulation)
                {
                    return false;
                }
                foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
                {
                    if (kind.CreateAvail(this))
                    {
                        return true;
                    }
                }
                foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
                {
                    if (kind.CreateAvail(this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool NewSectionAvail()
        {
            return (this.BelongedFaction.ArchitectureCount > 1);
        }

        public int connectedToFactionArchitectureCount(Faction f)
        {
            int result = 0;
            foreach (Architecture a in this.GetAILinks())
            {
                if (a.BelongedFaction == f)
                {
                    result++;
                }
            }
            return result;
        }

        public int connectedNotToFactionArchitectureCount(Faction f)
        {
            int result = 0;
            foreach (Architecture a in this.GetAILinks())
            {
                if (a.BelongedFaction != f)
                {
                    result++;
                }
            }
            return result;
        }

        private int AttackableLandArmyScale
        {
            get
            {
                int result = 0;
                int troopCnt = 0;
                foreach (Military i in this.Militaries)
                {
                    if (i.Kind.Type != MilitaryType.水军)
                    {
                        result += i.Scales;
                        troopCnt++;
                        if (troopCnt >= this.Persons.Count) break;
                    }
                }
                return result;
            }
        }

        private int AttackableWaterArmyScale
        {
            get
            {
                int result = 0;
                int troopCnt = 0;
                foreach (Military i in this.Militaries)
                {
                    result += i.Scales / (i.Kind.Type == MilitaryType.水军 ? 1 : 2);
                    troopCnt++;
                    if (troopCnt >= this.Persons.Count) break;
                }
                return result;
            }
        }

        private int getArmyReserveForOffensive(LinkNode target)
        {
            int totalThreat = 0;
            int maxThreat = 0;
            int playerMaxThreat = 0;
            int playerTotalThreat = 0;
            foreach (LinkNode i in this.AIAllLinkNodes.Values)
            {
                if (i == target) continue;
                if (i.Level > 1) break;
                if (i.A.BelongedFaction != null && !this.IsFriendly(i.A.BelongedFaction))
                {
                    int threat = (i.Kind == LinkKind.Land ? i.A.AttackableLandArmyScale : i.A.AttackableWaterArmyScale);
                    if (threat > maxThreat)
                    {
                        maxThreat = threat;
                        if (base.Scenario.IsPlayer(i.A.BelongedFaction))
                        {
                            playerMaxThreat = threat;
                        }
                    }
                    totalThreat += threat;
                    if (base.Scenario.IsPlayer(i.A.BelongedFaction))
                    {
                        playerTotalThreat += threat;
                    }
                }
            }
            int reserve;
            if (GlobalVariables.PinPointAtPlayer && this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.势力 &&
                    base.Scenario.IsPlayer(this.BelongedSection.OrientationFaction))
            {
                maxThreat = playerMaxThreat;
                totalThreat = playerTotalThreat;
            }
            Person leader = this.BelongedFaction.Leader;
            if (leader.Braveness >= 5 || leader.Calmness <= 5)
            {
                reserve = (int)(maxThreat * (0.8 + (leader.Calmness - leader.Braveness) * 0.1));
            }
            else
            {
                reserve = (int)(totalThreat / 2 * (0.8 + (leader.Calmness - leader.Braveness) * 0.1));
            }
            return reserve;
        }

        private bool ignoreReserve = false;
        private void OffensiveCampaign()
        {
            Person leader = this.BelongedFaction.Leader;
            if (this.BelongedSection != null && !this.BelongedSection.AIDetail.AllowOffensiveCampaign)
            {
                this.PlanArchitecture = null;
            }
            else if (!this.HasPerson())
            {
                this.PlanArchitecture = null;
            }
            else if ((this.PlanArchitecture != null) || ((this.InformationCoolDown <= 0) && (this.IsGood() || GameObject.Chance((int) (GameObject.Square((int)leader.Ambition) * Parameters.AIAttackChanceIfUnfull))) &&
                (this.Domination >= this.DominationCeiling || this.Population <= this.Kind.PopulationBoundary / 2)))
            {
                Architecture target = this.PlanArchitecture;
                LinkNode wayToTarget = null;
                if (target == null)
                {
                    ignoreReserve = false;
                    //choose target
                    int maxWeight = int.MinValue;
                    LinkNode maxNode = null;
                    int maxLevel = 1;
                    foreach (LinkNode i in this.AIAllLinkNodes.Values)
                    {
                        if (i.Level > maxLevel && maxNode != null)
                        {
                            break;
                        }
                        else if (i.Level > maxLevel)
                        {
                            maxLevel++;
                        }
                        if (this.IsFriendly(i.A.BelongedFaction) || i.Kind == LinkKind.None)
                        {
                            continue;
                        }
                        if (GameObject.Chance(Parameters.AIObeyStrategyTendencyChance) && this.BelongedFaction.Leader.StrategyTendency == PersonStrategyTendency.统一地区 && i.A.LocationState.LinkedRegion != this.LocationState.LinkedRegion)
                        {
                            continue;
                        }
                        if (GameObject.Chance(Parameters.AIObeyStrategyTendencyChance) && this.BelongedFaction.Leader.StrategyTendency == PersonStrategyTendency.统一州 && i.A.LocationState != this.LocationState)
                        {
                            continue;
                        }
                        if (GameObject.Chance(Parameters.AIObeyStrategyTendencyChance) && this.BelongedFaction.Leader.StrategyTendency == PersonStrategyTendency.维持现状)
                        {
                            continue;
                        }
                        if (i.A.BelongedFaction != null && i.A.BelongedFaction.ArchitectureCount > 1 && i.A.connectedNotToFactionArchitectureCount(this.BelongedFaction) > 0)
                        {
                            if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.军区)
                            {
                                continue;
                            }
                            if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.势力)
                            {
                                if (this.BelongedSection.OrientationFaction != i.A.BelongedFaction)
                                {
                                    continue;
                                }
                            }
                            if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.州域)
                            {
                                if (this.BelongedSection.OrientationState != i.A.LocationState)
                                {
                                    continue;
                                }
                            }
                            if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.建筑)
                            {
                                if (this.BelongedSection.OrientationArchitecture != i.A)
                                {
                                    continue;
                                }
                            }
                            if (this.BelongedSection.AIDetail.OrientationKind == SectionOrientationKind.无)
                            {
                                if (i.A.BelongedFaction != null &&
                                    (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, i.A.BelongedFaction.ID) >= leader.Uncruelty * Parameters.AIOffendMaxDiplomaticRelationMultiply)
                                    && GameObject.Random(leader.Uncruelty * leader.Uncruelty * 10) > 0)
                                /*&& this.BelongedFaction.ArchitectureCount < i.A.BelongedFaction.ArchitectureCount + leader.Uncruelty - 2*/
                                {
                                    continue;
                                }
                            }
                        }
                        Routeway rw = this.GetRouteway(i, true);
                        if (rw == null)
                        {
                            continue;
                        }
                        if (rw.ByPassHostileArchitecture)
                        {
                            continue;
                        }
                        if (!IsSelfFoodEnoughForOffensive(i, rw))
                        {
                            continue;
                        }
                        int weight = 1000 + (i.Kind == LinkKind.Land ? this.LandArmyScale : this.WaterArmyScale) - i.A.ArmyScale;
                        weight += weight / 10 * (i.A.connectedToFactionArchitectureCount(this.BelongedFaction) - i.A.connectedNotToFactionArchitectureCount(this.BelongedFaction));
                        if (i.A.IsImportant)
                        {
                            weight = weight * 3 / 2;
                        }
                        if (i.A.PopulationCeiling > 0 && this.PopulationCeiling > 0)
                        {
                            weight = (int)(weight * ((double)(i.A.Population - this.Population) / this.PopulationCeiling / 2 + 0.5));
                        }
                        else
                        {
                            if (i.A.PopulationCeiling <= 0)
                            {
                                weight /= 3;
                            }
                        }
                        if (weight > maxWeight)
                        {
                            maxWeight = weight;
                            maxNode = i;
                        }
                    }
                    wayToTarget = maxNode;
                }
                else
                {
                    //get way to target
                    this.AIAllLinkNodes.TryGetValue(this.PlanArchitecture.ID, out wayToTarget);
                }
                if (wayToTarget != null)
                {
                    int reserve = this.getArmyReserveForOffensive(wayToTarget);
                    int armyScaleRequiredForAttack = (int) ((wayToTarget.A.ArmyScale +
                        (wayToTarget.A.DefensiveLegion == null || base.Scenario.IsPlayer(wayToTarget.A.BelongedFaction) ? 0 : wayToTarget.A.DefensiveLegion.ArmyScale * Parameters.AIOffendDefendingTroopRate)) *
                        (Parameters.AIOffendDefendTroopAdd + (leader.Calmness - leader.Braveness + (3 - (int)leader.Ambition) * 2) * Parameters.AIOffendDefendTroopMultiply));
                    int armyScaleHere = (wayToTarget.Kind == LinkKind.Land ? this.LandArmyScale : (this.WaterArmyScale + this.LandArmyScale / 2));
                    if (wayToTarget.A.BelongedFaction != null && (armyScaleHere < armyScaleRequiredForAttack + reserve) && !ignoreReserve)
                    {
                        if ((GameObject.Random((5 - (int)leader.Ambition) * Parameters.AIOffendIgnoreReserveProbAmbitionMultiply - Parameters.AIOffendIgnoreReserveProbAmbitionAdd) == 0 &&
                            (GameObject.Random((leader.Calmness - leader.Braveness) * Parameters.AIOffendIgnoreReserveProbBCDiffMultiply + Parameters.AIOffendIgnoreReserveProbBCDiffAdd)) == 0) &&
                            (GameObject.Chance((int)(((double)armyScaleHere / wayToTarget.A.ArmyScale - Parameters.AIOffendIgnoreReserveChanceTroopRatioAdd) * Parameters.AIOffendIgnoreReserveChanceTroopRatioMultiply))))
                        {
                            ignoreReserve = true;
                        }
                        else if ((GlobalVariables.PopulationRecruitmentLimit && (this.ArmyQuantity > this.Population)) || this.Population <= 0 ||
                            !this.Kind.HasPopulation || !this.Kind.HasMorale)
                        {
                            ignoreReserve = true;
                        } 
                        else 
                        {
                            this.PlanArchitecture = null;
                            return;
                        }
                    }
                    if (this.BelongedFaction.IsArchitectureKnown(wayToTarget.A))
                    {
                        Routeway routeway = this.GetRouteway(wayToTarget, true);
                        if (routeway == null)
                        {
                            this.PlanArchitecture = null;
                        }
                        else if (routeway.ByPassHostileArchitecture)
                        {
                            this.PlanArchitecture = null;
                        }
                        else if ((routeway.LastPoint.BuildFundCost * (4 + ((wayToTarget.A.AreaCount >= 4) ? 2 : 0))) > this.Fund)
                        {
                            routeway.Building = false;
                            this.PlanArchitecture = wayToTarget.A;
                        }
                        else
                        {
                            double foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                            if (!(((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnoughForOffensive(wayToTarget, routeway)))
                            {
                                routeway.Building = false;
                                this.PlanArchitecture = wayToTarget.A;
                            }
                            else if (GlobalVariables.LiangdaoXitong && (routeway.LastPoint.ConsumptionRate >= 0.1f) && (((int)(routeway.Length * (routeway.LastPoint.ConsumptionRate + 0.2f))) > routeway.LastActivePointIndex))
                            {
                                routeway.Building = true;
                                this.PlanArchitecture = wayToTarget.A;
                            }
                            else
                            {
                                if (!routeway.IsActive)
                                {
                                    routeway.Building = true;
                                }
                                while (this.ArmyScale > reserve || ignoreReserve)
                                {
                                    if (this.BuildOffensiveTroop(wayToTarget.A, wayToTarget.Kind, true) == null)
                                    {
                                        break;
                                    }
                                    if (!(this.HasOffensiveMilitary() && this.HasPerson()))
                                    {
                                        break;
                                    }
                                }
                                if (armyScaleHere <= reserve)
                                {
                                    this.PlanArchitecture = null;
                                }
                            }
                        }
                                        
                    } 
                    else if (this.InformationAvail())
                    {
                        Routeway routeway = this.GetRouteway(wayToTarget, true);
                        if (((routeway != null) && !routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * (4 + ((wayToTarget.A.AreaCount >= 4) ? 2 : 0))) <= this.Fund))
                        {
                            double foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                            if (((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnoughForOffensive(wayToTarget, routeway))
                            {
                                this.PlanArchitecture = wayToTarget.A;
                                Person firstHalfPerson = this.GetFirstHalfPerson("InformationAbility");
                                if (firstHalfPerson != null && firstHalfPerson.LocationArchitecture != null)
                                {
                                    firstHalfPerson.CurrentInformationKind = this.GetFirstHalfInformationKind();
                                    if (firstHalfPerson.CurrentInformationKind != null)
                                    {
                                        firstHalfPerson.GoForInformation(base.Scenario.GetClosestPoint(wayToTarget.A.ArchitectureArea, this.Position));
                                    }
                                }
                                else
                                {
                                    this.PlanArchitecture = null;
                                }
                            }
                        }
                    }
                        
                }
            }
        }

        private void OLD_OffensiveCampaign()
        {
            //No offensive campaign if
            //1. the section is not allowed to do so
            //2. no officer is in the city
            //3. information hasn't been cooled down and no target specified
            if (this.BelongedSection != null && !this.BelongedSection.AIDetail.AllowOffensiveCampaign)
            {
                this.PlanArchitecture = null;
            }
            else if (!this.HasPerson())
            {
                this.PlanArchitecture = null;
            }
            else if ((this.PlanArchitecture != null) || (this.InformationCoolDown <= 0))
            {
                //do not give a target, and cancel any offensive, if
                //1. there is no military good enough for an offensive
                //2. there is only 1 offensive army which scale < 30
                //3. There is nowhere for military to appear near the city
                //Otherwise, go into next step if:
                //5% chance, or population < 10000, or domination reaches its ceiling, or endurance reaches 20% of its ceiling, 
                //   or target is already specified and not cancelled
                int num = this.OffensiveMilitaryCount();
                if (num <= 0)
                {
                    this.PlanArchitecture = null;
                }
                else if (!((num != 1) || this.HasEnoughForceOffensiveMilitary()))
                {
                    this.PlanArchitecture = null;
                }
                else if (this.GetAllAvailableArea(false).Count == 0)
                {
                    this.PlanArchitecture = null;
                }
                else if ((((this.PlanArchitecture != null) || (this.Population < (10000 * this.AreaCount))) || ((this.Domination >= this.DominationCeiling) || (this.Endurance >= (this.EnduranceCeiling * 0.2f)))) || GameObject.Chance(5))
                {
                    //cancel any offensive if
                    //1. population >= 1000 (ignored if arch type has no population), and
                    //2. this arch is not good, and "good" means internal values reached 60% of their ceilings (80% of domination), and
                    //3. armyscale too little or army quantity less than half of the population (ignored if arch type has no population), and
                    //4. armyscale is not many or domination < 80% or endurance < 20%
                    if ((((!this.Kind.HasPopulation || (this.Population >= (1000 * this.AreaCount))) && !this.IsGood()) && ((!this.Kind.HasPopulation || (this.ArmyScale <= this.FewArmyScale)) || (this.ArmyQuantity <= (this.Population / 2)))) && (((this.ArmyScale < this.NormalArmyScale) || (this.Domination < (this.DominationCeiling * 0.8))) || (this.Endurance < (0.2f * this.EnduranceCeiling))))
                    {
                        this.PlanArchitecture = null;
                    }
                    else
                    {
                        LinkNode node = null;
                        int num2 = 0;
                        //if there is no target, pick one.
                        if (this.PlanArchitecture != null)
                        {
                            this.AIAllLinkNodes.TryGetValue(this.PlanArchitecture.ID, out node);
                        }
                        else
                        {
                            int num4;
                            double distance;
                            List<LinkNode> list = new List<LinkNode>();
                            List<LinkNode> list2 = new List<LinkNode>();
                            List<LinkNode> list3 = new List<LinkNode>();
                            //int level = 1;
                            bool flag = this.LandArmyScale < this.VeryFewArmyScale;
                            bool flag2 = this.WaterArmyScale < this.VeryFewArmyScale;
                            //consider which target to attack
                            foreach (LinkNode node2 in this.AIAllLinkNodes.Values)
                            {
                                //stop the consideration entirely if a node has level > 2 i.e. the shortest distance from this arch to node2 arch > 2
                                Legion legion;
                                /*if (node2.Level > 2)
                                {
                                    break;
                                }
                                //stop the consideration entirely if a node has level > 1 unless there is another factioned base which satisfies the following code conditions
                                if (node2.Level > level)
                                {
                                    if (list3.Count > 0)
                                    {
                                        break;
                                    }
                                    level = node2.Level;
                                }*/
                                if (node2.Level > 1)
                                {
                                    break;
                                    /*bool ok = true;
                                    for (int i = 1; i < node2.Path.Count - 1; ++i)
                                    {
                                        if (node2.Path[i].kind.HasPopulation)
                                        {
                                            ok = false;
                                            break;
                                        }
                                    }
                                    if (!ok) continue;*/
                                }
                                //don't attack any base that is friendly, or don't have enough troop on land/water to attack the base
                                if ((this.IsFriendly(node2.A.BelongedFaction) || (node2.Kind == LinkKind.None)) || (((node2.Kind == LinkKind.Land) && flag) || ((node2.Kind == LinkKind.Water) && flag2)))
                                {
                                    continue;
                                }
                                //don't attack any base that violates leader's stretagy tendency (possible culprit)
                                //111113 - added condition by troop scale that violates leader's tendency
                                switch (this.BelongedFaction.Leader.StrategyTendency)
                                {
                                    case PersonStrategyTendency.统一地区:
                                        {
                                            if (node2.A.LocationState.LinkedRegion == this.LocationState.LinkedRegion || this.ArmyScale > 1.5 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                    case PersonStrategyTendency.统一州:
                                        {
                                            if (node2.A.LocationState == this.LocationState || this.ArmyScale > 1.75 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                    case PersonStrategyTendency.维持现状:
                                        {
                                            if (node2.A.BelongedFaction == null || this.ArmyScale > 2.0 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                }
                                //consider empty base if there is no legion (group a troops launching an attack) or the legion has less than 6 troops, and
                                //10% of chance or base is important or its population > 10000
                                if (node2.A.BelongedFaction == null)
                                {
                                    legion = this.BelongedFaction.GetLegion(node2.A);
                                    if (((legion == null) || (legion.Troops.Count < 6)) && ((GameObject.Chance(10) || node2.A.IsImportant) || (node2.A.Kind.HasPopulation && (node2.A.Population > (0x2710 * node2.A.AreaCount)))))
                                    {
                                        list.Add(node2);
                                    }
                                }
                                else
                                {
                                    list3.Add(node2);
                                    if (this.BelongedSection != null)
                                    {
                                        switch (this.BelongedSection.AIDetail.OrientationKind)
                                        {
                                            //otherwise, if no section command ordered, if
                                            //1. population >= 1000, and
                                            //2. not having many army, and 
                                            //3. having little army or army quantity < 0.8 * population, and
                                            //4. base is not completely developed or has not more than enough troop
                                            //add in base which (diplomatic relation + more arch than us) < 0, and more negative, greater chance
                                            //otherwise, if no legion is going on or that legion has troops count < 30, add into list
                                            case SectionOrientationKind.无:
                                                if (!this.BelongedSection.AIDetail.ValueOffensiveCampaign || ((((!this.Kind.HasPopulation || (this.Population >= (1000 * this.AreaCount))) && (this.ArmyScale < this.LargeArmyScale)) && ((!this.Kind.HasPopulation || (this.ArmyScale < this.FewArmyScale)) || (this.ArmyQuantity <= (this.Population * 0.8f)))) && (!this.IsFull() || (this.ArmyScale < this.NormalArmyScale))))
                                                {
                                                    //goto Label_05AB;
                                                    if (this.BelongedSection.AIDetail.ValueOffensiveCampaign || GameObject.Chance(20))
                                                    {
                                                        num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize) * 30
                                                            - (this.ArmyScale - node2.A.ArmyScale) * 2;
                                                        if ((num4 < 0) && GameObject.Chance(Math.Abs((int)(num4 / 10))))
                                                        {
                                                            list2.Add(node2);
                                                        }
                                                    }
                                                    break;
                                                }
                                                legion = this.BelongedFaction.GetLegion(node2.A);
                                                if ((legion == null) || (legion.Troops.Count < 30))
                                                {
                                                    list2.Add(node2);
                                                }
                                                //
                                                continue;

                                            case SectionOrientationKind.军区:
                                                continue;

                                            case SectionOrientationKind.势力:
                                                if (this.BelongedSection.OrientationFaction == node2.A.BelongedFaction)
                                                {
                                                    list2.Add(node2);
                                                }
                                                continue;

                                            case SectionOrientationKind.州域:
                                                if (this.BelongedSection.OrientationState == node2.A.LocationState)
                                                {
                                                    list2.Add(node2);
                                                }
                                                continue;

                                            case SectionOrientationKind.建筑:
                                                if (this.BelongedSection.OrientationArchitecture == node2.A)
                                                {
                                                    list2.Add(node2);
                                                }
                                                continue;
                                        }// end switch
                                    }
                                    else continue;
                                }// end else
                                //continue;
                                /*
                            Label_05AB:
                                if (this.BelongedSection.AIDetail.ValueOffensiveCampaign || GameObject.Chance(20))
                                {
                                    num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize);
                                    if ((num4 < 0) && GameObject.Chance(Math.Abs((int) (num4 / 10))))
                                    {
                                        list2.Add(node2);
                                    }
                                }
                                 */
                                //Label_0650:;
                            }
                            double maxValue = double.MaxValue;
                            LinkNode node3 = null;
                            //after first consideration, decide last target by determining base distances, and choose the minimum one
                            //this list is for empty bases
                            if (list.Count > 0)
                            {
                                foreach (LinkNode node2 in list)
                                {
                                    //1/(2*number of bases in consideration) chance to throw that node away
                                    /*if (GameObject.Random(list.Count * 2) == 0)
                                    {
                                        continue;
                                    }*/
                                    distance = node2.Distance;
                                    if (node2.A.LocationState.LinkedRegion.ID != this.LocationState.LinkedRegion.ID)
                                    {
                                        if (this.BelongedFaction.Leader.StrategyTendency != PersonStrategyTendency.统一全国)
                                        {
                                            continue;
                                        }
                                        distance *= 2.0;
                                    }
                                    else if (node2.A.LocationState.ID != this.LocationState.ID)
                                    {
                                        if (this.BelongedFaction.Leader.StrategyTendency == PersonStrategyTendency.统一地区)
                                        {
                                            distance *= 2.0;
                                        }
                                        else if (this.BelongedFaction.Leader.StrategyTendency != PersonStrategyTendency.统一全国)
                                        {
                                            continue;
                                        }
                                    }
                                    if (node2.A.IsImportant)
                                    {
                                        distance /= 2.0;
                                    }
                                    //add variation to AI attack (and less prone to cases where the selected base is prevented from attacking
                                    //because of conditions below
                                    distance *= 1 + (GameObject.Random(100) / 100.0 * 0.4 + 0.8);
                                    if (distance < maxValue)
                                    {
                                        maxValue = distance;
                                        node3 = node2;
                                    }
                                }
                            }
                            double num7 = double.MaxValue;
                            LinkNode node4 = null;
                            //this list is for occupied bases
                            if (list2.Count > 0)
                            {
                                foreach (LinkNode node2 in list2)
                                {
                                    //1/(2*number of bases in consideration) chance to throw that node away
                                    //if there has hostile arch on path, throw that node away
                                    if (/*(GameObject.Random(list2.Count * 2) != 0) && */!this.HasHostileArchitectureOnPath(node2))
                                    {
                                        distance = node2.Distance;
                                        num4 = 0;
                                        if (node2.A.BelongedFaction != null)
                                        {
                                            num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize);
                                        }
                                        if (num4 < 0)
                                        {
                                            distance /= (double)((((float)Math.Abs(num4)) / 200f) + 1f);
                                        }
                                        if (node2.A.IsImportant)
                                        {
                                            distance /= 2.0;
                                        }
                                        //make AI more aggressive against player
                                        /*if (base.Scenario.IsPlayer(node2.A.BelongedFaction))
                                        {
                                            distance /= 2.0;
                                        }*/
                                        distance *= 1 + (GameObject.Random(100) / 100.0 * 0.4 + 0.8);
                                        if (distance < num7)
                                        {
                                            num7 = distance;
                                            node4 = node2;
                                        }
                                    }
                                }
                            }
                            //finally, choose the best target from both lists
                            if (maxValue <= num7)
                            {
                                node = node3;
                            }
                            else
                            {
                                node = node4;
                            }
                        }
                        //if a target is found, consider starting an offensive
                        if (node != null)
                        {
                            Architecture closer = null;
                            //if there is closer arch and they belonged to same section, move over to that arch
                            if (this.HasCloserOffensiveArchitecture(node, out closer))
                            {
                                if ((((closer != null) && this.AIAllLinkNodes.ContainsKey(closer.ID)) && (closer.BelongedSection == this.BelongedSection))/* && this.BelongedSection.AIDetail.ValueOffensiveCampaign*/)
                                {
                                    this.BuildOffensiveTroop(closer, this.AIAllLinkNodes[closer.ID].Kind, true);
                                }
                                this.PlanArchitecture = null;
                            }
                            else
                            {
                                //if
                                //1. the target is not known nor there is any spy in it, or
                                //2. rand(target domination)^2 < rand(target domination) (prob should be n(n+1)/2n^3, 1.8y to attack on average...), or
                                //3. has enough troop to mount the offensive 
                                //  "enough" == number of troop is great, or has more troop if base is important, has 1.5 times more troop is base is unimportant
                                //then go on with the offensive
                                bool flag3 = this.BelongedFaction.IsArchitectureKnown(node.A);
                                if (!(((!flag3 && !node.A.HasFactionSpy(this.BelongedFaction)) || (GameObject.Random(GameObject.Square(node.A.Domination)) < GameObject.Random(node.A.DominationCeiling))) || this.IsSelfOffensiveArmyEnough(node)))
                                {
                                    this.PlanArchitecture = null;
                                }
                                else
                                {
                                    int num8;
                                    if (node.A.BelongedFaction != null)
                                    {
                                        num2 = 30;
                                    }
                                    else
                                    {
                                        num8 = 0;
                                        foreach (LinkNode node2 in node.A.AIAllLinkNodes.Values)
                                        {
                                            if (node2.Level > 2)
                                            {
                                                break;
                                            }
                                            if (!this.IsFriendly(node2.A.BelongedFaction) && (node2.A.BelongedFaction != null))
                                            {
                                                num8++;
                                            }
                                        }
                                        num2 = 2 + num8;
                                        if (num2 > 6)
                                        {
                                            num2 = 6;
                                        }
                                    }
                                    if (this.TargetingTroopCount(node.A) >= num2)
                                    {
                                        this.PlanArchitecture = null;
                                    }
                                    else
                                    {
                                        Routeway routeway;
                                        float foodRateBySeason;
                                        //if nothing is known about the target and no planned attacks, and
                                        //there are enough food and fund, then get info for that target
                                        if (!flag3 && (this.PlanArchitecture == null))
                                        {
                                            if ((this.PlanArchitecture == null) && this.InformationAvail())
                                            {
                                                routeway = this.GetRouteway(node, true);
                                                if (((routeway != null) && !routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * (4 + ((node.A.AreaCount >= 4) ? 2 : 0))) <= this.Fund))
                                                {
                                                    foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                                                    if (((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnoughForOffensive(node, routeway))
                                                    {
                                                        this.PlanArchitecture = node.A;
                                                        Person firstHalfPerson = this.GetFirstHalfPerson("InformationAbility");
                                                        if (firstHalfPerson != null)
                                                        {
                                                            firstHalfPerson.CurrentInformationKind = this.GetFirstHalfInformationKind();
                                                            if (firstHalfPerson.CurrentInformationKind != null)
                                                            {
                                                                firstHalfPerson.GoForInformation(base.Scenario.GetClosestPoint(node.A.ArchitectureArea, this.Position));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.PlanArchitecture = null;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //if routeway to the target does not exist or bypasses hostile archs, forget about the target
                                            //else, if food is not enough, put into plan
                                            //else, wait for enough length of routeway has been built, if no more waiting, really start offensive
                                            routeway = this.GetRouteway(node, true);
                                            if (routeway == null)
                                            {
                                                this.PlanArchitecture = null;
                                            }
                                            else if (routeway.ByPassHostileArchitecture)
                                            {
                                                this.PlanArchitecture = null;
                                            }
                                            else if ((routeway.LastPoint.BuildFundCost * (4 + ((node.A.AreaCount >= 4) ? 2 : 0))) > this.Fund)
                                            {
                                                routeway.Building = false;
                                                this.PlanArchitecture = node.A;
                                            }
                                            else
                                            {
                                                foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                                                if (!(((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnoughForOffensive(node, routeway)))
                                                {
                                                    routeway.Building = false;
                                                    this.PlanArchitecture = node.A;
                                                }
                                                else if ((routeway.LastPoint.ConsumptionRate >= 0.1f) && (((int)(routeway.Length * (routeway.LastPoint.ConsumptionRate + 0.2f))) > routeway.LastActivePointIndex))
                                                {
                                                    routeway.Building = true;
                                                    this.PlanArchitecture = node.A;
                                                }
                                                else
                                                {
                                                    if (!routeway.IsActive)
                                                    {
                                                        routeway.Building = true;
                                                    }
                                                    num8 = 0;
                                                    while (num8 < num2)
                                                    {
                                                        if (this.BuildOffensiveTroop(node.A, node.Kind, true) == null)
                                                        {
                                                            break;
                                                        }
                                                        num8++;
                                                        if (!(this.HasOffensiveMilitary() && this.HasPerson()))
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.PlanArchitecture = null;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public int OffensiveMilitaryCount()
        {
            int num = 0;
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military))
                {
                    num++;
                }
            }
            return num;
        }



        public bool PersonConveneAvail()
        {
            int num = 0;
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        num += architecture.Persons.Count;
                    }
                }
            }
            return (num > 0);
        }

        public bool PersonHireAvail()
        {
            return ((!this.HasManualHire  && (this.NoFactionPersonCount > 0)) && (this.Fund >= this.HirePersonFund));
        }

        public bool PersonStudySkillAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableSkill)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonStudyStuntAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableStunt)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonStudyTitleAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableTitle)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonTransferAvail()
        {
            return ((this.BelongedFaction != null) && ((this.Persons.Count > 0) && (this.BelongedFaction.ArchitectureCount > 1)));
        }

        public void PlayerAIHire()
        {
            this.AIAutoHire();
        }

        public void PlayerAIReward()
        {
            this.AIAutoReward();
        }

        public void PlayerAISearch()
        {
            this.AIAutoSearch();
        }

        public void PlayerAIWork()
        {
            this.AIWork(true);
        }

        public void PlayerAutoAI()
        {
            if (this.AutoHiring)
            {
                this.PlayerAIHire();
            }
            if (this.AutoRewarding)
            {
                this.PlayerAIReward();
            }
            if (this.AutoWorking)
            {
                this.PlayerAIWork();
            }
            if (this.AutoSearching)
            {
                this.PlayerAISearch();
            }
        }

        private void PopulationEscapeEvent()
        {
            if ((((!this.DayAvoidPopulationEscape && this.Kind.HasPopulation) && ((this.Domination < this.DominationCeiling) && (this.RecentlyAttacked > 0))) && ((this.Population > (0x3e8 * this.AreaCount)) && (this.Morale < this.MoraleCeiling))) && (GameObject.Random(((int) Math.Pow((double) (this.Domination + this.Morale), 2.0)) + 0x3e8) < GameObject.Random(0x3e8)))
            {
                int num = 0;
                int maxValue = this.Population / 100;
                foreach (Architecture architecture in this.GetAILinks().GetRandomList())
                {
                    if (architecture.Kind.HasPopulation)
                    {
                        architecture.AddPopulationPack((int) (base.Scenario.GetDistance(this.ArchitectureArea, architecture.ArchitectureArea) / 2.0), 1 + GameObject.Random(maxValue));
                        num++;
                    }
                    if (num >= 100)
                    {
                        break;
                    }
                }
                if (num > 0)
                {
                    int decrement = maxValue * num;
                    this.DecreasePopulation(decrement);
					ExtensionInterface.call("PopulationEscape", new Object[] { this.Scenario, this, decrement });
                    if (this.OnPopulationEscape != null)
                    {
                        this.OnPopulationEscape(this, decrement);
                    }
                }
            }
        }

        public string PopulationInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0x186a0);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0xc350);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0x2710);

                case InformationLevel.全:
                    return this.Population.ToString();
            }
            return "----";
        }

        public string MilitaryPopulationInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.MilitaryPopulation, 0x186a0);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.MilitaryPopulation, 0xc350);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.MilitaryPopulation, 0x2710);

                case InformationLevel.全:
                    return this.MilitaryPopulation.ToString();
            }
            return "----";
        }


        public void PopulationPacksDayEvent()
        {
            for (int i = this.PopulationPacks.Count - 1; i >= 0; i--)
            {
                PopulationPack local1 = this.PopulationPacks[i];
                local1.Days--;
                if (this.PopulationPacks[i].Days <= 0)
                {
                    this.ReceivePopulation(this.PopulationPacks[i].Population);
                    this.PopulationPacks.RemoveAt(i);
                }
            }
        }

        public void PostCreateTroop(Troop troop, bool hand)
        {
            if ((this.BelongedFaction != null) && this.HasSpy)
            {
                this.AddMessageToTodayNewTroopSpyMessage(troop, hand);
            }
        }

        private void PrepareAI()
        {
            this.TotalHostileForce = 0;
            this.TotalFriendlyForce = 0;
            TroopList hostileTroopsInView = this.GetHostileTroopsInView();
            foreach (Troop troop in hostileTroopsInView)
            {
                this.TotalHostileForce += troop.FightingForce;
            }
            if (this.DefensiveLegion == null)
            {
                TroopList friendlyTroopsInView = this.GetFriendlyTroopsInView();
                foreach (Troop troop in friendlyTroopsInView)
                {
                    this.TotalFriendlyForce += troop.FightingForce;
                }
            }
            else
            {
                foreach (Troop i in this.DefensiveLegion.Troops)
                {
                    this.TotalFriendlyForce += i.FightingForce;
                }
            }
        }

        public void PurifyFacilityInfluences()
        {
            foreach (Facility facility in this.Facilities)
            {
                if (facility.MaintenanceCost > 0)
                {
                    facility.Influences.PurifyInfluence(this, Applier.Facility, facility.ID);
                }
            }
        }

        private void QuickSortArchitecturesDistance(ArchitectureList List, int begin, int end)
        {
            if (begin < end)
            {
                int num = this.QuickSortPartitionArchitecturesDistance(List, begin, end);
                if (begin < (num - 1))
                {
                    this.QuickSortArchitecturesDistance(List, begin, num - 1);
                }
                if ((num + 1) < end)
                {
                    this.QuickSortArchitecturesDistance(List, num + 1, end);
                }
            }
        }

        private int QuickSortPartitionArchitecturesDistance(ArchitectureList List, int begin, int end)
        {
            Architecture architecture = List[begin] as Architecture;
            int simpleDistance = base.Scenario.GetSimpleDistance(architecture.Position, this.Position);
            int num2 = begin;
            while (begin < end)
            {
                int num3 = base.Scenario.GetSimpleDistance((List[end] as Architecture).Position, this.Position);
                while ((begin < end) && (num3 >= simpleDistance))
                {
                    end--;
                    num3 = base.Scenario.GetSimpleDistance((List[end] as Architecture).Position, this.Position);
                }
                if (begin >= end)
                {
                    return begin;
                }
                this.QuickSortSwapArchitectureDistance(List, begin, end);
                begin++;
                for (num3 = base.Scenario.GetSimpleDistance((List[begin] as Architecture).Position, this.Position); (begin < end) && (num3 <= simpleDistance); num3 = base.Scenario.GetSimpleDistance((List[begin] as Architecture).Position, this.Position))
                {
                    begin++;
                }
                if (begin >= end)
                {
                    return begin;
                }
                this.QuickSortSwapArchitectureDistance(List, begin, end);
                end--;
            }
            return begin;
        }

        private void QuickSortSwapArchitectureDistance(ArchitectureList List, int i, int j)
        {
            GameObject obj2 = List[i];
            List[i] = List[j];
            List[j] = obj2;
        }

        public ArchitectureDamage ReceiveAttackDamage(ArchitectureDamage receivedDamage)
        {
            if (receivedDamage.Damage > 0)
            {
                int maxValue = 2 + (receivedDamage.Damage / 5);
                this.DecreaseAgriculture(GameObject.Random(maxValue));
                this.DecreaseCommerce(GameObject.Random(maxValue));
                this.DecreaseTechnology(GameObject.Random(maxValue));
                this.DecreaseMorale(GameObject.Random(maxValue));
				ExtensionInterface.call("ArchitectureReceiveDamage", new Object[] { this.Scenario, this, receivedDamage });
            }
            return receivedDamage;
        }

        private void ReceivePopulation(int quantity)
        {
            int population = this.Population;
            quantity = this.IncreasePopulation(quantity);
            if (quantity > 0)
            {
                if (this.BelongedFaction != null)
                {
                    this.Domination = (int) (((long) this.Domination * population) / this.Population);
                    this.Morale = (int) (((long) this.Morale * population) / this.Population);
                }
                if (this.OnPopulationEnter != null)
                {
                    this.OnPopulationEnter(this, quantity);
                }
				ExtensionInterface.call("ReceivePopulation", new Object[] { this.Scenario, this, quantity });
            }
        }

        public bool RecruitmentAvail()
        {
            if (this.HasPerson())
            {
                if (this.youzainan)
                {
                    return false;
                }
                if (!this.Kind.HasPopulation||!this.Kind.HasMorale)
                {
                    return false;
                }
                if (GlobalVariables.PopulationRecruitmentLimit && (this.ArmyQuantity > this.Population))
                {
                    return false;
                }
                if (this.Population <= 0||this.MilitaryPopulation<=0)
                {
                    return false;
                }
                if (this.Domination < Parameters.RecruitmentDomination)
                {
                    return false;
                }
                if (this.Morale < Parameters.RecruitmentMorale)
                {
                    return false;
                }
                foreach (Military military in this.Militaries)
                {
                    if ((military.Quantity < military.Kind.MaxScale) && (military.InjuryQuantity == 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int crlm_recurse_level = 0;
        private bool CanRecruitLowerMilitary_r(MilitaryKind mk)
        {
            MilitaryKind current;
            Dictionary<int, MilitaryKind>.ValueCollection.Enumerator enumerator;
            using (enumerator = this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current == mk)
                    {
                        return true;
                    }
                }
            }
            using (enumerator = this.PrivateMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current == mk)
                    {
                        return true;
                    }
                }
            }
            foreach (MilitaryKind i in base.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values){
                if (i.LevelUpKindID == mk.ID)
                {
                    crlm_recurse_level++;
                    if (crlm_recurse_level > 50)
                    {
                        return false;
                    }
                    if (CanRecruitLowerMilitary_r(i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanRecruitMilitary(MilitaryKind mk)
        {
            crlm_recurse_level = 0;
            return CanRecruitLowerMilitary_r(mk);
        }

        private void RecruitmentMilitary(Military military)
        {
            if ((((this.MilitaryPopulation != 0) && (this.Population != 0) && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population))) && ((this.Fund >= (Parameters.RecruitmentFundCost * this.AreaCount * (this.CanRecruitMilitary(military.Kind) ? 1 : 10))) && (this.Domination >= Parameters.RecruitmentDomination))) && (((this.Morale >= Parameters.RecruitmentMorale) && ((military.RecruitmentPerson != null) && (military.RecruitmentPerson.BelongedFaction != null))) && (military.Quantity < military.Kind.MaxScale)))
            {
                int randomValue = StaticMethods.GetRandomValue((int)((military.RecruitmentPerson.RecruitmentAbility * military.Kind.MinScale) * Parameters.RecruitmentRate), 0x7d0);
                int populationDecrement;

                if ((randomValue + military.Quantity) > military.Kind.MaxScale)
                {
                    randomValue = military.Kind.MaxScale - military.Quantity;
                }
                if ((randomValue * military.Kind.PointsPerSoldier) > military.BelongedFaction.TechniquePoint && military.Kind.PointsPerSoldier != 0)
                {
                    if (!(((this.BelongedSection == null) || (this.BelongedSection.AIDetail == null)) || this.BelongedSection.AIDetail.AutoRun))
                    {
                        military.BelongedFaction.DepositTechniquePointForTechnique(randomValue * military.Kind.PointsPerSoldier);
                    }
                    randomValue = military.BelongedFaction.TechniquePoint / military.Kind.PointsPerSoldier;
                }
                populationDecrement = randomValue;
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    randomValue = (int)(randomValue * Parameters.AIRecruitmentSpeedRate);
                }
                if (randomValue > 0)
                {
                    this.DecreaseFund(Parameters.RecruitmentFundCost * this.AreaCount * (this.CanRecruitMilitary(military.Kind) ? 1 : 10));
                    if (populationDecrement > this.MilitaryPopulation)
                    {
                        populationDecrement = this.MilitaryPopulation;
                        randomValue = populationDecrement;
                    }
                    if (populationDecrement > this.Population)
                    {
                        populationDecrement = this.Population;
                        randomValue = populationDecrement;
                    }
                    this.DecreaseMilitaryPopulation(populationDecrement);
                    this.DecreasePopulation(populationDecrement);

                    int scales = military.Scales;
                    military.IncreaseQuantity(randomValue, this.MoraleOfRecruitment, this.CombativityOfRecruitment, 0, 0);
                    if (this.HasSpy && ((military.Scales / 10) > (scales / 10)))
                    {
                        this.AddMessageToTodayMilitaryScaleSpyMessage(military);
                    }
                    if (this.Population < this.RecruitmentPopulationBoundary)
                    {
                        this.DecreaseDomination(GameObject.Random(6));
                        this.DecreaseMorale(GameObject.Random(6) * 2);
                    }
                    else
                    {
                        this.DecreaseDomination(GameObject.Random(2));
                        this.DecreaseMorale(GameObject.Random(2) * 2);
                    }
                    this.BelongedFaction.DecreaseTechniquePoint(randomValue * military.Kind.PointsPerSoldier);
                    int increment = StaticMethods.GetRandomValue(randomValue * 10, military.Kind.MinScale);
                    if (increment > 0)
                    {
                        military.RecruitmentPerson.AddRecruitmentExperience(increment);
                        military.RecruitmentPerson.AddCommandExperience(increment);
                        military.RecruitmentPerson.AddGlamourExperience(increment);
                        military.RecruitmentPerson.IncreaseReputation(increment * 4);
                        military.RecruitmentPerson.BelongedFaction.IncreaseReputation(increment * 2);
                        military.RecruitmentPerson.BelongedFaction.IncreaseTechniquePoint(increment * 100);
                    }
                }
            }
            else
            {
                if (military.RecruitmentPerson != null)
                {
                    military.StopRecruitment();
                }
            }
        }

        public void RecruitmentMilitary(Military military, float scale)
        {
            if ((((this.MilitaryPopulation != 0) &&(this.Population != 0) && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population))) && ((this.Domination >= Parameters.RecruitmentDomination) && (this.Morale >= Parameters.RecruitmentMorale))) && (military.Quantity < military.Kind.MaxScale))
            {
                int decrement = (int) (military.Kind.MinScale * scale);
                int populationDecrement;
                if ((decrement + military.Quantity) > military.Kind.MaxScale)
                {
                    decrement = military.Kind.MaxScale - military.Quantity;
                }
                if ((decrement * military.Kind.PointsPerSoldier) > military.BelongedFaction.TechniquePoint)
                {
                    if (!(((this.BelongedSection == null) || (this.BelongedSection.AIDetail == null)) || this.BelongedSection.AIDetail.AutoRun))
                    {
                        military.BelongedFaction.DepositTechniquePointForTechnique(decrement * military.Kind.PointsPerSoldier);
                    }
                    decrement = military.BelongedFaction.TechniquePoint / military.Kind.PointsPerSoldier;
                }
                populationDecrement = decrement;
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    decrement = (int)(decrement * Parameters.AIRecruitmentSpeedRate);
                }
                if (decrement > 0)
                {
                    if (populationDecrement > this.MilitaryPopulation)
                    {
                        populationDecrement = this.MilitaryPopulation;
                        decrement = populationDecrement;
                    }
                    if (populationDecrement > this.Population)
                    {
                        populationDecrement = this.Population;
                        decrement = populationDecrement;
                    }
                    this.DecreaseMilitaryPopulation(populationDecrement);
                    this.DecreasePopulation(populationDecrement);
                    int scales = military.Scales;
                    military.IncreaseQuantity(decrement, this.MoraleOfRecruitment, this.CombativityOfRecruitment, 0, 0);
                    if (this.HasSpy && ((military.Scales / 10) > (scales / 10)))
                    {
                        this.AddMessageToTodayMilitaryScaleSpyMessage(military);
                    }
                    if (this.Population < this.RecruitmentPopulationBoundary)
                    {
                        this.DecreaseDomination(GameObject.Random(6));
                        this.DecreaseMorale(GameObject.Random(6) * 2);
                    }
                    else
                    {
                        this.DecreaseDomination(GameObject.Random(2));
                        this.DecreaseMorale(GameObject.Random(2) * 2);
                    }
                    this.BelongedFaction.DecreaseTechniquePoint(decrement * military.Kind.PointsPerSoldier);
                    int randomValue = StaticMethods.GetRandomValue(decrement * 10, military.Kind.MinScale);
                    if (randomValue > 0)
                    {
                        military.BelongedFaction.IncreaseReputation(randomValue * 2);
                        military.BelongedFaction.IncreaseTechniquePoint(randomValue * 100);
                    }
                }
            }
        }

        public bool RedeemAvail()
        {
            if (this.FactionHasSelfCaptive())
            {
                foreach (Captive captive in this.BelongedFaction.SelfCaptives)
                {
                    if ((captive.RansomArriveDays == 0) && (captive.Ransom <= this.Fund))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RefreshViewArea()
        {
            if (!base.Scenario.Preparing)
            {
                foreach (Point point in this.ViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        base.Scenario.MapTileData[point.X, point.Y].RemoveHighViewingArchitecture(this);
                    }
                }
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        base.Scenario.MapTileData[point.X, point.Y].RemoveViewingArchitecture(this);
                    }
                }
            }
            this.ViewArea = null;
            this.LongViewArea = null;
            foreach (Point point in this.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddHighViewingArchitecture(this);
                }
            }
            foreach (Point point in this.LongViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddViewingArchitecture(this);
                }
            }
        }

        public bool RegionCoreEffectAvail()
        {
            return (this.Kind.HasTechnology && (this.Technology >= ((int) (this.TechnologyCeiling * 0.8))));
        }

        public bool RegroupSectionAvail()
        {
            return (this.BelongedFaction.SectionCount > 0);
        }

        private void ReleaseAllCaptive()
        {
            if (this.HasCaptive())
            {
                PersonList persons = new PersonList();
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (((captive.CaptivePerson != null) && (captive.CaptiveFaction != null)) && (captive.CaptiveFaction.Capital != null))
                    {
                        Architecture moveTo = captive.CaptiveFaction.Capital;
                        persons.Add(captive.CaptivePerson);
                        Person p = captive.CaptivePerson;
                        captive.CaptivePerson.BelongedCaptive = null;
                        p.Status = PersonStatus.Normal;
                        p.MoveToArchitecture(moveTo);
                    }
                }
                if ((persons.Count > 0) && (this.OnReleaseCaptiveAfterOccupied != null))
                {
                    this.OnReleaseCaptiveAfterOccupied(this, persons);
                }
            }
        }

        public bool ReleaseCaptiveAvail()
        {
            return (this.BelongedFaction.CaptiveCount > 0);
        }

        public void RemoveBaseSupplyingArchitecture()
        {
            foreach (Point point in this.BaseFoodSurplyArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].RemoveSupplyingArchitecture(this);
                }
            }
        }

        public void RemoveInactiveRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                if (!(routeway.Building || (routeway.LastActivePointIndex >= 0)))
                {
                    base.Scenario.RemoveRouteway(routeway);
                }
            }
        }

        public void RemoveMilitary(Military military)
        {
            this.Militaries.Remove(military);
            military.StopRecruitment();
            military.BelongedArchitecture = null;
        }

        internal void RemovePopulationPack(PopulationPack pp)
        {
            this.PopulationPacks.Remove(pp);
        }

        internal void RemoveSpyPack(SpyPack sp)
        {
            this.SpyPacks.Remove(sp);
        }

        private void ResetAuto()
        {
            this.AutoHiring = false;
            this.AutoRewarding = false;
            this.AutoWorking = false;
            this.AutoSearching = false;
        }

        private void ResetDayInfluence()
        {
            this.DayRateIncrementOfInternal = 0f;
            this.DayLearnTitleDay = Parameters.LearnTitleDays;
            this.DayLocationLoyaltyNoChange = false;
            this.DayAvoidInfluenceByBattle = false;
            this.DayAvoidPopulationEscape = false;
            this.DayAvoidInternalDecrementOnBattle = false;
            if (this.RecentlyAttacked > 0)
            {
                this.RecentlyAttacked--;
            }
            if (this.RecentlyBreaked > 0)
            {
                this.RecentlyBreaked--;
            }
        }

        public bool ResetDiplomaticRelationAvail()
        {
            if (this.BelongedFaction == null)
            {
                return false;
            }
            return (this.HasFriendlyDiplomaticRelation && (this.BelongedFaction.TroopCount == 0));
        }

        public void ResetFaction(Faction faction)
        {
			Faction oldFaction = this.BelongedFaction;
            this.ResetAuto();
            if ((faction != null) && base.Scenario.IsPlayer(faction))
            {
                this.AutoHiring = true;
                this.AutoRewarding = true;

            }
            if (this.BelongedFaction != null && this.BelongedFaction != faction)
            {
                this.ClearFundPacks();
                this.ClearRouteways();
                this.ReleaseAllCaptive();
                this.PurifyFactionInfluences();
                if (this.BelongedSection != null)
                {
                    this.BelongedSection.RemoveArchitecture(this);
                }
                this.DefensiveLegion = null;
                if (this == this.BelongedFaction.Capital)
                {
                    Person leader = this.BelongedFaction.Leader;
                    while (this.Persons.Count > 0)
                    {
                        Person person2 = this.Persons[0] as Person;
                        person2.Status = PersonStatus.NoFaction;
                        person2.LocationArchitecture = this;
                    }
                    //this.Persons.Clear();
                    while (this.MovingPersons.Count > 0)
                    {
                        Person person2 = this.MovingPersons[0] as Person;
                        person2.OutsideTask = OutsideTaskKind.无;
                        person2.TaskDays = 0;
                        person2.Status = PersonStatus.NoFaction;

                        person2.LocationArchitecture = this;
                        person2.TargetArchitecture = null;

                    }
                    
                    //if ((leader.LocationTroop == null) || leader.IsCaptive)
                    {
                        TroopList list = new TroopList();
                        foreach (Troop troop in this.BelongedFaction.Troops)
                        {
                            list.Add(troop);
                        }
                        foreach (Troop troop in list)
                        {
                            troop.FactionDestroy();
                        }
                        if (faction != null)
                        {
                            faction.CheckLeaderDeath(leader);
                        }
                        this.BelongedFaction.Destroy();

                    }
                    this.BelongedFaction.Capital = null;
                }
                else
                {
                    while (this.Persons.Count > 0)
                    {
                        if ((this.Persons[0] as Person).LocationArchitecture != null)
                        {
                            (this.Persons[0] as Person).MoveToArchitecture(this.BelongedFaction.Capital);
                        }
                    }
                    while (this.MovingPersons.Count > 0)
                    {
                        if ((this.MovingPersons[0] as Person).LocationArchitecture != null)
                        {
                            (this.MovingPersons[0] as Person).MoveToArchitecture(this.BelongedFaction.Capital);
                        }
                    }
                }
                if (this.BelongedFaction != null)
                {
                    this.BelongedFaction.RemoveArchitectureMilitaries(this);
                    this.BelongedFaction.RemoveArchitectureKnownData(this);
                    this.BelongedFaction.RemoveArchitecture(this);
                }
                if (faction != null)
                {
                    faction.AddArchitecture(this);
                    this.ApplyFactionInfluences();
                    faction.AddArchitectureMilitaries(this);
                }
                else
                {
                    this.BelongedFaction = null;
                }
            }
            else if (faction != null)
            {
                faction.AddArchitecture(this);
                this.ApplyFactionInfluences();
                faction.AddArchitectureMilitaries(this);
            }

            if (faction != null)
            {
                //this.jianzhuqizi.qizidezi.Text = faction.ToString().Substring(0, 1);
            }

            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                architecture.RefreshViewArea();
            }
            foreach (Troop troop in base.Scenario.Troops)
            {
                troop.RefreshViewArchitectureRelatedArea();
            }
            foreach (LinkNode i in this.AIAllLinkNodes.Values)
            {
                i.A.CheckIsFrontLine();
            }
            this.CheckIsFrontLine();
			ExtensionInterface.call("ArchitectureResetFaction", new Object[] { this.Scenario, this, oldFaction });
        }

        private void ReSortAllWeighingList(PersonList zhenzaiPersons, PersonList agriculturePersons, PersonList commercePersons,
            PersonList technologyPersons, PersonList dominationPersons, PersonList moralePersons, PersonList endurancePersons,
            PersonList recruitmentPersons, PersonList trainingPersons, MilitaryList weighingMilitaries)
        {
            zhenzaiPersons.Clear();
            if (this.kezhenzai())
            {
                foreach (Person person in this.Persons)
                {
                    zhenzaiPersons.Add(person);
                }
                zhenzaiPersons.IsNumber = true;
                zhenzaiPersons.PropertyName = "zhenzaiWeighing";
                zhenzaiPersons.ReSort();
            }
            agriculturePersons.Clear();
            if (this.Kind.HasAgriculture)
            {
                foreach (Person person in this.Persons)
                {
                    agriculturePersons.Add(person);
                }
                agriculturePersons.IsNumber = true;
                agriculturePersons.PropertyName = "AgricultureWeighing";
                agriculturePersons.ReSort();
            }
            commercePersons.Clear();
            if (this.Kind.HasCommerce)
            {
                foreach (Person person in this.Persons)
                {
                    commercePersons.Add(person);
                }
                commercePersons.IsNumber = true;
                commercePersons.PropertyName = "CommerceWeighing";
                commercePersons.ReSort();
            }
            technologyPersons.Clear();
            if (this.Kind.HasTechnology)
            {
                foreach (Person person in this.Persons)
                {
                    technologyPersons.Add(person);
                }
                technologyPersons.IsNumber = true;
                technologyPersons.PropertyName = "TechnologyWeighing";
                technologyPersons.ReSort();
            }
            dominationPersons.Clear();
            if (this.Kind.HasDomination)
            {
                foreach (Person person in this.Persons)
                {
                    dominationPersons.Add(person);
                }
                dominationPersons.IsNumber = true;
                dominationPersons.PropertyName = "DominationWeighing";
                dominationPersons.ReSort();
            }
            moralePersons.Clear();
            if (this.Kind.HasMorale)
            {
                foreach (Person person in this.Persons)
                {
                    moralePersons.Add(person);
                }
                moralePersons.IsNumber = true;
                moralePersons.PropertyName = "MoraleWeighing";
                moralePersons.ReSort();
            }
            endurancePersons.Clear();
            if (this.Kind.HasEndurance)
            {
                foreach (Person person in this.Persons)
                {
                    endurancePersons.Add(person);
                }
                endurancePersons.IsNumber = true;
                endurancePersons.PropertyName = "EnduranceWeighing";
                endurancePersons.ReSort();
            }
            trainingPersons.Clear();
            foreach (Person person in this.Persons)
            {
                trainingPersons.Add(person);
            }
            trainingPersons.IsNumber = true;
            trainingPersons.PropertyName = "TrainingWeighing";
            trainingPersons.ReSort();
            recruitmentPersons.Clear();
            foreach (Person person in this.Persons)
            {
                recruitmentPersons.Add(person);
            }
            recruitmentPersons.IsNumber = true;
            recruitmentPersons.PropertyName = "RecruitmentWeighing";
            recruitmentPersons.ReSort();
            weighingMilitaries.Clear();
            foreach (Military military in this.Militaries)
            {
                weighingMilitaries.Add(military);
            }
            weighingMilitaries.IsNumber = true;
            weighingMilitaries.PropertyName = "Weighing";
            weighingMilitaries.ReSort();
        }

        public void RewardAll()
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (!architecture.HasPerson())
                {
                    continue;
                }
                int rewardPersonMaxCount = architecture.RewardPersonMaxCount;
                if (rewardPersonMaxCount > 0)
                {
                    GameObjectList list = architecture.Persons.GetList();
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Loyalty";
                        list.SmallToBig = true;
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    int num2 = 0;
                    foreach (Person person in list)
                    {
                        if ((!person.RewardFinished && (person.Loyalty < 100)) && (person != person.BelongedFaction.Leader))
                        {
                            architecture.RewardPerson(person);
                            num2++;
                        }
                        if (num2 >= rewardPersonMaxCount)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public bool RewardAllAvail()
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture.RewardPersonAvail())
                {
                    return true;
                }
            }
            return false;
        }

        public void RewardByPersonList(GameObjectList personlist)
        {
            foreach (Person person in personlist)
            {
                this.RewardPerson(person);
            }
            if (this.OnRewardPersons != null)
            {
                this.OnRewardPersons(this, personlist);
            }
        }

        public bool RewardPerson(Person p)
        {
            if (this.Fund < this.RewardPersonFund)
            {
                return false;
            }
            p.RewardFinished = true;
            this.DecreaseFund(this.RewardPersonFund);
            int idealOffset = Person.GetIdealOffset(p, this.BelongedFaction.Leader);
            p.IncreaseLoyalty((15 - (idealOffset / 5)) + 4 - (int) p.PersonalLoyalty);
			ExtensionInterface.call("RewardPerson", new Object[] { this.Scenario, this, p });
            return true;
        }

        public bool RewardPersonAvail()
        {
            return ((this.GetRewardPersons().Count > 0) && (this.Fund >= this.RewardPersonFund));
        }

        public void RewardPersonsUnderLoyalty(int loyalty)
        {
            foreach (Person person in this.Persons)
            {
                if (((!person.RewardFinished && (person.Loyalty < loyalty)) && (person != this.BelongedFaction.Leader)) && !this.RewardPerson(person))
                {
                    break;
                }
            }
        }

        public bool RoutewayAvail()
        {

            foreach (Point point in this.GetRoutewayStartArea().Area)
            {
                if (this.IsRoutewayPossible(point))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CaiyongLiangdaoXitong()
        {
            if (GlobalVariables.LiangdaoXitong == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        internal string SaveFundPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (FundPack pack in this.FundPacks)
            {
                builder.Append(string.Concat(new object[] { pack.Fund, " ", pack.Days, " " }));
            }
            return builder.ToString();
        }

        internal string SavePopulationPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (PopulationPack pack in this.PopulationPacks)
            {
                builder.Append(string.Concat(new object[] { pack.Days, " ", pack.Population, " " }));
            }
            return builder.ToString();
        }

        internal string SaveSpyPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SpyPack pack in this.SpyPacks)
            {
                builder.Append(string.Concat(new object[] { pack.SpyPerson.ID, " ", pack.Days, " " }));
            }
            return builder.ToString();
        }

        public bool SearchAvail()
        {
            return this.HasPerson();
        }

        public void SellFood(int spendFood)
        {
            this.DecreaseFood(spendFood);
            this.IncreaseFund(spendFood / Parameters.FoodToFundDivisor);
			ExtensionInterface.call("SellFood", new Object[] { this.Scenario, this });
        }

        public bool SellFoodAvail()
        {
            return ((((this.Commerce >= Parameters.SellFoodCommerce) && ((base.Scenario.Date.Season == GameSeason.冬) || (base.Scenario.Date.Season == GameSeason.春))) && (this.Food > 0)) && (this.Fund < this.FundCeiling));
        }

        public void SetLongViewArea(GameArea area)
        {
            this.longViewArea = area;
        }

        public void SetRecentlyAttacked()
        {
            if (this.RecentlyAttacked <= 0)
            {
				ExtensionInterface.call("ArchitectureBeingAttacked", new Object[] { this.Scenario, this });
                this.JustAttacked = true;
                if (this.BelongedFaction != null)
                {
                    this.BelongedFaction.StopToControl = true;
                }
                if (this.OnBeginRecentlyAttacked != null)
                {
                    this.OnBeginRecentlyAttacked(this);
                }
            }
            this.RecentlyAttacked = 10;
            this.AttackedReminder();
        }

        private bool remindedAboutAttack = false;
        public void AttackedReminder()
        {
            if (!remindedAboutAttack && this.MilitaryCount > 0 && !this.HasOwnFactionTroopsInView())
            {
                if (this.BelongedFaction != null)
                {
                    this.BelongedFaction.StopToControl = true;
                }
                if (this.OnBeginRecentlyAttacked != null)
                {
                    this.OnBeginRecentlyAttacked(this);
                }
                remindedAboutAttack = true;
            }
        }

        public void SetViewArea(GameArea area)
        {
            this.viewArea = area;
        }

        private void Sourrounded()
        {
            if (((this.BelongedFaction != null) && (this.Endurance > 0)) && this.Kind.HasDomination)
            {
                int num = 0;
                foreach (Point point in this.ContactArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (!((troopByPosition == null) || this.IsFriendly(troopByPosition.BelongedFaction)))
                    {
                        num++;
                    }
                }
                if (num > this.AreaCount)
                {
                    int decrement = (num - this.AreaCount) * Parameters.SurroundArchitectureDominationUnit;
                    decrement = this.DecreaseDomination(decrement);
					ExtensionInterface.call("ArchitectureSurrounded", new Object[] { this.Scenario, this });
                    if (decrement > 0)
                    {
                        this.DecrementNumberList.AddNumber(decrement, CombatNumberKind.士气, this.Position);
                    }
                }
            }
        }

        public bool SpyAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.SpyArchitectureFund)) && (this.GetSpyArchitectureArea().Count > 0));
        }

        public void SpyPacksDayEvent()
        {
            this.TodayNewMilitarySpyMessage = null;
            this.TodayNewTroopSpyMessage = null;
            for (int i = this.SpyPacks.Count - 1; i >= 0; i--)
            {
                SpyPack local1 = this.SpyPacks[i];
                local1.Days--;
                if ((this.SpyPacks[i].Days <= 0) || ((this.SpyPacks[i].SpyPerson != null) && (this.SpyPacks[i].SpyPerson.BelongedFaction == this.BelongedFaction)))
                {
                    this.SpyPacks.RemoveAt(i);
                }
            }
        }

        public bool StateAdminEffectAvail()
        {
            return (this.Kind.HasTechnology && (this.Technology >= ((int) (this.TechnologyCeiling * 0.5))));
        }

        private void StopAllWork()
        {
            foreach (Person person in this.Persons)
            {
                person.WorkKind = ArchitectureWorkKind.无;
                person.RecruitmentMilitary = null;
            }
        }

        private void StopCostFundWork()
        {
            foreach (Person person in this.Persons)
            {
                if ((person.WorkKind != ArchitectureWorkKind.无) && (person.WorkKind != ArchitectureWorkKind.训练))
                {
                     person.WorkKind = ArchitectureWorkKind.无;
                     person.RecruitmentMilitary = null;
                }
            }
        }

        private void StrategicCenterEffect()
        {
            if ((this.BelongedFaction != null) && this.IsStrategicCenter)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (troopByPosition != null)
                    {
                        if (this.IsFriendly(troopByPosition.BelongedFaction))
                        {
                            troopByPosition.IncreaseCombativity(5);
                        }
                        else
                        {
                            troopByPosition.DecreaseCombativity(10);
                        }
                    }
                }
                if (base.Scenario.Date.Day == 30)
                {
                    GameObjectList aILinks = this.GetAILinks();
                    aILinks.Add(this);
                    foreach (Architecture architecture in aILinks)
                    {
                        if (this.IsFriendly(architecture.BelongedFaction))
                        {
                            if (architecture.Kind.HasDomination)
                            {
                                int number = architecture.IncreaseDomination(20);
                                if (number > 0)
                                {
                                    architecture.IncrementNumberList.AddNumber(number, CombatNumberKind.士气, architecture.Position);
                                }
                            }
                        }
                        else if (this.IsHostile(architecture.BelongedFaction) && architecture.Kind.HasDomination)
                        {
                            int num2 = architecture.DecreaseDomination(10);
                            if (num2 > 0)
                            {
                                architecture.DecrementNumberList.AddNumber(num2, CombatNumberKind.士气, architecture.Position);
                            }
                        }
                    }
                }
            }
        }

        private int TargetingTroopCount(Architecture a)
        {
            int num = 0;
            foreach (Troop troop in this.BelongedFaction.Troops)
            {
                if (troop.WillArchitecture == a)
                {
                    num++;
                }
            }
            return num;
        }

        public bool TechnologyAvail()
        {
            return (this.Kind.HasTechnology && this.HasPerson());
        }

        public override string ToString()
        {
            return string.Concat(new object[] { base.Name, "  ", this.KindString, "  ", this.FactionString, "  ", this.Persons.Count, "人" });
        }

        public bool TrainingAvail()
        {
            if (this.HasPerson())
            {
                foreach (Military military in this.Militaries)
                {
                    if ((military.Quantity > 0) && ((military.Morale < military.MoraleCeiling) || (military.Combativity < military.CombativityCeiling)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        private void TrainMilitary()  //训练编队
        {
            int meiXunlianHaoDeBianduiShu;
            meiXunlianHaoDeBianduiShu = this.MeiXunlianHaoDeBianduiShu();
            if (meiXunlianHaoDeBianduiShu == 0)
            {
                return;
            }
            int zongXunlianNengli = 0;
            int pingjunXunlianNengli;
            foreach (Person person in this.TrainingWorkingPersons)
            {
                zongXunlianNengli += person.TrainingAbility;
            }
            pingjunXunlianNengli = zongXunlianNengli / meiXunlianHaoDeBianduiShu;

            if (pingjunXunlianNengli > 0)
            {
                int pingjunJinyan = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Morale < military.MoraleCeiling)
                    {
                        int randomValue = StaticMethods.GetRandomValue((int)((pingjunXunlianNengli * this.MultipleOfTraining) * Parameters.TrainingRate), 200 + (10 * (military.Scales + military.InjuryQuantity / military.Kind.MinScale)));
                        if (randomValue > 0)
                        {
                            if (!base.Scenario.IsPlayer(this.BelongedFaction))
                            {
                                randomValue = (int)(randomValue * Parameters.AITrainingSpeedRate);
                            }
                            pingjunJinyan = randomValue / this.TrainingWorkingPersons.Count;
                            List<Person> needRemoval = new List<Person>();
                            foreach (Person person in this.TrainingWorkingPersons)
                            {
                                if (person.BelongedFaction == null)
                                {
                                    needRemoval.Add(person);
                                }
                                else
                                {
                                    //person.AddTrainingExperience(pingjunJinyan * 2);
                                    person.AddCommandExperience(pingjunJinyan * 2);
                                    person.IncreaseReputation(pingjunJinyan * 3);
                                    person.BelongedFaction.IncreaseReputation(pingjunJinyan * 2);
                                    person.BelongedFaction.IncreaseTechniquePoint(pingjunJinyan * 50);
                                }
                            }
                            foreach (Person p in needRemoval){
                                this.TrainingWorkingPersons.Remove(p);
                            }
                            military.IncreaseMorale(randomValue);
                        }
                    }
                    if (military != null && military.Combativity < military.CombativityCeiling && this.TrainingWorkingPersons.Count > 0)
                    {
                        int increment = StaticMethods.GetRandomValue((int)((pingjunXunlianNengli * this.MultipleOfTraining) * Parameters.TrainingRate), 50 + (5 * (military.Scales + military.InjuryQuantity / military.Kind.MinScale)));
                        if (increment > 0)
                        {
                            if (!base.Scenario.IsPlayer(this.BelongedFaction))
                            {
                                increment = (int)(increment * Parameters.AITrainingSpeedRate);
                            }
                            List<Person> needRemoval = new List<Person>();
                            pingjunJinyan = increment / this.TrainingWorkingPersons.Count;
                            foreach (Person person in this.TrainingWorkingPersons)
                            {
                                if (person.BelongedFaction == null)
                                {
                                    needRemoval.Add(person);
                                }
                                else
                                {
                                    //person.AddTrainingExperience(pingjunJinyan);
                                    person.AddStrengthExperience(pingjunJinyan);
                                    person.IncreaseReputation(pingjunJinyan);
                                    person.BelongedFaction.IncreaseReputation(0);
                                    person.BelongedFaction.IncreaseTechniquePoint(pingjunJinyan * 20);
                                }
                            }
                            foreach (Person p in needRemoval)
                            {
                                this.TrainingWorkingPersons.Remove(p);
                            }
                            military.IncreaseCombativity(increment);
                        }
                    }

                }

            }
        }


        public bool TransferFoodAvail()
        {
            if (this.Food > 0)
            {
                foreach (Routeway routeway in this.Routeways)
                {
                    float minRate = 1f;
                    if (((routeway.EndArchitecture != null) && routeway.IsActiveInArea(routeway.EndArchitecture.GetRoutewayStartArea(), out minRate)) && (minRate < 1f))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TransferFundAvail()
        {
            return ((this.Fund > 0) && (this.GetOtherArchitectureList().Count > 0));
        }

        public bool TroopershipAvail()
        {
            if ((((base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x1c) != null) 
                && (this.Persons.Count > 0)) && (this.Militaries.Count > 0)) && this.IsBesideWater && !GlobalVariables.LandArmyCanGoDownWater)
            {
                foreach (Military military in this.Militaries)
                {
                    if ((((military.Quantity > 0) && (military.Morale > 0)) && (military.Kind.Type != MilitaryType.水军)) && (this.GetMilitaryCampaignArea(military).Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ViewAreaEvent()
        {
            this.DetectAmbushTroop();
            this.IncreaseViewAreaCombativity();
        }

        public bool ViewTroop(Troop troop)
        {
            return (this.LongViewArea.HasPoint(troop.Position) && (((this.BelongedFaction != null) && this.IsFriendly(troop.BelongedFaction)) || (troop.Status != TroopStatus.埋伏)));
        }

        public void WallStateChange()
        {
            foreach (Troop troop in base.Scenario.Troops)
            {
                if (!this.IsFriendly(troop.BelongedFaction))
                {
                    troop.RefreshViewArchitectureRelatedArea();
                }
            }
        }

        private void YearEnd()
        {
        }

        public void YearEvent()
        {
            this.YearEnd();
        }

        public int AbundantFood
        {
            get
            {
                int num = 0;
                foreach (Legion legion in this.BelongedFaction.Legions)
                {
                    if (legion.Kind == LegionKind.Defensive)
                    {
                        if (legion == this.DefensiveLegion)
                        {
                            num += legion.FoodCostPerDay * 80;
                        }
                    }
                    else if (((legion.Kind == LegionKind.Offensive) && (legion.PreferredRouteway != null)) && (legion.PreferredRouteway.StartArchitecture == this))
                    {
                        num += legion.FoodCostPerDay * 80;
                    }
                }
                int num2 = (((int) (Math.Sqrt((double) this.Population) * 400.0)) + (this.FoodCostPerDayOfAllMilitaries * 80)) + num;
                if (!this.HostileLine)
                {
                    num2 /= 2;
                }
                if (!this.FrontLine)
                {
                    num2 /= 2;
                }
                return num2;
            }
        }

        public int AbundantFund
        {
            get
            {
                return ((((((((this.AreaCount + this.PersonCount) + this.MilitaryCount) + 
                    ((this.TransferFoodArchitecture != null) ? 10 : 0)) + (this.IsCapital ? (4 * this.AreaCount) : 0)) + (this.IsImportant ? 6 : 0)) * 0x3e8) + 
                    (this.FacilityMaintenanceCost * 60)) + (this.RoutewayActiveCost * 60) +
                    ((this.BelongedFaction.BecomeEmperorLegallyAvail() || this.BelongedFaction.SelfBecomeEmperorAvail()) && this.BelongedFaction.Capital == this ? 100000 : 0) +
                    (this.BelongedFaction.Leader.WaitForFeiZi != null ? 50000 : 0) + (this.PlanFacilityKind != null ? this.PlanFacilityKind.FundCost : 0));
            }
        }

        public int Agriculture
        {
            get
            {
                return this.agriculture;
            }
            set
            {
                this.agriculture = value;
            }
        }

        public int AgricultureCeiling
        {
            get
            {
                return this.kind.HasAgriculture ? ((this.Kind.AgricultureBase + (this.Kind.AgricultureUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfAgricultureCeiling) : 0;
            }
        }

        public string AgricultureString
        {
            get
            {
                return (this.Agriculture + "/" + this.AgricultureCeiling);
            }
        }

        public string AILandLinksDisplayString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Architecture architecture in this.AILandLinks)
                {
                    builder.Append(architecture.Name + " ");
                }
                return builder.ToString();
            }
        }

        public string AIWaterLinksDisplayString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Architecture architecture in this.AIWaterLinks)
                {
                    builder.Append(architecture.Name + " ");
                }
                return builder.ToString();
            }
        }

        public int AreaCount
        {
            get
            {
                //return this.ArchitectureArea.Count;
                return 1;

            }
        }

        public int JianzhuGuimo
        {
            get
            {
                return this.ArchitectureArea.Count;
                

            }
        }


        public int ArmyQuantity
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    num += military.Quantity;
                }
                return num;
            }
        }

        public int ArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        num += military.Scales;
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        public int InverseArmyScaleWeighing
        {
            get
            {
                return (int) ((10000.0 / this.ArmyScale) * (((((((this.IsCapital ? 2 : 1) + (this.IsStateAdmin ? 1 : 0)) + (this.IsRegionCore ? 1 : 0)) + (this.IsStrategicCenter ? 1 : 0)) + (this.FrontLine ? 2 : 0)) + (this.HostileLine ? 2 : 0)) + (this.CriticalHostile ? 3 : 0)));
            }
        }

        public int ArmyScaleWeighing
        {
            get
            {
                return ((this.ArmyScale + 10) * (((((((this.IsCapital ? 2 : 1) + (this.IsStateAdmin ? 1 : 0)) + (this.IsRegionCore ? 1 : 0)) + (this.IsStrategicCenter ? 1 : 0)) + (this.FrontLine ? 2 : 0)) + (this.HostileLine ? 2 : 0)) + (this.CriticalHostile ? 3 : 0)));
            }
        }

        public bool AutoHiring
        {
            get
            {
                return this.autoHiring;
            }
            set
            {
                this.autoHiring = value;
            }
        }

        public bool AutoRewarding
        {
            get
            {
                return this.autoRewarding;
            }
            set
            {
                this.autoRewarding = value;
            }
        }

        public bool AutoSearching
        {
            get
            {
                return this.autoSearching;
            }
            set
            {
                this.autoSearching = value;
            }
        }

        public bool AutoWorking
        {
            get
            {
                return this.autoWorking;
            }
            set
            {
                this.autoWorking = value;
            }
        }

        public GameArea BaseFoodSurplyArea
        {
            get
            {
                if (this.baseFoodSurplyArea == null)
                {
                    this.baseFoodSurplyArea = this.LongViewArea;
                    /*this.baseFoodSurplyArea = new GameArea();
                    foreach (Point point in this.ArchitectureArea.GetContactArea(true).Area)
                    {
                        this.baseFoodSurplyArea.AddPoint(point);
                    }
                    foreach (Point point in this.ArchitectureArea.Area)
                    {
                        this.baseFoodSurplyArea.AddPoint(point);
                    }
                    return this.baseFoodSurplyArea;*/
                }
                return this.baseFoodSurplyArea;
            }
        }

        public int BuildingDaysLeft
        {
            get
            {
                return this.buildingDaysLeft;
            }
            set
            {
                this.buildingDaysLeft = value;
            }
        }

        public int BuildingFacility
        {
            get
            {
                return this.buildingFacility;
            }
            set
            {
                this.buildingFacility = value;
            }
        }

        public int CaptiveCount
        {
            get
            {
                return this.Captives.Count;
            }
        }

        public int ChangeCapitalCost
        {
            get
            {
                return (Parameters.ChangeCapitalCost * this.AreaCount);
            }
        }

        public int ClearFieldAgricultureCost
        {
            get
            {
                if (this.Kind.HasAgriculture)
                {
                    return ((this.LongViewArea.Count - this.AreaCount) * Parameters.ClearFieldAgricultureCostUnit);
                }
                return 0;
            }
        }

        public int ClearFieldCredit
        {
            get
            {
                int num = 0;
                foreach (Point point in this.LongViewArea.Area)
                {
                    if ((base.Scenario.GetArchitectureByPosition(point) != null) || base.Scenario.NoFoodDictionary.HasPosition(point))
                    {
                        continue;
                    }
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition == null) || this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                    {
                        TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                        if ((terrainDetailByPosition != null) && (terrainDetailByPosition.FoodDeposit > 0))
                        {
                            num += terrainDetailByPosition.GetFood(base.Scenario.Date.Season);
                        }
                    }
                }
                return num;
            }
        }

        public int ClearFieldFundCost
        {
            get
            {
                int num = (int) (((this.LongViewArea.Count - this.AreaCount) * Parameters.ClearFieldFundCostUnit) * this.RateOfClearField);
                if (this.Kind.HasAgriculture)
                {
                    return num;
                }
                return (num * 2);
            }
        }

        public int Commerce
        {
            get
            {
                return this.commerce;
            }
            set
            {
                this.commerce = value;
            }
        }

        public int CommerceCeiling
        {
            get
            {
                return this.kind.HasCommerce ? ((this.Kind.CommerceBase + (this.Kind.CommerceUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfCommerceCeiling) : 0;
            }
        }

        public string CommerceString
        {
            get
            {
                return (this.Commerce + "/" + this.CommerceCeiling);
            }
        }

        public GameArea ContactArea
        {
            get
            {
                if (this.contactArea == null)
                {
                    this.contactArea = this.ArchitectureArea.GetContactArea(false);
                }
                return this.contactArea;
            }
        }

        public int ConvincePersonFund
        {
            get
            {
                return (int) (Parameters.ConvincePersonCost * this.RateOfConvincePerson);
            }
        }

        public int ConvincePersonMaxCount
        {
            get
            {
                return (this.Fund / this.ConvincePersonFund);
            }
        }

        public float CurrentRateOfInternal
        {
            get
            {
                return (this.RateOfInternal + this.DayRateIncrementOfInternal);
            }
        }

        public float CurrentSurplusRate
        {
            get
            {
                return this.surplusRate;
            }
        }

        public int DestroyArchitectureFund
        {
            get
            {
                return (int) (Parameters.DestroyArchitectureCost * this.RateOfDestroyArchitecture);
            }
        }

        public int DestroyPersonMaxCount
        {
            get
            {
                return (this.Fund / this.DestroyArchitectureFund);
            }
        }

        public int Domination
        {
            get
            {
                return this.domination;
            }
            set
            {
                this.domination = value;
            }
        }

        public int DominationCeiling
        {
            get
            {
                return this.kind.HasDomination ? (this.Kind.DominationBase + (this.Kind.DominationUnit * (this.JianzhuGuimo - 1)) + this.IncrementOfDominationCeiling) : 0;
            }
        }

        public string DominationString
        {
            get
            {
                return (this.Domination + "/" + this.DominationCeiling);
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                this.endurance = value;
            }
        }

        public int EnduranceCeiling
        {
            get
            {
                return this.kind.HasEndurance ? ((this.Kind.EnduranceBase + (this.Kind.EnduranceUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfEnduranceCeiling) : 0;
            }
        }

        public string EnduranceString
        {
            get
            {
                return (this.Endurance + "/" + this.EnduranceCeiling);
            }
        }

        public int EnoughFood
        {
            get
            {
                int num = 0;
                foreach (Legion legion in this.BelongedFaction.Legions)
                {
                    if (legion.Kind == LegionKind.Defensive)
                    {
                        if (legion == this.DefensiveLegion)
                        {
                            num += legion.FoodCostPerDay * 40;
                        }
                    }
                    else if (((legion.Kind == LegionKind.Offensive) && (legion.PreferredRouteway != null)) && (legion.PreferredRouteway.StartArchitecture == this))
                    {
                        num += legion.FoodCostPerDay * 40;
                    }
                }
                int num2 = (((int) (Math.Sqrt((double) this.Population) * 200.0)) + (this.FoodCostPerDayOfAllMilitaries * 40)) + num;
                if (!this.HostileLine)
                {
                    num2 /= 2;
                }
                if (!this.FrontLine)
                {
                    num2 /= 2;
                }
                return num2;
            }
        }

        public int EnoughFund
        {
            get
            {
                return ((((((((this.AreaCount + this.PersonCount) + this.MilitaryCount) + 
                    ((this.TransferFoodArchitecture != null) ? 5 : 0)) + (this.IsCapital ? (2 * this.AreaCount) : 0)) + (this.IsImportant ? 3 : 0)) * 500) +
                    (this.FacilityMaintenanceCost * 30)) + (this.RoutewayActiveCost * 30) + 
                    ((this.BelongedFaction.BecomeEmperorLegallyAvail() || this.BelongedFaction.SelfBecomeEmperorAvail()) && this.BelongedFaction.Capital == this ? 100000 : 0) + 
                    (this.BelongedFaction.Leader.WaitForFeiZi != null ? 50000 : 0) + (this.PlanFacilityKind != null ? this.PlanFacilityKind.FundCost : 0));
            }
        }

        private int ExpectedFoodCache = -1;
        public int ExpectedFood
        {
            get
            {
                if (ExpectedFoodCache >= 0)
                {
                    return ExpectedFoodCache;
                }
                int num = this.Agriculture + ((int)((Math.Pow((double)this.Population, 0.3) * Math.Pow((double)this.Agriculture, 0.8)) * 47.0));
                num += this.IncrementOfMonthFood;
                num += (int)(this.RateIncrementOfMonthFood * num);
                num = (int)(num * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.Season));
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.IsFriendly(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num += (int)(num * 0.2);
                    }
                    else if (this.IsHostile(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num -= (int)(num * 0.2);
                    }
                }
                if (this.BelongedFaction != null)
                {
                    num = (int)(num * this.BelongedFaction.InternalSurplusRate);
                }
                num = (int)(num * Parameters.FoodRate);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    num = (int)(num * Parameters.AIFoodRate);
                }
                if (GlobalVariables.MultipleResource)
                {
                    num *= 2;
                }
                num += 10000;
                ExpectedFoodCache = num;
                return num;
            }
        }

        public string ExpectedFoodString
        {
            get
            {
                return (this.ExpectedFood + "/月");
            }
        }

        private int ExpectedFundCache = -1;
        public int ExpectedFund
        {
            get
            {
                if (ExpectedFundCache >= 0)
                {
                    return ExpectedFundCache;
                }
                int num = this.Commerce + ((int)((Math.Pow((double)this.Population, 0.6) * Math.Pow((double)this.Commerce, 0.8)) / 59.0));
                num += this.IncrementOfMonthFund;
                num += (int)(this.RateIncrementOfMonthFund * num);
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.IsFriendly(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num += (int)(num * 0.2);
                    }
                    else if (this.IsHostile(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num -= (int)(num * 0.2);
                    }
                }
                if (this.BelongedFaction != null)
                {
                    num = (int)(num * this.BelongedFaction.InternalSurplusRate);
                }
                num = (int)(num * Parameters.FundRate);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    num = (int)(num * Parameters.AIFundRate);
                }
                if (GlobalVariables.MultipleResource)
                {
                    num *= 2;
                }
                num += 100;
                ExpectedFundCache = num;
                return num;
            }
        }

        public int ExpectedMilitaryPopulation
        {
            get
            {
                int num;
                num=this.Population /10 *this.Morale/1000;
                return num;
            }
        }

        public string ExpectedFundString
        {
            get
            {
                return (this.ExpectedFund + "/月");
            }
        }

        public int FacilityCount
        {
            get
            {
                return this.Facilities.Count;
            }
        }

        public bool FacilityEnabled
        {
            get
            {
                return this.facilityEnabled;
            }
            set
            {
                this.facilityEnabled = value;
            }
        }

        public string FacilityEnabledString
        {
            get
            {
                return (this.FacilityEnabled ? "○" : "×");
            }
        }

        public int FacilityMaintenanceCost
        {
            get
            {
                int num = 0;
                foreach (Facility facility in this.Facilities)
                {
                    num += facility.MaintenanceCost;
                }
                return num;
            }
        }

        public string FacilityMaintenanceCostString
        {
            get
            {
                return (this.FacilityMaintenanceCost + "/日");
            }
        }

        public int FacilityPositionCount
        {
            get
            {
                return (this.Kind.FacilityPositionUnit * (this.JianzhuGuimo + this.IncrementOfFacilityPositionCount));
            }
        }

        public int FacilityPositionLeft
        {
            get
            {
                int facilityPositionCount = this.FacilityPositionCount;
                foreach (Facility facility in this.Facilities)
                {
                    facilityPositionCount -= facility.PositionOccupied;
                }
                if (this.BuildingFacility >= 0)
                {
                    FacilityKind facilityKind = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.BuildingFacility);
                    if (facilityKind != null)
                    {
                        facilityPositionCount -= facilityKind.PositionOccupied;
                    }
                }
                return facilityPositionCount;
            }
        }

        public string FacilityPositionString
        {
            get
            {
                return ((this.FacilityPositionCount - this.FacilityPositionLeft) + "/" + this.FacilityPositionCount);
            }
        }

        public bool FactionAutoRefuse
        {
            get
            {
                return ((this.BelongedFaction != null) && this.BelongedFaction.AutoRefuse);
            }
        }

        public string FactionInternalSurplusRatePercentString
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return StaticMethods.GetPercentString(this.BelongedFaction.InternalSurplusRate, 3);
                }
                return "----";
            }
        }

        public string FactionString
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return this.BelongedFaction.Name;
                }
                return "----";
            }
        }

        public int FewArmyScale
        {
            get
            {
                return (10 + (2 * this.AreaCount));
            }
        }

        public int Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
            }
        }

        public int FoodCeiling
        {
            get
            {
                return (this.kind.FoodMaxUnit * this.JianzhuGuimo) + this.IncrementOfFoodCeiling;
            }
        }

        public int FoodCostPerDayOfAllMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    num += military.FoodCostPerDay;
                }
                return num;
            }
        }

        public int FoodCostPerDayOfLandMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Kind.Type != MilitaryType.水军)
                    {
                        num += military.FoodCostPerDay;
                    }
                }
                return num;
            }
        }

        public int FoodCostPerDayOfWaterMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Kind.Type == MilitaryType.水军)
                    {
                        num += military.FoodCostPerDay;
                    }
                }
                return num;
            }
        }

        public float FoodReduceDayRate
        {
            get
            {
                return (0.001f * this.RateOfFoodReduceRate);
            }
        }

        public string FoodReduceDayRateString
        {
            get
            {
                return (Math.Round((double) this.FoodReduceDayRate, 4).ToString() + "/日");
            }
        }

        public int Fund
        {
            get
            {
                return this.fund;
            }
            set
            {
                this.fund = value;
            }
        }

        public int FundCeiling
        {
            get
            {
                return (this.Kind.FundMaxUnit * this.JianzhuGuimo) + this.IncrementOfFundCeiling;
            }
        }

        public int FundInPack
        {
            get
            {
                int num = 0;
                foreach (FundPack pack in this.FundPacks)
                {
                    num += pack.Fund;
                }
                return num;
            }
        }

        public int GossipArchitectureFund
        {
            get
            {
                return (int) (Parameters.GossipArchitectureCost * this.RateOfGossipArchitecture);
            }
        }

        public int GossipPersonMaxCount
        {
            get
            {
                return (this.Fund / this.GossipArchitectureFund);
            }
        }

        public bool HasBuildingRouteway
        {
            get
            {
                foreach (Routeway routeway in this.Routeways)
                {
                    if (routeway.Building)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasDefensiveLegion
        {
            get
            {
                return (this.DefensiveLegion != null);
            }
        }

        public bool HasFriendlyDiplomaticRelation
        {
            get
            {
                if (this.BelongedFaction == null)
                {
                    return false;
                }
                return this.BelongedFaction.HasFriendlyDiplomaticRelation;
            }
        }

        private bool HasHirablePerson
        {
            get
            {
                foreach (Person person in this.NoFactionPersons)
                {
                    if (person.IsHirable(this.BelongedFaction))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasSpy
        {
            get
            {
                return (this.SpyPacks.Count > 0);
            }
        }

        private int HirablePersonCount
        {
            get
            {
                int num = 0;
                foreach (Person person in this.NoFactionPersons)
                {
                    if (person.IsHirable(this.BelongedFaction))
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public bool HireFinished
        {
            get
            {
                return this.hireFinished;
            }
            set
            {
                this.hireFinished = value;
            }
        }

        public int HirePersonFund
        {
            get
            {
                return (int) ((Parameters.HireNoFactionPersonCost * this.AreaCount) * this.RateOfHirePerson);
            }
        }

        public int InformationCoolDown
        {
            get
            {
                return this.informationCoolDown;
            }
            set
            {
                this.informationCoolDown = value;
            }
        }

        public int InstigateArchitectureFund
        {
            get
            {
                return (int) (Parameters.InstigateArchitectureCost * this.RateOfInstigateArchitecture);
            }
        }

        public int InstigatePersonMaxCount
        {
            get
            {
                return (this.Fund / this.InstigateArchitectureFund);
            }
        }

        public int InternalFundCost
        {
            get
            {
                return (Parameters.InternalFundCost * this.AreaCount);
            }
        }

        public bool IsBesideWater
        {
            get
            {
                foreach (Point point in this.ArchitectureArea.GetContactArea(false).Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point) && (base.Scenario.ScenarioMap.MapData[point.X, point.Y] == 6))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsCapital
        {
            get
            {
                return ((this.BelongedFaction != null) && (this.BelongedFaction.Capital == this));
            }
        }

        public bool IsFoodAbundant
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food >= this.AbundantFood));
            }
        }

        public bool IsFoodEnough
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food >= this.EnoughFood));
            }
        }

        public bool IsFoodTwiceAbundant
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food > (this.AbundantFood * 2)));
            }
        }

        public bool IsFundAbundant
        {
            get
            {
                return ((this.Fund >= this.FundCeiling) || ((((this.Fund + this.FundInPack) - ((this.BelongedFaction.PlanTechniqueArchitecture == this) ? this.BelongedFaction.getTechniqueActualFundCost(this.BelongedFaction.PlanTechnique) : 0)) - ((this.PlanFacilityKind != null) ? this.PlanFacilityKind.FundCost : 0)) >= this.AbundantFund));
            }
        }

        public bool IsFundEnough
        {
            get
            {
                return ((this.Fund >= this.FundCeiling) || ((((this.Fund + this.FundInPack) - ((this.BelongedFaction.PlanTechniqueArchitecture == this) ? this.BelongedFaction.getTechniqueActualFundCost(this.BelongedFaction.PlanTechnique) : 0)) - ((this.PlanFacilityKind != null) ? this.PlanFacilityKind.FundCost : 0)) >= this.EnoughFund));
            }
        }

        public bool IsImportant
        {
            get
            {
                return (((this.IsCapital || this.IsStrategicCenter) || this.IsStateAdmin) || this.IsRegionCore || this.huangdisuozai);
            }
        }

        public bool IsRegionCore
        {
            get
            {
                return (this.LocationState.LinkedRegion.RegionCore == this);
            }
        }

        public bool IsStateAdmin
        {
            get
            {
                return (this.LocationState.StateAdmin == this);
            }
        }

        public bool IsStrategicCenter
        {
            get
            {
                return this.isStrategicCenter;
            }
            set
            {
                this.isStrategicCenter = value;
            }
        }

        public string IsStrategicCenterString
        {
            get
            {
                return (this.IsStrategicCenter ? "○" : "×");
            }
        }

        public ArchitectureKind Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        public string KindString
        {
            get
            {
                return this.Kind.Name;
            }
        }

        public int LandArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        if (military.Kind.Type != MilitaryType.水军)
                        {
                            num += military.Scales;
                        }
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        public int LargeArmyScale
        {
            get
            {
                return (40 + (10 * this.AreaCount));
            }
        }

        public GameArea LongViewArea
        {
            get
            {
                if (!this.Kind.HasLongView)
                {
                    return this.ViewArea;
                }
                if (this.longViewArea != null)
                {
                    return this.longViewArea;
                }
                return (this.longViewArea = GameArea.GetAreaFromArea(this.ArchitectureArea, this.LongViewDistance, this.kind.HasObliqueView, base.Scenario, this.BelongedFaction));
            }
            set
            {
                this.longViewArea = value;
            }
        }

        public int LongViewDistance
        {
            get
            {
                return (this.ViewDistance * 2);
            }
        }

        public int MilitaryCount
        {
            get
            {
                return this.Militaries.Count;
            }
        }

        public int Morale
        {
            get
            {
                return this.morale;
            }
            set
            {
                this.morale = value;
            }
        }

        public int MoraleCeiling
        {
            get
            {
                return this.kind.HasMorale ? (this.Kind.MoraleBase + (this.Kind.MoraleUnit * (this.JianzhuGuimo - 1)) + this.IncrementOfMoraleCeiling) : 0;
            }
        }

        public string MoraleString
        {
            get
            {
                return (this.Morale + "/" + this.MoraleCeiling);
            }
        }

        public string FrontLineString
        {
            get
            {
                return this.FrontLine ? "○" : "×";
            }
        }

        public int MovingPersonCount
        {
            get
            {
                return this.MovingPersons.Count;
            }
        }

        public int NoFactionPersonCount
        {
            get
            {
                return this.NoFactionPersons.Count;
            }
        }

        public int NormalArmyScale
        {
            get
            {
                return (20 + (5 * this.AreaCount));
            }
        }

        public ArchitectureList OtherArchitectures
        {
            get
            {
                ArchitectureList list = new ArchitectureList();
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        list.Add(architecture);
                    }
                }
                return list;
            }
        }

        public double PDRAgricultureFix
        {
            get
            {
                if (this.Agriculture >= ((int) (this.AgricultureCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Agriculture < ((int) (this.AgricultureCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRCommerceFix
        {
            get
            {
                if (this.Commerce >= ((int) (this.CommerceCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Commerce < ((int) (this.CommerceCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRDominationFix
        {
            get
            {
                if (this.Domination >= ((int) (this.DominationCeiling * 0.8)))
                {
                    return 2E-05;
                }
                if (this.Domination < ((int) (this.DominationCeiling * 0.2)))
                {
                    return -0.0001;
                }
                if (this.Domination < ((int) (this.DominationCeiling * 0.5)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRMoraleFix
        {
            get
            {
                if (this.Morale >= ((int) (this.MoraleCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Morale < ((int) (this.MoraleCeiling * 0.1)))
                {
                    return -0.0001;
                }
                if (this.Morale < ((int) (this.MoraleCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public int PersonCount
        {
            get
            {
                return this.Persons.Count;
            }
        }

        public int Population
        {
            get
            {
                return this.population;
            }
            set
            {
                this.population = value;
            }
        }

        public int PopulationCeiling
        {
            get
            {
                return (int) ((this.Kind.PopulationBase + (this.Kind.PopulationUnit * (this.JianzhuGuimo - 1))) * (1 + this.RateIncrementOfPopulationCeiling));
            }
        }

        public double PopulationDevelopingRate
        {
            get
            {
                double num = Math.Round((double) (((((Parameters.DefaultPopulationDevelopingRate + this.PDRAgricultureFix) + this.PDRCommerceFix) + this.PDRDominationFix) + this.PDRMoraleFix) + this.RateIncrementOfPopulationDevelop), 5);
                if (!((this.RecentlyAttacked <= 0) || this.DayAvoidInfluenceByBattle))
                {
                    num += -0.00030000000000000003;
                }

                return num;
            }
        }

        public double PopulationDevelopingRateString
        {
            get
            {
                return Math.Round((double) (this.PopulationDevelopingRate / 0.0001), 1);
            }
        }

        public Point Position
        {
            get
            {
                return this.ArchitectureArea.TopLeft;
            }
        }

        public int RecruitmentPopulationBoundary
        {
            get
            {
               // return (this.Kind.PopulationBoundary * this.AreaCount);
                return (this.Kind.PopulationBoundary);
            }
        }

        public string RegionEffectString
        {
            get
            {
                if ((this.LocationState.LinkedRegion.RegionCore != null) && this.LocationState.LinkedRegion.RegionCore.RegionCoreEffectAvail())
                {
                    if (this.LocationState.LinkedRegion.RegionCore.IsFriendly(this.BelongedFaction))
                    {
                        return "正面";
                    }
                    if (this.LocationState.LinkedRegion.RegionCore.IsHostile(this.BelongedFaction))
                    {
                        return "负面";
                    }
                }
                return "----";
            }
        }

        public string RegionString
        {
            get
            {
                return this.LocationState.LinkedRegionString;
            }
        }

        public int RewardPersonFund
        {
            get
            {
                return (int) (Parameters.RewardPersonCost * this.RateOfRewardPerson);
            }
        }

        public int RewardPersonMaxCount
        {
            get
            {
                int rewardPersonFund = this.RewardPersonFund;
                if (rewardPersonFund > 0)
                {
                    return (this.Fund / rewardPersonFund);
                }
                return this.PersonCount;
            }
        }

        public int RoutewayActiveCost
        {
            get
            {
                int num = 0;
                foreach (Routeway routeway in this.Routeways)
                {
                    if (routeway.LastActivePoint != null)
                    {
                        num += routeway.LastActivePoint.ActiveFundCost;
                    }
                }
                return num;
            }
        }

        public string RoutewayActiveCostString
        {
            get
            {
                return (this.RoutewayActiveCost.ToString() + "/日");
            }
        }

        public ArchitectureList RoutewayDestinationArchitectureList
        {
            get
            {
                ArchitectureList list = new ArchitectureList();
                foreach (Architecture architecture in this.RoutewayDestinationArchitectures.Values)
                {
                    list.Add(architecture);
                }
                return list;
            }
        }

        public string SectionString
        {
            get
            {
                if (this.BelongedSection != null)
                {
                    return this.BelongedSection.Name;
                }
                return "----";
            }
        }

        public bool ShowNumber
        {
            get
            {
                return this.showNumber;
            }
            set
            {
                this.showNumber = value;
                if (!value)
                {
                    this.IncrementNumberList.Clear();
                    this.DecrementNumberList.Clear();
                }
            }
        }

        public int SpyArchitectureFund
        {
            get
            {
                return (int) (Parameters.SendSpyCost * this.RateOfSpyArchitecture);
            }
        }

        public int SpyPersonMaxCount
        {
            get
            {
                return (this.Fund / this.SpyArchitectureFund);
            }
        }

        public string StateEffectString
        {
            get
            {
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.LocationState.StateAdmin.IsFriendly(this.BelongedFaction))
                    {
                        return "正面";
                    }
                    if (this.LocationState.StateAdmin.IsHostile(this.BelongedFaction))
                    {
                        return "负面";
                    }
                }
                return "----";
            }
        }

        public string StateString
        {
            get
            {
                return this.LocationState.Name;
            }
        }

        public int Technology
        {
            get
            {
                return this.technology;
            }
            set
            {
                this.technology = value;
            }
        }

        public int TechnologyCeiling
        {
            get
            {
                return this.kind.HasTechnology ? ((this.Kind.TechnologyBase + (this.Kind.TechnologyUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfTechnologyCeiling) : 0;
            }
        }

        public string TechnologyString
        {
            get
            {
                return (this.Technology + "/" + this.TechnologyCeiling);
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this.Kind.Texture;
            }
        }

        public int TransferFoodArchitectureCount
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.OtherArchitectures)
                {
                    if (architecture.TransferFoodArchitecture == this)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int UnitPopulation
        {
            get
            {
                return (this.Population / this.AreaCount);
            }
        }

        public bool ValueWater
        {
            get
            {
                return (this.Kind.HasHarbor || this.TroopershipAvailable);
            }
        }

        public int VeryFewArmyScale
        {
            get
            {
                return (5 + this.AreaCount);
            }
        }

        public GameArea ViewArea
        {
            get
            {
                if (this.viewArea != null)
                {
                    return this.viewArea;
                }
                return (this.viewArea = GameArea.GetAreaFromArea(this.ArchitectureArea, this.ViewDistance, this.kind.HasObliqueView, base.Scenario, this.BelongedFaction));
            }
            set
            {
                this.viewArea = value;
            }
        }

        public int ViewDistance
        {
            get
            {
                return ((this.Kind.ViewDistance + (this.AreaCount / this.Kind.ViewDistanceIncrementDivisor)) + this.IncrementOfViewRadius);
            }
        }

        public int WaterArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        if (military.Kind.Type == MilitaryType.水军 && military.KindID != 29)
                        {
                            num += military.Scales;
                        }
                        else if (this.ValueWater)
                        {
                            num += military.Quantity / 0x7d0;
                        }
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        private class AILinkProcedureDetail
        {
            internal Architecture A;
            internal int Level;
            internal List<Architecture> Path = new List<Architecture>();

            internal AILinkProcedureDetail(int level, Architecture a, List<Architecture> path)
            {
                this.Level = level;
                this.A = a;
                foreach (Architecture architecture in path)
                {
                    this.Path.Add(architecture);
                }
            }
        }
        /*
        public FreeText jianzhubiaoti
        {
            get;
            set;
        }
        */

        public qizi jianzhuqizi
        {
            get;
            set;
        }

        public bool youzainan
        {
            get;
            set;
        }

        public string zainanming
        {
            get
            {
                if (this.youzainan)
                {
                    return this.zainan.zainanzhonglei.Name;
                }
                else
                {
                    return "——";
                }
            }
        }

        public string zainanshengyutianshu
        {
            get
            {
                if (this.youzainan)
                {
                    return this.zainan.shengyutianshu.ToString() ;
                }
                else
                {
                    return "——";
                }
            }
        }

        public bool kezhenzai()
        {

                if (this.youzainan && this.Fund > 0 && this.Food > 0 && this.HasPerson())
                {
                    return true;
                }
                else
                {
                    return false;
                }

        }

        public bool kenafei()
        {
            if (GlobalVariables.getChildrenRate <= 0) return false;
            
            //if (this.younvxingwujiang() && this.Fund > 50000 && this.meinvkongjian() > this.feiziliebiao.Count && this.Persons.GameObjects.Contains(this.BelongedFaction.Leader))
            if (this.nvxingwujiang().Count>0 && this.Fund > 50000 && this.meinvkongjian() > this.feiziliebiao.Count && this.Persons.GameObjects.Contains(this.BelongedFaction.Leader))

                
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool kejinhougong()
        {
            if (this.meifaxianhuaiyundefeiziliebiao().Count != 0 && this.Persons.GameObjects.Contains(this.BelongedFaction.Leader) && !this.BelongedFaction.Leader.huaiyun)
            {

                return true;
            }
            return false;

        }

        public PersonList meifaxianhuaiyundefeiziliebiao()
        {
             PersonList meihuailiebiao=new PersonList();
             foreach (Person person in this.feiziliebiao)
                {
                    if (!person.faxianhuaiyun && this.BelongedFaction.Leader.isLegalFeiZi(person))
                        meihuailiebiao.Add(person);
                }
             return meihuailiebiao;
        }
        /*
        private bool younvxingwujiang()
        {
            foreach (Person person in this.Persons)
            {
                if (person.Sex != person.BelongedFaction.Leader.Sex)
                {
                    return true;
                }
            }
            return false;
        }
        */

        public PersonList nvxingwujiang()
        {
            PersonList nvxingwujiangliebiao = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.BelongedFaction.Leader.isLegalFeiZi(person))
                {
                    nvxingwujiangliebiao.Add(person);
                }
            }
            return nvxingwujiangliebiao;
        }

        public PersonList CanKilledPersons()
        {
            PersonList personList = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.ID !=this.BelongedFaction.LeaderID )
                {
                    personList.Add(person);
                }
            }

            return personList;
        }

        public PersonList CanKilledCaptives()
        {
            PersonList personList = new PersonList();
            foreach (Captive captive in this.Captives )
            {

                    personList.Add(captive.CaptivePerson);
                
            }

            return personList;
        }

        public int meinvkongjian()
        {
            int kongjian=0;
            foreach (Facility facility in this.Facilities)
            {
                kongjian += facility.Kind.rongna;
            }
            return kongjian;
        }

        public string meinvkongjianzifu
        {
            get
            {
                return this.feiziliebiao.Count.ToString()+"/"+this.meinvkongjian().ToString();
            }
        }


        public FacilityList kechaichudesheshi()
        {
            FacilityList kechaichu = new FacilityList();
            foreach (Facility facility in this.Facilities)
            {
                if (! facility.Kind.bukechaichu)
                {
                    kechaichu.Add(facility);
                }
            }
            return kechaichu;
        }

        public PersonList yihuaiyundefeiziliebiao()
        {
            PersonList feiziliebiao= new PersonList();
            foreach (Person feizi in this.feiziliebiao)
            {
                if (feizi.huaiyun)
                {
                    feiziliebiao.Add(feizi);
                }
            }
            return feiziliebiao;
        }

        public bool huangdisuozai
        {
            get;
            set;
        }

        public bool kejingongzijin()
        {
            if (base.Scenario.Date.Month==3 && base.Scenario.youhuangdi() && this.Fund > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool KillPersonAvail()
        {
            if (this.PersonCount - (this.Persons.GameObjects.Contains(this.BelongedFaction.Leader) ? 1 : 0) > 0)
                
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public bool kejingongliangcao()
        {
            if (base.Scenario.Date.Month == 3 && base.Scenario.youhuangdi() && this.Food  > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point zhongxindian
        {
            get
            {
                int xzonghe=0;
                int yzonghe=0;
                int xpingjunzhi;
                int ypingjunzhi;
                foreach (Point p in this.ArchitectureArea.Area  )
                {
                    xzonghe += p.X;
                    yzonghe += p.Y;
                }
                xpingjunzhi = xzonghe / this.JianzhuGuimo;
                ypingjunzhi = yzonghe / this.JianzhuGuimo;
                foreach (Point p in this.ArchitectureArea.Area)
                {
                    if (p.X == xpingjunzhi && p.Y == ypingjunzhi)
                    {
                        return p;
                    }
                }
                return this.ArchitectureArea.Area[0]; 
            }
        }

        public Point dingdian
        {
            get
            {
                Point zuishangmiandedian = this.ArchitectureArea.Area[0];
                foreach (Point p in this.ArchitectureArea.Area)
                {
                    if (p.Y < zuishangmiandedian.Y)
                    {
                        zuishangmiandedian = p;
                    }
                }

                if (this.Kind.ID == 2 )  //如果是关隘
                {
                    if (this.JianzhuGuimo == 1)
                    {
                        return zuishangmiandedian;
                    }
                    if (this.ArchitectureArea.Area[0].X == this.ArchitectureArea.Area[1].X)
                    {
                        return zuishangmiandedian;
                    }
                    else
                    {
                        return this.zhongxindian;
                    }

                }

                return zuishangmiandedian;
            }
        }

        public int IdlingPersonCount
        {
            get
            {
                int result = 0;
                foreach (Person person in this.Persons)
                {
                    if (person.WorkKind == ArchitectureWorkKind.无)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public String yocelanPersonString
        {
            get
            {
                return IdlingPersonCount + "/" + PersonCount;
            }
        }

        private int MeiXunlianHaoDeBianduiShu()
        {
            int bianduiShu = 0;
            foreach (Military military in this.Militaries)
            {
                if (military.Morale < military.MoraleCeiling || military.Combativity < military.CombativityCeiling)
                {
                    bianduiShu++;
                }
            }
            return bianduiShu;


        }

        public delegate void BeginRecentlyAttacked(Architecture architecture);

        public delegate void FacilityCompleted(Architecture architecture, Facility facility);

        public delegate void fashengzainan(Architecture architecture, int  zainanID);

        public delegate void HirePerson(PersonList personList);

        public delegate void MilitaryCreate(Architecture architecture, Military military);

        public delegate void PopulationEnter(Architecture a, int quantity);

        public delegate void PopulationEscape(Architecture a, int quantity);

        public delegate void ReleaseCaptiveAfterOccupied(Architecture architecture, PersonList persons);

        public delegate void RewardPersons(Architecture architecture, GameObjectList personlist);

        [StructLayout(LayoutKind.Sequential)]
        private struct RoutewayProcedureDetail
        {
            internal Architecture Start;
            internal float PreviousRate;
            internal RoutewayProcedureDetail(Architecture a, float rate)
            {
                this.Start = a;
                this.PreviousRate = rate;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WorkRate
        {
            internal float rate;
            internal ArchitectureWorkKind workKind;
            public WorkRate(float r, ArchitectureWorkKind k)
            {
                this.rate = r;
                this.workKind = k;
            }
        }

        internal class WorkRateList
        {
            internal List<Architecture.WorkRate> RateList = new List<Architecture.WorkRate>();

            internal void AddWorkRate(Architecture.WorkRate wr)
            {
                for (int i = 0; i < this.RateList.Count; i++)
                {
                    if (wr.rate <= this.RateList[i].rate)
                    {
                        this.RateList.Insert(i, wr);
                        return;
                    }
                }
                this.RateList.Add(wr);
            }

            internal int Count
            {
                get
                {
                    return this.RateList.Count;
                }
            }
        }
    }
}

