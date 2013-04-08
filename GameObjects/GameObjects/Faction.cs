﻿namespace GameObjects
{
    using GameGlobal;
    using GameObjects.ArchitectureDetail;
    using GameObjects.FactionDetail;
    using GameObjects.MapDetail;
    using GameObjects.SectionDetail;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class Faction : GameObject
    {
        public int PrinceID = -1;
        private bool isAlien = false;
        private int guanjuedezhi = 0;
        private int chaotinggongxiandudezhi = 0;
        internal bool AIFinished;
        private Thread AIThread;
        public ZhandouZhuangtai BattleState = ZhandouZhuangtai.和平 ;
        public bool AllowAttackAfterMoveOfBubing;
        public bool AllowAttackAfterMoveOfNubing;
        public bool AllowAttackAfterMoveOfQibing;
        public bool AllowAttackAfterMoveOfQixie;
        public bool AllowAttackAfterMoveOfShuijun;
        public int AntiArrowChanceIncrementOfBubing;
        public int AntiArrowChanceIncrementOfNubing;
        public int AntiArrowChanceIncrementOfQibing;
        public int AntiArrowChanceIncrementOfQixie;
        public int AntiArrowChanceIncrementOfShuijun;
        public int AntiCriticalStrikeChanceIncrementWhileCombatMethodOfBubing;
        public int AntiCriticalStrikeChanceIncrementWhileCombatMethodOfNubing;
        public int AntiCriticalStrikeChanceIncrementWhileCombatMethodOfQibing;
        public int AntiCriticalStrikeChanceIncrementWhileCombatMethodOfQixie;
        public int AntiCriticalStrikeChanceIncrementWhileCombatMethodOfShuijun;
        private int[,] architectureAdjustCost;
        public ArchitectureList Architectures = new ArchitectureList();
        public bool AutoRefuse;
        public TechniqueTable AvailableTechniques = new TechniqueTable();
        public MilitaryKindTable BaseMilitaryKinds = new MilitaryKindTable();
        private Architecture capital;
        private int capitalID;
        public Dictionary<Point, object> ClosedRouteways = new Dictionary<Point, object>();
        private int colorIndex;
        private bool controlling;
        public int CriticalStrikeChanceIncrementWhileCombatMethodOfBubing;
        public int CriticalStrikeChanceIncrementWhileCombatMethodOfNubing;
        public int CriticalStrikeChanceIncrementWhileCombatMethodOfQibing;
        public int CriticalStrikeChanceIncrementWhileCombatMethodOfQixie;
        public int CriticalStrikeChanceIncrementWhileCombatMethodOfShuijun;
        public float DefenceRateOfBubing;
        public float DefenceRateOfNubing;
        public float DefenceRateOfQibing;
        public float DefenceRateOfQixie;
        public float DefenceRateOfShuijun;
        public float DefenceRateWhileCombatMethodOfBubing;
        public float DefenceRateWhileCombatMethodOfNubing;
        public float DefenceRateWhileCombatMethodOfQibing;
        public float DefenceRateWhileCombatMethodOfQixie;
        public float DefenceRateWhileCombatMethodOfShuijun;
        public bool Destroyed;
        public Color FactionColor;
        public int IncrementOfAntiCriticalStrikeChance;
        public int IncrementOfChaosDaysAfterPhisicalAttack;
        public int IncrementOfCombativityCeiling;
        public int IncrementOfCriticalStrikeChance;
        public int IncrementOfResistStratagemChance;
        public int IncrementOfRoutewayRadius;
        public int IncrementOfRoutewayWorkforce;
        public int IncrementOfStratagemSuccessChance;
        public int IncrementOfViewRadius;
        public InformationList Informations = new InformationList();
        private InformationTile[,] knownAreaData;
        public Dictionary<int, Troop> KnownTroops = new Dictionary<int, Troop>();
        private Person leader = null;
        private int leaderID;
        public LegionList Legions = new LegionList();
        public InformationLevel LevelOfView = InformationLevel.中;
        private int[,] mapData;
        public MilitaryList Militaries = new MilitaryList();
        public int NoCounterChanceIncrementOfBubing;
        public int NoCounterChanceIncrementOfNubing;
        public int NoCounterChanceIncrementOfQibing;
        public int NoCounterChanceIncrementOfQixie;
        public int NoCounterChanceIncrementOfShuijun;
        public int OffenceRadiusIncrementOfBubing;
        public int OffenceRadiusIncrementOfNubing;
        public int OffenceRadiusIncrementOfQibing;
        public int OffenceRadiusIncrementOfQixie;
        public int OffenceRadiusIncrementOfShuijun;
        public float OffenceRateOfBubing;
        public float OffenceRateOfNubing;
        public float OffenceRateOfQibing;
        public float OffenceRateOfQixie;
        public float OffenceRateOfShuijun;
        public float OffenceRateWhileCombatMethodOfBubing;
        public float OffenceRateWhileCombatMethodOfNubing;
        public float OffenceRateWhileCombatMethodOfQibing;
        public float OffenceRateWhileCombatMethodOfQixie;
        public float OffenceRateWhileCombatMethodOfShuijun;
        private bool passed;
        public Technique PlanTechnique;
        public Architecture PlanTechniqueArchitecture;
        public List<int> PreferredTechniqueKinds = new List<int>();
        private bool preUserControlFinished = true;
        public float RateIncrementOfTerrainRate;
        public float RateOfCombativityRecoveryAfterAttacked;
        public float RateOfCombativityRecoveryAfterStratagemFail;
        public float RateOfCombativityRecoveryAfterStratagemSuccess;
        public float RateOfFoodTransportBetweenArchitectures = 1f;
        public float RateOfRoutewayConsumption = 1f;
        private int reputation;
        internal RoutewayPathFinder RoutewayPathBuilder = new RoutewayPathFinder();
        public RoutewayList Routeways = new RoutewayList();
        private Dictionary<ClosedPathEndpoints, List<Point>> SecondTierKnownPaths = new Dictionary<ClosedPathEndpoints, List<Point>>();
        private int[,] secondTierMapCost;
        public int SecondTierXResidue = 0;
        public int SecondTierYResidue = 0;
        public SectionList Sections = new SectionList();
        public Dictionary<Point, object> SpyMessageCloseList = new Dictionary<Point, object>();
        public bool StopToControl;
        public MilitaryKindTable TechniqueMilitaryKinds = new MilitaryKindTable();
        private int techniquePoint;
        private int techniquePointForFacility;
        private int techniquePointForTechnique;
        private Dictionary<ClosedPathEndpoints, List<Point>> ThirdTierKnownPaths = new Dictionary<ClosedPathEndpoints, List<Point>>();
        private int[,] thirdTierMapCost;
        public int ThirdTierXResidue = 0;
        public int ThirdTierYResidue = 0;
        public TroopList Troops = new TroopList();
        private int upgradingDaysLeft;
        private int upgradingTechnique = -1;

        public float techniqueReputationRateDecrease = 0f;
        public float techniquePointCostRateDecrease = 0f;
        public float techniqueTimeRateDecrease = 0f;
        public float techniqueFundCostRateDecrease = 0f;

        public event AfterCatchLeader OnAfterCatchLeader;

        public event FactionDestroy OnFactionDestroy;

        public event ForcedChangeCapital OnForcedChangeCapital;

        public event GetControl OnGetControl;

        public event InitiativeChangeCapital OnInitiativeChangeCapital;

        public event TechniqueFinished OnTechniqueFinished;

        public event FactionUpgradeTechnique OnUpgradeTechnique;

        public Faction()
        {
            this.RoutewayPathBuilder.OnGetCost += new RoutewayPathFinder.GetCost(this.RoutewayPathBuilder_OnGetCost);
            this.RoutewayPathBuilder.OnGetPenalizedCost += new RoutewayPathFinder.GetPenalizedCost(this.RoutewayPathBuilder_OnGetPenalizedCost);
        }

        public PersonList Persons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in base.Scenario.Persons)
                {
                    if ((i.Status == GameObjects.PersonDetail.PersonStatus.Normal || i.Status == GameObjects.PersonDetail.PersonStatus.Moving) 
                        && i.BelongedFaction == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public CaptiveList Captives
        {
            get
            {
                CaptiveList result = new CaptiveList();
                foreach (Captive i in base.Scenario.Captives)
                {
                    if (i.BelongedFaction == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public CaptiveList SelfCaptives
        {
            get
            {
                CaptiveList result = new CaptiveList();
                foreach (Captive i in base.Scenario.Captives)
                {
                    if (i.CaptiveFaction == this)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public int GetTechniqueUsefulness(Technique tech)
        {
            int result = 0;
            foreach (Influences.Influence i in tech.Influences.GetInfluenceList())
            {
                switch (i.ID)
                {
                    case 1030:
                    case 2400:
                    case 2420:
                    case 2430:
                        if (!GlobalVariables.LiangdaoXitong) break;
                        result = Math.Max(100, result);
                        break;
                    case 2240:
                    case 2250:
                        if (int.Parse(i.Parameter2) == 3)
                        {
                            bool hasWater = false;
                            foreach (Architecture a in this.Architectures)
                            {
                                if (a.IsBesideWater)
                                {
                                    hasWater = true;
                                    break;
                                }
                            }
                            if (!hasWater) break;
                        }
                        else if (int.Parse(i.Parameter2) == 4)
                        {
                            bool hasSiege = false;
                            foreach (MilitaryKind mk in this.AvailableMilitaryKinds.MilitaryKinds.Values)
                            {
                                if (mk.Type == MilitaryType.器械)
                                {
                                    hasSiege = true;
                                }
                            }
                            if (!hasSiege) break;
                        }
                        result = Math.Max(100, result);
                        break;
                    default:
                        result = Math.Max(100, result);
                        break;
                }
            }
            return result;
        }

        public void AddArchitecture(Architecture architecture)
        {
            this.Architectures.Add(architecture);
            if (architecture.BelongedFaction != null)
            {
                if (architecture.BelongedFaction == this)
                {
                    return;
                }
                architecture.BelongedFaction.RemoveArchitecture(architecture);
            }
            architecture.BelongedFaction = this;
        }

        public void AddArchitectureKnownData(Architecture a)
        {
            foreach (Point point in a.ArchitectureArea.Area)
            {
                this.knownAreaData[point.X, point.Y].AddInformationLevel(InformationLevel.全);
            }
            foreach (Point point in a.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    this.knownAreaData[point.X, point.Y].AddInformationLevel(InformationLevel.高);
                }
            }
            if (a.Kind.HasLongView)
            {
                foreach (Point point in a.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        this.knownAreaData[point.X, point.Y].AddInformationLevel(InformationLevel.中);
                    }
                }
            }
        }

        public void AddArchitectureMilitaries(Architecture architecture)
        {
            foreach (Military military in architecture.Militaries)
            {
                this.AddMilitary(military);
            }
        }

        public void AddInformation(Information information)
        {
            this.Informations.AddInformation(information);
            information.BelongedFaction = this;
        }

        public void AddLegion(Legion legion)
        {
            this.Legions.Add(legion);
            legion.BelongedFaction = this;
        }

        public void AddMilitary(Military military)
        {
            this.Militaries.AddMilitary(military);
            military.BelongedFaction = this;
        }

        public void AddPositionInformation(Point position, InformationLevel level)
        {
            if (!base.Scenario.PositionOutOfRange(position))
            {
                this.knownAreaData[position.X, position.Y].AddInformationLevel(level);
            }
        }

        public void AddRouteway(Routeway routeway)
        {
            this.Routeways.AddRoutewayWithEvent(routeway);
            routeway.BelongedFaction = this;
        }

        public void AddSecondTierKnownPath(List<Point> path)
        {
            if (path != null)
            {
                ClosedPathEndpoints key = new ClosedPathEndpoints(path[0], path[path.Count - 1]);
                if (!this.SecondTierKnownPaths.ContainsKey(key))
                {
                    if (this.SecondTierKnownPaths.Count > GlobalVariables.MaxCountOfKnownPaths)
                    {
                        this.SecondTierKnownPaths.Clear();
                    }
                    this.SecondTierKnownPaths.Add(key, path);
                }
            }
        }

        public void AddSection(Section section)
        {
            this.Sections.Add(section);
            section.BelongedFaction = this;
        }

        public void AddTechniqueMilitaryKind(int kindID)
        {
            MilitaryKind militaryKind = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(kindID);
            if (militaryKind != null)
            {
                this.TechniqueMilitaryKinds.AddMilitaryKind(militaryKind);
            }
        }

        public void AddThirdTierKnownPath(List<Point> path)
        {
            if (path != null)
            {
                ClosedPathEndpoints key = new ClosedPathEndpoints(path[0], path[path.Count - 1]);
                if (!this.ThirdTierKnownPaths.ContainsKey(key))
                {
                    if (this.ThirdTierKnownPaths.Count > GlobalVariables.MaxCountOfKnownPaths)
                    {
                        this.ThirdTierKnownPaths.Clear();
                    }
                    this.ThirdTierKnownPaths.Add(key, path);
                }
            }
        }

        public void AddTroop(Troop troop)
        {
            this.Troops.Add(troop);
            if (troop.BelongedFaction != null)
            {
                if (troop.BelongedFaction == this)
                {
                    return;
                }
                troop.BelongedFaction.RemoveTroop(troop);
            }
            troop.BelongedFaction = this;
        }

        public void AddTroopKnownAreaData(Troop troop)
        {
            foreach (Point point in troop.ViewArea.Area)
            {
                if (base.Scenario.PositionOutOfRange(point))
                {
                    continue;
                }
                if (point == troop.ViewArea.Centre)
                {
                    this.knownAreaData[point.X, point.Y].AddInformationLevel(InformationLevel.全);
                }
                else
                {
                    this.knownAreaData[point.X, point.Y].AddInformationLevel(troop.ScoutLevel);
                }
            }
        }

        public void AddTroopMilitary(Troop troop)
        {
            //兼容以前的旧存档？
            if (troop.Army != null)
            {
                if (troop.Army.ShelledMilitary == null)
                {
                    this.AddMilitary(troop.Army);
                }
                else
                {
                    this.AddMilitary(troop.Army.ShelledMilitary);
                }
            }
        }

        public void AdjustByArchitecture(Architecture architecture, int cost)
        {
            foreach (Point point in architecture.ArchitectureArea.Area)
            {
                this.architectureAdjustCost[point.X, point.Y] = cost;
            }
        }

        protected void AdjustByArchitectures()
        {
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (!architecture.IsFriendly(this))
                {
                    this.AdjustByArchitecture(architecture, 0xdac);
                }
            }
        }

        public void AdjustMapCost()
        {
            this.AdjustByArchitectures();
        }

        private void AI()
        {
            base.Scenario.Threading = true;
            this.AIFinished = false;
            this.AIPrepare();
            this.AISections();
            this.AICapital();
            this.AICaptives();
            this.AITechniques();
            this.AIArchitectures();
            this.AILegions();
            this.AIFinished = true;
            base.Scenario.Threading = false;
        }

        private void AIArchitectures()
        {
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.AI();
            }
        }

        private void AICapital()
        {
            if ((this.ArchitectureCount != 0) && (this.Capital != null))
            {
                Architecture architecture;
                int num2;
                if ((this.Capital.Endurance < 30) && (this.Capital.RecentlyAttacked > 0))
                {
                    if (this.Capital.ChangeCapitalAvail() && this.Capital.HasHostileTroopsInView())
                    {
                        float rationRate = 0f;
                        if (this.Capital.GetRelationUnderZeroTroopFightingForceInView(out rationRate) > (this.Capital.GetFriendlyTroopFightingForceInView() * 3))
                        {
                            this.Capital.DecreaseFund(this.Capital.ChangeCapitalCost);
                            architecture = this.SelectNewCapital();
                            if (this.Capital.Fund > this.Capital.EnoughFund)
                            {
                                num2 = this.Capital.Fund - this.Capital.EnoughFund;
                                this.Capital.DecreaseFund(num2);
                                architecture.AddFundPack(num2, (int) (base.Scenario.GetDistance(this.Capital.ArchitectureArea, architecture.ArchitectureArea) / 5.0));
                            }
                            this.ChangeCapital(architecture);
                        }
                    }
                }
                else if (this.Capital.ChangeCapitalAvail())
                {
                    architecture = this.SelectNewCapital();
                    if (((architecture != null) && (architecture.Population > (this.Capital.Population + 0x2710))) && ((architecture.Endurance * architecture.Domination) > (this.Capital.Endurance * this.Capital.Domination)))
                    {
                        this.Capital.DecreaseFund(this.Capital.ChangeCapitalCost);
                        if (this.Capital.Fund > this.Capital.EnoughFund)
                        {
                            num2 = this.Capital.Fund - this.Capital.EnoughFund;
                            this.Capital.DecreaseFund(num2);
                            architecture.AddFundPack(num2, (int) (base.Scenario.GetDistance(this.Capital.ArchitectureArea, architecture.ArchitectureArea) / 5.0));
                        }
                        this.ChangeCapital(architecture);
                    }
                }
            }
        }

        private void AICaptives()
        {
            this.AISelfReleaseCaptives();
            this.AIRedeemCaptives();
        }

        private void AILegions()
        {
            foreach (Legion legion in this.Legions.GetRandomList())
            {
                legion.AI();
            }
        }

        private void AIPrepare()
        {
            if ((base.Scenario.Date.Day == 1) && ((base.Scenario.Date.Month % 3) == 1))
            {
                foreach (Architecture architecture in this.Architectures)
                {
                    architecture.CheckIsFrontLine();
                }
            }
        }

        private void AIRedeemCaptives()
        {
            if (this.HasSelfCaptive())
            {
                foreach (Captive captive in this.SelfCaptives.GetRandomList())
                {
                    if (captive.BelongedFaction == null)
                    {
                        captive.CaptivePerson.Status = GameObjects.PersonDetail.PersonStatus.Normal;
                        if ((captive.CaptivePerson != null) && (captive.CaptiveFaction != null))
                        {
                            captive.CaptivePerson.MoveToArchitecture(captive.CaptiveFaction.Capital);
                        }
                        captive.CaptivePerson.BelongedCaptive = null;
                        continue;
                    }
                    if ((captive.BelongedFaction.Capital != null) && (captive.RansomArriveDays <= 0))
                    {
                        int diplomaticRelation = base.Scenario.GetDiplomaticRelation(captive.BelongedFaction.ID, base.ID);
                        if ((diplomaticRelation >= 0) || (GameObject.Random(Math.Abs(diplomaticRelation) + 50) < 50))
                        {
                            int ransom = captive.Ransom;
                            if (GameObject.Random(ransom) > GameObject.Random(0x7d0))
                            {
                                foreach (Architecture architecture in captive.BelongedFaction.Capital.GetClosestArchitectures(base.Scenario.Architectures.Count - 1))
                                {
                                    if ((architecture.BelongedFaction != this) || ((architecture.PlanArchitecture != null) || !(architecture.IsFundEnough || !architecture.HasHostileTroopsInView())))
                                    {
                                        continue;
                                    }
                                    if (architecture.Fund >= ransom)
                                    {
                                        if (GameObject.Random(architecture.Fund) >= (ransom - 1))
                                        {
                                            captive.SendRansom(captive.BelongedFaction.Capital, architecture);
                                            break;
                                        }
                                        if (GameObject.Chance(10))
                                        {
                                            break;
                                        }
                                    }
                                    else if (GameObject.Chance(1))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AISections()
        {
            if ((this.ArchitectureCount != 0) && (base.Scenario.GameCommonData.AllSectionAIDetails.Count > 0))
            {
                this.RebuildSections();
                foreach (Section section in this.Sections.GetList())
                {
                    section.AI();
                }
            }
        }

        private void AISelfReleaseCaptives()
        {
            return;
            /*if (this.HasCaptive())
            {
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (((captive.CaptiveFaction == null) || (captive.BelongedFaction == null)) || ((captive.BelongedFaction.Capital == null) || ((captive.LocationTroop != null) && (captive.LocationTroop.RecentlyFighting > 0))))
                    {
                        continue;
                    }
                    int diplomaticRelation = base.Scenario.GetDiplomaticRelation(captive.CaptiveFaction.ID, base.ID);
                    if ((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 50) >= GameObject.Random(50)))
                    {
                        captive.SelfReleaseCaptive();
                        continue;
                    }
                    if (diplomaticRelation < 0)
                    {
                        int chance = Math.Abs((int) (diplomaticRelation / 5));
                        if (chance >= 100)
                        {
                            chance = 0x63;
                        }
                        if (!(GameObject.Chance(chance) || (GameObject.Random(Math.Abs(diplomaticRelation) + 50) >= GameObject.Random(50))))
                        {
                            captive.SelfReleaseCaptive();
                            continue;
                        }
                    }
                }
            }*/
        }

        private void AITechniques()
        {
            if ((this.ArchitectureCount != 0) && (this.UpgradingTechnique < 0))
            {
                if (this.PlanTechnique == null)
                {
                    if (this.PreferredTechniqueKinds.Count > 0)
                    {
                        List<Technique> list = new List<Technique>();
                        float preferredTechniqueComplition = this.GetPreferredTechniqueComplition();
                        foreach (Technique technique in base.Scenario.GameCommonData.AllTechniques.Techniques.Values)
                        {
                            if (!this.IsTechniqueUpgradable(technique))
                            {
                                continue;
                            }
                            if (this.GetTechniqueUsefulness(technique) <= 0) continue;
                            if (preferredTechniqueComplition < 0.5f)
                            {
                                if (this.PreferredTechniqueKinds.IndexOf(technique.Kind) >= 0)
                                {
                                    list.Add(technique);
                                }
                            }
                            else if (preferredTechniqueComplition < 0.75f)
                            {
                                if ((this.PreferredTechniqueKinds.IndexOf(technique.Kind) >= 0) || GameObject.Chance(0x19))
                                {
                                    list.Add(technique);
                                }
                            }
                            else if (preferredTechniqueComplition < 1f)
                            {
                                if ((this.PreferredTechniqueKinds.IndexOf(technique.Kind) >= 0) || GameObject.Chance(50))
                                {
                                    list.Add(technique);
                                }
                            }
                            else if ((this.PreferredTechniqueKinds.IndexOf(technique.Kind) >= 0) || GameObject.Chance(0x4b))
                            {
                                list.Add(technique);
                            }
                        }
                        if (list.Count > 0)
                        {
                            this.PlanTechnique = list[GameObject.Random(list.Count)];
                        }
                        else
                        {
                            this.PlanTechnique = this.GetRandomTechnique();
                        }
                    }
                    else
                    {
                        this.PlanTechnique = this.GetRandomTechnique();
                    }
                }
                if (this.PlanTechnique != null)
                {
                    if (((this.TechniquePoint + this.TechniquePointForTechnique) >= this.getTechniqueActualPointCost(this.PlanTechnique)) && (this.Reputation >= this.getTechniqueActualReputation(this.PlanTechnique)))
                    {
                        if (this.ArchitectureCount > 1)
                        {
                            this.Architectures.PropertyName = "Fund";
                            this.Architectures.IsNumber = true;
                            this.Architectures.ReSort();
                        }
                        this.PlanTechniqueArchitecture = this.Architectures[0] as Architecture;
                        if (this.PlanTechniqueArchitecture.Fund >= this.getTechniqueActualFundCost(this.PlanTechnique))
                        {
                            this.DepositTechniquePointForTechnique(this.TechniquePointForTechnique);
                            this.UpgradeTechnique(this.PlanTechnique, this.PlanTechniqueArchitecture);
                            this.PlanTechniqueArchitecture = null;
                            this.PlanTechnique = null;
                        }
                    }
                    else if ((this.Reputation >= this.getTechniqueActualReputation(this.PlanTechnique)) && GameObject.Chance(0x21))
                    {
                        this.SaveTechniquePointForTechnique(this.getTechniqueActualPointCost(this.PlanTechnique) / this.PlanTechnique.Days);
                    }
                    else if (GameObject.Chance(10))
                    {
                        this.PlanTechniqueArchitecture = null;
                        this.PlanTechnique = null;
                    }
                }
            }
        }

        public void ApplyTechniques()
        {
            foreach (Technique technique in this.AvailableTechniques.Techniques.Values)
            {
                technique.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Technique, technique.ID);
            }
        }

        private void SetSectionAIDetailPinAtPlayer()
        {
            if (GameGlobal.GlobalVariables.PinPointAtPlayer)
            {
                foreach (Section i in this.Sections)
                {
                    //if ((((this.FirstSection.ArchitectureScale / 2) - (this.FirstSection.ArchitectureCount / 2)) + 1) * 20 <= this.ArmyScale)
                    //{
                        //FactionList playerFactions = base.Scenario.PlayerFactions.GetRandomList() as FactionList;
                        FactionList playerFactions = base.Scenario.PlayerFactions;
                        bool assigned = false;
                        foreach (Architecture j in i.Architectures)
                        {
                            foreach (Faction k in playerFactions)
                            {
                                if (j.HasFactionInClose(k, 1))
                                {
                                    GameObjectList sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.势力, true, true, true, false, true);
                                    if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                    {
                                        this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                        this.FirstSection.OrientationFaction = k;
                                        assigned = true;
                                    }
                                    break;
                                }
                            }
                            if (assigned) break;
                        }
                    //}
                }
            }
        }

        private void BuildSectionByArchitectureList(GameObjectList architecturelist)
        {
            if (architecturelist.Count != 0)
            {
                Section section;
                GameObjectList list;
                if (architecturelist.Count == 1)
                {
                    section = new Section();
                    section.ID = base.Scenario.Sections.GetFreeGameObjectID();
                    section.Scenario = base.Scenario;
                    this.AddSection(section);
                    base.Scenario.Sections.AddSectionWithEvent(section);
                    list = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, true, true, false);
                    if (list.Count > 0)
                    {
                        section.AIDetail = list[GameObject.Random(list.Count)] as SectionAIDetail;
                    }
                    else
                    {
                        section.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailList()[0] as SectionAIDetail;
                    }
                    section.AddArchitecture(architecturelist[0] as Architecture);
                }
                else
                {
                    architecturelist.PropertyName = "Population";
                    architecturelist.IsNumber = true;
                    architecturelist.ReSort();
                    int count = 0;
                    int num2 = 4 + (this.ArchitectureCount / 8);
                    if (architecturelist.Count < ((num2 * 3) / 2))
                    {
                        count = architecturelist.Count;
                    }
                    else
                    {
                        count = num2;
                    }
                    section = new Section();
                    section.ID = base.Scenario.Sections.GetFreeGameObjectID();
                    section.Scenario = base.Scenario;
                    this.AddSection(section);
                    base.Scenario.Sections.AddSectionWithEvent(section);
                    list = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, true, true, false);
                    if (list.Count > 0)
                    {
                        section.AIDetail = list[GameObject.Random(list.Count)] as SectionAIDetail;
                    }
                    else
                    {
                        section.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailList()[0] as SectionAIDetail;
                    }
                    Architecture architecture = architecturelist[0] as Architecture;
                    section.AddArchitecture(architecture);
                    if (architecture.ClosestArchitectures == null)
                    {
                        architecture.GetClosestArchitectures();
                    }
                    if (architecture.AIAllLinkNodes.Count == 0)
                    {
                        architecture.GenerateAllAILinkNodes(3);
                    }
                    foreach (LinkNode node in architecture.AIAllLinkNodes.Values)
                    {
                        if (node.Level > 2)
                        {
                            break;
                        }
                        if ((node.A.BelongedFaction == this) && architecturelist.HasGameObject(node.A))
                        {
                            section.AddArchitecture(node.A);
                        }
                        if (section.ArchitectureCount >= count)
                        {
                            break;
                        }
                    }
                    if (count == architecturelist.Count)
                    {
                        if (section.ArchitectureCount < count)
                        {
                            foreach (Architecture architecture2 in section.Architectures)
                            {
                                architecturelist.Remove(architecture2);
                            }
                            if (this.SectionCount == 1)
                            {
                                foreach (Architecture architecture2 in architecturelist)
                                {
                                    this.FirstSection.AddArchitecture(architecture2);
                                }
                            }
                            else
                            {
                                foreach (Architecture architecture2 in architecturelist)
                                {
                                    int num3 = 0x7fffffff;
                                    Section section2 = null;
                                    foreach (Section section3 in this.Sections)
                                    {
                                        int distanceFromSection = architecture2.GetDistanceFromSection(section3);
                                        if (distanceFromSection < num3)
                                        {
                                            num3 = distanceFromSection;
                                            section2 = section3;
                                        }
                                    }
                                    section2.AddArchitecture(architecture2);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Architecture architecture2 in section.Architectures)
                        {
                            architecturelist.Remove(architecture2);
                        }
                        this.BuildSectionByArchitectureList(architecturelist);
                    }
                }
            }
        }

        public void ChangeCapital(Architecture newCapital)
        {
            if (this.Capital != newCapital)
            {
                Architecture capital = this.Capital;
                this.Capital = newCapital;
                base.Scenario.YearTable.addChangeCapitalEntry(base.Scenario.Date, this, newCapital);
                if (this.OnInitiativeChangeCapital != null)
                {
                    this.OnInitiativeChangeCapital(this, capital, this.Capital);
                }
				ExtensionInterface.call("ChangeCapital", new Object[] { this.Scenario, this });
            }
        }

        public void ChangeFaction(Faction faction)
        {
            GameObjectList list = this.Architectures.GetList();
            foreach (Architecture architecture in list)
            {
                architecture.ChangeFaction(faction);
            }
            foreach (Architecture architecture in list)
            {
                architecture.CheckIsFrontLine();
            }
            foreach (Troop troop in this.Troops.GetList())
            {
                troop.ChangeFaction(faction);
            }
            foreach (Section section in this.Sections.GetList())
            {
                this.RemoveSection(section);
                base.Scenario.Sections.Remove(section);
            }
            this.Destroy();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                architecture.RefreshViewArea();
            }
            foreach (Troop troop in base.Scenario.Troops)
            {
                troop.RefreshViewArchitectureRelatedArea();
            }
			ExtensionInterface.call("ChangeFaction", new Object[] { this.Scenario, this });
        }

        public Faction ChangeLeaderAfterLeaderDeath()
        {
            Person leader = this.Leader;
            Architecture locationArchitecture = this.Leader.LocationArchitecture;
            this.Leader.Status = GameObjects.PersonDetail.PersonStatus.None;
            this.Leader.Available = false;
            //base.Scenario.Persons.Remove(this.Leader);
            base.Scenario.AvailablePersons.Remove(this.Leader);
            Person person2 = null;
            PersonList list = new PersonList();
            if (person2 == null)
            {
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Father >= 0) && (person3.Sex == this.Leader.Sex) && ((this.Leader.Father == person3.Father) || (person3.Father == this.Leader.ID)))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "YearBorn";
                        list.IsNumber = true;
                        list.SmallToBig = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Strain >= 0) && (person3.Sex == this.Leader.Sex) && (this.Leader.Strain == person3.Strain))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "YearBorn";
                        list.IsNumber = true;
                        list.SmallToBig = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Brother >= 0) && (person3.Sex == this.Leader.Sex) && (this.Leader.Brother == person3.Brother))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Glamour";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 == null)
            {
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Mother >= 0) && (person3.Sex == this.Leader.Sex) && ((this.Leader.Mother == person3.Mother) || (person3.Mother == this.Leader.ID)))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "YearBorn";
                        list.IsNumber = true;
                        list.SmallToBig = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (GlobalVariables.PermitFactionMerge)
            {
                Faction maxFriendlyDiplomaticRelation = this.MaxFriendlyDiplomaticRelation;
                if (maxFriendlyDiplomaticRelation != null)
                {
                    base.Scenario.YearTable.addChangeFactionEntry(base.Scenario.Date, this, maxFriendlyDiplomaticRelation);
                    this.ChangeFaction(maxFriendlyDiplomaticRelation);
                    foreach (Treasure treasure in leader.Treasures.GetList())
                    {
                        treasure.HidePlace = locationArchitecture;
                        leader.LoseTreasure(treasure);
                        treasure.Available = false;
                    }
                    return maxFriendlyDiplomaticRelation;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((this.Leader.Ideal == person3.Ideal) && (person3.Sex == this.Leader.Sex) && ((person3.Brother < 0) || (person3.Brother == person3.ID)))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Sex == this.Leader.Sex) && (person3.Brother < 0) || (person3.Brother == person3.ID))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((person3.Brother < 0) || (person3.Brother == person3.ID))
                    {
                        list.Add(person3);
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    person2 = list[0] as Person;
                }
            }
            if (person2 != null)
            {
                this.Leader = person2;
                this.Leader.Loyalty = 100;
                if (!((this.Leader.LocationTroop == null) || this.Leader.IsCaptive))
                {
                    this.Leader.LocationTroop.RefreshWithPersonList(this.Leader.LocationTroop.Persons.GetList());
                }
                foreach (Treasure treasure in leader.Treasures.GetList())
                {
                    leader.LoseTreasure(treasure);
                    this.Leader.ReceiveTreasure(treasure);
                }
				ExtensionInterface.call("ChangeKing", new Object[] { this.Scenario, this });
                base.Scenario.YearTable.addChangeKingEntry(base.Scenario.Date, this.Leader);
                return this;
            }
            foreach (Treasure treasure in leader.Treasures.GetList())
            {
                treasure.HidePlace = locationArchitecture;
                leader.LoseTreasure(treasure);
                treasure.Available = false;
            }
            return null;
        }

        public void CheckLeaderDeath(Person leader)
        {
            if ((((((leader.LocationArchitecture != null) && (leader.LocationArchitecture.BelongedFaction == this.Leader.BelongedFaction)) || ((leader.LocationTroop != null) && (leader.LocationTroop.BelongedFaction == this.Leader.BelongedFaction))) && (GameObject.Random(leader.CaptiveAbility) < GameObject.Random(this.Leader.CaptiveAbility))) && base.Scenario.IsPlayer(this)) && (this.OnAfterCatchLeader != null))
            {
                this.OnAfterCatchLeader(leader, this);
            }
        }

        public void ClearRouteways()
        {
            while (this.RoutewayCount > 0)
            {
                base.Scenario.RemoveRouteway(this.Routeways[0] as Routeway);
            }
        }

        private void ClearSections()
        {
            foreach (Section section in this.Sections.GetList())
            {
                this.RemoveSection(section);
                base.Scenario.Sections.Remove(section);
            }
            foreach (Architecture architecture in this.Architectures)
            {
                architecture.BelongedSection = null;
            }
        }

        public Section CreateFirstSection()
        {
            if ((this.Capital != null) && (this.ArchitectureCount > 0))
            {
                Section section = new Section();
                section.Scenario = base.Scenario;
                section.ID = base.Scenario.Sections.GetFreeGameObjectID();
                section.Name = this.Capital.Name + "军区";
                section.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无 , true, false, true, true, false)[0] as SectionAIDetail;
                foreach (Architecture architecture in this.Architectures)
                {
                    section.AddArchitecture(architecture);
                }
                this.AddSection(section);
                base.Scenario.Sections.AddSectionWithEvent(section);
                return section;
            }
            return null;
        }

        public void DayEvent()
        {
            this.SpyMessageCloseList.Clear();
            this.TechniquesDayEvent();
            this.InformationDayEvent();
            if (!base.Scenario.IsPlayer(this))
            {
                //this.AISelectPrince();
                this.AIchaotingshijian();
                this.AIBecomeEmperor();
            }
        }



        private void AISelectPrince()
        {
            if (!base.Scenario.IsPlayer(this))
            {
                if (GameObject.Random(100) == 0 && (this.Capital!=null)  && this.Capital.SelectPrinceAvail())
                {
                    Person person = this.Leader.ChildrenCanBeSelectedAsPrince()[0] as Person;
                    this.PrinceID = person.ID;
                    this.Capital.DecreaseFund(50000);
                    this.Scenario.GameScreen.xianshishijiantupian(this.Leader, person.Name, "SelectPrince", "", "", true);

                }
            }
        }

        private void AIchaotingshijian()
        {
            if (base.Scenario.youhuangdi() && !base.Scenario.IsPlayer(this)&&!this.IsAlien
                && (this.guanjue < this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1))
            {
                if (base.Scenario.Date.Month == 3)
                {
                    this.AIjingong();
                }
            }
        }

        private void AIjingong()
        {
            int cashToGive = 0;
            foreach (guanjuezhongleilei g in this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhongleiliebiao())
            {
                if (g.xuyaochengchi <= this.ArchitectureCount)
                {
                    cashToGive = g.xuyaogongxiandu - this.chaotinggongxiandu;
                }
            }

            if (cashToGive > 0)
            {
                int givenValue = 0;
                Dictionary<Architecture, int> archGiveFund = new Dictionary<Architecture, int>();
                foreach (Architecture a in this.Architectures.GetRandomList())
                {
                    int canGiveFund = a.Fund - a.AbundantFund;
                    if (canGiveFund >= 1000)
                    {
                        if (canGiveFund + givenValue >= cashToGive)
                        {
                            canGiveFund = cashToGive - givenValue;
                        }
                        givenValue += canGiveFund;
                        archGiveFund[a] = canGiveFund;
                    }
                    if (givenValue >= cashToGive)
                    {
                        foreach (KeyValuePair<Architecture, int> i in archGiveFund)
                        {
                            i.Key.DecreaseFund(i.Value);
                            if (!this.Architectures.HasGameObject(base.Scenario.huangdisuozaijianzhu()))
                            {
                                base.Scenario.huangdisuozaijianzhu().IncreaseFund(i.Value);
                            }
                            this.chaotinggongxiandu += i.Value;
                            this.Scenario.GameScreen.shilijingong(this, i.Value, "资金");
                        }
                        break;
                    }
                }
            }

            /*int jingongshue;
            int gongxianduzangzhang=0;
            bool jingongliangcao;
            float jingongxishu=0f;
            switch (this.Leader.ValuationOnGovernment)
            {
                case PersonValuationOnGovernment.无视  :
                    jingongxishu=0.1f;
                    break;
                case PersonValuationOnGovernment.普通 :
                    jingongxishu=0.2f;
                    break;
                case PersonValuationOnGovernment.重视 :
                    jingongxishu=0.3f;
                    break;
                    
            }
            jingongliangcao = (GameObject.Random(8) == 0);
            if (jingongliangcao)
            {
                if (this.Architectures.HasGameObject(base.Scenario.huangdisuozaijianzhu())) jingongxishu = 0.3f;

                jingongshue = (int)(this.Capital.Food  * jingongxishu);
                this.Capital.DecreaseFood(jingongshue);
                if (!this.Architectures.HasGameObject(base.Scenario.huangdisuozaijianzhu()))
                {
                    base.Scenario.huangdisuozaijianzhu().IncreaseFood(jingongshue);
                }
                gongxianduzangzhang = jingongshue / 200;
                this.chaotinggongxiandu += gongxianduzangzhang;

            }
            else
            {
                if (this.Architectures.HasGameObject(base.Scenario.huangdisuozaijianzhu())) jingongxishu = 0.5f;

                jingongshue = (int)(this.Capital.Fund * jingongxishu);
                this.Capital.DecreaseFund(jingongshue);
                if (!this.Architectures.HasGameObject(base.Scenario.huangdisuozaijianzhu()))
                {
                    base.Scenario.huangdisuozaijianzhu().IncreaseFund(jingongshue);

                }
                gongxianduzangzhang = jingongshue;
                this.chaotinggongxiandu += gongxianduzangzhang;

            }*/
            //this.Scenario.GameScreen.shilijingong(this,jingongshue,jingongliangcao?"粮草":"资金");

        }

        public void DecreaseReputation(int decrement)
        {
            this.reputation -= decrement;
            if (this.reputation < 0)
            {
                this.reputation = 0;
            }
        }

        public void DecreaseTechniquePoint(int decrement)
        {
            this.techniquePoint -= decrement;
            if (this.techniquePoint < 0)
            {
                this.techniquePoint = 0;
            }
        }

        public void DepositTechniquePointForFacility(int deposit)
        {
            if (deposit > this.techniquePointForFacility)
            {
                deposit = this.techniquePointForFacility;
            }
            this.techniquePointForFacility -= deposit;
            this.techniquePoint += deposit;
        }

        public void DepositTechniquePointForTechnique(int deposit)
        {
            if (deposit > this.techniquePointForTechnique)
            {
                deposit = this.techniquePointForTechnique;
            }
            this.techniquePointForTechnique -= deposit;
            this.techniquePoint += deposit;
        }

        public void Destroy()
        {
            base.Scenario.YearTable.addFactionDestroyedEntry(base.Scenario.Date, this);
            if (this.OnFactionDestroy != null)
            {
                this.OnFactionDestroy(this);
            }
            foreach (Captive captive in this.SelfCaptives.GetList())
            {
                //captive.TransformToNoFaction();
                captive.TransformToNoFactionCaptive();
            }
            /*
            foreach (Troop troop in this.Troops.GetList())
            {
                troop.Destroy();
            }
            */

            foreach (Section section in this.Sections.GetList())
            {
                this.RemoveSection(section);
                base.Scenario.Sections.Remove(section);
            }
            base.Scenario.DiplomaticRelations.RemoveDiplomaticRelationByFactionID(base.ID);
            base.Scenario.Factions.Remove(this);
            base.Scenario.PlayerFactions.Remove(this);
            this.Destroyed = true;
			ExtensionInterface.call("FactionDestroyed", new Object[] { this.Scenario, this });
        }

        private void Develop()
        {
            this.DevelopArchitectures();
        }

        private void DevelopArchitectures()
        {
            foreach (Architecture architecture in this.Architectures)
            {
                architecture.DevelopDay();
            }
        }

        private void DiplomaticRelationAI()
        {
            this.ResetFriendlyDiplomaticRelations();
        }

        public void EndControl()
        {
            this.ClearRouteways();
            foreach (Troop t in this.Troops)
            {
                t.ManualControl = false;
            }
        }

        public Section GetAnotherSection(Section section)
        {
            foreach (Section section2 in this.Sections)
            {
                if (section2 != section)
                {
                    return section2;
                }
            }
            return null;
        }

        public InformationLevel GetArchitectureKnownLevel(Architecture a)
        {
            InformationLevel level = InformationLevel.无;
            foreach (Point point in a.ArchitectureArea.Area)
            {
                if (this.knownAreaData[point.X, point.Y].Level > level)
                {
                    level = this.knownAreaData[point.X, point.Y].Level;
                }
            }
            return level;
        }

        public GameArea GetAvailableTroopDestination(Troop troop)
        {
            GameArea area = new GameArea();
            for (int i = 0; i < base.Scenario.MapTileData.GetLength(0); i++)
            {
                for (int j = 0; j < base.Scenario.MapTileData.GetLength(1); j++)
                {
                    Point point = new Point(i, j);
                    area.AddPoint(point);
                }
            }
            if (area.Count > 0)
            {
                return area;
            }
            return null;
        }

        private int GetAverageValueOfSecondTier(int x, int y)
        {
            return 0;
        }

        private int GetAverageValueOfThirdTier(int x, int y)
        {
            return 0;
        }

        public List<Point> GetCurrentRoutewayPath()
        {
            List<Point> path = new List<Point>();
            this.RoutewayPathBuilder.SetPath(path);
            return path;
        }

        public FactionList GetHostileFactions()
        {
            FactionList list = new FactionList();
            foreach (Faction faction in base.Scenario.Factions)
            {
                if (!((faction == this) || this.IsFriendly(faction)))
                {
                    list.Add(faction);
                }
            }
            return list;
        }

        public InformationLevel GetKnownAreaData(Point position)
        {
            if (base.Scenario.PositionOutOfRange(position))
            {
                return InformationLevel.未知;
            }
            return this.knownAreaData[position.X, position.Y].Level;
        }

        public InformationLevel GetKnownAreaDataNoCheck(Point position)
        {
            return this.knownAreaData[position.X, position.Y].Level;
        }

        public Legion GetLegion(Architecture will)
        {
            foreach (Legion legion in this.Legions)
            {
                if (legion.WillArchitecture == will)
                {
                    return legion;
                }
            }
            return null;
        }

        public int GetMapCost(Troop troop, Point position)
        {
            if (base.Scenario.PositionOutOfRange(position))
            {
                return 0xdac;
            }
            if (base.Scenario.GetTerrainDetailByPositionNoCheck(position).RoutewayConsumptionRate >= 1)
            {
                return 0xdac;
            }
            int terrainAdaptability = 0;
            if (base.Scenario.GetArchitectureByPositionNoCheck(position) == null)
            {
                terrainAdaptability = troop.GetTerrainAdaptability((TerrainKind) this.mapData[position.X, position.Y]);
            }
            int waterPunishment = 0;
            if (this.mapData[position.X, position.Y] == 6 && troop.Army.Kind.Type != MilitaryType.水军 && base.Scenario.GetArchitectureByPositionNoCheck(position) == null)
            {
                waterPunishment = 3;
            }
            return ((terrainAdaptability + base.Scenario.GetWaterPositionMapCost(troop.Army.Kind.Type, position)) + base.Scenario.GetPositionMapCost(this, position) + waterPunishment);
        }

        public FactionList GetOtherFactions()
        {
            FactionList list = new FactionList();
            foreach (Faction faction in base.Scenario.Factions)
            {
                if (faction != this)
                {
                    list.Add(faction);
                }
            }
            return list;
        }

        public SectionList GetOtherSections(Section section)
        {
            SectionList list = new SectionList();
            foreach (Section section2 in this.Sections)
            {
                if (section2 != section)
                {
                    list.Add(section2);
                }
            }
            return list;
        }

        private float GetPreferredTechniqueComplition()
        {
            int num = 0;
            int num2 = 0;
            foreach (Technique technique in base.Scenario.GameCommonData.AllTechniques.Techniques.Values)
            {
                if (this.PreferredTechniqueKinds.IndexOf(technique.Kind) >= 0)
                {
                    num2++;
                    if (this.HasTechnique(technique.ID))
                    {
                        num++;
                    }
                }
            }
            if (num2 > 0)
            {
                return (((float) num) / ((float) num2));
            }
            return 0f;
        }

        private Technique GetRandomTechnique()
        {
            List<Technique> list = new List<Technique>();
            foreach (Technique technique in base.Scenario.GameCommonData.AllTechniques.Techniques.Values)
            {
                if (this.IsTechniqueUpgradable(technique) && this.GetTechniqueUsefulness(technique) > 0)
                {
                    list.Add(technique);
                }
            }
            if (list.Count > 0)
            {
                return list[GameObject.Random(list.Count)];
            }
            return null;
        }

        public List<Point> GetSecondTierKnownPath(Point start, Point end)
        {
            ClosedPathEndpoints key = new ClosedPathEndpoints(start, end);
            if (this.SecondTierKnownPaths.ContainsKey(key))
            {
                return this.SecondTierKnownPaths[key];
            }
            return null;
        }

        public List<Point> GetThirdTierKnownPath(Point start, Point end)
        {
            ClosedPathEndpoints key = new ClosedPathEndpoints(start, end);
            if (this.ThirdTierKnownPaths.ContainsKey(key))
            {
                return this.ThirdTierKnownPaths[key];
            }
            return null;
        }

        private int GetThreat(Faction faction)
        {
            if (faction == null)
            {
                return 0;
            }
            return ((faction.ArchitectureTotalSize * 10) - base.Scenario.GetDiplomaticRelation(base.ID, faction.ID));
        }

        public GameObjectList GetUnderZeroDiplomaticRelationFactions()
        {
            GameObjectList list = new GameObjectList();
            foreach (DiplomaticRelation relation in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
            {
                if (relation.Relation < 0)
                {
                    if (relation.RelationFaction1 == this)
                    {
                        list.Add(relation.RelationFaction2);
                    }
                    else
                    {
                        list.Add(relation.RelationFaction1);
                    }
                }
            }
            return list;
        }

        public Faction GetFactionByName(string FactionName)
        {
            foreach (Faction i in base.Scenario.Factions)
            {
                if (i.Name == FactionName) return i;
            }
            return null;
        }

        public void HandleForcedChangeCapital()
        {
            this.Reputation /= 2;
            if (this.Architectures.Count != 1)
            {
                Architecture capital = this.Capital;
                if (this.Architectures.Count == 2)
                {
                    foreach (Architecture architecture2 in this.Architectures)
                    {
                        if (architecture2 != this.Capital)
                        {
                            this.Capital = architecture2;
                            if (this.OnForcedChangeCapital != null)
                            {
                                this.OnForcedChangeCapital(this, capital, this.Capital);
                            }
                            base.Scenario.YearTable.addChangeCapitalEntry(base.Scenario.Date, this, this.Capital);
                            break;
                        }
                    }
                }
                else
                {
                    this.Capital = this.SelectNewCapital();
                    if (this.OnForcedChangeCapital != null)
                    {
                        this.OnForcedChangeCapital(this, capital, this.Capital);
                    }
                    base.Scenario.YearTable.addChangeCapitalEntry(base.Scenario.Date, this, this.Capital);
                }
            }
			ExtensionInterface.call("ForceChangeCapital", new Object[] { this.Scenario, this });
        }

        public bool HasArchitecture(Architecture architecture)
        {
            return this.Architectures.HasGameObject(architecture);
        }

        public bool HasCaptive()
        {
            return (this.CaptiveCount > 0);
        }

        public bool HasMilitaryKind(int id)
        {
            foreach (Military military in this.Militaries)
            {
                if (military.RealKindID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasPerson(Person person)
        {
            return this.Persons.HasGameObject(person);
        }

        public bool HasSelfCaptive()
        {
            return (this.SelfCaptiveCount > 0);
        }

        public bool HasTechnique(int id)
        {
            return (this.AvailableTechniques.GetTechnique(id) != null);
        }

        public void IncreaseReputation(int increment)
        {
            this.reputation += increment;
            if (this.reputation > this.shengwangshangxian) this.reputation = this.shengwangshangxian;

        }

        public void IncreaseTechniquePoint(int increment)
        {
            this.techniquePoint = (int) (this.techniquePoint + increment * GlobalVariables.TechniquePointMultiple);
        }

        private void InformationDayEvent()
        {
            InformationList list = new InformationList();
            foreach (Information information in this.Informations)
            {
                information.DaysLeft--;
                if (information.DaysLeft == 0)
                {
                    list.Add(information);
                }
                else
                {
                    information.CheckAmbushTroop();
                }
            }
            foreach (Information information in list)
            {
                information.Purify();
                this.RemoveInformation(information);
                base.Scenario.Informations.Remove(information);
            }
        }

        public bool IsArchitectureKnown(Architecture a)
        {
            foreach (Point point in a.ArchitectureArea.Area)
            {
                if (this.knownAreaData[point.X, point.Y].Level != InformationLevel.无)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFriendly(Faction faction)
        {
            if (faction == null)
            {
                return false;
            }
            return ((faction == this) || (base.Scenario.GetDiplomaticRelation(base.ID, faction.ID) >= 300) || (base.Scenario.GetDiplomaticRelationTruce(base.ID, faction.ID) > 0));
        }

        public bool IsHostile(Faction faction)
        {
            if (faction == null)
            {
                return false;
            }
            if (faction == this)
            {
                return false;
            }
            return (base.Scenario.GetDiplomaticRelation(base.ID, faction.ID) < 0);
        }

        public bool IsPositionKnown(Point position)
        {
            if (base.Scenario.PositionOutOfRange(position))
            {
                return false;
            }
            return (this.knownAreaData[position.X, position.Y].Level != InformationLevel.无);
        }

        private bool IsTechniqueUpgradable(Technique t)
        {
            return (!this.HasTechnique(t.ID) && ((t.PreID < 0) || this.HasTechnique(t.PreID)));
        }

        public bool IsTechniqueUpgrading(int id)
        {
            return (id == this.UpgradingTechnique);
        }

        public void LoadArchitecturesFromString(ArchitectureList architectures, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Architectures.Clear();
            foreach (string str in strArray)
            {
                Architecture gameObject = architectures.GetGameObject(int.Parse(str)) as Architecture;
                if (gameObject != null)
                {
                    this.AddArchitecture(gameObject);
                    this.AddArchitectureMilitaries(gameObject);
                }
            }
        }

        public void LoadInformationsFromString(InformationList informations, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Informations.Clear();
            foreach (string str in strArray)
            {
                Information gameObject = informations.GetGameObject(int.Parse(str)) as Information;
                if (gameObject != null)
                {
                    this.AddInformation(gameObject);
                }
            }
        }

        public void LoadLegionsFromString(LegionList legions, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Legions.Clear();
            foreach (string str in strArray)
            {
                Legion gameObject = legions.GetGameObject(int.Parse(str)) as Legion;
                if (gameObject != null)
                {
                    this.AddLegion(gameObject);
                }
            }
        }

        public void LoadRoutewaysFromString(RoutewayList routeways, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Routeways.Clear();
            foreach (string str in strArray)
            {
                Routeway gameObject = routeways.GetGameObject(int.Parse(str)) as Routeway;
                if (gameObject != null)
                {
                    this.AddRouteway(gameObject);
                }
            }
        }

        public void LoadSectionsFromString(SectionList sections, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Sections.Clear();
            foreach (string str in strArray)
            {
                Section gameObject = sections.GetGameObject(int.Parse(str)) as Section;
                if (gameObject != null)
                {
                    this.AddSection(gameObject);
                }
            }
        }

        public void LoadTroopsFromString(TroopList troops, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Troops.Clear();
            foreach (string str in strArray)
            {
                Troop gameObject = troops.GetGameObject(int.Parse(str)) as Troop;
                if (gameObject != null)
                {
                    this.AddTroop(gameObject);
                    this.AddTroopMilitary(gameObject);
                }
            }
        }

        public int getTechniqueActualPointCost(Technique technique)
        {
            return (int) Math.Round(technique.PointCost * (1 - this.techniquePointCostRateDecrease));
        }

        public int getTechniqueActualReputation(Technique technique)
        {
            return (int) Math.Round(technique.Reputation * (1 - this.techniqueReputationRateDecrease));
        }

        public int getTechniqueActualFundCost(Technique technique)
        {
            return (int) Math.Round(technique.FundCost * (1 - this.techniqueFundCostRateDecrease));
        }

        public int getTechniqueActualTime(Technique technique)
        {
            return (int) Math.Round(technique.Days * (1 - techniqueTimeRateDecrease));
        }

        public bool MatchTechnique(Technique technique, Architecture architecture)
        {
            return (((((this.TotalTechniquePoint >= this.getTechniqueActualPointCost(technique)) && 
                (this.Reputation >= this.getTechniqueActualReputation(technique))) && 
                (architecture.Fund >= this.getTechniqueActualFundCost(technique))) && 
                (this.HasTechnique(technique.PreID) || (technique.PreID < 0))) && (this.UpgradingTechnique < 0));
        }

        public void MonthEvent()
        {
            this.DiplomaticRelationAI();
        }

        private void PlayerAI()
        {
            base.Scenario.Threading = true;
            this.AIFinished = false;
            this.AIPrepare();
            this.PlayerTechniqueAI();
            this.PlayerAIArchitectures();
            this.PlayerAILegions();
            this.AIFinished = true;
            base.Scenario.Threading = false;
        }

        private void PlayerAIArchitectures()
        {
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                if (architecture.BelongedSection.AIDetail.AutoRun)
                {
                    architecture.AI();
                }
                else
                {
                    architecture.PlayerAutoAI();
                }
            }
        }

        private void PlayerAILegions()
        {
            foreach (Legion legion in this.Legions.GetRandomList())
            {
                if ((legion.StartArchitecture != null) && (legion.StartArchitecture.BelongedFaction == this))
                {
                    if (legion.StartArchitecture.BelongedSection.AIDetail.AutoRun)
                    {
                        legion.AI();
                    }
                    else
                    {
                        legion.AIWithAuto();
                    }
                }
                else
                {
                    legion.AIWithAuto();
                }
            }
        }

        private void PlayerTechniqueAI()
        {
            this.SaveTechniquePointForTechnique(this.TechniquePoint / 4);
        }

        public void PrepareData()
        {
            this.mapData = base.Scenario.ScenarioMap.MapData;
            this.architectureAdjustCost = new int[base.Scenario.ScenarioMap.MapDimensions.X, base.Scenario.ScenarioMap.MapDimensions.Y];
            this.knownAreaData = new InformationTile[base.Scenario.ScenarioMap.MapDimensions.X, base.Scenario.ScenarioMap.MapDimensions.Y];
            this.PrepareSecondTierMapCost();
            this.PrepareThirdTierMapCost();
            this.PrepareKnownAreaData();
            this.PrepareInformations();
        }

        public void PrepareInformations()
        {
            foreach (Information information in this.Informations)
            {
                information.Initialize();
            }
        }

        protected void PrepareKnownAreaData()
        {
            foreach (Architecture architecture in this.Architectures)
            {
                this.AddArchitectureKnownData(architecture);
            }
        }

        private void PrepareSecondTierMapCost()
        {
            this.SecondTierXResidue = base.Scenario.ScenarioMap.MapDimensions.X % GameObjectConsts.SecondTierSquareSize;
            this.SecondTierYResidue = base.Scenario.ScenarioMap.MapDimensions.Y % GameObjectConsts.SecondTierSquareSize;
            int num = base.Scenario.ScenarioMap.MapDimensions.X / GameObjectConsts.SecondTierSquareSize;
            int num2 = base.Scenario.ScenarioMap.MapDimensions.Y / GameObjectConsts.SecondTierSquareSize;
            if (this.SecondTierXResidue > 0)
            {
                num++;
            }
            if (this.SecondTierYResidue > 0)
            {
                num2++;
            }
            this.secondTierMapCost = new int[num, num2];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    this.secondTierMapCost[i, j] = this.GetAverageValueOfSecondTier(i, j);
                }
            }
        }

        private void PrepareThirdTierMapCost()
        {
            this.ThirdTierXResidue = base.Scenario.ScenarioMap.MapDimensions.X % GameObjectConsts.ThirdTierSquareSize;
            this.ThirdTierYResidue = base.Scenario.ScenarioMap.MapDimensions.Y % GameObjectConsts.ThirdTierSquareSize;
            int num = base.Scenario.ScenarioMap.MapDimensions.X / GameObjectConsts.ThirdTierSquareSize;
            int num2 = base.Scenario.ScenarioMap.MapDimensions.Y / GameObjectConsts.ThirdTierSquareSize;
            if (this.ThirdTierXResidue > 0)
            {
                num++;
            }
            if (this.ThirdTierYResidue > 0)
            {
                num2++;
            }
            this.thirdTierMapCost = new int[num, num2];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    this.thirdTierMapCost[i, j] = this.GetAverageValueOfThirdTier(i, j);
                }
            }
        }

        public void PurifyTechniques()
        {
            foreach (Technique technique in this.AvailableTechniques.Techniques.Values)
            {
                technique.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Technique, technique.ID);
            }
        }

        private void RebuildSections()
        {
            if ((this.Capital != null) && (base.Scenario.GameScreen.LoadScenarioInInitialization || (base.Scenario.Date.Day == 1)))
            {
                if (base.Scenario.GameScreen.LoadScenarioInInitialization || ((base.Scenario.Date.Month % 3) == 1))
                {
                    this.ClearSections();
                    this.BuildSectionByArchitectureList(this.Architectures.GetList());
                    foreach (Section section in this.Sections)
                    {
                        section.RefreshSectionName();
                    }
                }
                this.SetSectionAIDetail();
                this.SetSectionAIDetailPinAtPlayer();
            }
        }

        public void RemoveArchitecture(Architecture architecture)
        {
            this.Architectures.Remove(architecture);
            architecture.BelongedFaction = null;
        }

        public void RemoveArchitectureKnownData(Architecture a)
        {
            foreach (Point point in a.ArchitectureArea.Area)
            {
                this.knownAreaData[point.X, point.Y].RemoveInformationLevel(InformationLevel.全);
            }
            foreach (Point point in a.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    this.knownAreaData[point.X, point.Y].RemoveInformationLevel(InformationLevel.高);
                }
            }
            if (a.Kind.HasLongView)
            {
                foreach (Point point in a.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        this.knownAreaData[point.X, point.Y].RemoveInformationLevel(InformationLevel.中);
                    }
                }
            }
        }

        public void RemoveArchitectureMilitaries(Architecture architecture)
        {
            foreach (Military military in architecture.Militaries)
            {
                this.RemoveMilitary(military);
            }
        }

        public void RemoveInformation(Information information)
        {
            this.Informations.Remove(information);
            information.BelongedFaction = null;
        }

        public void RemoveLegion(Legion legion)
        {
            this.Legions.Remove(legion);
            legion.BelongedFaction = null;
        }

        public void RemoveMilitary(Military military)
        {
            this.Militaries.Remove(military);
            military.BelongedFaction = null;
        }

        public void RemovePositionInformation(Point position, InformationLevel level)
        {
            if (!base.Scenario.PositionOutOfRange(position))
            {
                this.knownAreaData[position.X, position.Y].RemoveInformationLevel(level);
            }
        }

        public void RemoveRouteway(Routeway routeway)
        {
            this.Routeways.Remove(routeway);
            routeway.BelongedFaction = null;
        }

        public void RemoveSection(Section section)
        {
            this.Sections.Remove(section);
            section.BelongedFaction = null;
        }

        public void RemoveTroop(Troop troop)
        {
            this.Troops.Remove(troop);
            troop.BelongedFaction = null;
        }

        public void RemoveTroopKnownAreaData(Troop troop)
        {
            foreach (Point point in troop.ViewArea.Area)
            {
                if (base.Scenario.PositionOutOfRange(point))
                {
                    continue;
                }
                if (point == troop.ViewArea.Centre)
                {
                    this.knownAreaData[point.X, point.Y].RemoveInformationLevel(InformationLevel.全);
                }
                else
                {
                    this.knownAreaData[point.X, point.Y].RemoveInformationLevel(troop.ScoutLevel);
                }
            }
        }

        public void RemoveTroopMilitary(Troop troop)
        {
            this.RemoveMilitary(troop.Army);
        }

        public bool adjacentTo(Faction f)
        {
            if (f != null)
            {
                foreach (Architecture i in this.Architectures)
                {
                    foreach (Architecture j in f.Architectures)
                    {
                        if (i.AILandLinks.GameObjects.Contains(j) || i.AIWaterLinks.GameObjects.Contains(j))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        private bool hasNonFriendlyFrontline
        {
            get
            {
                foreach (Architecture i in this.Architectures)
                {
                    foreach (Architecture j in i.AILandLinks)
                    {
                        if (j.BelongedFaction==null) continue;
                        if (j.BelongedFaction.ID == this.ID) continue;
                        if (base.Scenario.DiplomaticRelations.GetDiplomaticRelation(j.BelongedFaction.ID, this.ID).Relation < 300)
                        {
                            return true;
                        }
                    }
                    foreach (Architecture j in i.AIWaterLinks)
                    {
                        if (j.BelongedFaction == null) continue;
                        if (j.BelongedFaction.ID == this.ID) continue;
                        if (base.Scenario.DiplomaticRelations.GetDiplomaticRelation(j.BelongedFaction.ID, this.ID).Relation < 300)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public void CheckEncircleDiplomaticByFactionName(string EncircleFactionName)
        {
            FactionList encircleList = new FactionList();
            int fc = 0;
            foreach (Faction f in base.Scenario.Factions)
            {
                if ((f.Name != EncircleFactionName) && (f.Leader.StrategyTendency != PersonStrategyTendency.维持现状) && ! f.IsAlien)
                {
                    fc++;
                    if (((base.Scenario.DiplomaticRelations.GetDiplomaticRelation(this.GetFactionByName(EncircleFactionName).ID, f.ID).Relation +
                        Person.GetIdealOffset(this.GetFactionByName(EncircleFactionName).Leader, f.Leader) * 1.5) < 0
                        && GameObject.Chance(60))
                        )
                    {
                        encircleList.Add(f);
                    }
                }
            }
            if ((encircleList.Count * 2 > fc) && fc > 3)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, "EncircleDiplomaticRelation", "EncircleDiplomaticRelation.jpg", "EncircleDiplomaticRelation.wav", EncircleFactionName, true);
                foreach (Faction i in encircleList)
                {
                    foreach (Faction j in encircleList)
                    {
                        if (i != j)
                        {
                            if (this.Scenario.DiplomaticRelations.GetDiplomaticRelation(i.ID, j.ID).Truce < 90)
                            {
                                this.Scenario.DiplomaticRelations.GetDiplomaticRelation(i.ID, j.ID).Truce = 90;
                            }
                        }
                    }
                }
            }
        }

        private void ResetFriendlyDiplomaticRelations()
        {
            if (base.Scenario.IsPlayer(this)) return;

            bool relationBroken = false;

            if (GlobalVariables.PinPointAtPlayer)
            {
                foreach (DiplomaticRelation i in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
                {
                    Faction opposite = i.GetDiplomaticFaction(this.ID);
                    if (i.Relation >= -300 && base.Scenario.IsPlayer(opposite)){
                        i.Relation -= 15; //focus到玩家的时候，每月降低15点友好度
                        relationBroken = true;
                    }
                }
            }
            if ((this.Leader.StrategyTendency != PersonStrategyTendency.维持现状))
            {
                int minTroop = int.MaxValue;
                DiplomaticRelation minTroopFactionRelation = null;
                Faction minTroopFactionopposite = null;

                foreach (DiplomaticRelation i in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
                {
                    Faction opposite = i.GetDiplomaticFaction(this.ID);
                    //if (i.Relation < 300) continue; 
                    if (!this.adjacentTo(opposite)) continue;    //不接壤的AI不主动改变关系值
                    if (GameObject.Chance((int)((double)this.ArmyScale / opposite.ArmyScale * ((int)this.Leader.Ambition + 1) * 20))
                        && i.Relation < 300)
                    {
                        i.Relation -= (7 + (int)Random(15)); //根据总兵力情况每月随机减少
                        relationBroken = true;
                        break;
                    }
                    //增加关系300以上，随机一个降低数值后主动解盟的情况
                    if (GameObject.Chance((int)(Person.GetIdealOffset(this.Leader, opposite.Leader)/3)) && i.Relation >= 300)
                    {
                        i.Relation -= (7 + (int)Random(15));
                        relationBroken = true;
                        if (i.Relation < 300)
                        {
                            //显示联盟破裂画面
                            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, "BreakDiplomaticRelation", "BreakDiplomaticRelation.jpg", "BreakDiplomaticRelation.wav", opposite.Leader.Name, true);
                        }
                        break;
                    }

                    if (!this.hasNonFriendlyFrontline)
                    {
                        if (opposite.ArmyScale < minTroop)
                        {
                            minTroop = opposite.ArmyScale;
                            minTroopFactionRelation = i;
                            minTroopFactionopposite = i.GetDiplomaticFaction(this.ID);
                        }
                    }
                }
                if (minTroopFactionRelation != null && !relationBroken)
                {
                    minTroopFactionRelation.Relation = 0;
                    //AI宣布主动解盟
                    this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, "ResetDiplomaticRelation", "ResetDiplomaticRelation.jpg", "ResetDiplomaticRelation.wav", minTroopFactionopposite.LeaderName, true);
                }
            }
        }

        public bool RoutewayPathAvail(Point start, Point end, bool hasEnd)
        {
            return this.RoutewayPathBuilder.GetPath(start, end, hasEnd);
        }

        private int RoutewayPathBuilder_OnGetCost(Point position, out float consumptionRate)
        {
            consumptionRate = 0f;
            if (!base.Scenario.PositionOutOfRange(position))
            {
                if (base.Scenario.GetArchitectureByPositionNoCheck(position) != null)
                {
                    return 0x3e8;
                }
                if (this.RoutewayPathBuilder.MultipleWaterCost && !base.Scenario.IsWaterPositionRoutewayable(position))
                {
                    return 0x3e8;
                }
                TerrainDetail terrainDetailByPositionNoCheck = base.Scenario.GetTerrainDetailByPositionNoCheck(position);
                if (terrainDetailByPositionNoCheck != null)
                {
                    consumptionRate = terrainDetailByPositionNoCheck.RoutewayConsumptionRate;
                    int routewayBuildWorkCost = terrainDetailByPositionNoCheck.RoutewayBuildWorkCost;
                    int routewayWorkForce = this.RoutewayWorkForce;
                    if (this.RoutewayPathBuilder.MultipleWaterCost && (terrainDetailByPositionNoCheck.ID == 6))
                    {
                        routewayBuildWorkCost = this.RoutewayWorkForce;
                    }
                    return ((routewayBuildWorkCost <= routewayWorkForce) ? routewayBuildWorkCost : 0x3e8);
                }
            }
            return 0x3e8;
        }

        private int RoutewayPathBuilder_OnGetPenalizedCost(Point position)
        {
            foreach (Architecture architecture in base.Scenario.GetHighViewingArchitecturesByPosition(position))
            {
                if (!((architecture.BelongedFaction == null) || this.IsFriendly(architecture.BelongedFaction)))
                {
                    return (this.RoutewayWorkForce / 2);
                }
            }
            return 0;
        }

        public bool Run()
        {
            Thread thread;
            if (!this.preUserControlFinished)
            {
                this.Develop();
                this.preUserControlFinished = true;
            }
            if (this.Controlling || this.Passed)
            {
                return this.Passed;
            }
            if (base.Scenario.IsPlayer(this))
            {
                if (this.WantControl)
                {
                    if (!base.Scenario.Threading)
                    {
                        if (!this.AIFinished)
                        {
                            /*thread = new Thread(new ThreadStart(this.PlayerAI));
                            thread.Start();
                            thread.Join();
                            thread = null;*/
                            this.PlayerAI();
                            return false;
                        }
                        this.Controlling = true;
                        if (this.OnGetControl != null)
                        {
                            this.OnGetControl(this);
                        }
                        return false;
                    }
                    return false;
                }
                if (!base.Scenario.Threading)
                {
                    if (!this.AIFinished)
                    {
                        /*thread = new Thread(new ThreadStart(this.PlayerAI));
                            thread.Start();
                            thread.Join();
                            thread = null;*/
                        this.PlayerAI();
                        return false;
                    }
                    this.Passed = true;
                    return true;
                }
                return false;
            }
            if (!base.Scenario.Threading)
            {
                if (!this.AIFinished)
                {
                    /*thread = new Thread(new ThreadStart(this.AI));
                            thread.Start();
                            thread.Join();
                            thread = null;*/
                    this.AI();
                    return false;
                }
                this.Passed = true;
                return true;
            }
            return false;
        }

        public string SaveLegionsToString()
        {
            string str = "";
            foreach (Legion legion in this.Legions)
            {
                str = str + legion.ID.ToString() + " ";
            }
            return str;
        }

        public string SaveSectionsToString()
        {
            string str = "";
            foreach (Section section in this.Sections)
            {
                str = str + section.ID.ToString() + " ";
            }
            return str;
        }

        public void SaveTechniquePointForFacility(int credit)
        {
            if (credit > this.techniquePoint)
            {
                credit = this.techniquePoint;
            }
            this.techniquePoint -= credit;
            this.techniquePointForFacility += credit;
        }

        public void SaveTechniquePointForTechnique(int credit)
        {
            if (credit > this.techniquePoint)
            {
                credit = this.techniquePoint;
            }
            this.techniquePoint -= credit;
            this.techniquePointForTechnique += credit;
        }

        public string SaveTroopsToString()
        {
            string str = "";
            foreach (Troop troop in this.Troops)
            {
                str = str + troop.ID.ToString() + " ";
            }
            return str;
        }

        public void SeasonEvent()
        {
            if (!base.Scenario.scenarioJustLoaded)
            {
                this.shizheshengguan();
            }
        }


        internal bool  BecomeEmperorLegallyAvail()  //可以禅位
        {
            if (this.IsAlien || !base.Scenario.youhuangdi())
            {
                return false;
            }
            if (this.guanjue != this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 2)  //不是王
            {
                return false ;
            }
            if (this.Capital.Fund < 100000)
            {
                return false;
            }
            guanjuezhongleilei shengjiguanjue = new guanjuezhongleilei();
            shengjiguanjue = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1);
            if (this.HasEmperor() && this.chaotinggongxiandu >= shengjiguanjue.xuyaogongxiandu && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
            {
                return true;
            }
            return false;
        }

        internal bool SelfBecomeEmperorAvail()  //可以称帝
        {
            if (this.guanjue != this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 2)  //不是王
            {
                return false ;
            }
            if (this.Capital.Fund < 100000)
            {
                return false;
            }
            guanjuezhongleilei shengjiguanjue = new guanjuezhongleilei();
            shengjiguanjue = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1);

            if (this.IsAlien)
            {
                if (this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (base.Scenario.youhuangdi())
                {
                    if (!this.HasEmperor() && this.chaotinggongxiandu >= shengjiguanjue.xuyaogongxiandu && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    if (this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        private void AIBecomeEmperor()
        {
            if (this.guanjue != this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 2)  //不是王
            {
                return;
            }
            if (this.Capital==null||this.Capital.Fund < 100000)
            {
                return;
            }
            guanjuezhongleilei shengjiguanjue = new guanjuezhongleilei();
            shengjiguanjue = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1);
            if (base.Scenario.youhuangdi())
            {
                if (this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfBecomeEmperor();
                }
                else if (!this.IsAlien && this.chaotinggongxiandu >= shengjiguanjue.xuyaogongxiandu && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    if (this.HasEmperor())
                    {
                        foreach (Faction f in base.Scenario.Factions.GameObjects)
                        {
                            if (f == this) continue;
                            if (f.guanjue == base.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1) continue;
                            if (GameObject.Random((int) (((int) this.Leader.Ambition + 1) * 2 * (this.ArchitectureCount / (double) f.ArchitectureCount))) == 0)
                            {
                                return;
                            }
                        }
                        this.BecomeEmperorLegally();
                    }
                    else if (this.Leader.ValuationOnGovernment == PersonValuationOnGovernment.无视 ||
                        (this.Leader.ValuationOnGovernment == PersonValuationOnGovernment.普通 && GameObject.Chance(5)))
                    {
                        /*Faction owningEmperor = null;
                        foreach (Faction f in base.Scenario.Factions.GameObjects)
                        {
                            if (f.HasEmperor())
                            {
                                owningEmperor = f;
                                break;
                            }
                        }*/
                        if (GameObject.Random((int) ((5 - (int) this.Leader.Ambition) * 100 / (double) this.ArchitectureCount)) == 0)
                        {
                            this.SelfBecomeEmperor();
                        }
                    }
                }
            }
            else
            {
                if (this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfBecomeEmperor();
                }
                else if (!this.IsAlien &&  this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfBecomeEmperor();
                }
            }

        }

        public  void BecomeEmperorLegally()
        {
            this.guanjue++;
            base.Scenario.YearTable.addBecomeEmperorLegallyEntry(base.Scenario.Date, this.Scenario.Persons.GetGameObject(7000) as Person, this);
            this.Scenario.GameScreen.xianshishijiantupian(this.Scenario.Persons.GetGameObject(7000) as Person, this.LeaderName, "BecomeEmperorLegally", "shanwei.jpg", "",
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, true);
            this.Scenario.GameScreen.xiejinxingjilu("BecomeEmperorLegally", this.LeaderName,
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, this.Leader.Position);
            this.Capital.DecreaseFund(100000);

            ExtensionInterface.call("BecomeEmperorLegally", new Object[] { this.Scenario, this });
            this.Scenario.BecomeNoEmperor();
        }

        private bool HasEmperor()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai) return true;
            }
            return false;
        }



        private void shizheshengguan()
        {
            if (this.guanjue>= this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count-2)  //已经是王或者皇帝
            {
                return;
            }
            guanjuezhongleilei shengjiguanjue=new guanjuezhongleilei();
            shengjiguanjue=this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue+1);
            if (base.Scenario.youhuangdi())
            {
                if (this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfAdvancement();
                }
                else if (!this.IsAlien && this.chaotinggongxiandu >= shengjiguanjue.xuyaogongxiandu && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.Advancement();
                }
            }
            else 
            {
                if (this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfAdvancement();
                }
                else if (!this.IsAlien  && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfAdvancement();
                }
            }



        }

        public  void SelfBecomeEmperor()
        {
            this.guanjue++;
            base.Scenario.YearTable.addSelfBecomeEmperorEntry(base.Scenario.Date, this);
            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.LeaderName, "Zili", "BecomeEmperor.jpg", "",
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, true);
            this.Scenario.GameScreen.xiejinxingjilu("Zili", this.LeaderName,
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, this.Leader.Position);
            this.Capital.DecreaseFund(100000);
            if (!base.Scenario.youhuangdi() || this.IsAlien)
            {
                return;
            }
            else
            {
                this.DoSelfBecomeEmperorInfluence();
            }
            ExtensionInterface.call("SelfBecomeEmperor", new Object[] { this.Scenario, this });
        }

        private void DoSelfBecomeEmperorInfluence()
        {
            foreach (Architecture a in this.Architectures)
            {
                a.Morale = (int)(a.Morale * 0.9f);
            }
            float loyaltyMultiplier;
            foreach (Person person in this.Persons)
            {
                if (person == this.Leader)
                {
                    continue;
                }
                
                switch (person.ValuationOnGovernment)
                {
                    case PersonValuationOnGovernment.无视:
                        loyaltyMultiplier = 1f;
                        break;
                    case PersonValuationOnGovernment.普通:
                        loyaltyMultiplier = 0.8f;
                        break;
                    case PersonValuationOnGovernment.重视:
                        loyaltyMultiplier = 0.5f;
                        break;
                    default:
                        continue;

                }
                person.Loyalty =(int) (person.Loyalty * loyaltyMultiplier);
            }
            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, "", "SelfBecomeEmperorInfluence", "","", true);
        }


        private void Advancement()
        {
            this.guanjue++;
            this.Scenario.GameScreen.xianshishijiantupian(this.Scenario.Persons.GetGameObject(7000) as Person, this.LeaderName, "shengguan", "shengguan.jpg", "",
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, true);
            this.Scenario.GameScreen.xiejinxingjilu("shengguan", this.LeaderName,
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, this.Leader.Position);
            base.Scenario.YearTable.addAdvanceGuanjueEntry(base.Scenario.Date, this, this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue));
			ExtensionInterface.call("Advancement", new Object[] { this.Scenario, this });
        }

        private void SelfAdvancement()
        {
            this.guanjue++;
            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.LeaderName, "Zili", "", "",
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, true);
            this.Scenario.GameScreen.xiejinxingjilu("Zili", this.LeaderName,
                this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, this.Leader.Position);
            base.Scenario.YearTable.addSelfAdvanceGuanjueEntry(base.Scenario.Date, this, this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue));
			ExtensionInterface.call("SelfAdvancement", new Object[] { this.Scenario, this });
        }

        public int CityCount
        {
            get
            {
                return chengchigeshu();
            }
        }

        public int chengchigeshu()
        {
            int geshu = 0;
            foreach (Architecture a in this.Architectures)
            {
                if (a.Kind.CountToMerit)
                {
                    geshu++;
                }
            }
            return geshu;
        }

        public string guanjuezifuchuan
        {
            get
            {
                return this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name;
            }
        }

        public int shengwangshangxian
        {
            get
            {
                return this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).shengwangshangxian;
            }

        }
        public int shengguanxuyaogongxiandu
        {
            get
            {
                if (this.IsAlien||!base.Scenario.youhuangdi())
                {
                    return 0;
                }
                else
                {
                    if (this.guanjue >= this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1).xuyaogongxiandu;

                    }
                }
            }

        }
        public int shengguanxuyaochengchi
            
        {
            get
            {
                if (this.guanjue >= this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1)
                {
                    return 0;
                }
                else
                {
                    return this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1).xuyaochengchi;

                }
            }

        }

        public Architecture SelectNewCapital()
        {
            int population = 0;
            Architecture architecture = null;
            foreach (Architecture architecture2 in this.Architectures)
            {
                if ((architecture2 != this.Capital) && (architecture2.Population >= population))
                {
                    architecture = architecture2;
                    population = architecture2.Population;
                }
            }
            return architecture;
        }

        private void SetSectionAIDetail()
        {
            foreach (Section s in this.Sections)
            {
                GameObjectList candidates = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, false);
                if (candidates.Count > 0)
                {
                    s.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetail(candidates[GameObject.Random(candidates.Count)].ID);
                }
            }
        }

        private void SetSectionAIDetail_OLD()
        {
            Faction faction;
            int num2;
            int threat;
            GameObjectList sectionNoOrientationAutoAIDetailsByConditions;
            int num5;
            GameObjectList list5;
            if (this.SectionCount <= 1)
            {
                num5 = ((this.FirstSection.ArchitectureScale / 2) - (this.FirstSection.ArchitectureCount / 2)) + 1;
                if (this.ArmyScale < (num5 * 6))
                {
                    if (!this.Capital.IsOK())
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, false, false, false);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    else
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(false, true);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    return;
                }
                if (this.ArmyScale < (num5 * 12))
                {
                    if (!this.Capital.IsOK())
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, false, false, false);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    else
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(false, true);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    return;
                }
                if (this.ArmyScale < (num5 * 20))
                {
                    if (!this.Capital.IsOK())
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, false, false, false);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    else
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, true);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                    }
                    return;
                }
                if (this.ArmyScale >= (num5 * 30))
                {
                    if (!this.Capital.IsGood())
                    {
                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, false);
                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                        {
                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                        }
                        return;
                    }
                    faction = null;
                    num2 = -2147483648;
                    foreach (Faction faction2 in base.Scenario.Factions.GetRandomList())
                    {
                        if (((faction2 != this) && !this.IsFriendly(faction2)) && (faction2.Capital != null))
                        {
                            threat = this.GetThreat(faction2);
                            if ((threat > num2) || GameObject.Chance(20))
                            {
                                num2 = threat;
                                faction = faction2;
                            }
                        }
                    }
                    if ((faction != null) && (this.FirstSection.OrientationFaction != faction))
                    {
                        foreach (Architecture architecture in this.Architectures)
                        {
                            if (architecture.HasFactionInClose(faction, 1))
                            {
                                sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.势力, true, true, true, false, true);
                                if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                {
                                    this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                    this.FirstSection.OrientationFaction = faction;
                                }
                                break;
                            }
                        }
                    }
                    list5 = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
                    if (list5.Count > 0)
                    {
                        this.FirstSection.AIDetail = list5[GameObject.Random(list5.Count)] as SectionAIDetail;
                        if (this.Capital.LocationState.GetFactionScale(this) < 100)
                        {
                            this.FirstSection.OrientationState = this.Capital.LocationState;
                        }
                        else
                        {
                            this.FirstSection.OrientationState = this.Capital.LocationState.ContactStates[GameObject.Random(this.Capital.LocationState.ContactStates.Count)] as State;
                        }
                    }
                    return;
                }
                if (!this.Capital.IsGood())
                {
                    sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, false);
                    if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                    {
                        this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                    }
                    return;
                }
                faction = null;
                num2 = -2147483648;
                foreach (Faction faction2 in this.GetUnderZeroDiplomaticRelationFactions().GetRandomList())
                {
                    threat = this.GetThreat(faction2);
                    if ((threat > num2) || GameObject.Chance(20))
                    {
                        num2 = threat;
                        faction = faction2;
                    }
                }
                if ((faction != null) && (this.FirstSection.OrientationFaction != faction))
                {
                    foreach (Architecture architecture in this.Architectures)
                    {
                        if (architecture.HasFactionInClose(faction, 1))
                        {
                            sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.势力, true, true, true, false, true);
                            if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                            {
                                this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                this.FirstSection.OrientationFaction = faction;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                int num = (this.ArmyScale / 60) - (int)this.Leader.StrategyTendency;
                if (num <= 0)
                {
                    foreach (Section section in this.Sections)
                    {
                        if (section.AIDetail.OrientationKind == SectionOrientationKind.无)
                        {
                            Section section2;
                            num5 = this.FirstSection.ArchitectureScale - (this.FirstSection.ArchitectureCount / 2);
                            if (section.GetHostileScale() > 0)
                            {
                                if (section.ArmyScale > (num5 * 6))
                                {
                                    foreach (Architecture architecture in section.Architectures)
                                    {
                                        section2 = null;
                                        if (architecture.HasOffensiveSectionInClose(out section2, 1))
                                        {
                                            sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.军区, true, false, false, true, true);
                                            if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                            {
                                                section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                                section.OrientationSection = section2;
                                            }
                                            break;
                                        }
                                    }
                                    if (section.OrientationSection == null)
                                    {
                                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, true);
                                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                        {
                                            this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                        }
                                    }
                                }
                                else
                                {
                                    sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(false, true);
                                    if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                    {
                                        this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                    }
                                }
                            }
                            else if ((section.GetFrontScale() > 0) && (section.ArmyScale < (num5 * 6)))
                            {
                                sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(true, false);
                                if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                {
                                    this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                }
                            }
                            else
                            {
                                foreach (Architecture architecture in section.Architectures)
                                {
                                    section2 = null;
                                    if (architecture.HasOffensiveSectionInClose(out section2, 1))
                                    {
                                        sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.军区, true, false, false, false, false);
                                        if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                        {
                                            section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                            section.OrientationSection = section2;
                                        }
                                        break;
                                    }
                                }
                                if (section.OrientationSection == null)
                                {
                                    sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionNoOrientationAutoAIDetailsByConditions(false, false);
                                    if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                    {
                                        this.FirstSection.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
                faction = null;
                num2 = -2147483648;
                int num3 = 0;
                foreach (Faction faction2 in this.GetUnderZeroDiplomaticRelationFactions().GetRandomList())
                {
                    threat = this.GetThreat(faction2);
                    if ((threat > num2) || GameObject.Chance(20))
                    {
                        num2 = threat;
                        faction = faction2;
                    }
                }
                GameObjectList list = this.Sections.GetList();
                list.PropertyName = "ArmyScale";
                list.IsNumber = true;
                list.ReSort();
                if (faction != null)
                {
                    foreach (Section section in list)
                    {
                        if (section.ArmyScale < 0x19)
                        {
                            break;
                        }
                        foreach (Architecture architecture in section.Architectures)
                        {
                            if (architecture.HasFactionInClose(faction, 1))
                            {
                                sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.势力, true, true, true, false, true);
                                if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                {
                                    section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                    section.OrientationFaction = faction;
                                    num3++;
                                }
                                break;
                            }
                        }
                        if (num3 >= num)
                        {
                            break;
                        }
                    }
                    return;
                }
                if (this.Capital.LocationState.GetFactionScale(this) < 100)
                {
                    foreach (Section section in list)
                    {
                        if (section.ArmyScale < 0x19)
                        {
                            break;
                        }
                        if (this.Capital.LocationState.GetSectionScale(section) >= 60)
                        {
                            sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
                            if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                            {
                                section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                section.OrientationState = this.Capital.LocationState;
                                num3++;
                            }
                            if (num3 >= num)
                            {
                                break;
                            }
                        }
                    }
                    return;
                }
                if (this.Capital.LocationState.LinkedRegion.GetFactionScale(this) < 100)
                {
                    foreach (Section section in list)
                    {
                        if (section.ArmyScale < 0x19)
                        {
                            break;
                        }
                        if (this.Capital.LocationState.LinkedRegion.GetSectionScale(section) >= 60)
                        {
                            sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
                            if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                            {
                                section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                foreach (Architecture architecture in section.Architectures)
                                {
                                    if (architecture.LocationState.LinkedRegion == this.Capital.LocationState.LinkedRegion)
                                    {
                                        section.OrientationState = architecture.LocationState;
                                        break;
                                    }
                                }
                                num3++;
                            }
                            if (num3 >= num)
                            {
                                break;
                            }
                        }
                    }
                    return;
                }
                StateList list3 = new StateList();
                foreach (State state in this.Capital.LocationState.LinkedRegion.States)
                {
                    foreach (State state2 in state.ContactStates)
                    {
                        if ((state2.LinkedRegion != this.Capital.LocationState.LinkedRegion) && (state2.GetFactionScale(this) < 100))
                        {
                            list3.Add(state2);
                        }
                    }
                }
                if (list3.Count > 0)
                {
                    foreach (Section section in list)
                    {
                        if (section.ArmyScale < 0x19)
                        {
                            break;
                        }
                        if (this.Capital.LocationState.LinkedRegion.GetSectionScale(section) >= 60)
                        {
                            sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
                            if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                            {
                                section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                section.OrientationState = list3[GameObject.Random(list3.Count)] as State;
                                num3++;
                            }
                            if (num3 >= num)
                            {
                                break;
                            }
                        }
                    }
                }
                if (num3 < num)
                {
                    foreach (Section section in list)
                    {
                        if (section.ArmyScale < 0x19)
                        {
                            return;
                        }
                        if (this.Capital.LocationState.LinkedRegion.GetSectionScale(section) <= 0)
                        {
                            Architecture maxPopulationArchitecture = section.MaxPopulationArchitecture;
                            if (maxPopulationArchitecture != null)
                            {
                                StateList list4 = new StateList();
                                foreach (State state3 in maxPopulationArchitecture.LocationState.ContactStates)
                                {
                                    if ((state3.LinkedRegion != this.Capital.LocationState.LinkedRegion) && (state3.GetFactionScale(this) < 100))
                                    {
                                        list4.Add(state3);
                                    }
                                }
                                if (list4.Count > 0)
                                {
                                    sectionNoOrientationAutoAIDetailsByConditions = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
                                    if (sectionNoOrientationAutoAIDetailsByConditions.Count > 0)
                                    {
                                        section.AIDetail = sectionNoOrientationAutoAIDetailsByConditions[GameObject.Random(sectionNoOrientationAutoAIDetailsByConditions.Count)] as SectionAIDetail;
                                        section.OrientationState = list4[GameObject.Random(list4.Count)] as State;
                                        num3++;
                                    }
                                    if (num3 >= num)
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                return;
            }
            list5 = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.州域, true, true, true, false, true);
            if (list5.Count > 0)
            {
                this.FirstSection.AIDetail = list5[GameObject.Random(list5.Count)] as SectionAIDetail;
                if (this.Capital.LocationState.GetFactionScale(this) < 100)
                {
                    this.FirstSection.OrientationState = this.Capital.LocationState;
                }
                else
                {
                    this.FirstSection.OrientationState = this.Capital.LocationState.ContactStates[GameObject.Random(this.Capital.LocationState.ContactStates.Count)] as State;
                }
            }
        }

        private void TechniquesDayEvent()
        {
            if (this.UpgradingTechnique >= 0)
            {
                this.UpgradingDaysLeft--;
                if (this.UpgradingDaysLeft == 0)
                {
                    Technique technique = base.Scenario.GameCommonData.AllTechniques.GetTechnique(this.UpgradingTechnique);
                    if (technique != null)
                    {
                        this.AvailableTechniques.AddTechnique(technique);
                        base.Scenario.NewInfluence = true;
                        technique.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Technique, technique.ID);
                        base.Scenario.NewInfluence = false;
                        if (this.OnTechniqueFinished != null)
                        {
                            this.OnTechniqueFinished(this, technique);
                        }
						ExtensionInterface.call("TechniqueUpgradeComplete", new Object[] { this.Scenario, this, technique });
                        base.Scenario.YearTable.addFactionTechniqueCompletedEntry(base.Scenario.Date, this, technique);
                    }
                    this.UpgradingTechnique = -1;
                }
            }
        }

        public override string ToString()
        {
            return base.Name;
        }

        public void UpgradeTechnique(Technique technique, Architecture architecture)
        {
            this.UpgradingTechnique = technique.ID;
            this.UpgradingDaysLeft = getTechniqueActualTime(technique);
            if (this.TechniquePoint < this.getTechniqueActualPointCost(technique))
            {
                this.DepositTechniquePointForTechnique(this.getTechniqueActualPointCost(technique) - this.TechniquePoint);
                if (this.TechniquePoint < this.getTechniqueActualPointCost(technique))
                {
                    this.DepositTechniquePointForFacility(this.getTechniqueActualPointCost(technique) - this.TechniquePoint);
                }
            }
            this.DecreaseTechniquePoint(this.getTechniqueActualPointCost(technique));
            architecture.DecreaseFund(this.getTechniqueActualFundCost(technique));
			ExtensionInterface.call("UpgradeTechnique", new Object[] { this.Scenario, this });
            if (this.OnUpgradeTechnique != null)
            {
                this.OnUpgradeTechnique(this, technique, architecture);
            }
        }

        public void YearEvent()
        {
        }

        public int ArchitectureCount
        {
            get
            {
                return this.Architectures.Count;
            }
        }

        public int ArchitectureTotalSize
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.JianzhuGuimo;
                }
                return num;
            }
        }

        public int Army
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.ArmyQuantity;
                }
                foreach (Troop troop in this.Troops)
                {
                    num += troop.Quantity;
                }
                return num;
            }
        }

        public int ArmyScale
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.ArmyScale;
                }
                foreach (Troop troop in this.Troops)
                {
                    num += troop.Army.Scales;
                }
                return num;
            }
        }

        public MilitaryKindTable AvailableMilitaryKinds
        {
            get
            {
                MilitaryKindTable table = new MilitaryKindTable();
                foreach (MilitaryKind kind in this.BaseMilitaryKinds.MilitaryKinds.Values)
                {
                    table.AddMilitaryKind(kind);
                }
                foreach (MilitaryKind kind in this.TechniqueMilitaryKinds.MilitaryKinds.Values)
                {
                    table.AddMilitaryKind(kind);
                }
                return table;
            }
        }

        public Architecture Capital
        {
            get
            {
                if (this.Architectures.Count == 0) return null;
                if (this.CapitalID == -1)
                {
                    this.CapitalID = this.Architectures[GameObject.Random(this.Architectures.Count)].ID;
                }
                if (this.capital == null)
                {
                    this.capital = base.Scenario.Architectures.GetGameObject(this.capitalID) as Architecture;
                }
                return this.capital;
            }
            set
            {
                this.capital = value;
                if (this.capital != null)
                {
                    this.capitalID = this.capital.ID;
                }
                else
                {
                    this.capitalID = -1;
                }
            }
        }

        public int CapitalID
        {
            get
            {
                return this.capitalID;
            }
            set
            {
                this.capitalID = value;
                this.capital = null;
            }
        }

        public string CapitalName
        {
            get
            {
                if (this.Capital != null)
                {
                    return this.Capital.Name;
                }
                return "----";
            }
        }

        public int CaptiveCount
        {
            get
            {
                return this.Captives.Count;
            }
        }

        public int ColorIndex
        {
            get
            {
                return this.colorIndex;
            }
            set
            {
                this.colorIndex = value;
            }
        }

        public bool Controlling
        {
            get
            {
                return this.controlling;
            }
            set
            {
                this.controlling = value;
            }
        }

        public Section FirstSection
        {
            get
            {
                if (this.SectionCount > 0)
                {
                    return (this.Sections[0] as Section);
                }
                return this.CreateFirstSection();
            }
        }

        public long Food
        {
            get
            {
                long num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.Food;
                }
                return num;
            }
        }

        public int FriendlyDiplomaticRelationCount
        {
            get
            {
                int num = 0;
                foreach (DiplomaticRelation relation in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
                {
                    if (relation.Relation >= 300)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int Fund
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.Fund;
                }
                return num;
            }
        }

        public float GetCurrentRoutewayConsumptionRate
        {
            get
            {
                return this.RoutewayPathBuilder.PathConsumptionRate;
            }
        }

        public bool HasFriendlyDiplomaticRelation
        {
            get
            {
                foreach (DiplomaticRelation relation in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
                {
                    if (relation.Relation >= 300)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public int feiziCount()
        {
            int r = 0;
            foreach (Architecture a in this.Architectures)
            {
                r += a.feiziliebiao.Count;
            }
            return r;
        }

        public int meinvkongjian()
        {
            int r = 0;
            foreach (Architecture a in this.Architectures)
            {
                r += a.meinvkongjian();
            }
            return r;
        }

        public int InformationCount
        {
            get
            {
                return this.Informations.Count;
            }
        }

        public float InternalSurplusRate
        {
            get
            {
                float num = 1f - (0.001f * (((this.Population / 0x2710) + (this.ArmyScale / 5)) + this.PersonCount));
                if (num < 0.2f)
                {
                    num = 0.2f;
                }
                if (!base.Scenario.IsPlayer(this) && !GlobalVariables.internalSurplusRateForAI)
                {
                    num = 1f;
                }
                if (base.Scenario.IsPlayer(this) && !GlobalVariables.internalSurplusRateForPlayer)
                {
                    num = 1f;
                }
                return num;
            }
        }

        public string InternalSurplusRatePercentString
        {
            get
            {
                return StaticMethods.GetPercentString(this.InternalSurplusRate, 3);
            }
        }

        public Person Leader
        {
            get
            {
                if (this.leaderID == -1)
                {
                    this.leaderID = this.Persons.GetMaxMeritPerson().ID;
                }
                if (this.leader == null)
                {
                    this.leader = base.Scenario.Persons.GetGameObject(this.LeaderID) as Person;
                }
                return this.leader;
            }
            set
            {
                this.leader = value;
                if (this.leader != null)
                {
                    this.LeaderID = this.leader.ID;
                }
                else
                {
                    this.LeaderID = -1;
                }
            }
        }

        public int LeaderID
        {
            get
            {
                return this.leaderID;
            }
            set
            {
                this.leaderID = value;
            }
        }

        public string LeaderName
        {
            get
            {
                return ((this.Leader != null) ? this.Leader.Name : "----");
            }
        }

        public int LegionCount
        {
            get
            {
                return this.Legions.Count;
            }
        }

        public Faction MaxFriendlyDiplomaticRelation
        {
            get
            {
                int num = 0;
                Faction diplomaticFaction = null;
                foreach (DiplomaticRelation relation in base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(base.ID))
                {
                    if ((relation.Relation >= 300) && (num < relation.Relation))
                    {
                        num = relation.Relation;
                        diplomaticFaction = relation.GetDiplomaticFaction(base.ID);
                    }
                }
                return diplomaticFaction;
            }
        }

        public int MilitaryCount
        {
            get
            {
                return this.Militaries.Count;
            }
        }

        public bool Passed
        {
            get
            {
                return this.passed;
            }
            set
            {
                this.passed = value;
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
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    num += architecture.Population;
                }
                return num;
            }
        }

        public bool PreUserControlFinished
        {
            get
            {
                return this.preUserControlFinished;
            }
            set
            {
                this.preUserControlFinished = value;
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

        public int RoutewayCount
        {
            get
            {
                return this.Routeways.Count;
            }
        }

        public int RoutewayWorkForce
        {
            get
            {
                return (100 + this.IncrementOfRoutewayWorkforce);
            }
        }

        public int[,] SecondTierMapCost
        {
            get
            {
                return this.secondTierMapCost;
            }
        }

        public int SectionCount
        {
            get
            {
                return this.Sections.Count;
            }
        }

        public int SelfCaptiveCount
        {
            get
            {
                return this.SelfCaptives.Count;
            }
        }

        public int TechniquePoint
        {
            get
            {
                return this.techniquePoint;
            }
            set
            {
                this.techniquePoint = value;
            }
        }

        public int TechniquePointForFacility
        {
            get
            {
                return this.techniquePointForFacility;
            }
            set
            {
                this.techniquePointForFacility = value;
            }
        }

        public int TechniquePointForTechnique
        {
            get
            {
                return this.techniquePointForTechnique;
            }
            set
            {
                this.techniquePointForTechnique = value;
            }
        }

        public int[,] ThirdTierMapCost
        {
            get
            {
                return this.thirdTierMapCost;
            }
        }

        public int TotalTechniquePoint
        {
            get
            {
                return ((this.techniquePoint + this.techniquePointForTechnique) + this.techniquePointForFacility);
            }
        }

        public int TroopCount
        {
            get
            {
                return this.Troops.Count;
            }
        }

        public int UpgradingDaysLeft
        {
            get
            {
                return this.upgradingDaysLeft;
            }
            set
            {
                this.upgradingDaysLeft = value;
            }
        }

        public int UpgradingTechnique
        {
            get
            {
                return this.upgradingTechnique;
            }
            set
            {
                this.upgradingTechnique = value;
            }
        }

        private bool WantControl
        {
            get
            {
                bool stopToControl = this.StopToControl;
                if (!stopToControl)
                {
                    stopToControl = base.Scenario.Date.DaysLeft == 0;
                }
                return stopToControl;
            }
        }

        public int TotalPersonMerit
        {
            get
            {
                int result = 0;
                foreach (Person p in this.Persons)
                {
                    result += p.Merit;
                }
                return result;
            }
        }

        public int TotalPersonFightingForce
        {
            get
            {
                int result = 0;
                foreach (Person p in this.Persons)
                {
                    result += p.FightingForce;
                }
                return result;
            }
        }

        public int chaotinggongxiandu
        {
            get
            {
                return this.chaotinggongxiandudezhi;
            }
            set
            {
                this.chaotinggongxiandudezhi = value;
            }
        }

        public int guanjue
        {
            get
            {
                return this.guanjuedezhi;
            }
            set
            {
                this.guanjuedezhi = value;
            }
        }

        public bool IsAlien
        {
            get
            {
                return this.isAlien;
            }
            set
            {
                this.isAlien=value;
            }
        }

        public delegate void AfterCatchLeader(Person leader, Faction faction);

        [StructLayout(LayoutKind.Sequential)]
        public struct ClosedPathEndpoints
        {
            public Point Start;
            public Point End;
            public ClosedPathEndpoints(Point start, Point end)
            {
                this.Start = start;
                this.End = end;
            }

            public static bool operator !=(Faction.ClosedPathEndpoints a, Faction.ClosedPathEndpoints b)
            {
                return ((a.Start != b.Start) || (a.End != b.End));
            }

            public static bool operator ==(Faction.ClosedPathEndpoints a, Faction.ClosedPathEndpoints b)
            {
                return ((a.Start == b.Start) && (a.End == b.End));
            }

            public override int GetHashCode()
            {
                return (this.Start.GetHashCode() ^ this.End.GetHashCode());
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override string ToString()
            {
                return (this.Start.ToString() + " " + this.End.ToString());
            }
        }

        public delegate void FactionDestroy(Faction faction);

        public delegate void FactionUpgradeTechnique(Faction faction, Technique technique, Architecture architecture);

        public delegate void ForcedChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital);

        public delegate void GetControl(Faction faction);

        public delegate void InitiativeChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital);

        public delegate void TechniqueFinished(Faction faction, Technique technique);

        public int MaxPossibleReputation
        {
            get
            {
                int maxReputation = int.MinValue;
                foreach (guanjuezhongleilei i in base.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhongleiliebiao())
                {
                    if (i.shengwangshangxian > maxReputation)
                    {
                        maxReputation = i.shengwangshangxian;
                    }
                }
                return maxReputation;
            }
        }
    }
}

