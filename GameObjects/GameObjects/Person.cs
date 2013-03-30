namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.FactionDetail;
    using GameObjects.PersonDetail;
    using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.IO;
    using GameObjects.Conditions;

    public class Person : GameObject
    {
        private int maxExperience = GlobalVariables.maxExperience;
        public bool huaiyun = false;
        public bool shoudongsousuo = false;
        public int huaiyuntianshu = -1;
        public bool ManualStudy = false;

        public bool faxianhuaiyun = false;

        public int suoshurenwu = -1;
 
        private bool alive;
        private int ambition;
        private int arrivingDays;
        private bool available;
        private int availableLocation;
        private float baseImpactRate;
        public Captive BelongedCaptive;
        private PersonBornRegion bornRegion;
        private int braveness;
        private int brother = -1;
        private float bubingExperience;
        private string calledName;
        private int calmness;
        public int ChanceOfNoCapture;
        public CharacterKind Character;
        private int CharacterKindID;
        private List<int> closePersons = new List<int>();
        public Title CombatTitle;
        private int command;
        private float commandExperience;
        public Person ConvincingPerson;
        public int ConvincingPersonID;
        private InformationKind currentInformationKind;
        public bool DayAvoidInfluenceByBattle;
        public bool DayAvoidInternalDecrementOnBattle;
        public bool DayAvoidPopulationEscape;
        public int DayLearnTitleDay = 90;
        public bool DayLocationLoyaltyNoChange;
        public float DayRateIncrementOfInternal = 0f;
        private PersonDeadReason deadReason;
        private int father = -1;
        private PersonForm form;
        private int generation;
        private string givenName;
        private int glamour;
        private float glamourExperience;
        private List<int> hatedPersons = new List<int>();
        private int ideal;
        public IdealTendencyKind IdealTendency;
        public bool ImmunityOfCaptive;
        private float impactRateOfBadForm;
        private float impactRateOfGoodForm;
        public int IncrementOfAgricultureAbility;
        public int IncrementOfChallengeWinningChance;
        public int IncrementOfCommerceAbility;
        public int IncrementOfControversyWinningChance;
        public int IncrementOfDominationAbility;
        public int IncrementOfEnduranceAbility;
        public int IncrementOfMoraleAbility;
        public int IncrementOfRecruitmentAbility;
        public int IncrementOfSpyDays;
        public int IncrementOfTechnologyAbility;
        public int IncrementOfTrainingAbility;
        public bool InevitableSuccessOfConvince;
        public bool InevitableSuccessOfDestroy;
        public bool InevitableSuccessOfGossip;
        public bool InevitableSuccessOfInstigate;
        public bool InevitableSuccessOfSearch;
        public bool InevitableSuccessOfSpy;
        public int InfluenceIncrementOfCommand;
        public int InfluenceIncrementOfGlamour;
        public int InfluenceIncrementOfIntelligence;
        public int InfluenceIncrementOfPolitics;
        public int InfluenceIncrementOfStrength;
        public float InfluenceRateOfBadForm;
        public float InfluenceRateOfCommand = 1f;
        public float InfluenceRateOfGlamour = 1f;
        public float InfluenceRateOfGoodForm;
        public float InfluenceRateOfIntelligence = 1f;
        public float InfluenceRateOfPolitics = 1f;
        public float InfluenceRateOfStrength = 1f;
        private int informationKindID = -1;
        private int intelligence;
        private float intelligenceExperience;
        private float internalExperience;
        public bool InternalNoFundNeeded;
        private bool leaderPossibility;
        public Troop LocationTroop = null;
        private int loyalty;
        public int MonthIncrementOfFactionReputation = 0;
        public int MonthIncrementOfTechniquePoint = 0;
        private int mother = -1;
        public int MultipleOfAgricultureReputation = 1;
        public int MultipleOfAgricultureTechniquePoint = 1;
        public int MultipleOfCommerceReputation = 1;
        public int MultipleOfCommerceTechniquePoint = 1;
        public int MultipleOfDominationReputation = 1;
        public int MultipleOfDominationTechniquePoint = 1;
        public int MultipleOfEnduranceReputation = 1;
        public int MultipleOfEnduranceTechniquePoint = 1;
        public int MultipleOfMoraleReputation = 1;
        public int MultipleOfMoraleTechniquePoint = 1;
        public int MultipleOfRecruitmentReputation = 1;
        public int MultipleOfRecruitmentTechniquePoint = 1;
        public int MultipleOfTacticsReputation = 1;
        public int MultipleOfTacticsTechniquePoint = 1;
        public int MultipleOfTechnologyReputation = 1;
        public int MultipleOfTechnologyTechniquePoint = 1;
        public int MultipleOfTrainingReputation = 1;
        public int MultipleOfTrainingTechniquePoint = 1;
        private float nubingExperience;
        private int oldFactionID = -1;
        public ArchitectureWorkKind OldWorkKind = ArchitectureWorkKind.无;
        private Point? outsideDestination;
        private OutsideTaskKind outsideTask;
        private int personalLoyalty;
        public Title PersonalTitle;
        public Biography PersonBiography;
        public TextMessage PersonTextMessage;
        private int pictureIndex;
        private int politics;
        private float politicsExperience;
        private int prohibitedFactionID = -1;
        private float qibingExperience;
        private float qixieExperience;
        private PersonQualification qualification;
        public int RadiusIncrementOfInformation;
        public float RateIncrementOfAgricultureAbility;
        public float RateIncrementOfCommerceAbility;
        public float RateIncrementOfConvince;
        public float RateIncrementOfDestroy;
        public float RateIncrementOfDominationAbility;
        public float RateIncrementOfEnduranceAbility;
        public float RateIncrementOfGossip;
        public float RateIncrementOfInstigate;
        public float RateIncrementOfMoraleAbility;
        public float RateIncrementOfRecruitmentAbility;
        public float RateIncrementOfSearch;
        public float RateIncrementOfTechnologyAbility;
        public float RateIncrementOfTrainingAbility;
        private Military recruitmentMilitary;
        private int reputation;
        public bool RewardFinished;
        private int routCount;
        private int routedCount;
        private bool sex = false;
        private float shuijunExperience;
        public SkillTable Skills = new SkillTable();
        private int spouse = -1;
        private int strain;
        private float stratagemExperience;
        private PersonStrategyTendency strategyTendency;
        private int strength;
        private float strengthExperience;
        public Stunt StudyingStunt;
        public Title StudyingTitle;
        public GameObjectList StudyStuntList = new GameObjectList();
        public GameObjectList StudyTitleList = new GameObjectList();
        public StuntTable Stunts = new StuntTable();
        private string surName;
        private float tacticsExperience;
        public Architecture TargetArchitecture;
        private int taskDays;
        public TreasureList Treasures = new TreasureList();
        private PersonValuationOnGovernment valuationOnGovernment;
        private ArchitectureWorkKind workKind = ArchitectureWorkKind.无;
        private int yearAvailable;
        private int yearBorn;
        private int yearDead;

        private PersonStatus status;

        private Person waitForFeiZi = null;
        private int waitForFeiZiPeriod = 0;

        public int waitForFeiziId;

        public float ExperienceRate;

        public int captiveEscapeChance;
        public int pregnantChance;

        public PersonList preferredTroopPersons = new PersonList();
        public string preferredTroopPersonsString;

        public Architecture LocationArchitecture = null;

        private int tiredness;

        public int Tiredness
        {
            get
            {
                return tiredness;
            }
            set
            {
                tiredness = value;
            }
        }

        public int YearJoin{ get; set; }
        public int TroopDamageDealt{ get; set; }
        public int TroopBeDamageDealt{ get; set; }
        public int ArchitectureDamageDealt{ get; set; }
        public int RebelCount{ get; set; }
        public int ExecuteCount{ get; set; }
        public int FleeCount{ get; set; }
        public int HeldCaptiveCount{ get; set; }
        public int CaptiveCount { get; set; }
        public int StratagemSuccessCount { get; set; }
        public int StratagemFailCount { get; set; }
        public int StratagemBeSuccessCount { get; set; }
        public int StratagemBeFailCount { get; set; }

        public int ServedYears
        {
            get
            {
                if (this.Status != PersonStatus.Normal && this.Status != PersonStatus.Moving) return 0;
                int year = base.Scenario.Date.Year - this.YearJoin;
                int sinceBeginning = base.Scenario.DaySince / 360;
                return Math.Min(year, sinceBeginning);
            }
        }

        public PersonStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                /*if (status == PersonStatus.Princess)
                {
                    throw new Exception("Feizi cannot turn into any other state");
                }
                if (value == PersonStatus.Princess && this.LocationTroop != null)
                {
                    throw new Exception("Feizi cannot be in any troop");
                }
                if (value == PersonStatus.Princess && this.LocationArchitecture == null)
                {
                    throw new Exception("Feizi must be in some architectures");
                }
                if (value == PersonStatus.Captive && this.BelongedCaptive == null)
                {
                    throw new Exception("Captives must bear a belonged captive object");
                }
                if ((value == PersonStatus.NoFaction || value == PersonStatus.NoFactionMoving) && this.LocationTroop != null)
                {
                    throw new Exception("No faction persons cannot be in a troop");
                }
                if (value == PersonStatus.None && (this.LocationTroop != null || this.LocationArchitecture != null || this.BelongedCaptive != null))
                {
                    throw new Exception("Dead or unavailable person cannot be in anything!");
                }
                if ((value == PersonStatus.Moving || value == PersonStatus.NoFactionMoving) && this.ArrivingDays <= 0)
                {
                    throw new Exception("Moving persons must have arriving days set");
                }
                if (this.ArrivingDays == 0 && (value == PersonStatus.Moving || value == PersonStatus.NoFactionMoving))
                {
                    throw new Exception("Person finished moving must not remain moving");
                }*/
                if (value == PersonStatus.Moving && this.LocationTroop != null)
                {
                    this.LocationTroop = null;
                }
                if (value != PersonStatus.Normal)
                {
                    this.WorkKind = ArchitectureWorkKind.无;
                }
                if (value != PersonStatus.Normal && status == PersonStatus.Normal)
                {
                    this.PurifySkills();
                    this.PurifyTitles();
                    this.PurifyTreasures();
                    this.PurifyArchitectureInfluence();
                    this.PurifyFactionInfluence();
                }
                else if (value == PersonStatus.Normal && status == PersonStatus.Moving)
                {
                    this.ApplySkills();
                    this.ApplyTitles();
                    this.ApplyTreasures();
                    this.ApplyArchitectureInfluence();
                    this.ApplyFactionInfluence();
                }
                status = value;
            }
        }

        public Faction BelongedFaction
        {
            get
            {
                if ((this.Status == PersonStatus.Normal || this.Status == PersonStatus.Moving) && this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Normal && this.LocationTroop != null)
                {
                    return this.LocationTroop.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Captive)
                {
                    return this.BelongedCaptive.CaptiveFaction;
                }
                return null;
            }
        }

        public Person WaitForFeiZi
        {
            get
            {
                return waitForFeiZi;
            }
            set
            {
                waitForFeiZi = value;
                waitForFeiZiPeriod = 30;
                waitForFeiziId = value == null ? -1 : value.ID;
            }
        }

        public int WaitForFeiZiPeriod
        {
            get
            {
                return waitForFeiZiPeriod;
            }
            set
            {
                waitForFeiZiPeriod = value;
            }
        }


        private void doNotMovePeriodReduction()
        {
            waitForFeiZiPeriod--;
            if (waitForFeiZiPeriod < 0)
            {
                WaitForFeiZi = null;
            }
        }

        public event BeAwardedTreasure OnBeAwardedTreasure;

        public event BeConfiscatedTreasure OnBeConfiscatedTreasure;

        public event BeKilled OnBeKilled;

        public event ChangeLeader OnChangeLeader;

        public event ConvinceFailed OnConvinceFailed;

        public event ConvinceSuccess OnConvinceSuccess;

        public event Death OnDeath;

        public event DeathChangeFaction OnDeathChangeFaction;

        public event DestroyFailed OnDestroyFailed;

        public event DestroySuccess OnDestroySuccess;

        public event GossipFailed OnGossipFailed;

        public event GossipSuccess OnGossipSuccess;

        public event InformationObtained OnInformationObtained;

        public event qingbaoshibai qingbaoshibaishijian;

        public event InstigateFailed OnInstigateFailed;

        public event InstigateSuccess OnInstigateSuccess;

        public event Leave OnLeave;

        public event SearchFinished OnSearchFinished;

        public event ShowMessage OnShowMessage;

        public event SpyFailed OnSpyFailed;

        public event SpyFound OnSpyFound;

        public event SpySuccess OnSpySuccess;

        public event StudySkillFinished OnStudySkillFinished;

        public event StudyStuntFinished OnStudyStuntFinished;

        public event StudyTitleFinished OnStudyTitleFinished;

        public event TreasureFound OnTreasureFound;

        public event CapturedByArchitecture OnCapturedByArchitecture;

        public double TirednessFactor
        {
            get
            {
                return Math.Max(0.2, Math.Min(1, (210 - this.Tiredness / 180.0)));
            }
        }

        public void AddBubingExperience(int increment)
        {
            this.bubingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate) 
                * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.bubingExperience > maxExperience)
            {
                this.bubingExperience = maxExperience;
            }
        }

        public void AddCommandExperience(int increment)
        {
            if (increment > 0)
            {
                this.commandExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.commandExperience > maxExperience)
                {
                    this.commandExperience = maxExperience;
                }
            }
        }

        public void AddGlamourExperience(int increment)
        {
            if (increment > 0)
            {
                this.glamourExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.glamourExperience > maxExperience)
                {
                    this.glamourExperience = maxExperience;
                }
            }
        }

        public void AddIntelligenceExperience(int increment)
        {
            if (increment > 0)
            {
                this.intelligenceExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.intelligenceExperience > maxExperience)
                {
                    this.intelligenceExperience = maxExperience;
                }
            }
        }

        public void AddInternalExperience(int increment)
        {
            this.internalExperience += (increment * Parameters.InternalExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.internalExperience > maxExperience)
            {
                this.internalExperience = maxExperience;
            }
        }

        public void AddNubingExperience(int increment)
        {
            this.nubingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.nubingExperience > maxExperience)
            {
                this.nubingExperience = maxExperience;
            }
        }

        public void AddPoliticsExperience(int increment)
        {
            if (increment > 0)
            {
                this.politicsExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.politicsExperience > maxExperience)
                {
                    this.politicsExperience = maxExperience;
                }
            }
        }

        public void AddQibingExperience(int increment)
        {
            this.qibingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.qibingExperience > maxExperience)
            {
                this.qibingExperience = maxExperience;
            }
        }

        public void AddQixieExperience(int increment)
        {
            this.qixieExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.qixieExperience > maxExperience)
            {
                this.qixieExperience = maxExperience;
            }
        }

        public void AddShuijunExperience(int increment)
        {
            this.shuijunExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.shuijunExperience > maxExperience)
            {
                this.shuijunExperience = maxExperience;
            }
        }

        public void AddStratagemExperience(int increment)
        {
            this.stratagemExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.stratagemExperience > maxExperience)
            {
                this.stratagemExperience = maxExperience;
            }
        }

        public void AddStrengthExperience(int increment)
        {
            if (increment > 0)
            {
                this.strengthExperience += (int)(increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.strengthExperience > maxExperience)
                {
                    this.strengthExperience = maxExperience;
                }
            }
        }

        public bool AddTacticsExperience(int increment)
        {
            this.tacticsExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.tacticsExperience > maxExperience)
            {
                this.tacticsExperience = maxExperience;
            }
            return true;
        }

        public void AddRecruitmentExperience(int increment)
        {
            if (this.RecruitmentMilitary != null)
            {
                switch (this.RecruitmentMilitary.Kind.Type)
                {
                    case MilitaryType.步兵:
                        this.AddBubingExperience(increment);
                        break;

                    case MilitaryType.弩兵:
                        this.AddNubingExperience(increment);
                        break;

                    case MilitaryType.骑兵:
                        this.AddQibingExperience(increment);
                        break;

                    case MilitaryType.水军:
                        this.AddShuijunExperience(increment);
                        break;

                    case MilitaryType.器械:
                        this.AddQixieExperience(increment);
                        break;
                }
            }
        }

        public void AddTreasureToList(TreasureList list)
        {
            foreach (Treasure treasure in this.Treasures)
            {
                list.Add(treasure);
            }
        }

        public void ApplySkills()
        {
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                skill.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID);
            }
        }

        public void PurifySkills()
        {
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                skill.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID);
            }
        }

        internal void ApplyStunts()
        {
            if ((this.LocationTroop != null) && (this.LocationTroop.Leader == this))
            {
                this.LocationTroop.Stunts.Clear();
                foreach (Stunt stunt in this.Stunts.Stunts.Values)
                {
                    this.LocationTroop.Stunts.AddStunt(stunt);
                }
            }
        }

        public void ApplyTitles()
        {
            if (this.PersonalTitle != null)
            {
                this.PersonalTitle.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.PersonalTitle, 0);
            }
            if (this.CombatTitle != null)
            {
                this.CombatTitle.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.CombatTitle, 0);
            }
        }

        public void PurifyTitles()
        {
            if (this.PersonalTitle != null)
            {
                this.PersonalTitle.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.PersonalTitle, 0);
            }
            if (this.CombatTitle != null)
            {
                this.CombatTitle.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.CombatTitle, 0);
            }
        }

        public void PurifyTreasures()
        {
            foreach (Treasure treasure in this.Treasures)
            {
                treasure.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.ID);
            }
        }

        public void ApplyTreasures()
        {
            foreach (Treasure treasure in this.Treasures)
            {
                treasure.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.ID);
            }
        }

        public void AwardedTreasure(Treasure t)
        {
            this.ReceiveTreasure(t);
            if (this.Loyalty <= 110)
            {
                if (this.OnBeAwardedTreasure != null)
                {
                    this.OnBeAwardedTreasure(this, t);
                }
                this.IncreaseLoyalty(t.Worth);
            }
        }

        private bool BeAvailable()
        {
            Architecture gameObject = base.Scenario.Architectures.GetGameObject(this.AvailableLocation) as Architecture;
            if (gameObject == null)
            {
                this.AvailableLocation = (base.Scenario.Architectures[GameObject.Random(base.Scenario.Architectures.Count)] as Architecture).ID;
                gameObject = base.Scenario.Architectures.GetGameObject(this.AvailableLocation) as Architecture;
            }
            if (gameObject != null)
            {
				ExtensionInterface.call("PersonBecomeAvailable", new Object[] { this.Scenario, this });
                base.Scenario.PreparedAvailablePersons.Add(this);
                return true;
            }
            return false;
        }

        public void ChangeFaction(GameObjects.Faction faction)
        {
            this.Status = PersonStatus.Normal;
            this.YearJoin = base.Scenario.Date.Year;
            this.InitialLoyalty();
        }

        public static int ChanlengeWinningChance(Person source, Person destination)
        {
            int num = 0;
            if (source.Strength >= destination.Strength)
            {
                num = ((50 + ((int) Math.Round(Math.Pow((double) (source.Strength - destination.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
            }
            else
            {
                num = ((50 - ((int) Math.Round(Math.Pow((double) (destination.Strength - source.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
            }
            if (num > 100)
            {
                return 100;
            }
            if (num < 0)
            {
                return 0;
            }
            return num;
        }

        public Architecture BelongedArchitecture
        {
            get
            {
                if (this.IsCaptive)
                {
                    foreach (Captive c in base.Scenario.Captives)
                    {
                        if (c.ID == this.ID && c.CaptiveFaction != null)
                        {
                            return c.CaptiveFaction.Capital;
                        }
                    }
                }
                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.StartingArchitecture;
                }
                return null;
            }
        }

        public void ToDeath()
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            GameObjects.Faction belongedFaction = this.BelongedFaction;
            this.Alive = false;  //死亡
            this.BelongedCaptive = null;
            this.LocationArchitecture = null;
            this.Status = PersonStatus.None;
            if (this.OnDeath != null && locationArchitecture !=null )
            {
                this.OnDeath(this, locationArchitecture);
            }
            if (belongedFaction != null && this == belongedFaction.Leader)
            {
                string name = belongedFaction.Name;
                base.Scenario.YearTable.addKingDeathEntry(base.Scenario.Date, this, belongedFaction);
                GameObjects.Faction faction2 = belongedFaction.ChangeLeaderAfterLeaderDeath();
                if (faction2 != null)
                {
                    if (belongedFaction == faction2)
                    {
                        bool changeName = false;
                        if ((name == this.Name) && (belongedFaction.Leader.Ambition >= (int) PersonAmbition.普通))
                        {
                            belongedFaction.Name = belongedFaction.Leader.Name;
                            changeName = true;
                        }
                        if (this.OnChangeLeader != null)
                        {
                            this.OnChangeLeader(belongedFaction, belongedFaction.Leader, changeName, name);
                        }
                    }
                    else if (this.OnDeathChangeFaction != null)
                    {
                        this.OnDeathChangeFaction(this, faction2.Leader, name);
                    }
                }
                else
                {
                    foreach (Architecture architecture2 in belongedFaction.Architectures.GetList())
                    {
                        architecture2.ResetFaction(null);
                    }
                    belongedFaction.Destroy();
                }
            }
            else
            {

                Treasure baowu;

                while (this.Treasures.Count > 0)
                {
                    baowu = (Treasure)this.Treasures[0];
                    this.LoseTreasure(baowu);
                    baowu.Available = false;
                    baowu.HidePlace = locationArchitecture;
                }
            }
			ExtensionInterface.call("PersonDie", new Object[] { this.Scenario, this });
        }

        private void CheckDeath()
        {


            if ((GlobalVariables.PersonNaturalDeath && ((this.LocationArchitecture != null) && !this.IsCaptive)) && (this.alive && ((((((this.DeadReason == PersonDeadReason.自然死亡) && (this.YearDead <= base.Scenario.Date.Year)) && (GameObject.Random(base.Scenario.Date.LeftDays * ((1 + this.YearDead) - base.Scenario.Date.Year)) == 0)) || (((this.DeadReason == PersonDeadReason.被杀死) && (this.Age >= 80)) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.郁郁而终) && (this.YearDead <= base.Scenario.Date.Year)) && (((this.Age >= 80) || (this.BelongedFaction == null)) || ((this.BelongedFaction.Leader != this) || (this.BelongedFaction.ArchitectureTotalSize < 8)))) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.操劳过度) && (this.YearDead <= base.Scenario.Date.Year)) && ((this.Age >= 80) || ((((((((this.InternalExperience + this.TacticsExperience) + this.StratagemExperience) + this.BubingExperience) + this.NubingExperience) + this.QibingExperience) + this.QibingExperience) + this.ShuijunExperience) > 0x7530))) && (GameObject.Random(90) == 0)))))
            {
                this.ToDeath();
            }
        }

        public Troop BelongedTroop
        {
            get
            {
                foreach (Troop t in base.Scenario.Troops.GameObjects)
                {
                    if (t.Persons.GameObjects.Contains(this))
                    {
                        return t;
                    }
                }
                return null;
            }
        }

        public void ApplyFactionInfluence()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        if (i.Kind.Type != GameObjects.Influences.InfluenceType.战斗)
                        {
                            i.ApplyInfluence(this, GameObjects.Influences.Applier.Technique, t.ID);
                        }
                        else
                        {
                            Troop a = this.LocationTroop;
                            if (a != null && a.Leader == this)
                            {
                                i.ApplyInfluence(a, GameObjects.Influences.Applier.Technique, t.ID);
                            }
                        }
                    }
                }
            }
        }

        public void PurifyFactionInfluence()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        if (i.Kind.Type != GameObjects.Influences.InfluenceType.战斗)
                        {
                            i.PurifyInfluence(this, GameObjects.Influences.Applier.Technique, t.ID);
                        }
                        else
                        {
                            Troop a = this.LocationTroop;
                            if (a != null && a.Leader == this)
                            {
                                i.PurifyInfluence(a, GameObjects.Influences.Applier.Technique, t.ID);
                            }
                        }
                    }
                }
            }
        }

        public void ApplyArchitectureInfluence()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                foreach (Influences.Influence i in this.LocationArchitecture.Characteristics.Influences.Values)
                {
                    i.ApplyInfluence(this, GameObjects.Influences.Applier.Characteristics, 0);
                }
                if (this.LocationArchitecture.FacilityEnabled)
                {
                    foreach (Facility f in this.LocationArchitecture.Facilities.GameObjects)
                    {
                        foreach (Influences.Influence i in f.Influences.Influences.Values)
                        {
                            i.ApplyInfluence(this, GameObjects.Influences.Applier.Facility, f.ID);
                        }
                    }
                }
            }
        }

        public void PurifyArchitectureInfluence()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                foreach (Influences.Influence i in this.LocationArchitecture.Characteristics.Influences.Values)
                {
                    i.PurifyInfluence(this, GameObjects.Influences.Applier.Characteristics, 0);
                }
                if (this.LocationArchitecture.FacilityEnabled)
                {
                    foreach (Facility f in this.LocationArchitecture.Facilities.GameObjects)
                    {
                        foreach (Influences.Influence i in f.Influences.Influences.Values)
                        {
                            i.PurifyInfluence(this, GameObjects.Influences.Applier.Facility, f.ID);
                        }
                    }
                }
            }
        }

        public void ConfiscatedTreasure(Treasure t)
        {
            this.LoseTreasure(t);
            if (this.Loyalty <= 110)
            {
                if (this.OnBeConfiscatedTreasure != null)
                {
                    this.OnBeConfiscatedTreasure(this, t);
                }
                this.DecreaseLoyalty(t.Worth * 2);
                if (GameObject.Random(this.Loyalty) <= GameObject.Random(10))
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LeaveToNoFaction();
                    }
                }
            }
			ExtensionInterface.call("ConfiscatedTreasure", new Object[] { this.Scenario, this });
        }

        public static int ControversyWinningChance(Person source, Person destination)
        {
            int num = 0;
            int controversyAbility = source.ControversyAbility;
            int num3 = destination.ControversyAbility;
            num = (((50 + controversyAbility) - num3) + source.IncrementOfControversyWinningChance) - destination.IncrementOfControversyWinningChance;
            if (num > 100)
            {
                return 100;
            }
            if (num < 0)
            {
                return 0;
            }
            return num;
        }

        public void DayEvent()
        {
            this.CheckDeath();
            if (this.Alive)
            {
                this.LeaveFaction();
                this.NoFactionMove();
                this.LoyaltyChange();
                this.ProgressArrivingDays();
                this.huaiyunshijian();
                this.doNotMovePeriodReduction();
            }
        }

        private void huaiyunshijian()
        {
            if (this.huaiyun)
            {
                this.huaiyuntianshu++;
                //if (this.huaiyuntianshu == 30)
                if (GameObject.Chance((this.huaiyuntianshu - 20) * 5) && !this.faxianhuaiyun)
                {
					ExtensionInterface.call("FoundPregnant", new Object[] { this.Scenario, this });
                    this.faxianhuaiyun = true;
                    if (this.BelongedFaction != null && this == this.BelongedFaction.Leader)  //女君主自己怀孕
                    {
                    }
                    else 
                    {
                        this.Scenario.GameScreen.faxianhuaiyun(this);
                    }
                }
                else if (GameObject.Chance((this.huaiyuntianshu - 290) * 5))
                {
                    Person haizifuqin = new Person();
                    Person haizi = new Person();
                    this.huaiyun = false;
                    this.faxianhuaiyun = false;
                    this.huaiyuntianshu = -1;

                    if (this.suoshurenwu == -1)
                    {
                        this.suoshurenwu = this.LocationArchitecture.BelongedFaction.LeaderID;
                    }
                    haizifuqin = this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person;

                    if (haizifuqin != null)
                    {
                        PersonList origChildren = haizifuqin.meichushengdehaiziliebiao();
                        if (origChildren.Count > 0)
                        {
                            haizi = origChildren[0] as Person;
                            haizi.father = this.Sex ? haizifuqin.ID : this.ID;
                            haizi.mother = this.Sex ? this.ID : haizifuqin.ID;
                        }
                        else
                        {
                            haizi = Person.createChildren(this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person, this);
                        }

                        base.Scenario.YearTable.addChildrenBornEntry(base.Scenario.Date, haizifuqin, this, haizi);

                        haizifuqin.TextResultString = haizi.Name;

                        base.Scenario.GameScreen.xiaohaichusheng(haizifuqin, haizi);
                        base.Scenario.haizichusheng(haizi, haizifuqin, this, origChildren.Count > 0);

                        haizifuqin.suoshurenwu = -1;
                    }

                    this.suoshurenwu = -1;

                }
            }
        }



        public int Uncruelty
        {
            get
            {
                return Enum.GetNames(typeof(PersonAmbition)).Length - (int)this.Ambition + (int)this.PersonalLoyalty + 1;
            }
        }

        public int NumberOfChildren
        {
            get
            {
                int cnt = 0;
                foreach (Person p in base.Scenario.Persons)
                {
                    if ((p.Father == this.ID || p.Mother == this.ID) && p.Available)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
        }

        public int DecreaseLoyalty(int decrement)
        {
            if (decrement > this.Loyalty)
            {
                decrement = this.Loyalty;
            }
            this.loyalty -= decrement;
            return decrement;
        }

        public void DoConvince()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.ConvincingPerson != null && this.BelongedFaction != null)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
                if ((architectureByPosition != null) && ((architectureByPosition.BelongedFaction != null) && (this.ConvincingPerson.IsCaptive || (architectureByPosition.BelongedFaction != this.BelongedFaction))))
                {
                    bool ConvinceSuccess;
                    int idealOffset = Person.GetIdealOffset(this.ConvincingPerson, this.BelongedFaction.Leader);

                    if (this.ConvincingPerson.BelongedFaction == null)
                    {
                        ConvinceSuccess =
                                (
                        ((this.ConvincingPerson.IsCaptive && architectureByPosition.IsCaptiveInArchitecture(this.ConvincingPerson.BelongedCaptive))
                        || (this.ConvincingPerson.LocationArchitecture == architectureByPosition))
                        && (
                        (
                            
                            ((this.ConvincingPerson.BelongedFaction == null) && (this.ConvincingPerson.IsCaptive))
                        )
                        && ((this.ConvincingPerson.Loyalty < 100))))
                        && (!this.ConvincingPerson.HatedPersons.Contains(this.BelongedFaction.LeaderID))
                        && (!GlobalVariables.IdealTendencyValid || (idealOffset <= this.ConvincingPerson.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                        && (GameObject.Random((this.ConvinceAbility - (this.ConvincingPerson.Loyalty * 2)) - ((int)this.ConvincingPerson.PersonalLoyalty * (int)((PersonLoyalty)0x19))) > this.ConvincingPerson.Loyalty);
                        
                        ConvinceSuccess |= !base.Scenario.IsPlayer(this.BelongedFaction) && GlobalVariables.AIAutoTakeNoFactionCaptives;
                        // 当被登用武将在野并且亲爱登用武将的君主或登用武将自己时，一定被登用
                        ConvinceSuccess |= (this.ConvincingPerson.closePersons.Contains(this.BelongedFaction.LeaderID)) || (this.ConvincingPerson.closePersons.Contains(this.ID));
                        ConvinceSuccess |= (this.ConvincingPerson.Spouse == this.BelongedFaction.LeaderID) || (this.ConvincingPerson.Brother == this.BelongedFaction.LeaderID) || (this.ConvincingPerson.Brother == this.ID);
                    }
                    else
                    {
                               ConvinceSuccess =
                                   (
                            ((this.ConvincingPerson.IsCaptive && architectureByPosition.IsCaptiveInArchitecture(this.ConvincingPerson.BelongedCaptive))
                            || (this.ConvincingPerson.LocationArchitecture == architectureByPosition)) 
                            && (
                            (
                                ((this.ConvincingPerson.BelongedFaction != null) && (this.BelongedFaction != this.ConvincingPerson.BelongedFaction))
                                
                            )
                            && ((this.ConvincingPerson != this.ConvincingPerson.BelongedFaction.Leader) && (this.ConvincingPerson.Loyalty < 100))))
                            && (!this.ConvincingPerson.HatedPersons.Contains(this.BelongedFaction.LeaderID))
                            && (!GlobalVariables.IdealTendencyValid || (idealOffset <= this.ConvincingPerson.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                            && (GameObject.Random((this.ConvinceAbility - (this.ConvincingPerson.Loyalty * 2)) - ((int)this.ConvincingPerson.PersonalLoyalty *(int) ((PersonLoyalty) 0x19))) > this.ConvincingPerson.Loyalty);

                        ConvinceSuccess |= !base.Scenario.IsPlayer(this.BelongedFaction) && base.Scenario.IsPlayer(this.ConvincingPerson.BelongedFaction) && 
                            GlobalVariables.AIAutoTakePlayerCaptives && (!GlobalVariables.AIAutoTakePlayerCaptiveOnlyUnfull || this.ConvincingPerson.Loyalty < 100);
                        //兄弟相互说服
                        ConvinceSuccess |= ((this.ConvincingPerson.Brother == this.Brother) && (this.ConvincingPerson.Brother != this.ConvincingPerson.BelongedFaction.LeaderID));
                    }
                    ConvinceSuccess = ConvinceSuccess && (!this.BelongedFaction.IsAlien || (int)this.ConvincingPerson.PersonalLoyalty < 2);  //异族只能说服义理为2以下的武将。
                    //这样配偶和义兄可以无视一切条件强登被登用武将 (当是君主的配偶或者义兄弟)
                    ConvinceSuccess |= (this.ConvincingPerson.Spouse == this.BelongedFaction.LeaderID) || (this.ConvincingPerson.Brother == this.BelongedFaction.LeaderID);

                    if (ConvinceSuccess)
                    {
                        GameObjects.Faction belongedFaction = null;
                        if (this.ConvincingPerson.BelongedFaction != null)
                        {
                            belongedFaction = this.ConvincingPerson.BelongedFaction;
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.ConvincingPerson.BelongedFaction.ID, -10);
                            if (this.ConvincingPerson.BelongedFaction.Leader.hasStrainTo(this.ConvincingPerson))
                            {
                                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.ConvincingPerson.BelongedFaction.ID, -10);
                            }
                            if (this.ConvincingPerson.BelongedFaction.Leader.hasCloseStrainTo(this.ConvincingPerson))
                            {
                                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.ConvincingPerson.BelongedFaction.ID, -10);
                            }
                            this.ConvincingPerson.RebelCount++;
                        }

                        Architecture from = null;
                        if (this.ConvincingPerson.IsCaptive)
                        {
                            from = this.ConvincingPerson.BelongedCaptive.LocationArchitecture;
                            this.ConvincingPerson.Status = PersonStatus.Normal;
                            this.ConvincingPerson.BelongedCaptive = null;
                        }
                        else
                        {
                            from = this.ConvincingPerson.LocationArchitecture;
                        }

                        this.ConvincingPerson.ChangeFaction(this.BelongedFaction);
                        if (from == null)
                        {
                            this.ConvincingPerson.MoveToArchitecture(this.TargetArchitecture, null);
                        }
                        else
                        {
                            this.ConvincingPerson.MoveToArchitecture(this.TargetArchitecture, from.ArchitectureArea.Area[0]);
                        }

                        /*if (!(flag || (this.ConvincingPerson.LocationArchitecture == null)))
                        {
                            this.ConvincingPerson.LocationArchitecture.RemovePerson(this.ConvincingPerson);
                        }*/
                        this.AddGlamourExperience(40);
                        this.IncreaseReputation(40);
                        this.BelongedFaction.IncreaseReputation(20 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((20 * this.MultipleOfTacticsTechniquePoint) * 100);
						ExtensionInterface.call("DoConvinceSuccess", new Object[] { this.Scenario, this });
                        if (this.OnConvinceSuccess != null)
                        {
                            this.OnConvinceSuccess(this, this.ConvincingPerson, belongedFaction);
                        }
                        if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                        {
                            CheckCapturedByArchitecture(architectureByPosition);
                        }
                    }
                    else 
                    {
						ExtensionInterface.call("DoConvinceFail", new Object[] { this.Scenario, this });
						if (this.OnConvinceFailed != null) {
							this.OnConvinceFailed(this, this.ConvincingPerson);
						}
                    }
                }
            }
        }

        public void DoDestroy()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                {
                    if ((architectureByPosition.Endurance > 0) && (this.InevitableSuccessOfDestroy || (GameObject.Random(architectureByPosition.Domination * 8) < GameObject.Random(this.DestroyAbility))))
                    {
                        int randomValue = StaticMethods.GetRandomValue(this.DestroyAbility, 12);
                        randomValue = architectureByPosition.DecreaseEndurance(randomValue);
                        int increment = randomValue / 4;
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.AddStrengthExperience(increment / 2);
                        this.AddCommandExperience(increment / 2);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        if (this.OnDestroySuccess != null)
                        {
                            this.OnDestroySuccess(this, architectureByPosition, randomValue);
                        }
                        architectureByPosition.DecrementNumberList.AddNumber(randomValue, CombatNumberKind.人数, architectureByPosition.Position);
						ExtensionInterface.call("DoDestroySuccess", new Object[] { this.Scenario, this, randomValue });
                    }
                    else 
                    {
						ExtensionInterface.call("DoDestroyFail", new Object[] { this.Scenario, this });
						if (this.OnDestroyFailed != null) {
							this.OnDestroyFailed(this, architectureByPosition);
						}
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else if (this.OnDestroyFailed != null)
                {
					ExtensionInterface.call("DoDestroyFail", new Object[] { this.Scenario, this });
                    this.OnDestroyFailed(this, architectureByPosition);
                }
            }
        }
        public void DoHouGong()
        {
            this.OutsideTask = OutsideTaskKind.无;

        }




        public void DoGossip()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if ((architectureByPosition.BelongedFaction != null) && (this.BelongedFaction != architectureByPosition.BelongedFaction))
                {
                    if (this.InevitableSuccessOfGossip || (GameObject.Random(architectureByPosition.Domination * 5) < GameObject.Random(this.GossipAbility)))
                    {
                        architectureByPosition.DamageByGossip(this.GossipAbility);
                        this.AddTacticsExperience(20);
                        this.AddPoliticsExperience(10);
                        this.AddGlamourExperience(10);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
						ExtensionInterface.call("DoGossipSuccess", new Object[] { this.Scenario, this });
                        if (this.OnGossipSuccess != null)
                        {
                            this.OnGossipSuccess(this, architectureByPosition);
                        }
                    }
                    else 
                    {
						ExtensionInterface.call("DoGossipFail", new Object[] { this.Scenario, this });
						if (this.OnGossipFailed != null) {
							this.OnGossipFailed(this, architectureByPosition);
						}
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else 
                {
					ExtensionInterface.call("DoGossipFail", new Object[] { this.Scenario, this });
					if (this.OnGossipFailed != null) {
						this.OnGossipFailed(this, architectureByPosition);
					}
                }
            }
        }

        public void DoInformation()
        {
            if (!base.Scenario.IsPlayer(this.BelongedFaction) || (this.InformationAbility >90 && GameObject.Random(280) < this.InformationAbility))
                    {
                        Information information = new Information();
                        information.Scenario = base.Scenario;
                        information.ID = base.Scenario.Informations.GetFreeGameObjectID();
                        information.Level = this.CurrentInformationKind.Level;
                        information.Radius = this.CurrentInformationKind.Radius + this.RadiusIncrementOfInformation + 
                            (this.InformationAbility + GameObject.Random(100) - 50) / 200;
                        information.Position = this.OutsideDestination.Value;
                        information.Oblique = this.CurrentInformationKind.Oblique;
                        information.DaysLeft = (int) Math.Max(5, this.CurrentInformationKind.Days * (this.InformationAbility / 300.0 + 0.5));
						
                        base.Scenario.Informations.AddInformation(information);
                        this.BelongedFaction.AddInformation(information);

                        information.Apply();

                        this.CurrentInformationKind = null;
                        this.OutsideTask = OutsideTaskKind.无;

                        int increment = (int)(((int)information.Level - 2) * (information.Radius + (information.Oblique ? 1 : 0)));
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
						ExtensionInterface.call("DoInformationSuccess", new Object[] { this.Scenario, this, information });
                        if (this.OnInformationObtained != null)
                        {
                            this.OnInformationObtained(this, information);
                        }
 
                    }
            else
                    {
                        int increment = (int)(((int)this.CurrentInformationKind.Level - 2) * (this.CurrentInformationKind.Radius + (this.CurrentInformationKind.Oblique? 1 : 0)));
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.CurrentInformationKind = null;
                        this.OutsideTask = OutsideTaskKind.无;
						ExtensionInterface.call("DoInformationFail", new Object[] { this.Scenario, this });
                        if (this.qingbaoshibaishijian != null)
                        {
                            this.qingbaoshibaishijian(this);
                        }
                    }

        }

        public void DoInstigate()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                {
                    if ((architectureByPosition.Domination > 0) && (this.InevitableSuccessOfInstigate || (GameObject.Random((architectureByPosition.Morale * 2) + 200) < GameObject.Random(this.InstigateAbility))))
                    {
                        int randomValue = StaticMethods.GetRandomValue(this.InstigateAbility, 60);
                        randomValue = architectureByPosition.DecreaseDomination(randomValue);
                        int increment = randomValue / 1;
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.AddGlamourExperience(increment);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        if (this.OnInstigateSuccess != null)
                        {
                            this.OnInstigateSuccess(this, architectureByPosition, randomValue);
                        }
                        architectureByPosition.DecrementNumberList.AddNumber(randomValue, CombatNumberKind.士气, architectureByPosition.Position);
						ExtensionInterface.call("DoInstigateSuccess", new Object[] { this.Scenario, this, randomValue });
                    }
                    else 
                    {
						ExtensionInterface.call("DoinstigateFail", new Object[] { this.Scenario, this });
						if (this.OnInstigateFailed != null){
							this.OnInstigateFailed(this, architectureByPosition);
						}
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else 
                {
					ExtensionInterface.call("DoinstigateFail", new Object[] { this.Scenario, this });
					if (this.OnInstigateFailed != null){
						this.OnInstigateFailed(this, architectureByPosition);
					}
                }
            }
        }

        public void DoEnhanceDiplomatic()
        {
            /*
            亲善
            势力间友好度上升=(c*20+max(执行武将政治-执行武将和目标势力君主的相性差/2,0)+100)/10
            系数c取决于执行武将和目标势力君主的关系，两者是义兄弟、配偶或者是目标君主的亲爱武将取2，是目标君主的厌恶武将取-1，否则取1
            如果难度为上级，则效果*0.8；如果难度为超级，则效果为*0.7 (这个部分可调整)
            执行武将名声+50，政治经验+5
            */ 
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            this.OutsideDestination = null;
            if ((this.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction != null))
            {
                //int g = (5 + (int)(5 * this.Glamour / 100));
                int c = 2;
                if ((this.Spouse == this.TargetArchitecture.BelongedFaction.LeaderID || (this.Brother == this.TargetArchitecture.BelongedFaction.Leader.Brother && this.Brother > 0))
                    || this.TargetArchitecture.BelongedFaction.Leader.closePersons.Contains(this.ID))
                {
                    c = 3;
                }
                if (this.TargetArchitecture.BelongedFaction.Leader.hatedPersons.Contains(this.ID))
                {
                    c = -2;
                }
                int g = (((c * 10 + Math.Max((this.politics - GetIdealOffset(this, this.TargetArchitecture.BelongedFaction.Leader) / 2) , 0 )) +100) / 10);
                int cd = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID);
                if (((cd + g) > 290) && cd < 300)
                {
                    g = 290 - cd;
                }
                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, g);
                this.TargetArchitecture.Fund += 10000;
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                this.TargetArchitecture = this.LocationArchitecture;
                this.AddPoliticsExperience(5);
                this.IncreaseReputation(50);
            }
        }

        public void DoAllyDiplomatic()
        {
            /*
            同盟
        a、判定值=（金钱/150+执行武将政治-执行武将和目标势力君主的相性差/5+c*10）*t
        b、判定
        如果执行武将没有论客特技，且为执行势力君主为目标势力君主的厌恶武将，则必失败被捕
        如果判定值> 180，则成功
        否则执行武将有论客特技或者判定值>(80-势力间友好度)*2，则失败
        否则失败被捕（注：游戏中的实际效果和失败相同）
        c、结果
        1、成功
        势力间友好度+36 (大于300)
        执行武将功绩+500，政治经验+5
        势力技术点:50
        2、失败
        势力间友好度-10
        执行武将功绩+50，政治经验+1
        3、失败被捕（注：实际效果和失败相同）
            */
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            this.OutsideDestination = null;
            if ((this.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction != null))
            {
                int c = 2;
                if ((this.Spouse == this.TargetArchitecture.BelongedFaction.LeaderID || (this.Brother == this.TargetArchitecture.BelongedFaction.Leader.Brother && this.Brother > 0))
                    || this.TargetArchitecture.BelongedFaction.Leader.closePersons.Contains(this.ID))
                {
                    c = 3;
                }
                if (this.TargetArchitecture.BelongedFaction.Leader.hatedPersons.Contains(this.ID))
                {
                    c = -2;
                }
                int g = (c * 10 + (20000 / 150) + this.politics - GetIdealOffset(this, this.TargetArchitecture.BelongedFaction.Leader) / 5);
                int cd = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID);
                if (g > 180)
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, 36);
                    this.TargetArchitecture.Fund += 20000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, "AllyDiplomaticRelation", "AllyDiplomaticRelation.jpg", "AllyDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(5);
                    this.IncreaseReputation(500);
                }
                else
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, -10);
                    this.BelongedArchitecture.Fund += 20000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, "AllyDiplomaticRelationFailed", "chuzhan.jpg", "BreakDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(1);
                    this.IncreaseReputation(50);
                }
            }
        }


        private void DoOutsideTask()
        {
            switch (this.OutsideTask)
            {
                case OutsideTaskKind.说服:
                    this.DoConvince();
                    break;

                case OutsideTaskKind.情报:
                    this.DoInformation();
                    break;

                case OutsideTaskKind.间谍:
                    this.DoSpy();
                    break;

                case OutsideTaskKind.破坏:
                    this.DoDestroy();
                    break;

                case OutsideTaskKind.煽动:
                    this.DoInstigate();
                    break;

                case OutsideTaskKind.流言:
                    this.DoGossip();
                    break;

                case OutsideTaskKind.搜索:
                    this.DoSearch();
                    break;

                case OutsideTaskKind.技能:
                    this.DoStudySkill();
                    break;

                case OutsideTaskKind.称号:
                    this.DoStudyTitle();
                    break;

                case OutsideTaskKind.特技:
                    this.DoStudyStunt();
                    break;

                case OutsideTaskKind.后宮:
                    this.DoHouGong();
                    break;

                case OutsideTaskKind.亲善:
                    this.DoEnhanceDiplomatic();
                    break;

                case OutsideTaskKind.结盟:
                    this.DoAllyDiplomatic();
                    break;

            }
        }

        public void DoSearch()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if ((this.TargetArchitecture != null) && (this.TargetArchitecture.BelongedFaction == this.BelongedFaction))
            {
                SearchResultPack pack = new SearchResultPack();
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                if (this.InevitableSuccessOfSearch)
                {
                    pack.Result = (SearchResult) (GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length - 1) + 1);
                }
                else
                {
                    pack.Result = (SearchResult) GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length);
                }
                switch (pack.Result)
                {
                    case SearchResult.资金:
                        flag = this.DoSearchFund(pack);
                        break;

                    case SearchResult.粮草:
                        flag = this.DoSearchFood(pack);
                        break;

                    case SearchResult.技巧:
                        flag = this.DoSearchTechnique(pack);
                        break;

                    case SearchResult.间谍:
                        flag = this.DoSearchSpy(pack);
                        flag2 = flag;
                        break;

                    case SearchResult.隐士:
                        flag = this.DoSearchPerson(pack);
                        flag3 = flag;
                        break;

                    case SearchResult.宝物:
                        flag = this.DoSearchTreasure(pack);
                        flag4 = flag;
                        break;
                }
                if (!flag && this.InevitableSuccessOfSearch)
                {
                    switch (GameObject.Random(3))
                    {
                        case 0:
                            pack.Result = SearchResult.资金;
                            flag = this.DoSearchFund(pack);
                            break;

                        case 1:
                            pack.Result = SearchResult.粮草;
                            flag = this.DoSearchFood(pack);
                            break;

                        case 2:
                            pack.Result = SearchResult.技巧;
                            flag = this.DoSearchTechnique(pack);
                            break;
                    }
                }
                if (flag)
                {
                    this.AddTacticsExperience(20);
                    this.AddIntelligenceExperience(5);
                    this.AddPoliticsExperience(5);
                    this.AddGlamourExperience(10);
                    this.IncreaseReputation(20);
                    this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                    this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                    if (this.OnSearchFinished != null)
                    {
                        this.OnSearchFinished(this, this.TargetArchitecture, pack);
                    }
                }
                else
                {
                    pack.Result = SearchResult.无;
                    if (this.OnSearchFinished != null)
                    {
                        this.OnSearchFinished(this, this.TargetArchitecture, pack);
                    }
                }
				ExtensionInterface.call("DoSearch", new Object[] { this.Scenario, this, pack });
            }
        }

        private bool DoSearchFood(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = this.SearchAbility * 20;
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                this.TargetArchitecture.IncreaseFood(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchFund(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = StaticMethods.GetRandomValue(this.SearchAbility, 2);
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                this.TargetArchitecture.IncreaseFund(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchPerson(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                foreach (Person person in base.Scenario.Persons)
                {
                    if (((((!person.Available && person.Alive) && (person.YearAvailable <= base.Scenario.Date.Year)) && GameObject.Chance(20)) && (person.AvailableLocation == this.TargetArchitecture.ID)) && ((((((GlobalVariables.CommonPersonAvailable && (person.ID >= 0)) && (person.ID <= 0x1b57)) || ((GlobalVariables.AdditionalPersonAvailable && (person.ID >= 0x1f40)) && (person.ID <= 0x2327))) || ((GlobalVariables.PlayerPersonAvailable && (person.ID >= 0x2328)) && (person.ID <= 0x270f))) && !base.Scenario.PreparedAvailablePersons.HasGameObject(person)) && person.BeAvailable()))
                    {
                        pack.FoundPerson = person;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DoSearchSpy(SearchResultPack pack)
        {
            if (this.TargetArchitecture.HasSpy && (this.InevitableSuccessOfSearch || (GameObject.Random(this.SearchAbility + 500) > 500)))
            {
                SpyPack sp = this.TargetArchitecture.SpyPacks[GameObject.Random(this.TargetArchitecture.SpyPacks.Count)];
                if (sp.SpyPerson.BelongedFaction != this.BelongedFaction)
                {
                    if (sp.SpyPerson.BelongedFaction != null)
                    {
                        base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, sp.SpyPerson.BelongedFaction.ID, -10);
                    }
                    if (this.OnSpyFound != null)
                    {
                        this.OnSpyFound(this, sp.SpyPerson);
                    }
                    pack.FoundPerson = sp.SpyPerson;
                }
                this.TargetArchitecture.RemoveSpyPack(sp);
                return true;
            }
            return false;
        }

        private bool DoSearchTechnique(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = this.SearchAbility * 2;
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchTreasure(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                foreach (Treasure treasure in base.Scenario.Treasures.GetRandomList())
                {
                    if (((!treasure.Available && (treasure.BelongedPerson == null)) && (treasure.HidePlace == this.TargetArchitecture)) && (treasure.AppearYear <= base.Scenario.Date.Year))
                    {
                        if (GameObject.Random(treasure.Worth) <= GameObject.Random(Parameters.FindTreasureChance))
                        {
                            treasure.Available = true;
                            //this.ReceiveTreasure(treasure);
                            this.BelongedFaction.Leader.ReceiveTreasure(treasure);
                            if (this.OnTreasureFound != null)
                            {
                                this.OnTreasureFound(this, treasure);
                            }
                        }
                        break;
                    }
                }
            }
            return false;
        }

        public void DoSpy()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if ((architectureByPosition.BelongedFaction != null) && (this.BelongedFaction != architectureByPosition.BelongedFaction))
                {
                    if (this.InevitableSuccessOfSpy || (GameObject.Random((architectureByPosition.Domination * (20 - architectureByPosition.AreaCount)) - architectureByPosition.Commerce) < this.SpyAbility))
                    {
                        architectureByPosition.AddSpyPack(this, this.SpyDays);
                        this.AddTacticsExperience(20);
                        this.AddIntelligenceExperience(10);
                        this.AddStrengthExperience(5);
                        this.AddGlamourExperience(5);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
						ExtensionInterface.call("DoSpySuccess", new Object[] { this.Scenario, this, this.SpyDays });
                        if (this.OnSpySuccess != null)
                        {
                            this.OnSpySuccess(this, architectureByPosition);
                        }
                    }
                    else 
                    {
						ExtensionInterface.call("DoSpyFail", new Object[] { this.Scenario, this });
						if (this.OnSpyFailed != null){
							this.OnSpyFailed(this, architectureByPosition);
						}
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else if (this.OnSpyFailed != null)
                {
					ExtensionInterface.call("DoSpyFail", new Object[] { this.Scenario, this });
					if (this.OnSpyFailed != null){
						this.OnSpyFailed(this, architectureByPosition);
					}
                }
            }
        }

        public int zhenzaiWeighing
        {
            get
            {
                return zhenzaiAbility;
            }
        }
        public bool CheckCapturedByArchitecture(Architecture a)
        {
            if (!(this.ImmunityOfCaptive || GameObject.Random((a.Domination * 10 + a.Morale)) + 200 <= GameObject.Random(this.CaptiveAbility) * 60) ||
                (!this.ImmunityOfCaptive && GameObject.Chance(a.captureChance)))
            {
                this.ArrivingDays = 0;
                this.TargetArchitecture = null;
                this.TaskDays = 0;
                this.OutsideTask = OutsideTaskKind.无;
                Captive captive = Captive.Create(base.Scenario, this, a.BelongedFaction);
                this.Status = PersonStatus.Captive;
                this.LocationArchitecture = a;
				ExtensionInterface.call("CapturedByArchitecture", new Object[] { this.Scenario, this, a });
                if (this.OnCapturedByArchitecture != null)
                {
                    this.OnCapturedByArchitecture(this, a);
                }
                return true;
            }
            return false;
        }

        public int StudyableSkillCount
        {
            get
            {
                int result = 0;
                foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
                {
                    if ((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyableStuntCount
        {
            get
            {
                int result = 0;
                foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
                {
                    if (this.Stunts.GetStunt(stunt.ID) == null && stunt.IsLearnable(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyablePersonalTitleCount
        {
            get
            {
                int result = 0;
                foreach (Title t in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (this.PersonalTitle != t && !t.Combat && t.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyableCombatTitleCount
        {
            get
            {
                int result = 0;
                foreach (Title t in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (this.CombatTitle != t && t.Combat && t.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyableHigherLevelPersonalTitleCount
        {
            get
            {
                if (this.PersonalTitle == null) return this.StudyablePersonalTitleCount;
                int result = 0;
                foreach (Title t in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (this.PersonalTitle != t && !t.Combat && t.Level > this.PersonalTitle.Level && t.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyableHigherLevelCombatTitleCount
        {
            get
            {
                if (this.CombatTitle == null) return this.StudyableCombatTitleCount;
                int result = 0;
                foreach (Title t in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (this.CombatTitle != t && t.Combat && t.Level > this.CombatTitle.Level && t.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public void DoStudySkill()
        {
            this.OutsideTask = OutsideTaskKind.无;
            int num = 0;
            string skillString = "";
            foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                if (((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this)) && (GameObject.Random((skill.Level * 2) + 8) >= ((skill.Level + num) * 2)))
                {
                    this.Skills.AddSkill(skill);
                    skill.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID);
                    skillString = skillString + "•" + skill.Name;
                    num++;
					ExtensionInterface.call("StudySkill", new Object[] { this.Scenario, this, skill });
                }
            }
            if (this.OnStudySkillFinished != null&&this.ManualStudy )
            {
                this.OnStudySkillFinished(this, skillString, num > 0);
                
            }
            this.ManualStudy = false;
        }

        public void DoStudyStunt()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingStunt != null)
            {
                if (GameObject.Chance(0x4b))
                {
                    this.Stunts.AddStunt(this.StudyingStunt);
					ExtensionInterface.call("StudyStuntSuccess", new Object[] { this.Scenario, this, this.StudyingStunt });
                    if (this.OnStudyStuntFinished != null && this.ManualStudy)
                    {
                        this.OnStudyStuntFinished(this, this.StudyingStunt, true);
                    }
                }
                else 
                {
					ExtensionInterface.call("StudyStuntFail", new Object[] { this.Scenario, this, this.StudyingStunt });
					if (this.OnStudyStuntFinished != null && this.ManualStudy) {
						this.OnStudyStuntFinished(this, this.StudyingStunt, false);
					}
                }
                this.StudyingStunt = null;
            }
            this.ManualStudy = false;
        }

        public void DoStudyTitle()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingTitle != null)
            {
                bool flag = false;
                if (GameObject.Random((this.StudyingTitle.Level * 2) + 8) >= (this.StudyingTitle.Level * 2))
                {
                    if (this.StudyingTitle.Kind == TitleKind.个人)
                    {
                        if (this.PersonalTitle != null)
                        {
                            this.PersonalTitle.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.PersonalTitle, 0);
                            flag = true;
                        }
                        this.PersonalTitle = this.StudyingTitle;
                    }
                    else
                    {
                        if (this.StudyingTitle.Kind != TitleKind.战斗)
                        {
                            return;
                        }
                        if (this.CombatTitle != null)
                        {
                            this.CombatTitle.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.CombatTitle, 0);
                            flag = true;
                        }
                        this.CombatTitle = this.StudyingTitle;
                    }
                    if (flag)
                    {
                        this.ApplyTitles();
                        this.ApplySkills();
                    }
					ExtensionInterface.call("StudyTitleSuccess", new Object[] { this.Scenario, this, this.StudyingTitle });
                    if (this.OnStudyTitleFinished != null && this.ManualStudy)
                    {
                        this.OnStudyTitleFinished(this, this.StudyingTitle, true);
                    }
                }
                else 
                {
					ExtensionInterface.call("StudyTitleFail", new Object[] { this.Scenario, this, this.StudyingTitle });
					if (this.OnStudyTitleFinished != null && this.ManualStudy) {
						this.OnStudyTitleFinished(this, this.StudyingTitle, false);
					}
                }
                this.StudyingTitle = null;
                this.ManualStudy = false;
            }
        }

        public GameObjectList GetCombatTitleInfluenceList()
        {
            if (this.CombatTitle == null)
            {
                return null;
            }
            return this.CombatTitle.GetInfluenceList();
        }

        public GameObjectList GetHirableFactionList()
        {
            GameObjectList list = new GameObjectList();
            foreach (GameObjects.Faction faction in base.Scenario.Factions)
            {
                if (this.IsHirable(faction))
                {
                    list.Add(faction);
                }
            }
            return list;
        }

        public static int GetIdealOffset(Person p1, Person p2)
        {
            int num = Math.Abs((int) (p1.Ideal - p2.Ideal));
            if (num > 75)
            {
                num = 150 - num;
            }
            return num;
        }

        public bool YoukenengChuangjianXinShili()
        {
            if (this.LeaderPossibility == false || this.IsCaptive || this.LocationArchitecture == null || 
                (this.Status != PersonStatus.Normal && this.Status != PersonStatus.NoFaction))
            {
                return false;
            }
            
            if (this.BelongedFaction == null)
            {

                return true;
            }
            else
            {
                if (GlobalVariables.WujiangYoukenengDuli == false) return false;
                if (this == this.BelongedFaction.Leader) return false;
                if (this.Father >= 0 && this.Father == this.BelongedFaction.Leader.ID) return false;  //隐含父亲活着，下同。
                if (this.Mother >= 0 && this.Mother == this.BelongedFaction.Leader.ID) return false;
                if (this.Spouse >= 0 && this.Spouse == this.BelongedFaction.Leader.ID) return false;
                if (this.Brother >= 0 && this.Brother == this.BelongedFaction.Leader.ID) return false;
                if (this.Strain == this.BelongedFaction.Leader.Strain) return false;  //同一血缘不能独立，孙子不能从爷爷手下独立。
                return true; 
            }

        }

        public GameObjectList GetPersonalTitleInfluenceList()
        {
            if (this.PersonalTitle == null)
            {
                return null;
            }
            return this.PersonalTitle.GetInfluenceList();
        }

        public GameObjectList GetSkillList()
        {
            return this.Skills.GetSkillList();
        }

        public GameObjectList GetStuntList()
        {
            return this.Stunts.GetStuntList();
        }

        public GameObjectList GetStudyStuntList()
        {
            this.StudyStuntList.Clear();
            foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
            {
                if ((this.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(this))
                {
                    this.StudyStuntList.Add(stunt);
                }
            }
            return this.StudyStuntList;
        }

        public GameObjectList GetStudyTitleList()
        {
            this.StudyTitleList.Clear();
            foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                if (((title != this.PersonalTitle) && (title != this.CombatTitle)) && title.CanLearn(this))
                {
                    this.StudyTitleList.Add(title);
                }
            }
            return this.StudyTitleList;
        }

        public int GetWorkAbility(ArchitectureWorkKind workKind)
        {
            switch (workKind)
            {
                case ArchitectureWorkKind.无:
                    return 0;

                case ArchitectureWorkKind.赈灾 :
                    return this.zhenzaiAbility;

                case ArchitectureWorkKind.农业:
                    return this.AgricultureAbility;

                case ArchitectureWorkKind.商业:
                    return this.CommerceAbility;

                case ArchitectureWorkKind.技术:
                    return this.TechnologyAbility;

                case ArchitectureWorkKind.统治:
                    return this.DominationAbility;

                case ArchitectureWorkKind.民心:
                    return this.MoraleAbility;

                case ArchitectureWorkKind.耐久:
                    return this.EnduranceAbility;

                case ArchitectureWorkKind.训练:
                    return this.TrainingAbility;
            }
            return 0;
        }

        public void GoForConvince(Person person)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.说服;
                this.ConvincingPerson = person;
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.ConvincePersonFund);
                this.GoToDestinationAndReturn(this.OutsideDestination.Value);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
				ExtensionInterface.call("GoForConvince", new Object[] { this.Scenario, this, person});
            }
        }

        public void GoForDestroy(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.破坏;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.DestroyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
				ExtensionInterface.call("GoForDestroy", new Object[] { this.Scenario, this, position});
            }
        }

        public void GoForGossip(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.流言;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.GossipArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
				ExtensionInterface.call("GoForGossip", new Object[] { this.Scenario, this, position});
            }
        }

        public void GoForInformation(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.情报;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.InformationCoolDown += this.CurrentInformationKind.CoolDown;
                this.LocationArchitecture.DecreaseFund(this.CurrentInformationKind.CostFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = this.ArrivingDays;
				ExtensionInterface.call("GoForInformation", new Object[] { this.Scenario, this, position});
            }
        }

        public void GoForInstigate(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.煽动;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.InstigateArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
				ExtensionInterface.call("GoForInstigate", new Object[] { this.Scenario, this, position});
            }
        }

        public void GoForSearch()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.搜索;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = 10;
                this.TaskDays = this.ArrivingDays;
                this.Status = PersonStatus.Moving;
				ExtensionInterface.call("GoForSearch", new Object[] { this.Scenario, this });
            }
        }

        public void shoudongjinxingsousuo()
        {
            this.shoudongsousuo = true;
            this.GoForSearch();
        }

        public void GoForSpy(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.间谍;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.SpyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
				ExtensionInterface.call("GoForSpy", new Object[] { this.Scenario, this, position});
            }
        }

        public void GoForStudySkill()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.技能;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, Parameters.LearnSkillDays);
                this.TaskDays = this.ArrivingDays;
                this.Status = PersonStatus.Moving;
				ExtensionInterface.call("GoForStudySkill", new Object[] { this.Scenario, this });
            }
        }

        public void GoForStudyStunt(Stunt desStunt)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.特技;
                this.StudyingStunt = desStunt;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, Parameters.LearnStuntDays);
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
				ExtensionInterface.call("GoForStudyStunt", new Object[] { this.Scenario, this });
            }
        }

        public void GoForStudyTitle(Title desTitle)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.称号;
                this.StudyingTitle = desTitle;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, this.LocationArchitecture.DayLearnTitleDay);
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
				ExtensionInterface.call("GoForStudyTitle", new Object[] { this.Scenario, this });
            }
        }

        private void GoToDestinationAndReturn(Point destination)
        {
            this.TargetArchitecture = this.LocationArchitecture;
            this.ArrivingDays = base.Scenario.GetReturnDays(destination, this.TargetArchitecture.ArchitectureArea);
            this.Status = PersonStatus.Moving;
        }

        private void HandleSpyMessage(SpyMessage sm)
        {
            if (sm.Kind == SpyMessageKind.NewTroop)
            {
            }
        }

        public int IncreaseLoyalty(int increment)
        {
            //110为剧本阈值，加忠诚不超过，超过的不降忠诚
            if (increment > (110 - this.Loyalty))
            {
                increment = 110 - this.Loyalty;
            }
            if (increment > 0)
            {
                this.loyalty += increment;
                return increment;
            }
            return 0;
        }

        public bool IncreaseReputation(int increment)
        {
            this.reputation += increment;
            return true;
        }

        public void IncreaseTechniquePoint(int increment)
        {
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.IncreaseTechniquePoint(increment);
            }
        }

        public void InitialLoyalty()
        {
            if (this.BelongedFaction == null)
            {
                this.Loyalty = 0;
                return;
            }
            int num = (60 + (10 * (int)this.PersonalLoyalty)) - (GetIdealOffset(this, this.BelongedFaction.Leader) / 5);
            if (this.Ideal == this.BelongedFaction.Leader.Ideal)
            {
                num += 20;
            }
            if (this.Father == this.BelongedFaction.Leader.ID || this.Mother == this.BelongedFaction.Leader.ID)
            {
                num += 20;
            }
            if (this.ClosePersons.Contains(this.BelongedFaction.Leader.ID))
            {
                num += 30;
            }
            if (this.Spouse == this.BelongedFaction.Leader.ID || (this.Brother == this.BelongedFaction.Leader.Brother && this.Brother >= 0))
            {
                num += 50;
            }
            this.Loyalty = num;
        }

        public bool IsHirable(GameObjects.Faction faction)
        {
            if (faction.Leader != null)
            {
                if (this.ProhibitedFactionID == faction.Leader.ID)
                {
                    return false;
                }
                if (GlobalVariables.IdealTendencyValid && (this.IdealTendency != null))
                {
                    bool flag = GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset;
                    if (!flag)
                    {
                        foreach (GameObjects.Faction faction2 in base.Scenario.Factions)
                        {
                            if ((faction2 != faction) && (faction2.Leader != null))
                            {
                                flag = GetIdealOffset(this, faction2.Leader) <= this.IdealTendency.Offset;
                                if (flag)
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
                return true;
            }
            return false;
        }

        public void Killed()   //现在用PlayerKillLeader代替，应该没有使用
        {
            if (((this.LocationArchitecture != null) && !this.IsCaptive) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.LocationArchitecture);
                }
                if ((this.LocationArchitecture.BelongedFaction != null) && (this.LocationArchitecture.BelongedFaction.Leader != null))
                {
                    foreach (Person person in base.Scenario.AvailablePersons)
                    {
                        if ((person != this) && (((person.Father >= 0) && (person.Father == base.ID)) || ((person.Brother >= 0) && (person.Brother == this.Brother))))
                        {
                            person.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.Leader.ID;
                        }
                    }
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.Status = PersonStatus.None;
                this.LocationArchitecture = null;
            }
            else if ((this.TargetArchitecture != null) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.TargetArchitecture);
                }
                if ((this.TargetArchitecture.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction.Leader != null))
                {
                    foreach (Person person in base.Scenario.AvailablePersons)
                    {
                        if ((person != this) && (((person.Father >= 0) && (person.Father == base.ID)) || ((person.Brother >= 0) && (person.Brother == this.Brother))))
                        {
                            person.ProhibitedFactionID = this.TargetArchitecture.BelongedFaction.Leader.ID;
                        }
                    }
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.status = PersonStatus.None;
                base.Scenario.AvailablePersons.Remove(this);
            }
        }

        public void PlayerKillLeader()
        {
            this.execute(this.Scenario.CurrentPlayer);
            this.BelongedCaptive.Clear();
        }

        public void execute(Faction executingFaction)
        {
            Person executor = executingFaction.Leader;
            executor.ExecuteCount++;

            if (this.BelongedCaptive != null && this.BelongedCaptive.CaptiveFaction != null && this.BelongedCaptive.CaptiveFaction != executingFaction)
            {
                base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                if (this.BelongedFaction.Leader.hasStrainTo(this))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                }
                if (this.BelongedFaction.Leader.hasCloseStrainTo(this))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                    base.Scenario.SetDiplomaticRelationIfHigher(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, 0);
                }
                if (this == this.BelongedFaction.Leader)
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -1000);
                    base.Scenario.SetDiplomaticRelationIfHigher(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -1000);
                }
            }

            foreach (Person p in base.Scenario.Persons)
            {
                if (p == this) continue;
                if (p.hasCloseStrainTo(this))
                {
                    if (!p.HatedPersons.Contains(executor.ID))
                    {
                        p.HatedPersons.Add(executor.ID);
                    }
                    foreach (Person q in base.Scenario.Persons)
                    {
                        if (p == q || q == this || q == executor) continue;
                        if (GameObject.Chance((int)p.PersonalLoyalty * 25)) continue;
                        if (q.hasCloseStrainTo(executor))
                        {
                            if (!p.HatedPersons.Contains(q.ID))
                            {
                                p.HatedPersons.Add(q.ID);
                            }
                        }
                    }
                }
            }

            executingFaction.Reputation = (int) (executingFaction.Reputation * (1 - 0.05 * this.PersonalLoyalty));
            executor.Reputation = (int)(executor.Reputation * (1 - 0.05 * this.PersonalLoyalty));
			
			ExtensionInterface.call("Executed", new Object[] { this.Scenario, this, executingFaction });

            base.Scenario.YearTable.addExecuteEntry(base.Scenario.Date, executor, this);
            this.ToDeath();
        }
        /*
        private void LeaveFaction()
        {
            if (GameObject.Chance(20) && ((((this.LocationArchitecture != null) && (this.BelongedFaction != null)) && (this.BelongedFaction.Leader != this)) && !this.IsCaptive))
            {
                if ((this.Loyalty < 50) && (GameObject.Random(this.Loyalty * (1 + (int)this.PersonalLoyalty)) <= GameObject.Random(5)))
                {
                    this.LeaveToNoFaction();
                }
                else if (((GlobalVariables.IdealTendencyValid && (this.IdealTendency != null)) && (this.IdealTendency.Offset <= 1)) && (this.BelongedFaction.Leader != null))
                {
                    int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                    if (idealOffset > this.IdealTendency.Offset)
                    {
                        GameObjectList list = new GameObjectList();
                        foreach (GameObjects.Faction faction in base.Scenario.Factions)
                        {
                            if (((faction != this.BelongedFaction) && (faction.Leader != null)) && (GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset))
                            {
                                list.Add(faction);
                            }
                        }
                        if (list.Count > 0)
                        {
                            GameObjects.Faction faction2 = list[GameObject.Random(list.Count)] as GameObjects.Faction;
                            if ((faction2.Capital != null) && ((((this.PersonalLoyalty < PersonLoyalty.很高) || ((this.Father >= 0) && (this.Father == faction2.Leader.ID))) || ((this.Brother >= 0) && (this.Brother == faction2.Leader.ID))) || (idealOffset > 10)))
                            {
                                this.LeaveToNoFaction();
                                this.MoveToArchitecture(faction2.Capital);
                                //this.LocationArchitecture.RemoveNoFactionPerson(this);
                            }
                        }
                    }
                }
            }
        }
        */

        private void LeaveFaction()
        {
            if (GameObject.Chance(20) && ((((this.LocationArchitecture != null) && this.Status == PersonStatus.Normal && (this.BelongedFaction != null)) && (this.BelongedFaction.Leader != this)) && !this.IsCaptive))
            {
                if ((this.Loyalty < 50) && (GameObject.Random(this.Loyalty * (1 + (int)this.PersonalLoyalty)) <= GameObject.Random(5)))
                {
					this.LeaveToNoFaction();
					ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                }
                /*else if (((GlobalVariables.IdealTendencyValid && (this.IdealTendency != null)) && (this.IdealTendency.Offset <= 1)) && (this.BelongedFaction.Leader != null))
                {
                    int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                    if (idealOffset > this.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75)
                    {
                        GameObjectList list = new GameObjectList();
                        foreach (GameObjects.Faction faction in base.Scenario.Factions)
                        {
                            if (((faction != this.BelongedFaction) && (faction.Leader != null)) && (GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset)
                                && !this.HatedPersons.Contains(faction.LeaderID))
                            {
                                list.Add(faction);
                            }
                        }
                        if (list.Count > 0)
                        {
                            GameObjects.Faction faction2 = list[GameObject.Random(list.Count)] as GameObjects.Faction;
                            if ((faction2.Capital != null) && ((((this.PersonalLoyalty < (int) PersonLoyalty.很高) || ((this.Father >= 0) && (this.Father == faction2.Leader.ID))) || ((this.Brother >= 0) && (this.Brother == faction2.Leader.Brother))) || (idealOffset > 10)))
                            {
                                this.LeaveToNoFaction();
                                this.MoveToArchitecture(faction2.Capital);
								ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                                //this.LocationArchitecture.RemoveNoFactionPerson(this);
                                //base.Scenario.detectDuplication();
                            }
                        }
                    }
                }*/
                if (this.BelongedFaction != null)
                {
                    if (this.HatedPersons.Contains(this.BelongedFaction.LeaderID))
                    {
                        this.LeaveToNoFaction();
                        ArchitectureList allArch = base.Scenario.Architectures;
                        this.MoveToArchitecture(allArch[GameObject.Random(allArch.Count)] as Architecture);
						ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                        //this.LocationArchitecture.RemoveNoFactionPerson(this);
                        //base.Scenario.detectDuplication();
                    }
                }
            }
        }



        public void LeaveToNoFaction()
        {
            Architecture locationArchitecture = this.LocationArchitecture;

            if (TargetArchitecture != null)
            {
                this.TargetArchitecture = null;
                this.ArrivingDays = 0;
                this.TaskDays = 0;
                this.OutsideTask = OutsideTaskKind.无;
            }

            this.Status = PersonStatus.NoFaction;

            if (this.OnLeave != null)
            {
                this.OnLeave(this, locationArchitecture);
            }
        }


        public  void BeLeaveToNoFaction()
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            this.Status = PersonStatus.NoFaction;
            this.ProhibitedFactionID = locationArchitecture.BelongedFaction.ID;
        }

        public void LoseTreasure(Treasure t)
        {
            this.Treasures.Remove(t);
            t.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Treasure, t.ID);
            t.BelongedPerson = null;
        }

        public void LoseTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Remove(treasure);
                treasure.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.ID);
                treasure.BelongedPerson = null;
            }
        }

        private void LoyaltyChange()
        {
            if ((((this.BelongedFaction != null) && (((this.LocationArchitecture == null) || this.IsCaptive) || !this.LocationArchitecture.DayLocationLoyaltyNoChange)) && ((((this.LocationTroop == null) || this.IsCaptive) || !this.LocationTroop.DayLocationLoyaltyNoChange) && (GameObject.Random(30) <= 0))) 
                && (this.Loyalty <= 110) )
            {
                int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                //亲爱武将性格差调整
                if (this.closePersons.Contains(this.BelongedFaction.LeaderID) && (idealOffset > 5))
                {
                    idealOffset = 5;
                }

                if (idealOffset > 0)
                {
                    int decrement = ((int) (this.Ambition - ((PersonAmbition) ((int) this.PersonalLoyalty)))) + (idealOffset / 10);
                    if (!(!GlobalVariables.IdealTendencyValid || this.IsHirable(this.BelongedFaction)))
                    {
                        decrement += 2;
                    }
                    if (this.IsCaptive)
                    {
                        decrement *= 2;
                    }
                    if (decrement > 0 && !(this.Spouse == this.BelongedFaction.LeaderID || (this.Brother == this.BelongedFaction.Leader.Brother && this.Brother > 0)))
                    {
                        this.DecreaseLoyalty(decrement);
                    }
                    else if (decrement < 0 && (this.Loyalty < 100))
                    {
                        this.IncreaseLoyalty(Math.Abs(decrement));
                    }
                }
            }
            if (this.IsCaptive && this.BelongedCaptive.LocationArchitecture != null && 
                this.loyalty <= this.BelongedCaptive.LocationArchitecture.captiveLoyaltyFallThreshold)
            {
                this.DecreaseLoyalty(this.BelongedCaptive.LocationArchitecture.captiveLoyaltyExtraFall);
            }
        }

        private bool MeetAvailableCondition()
        {
            foreach (Faction faction in this.Scenario.Factions)
            {
                if (this.Scenario.IsPlayer(faction) && this.Father == faction.LeaderID)
                {
                    return false;
                }
            }
            return ((((this.Alive && !this.Available) && (this.YearAvailable <= base.Scenario.Date.Year)) && ((((GlobalVariables.CommonPersonAvailable && (base.ID >= 0)) && (base.ID <= 6999)) || ((GlobalVariables.AdditionalPersonAvailable && (base.ID >= 8000)) && (base.ID <= 8999))) || ((GlobalVariables.PlayerPersonAvailable && (base.ID >= 9000)) && (base.ID <= 9999)))) && !base.Scenario.PreparedAvailablePersons.HasGameObject(this));
        }

        public void MonthEvent()
        {
            if ((this.MonthIncrementOfTechniquePoint > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.MonthIncrementOfTechniquePoint);
            }
            if ((this.MonthIncrementOfFactionReputation > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseReputation(this.MonthIncrementOfFactionReputation);
            }
        }
        /*
        public void MoveToArchitecture(Architecture a)
        {
            if (this.LocationArchitecture != a)
            {
                Point position = this.Position;
                Architecture targetArchitecture = this.TargetArchitecture;
                this.TargetArchitecture = a;
                if (this.LocationArchitecture != null)
                {
                    this.ArrivingDays = (int) Math.Ceiling((double) (base.Scenario.GetDistance(this.LocationArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                }
                else if (targetArchitecture != null)
                {
                    this.ArrivingDays += (int) Math.Ceiling((double) (base.Scenario.GetDistance(targetArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                    if ((((this.OutsideTask == OutsideTaskKind.情报) || (this.OutsideTask == OutsideTaskKind.搜索)) || (this.OutsideTask == OutsideTaskKind.技能)) || (this.OutsideTask == OutsideTaskKind.称号))
                    {
                        this.TaskDays = this.ArrivingDays;
                    }
                }
                else
                {
                    this.ArrivingDays = (int) Math.Ceiling((double) (base.Scenario.GetDistance(position, base.Scenario.GetClosestPoint(a.ArchitectureArea, position)) / 10.0));
                }
                if (this.ArrivingDays == 0)
                {
                    this.ArrivingDays = 1;
                }
            }
            else
            {
                this.TargetArchitecture = a;
                this.ArrivingDays = 1;
            }
            if (this.TargetArchitecture != null)
            {
                if (this.BelongedFaction != null)
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.RemovePerson(this);
                    }
                    this.TargetArchitecture.MovingPersons.Add(this);

                }
                else
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.RemoveNoFactionPerson(this);
                    }
                    this.TargetArchitecture.NoFactionMovingPersons.Add(this);
                }

            }
        }
        */

        public void MoveToArchitecture(Architecture a, Point? startingPoint)
        {
            Architecture targetArchitecture = this.TargetArchitecture;

            if (a == null) return;

            //if (this.Status != PersonStatus.Normal) return;

            if (this.LocationArchitecture != a || startingPoint != null)
            {
                Point position = this.Position;
                this.TargetArchitecture = a;
                if (startingPoint.HasValue)
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(startingPoint.Value, a.ArchitectureArea) / 10.0));
                } 
                else if (this.LocationArchitecture != null)
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(this.LocationArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                }
                else if (targetArchitecture != null)
                {
                    this.ArrivingDays += (int)Math.Ceiling((double)(base.Scenario.GetDistance(targetArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                    if ((((this.OutsideTask == OutsideTaskKind.情报) || (this.OutsideTask == OutsideTaskKind.搜索)) || (this.OutsideTask == OutsideTaskKind.技能)) || (this.OutsideTask == OutsideTaskKind.称号))
                    {
                        this.TaskDays = this.ArrivingDays;
                    }
                }
                else
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, base.Scenario.GetClosestPoint(a.ArchitectureArea, position)) / 10.0));
                }
                if (this.ArrivingDays == 0)
                {
                    this.ArrivingDays = 1;
                }
            }
            else
            {
                this.TargetArchitecture = a;
                this.ArrivingDays = 1;
            }
            if (this.TargetArchitecture != null)
            {
                this.LocationArchitecture = this.TargetArchitecture;
                this.workKind = ArchitectureWorkKind.无;
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }

            }
        }

        public void GoToDiplomatic(DiplomaticRelationDisplay a)
        {
            if (a == null) return;
            
            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            //Architecture targetArchitecture = targetFaction.Leader.BelongedArchitecture;
            Architecture targetArchitecture = targetFaction.Capital;

            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;

                this.LocationArchitecture = this.BelongedArchitecture;
                this.workKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.亲善;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }

            }
        }

        public void GoToAllyDiplomatic(DiplomaticRelationDisplay a)
        {
            if (a == null) return;

            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            //Architecture targetArchitecture = targetFaction.Leader.BelongedArchitecture;
            Architecture targetArchitecture = targetFaction.Capital;

            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;

                this.LocationArchitecture = this.BelongedArchitecture;
                this.workKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.结盟;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }

            }
        }

        public void MoveToArchitecture(Architecture a)
        {
            this.MoveToArchitecture(a, null);
        }

        public void NoFactionMove()
        {
            if (((((this.BelongedFaction == null) && (this.ArrivingDays == 0)) && (this.LocationArchitecture != null) && this.Status == PersonStatus.NoFaction) && !this.IsCaptive) && GameObject.Chance((2 + (int)this.Ambition) + (this.LeaderPossibility ? 10 : 0)) && this.Status != PersonStatus.Princess)
            {
                if (GameObject.Chance(50 + (this.LeaderPossibility ? 10 : 0)))
                {
                    GameObjectList hirableFactionList = this.GetHirableFactionList();
                    if (hirableFactionList.Count > 0)
                    {
                        GameObjects.Faction faction = hirableFactionList[GameObject.Random(hirableFactionList.Count)] as GameObjects.Faction;
                        if (((faction.Leader != null) && (GetIdealOffset(faction.Leader, this) <= 10)) && ((faction.Capital != null) && (faction.Capital != this.LocationArchitecture)))
                        {
                            this.MoveToArchitecture(faction.Capital);
                            //this.LocationArchitecture.RemoveNoFactionPerson(this);
                        }
                    }
                    else if (this.LeaderPossibility)
                    {
                        GameObjectList list2 = new GameObjectList();
                        foreach (Architecture architecture in this.LocationArchitecture.GetClosestArchitectures(40, 80))
                        {
                            if ((architecture.BelongedFaction == null) && (architecture.RecentlyAttacked <= 0))
                            {
                                list2.Add(architecture);
                            }
                        }
                        if (list2.Count > 0)
                        {
                            if (list2.Count > 1)
                            {
                                list2.PropertyName = "UnitPopulation";
                                list2.IsNumber = true;
                                list2.ReSort();
                            }
                            Architecture a = list2[GameObject.Random(list2.Count / 2)] as Architecture;
                            this.MoveToArchitecture(a);
                            //this.LocationArchitecture.RemoveNoFactionPerson(this);
                        }
                    }
                }
                else
                {
                    if (this.LocationArchitecture.ClosestArchitectures == null)
                    {
                        this.LocationArchitecture.GetClosestArchitectures();
                    }
                    if (this.LocationArchitecture.ClosestArchitectures.Count > 0)
                    {
                        int maxValue = 20;
                        if (maxValue > this.LocationArchitecture.ClosestArchitectures.Count)
                        {
                            maxValue = this.LocationArchitecture.ClosestArchitectures.Count;
                        }
                        maxValue = GameObject.Random(maxValue);
                        this.MoveToArchitecture(this.LocationArchitecture.ClosestArchitectures[maxValue] as Architecture);
                        //this.LocationArchitecture.RemoveNoFactionPerson(this);
                    }
                }
            }
        }

        public void PreDayEvent()
        {
            this.SetDayInfluence();
        }

        private void ProgressArrivingDays()
        {


            if (this.TaskDays > 0)
            {
                this.TaskDays--;
                if ((this.TaskDays == 0) && (this.OutsideTask != OutsideTaskKind.无))
                {
                    if (this.BelongedFaction != null)
                    {
                        this.DoOutsideTask();
                    }
                    else
                    {
                        this.Status = PersonStatus.NoFaction;
                        this.TargetArchitecture = null;
                    }
                }
            }
            if (this.ArrivingDays > 0)
            {
                this.ArrivingDays--;
                if ((this.ArrivingDays == 0) && (this.TargetArchitecture != null))
                {

                    if (this.BelongedFaction != null)
                    {
                        if (this.TargetArchitecture.BelongedFaction == this.BelongedFaction)
                        {
                            this.Status = PersonStatus.Normal;

                            if (this.Scenario.IsCurrentPlayer(this.BelongedFaction) && this.TargetArchitecture.TodayPersonArriveNote == false
                                && this.TargetArchitecture.BelongedSection!=null  && this.TargetArchitecture.BelongedSection.AIDetail.ID == 0)
                            {
                                this.TargetArchitecture.TodayPersonArriveNote = true;
                                this.Scenario.GameScreen.renwudaodatishi(this, this.TargetArchitecture);
                            }
                            this.TargetArchitecture = null;
                        }
                        else if (this.BelongedFaction.Capital != null)
                        {
                            this.MoveToArchitecture(this.BelongedFaction.Capital);
                        }
                        else   //这种情况在现在的程序中应该不会出现。
                        {
                            this.Status = PersonStatus.NoFaction;
                            this.TargetArchitecture = null;
                        }
                    }
                    else
                    {
                        this.Status = PersonStatus.NoFaction;
                        this.TargetArchitecture = null;
                    }
					ExtensionInterface.call("ArrivedAtArchitecture", new Object[] { this.Scenario, this, this.TargetArchitecture });
                }
            }
        }

        public void ReceiveTreasure(Treasure t)
        {
            this.Treasures.Add(t);
            t.BelongedPerson = this;
            t.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Treasure, t.ID);
        }

        public void ReceiveTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Add(treasure);
                treasure.BelongedPerson = this;
                treasure.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.ID);
            }
        }

        public void SeasonEvent()
        {
        }

        private void SetDayInfluence()
        {
            this.RewardFinished = false;
            if (this.Status == PersonStatus.Normal)
            {
                if (((this.DayRateIncrementOfInternal > 0f) && ((this.BelongedFaction != null) && (this.LocationArchitecture != null))) && (this.LocationArchitecture.DayRateIncrementOfInternal < this.DayRateIncrementOfInternal))
                {
                    this.LocationArchitecture.DayRateIncrementOfInternal = this.DayRateIncrementOfInternal;
                }
                if ((this.LocationArchitecture != null) && (this.DayLearnTitleDay < this.LocationArchitecture.DayLearnTitleDay))
                {
                    this.LocationArchitecture.DayLearnTitleDay = this.DayLearnTitleDay;
                }
                if (this.DayLocationLoyaltyNoChange && (this.BelongedFaction != null))
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.DayLocationLoyaltyNoChange = true;
                    }
                    if (this.LocationTroop != null)
                    {
                        this.LocationTroop.DayLocationLoyaltyNoChange = true;
                    }
                }
                if ((this.DayAvoidInfluenceByBattle && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidInfluenceByBattle = true;
                }
                if ((this.DayAvoidPopulationEscape && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidPopulationEscape = true;
                }
                if ((this.DayAvoidInternalDecrementOnBattle && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidInternalDecrementOnBattle = true;
                }
            }
        }

        public void ShowPersonMessage(PersonMessage personMessage)
        {
            bool flag = true;
            if ((this.BelongedFaction != null) && (personMessage is SpyMessage))
            {
                SpyMessage sm = personMessage as SpyMessage;
                Point key = new Point(sm.MessageArchitecture.ID, (int) sm.Kind);
                if (!this.BelongedFaction.SpyMessageCloseList.ContainsKey(key))
                {
                    this.HandleSpyMessage(sm);
                    this.BelongedFaction.SpyMessageCloseList.Add(key, null);
                }
                else
                {
                    flag = false;
                }
            }
            if (flag && (this.OnShowMessage != null))
            {
                this.OnShowMessage(this, personMessage);
            }
        }

        public override string ToString()
        {
            return (this.NormalName + " 势力：" + this.Faction + " 所在：" + this.Location);
        }

        public void TryToBeAvailable()
        {

            if (GameObject.Chance(10) && this.MeetAvailableCondition())
            {
                this.BeAvailable();
            }
        }

        public void YearEvent()
        {
        }

        public int Age
        {
            get
            {
                return base.Scenario.Date.Year - this.yearBorn;
            }
        }

        public string DisplayedAge
        {
            get
            {
                return GlobalVariables.PersonNaturalDeath ? (base.Scenario.Date.Year - this.yearBorn).ToString() : "--";
            }
        }

        public int AgricultureAbility
        {
            get
            {
                return (int) ((this.BaseAgricultureAbility + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
            }
        }

        public int zhenzaiAbility
        {
            get
            {
                return this.Intelligence + 2 * this.Politics;
            }
        }

        public int AgricultureWeighing
        {
            get
            {
                return ((this.AgricultureAbility * (this.MultipleOfAgricultureReputation + this.MultipleOfAgricultureTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public bool Alive
        {
            get
            {
                return this.alive;
            }
            set
            {
                this.alive = value;
            }
        }

        public int AllSkillMerit
        {
            get
            {
                int num = 0;
                foreach (Skill skill in this.Skills.Skills.Values)
                {
                    num += 5 * skill.Level;
                }
                return num;
            }
        }

        public int Ambition
        {
            get
            {
                return this.ambition;
            }
            set
            {
                this.ambition = value;
            }
        }

        public int ArrivingDays
        {
            get
            {
                return this.arrivingDays;
            }
            set
            {
                this.arrivingDays = value;
            }
        }

        public bool Available
        {
            get
            {
                return this.available;
            }
            set
            {
                this.available = value;
            }
        }

        public int AvailableLocation
        {
            get
            {
                return this.availableLocation;
            }
            set
            {
                this.availableLocation = value;
            }
        }

        private int BaseAgricultureAbility
        {
            get
            {
                return (2 * (this.Politics + this.Glamour));
            }
        }

        public int BaseCommand
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        private int BaseCommerceAbility
        {
            get
            {
                return ((this.Intelligence + (2 * this.Politics)) + this.Glamour);
            }
        }

        private int BaseDominationAbility
        {
            get
            {
                return (((2 * this.Strength) + this.Command) + this.Glamour);
            }
        }

        private int BaseEnduranceAbility
        {
            get
            {
                return (((this.Strength + this.Command) + this.Intelligence) + this.Politics);
            }
        }

        public int BaseGlamour
        {
            get
            {
                return this.glamour;
            }
            set
            {
                this.glamour = value;
            }
        }

        public float BaseImpactRate
        {
            get
            {
                return this.baseImpactRate;
            }
            set
            {
                this.baseImpactRate = value;
            }
        }

        public int BaseIntelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        private int BaseMoraleAbility
        {
            get
            {
                return ((this.Command + this.Politics) + (2 * this.Glamour));
            }
        }

        public int BasePolitics
        {
            get
            {
                return this.politics;
            }
            set
            {
                this.politics = value;
            }
        }

        private int BaseRecruitmentAbility
        {
            get
            {
                return ((2 * this.Command) + (2 * this.Glamour));
            }
        }

        public int BaseStrength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }

        private int BaseTechnologyAbility
        {
            get
            {
                return (2 * (this.Intelligence + this.Politics));
            }
        }

        private int BaseTrainingAbility
        {
            get
            {
                return ((2 * this.Strength) + (2 * this.Command));
            }
        }

        public PersonBornRegion BornRegion
        {
            get
            {
                return this.bornRegion;
            }
            set
            {
                this.bornRegion = value;
            }
        }

        public int Braveness
        {
            get
            {
                return this.braveness;
            }
            set
            {
                this.braveness = value;
            }
        }

        public int Brother
        {
            get
            {
                return this.brother;
            }
            set
            {
                this.brother = value;
            }
        }

        public String BrotherName
        {
            get
            {
                if (brother == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person brotherPerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == brother)
                    {
                        brotherPerson = i;
                        break;
                    }
                }
                return brotherPerson == null ? "－－－－" : brotherPerson.Name;
            }
        }

        public int BubingExperience
        {
            get
            {
                return (int) (this.bubingExperience);
            }
            set
            {
                this.bubingExperience = value;
            }
        }

        public string CalledName
        {
            get
            {
                return this.calledName;
            }
            set
            {
                this.calledName = value;
            }
        }

        public int Calmness
        {
            get
            {
                return this.calmness;
            }
            set
            {
                this.calmness = value;
            }
        }

        public int CaptiveAbility
        {
            get
            {
                return (((this.Strength * 3) + (this.Intelligence * 3)) + ((this.Braveness + this.Calmness) * 20));
            }
        }

        public string CharacterString
        {
            get
            {
                return this.Character.Name;
            }
        }

        public string CloseName
        {
            get
            {
                if ((this.calledName != null) && (this.calledName != ""))
                {
                    return this.calledName;
                }
                return this.NormalName;
            }
        }

        public List<int> ClosePersons
        {
            get
            {
                return this.closePersons;
            }
        }


        public int MilitaryTypeSkillMerit(MilitaryType kind)
        {
            int result = 0;
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                if (skill.Combat && (skill.MilitaryTypeOnly == kind || skill.MilitaryTypeOnly == MilitaryType.其他))
                {
                    result += 5 * skill.Level;
                }
            }
            return result;
        }

        public int MilitaryTypeStuntMerit(MilitaryType kind)
        {
            int result = 0;
            foreach (Stunt stunt in this.Stunts.Stunts.Values)
            {
                if ((stunt.MilitaryTypeOnly == kind || stunt.MilitaryTypeOnly == MilitaryType.其他))
                {
                    result += 30;
                }
            }
            return result;
        }

        public bool MilitaryTypePersonalTitle(MilitaryType kind)
        {
            if (this.PersonalTitle == null) return false;
            if (this.PersonalTitle.Combat && (this.PersonalTitle.MilitaryTypeOnly == kind || this.PersonalTitle.MilitaryTypeOnly == MilitaryType.其他))
            {
                return true;
            }
            return false;
        }

        public bool MilitaryTypeCombatTitle(MilitaryType kind)
        {
            if (this.CombatTitle == null) return false;
            if (this.CombatTitle.Combat && (this.CombatTitle.MilitaryTypeOnly == kind || this.CombatTitle.MilitaryTypeOnly == MilitaryType.其他))
            {
                return true;
            }
            return false;
        }

        public int CombatSkillMerit
        {
            get
            {
                int num = 0;
                foreach (Skill skill in this.Skills.Skills.Values)
                {
                    if (skill.Combat)
                    {
                        num += 5 * skill.Level;
                    }
                }
                return num;
            }
        }

        public int CombatTitleInfluenceCount
        {
            get
            {
                if (this.CombatTitle != null)
                {
                    return this.CombatTitle.InfluenceCount;
                }
                return 0;
            }
        }

        public string CombatTitleString
        {
            get
            {
                if (this.CombatTitle != null)
                {
                    return this.CombatTitle.Name;
                }
                return "----";
            }
        }

        public int CombatTitleLevel
        {
            get
            {
                return this.CombatTitle != null ? this.CombatTitle.Level : 0;
            }
        }


        public int Command
        {
            get
            {
                return this.NormalCommand;
            }
            set
            {
                this.command = value;
            }
        }

        public int CommandExperience
        {
            get
            {
                return (int) (this.commandExperience);
            }
            set
            {
                this.commandExperience = value;
            }
        }

        public int CommandFromExperience
        {
            get
            {
                return (this.CommandExperience / 0x3e8);
            }
        }

        public int CommandIncludingExperience
        {
            get
            {
                return (this.BaseCommand + this.CommandFromExperience);
            }
        }

        public int CommerceAbility
        {
            get
            {
                return (int) ((this.BaseCommerceAbility + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
            }
        }

        public int CommerceWeighing
        {
            get
            {
                return ((this.CommerceAbility * (this.MultipleOfCommerceReputation + this.MultipleOfCommerceTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int ControversyAbility
        {
            get
            {
                return (this.Intelligence + this.Glamour);
            }
        }

        public int ConvinceAbility
        {
            get
            {
                return (int) ((this.Glamour * 4) * (1f + this.RateIncrementOfConvince));
            }
        }

        public InformationKind CurrentInformationKind
        {
            get
            {
                if (this.currentInformationKind == null)
                {
                    this.currentInformationKind = base.Scenario.GameCommonData.AllInformationKinds.GetGameObject(this.informationKindID) as InformationKind;
                }
                return this.currentInformationKind;
            }
            set
            {
                this.currentInformationKind = value;
                if (value != null)
                {
                    this.informationKindID = value.ID;
                }
                else
                {
                    this.informationKindID = -1;
                }
            }
        }

        public PersonDeadReason DeadReason
        {
            get
            {
                return this.deadReason;
            }
            set
            {
                this.deadReason = value;
            }
        }

        public int DestroyAbility
        {
            get
            {
                return (int) (((this.Strength + this.Command) + (this.Intelligence * 2)) * (1f + this.RateIncrementOfDestroy));
            }
        }

        public int DominationAbility
        {
            get
            {
                return (int) ((this.BaseDominationAbility + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
            }
        }

        public int DominationWeighing
        {
            get
            {
                return ((this.DominationAbility * (this.MultipleOfDominationReputation + this.MultipleOfDominationTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int EnduranceAbility
        {
            get
            {
                return (int) ((this.BaseEnduranceAbility + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
            }
        }

        public int EnduranceWeighing
        {
            get
            {
                return ((this.EnduranceAbility * (this.MultipleOfEnduranceReputation + this.MultipleOfEnduranceTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public string Faction
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

        public int Father
        {
            get
            {
                return this.father;
            }
            set
            {
                this.father = value;
            }
        }

        public int FightingForce
        {
            get
            {
                return (this.Strength + this.Command + Math.Max((int)(90 * this.Character.IntelligenceRate), this.Intelligence)) * (100 + (this.PersonalTitle != null ? this.PersonalTitle.FightingMerit : 0) + (this.CombatTitle != null? this.CombatTitle.FightingMerit : 0) + this.TreasureMerit + this.StuntCount * 30);
            }
        }

        public int FightingNumber
        {
            get
            {
                return (((this.Strength * 2) + (this.Command * 2)) + this.Intelligence);
            }
        }

        public PersonForm Form
        {
            get
            {
                return this.form;
            }
            set
            {
                this.form = value;
            }
        }

        public float FormRate
        {
            get
            {
                switch (this.form)
                {
                    case PersonForm.好:
                        return (1f + this.ImpactRateOfGoodForm);

                    case PersonForm.中:
                        return 1f;

                    case PersonForm.差:
                        return (1f - this.ImpactRateOfBadForm);
                }
                return 1f;
            }
        }

        public int Generation
        {
            get
            {
                return this.generation;
            }
            set
            {
                this.generation = value;
            }
        }

        public string GivenName
        {
            get
            {
                return this.givenName;
            }
            set
            {
                this.givenName = value;
            }
        }

        public int Glamour
        {
            get
            {
                return this.NormalGlamour;
            }
            set
            {
                this.glamour = value;
            }
        }

        public int GlamourExperience
        {
            get
            {
                return (int)(this.glamourExperience);
            }
            set
            {
                this.glamourExperience = value;
            }
        }

        public int GlamourFromExperience
        {
            get
            {
                return (this.GlamourExperience / 0x3e8);
            }
        }

        public int GlamourIncludingExperience
        {
            get
            {
                return (this.BaseGlamour + this.GlamourFromExperience);
            }
        }

        public int GossipAbility
        {
            get
            {
                return (int)(((this.Politics * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfGossip));
            }
        }

        public bool HasLeaderValidCombatTitle
        {
            get
            {
                if (this.CombatTitle == null)
                {
                    return false;
                }
                return this.CombatTitle.Influences.HasTroopLeaderValidInfluence;
            }
        }

        public bool HasLearnableSkill
        {
            get
            {
                if (base.Scenario.GameCommonData.AllSkills.Count > this.SkillCount)
                {
                    foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
                    {
                        if ((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool HasLearnableStunt
        {
            get
            {
                if (base.Scenario.GameCommonData.AllStunts.Count > this.StuntCount)
                {
                    foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
                    {
                        if ((this.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(this))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool HasLearnableTitle
        {
            get
            {
                foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (((title != this.PersonalTitle) && (title != this.CombatTitle)) && title.CanLearn(this))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public List<int> HatedPersons
        {
            get
            {
                return this.hatedPersons;
            }
        }

        public Title HigherLevelLearnableTitle
        {
            get
            {
                Title title = null;
                foreach (Title title2 in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if ((title2.Kind == TitleKind.个人) && (((this.PersonalTitle == null) || (title2.Level > this.PersonalTitle.Level)) && title2.CanLearn(this)))
                    {
                        if ((title == null) || (title.Level < title2.Level))
                        {
                            title = title2;
                        }
                        /*else if ((title.Level == title2.Level) && GameObject.Chance(50))
                        {
                            title = title2;
                        }*/
                    }
                    if ((title2.Kind == TitleKind.战斗) && (((this.CombatTitle == null) || (title2.Level > this.CombatTitle.Level)) && title2.CanLearn(this)))
                    {
                        if ((title == null) || (title.Level < title2.Level))
                        {
                            title = title2;
                        }
                        /*else if (GameObject.Chance(50))
                        {
                            title = title2;
                        }*/
                    }
                }
                return title;
            }
        }

        public int Ideal
        {
            get
            {
                return this.ideal;
            }
            set
            {
                this.ideal = value;
            }
        }

        public string IdealTendencyString
        {
            get
            {
                return ((this.IdealTendency != null) ? this.IdealTendency.Name : "----");
            }
        }

        public float ImpactRateOfBadForm
        {
            get
            {
                return (this.impactRateOfBadForm + (this.BaseImpactRate * this.InfluenceRateOfBadForm));
            }
            set
            {
                this.impactRateOfGoodForm = value;
            }
        }

        public float ImpactRateOfGoodForm
        {
            get
            {
                return (this.impactRateOfGoodForm + (this.BaseImpactRate * this.InfluenceRateOfGoodForm));
            }
            set
            {
                this.impactRateOfGoodForm = value;
            }
        }

        public int InformationAbility
        {
            get
            {
                //return this.RadiusIncrementOfInformation;
                return ((this.Intelligence * 2) + this.Glamour);

            }
        }

        public int InformationKindID
        {
            get
            {
                return this.informationKindID;
            }
            set
            {
                this.informationKindID = value;
            }
        }

        public int InstigateAbility
        {
            get
            {
                return (int)(((this.Intelligence * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfInstigate));
            }
        }

        public int Intelligence
        {
            get
            {
                return this.NormalIntelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        public int IntelligenceExperience
        {
            get
            {
                return (int)(this.intelligenceExperience);
            }
            set
            {
                this.intelligenceExperience = value;
            }
        }

        public int IntelligenceFromExperience
        {
            get
            {
                return (this.IntelligenceExperience / 0x3e8);
            }
        }

        public int IntelligenceIncludingExperience
        {
            get
            {
                return (this.BaseIntelligence + this.IntelligenceFromExperience);
            }
        }

        public int InternalExperience
        {
            get
            {
                return (int)(this.internalExperience);
            }
            set
            {
                this.internalExperience = value;
            }
        }

        public bool IsCaptive
        {
            get
            {
                return (this.BelongedCaptive != null);
            }
        }

        public bool LeaderPossibility
        {
            get
            {
                return this.leaderPossibility;
            }
            set
            {
                this.leaderPossibility = value;
            }
        }

        public string Location
        {
            get
            {
                if (this.IsCaptive)
                {
                    return "俘虏";
                }
                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.Name;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture.Name;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.DisplayName;
                }
                return "----";
            }
        }

        public int Loyalty
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return this.loyalty;
                }
                return 0;
            }
            set
            {
                this.loyalty = value;
            }
        }

        public int Merit
        {
            get
            {
                return (this.Strength + this.Command + this.Intelligence + this.Politics + this.Glamour) * (100 + ((this.PersonalTitle != null) ? this.PersonalTitle.Merit : 0) + ((this.CombatTitle != null) ? this.CombatTitle.Merit : 0) + this.AllSkillMerit + this.TreasureMerit);
            }
        }

        public int MoraleAbility
        {
            get
            {
                return (int)((this.BaseMoraleAbility + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
            }
        }

        public int MoraleWeighing
        {
            get
            {
                return ((this.MoraleAbility * (this.MultipleOfMoraleReputation + this.MultipleOfMoraleTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int Mother
        {
            get
            {
                return this.mother;
            }
            set
            {
                this.mother = value;
            }
        }

        public string Name
        {
            get
            {
                return this.NormalName;
            }
        }

        public int NonFightingNumber
        {
            get
            {
                return ((this.Intelligence + (this.Politics * 2)) + (this.Glamour * 2));
            }
        }

        public int NormalAgricultureAbility
        {
            get
            {
                return (int)(((2 * (this.NormalPolitics + this.NormalGlamour)) + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
            }
        }

        public int NormalCommand
        {
            get
            {
                return (int) (Math.Min((int)((this.CommandIncludingExperience + this.InfluenceIncrementOfCommand) * this.InfluenceRateOfCommand), GlobalVariables.MaxAbility) * this.TirednessFactor);
            }
        }

        public int NormalCommerceAbility
        {
            get
            {
                return (int)((((this.NormalIntelligence + (2 * this.NormalPolitics)) + this.NormalGlamour) + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
            }
        }

        public int NormalDominationAbility
        {
            get
            {
                return (int)(((((2 * this.NormalStrength) + this.NormalCommand) + this.NormalGlamour) + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
            }
        }

        public int NormalEnduranceAbility
        {
            get
            {
                return (int)(((((this.NormalStrength + this.NormalCommand) + this.NormalIntelligence) + this.NormalPolitics) + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
            }
        }

        public int NormalGlamour
        {
            get
            {
                return (int) (Math.Min((int)((this.GlamourIncludingExperience + this.InfluenceIncrementOfGlamour) * this.InfluenceRateOfGlamour), GlobalVariables.MaxAbility) * this.TirednessFactor);
            }
        }

        public int NormalIntelligence
        {
            get
            {
                return (int) (Math.Min((int)((this.IntelligenceIncludingExperience + this.InfluenceIncrementOfIntelligence) * this.InfluenceRateOfIntelligence), GlobalVariables.MaxAbility) * this.TirednessFactor);
            }
        }

        public int NormalMoraleAbility
        {
            get
            {
                return (int)((((this.NormalCommand + this.NormalPolitics) + (2 * this.NormalGlamour)) + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
            }
        }

        public string NormalName
        {
            get
            {
                return (this.surName + this.givenName);
            }
        }

        public int NormalPolitics
        {
            get
            {
                return (int) (Math.Min((int)((this.PoliticsIncludingExperience + this.InfluenceIncrementOfPolitics) * this.InfluenceRateOfPolitics), GlobalVariables.MaxAbility) * this.TirednessFactor);
            }
        }

        public int NormalRecruitmentAbility
        {
            get
            {
                return (int)((((2 * this.NormalCommand) + (2 * this.NormalGlamour)) + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public int NormalStrength
        {
            get
            {
                return (int) (Math.Min((int)((this.StrengthIncludingExperience + this.InfluenceIncrementOfStrength) * this.InfluenceRateOfStrength), GlobalVariables.MaxAbility) * this.TirednessFactor);
            }
        }

        public int NormalTechnologyAbility
        {
            get
            {
                return (int)(((2 * (this.NormalIntelligence + this.NormalPolitics)) + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
            }
        }

        public int NormalTrainingAbility
        {
            get
            {
                return (int)((((2 * this.NormalStrength) + (2 * this.NormalCommand)) + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
            }
        }

        public int NubingExperience
        {
            get
            {
                return (int)(this.nubingExperience);
            }
            set
            {
                this.nubingExperience = value;
            }
        }

        public int OldFactionID
        {
            get
            {
                return this.oldFactionID;
            }
            set
            {
                this.oldFactionID = value;
            }
        }

        public Point? OutsideDestination
        {
            get
            {
                return this.outsideDestination;
            }
            set
            {
                this.outsideDestination = value;
            }
        }

        public OutsideTaskKind OutsideTask
        {
            get
            {
                return this.outsideTask;
            }
            set
            {
                this.outsideTask = value;
            }
        }

        public string OutsideTaskDaysString
        {
            get
            {
                if (this.TaskDays > 0)
                {
                    return (this.TaskDays.ToString() + "天");
                }
                return "----";
            }
        }

        public string OutsideTaskString
        {
            get
            {
                if (this.outsideTask != OutsideTaskKind.无)
                {
                    return this.outsideTask.ToString();
                }
                return "----";
            }
        }

        public int PersonalLoyalty
        {
            get
            {
                return this.personalLoyalty;
            }
            set
            {
                this.personalLoyalty = value;
            }
        }

        public int PersonalTitleInfluenceCount
        {
            get
            {
                if (this.PersonalTitle != null)
                {
                    return this.PersonalTitle.InfluenceCount;
                }
                return 0;
            }
        }

        public string PersonalTitleString
        {
            get
            {
                if (this.PersonalTitle != null)
                {
                    return this.PersonalTitle.Name;
                }
                return "----";
            }
        }

        public int PersonalTitleLevel
        {
            get
            {
                return this.PersonalTitle != null ? this.PersonalTitle.Level : 0;
            }
        }

        public int PictureIndex
        {
            get
            {
                return this.pictureIndex;
            }
            set
            {
                this.pictureIndex = value;
            }
        }

        public int Politics
        {
            get
            {
                return this.NormalPolitics;
            }
            set
            {
                this.politics = value;
            }
        }

        public int PoliticsExperience
        {
            get
            {
                return (int)(this.politicsExperience);
            }
            set
            {
                this.politicsExperience = value;
            }
        }

        public int PoliticsFromExperience
        {
            get
            {
                return (this.PoliticsExperience / 0x3e8);
            }
        }

        public int PoliticsIncludingExperience
        {
            get
            {
                return (this.BasePolitics + this.PoliticsFromExperience);
            }
        }

        public Texture2D Portrait
        {
            get
            {
                Texture2D result = base.Scenario.GetPortrait(this.PictureIndex);
                return result == null ? base.Scenario.GetPortrait(9999) : result;
            }
        }

        public Point Position
        {
            get
            {
                if (this.IsCaptive)
                {
                    if (this.BelongedCaptive.LocationArchitecture != null)
                    {
                        return this.BelongedCaptive.LocationArchitecture.Position;
                    }
                    if (this.BelongedCaptive.LocationTroop != null)
                    {
                        return this.BelongedCaptive.LocationTroop.Position;
                    }
                    return this.BelongedCaptive.BelongedFaction.Capital.Position;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.Position;
                }
                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.Position;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture.Position;
                }
                return Point.Zero;
            }
        }

        public int ProhibitedFactionID
        {
            get
            {
                return this.prohibitedFactionID;
            }
            set
            {
                this.prohibitedFactionID = value;
            }
        }

        public int QibingExperience
        {
            get
            {
                return (int)(this.qibingExperience);
            }
            set
            {
                this.qibingExperience = value;
            }
        }

        public int QixieExperience
        {
            get
            {
                return (int)(this.qixieExperience);
            }
            set
            {
                this.qixieExperience = value;
            }
        }

        public PersonQualification Qualification
        {
            get
            {
                return this.qualification;
            }
            set
            {
                this.qualification = value;
            }
        }

        public string RealDestinationString
        {
            get
            {
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.RealDestinationString;
                }
                return "----";
            }
        }

        public int RecruitmentAbility
        {
            get
            {
                return (int)((this.BaseRecruitmentAbility + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public void RecruitMilitary(Military m)
        {
            this.WorkKind = ArchitectureWorkKind.补充;
            this.RecruitmentMilitary = m;
        }

        public Military RecruitmentMilitary
        {
            get
            {
                return this.recruitmentMilitary;
            }
            set
            {
                this.recruitmentMilitary = value;
            }
        }

        public int RecruitmentWeighing
        {
            get
            {
                return (this.RecruitmentAbility * (this.MultipleOfRecruitmentReputation + this.MultipleOfRecruitmentTechniquePoint));
            }
        }

        public int Reputation
        {
            get
            {
                return this.reputation;
            }
            set
            {
                this.reputation = value;
            }
        }

        public string RespectfulName
        {
            get
            {
                if ((this.calledName != null) && (this.calledName != ""))
                {
                    return (this.surName + this.calledName);
                }
                return this.NormalName;
            }
        }

        public int RoutCount
        {
            get
            {
                return this.routCount;
            }
            set
            {
                this.routCount = value;
            }
        }

        public int RoutedCount
        {
            get
            {
                return this.routedCount;
            }
            set
            {
                this.routedCount = value;
            }
        }

        public int SearchAbility
        {
            get
            {
                return (int)(((this.Intelligence + this.Politics) + (this.Glamour * 2)) * (1f + this.RateIncrementOfSearch));
            }
        }

        public string SectionString
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    if (this.IsCaptive)
                    {
                        return "----";
                    }
                    if (this.LocationArchitecture != null)
                    {
                        return this.LocationArchitecture.SectionString;
                    }
                    if (this.TargetArchitecture != null)
                    {
                        return this.TargetArchitecture.SectionString;
                    }
                    if (this.LocationTroop != null)
                    {
                        if ((this.LocationTroop.StartingArchitecture != null) && (this.LocationTroop.StartingArchitecture.BelongedFaction == this.BelongedFaction))
                        {
                            return this.LocationTroop.StartingArchitecture.SectionString;
                        }
                        return "----";
                    }
                }
                return "----";
            }
        }

        public bool Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public string SexString
        {
            get
            {
                if (this.sex)
                {
                    return "女";
                }
                return "男";
            }
        }

        public int ShuijunExperience
        {
            get
            {
                return (int)(this.shuijunExperience);
            }
            set
            {
                this.shuijunExperience = value;
            }
        }

        public int SkillCount
        {
            get
            {
                return this.Skills.Skills.Count;
            }
        }

        public Texture2D SmallPortrait
        {
            get
            {
                Texture2D result = base.Scenario.GetSmallPortrait(this.PictureIndex);
                return result == null ? base.Scenario.GetSmallPortrait(9999) : result;
            }
        }

        public int Spouse
        {
            get
            {
                return this.spouse;
            }
            set
            {
                this.spouse = value;
            }
        }

        public int SpyAbility
        {
            get
            {
                return ((this.Strength + (this.Intelligence * 2)) + this.Glamour);
            }
        }

        public int SpyDays
        {
            get
            {
                return (this.IncrementOfSpyDays + 80 + this.SpyAbility / 10);
            }
        }

        public int Strain
        {
            get
            {
                return this.strain;
            }
            set
            {
                this.strain = value;
            }
        }

        public int StratagemExperience
        {
            get
            {
                return (int)(this.stratagemExperience);
            }
            set
            {
                this.stratagemExperience = value;
            }
        }

        public PersonStrategyTendency StrategyTendency
        {
            get
            {
                return GlobalVariables.IgnoreStrategyTendency ? PersonStrategyTendency.统一全国 : this.strategyTendency;
            }
            set
            {
                this.strategyTendency = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.NormalStrength;
            }
            set
            {
                this.strength = value;
            }
        }

        public int StrengthExperience
        {
            get
            {
                return (int)(this.strengthExperience);
            }
            set
            {
                this.strengthExperience = value;
            }
        }

        public int StrengthFromExperience
        {
            get
            {
                return (this.StrengthExperience / 0x3e8);
            }
        }

        public int StrengthIncludingExperience
        {
            get
            {
                return (this.BaseStrength + this.StrengthFromExperience);
            }
        }

        public int StuntCount
        {
            get
            {
                return this.Stunts.Count;
            }
        }

        public string SurName
        {
            get
            {
                return this.surName;
            }
            set
            {
                this.surName = value;
            }
        }

        public int TacticsExperience
        {
            get
            {
                return (int)(this.tacticsExperience);
            }
            set
            {
                this.tacticsExperience = value;
            }
        }

        public string TargetString
        {
            get
            {
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.TargetString;
                }
                return "----";
            }
        }

        public int TaskDays
        {
            get
            {
                return this.taskDays;
            }
            set
            {
                this.taskDays = value;
            }
        }

        public int TechnologyAbility
        {
            get
            {
                return (int)((this.BaseTechnologyAbility + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
            }
        }

        public int TechnologyWeighing
        {
            get
            {
                return ((this.TechnologyAbility * (this.MultipleOfTechnologyReputation + this.MultipleOfTechnologyTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int TrainingAbility
        {
            get
            {
                return (int)((this.BaseTrainingAbility + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
            }
        }

        public int TrainingWeighing
        {
            get
            {
                return (this.TrainingAbility * (this.MultipleOfTrainingReputation + this.MultipleOfTrainingTechniquePoint));
            }
        }

        public string Travel
        {
            get
            {
                if (this.ArrivingDays > 0)
                {
                    return (this.ArrivingDays + "天");
                }
                return "----";
            }
        }

        public int TreasureCount
        {
            get
            {
                return this.Treasures.Count;
            }
        }

        public int TreasureMerit
        {
            get
            {
                int num = 0;
                foreach (Treasure treasure in this.Treasures)
                {
                    num += treasure.Worth;
                }
                return num;
            }
        }

        public PersonValuationOnGovernment ValuationOnGovernment
        {
            get
            {
                return this.valuationOnGovernment;
            }
            set
            {
                this.valuationOnGovernment = value;
            }
        }

        public float WinningRate
        {
            get
            {
                if ((this.routCount + this.routedCount) == 0)
                {
                    return 0f;
                }
                return (((float)this.routCount) / ((float)(this.routCount + this.routedCount)));
            }
        }

        public int WorkAbility
        {
            get
            {
                return this.GetWorkAbility(this.workKind);
            }
        }

        public ArchitectureWorkKind WorkKind
        {
            get
            {
                return this.workKind;
            }
            set
            {
                if (value != ArchitectureWorkKind.补充)
                {
                    this.RecruitmentMilitary = null;
                }
                this.workKind = value;
            }
        }

        public string WorkKindString
        {
            get
            {
                if (this.workKind != ArchitectureWorkKind.无)
                {
                    return this.workKind.ToString();
                }
                return "----";
            }
        }

        public int YearAvailable
        {
            get
            {
                return this.yearAvailable;
            }
            set
            {
                this.yearAvailable = value;
            }
        }

        public int YearBorn
        {
            get
            {
                return this.yearBorn;
            }
            set
            {
                this.yearBorn = value;
            }
        }

        public int YearDead
        {
            get
            {
                return this.yearDead;
            }
            set
            {
                this.yearDead = value;
            }
        }

        public PersonList ChildrenCanBeSelectedAsPrince()
        {
            PersonList haiziliebiao = new PersonList();
            foreach (Person person in this.Scenario.Persons)
            {
                if (person.Alive && person.Available && person.Father == this.ID && person.BelongedCaptive == null && person.sex == false)
                {
                    haiziliebiao.Add(person);
                }
            }
            haiziliebiao.PropertyName = "YearBorn";
            haiziliebiao.IsNumber = true;
            haiziliebiao.SmallToBig = true;
            haiziliebiao.ReSort();
            return haiziliebiao;

        }



        public PersonList meichushengdehaiziliebiao()
        {
            PersonList haiziliebiao = new PersonList();
            foreach (Person person in this.Scenario.Persons)
            {
                if (person.Alive && !person.Available && person.Father == this.ID)
                {
                    haiziliebiao.Add(person);
                }
            }
            haiziliebiao.PropertyName = "YearBorn";
            haiziliebiao.IsNumber = true;
            haiziliebiao.SmallToBig = true;
            haiziliebiao.ReSort();
            return haiziliebiao;
        }

        public String FatherName
        {
            get
            {
                if (father == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person fatherPerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == Father)
                    {
                        fatherPerson = i;
                        break;
                    }
                }
                return fatherPerson == null ? "－－－－" : fatherPerson.Name;
            }
        }

        public String MotherName
        {
            get
            {
                if (mother == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person motherPerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == Mother)
                    {
                        motherPerson = i;
                        break;
                    }
                }
                return motherPerson == null ? "－－－－" : motherPerson.Name;
            }
        }

        public String SpouseName
        {
            get
            {
                if (spouse == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person spousePerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == spouse)
                    {
                        spousePerson = i;
                        break;
                    }
                }
                return spousePerson == null ? "－－－－" : spousePerson.Name;
            }
        }


        public delegate void BeAwardedTreasure(Person person, Treasure t);

        public delegate void BeConfiscatedTreasure(Person person, Treasure t);

        public delegate void BeKilled(Person person, Architecture location);

        public delegate void ChangeLeader(Faction faction, Person leader, bool changeName, string oldName);

        public delegate void ConvinceFailed(Person source, Person destination);

        public delegate void ConvinceSuccess(Person source, Person destination, Faction oldFaction);

        public delegate void Death(Person person, Architecture location);

        public delegate void DeathChangeFaction(Person dead, Person leader, string oldName);

        public delegate void DestroyFailed(Person person, Architecture architecture);

        public delegate void DestroySuccess(Person person, Architecture architecture, int down);

        public delegate void GossipFailed(Person person, Architecture architecture);

        public delegate void GossipSuccess(Person person, Architecture architecture);

        public delegate void InformationObtained(Person person, Information information);

        public delegate void qingbaoshibai(Person person);

        public delegate void InstigateFailed(Person person, Architecture architecture);

        public delegate void InstigateSuccess(Person person, Architecture architecture, int down);

        public delegate void Leave(Person person, Architecture location);

        public delegate void SearchFinished(Person person, Architecture architecture, SearchResultPack resultPack);

        public delegate void ShowMessage(Person person, PersonMessage personMessage);

        public delegate void SpyFailed(Person person, Architecture architecture);

        public delegate void SpyFound(Person person, Person spy);

        public delegate void SpySuccess(Person person, Architecture architecture);

        public delegate void StudySkillFinished(Person person, string skillString, bool success);

        public delegate void StudyStuntFinished(Person person, Stunt stunt, bool success);

        public delegate void StudyTitleFinished(Person person, Title title, bool success);

        public delegate void TreasureFound(Person person, Treasure treasure);

        public delegate void CapturedByArchitecture(Person person, Architecture architecture);

        public bool RecruitableBy(Faction f, int idealLeniency)
        {
            int idealOffset = Person.GetIdealOffset(this, f.Leader);
            //义兄弟或者配偶直接登用。(当前判断是和所在势力的君主)
            if ((this.Spouse == f.LeaderID) || (this.Brother == f.LeaderID))
            {
                return true;
            }
            
            if ((GlobalVariables.IdealTendencyValid && idealOffset > this.IdealTendency.Offset + (double)f.Reputation / f.MaxPossibleReputation * 75 + idealLeniency) ||
                this.HatedPersons.Contains(f.LeaderID))
            {
                foreach (Faction i in base.Scenario.Factions)
                {
                    if (((i != this.BelongedFaction) && (i.Leader != null)) && (GetIdealOffset(this, i.Leader) <= this.IdealTendency.Offset)
                        && !this.HatedPersons.Contains(i.LeaderID) &&
                        ((((this.PersonalLoyalty < (int) PersonLoyalty.很高) || ((this.Father >= 0) && (this.Father == i.Leader.ID))) || ((this.Brother >= 0) && (this.Brother == i.Leader.Brother))) || (idealOffset > 10)))
                    {
                        return false;
                    }
                }
            }
            if (this.Loyalty > 100 && this.BelongedFaction != f)
            {
                return false;
            }
            if (this.IsCaptive && this.BelongedFaction != null && this == this.BelongedFaction.Leader)
            {
                return false;
            }
            return true;
        }

        internal void muqinyingxiangnengli(Person muqin)
        {
            this.BaseStrength = (int)(this.BaseStrength * 0.9 + muqin.BaseStrength * 0.1);
            this.BaseStrength += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseStrength > 100 && !GlobalVariables.createChildrenIgnoreLimit) this.BaseStrength = 100;

            this.BaseCommand = (int)(this.BaseCommand * 0.9 + muqin.BaseCommand * 0.1);
            this.BaseCommand += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseCommand > 100 && !GlobalVariables.createChildrenIgnoreLimit) this.BaseCommand = 100;

            this.BaseIntelligence = (int)(this.BaseIntelligence * 0.9 + muqin.BaseIntelligence * 0.1);
            this.BaseIntelligence += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseIntelligence > 100 && !GlobalVariables.createChildrenIgnoreLimit) this.BaseIntelligence = 100;

            this.BasePolitics = (int)(this.BasePolitics * 0.9 + muqin.BasePolitics * 0.1);
            this.BasePolitics += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BasePolitics > 100 && !GlobalVariables.createChildrenIgnoreLimit) this.BasePolitics = 100;

            this.BaseGlamour = (int)(this.BaseGlamour * 0.9 + muqin.BaseGlamour * 0.1);
            this.BaseGlamour += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseGlamour > 100 && !GlobalVariables.createChildrenIgnoreLimit) this.BaseGlamour = 100;
        }

        private static List<String> readTextList(String fileName)
        {
            TextReader tr = new StreamReader("Resources/" + fileName);
            List<String> result = new List<String>();
            while (tr.Peek() >= 0)
            {
                result.Add(tr.ReadLine());
            }
            return result;
        }

        private static List<int> readNumberList(String fileName)
        {
            TextReader tr = new StreamReader("Resources/" + fileName);
            List<int> result = new List<int>();
            while (tr.Peek() >= 0)
            {
                result.Add(int.Parse(tr.ReadLine()));
            }
            return result;
        }

        public static Person createChildren(Person father, Person mother)
        {
            Person r = new Person();

            //look for empty id
            int id = 5000;
            PersonList pl = father.Scenario.Persons as PersonList;
            pl.SmallToBig = true;
            pl.IsNumber = true;
            pl.PropertyName = "ID";
            pl.ReSort();
            foreach (Person p in pl)
            {
                if (p.ID == id)
                {
                    id++;
                    if (id >= 7000 && id < 10000)
                    {
                        id = 10000;
                    }
                }
                else if (p.ID > id)
                {
                    break;
                }
                /*if (id >= 7000)
                {
                    //no more room!
                    throw new Exception("No more room for children!");
                }*/
            }
            r.ID = id;

            r.Father = father.ID;
            r.Mother = mother.ID;
            r.Generation = father.Generation + 1;
            r.Strain = father.Strain;

            r.Sex = GameObject.Chance(50) ? true : false;

            r.SurName = father.SurName;
            List<String> givenNameList = r.Sex ? Person.readTextList("CreateChildrenTextFile/femalegivenname.txt") : Person.readTextList("CreateChildrenTextFile/malegivenname.txt");
            r.GivenName = givenNameList[GameObject.Random(givenNameList.Count)];
            if (GameObject.Chance(80))
            {
                r.GivenName += givenNameList[GameObject.Random(givenNameList.Count)];
            }
            r.CalledName = "";

            int var = 5; //variance / maximum divert from parent ability
            r.BaseCommand = GameObject.Random(Math.Abs(father.BaseCommand - mother.BaseCommand) + 2 * var + 1) + Math.Min(father.BaseCommand, mother.BaseCommand) - var;
            r.BaseStrength = GameObject.Random(Math.Abs(father.BaseStrength - mother.BaseStrength) + 2 * var + 1) + Math.Min(father.BaseStrength, mother.BaseStrength) - var;
            r.BaseIntelligence = GameObject.Random(Math.Abs(father.BaseIntelligence - mother.BaseIntelligence) + 2 * var + 1) + Math.Min(father.BaseIntelligence, mother.BaseIntelligence) - var;
            r.BasePolitics = GameObject.Random(Math.Abs(father.BasePolitics - mother.BasePolitics) + 2 * var + 1) + Math.Min(father.BasePolitics, mother.BasePolitics) - var;
            r.BaseGlamour = GameObject.Random(Math.Abs(father.BaseGlamour - mother.BaseGlamour) + 2 * var + 1) + Math.Min(father.BaseGlamour, mother.BaseGlamour) - var;
            if (!GlobalVariables.createChildrenIgnoreLimit)
            {
                if (r.BaseStrength > 100) r.BaseStrength = 100;
                if (r.BaseStrength < 0) r.BaseStrength = 0;
                if (r.BaseCommand > 100) r.BaseCommand = 100;
                if (r.BaseCommand < 0) r.BaseCommand = 0;
                if (r.BaseIntelligence > 100) r.BaseIntelligence = 100;
                if (r.BaseIntelligence < 0) r.BaseIntelligence = 0;
                if (r.BasePolitics > 100) r.BasePolitics = 100;
                if (r.BasePolitics < 0) r.BasePolitics = 0;
                if (r.BaseGlamour > 100) r.BaseGlamour = 100;
                if (r.BaseGlamour < 0) r.BaseGlamour = 0;
            }

            List<int> pictureList;
            if (r.Sex)
            {
                if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/femalefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/femalefaceA.txt");
                }
            }
            else
            {
                if (r.BaseCommand < 50 && r.BaseStrength < 50 && r.BaseIntelligence < 50 && r.BasePolitics < 50 && r.BaseGlamour < 50)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceU.txt");
                }
                else if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceA.txt");
                }
            }
            r.PictureIndex = pictureList[GameObject.Random(pictureList.Count)];

            r.YearBorn = father.Scenario.Date.Year;
            r.YearAvailable = father.Scenario.Date.Year;
            r.YearDead = r.YearBorn + GameObject.Random(69) + 30;

            r.Ideal = GameObject.Chance(50) ? father.Ideal + GameObject.Random(10) - 5 : mother.Ideal + GameObject.Random(10) - 5;
            r.Ideal = (r.Ideal + 150) % 150;

            r.Reputation = (int)((father.Reputation + mother.Reputation) * (GameObject.Random(100) / 100.0 * 0.1 + 0.05));

            r.PersonalLoyalty = (GameObject.Chance(50) ? father.PersonalLoyalty : mother.PersonalLoyalty) + GameObject.Random(3) - 1;
            if (r.PersonalLoyalty < 0) r.PersonalLoyalty = 0;
            if ((int)r.PersonalLoyalty > Enum.GetNames(typeof(PersonLoyalty)).Length) r.PersonalLoyalty = Enum.GetNames(typeof(PersonLoyalty)).Length;

            r.Ambition = (GameObject.Chance(50) ? father.Ambition : mother.Ambition) + GameObject.Random(3) - 1;
            if (r.Ambition < 0) r.Ambition = 0;
            if ((int)r.Ambition > Enum.GetNames(typeof(PersonAmbition)).Length) r.Ambition = Enum.GetNames(typeof(PersonAmbition)).Length;

            r.Qualification = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Qualification : mother.Qualification) : (PersonQualification)GameObject.Random(Enum.GetNames(typeof(PersonQualification)).Length);

            r.Braveness = (GameObject.Chance(50) ? father.Braveness : mother.Braveness) + GameObject.Random(5) - 2;
            if (r.Braveness < 1) r.Braveness = 1;
            if (r.Braveness > 10 && !GlobalVariables.createChildrenIgnoreLimit) r.Braveness = 10;

            r.Calmness = (GameObject.Chance(50) ? father.Calmness : mother.Calmness) + GameObject.Random(5) - 2;
            if (r.Calmness < 1) r.Calmness = 1;
            if (r.Calmness > 10 && !GlobalVariables.createChildrenIgnoreLimit) r.Calmness = 10;

            r.ValuationOnGovernment = (GameObject.Chance(50) ? father.ValuationOnGovernment : mother.ValuationOnGovernment);

            r.StrategyTendency = (GameObject.Chance(50) ? father.StrategyTendency : mother.StrategyTendency);

            r.IdealTendency = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.IdealTendency : mother.IdealTendency) : father.Scenario.GameCommonData.AllIdealTendencyKinds.GetRandomList()[0] as IdealTendencyKind;
            if (father.BelongedFaction != null || mother.BelongedFaction != null)
            {
                Person leader = father.BelongedFaction == null ? mother.BelongedFaction.Leader : father.BelongedFaction.Leader;
                if (r.IdealTendency.Offset < Person.GetIdealOffset(r, leader))
                {
                    if (leader.IdealTendency.Offset >= 0)
                    {
                        r.Ideal = leader.Ideal + GameObject.Random(r.IdealTendency.Offset * 2 + 1) - r.IdealTendency.Offset;
                        r.Ideal = (r.Ideal + 150) % 150;
                    }
                    else
                    {
                        r.Ideal = leader.Ideal;
                    }
                }
            }

            Architecture bornArch = father.BelongedArchitecture == null ? mother.BelongedArchitecture : father.BelongedArchitecture;

            try //best-effort approach for getting PersonBornRegion
            {
                r.BornRegion = (PersonBornRegion)Enum.Parse(typeof(PersonBornRegion), bornArch.LocationState.Name); //mother has no locationarch...
            }
            catch (Exception)
            {
                r.BornRegion = (PersonBornRegion)GameObject.Random(Enum.GetNames(typeof(PersonBornRegion)).Length);
            }

            r.Character = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Character : mother.Character) : father.Scenario.GameCommonData.AllCharacterKinds[GameObject.Random(father.Scenario.GameCommonData.AllCharacterKinds.Count)];

            foreach (Skill i in father.Skills.GetSkillList())
            {
                if (GameObject.Chance(50))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in mother.Skills.GetSkillList())
            {
                if (GameObject.Chance(50))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in father.Scenario.GameCommonData.AllSkills.GetSkillList())
            {
                if (GameObject.Random(father.Scenario.GameCommonData.AllSkills.GetSkillList().Count / 2) == 0)
                {
                    r.Skills.AddSkill(i);
                }
            }

            foreach (Stunt i in father.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50))
                {
                    bool ok = true;
                    foreach (Condition j in i.LearnConditions.Conditions.Values)
                    {
                        if (j.Kind.ID == 600 || j.Kind.ID == 610) //check personality kind only
                        {
                            if (!j.CheckCondition(r))
                            {
                                ok = false;
                                break;
                            }
                        }
                    }
                    if (ok)
                    {
                        r.Stunts.AddStunt(i);
                    }
                }
            }
            foreach (Stunt i in mother.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50))
                {
                    bool ok = true;
                    foreach (Condition j in i.LearnConditions.Conditions.Values)
                    {
                        if (j.Kind.ID == 600 || j.Kind.ID == 610) //check personality kind only
                        {
                            if (!j.CheckCondition(r))
                            {
                                ok = false;
                                break;
                            }
                        }
                    }
                    if (ok)
                    {
                        r.Stunts.AddStunt(i);
                    }
                }
            }
            foreach (Stunt i in father.Scenario.GameCommonData.AllStunts.GetStuntList())
            {
                if (GameObject.Random(father.Scenario.GameCommonData.AllStunts.GetStuntList().Count * 2) == 0)
                {
                    bool ok = true;
                    foreach (Condition j in i.LearnConditions.Conditions.Values)
                    {
                        if (j.Kind.ID == 600 || j.Kind.ID == 610) //check personality kind only
                        {
                            if (!j.CheckCondition(r))
                            {
                                ok = false;
                                break;
                            }
                        }
                    }
                    if (ok)
                    {
                        r.Stunts.AddStunt(i);
                    }
                }
            }

            if (GameObject.Chance(20))
            {
                r.PersonalTitle = GameObject.Chance(50) ? father.PersonalTitle : mother.PersonalTitle;
            }
            else
            {
                GameObjectList titles = father.Scenario.GameCommonData.AllTitles.GetTitleList().GetRandomList();
                int levelTendency = ((father.PersonalTitle == null ? 0 : father.PersonalTitle.Level) + (mother.PersonalTitle == null ? 0 : mother.PersonalTitle.Level)) / 2;
                foreach (Title t in titles)
                {
                    if (t.Kind == TitleKind.个人 && (GameObject.Random(t.Level * t.Level + father.Scenario.GameCommonData.AllTitles.GetTitleList().Count / 8) == 0 ||
                        (t.Level == levelTendency && GameObject.Chance(50)) || (t.Level - 1 == levelTendency && GameObject.Chance(25)) || (t.Level + 1 == levelTendency && GameObject.Chance(25))))
                    {
                        if (t.Combat)
                        {
                            if (GameObject.Chance((r.BaseCommand + r.BaseStrength) / 2))
                            {
                                r.PersonalTitle = t;
                                break;
                            }
                        }
                        else
                        {
                            if (GameObject.Chance((r.BaseIntelligence + r.BasePolitics) / 2))
                            {
                                r.PersonalTitle = t;
                                break;
                            }
                        }
                    }
                }
            }

            if (GameObject.Chance(20))
            {
                r.CombatTitle = GameObject.Chance(50) ? father.CombatTitle : mother.CombatTitle;
            }
            else
            {
                GameObjectList titles = father.Scenario.GameCommonData.AllTitles.GetTitleList().GetRandomList();
                int levelTendency = ((father.CombatTitle == null ? 0 : father.CombatTitle.Level) + (mother.CombatTitle == null ? 0 : mother.CombatTitle.Level)) / 2;
                foreach (Title t in titles)
                {
                    if (t.Kind == TitleKind.战斗 && (GameObject.Random(t.Level * t.Level + 1) == 0 ||
                        (t.Level == levelTendency && GameObject.Chance(50)) || (t.Level - 1 == levelTendency && GameObject.Chance(25)) || (t.Level + 1 == levelTendency && GameObject.Chance(25))))
                    {
                        if (t.Combat)
                        {
                            if (GameObject.Chance((r.BaseCommand + r.Strength + r.BaseIntelligence) / 3))
                            {
                                r.CombatTitle = t;
                                break;
                            }
                        }
                        else
                        {
                            if (GameObject.Chance((r.BaseIntelligence + r.BasePolitics) / 2))
                            {
                                r.CombatTitle = t;
                                break;
                            }
                        }
                    }
                }
            }

            /*r.LocationArchitecture = father.BelongedArchitecture; //mother has no location arch!
            r.BelongedFaction = r.BelongedArchitecture.BelongedFaction;
            r.Available = true;*/
            r.Alive = true;

            father.Scenario.Persons.Add(r);

            r.Scenario = father.Scenario;

            foreach (int i in father.HatedPersons)
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    if (!r.HatedPersons.Contains(i))
                    {
                        r.HatedPersons.Add(i);
                    }
                }
            }
            foreach (int i in mother.HatedPersons)
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    if (!r.HatedPersons.Contains(i))
                    {
                        r.HatedPersons.Add(i);
                    }
                }
            }

            foreach (Person p in father.Scenario.Persons)
            {
                if (p.HatedPersons.Contains(father.ID) || p.HatedPersons.Contains(mother.ID))
                {
                    if (!GameObject.Chance((int)p.personalLoyalty * 25))
                    {
                        if (!p.HatedPersons.Contains(r.ID))
                        {
                            p.HatedPersons.Add(r.ID);
                        }
                    }
                }
            }

            ExtensionInterface.call("CreateChildren", new Object[] { father.Scenario, r });

            return r;
        }

        public bool hasCloseStrainTo(Person b)
        {
            if (this.father == b.ID) return true;
            if (this.mother == b.ID) return true;

            if (this.father != -1 && b.father == this.father) return true;
            if (this.mother != -1 && b.mother == this.mother) return true;

            if (b.father == this.ID) return true;
            if (b.mother == this.ID) return true;

            return false;
        }

        public bool hasStrainTo(Person b)
        {
            if (this.hasCloseStrainTo(b)) return true;

            if (this.Strain == b.Strain) return true;

            if (this.Mother != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == this.Mother)
                    {
                        if (p.Strain == b.Strain)
                        {
                            return true;
                        }
                    }
                }
            }

            if (b.Mother != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == b.Mother)
                    {
                        if (p.Strain == this.Strain)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool isLegalFeiZi(Person b)
        {
            if (this.Sex == b.Sex) return false;

            if ((b.Age < 16 || b.Age > 50) && GlobalVariables.PersonNaturalDeath) return false;

            if (this.hasStrainTo(b)) return false;

            return true;
        }

        public Person XuanZeMeiNv(Person nvren)
        {
            Person tookSpouse = null;
			
            nvren.LocationArchitecture.DecreaseFund(50000);

            nvren.Status = PersonStatus.Princess;
            nvren.workKind = ArchitectureWorkKind.无;

            nvren.LocationTroop = null;
            nvren.TargetArchitecture = null;

            if (nvren.Spouse != -1)
            {
                Person p = new Person();
                foreach (Person person in base.Scenario.Persons)
                {
                    if (person.ID == nvren.Spouse)
                    {
                        p = person;
                    }
                }

                if ((p != null) && p.ID != nvren.LocationArchitecture.BelongedFaction.LeaderID)
                {
                    if (p.Alive)
                    {
                        tookSpouse = p;

                        p.HatedPersons.Add(this.BelongedFaction.LeaderID);
                        if (p.Available == false)
                        {
                            p.ProhibitedFactionID = this.BelongedFaction.ID;

                        }
                        else if (p.BelongedFaction == null)
                        {
                            p.ProhibitedFactionID = this.BelongedFaction.ID;
                        }
                        else if (p.BelongedFaction != this.BelongedFaction)
                        {
                            p.ProhibitedFactionID = this.BelongedFaction.ID;
                        }
                        else if (p.BelongedFaction == this.BelongedFaction)
                        {
                            p.ProhibitedFactionID = this.BelongedFaction.ID;

                            p.Loyalty = -100;
                        }
                    }
                }
            }// end if (this.CurrentPerson.Spouse != -1)
			ExtensionInterface.call("TakeToHouGong", new Object[] { this.Scenario, this, nvren });
			
            return tookSpouse;
        }



        public void GoForHouGong(Person nvren)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                int houGongDays = nvren.Glamour / 4 + GameObject.Random(6) + 10;
                if (!nvren.HatedPersons.Contains(this.ID) && GlobalVariables.getChildrenRate > 0)
                {
                    if ((GameObject.Random(Math.Max((int)((this.NumberOfChildren * (GlobalVariables.PersonNaturalDeath ? 1 : 0) + nvren.NumberOfChildren * 2 + 2) / 2.0 * (10000.0 / GlobalVariables.getChildrenRate) / houGongDays), Parameters.MinPregnantProb)) == 0 ||
                        GameObject.Chance(this.pregnantChance) || GameObject.Chance(nvren.pregnantChance))
                        && !nvren.huaiyun && !this.huaiyun && this.isLegalFeiZi(nvren) &&
                        (this.LocationArchitecture.BelongedFaction.Leader.meichushengdehaiziliebiao().Count - this.LocationArchitecture.yihuaiyundefeiziliebiao().Count > 0 || GlobalVariables.createChildren))
                    {
                        nvren.suoshurenwu = this.ID;
                        this.suoshurenwu = nvren.ID;
                        if (nvren.Sex)
                        {
                            nvren.huaiyun = true;
                            nvren.huaiyuntianshu = -GameObject.Random(houGongDays);
                        }
                        else
                        {
                            this.huaiyun = true;
                            this.huaiyuntianshu = -GameObject.Random(houGongDays);
                        }
                    }
                }
                this.OutsideTask = OutsideTaskKind.后宮;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = houGongDays;
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
				ExtensionInterface.call("GoForHouGong", new Object[] { this.Scenario, this, nvren });
            }
        }

        public String FoundPregnantString
        {
            get
            {
                return faxianhuaiyun ? "○" : "×";
            }
        }

        public int PregnantDayForShowing
        {
            get
            {
                return faxianhuaiyun ? (huaiyuntianshu < 30 ? 1 : huaiyuntianshu / 30) : 0;
            }
        }

        public String HaveFollowingArmy
        {
            get
            {
                if (this.LocationArchitecture == null) return "×";
                foreach (Military i in this.LocationArchitecture.Militaries)
                {
                    if (i.FollowedLeader == this)
                    {
                        return "○";
                    }
                }
                return "×";
            }
        }

        public bool HasFollowingArmy
        {
            get
            {
                if (this.LocationArchitecture == null) return false;
                foreach (Military i in this.LocationArchitecture.Militaries)
                {
                    if (i.FollowedLeader == this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public String HaveLeadingArmy
        {
            get
            {
                if (this.LocationArchitecture == null) return "×";
                foreach (Military i in this.LocationArchitecture.Militaries)
                {
                    if (i.Leader == this || i.FollowedLeader == this)
                    {
                        return "○";
                    }
                }
                return "×";
            }
        }

        public bool HasLeadingArmy
        {
            get
            {
                if (this.LocationArchitecture == null) return false;
                foreach (Military i in this.LocationArchitecture.Militaries)
                {
                    if (i.Leader == this || i.FollowedLeader == this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}

