﻿namespace GameObjects
{
    using GameGlobal;
    using GameObjects.ArchitectureDetail;
    using GameObjects.FactionDetail;
    using GameObjects.MapDetail;
    using GameObjects.SectionDetail;
    using GameObjects.TroopDetail;
    using GameObjects.PersonDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Linq;
    using GameObjects.Influences;
    using System.Text;


    public class Faction : GameObject
    {
       // public int PrinceID = -1;
        //public int AllRoundOfficerCount;
        private int militarycount;
        private int transferingmilitarycount;
        public int ZhaoxianFailureCount = 0;
        public int YearOfficialLimit = 0;
        private Person prince = null;
        private int princeID = -1;
        private bool isAlien = false;
        private int guanjuedezhi = 0;
        private int chaotinggongxiandudezhi = 0;
        internal bool AIFinished;
        private Thread AIThread;
        public ZhandouZhuangtai BattleState = ZhandouZhuangtai.和平;
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
        private int armyScale = 0;
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
        private Dictionary<Point, InformationTile> knownAreaData;
        public Dictionary<int, Troop> KnownTroops = new Dictionary<int, Troop>();
        private Person leader = null;
        private int leaderID;
        public LegionList Legions = new LegionList();
        public InformationLevel LevelOfView = InformationLevel.中;
        private int[,] mapData;
       // public MilitaryList Militaries = new MilitaryList();
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
       // private Dictionary<MilitaryKind, int> militaryKindCounts = new Dictionary<MilitaryKind, int>();

        public List<float> techniqueReputationRateDecrease = new List<float>();
        public List<float> techniquePointCostRateDecrease = new List<float>();
        public List<float> techniqueTimeRateDecrease = new List<float>();
        public List<float> techniqueFundCostRateDecrease = new List<float>();

        public bool NotPlayerSelectable = false;

        public int[] CriticalOfMillitaryType = new int[5];
        public int[] AntiCriticalOfMillitaryType = new int[5];
        public float[] ArchitectureDamageOfMillitaryType = { 1f, 1f, 1f, 1f, 1f };
        public float[] SpeedOfMillitaryType = { 1f, 1f, 1f, 1f, 1f };
        public int[] ViewAreaOfMillitaryType = new int[5];
        public int[] StratagemOfMillitaryType = new int[5];
        public int[] AntiStratagemOfMillitaryType = new int[5];

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
                //foreach (Person i in base.Scenario.Persons)
                //{
                //    if ((i.Status == GameObjects.PersonDetail.PersonStatus.Normal || i.Status == GameObjects.PersonDetail.PersonStatus.Moving)
                //        && i.BelongedFaction == this)
                //    {
                //        result.Add(i);
                //    }
                //}
                foreach (Architecture a in Architectures)
                {
                    foreach (Person p in a.Persons)
                        result.Add(p);
                    foreach (Person p in a.MovingPersons)
                        result.Add(p);
                }
                foreach (Troop t in Troops)
                {
                    foreach (Person p in t.Persons)
                        result.Add(p);
                }

                return result;
            }
        }

        public PersonList MayorList
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Architecture a in this.Architectures)
                {
                    if (a.Mayor != null)
                    {
                        result.Add(a.Mayor);
                    }
                }
                return result;
            }
        }
        /*
        public PersonList ConvinceableMayorList   //可劝降的太守列表
        {
            get
            {
                PersonList list = new PersonList();
                foreach (Faction f in base.Scenario.Factions)
                {
                    foreach (Architecture a in f.Architectures)
                    {
                        if (f != this && a.Mayor != null)
                        {
                            list.Add(a.Mayor);
                        }
                    }
                }
                return list;
            }
        }
 
        public PersonList ConvinceableLeaderList //可劝降的君主列表
        {
            get
            {
                 PersonList list = new PersonList();
                 foreach (Faction f in base.Scenario.Factions )
                 {
                     if (f != this )
                     {
                         list.Add(f.Leader);
                     }
                 }
                return list ;
            }
        }
        */


        public TreasureList AllTreasuresExceptLeader
        {
            get
            {
                TreasureList list = new TreasureList();
                foreach (Person person in this.Persons)
                {
                    if (person != this.Leader)
                    {
                        person.AddTreasureToList(list);
                    }
                }
                return list;
            }
        }

        public PersonList PersonsInArchitecturesExceptLeader
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Architecture a in Architectures)
                {
                    foreach (Person p in a.Persons)
                    {
                        if (p != this.Leader)  result.Add(p);
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
        
        public ArchitectureList ArchitecturesExcluding(Architecture a)
        {
            ArchitectureList result = new ArchitectureList();
            foreach (Architecture i in this.Architectures)
            {
                if (i != a)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public int GetTechniqueUsefulness(Technique tech)
        {
            int result = 0;
            foreach (Influences.Influence i in tech.Influences.GetInfluenceList())
            {
                switch (i.Kind.ID)
                {
                    case 1030:
                    case 2400:
                    case 2420:
                    case 2430:
                        if (!GlobalVariables.LiangdaoXitong) break;
                        result = Math.Max(100, result);
                        break;
                    case 2000:
                    case 2010:
                    case 2020:
                    case 2030:
                    case 2200:
                    case 2210:
                    case 2220:
                    case 2230:
                    case 2240:
                    case 2250:
                        if (int.Parse(i.Parameter) == 3)
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
                        else if (int.Parse(i.Parameter) == 4)
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
                        else if (int.Parse(i.Parameter) == 0)
                        {
                            bool hasSiege = false;
                            foreach (MilitaryKind mk in this.AvailableMilitaryKinds.MilitaryKinds.Values)
                            {
                                if (mk.Type == MilitaryType.步兵)
                                {
                                    hasSiege = true;
                                }
                            }
                            if (!hasSiege) break;
                        }
                        else if (int.Parse(i.Parameter) == 1)
                        {
                            bool hasSiege = false;
                            foreach (MilitaryKind mk in this.AvailableMilitaryKinds.MilitaryKinds.Values)
                            {
                                if (mk.Type == MilitaryType.弩兵)
                                {
                                    hasSiege = true;
                                }
                            }
                            if (!hasSiege) break;
                        }
                        else if (int.Parse(i.Parameter) == 2)
                        {
                            bool hasSiege = false;
                            foreach (MilitaryKind mk in this.AvailableMilitaryKinds.MilitaryKinds.Values)
                            {
                                if (mk.Type == MilitaryType.骑兵)
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

        public List<Point> GetAllKnownArea()
        {
            List<Point> result = new List<Point>();
            foreach (Point p in this.knownAreaData.Keys)
            {
                if (this.GetKnownAreaData(p) != InformationLevel.无 && this.GetKnownAreaData(p) != InformationLevel.未知)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        private TroopList visibleTroopsCache = null;
        public TroopList GetVisibleTroops()
        {
            if (visibleTroopsCache != null)
            {
                return visibleTroopsCache;
            }
            else
            {
                TroopList result = new TroopList();
                foreach (Point p in this.GetAllKnownArea())
                {
                    Troop troopByPositionNoCheck = this.Scenario.GetTroopByPositionNoCheck(p);
                    if ((troopByPositionNoCheck != null) && !troopByPositionNoCheck.Destroyed)
                    {
                        result.Add(troopByPositionNoCheck);
                    }
                }
                visibleTroopsCache = result;
                return result;
            }
        }

        private void AddKnownAreaData(Point p, InformationLevel level)
        {
            if (!this.knownAreaData.ContainsKey(p))
            {
                InformationTile it = new InformationTile();
                it.AddInformationLevel(level);
                this.knownAreaData.Add(p, it);
            }
            else
            {
                InformationTile it = this.knownAreaData[p];
                it.AddInformationLevel(level);
                this.knownAreaData[p] = it;
            }
        }

        private void RemoveKnownAreaData(Point p, InformationLevel level)
        {
            if (this.knownAreaData.ContainsKey(p))
            {
                InformationTile it = this.knownAreaData[p];
                it.RemoveInformationLevel(level);
                this.knownAreaData[p] = it;
                if (it.Level == InformationLevel.无)
                {
                    this.knownAreaData.Remove(p);
                }
            }
        }

        private InformationLevel getInformationLevel(Point p)
        {
            if (!this.knownAreaData.ContainsKey(p))
            {
                return InformationLevel.无;
            }
            else
            {
                return this.knownAreaData[p].Level;
            }
        }

        public void AddArchitectureKnownData(Architecture a)
        {
            foreach (Point point in a.ArchitectureArea.Area)
            {
                this.AddKnownAreaData(point, InformationLevel.全);
            }
            foreach (Point point in a.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    this.AddKnownAreaData(point, InformationLevel.高);
                }
            }
            if (a.Kind.HasLongView)
            {
                foreach (Point point in a.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        this.AddKnownAreaData(point, InformationLevel.中);
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
           /* if (this.militaryKindCounts.ContainsKey(military.RealMilitaryKind))
            {
                this.militaryKindCounts[military.Kind]++;
            }
            else
            {
                this.militaryKindCounts[military.Kind] = 1;
            }*/
            military.BelongedFaction = this;
        }

        public void AddPositionInformation(Point position, InformationLevel level)
        {
            if (!base.Scenario.PositionOutOfRange(position))
            {
                this.AddKnownAreaData(position, level);
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
                    this.AddKnownAreaData(point, InformationLevel.全);
                }
                else
                {
                    this.AddKnownAreaData(point, troop.ScoutLevel);
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

        private bool IsPersonForHouGong(Person p)
        {
            return IsPersonForHouGong(p, p.suoshurenwuList.GetList());
        }

        private bool IsPersonForHouGong(Person p, GameObjectList suoshu)
        {
            Dictionary<Person, PersonList> haters = p.willHateCausedByAffair(p, this.Leader, this.Leader, suoshu);
            PersonList leaderHaters = new PersonList();
            foreach (KeyValuePair<Person, PersonList> i in haters)
            {
                if (i.Value.HasGameObject(this.Leader))
                {
                    leaderHaters.Add(i.Key);
                }
            }

            int unAmbition = Enum.GetNames(typeof(PersonAmbition)).Length - (int)this.Leader.Ambition;
            Person spousePerson = null;
            int maxMerit = 0;
            foreach (Person i in leaderHaters)
            {
                if (i.Alive && i != p && i != this.Leader && i.UntiredMerit > maxMerit)
                {
                    spousePerson = i;
                    maxMerit = i.UntiredMerit;
                }
            }
            return p.UntiredMerit > ((unAmbition - 1) * Parameters.AINafeiAbilityThresholdRate) && leader.isLegalFeiZi(p) && p.LocationArchitecture != null && !p.IsCaptive && !p.Hates(this.Leader) &&
                            (spousePerson == null || (leader.PersonalLoyalty <= (int)PersonLoyalty.普通 && spousePerson.UntiredMerit * (leader.PersonalLoyalty * Parameters.AINafeiStealSpouseThresholdRateMultiply + Parameters.AINafeiStealSpouseThresholdRateAdd) < p.UntiredMerit)) &&
                            (!GlobalVariables.PersonNaturalDeath || (p.Age >= 16 && p.Age <= Parameters.AINafeiMaxAgeThresholdAdd + (int)leader.Ambition * Parameters.AINafeiMaxAgeThresholdMultiply)) &&
                            p.marriageGranter != this.Leader;
        }

        private void AIMakeMarriage()
        {
            if (base.Scenario.IsPlayer(this)) return;

            foreach (Person p in this.Persons)
            {
                if (p.WaitForFeiZi != null)
                {
                    if ((p.BelongedFaction != this || p.Spouse != null
                        || (p.WaitForFeiZi.BelongedFaction != this && p.WaitForFeiZi.Spouse != null)))
                    {
                        if (p.WaitForFeiZi != null)
                        {
                            p.WaitForFeiZi.WaitForFeiZi = null;
                        }
                        p.WaitForFeiZi = null;
                    }
                    else if (!p.isLegalFeiZi(p.WaitForFeiZi) || p.WaitForFeiZi.isLegalFeiZi(p))
                    {
                        if (p.WaitForFeiZi != null)
                        {
                            p.WaitForFeiZi.WaitForFeiZi = null;
                        }
                        p.WaitForFeiZi = null;
                    }
                    else
                    {
                        if (p.Status == PersonStatus.Normal && p.LocationArchitecture != null
                            && p.LocationTroop == null)
                        {
                            if (p.LocationArchitecture.Fund >= Parameters.MakeMarriageCost)
                            {
                                p.Marry(p.WaitForFeiZi, this.Leader);
                                if (p.WaitForFeiZi != null)
                                {
                                    p.WaitForFeiZi.WaitForFeiZi = null;
                                }
                                p.WaitForFeiZi = null;
                            }
                        }
                    }
                }
            }

            if (GameObject.Random(10) == 0)
            {
                GameObjectList pl = this.Persons.GetList();
                pl.PropertyName = "UntiredMerit";
                pl.IsNumber = true;
                pl.SmallToBig = false;
                pl.ReSort();
                foreach (Person p in pl)
                {
                    if (p.WaitForFeiZi != null) continue;
                    if (p.Spouse != null) continue;
                    PersonList candidates = p.MakeMarryableInFaction();
                    if (candidates.Count > 0)
                    {
                        Person q = candidates.GetMaxUntiredMeritPerson();
                        if (q.WaitForFeiZi == null)
                        {
                            if (GlobalVariables.hougongGetChildrenRate > 0)
                            {
                                Person t = p.Sex != Leader.Sex ? p : q;
                                Person u = p.Sex != Leader.Sex ? q : p;
                                GameObjectList simulatSuoshu = t.suoshurenwuList.GetList();
                                simulatSuoshu.Add(u);

                                if (IsPersonForHouGong(t, simulatSuoshu)) continue;
                            }

                            if (p.LocationArchitecture == q.LocationArchitecture && p.LocationArchitecture != null &&
                                p.LocationArchitecture.Fund >= Parameters.MakeMarriageCost)
                            {
                                if (p.WaitForFeiZi != null)
                                {
                                    p.WaitForFeiZi.WaitForFeiZi = null;
                                }
                                if (q.WaitForFeiZi != null)
                                {
                                    q.WaitForFeiZi.WaitForFeiZi = null;
                                }
                                p.Marry(q, this.Leader);
                                p.WaitForFeiZi = null;
                                q.WaitForFeiZi = null;
                            }
                            else
                            {
                                if (p.WaitForFeiZi != null)
                                {
                                    p.WaitForFeiZi.WaitForFeiZi = null;
                                }
                                if (q.WaitForFeiZi != null)
                                {
                                    q.WaitForFeiZi.WaitForFeiZi = null;
                                }
                                p.WaitForFeiZi = q;
                                q.WaitForFeiZi = p;
                                if (p.LocationArchitecture != q.LocationArchitecture)
                                {
                                    if (q.Status == PersonStatus.Normal && q.LocationArchitecture != null && q.LocationTroop == null)
                                    {
                                        q.MoveToArchitecture(p.BelongedArchitecture);
                                    }
                                    else if (p.Status == PersonStatus.Normal && p.LocationArchitecture != null && p.LocationTroop == null)
                                    {
                                        p.MoveToArchitecture(q.BelongedArchitecture);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void AIHouGong()
        {
            if (GlobalVariables.hougongGetChildrenRate <= 0) return;

            if (base.Scenario.IsPlayer(this)) return;

            int uncruelty = this.Leader.Uncruelty;
            int unAmbition = Enum.GetNames(typeof(PersonAmbition)).Length - (int)this.Leader.Ambition;

            // move feizis
            if (GameObject.Random(10) == 0)
            {
                foreach (Architecture a in this.Architectures)
                {
                    if (a.Feiziliebiao.Count > 0)
                    {
                        foreach (Architecture b in this.Architectures)
                        {
                            if (!b.withoutTruceFrontline && 
                                (b.Meinvkongjian > b.Feiziliebiao.Count || b.BelongedFaction.IsAlien) && 
                                (a.withoutTruceFrontline || b.Meinvkongjian > a.Meinvkongjian))
                            {
                                int cnt = b.BelongedFaction.IsAlien ? 9999 : b.Meinvkongjian - b.Feiziliebiao.Count;
                                GameObjectList list = a.Feiziliebiao.GetList();
                                list.PropertyName = "Merit";
                                list.IsNumber = true;
                                list.SmallToBig = false;
                                list.ReSort();
                                int moved = 0;
                                foreach (Person p in list)
                                {
                                    p.MoveToArchitecture(b);
                                    moved++;
                                    if (moved >= cnt) break;
                                }
                            }
                            if (a.Feiziliebiao.Count <= 0) break;
                        }
                    }
                }
            }

            
            // if (this.Leader.LocationArchitecture == null || this.Leader.LocationArchitecture.HasHostileTroopsInView()) return;

            if (this.Leader.NumberOfChildren >= GlobalVariables.OfficerChildrenLimit) return;

            // build hougong
            if (this.meinvkongjian() - this.feiziCount() <= 0 && !this.isAlien && 
                GameObject.Random((int)(GameObject.Square(unAmbition) * Parameters.AIBuildHougongUnambitionProbWeight + GameObject.Square(this.meinvkongjian()) * unAmbition * Parameters.AIBuildHougongSpaceBuiltProbWeight)) == 0)
            {
                Architecture buildAt = null;
                bool planned = false;
                foreach (Architecture a in this.Architectures)
                {
                    if (a.FrontLine) continue;
                    if (a.ExpectedFund - a.EnoughFund <= 50 * 30) continue;
                    if (a.Kind.FacilityPositionUnit <= 0) continue;
                    if (a.PlanFacilityKind != null && a.PlanFacilityKind.rongna > 0)
                    {
                        planned = true;
                        break;
                    }
                    if (a.BuildingFacility >= 0 && base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(a.BuildingFacility).rongna > 0)
                    {
                        planned = true;
                        break;
                    }

                    if (buildAt == null || a.Population > buildAt.Population)
                    {
                        buildAt = a;
                    }
                }

                if (!planned && buildAt != null)
                {
                    int maxHgSize = (12 - uncruelty) + Math.Max(0, buildAt.FacilityPositionCount / buildAt.Kind.FacilityPositionUnit - 5) + Parameters.AIBuildHougongMaxSizeAdd;
                    FacilityKind hougong = null;
                    foreach (FacilityKind fk in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (!fk.CanBuild(buildAt)) continue;
                        if (fk.FundCost > buildAt.Fund) continue;
                        if (fk.rongna > 0 && fk.rongna < maxHgSize && GameObject.Chance(Parameters.AIBuildHougongSkipSizeChance))
                        {
                            if (hougong == null || hougong.rongna < fk.rongna)
                            {
                                hougong = fk;
                            }
                        }
                    }
                    if (hougong != null)
                    {
                        int facilityPositionLeft = buildAt.FacilityPositionLeft;
                        if (facilityPositionLeft < hougong.PositionOccupied && buildAt.FacilityPositionCount >= hougong.PositionOccupied)
                        {
                            FacilityList fl = new FacilityList();
                            foreach (Facility f in buildAt.Facilities)
                            {
                                if (f.location.CanRemoveFacility(f))
                                {
                                    fl.Add(f);
                                }
                            }

                            int totalRemovableSpace = 0;
                            foreach (Facility f in fl)
                            {
                                totalRemovableSpace += f.PositionOccupied;
                            }

                            if (totalRemovableSpace >= hougong.PositionOccupied)
                            {
                                fl.PropertyName = "AIValue";
                                fl.IsNumber = true;
                                fl.SmallToBig = true;
                                fl.ReSort();

                                while (buildAt.FacilityPositionLeft < hougong.PositionOccupied && fl.Count > 0)
                                {
                                    Facility f = fl[0] as Facility;
                                    if (buildAt.FacilityEnabled || f.MaintenanceCost <= 0)
                                    {
                                        f.Influences.PurifyInfluence(this, Applier.Facility, f.ID);
                                    }
                                    buildAt.Facilities.Remove(f);
                                    base.Scenario.Facilities.Remove(f);
                                    fl.Remove(f);
                                }
                            }

                            facilityPositionLeft = buildAt.FacilityPositionLeft;
                        }
                        if (facilityPositionLeft >= hougong.PositionOccupied)
                        {
                            if ((this.Fund >= hougong.FundCost) && ((buildAt.BelongedFaction.TechniquePoint + buildAt.BelongedFaction.TechniquePointForFacility) >= hougong.PointCost))
                            {
                                buildAt.PlanFacilityKind = null;
                                buildAt.BelongedFaction.DepositTechniquePointForFacility(hougong.PointCost);
                                buildAt.BeginToBuildAFacility(hougong);
                            }
                            else
                            {
                                buildAt.PlanFacilityKind = hougong;
                                if (GameObject.Chance(0x21) && ((buildAt.BelongedFaction.TechniquePoint + buildAt.BelongedFaction.TechniquePointForFacility) < buildAt.PlanFacilityKind.PointCost))
                                {
                                    buildAt.BelongedFaction.SaveTechniquePointForFacility(buildAt.PlanFacilityKind.PointCost / buildAt.PlanFacilityKind.Days);
                                }
                            }
                        }
                    }
                }
            }

            //nafei
            if (leader.WaitForFeiZi != null && leader.Status == PersonStatus.Normal && leader.LocationArchitecture != null &&
                this.Leader.LocationTroop == null)
            {
                if ((this.Leader.LocationArchitecture.Meinvkongjian - this.Leader.LocationArchitecture.Feiziliebiao.Count <= 0 && ! this.IsAlien) ||
                    !this.Leader.isLegalFeiZi(leader.WaitForFeiZi) ||
                    this.Leader.WaitForFeiZi.BelongedFaction != this)
                {
                    leader.WaitForFeiZi.WaitForFeiZi = null;
                    leader.WaitForFeiZi = null;
                }
                else if (this.Leader.LocationArchitecture.Fund >= Parameters.NafeiCost)
                {
                    if (this.Leader.WaitForFeiZi.LocationArchitecture == this.Leader.LocationArchitecture &&
                        this.Leader.WaitForFeiZi.Status == PersonStatus.Normal)
                    {
                        this.Leader.XuanZeMeiNv(this.Leader.WaitForFeiZi);
                        this.Leader.WaitForFeiZi.WaitForFeiZi = null;
                        this.Leader.WaitForFeiZi = null;
                    }
                }
            }
            else if (this.Leader.Status == PersonStatus.Normal && this.Leader.LocationArchitecture != null &&
                this.Leader.LocationTroop == null && this.Leader.WaitForFeiZi == null)
            {
                Architecture dest = null;
                if ((this.Leader.LocationArchitecture.Meinvkongjian - this.Leader.LocationArchitecture.Feiziliebiao.Count > 0 || this.IsAlien) && this.Fund >= 60000)
                {
                    dest = this.Leader.LocationArchitecture;
                }
                else
                {
                    foreach (Architecture a in this.Architectures)
                    {
                        if ((a.Meinvkongjian - a.Feiziliebiao.Count > 0 || this.IsAlien) && (dest == null || a.Population > dest.Population) && a.Fund >= 60000)
                        {
                            dest = a;
                        }
                    }
                }

                if (dest != null)
                {
                    PersonList candidate = new PersonList();
                    foreach (Person p in this.Persons)
                    {
                        Person spousePerson = p.Spouse == null ? null : p.Spouse;
                        if (IsPersonForHouGong(p) && p.WaitForFeiZi == null)
                        {
                            candidate.Add(p);
                        }
                    }
                    candidate.PropertyName = "UntiredMerit";
                    candidate.IsNumber = true;
                    candidate.SmallToBig = false;
                    candidate.ReSort();
                    Person toTake = null;
                    foreach (Person p in candidate)
                    {
                        if (p.Status == PersonStatus.Normal && p.LocationArchitecture != null && p.LocationTroop == null)
                        {
                            if ((!p.RecruitableBy(this, 0) && GameObject.Random((int)unAmbition) == 0) || GameObject.Chance((int)(Parameters.AINafeiSkipChanceAdd + (int)leader.Ambition * Parameters.AINafeiSkipChanceMultiply)))
                            {
                                toTake = p;
                                break;
                            }
                        }
                    }

                    if (toTake != null)
                    {
                        if (this.Leader.LocationArchitecture == dest)
                        {
                            if (toTake.LocationArchitecture == dest)
                            {
                                this.Leader.XuanZeMeiNv(toTake);
                                toTake.WaitForFeiZi = null;
                                leader.WaitForFeiZi = null;
                            }
                            else
                            {
                                toTake.MoveToArchitecture(dest);
                                toTake.WaitForFeiZi = this.Leader;
                                this.Leader.WaitForFeiZi = toTake;
                            }
                        }
                        else
                        {
                            if (toTake.LocationArchitecture == dest)
                            {
                                this.Leader.MoveToArchitecture(dest);
                                toTake.WaitForFeiZi = this.Leader;
                                this.Leader.WaitForFeiZi = toTake;
                            }
                            else
                            {
                                this.Leader.MoveToArchitecture(dest);
                                toTake.MoveToArchitecture(dest);
                                toTake.WaitForFeiZi = this.Leader;
                                this.Leader.WaitForFeiZi = toTake;
                            }
                        }
                    }
                }
            }

            //chongxing
            if (this.Leader.Status == PersonStatus.Normal && this.Leader.LocationArchitecture != null && this.Leader.LocationTroop == null &&
                !this.Leader.huaiyun && this.Leader.WaitForFeiZi == null)
            {
                if ((
                GameObject.Chance((int)((int)this.Leader.Ambition * Parameters.AIChongxingChanceMultiply + Parameters.AIChongxingChanceAdd))
                ||
                GameObject.Chance((int)Math.Round(Parameters.AIHougongArchitectureCountProbMultiply * Math.Pow(this.ArchitectureCount, Parameters.AIHougongArchitectureCountProbPower)))
                ))
                {
                    Person target = null;
                    Architecture location = null;
                    foreach (Architecture a in this.Architectures)
                    {
                        foreach (Person p in a.meifaxianhuaiyundefeiziliebiao())
                        {
                            if (p.Hates(this.Leader)) continue;
                            if (p.GetRelation(this.leader) < -400)
                            {
                                target = p;
                                location = a;
                                break;
                            }
                            int pval = p.NumberOfChildren > 0 ? p.Merit / p.NumberOfChildren : int.MaxValue;
                            int tval = target == null ? 0 : (target.NumberOfChildren > 0 ? target.UntiredMerit / target.NumberOfChildren : int.MaxValue);
                            if (target == null || pval > tval)
                            {
                                target = p;
                                location = a;
                            }
                        }
                    }
                    if (target != null)
                    {
                        if (location == this.Leader.LocationArchitecture)
                        {
                            this.Leader.GoForHouGong(target);
                        }
                        else
                        {
                            this.Leader.MoveToArchitecture(location);
                        }
                    }
                }
            }
        }

        private void AIDiplomacy()
        {
            foreach (Faction f in base.Scenario.PlayerFactions) 
            {
                if (!this.adjacentTo(f)) continue;
                if (this == f) continue;
                if (GameObject.Random(1000) < Parameters.AIEncirclePlayerRate && GameObject.Chance(f.ArchitectureCount))
                {
                    if (GetEncircleFactionList(f, true) == null) continue;
                    foreach (Architecture a in this.Architectures)
                    {
                        if (a.Fund > 120000 + a.AbundantFund)
                        {
                            Encircle(a, f);
                            return;
                        }
                    }
                }
            }

            if (GameObject.Random(180 * (5 - this.Leader.Ambition)) == 0 && GameObject.Chance(100 - Parameters.AIEncirclePlayerRate))
            {
                GameObjectList factions = this.GetAdjecentHostileFactions();
                if (factions.Count == 0) return;

                factions.PropertyName = "Power";
                factions.IsNumber = true;
                factions.SmallToBig = false;
                factions.ReSort();

                int rank = Parameters.AIEncircleRank + GameObject.Random(Parameters.AIEncircleVar * 2) - Parameters.AIEncircleVar;
                rank = Math.Min(rank, 100);
                rank = Math.Max(rank, 0);
                Faction target = (Faction) factions[(factions.Count - 1) * rank / 100];
                int rel = base.Scenario.GetDiplomaticRelation(this.ID, target.ID);
                if (target != this && rel < 0 && GetEncircleFactionList(target, true) != null)
                {
                    if (GameObject.Chance(Math.Abs(rel) / 10))
                    {
                        foreach (Architecture a in this.Architectures)
                        {
                            if (a.Fund > 120000 + a.AbundantFund)
                            {
                                Encircle(a, target);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private int? powerCache = null;
        public int Power
        {
            get
            {
                if (powerCache == null)
                {
                    powerCache = this.ArchitectureCount * 10000 + this.TotalPersonMerit / 10 + this.Population / 10 + this.ArmyScale * 100;
                }
                return powerCache.Value;
            }
        }

        private void AI()
        {
            base.Scenario.Threading = true;
            this.AIFinished = false;
            this.AIPrepare();
            this.AIDiplomacy();
            this.AISections();
            this.AICapital();
            this.AICaptives();
            this.AITechniques();
            this.AIMakeMarriage();
            this.AISelectPrince();
            this.AIZhaoXian();
            this.AIAppointMayor();
            this.AIHouGong();
            this.AITransfer();
            this.AIArchitectures();
            this.AILegions();
            this.AIReward();
            this.AIFinished = true;
            base.Scenario.Threading = false;
        }

        class DistanceComparer : IComparer<GameObject>
        {
            private Architecture target;
            public DistanceComparer(Architecture target)
            {
                this.target = target;
            }

            public int Compare(GameObject x, GameObject y)
            {
                double a = target.Scenario.GetDistance(target.Position, ((Architecture)x).Position);
                double b = target.Scenario.GetDistance(target.Position, ((Architecture)y).Position);
                if (a > b)
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void WithdrwalTransfer(ArchitectureList architectures)
        {
            foreach (Architecture a in architectures)
            {
                if (a.Abandoned)
                {
                    a.WithdrawResources();
                    a.WithdrawMilitaries();
                    a.WithdrawPerson();
                }
            }
        }

        internal void FullTransfer(ArchitectureList srcArch, ArchitectureList destArch, bool resource, bool person, bool military)
        {
            foreach (Architecture a in srcArch)
            {
                if (a.Abandoned) continue;

                List<GameObject> candidates = new List<GameObject>(destArch.GameObjects);
                candidates.Sort(new DistanceComparer(a));

                if (a.Fund >= a.FundCeiling * 0.9 && resource && a.IsFundAbundant)
                {
                    foreach (Architecture b in candidates)
                    {
                        if (b.Fund + b.FundInPack < b.FundCeiling * 0.8 && !b.Abandoned && b != a)
                        {
                            int toTransfer = (int) (Math.Min(a.Fund - a.FundCeiling * (a.FrontLine ? 0.7 : 0.5), b.FundCeiling * 0.8 - b.Fund - b.FundInPack));
                            b.CallResource(a, toTransfer, 0);
                            if (a.Fund < a.FundCeiling * 0.9) break;
                        }
                    }
                }
                if (a.Food >= a.FoodCeiling * 0.9 && resource && a.IsFoodAbundant)
                {
                    foreach (Architecture b in candidates)
                    {
                        if (b.Food + b.FoodInPack < b.FoodCeiling * 0.8 && !b.Abandoned && b != a)
                        {
                            int toTransfer = (int)(Math.Min(a.Food - a.FoodCeiling * (a.FrontLine ? 0.7 : 0.5), b.FoodCeiling * 0.8 - b.Food - b.FoodInPack));
                            b.CallResource(a, 0, toTransfer);
                            if (a.Food < a.FoodCeiling * 0.9) break;
                        }
                    }
                }

                if (a.IsTroopExceedsLimit && military && !a.FrontLine && a.HasPerson())
                {
                    int toSend = a.ArmyScale / 2;
                    foreach (Architecture b in candidates)
                    {
                        if ((!b.IsTroopExceedsLimit || b.FrontLine) && b.IsFoodTwiceAbundant && !b.Abandoned & b != a)
                        {
                            int sent = b.CallMilitary(a, toSend);
                            toSend -= sent;
                            if (toSend <= 0) break;
                            if (!a.HasPerson()) break;
                        }
                    }
                }
            }
        }

        internal void AllocationTransfer(ArchitectureList srcArch, ArchitectureList destArch, bool resource, bool person, bool military)
        {
            ArchitectureList scope = new ArchitectureList();

            Dictionary<Architecture, int> minPerson = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> minFund = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> minFood = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> minTroop = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> goodPerson = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> goodFund = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> goodFood = new Dictionary<Architecture, int>();
            Dictionary<Architecture, int> goodTroop = new Dictionary<Architecture, int>();
            bool urgent = false;

            foreach (Architecture a in srcArch.GameObjects.Union(destArch.GameObjects))
            {
                if (!a.Abandoned)
                {
                    scope.Add(a);

                    if (a.HasHostileTroopsInView() || a.RecentlyAttacked > 0)
                    {
                        minPerson.Add(a, a.EnoughPeople + a.JianzhuGuimo * 3);
                        minTroop.Add(a, a.TroopReserveScale); // defensiveCampaign will deal with this
                        urgent = true;
                    }
                    else if (a.PlanArchitecture != null)
                    {
                        minPerson.Add(a, Math.Min(3, a.EnoughPeople));
                        minTroop.Add(a, a.TroopReserveScale);
                    }
                    else if (a.FrontLine || a.IsNetLosingPopulation)
                    {
                        minPerson.Add(a, Math.Min(3, a.EnoughPeople) / 2);
                        minTroop.Add(a, a.TroopReserveScale);
                    }
                    else
                    {
                        minPerson.Add(a, 0);
                        minTroop.Add(a, 0);
                    }
                    minFund.Add(a, Math.Min(a.FundCeiling, a.EnoughFund));
                    minFood.Add(a, Math.Min(a.FoodCeiling, a.EnoughFood));

                    if (a.HostileLine || a.orientationFrontLine)
                    {
                        int troop = Math.Max(a.HostileScale, a.OrientationScale);
                        if (a.IsVeryGood())
                        {
                            goodPerson.Add(a, Math.Max(3, minPerson[a]));
                        }
                        else
                        {
                            goodPerson.Add(a, Math.Max(a.EnoughPeople, minPerson[a]));
                        }
                        goodTroop.Add(a, Math.Max(troop, minTroop[a]));
                        goodFood.Add(a, Math.Min(a.FoodCeiling, Math.Max(a.AbundantFood * 2, minFood[a])));
                        goodFund.Add(a, Math.Min(a.FundCeiling, Math.Max(a.AbundantFund, minFund[a])));
                    }
                    else if (!a.IsVeryGood())
                    {
                        goodPerson.Add(a, Math.Max(a.EnoughPeople, minPerson[a]));
                        goodTroop.Add(a, Math.Max(a.TroopReserveScale, minTroop[a]));
                        goodFund.Add(a, Math.Min(a.FundCeiling, Math.Max(a.AbundantFund, minFund[a])));
                        goodFood.Add(a, Math.Min(a.FoodCeiling, Math.Max(a.AbundantFood * 2, minFood[a])));
                    }
                    else
                    {
                        goodPerson.Add(a, Math.Max(1, minPerson[a]));
                        goodTroop.Add(a, Math.Max(a.TroopReserveScale, minTroop[a]));
                        goodFund.Add(a, Math.Min(a.FundCeiling, Math.Max(a.AbundantFund, minFund[a])));
                        goodFood.Add(a, Math.Min(a.FoodCeiling, Math.Max(a.AbundantFood * 2, minFood[a])));
                    }
                }
            }

            scope.PropertyName = "Population";
            scope.SmallToBig = false;
            scope.IsNumber = true;
            scope.ReSort();

            for (int priority = 0; priority < 3; ++priority)
            {
                foreach (Architecture a in destArch)
                {
                    if (a.Abandoned) continue;

                    if (!a.HasHostileTroopsInView() && priority < 1) continue;
                    if (a.HasHostileTroopsInView() && priority >= 1) continue;

                    if (!a.FrontLine && priority < 2) continue;
                    if (a.FrontLine && priority >= 2) continue;

                    if (a.ArmyScale < minTroop[a] && military && (a.SuspendTroopTransfer <= 0 || urgent))
                    {
                        int deficit = minTroop[a] * 2 - a.ArmyScale;

                        List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                        candidates.Sort(new DistanceComparer(a));

                        foreach (Architecture b in candidates)
                        {
                            if (b.Abandoned || b == a) continue;
                            if (b.ArmyScale > goodTroop[b])
                            {
                                int send = Math.Min(deficit, b.ArmyScale - goodTroop[b]);
                                send = a.CallMilitary(b, send);
                                if (send > 0)
                                {
                                    deficit -= send;
                                    if (deficit <= 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (deficit > 0)
                        {
                            foreach (Architecture b in candidates)
                            {
                                if (b.Abandoned || b == a) continue;
                                int send = Math.Min(deficit, b.ArmyScale - minTroop[b]);
                                send = a.CallMilitary(b, send);
                                if (send > 0)
                                {
                                    deficit -= send;
                                    if (deficit <= 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (a.PersonCount + a.MovingPersonCount < minPerson[a] && person)
                    {
                        int deficit = minPerson[a] - a.PersonCount - a.MovingPersonCount;

                        List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                        candidates.Sort(new DistanceComparer(a));

                        foreach (Architecture b in candidates)
                        {
                            if (b.Abandoned || b == a) continue;
                            if (b.PersonCount + b.MovingPersonCount > goodPerson[b])
                            {
                                int send = Math.Min(deficit, b.PersonCount + b.MovingPersonCount - goodPerson[b]);
                                send = a.CallPeople(b, send);
                                if (send > 0)
                                {
                                    deficit -= send;
                                    if (deficit <= 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (deficit > 0)
                        {
                            foreach (Architecture b in candidates)
                            {
                                if (b.Abandoned || b == a) continue;
                                if (b.PersonCount + b.MovingPersonCount > minPerson[b])
                                {
                                    int send = Math.Min(deficit, b.PersonCount + b.MovingPersonCount - minPerson[b]);
                                    send = a.CallPeople(b, send);
                                    if (send > 0)
                                    {
                                        deficit -= send;
                                        if (deficit <= 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (deficit > 0 && urgent)
                        {
                            foreach (Architecture b in candidates)
                            {
                                if (b.Abandoned || b == a) continue;
                                if (b.PersonCount + b.MovingPersonCount > 1 && !b.HasHostileTroopsInView() && b.RecentlyAttacked == 0)
                                {
                                    int send = Math.Min(deficit, b.PersonCount + b.MovingPersonCount - minPerson[b]);
                                    send = a.CallPeople(b, send);
                                    if (send > 0)
                                    {
                                        deficit -= send;
                                        if (deficit <= 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }

                    if ((a.Fund < minFund[a] || a.Food < minFood[a]) && resource)
                    {
                        int deficitFund = Math.Max(0, minFund[a] * 2 - a.Fund - a.FundInPack);
                        int deficitFood = Math.Max(0, minFood[a] * 2 - a.Food - a.FoodInPack);
                        deficitFood = Math.Min(deficitFood, a.FoodCeiling - a.FoodInPack - a.Food);
                        deficitFund = Math.Min(deficitFund, a.FundCeiling - a.FundInPack - a.Fund);

                        if (deficitFund > 0 || deficitFood > 0)
                        {
                            List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                            candidates.Sort(new DistanceComparer(a));

                            foreach (Architecture b in candidates)
                            {
                                if (b.Abandoned || b == a) continue;
                                if (!b.withoutTruceFrontline && !b.HasHostileTroopsInView())
                                {
                                    if (b.Fund >= goodFund[b] * 2 || b.Food >= goodFood[b] * 2)
                                    {
                                        int transferFund = Math.Max(0, Math.Min(deficitFund, b.Fund - goodFund[b] * 2));
                                        int transferFood = Math.Max(0, Math.Min(deficitFood, b.Food - goodFood[b] * 2));
                                        if (a.CallResource(b, transferFund, transferFood))
                                        {
                                            deficitFund -= transferFund;
                                            deficitFood -= transferFood;
                                            if (deficitFood <= 0 && deficitFund <= 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (deficitFood > 0 || deficitFund > 0)
                            {
                                foreach (Architecture b in candidates)
                                {
                                    if (b.Abandoned || b == a) continue;
                                    if (!b.HasHostileTroopsInView())
                                    {
                                        if (b.Fund >= goodFund[b] * 2 || b.Food >= goodFood[b] * 2)
                                        {
                                            int transferFund = Math.Max(0, Math.Min(deficitFund, b.Fund - goodFund[b] * 2));
                                            int transferFood = Math.Max(0, Math.Min(deficitFood, b.Food - goodFood[b] * 2));
                                            if (a.CallResource(b, transferFund, transferFood))
                                            {
                                                deficitFund -= transferFund;
                                                deficitFood -= transferFood;
                                                if (deficitFood <= 0 && deficitFund <= 0)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (deficitFood > 0 || deficitFund > 0)
                            {
                                foreach (Architecture b in candidates)
                                {
                                    if (b.Abandoned || b == a) continue;
                                    if (!b.HasHostileTroopsInView())
                                    {
                                        if (b.Fund >= goodFund[b] || b.Food >= goodFood[b])
                                        {
                                            int transferFund = Math.Max(0, Math.Min(deficitFund, b.Fund - goodFund[b]));
                                            int transferFood = Math.Max(0, Math.Min(deficitFood, b.Food - goodFood[b]));
                                            if (a.CallResource(b, transferFund, transferFood))
                                            {
                                                deficitFund -= transferFund;
                                                deficitFood -= transferFood;
                                                if (deficitFood <= 0 && deficitFund <= 0)
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
                }
            }

            foreach (Architecture a in destArch)
            {
                if (a.Abandoned) continue;

                if (a.ArmyScale < goodTroop[a] && military && a.SuspendTroopTransfer <= 0)
                {
                    int deficit = goodTroop[a] * 2 - a.ArmyScale;

                    List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                    candidates.Sort(new DistanceComparer(a));

                    foreach (Architecture b in candidates)
                    {
                        if (b.Abandoned || b == a) continue;
                        if (b.ArmyScale > goodTroop[b])
                        {
                            int send = Math.Min(deficit, b.ArmyScale - goodTroop[b]);
                            send = a.CallMilitary(b, send);
                            if (send > 0)
                            {
                                deficit -= send;
                                if (deficit <= 0)
                                {
                                    break;
                                }
                            }
                        }
                    }

                }

                if (a.PersonCount + a.MovingPersonCount < goodPerson[a] && person)
                {
                    int deficit = goodPerson[a] - a.PersonCount - a.MovingPersonCount;

                    List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                    candidates.Sort(new DistanceComparer(a));

                    foreach (Architecture b in candidates)
                    {
                        if (b.Abandoned || b == a) continue;
                        if (b.PersonCount + b.MovingPersonCount > goodPerson[b])
                        {
                            int send = Math.Min(deficit, b.PersonCount + b.MovingPersonCount - goodPerson[b]);
                            send = a.CallPeople(b, send);
                            if (send > 0)
                            {
                                deficit -= send;
                                if (deficit <= 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                if ((a.Fund < goodFund[a] || a.Food < goodFood[a]) && resource)
                {
                    int deficitFund = Math.Max(0, goodFund[a] * 2 - a.Fund - a.FundInPack);
                    int deficitFood = Math.Max(0, goodFood[a] * 2 - a.Food - a.FoodInPack);
                    deficitFood = Math.Min(deficitFood, a.FoodCeiling - a.FoodInPack - a.Food);
                    deficitFund = Math.Min(deficitFund, a.FundCeiling - a.FundInPack - a.Fund);

                    if (deficitFund > 0 || deficitFood > 0)
                    {
                        List<GameObject> candidates = new List<GameObject>(srcArch.GameObjects);
                        candidates.Sort(new DistanceComparer(a));

                        foreach (Architecture b in candidates)
                        {
                            if (b.Abandoned || b == a) continue;
                            if (!b.withoutTruceFrontline && !b.HasHostileTroopsInView())
                            {
                                if (b.Fund >= goodFund[b] * 2 || b.Food >= goodFood[b] * 2)
                                {
                                    int transferFund = Math.Max(0, Math.Min(deficitFund, b.Fund - goodFund[b] * 2));
                                    int transferFood = Math.Max(0, Math.Min(deficitFood, b.Food - goodFood[b] * 2));
                                    if (a.CallResource(b, transferFund, transferFood))
                                    {
                                        deficitFund -= transferFund;
                                        deficitFood -= transferFood;
                                        if (deficitFood <= 0 && deficitFund <= 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (deficitFood > 0 || deficitFund > 0)
                        {
                            foreach (Architecture b in candidates)
                            {
                                if (b.Abandoned || b == a) continue;
                                if (!b.HasHostileTroopsInView())
                                {
                                    if (b.Fund >= goodFund[b] * 2 || b.Food >= goodFood[b] * 2)
                                    {
                                        int transferFund = Math.Max(0, Math.Min(deficitFund, b.Fund - goodFund[b] * 2));
                                        int transferFood = Math.Max(0, Math.Min(deficitFood, b.Food - goodFood[b] * 2));
                                        if (a.CallResource(b, transferFund, transferFood))
                                        {
                                            deficitFund -= transferFund;
                                            deficitFood -= transferFood;
                                            if (deficitFood <= 0 && deficitFund <= 0)
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

            }
        }

        internal void AIVeryClosePersonTransfer()
        {
            if (GameObject.Chance(10))
            {
                foreach (Person p in this.Persons)
                {
                    if (p.LocationArchitecture != null && p.LocationTroop == null && p.Status == PersonStatus.Normal)
                    {
                        foreach (Person q in p.AvailableVeryClosePersons)
                        {
                            if (q.LocationArchitecture != null && q.LocationTroop == null && q.LocationArchitecture != p.LocationArchitecture &&
                                q.Status == PersonStatus.Normal && !q.DontMoveMeUnlessIMust && !this.MayorList.GameObjects.Contains(q))
                            {
                                if (base.Scenario.IsPlayer(this))
                                {
                                    if (p.LocationArchitecture.BelongedSection.AIDetail.AutoRun && q.LocationArchitecture.BelongedSection.AIDetail.AutoRun)
                                    {
                                        q.MoveToArchitecture(p.LocationArchitecture);
                                    }
                                }
                                else
                                {
                                    q.MoveToArchitecture(p.LocationArchitecture);
                                }
                            }
                        }
                    }
                }
            }
        }


        internal void AITransferPlanning(ArchitectureList architectures)
        {
            WithdrwalTransfer(architectures);
            AllocationTransfer(architectures, architectures, true, true, true);
            if (GameObject.Chance(10))
            {
                FullTransfer(architectures, architectures, true, true, true);
            }
        }

        private void PlayerAITransfer()
        {
            foreach (Section s in this.Sections)
            {
                if (s.AIDetail.AutoRun)
                {
                    s.AIIntraTransfer();
                    if (s.AIDetail.AllowFoodTransfer || s.AIDetail.AllowFundTransfer || s.AIDetail.AllowMilitaryTransfer)
                    {
                        s.AIInterTransfer();
                    }
                }
            }
        }

        private void AITransfer()
        {
            if (this.Architectures.Count > 1)
            {
                this.AITransferPlanning(this.Architectures);
            }
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
                                architecture.AddFundPack(num2, (int)(base.Scenario.GetDistance(this.Capital.ArchitectureArea, architecture.ArchitectureArea) / 5.0));
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
                            architecture.AddFundPack(num2, (int)(base.Scenario.GetDistance(this.Capital.ArchitectureArea, architecture.ArchitectureArea) / 5.0));
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
                        captive.CaptivePerson.SetBelongedCaptive(null, PersonStatus.Normal);
                        if ((captive.CaptivePerson != null) && (captive.CaptiveFaction != null))
                        {
                            captive.CaptivePerson.MoveToArchitecture(captive.CaptiveFaction.Capital);
                        }
                        
                        continue;
                    }
                    if ((captive.BelongedFaction.Capital != null) && (captive.RansomArriveDays <= 0))
                    {
                        if (captive.CaptivePerson == this.Leader && this.Capital.Fund >= captive.Ransom)
                        {
                            captive.SendRansom(captive.BelongedFaction.Capital, this.Capital);
                            continue;
                        }
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
                    int num2 = 2 + (this.ArchitectureCount / 8);
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
                        architecture.GenerateAllAILinkNodes(2);
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

        public void AfterChangeLeader(Person oldLeader, Person newLeader)
        {
            foreach (Person p in this.Persons)
            {
                if (p.Loyalty < 110 || (!oldLeader.IsCloseTo(newLeader) && !oldLeader.HasStrainTo(newLeader)))
                {
                    p.Loyalty -= (int)Math.Max(0, (Person.GetIdealOffset(p, newLeader) / 75.0f - 5) * 20);
                    if (!oldLeader.IsCloseTo(newLeader) && !oldLeader.HasStrainTo(newLeader))
                    {
                        p.Loyalty -= (int)Math.Max(0, (Person.GetIdealOffset(p, newLeader) / 75.0f - 5) * 30);
                    }
                    p.Loyalty -= GameObject.Random(10);
                    p.LeaveFaction();
                }
            }

            foreach (Architecture a in this.Architectures)
            {
                foreach (Person p in a.Feiziliebiao)
                {
                    a.PrincessChangeLeader(false, a.BelongedFaction, p);
                }
            }

            do
            {
                base.Scenario.NewFaction(this.Persons);
            } while (GameObject.Chance(50));
        }

        public Faction ChangeLeaderAfterLeaderDeath()
        {
            Person leader = this.Leader;
            Architecture locationArchitecture = this.Leader.LocationArchitecture;
            this.Leader.Status = GameObjects.PersonDetail.PersonStatus.None;
            // this.Leader.Available = false;
            // base.Scenario.Persons.Remove(this.Leader);
            base.Scenario.AvailablePersons.Remove(this.Leader);
            Person person2 = null;
            PersonList list = new PersonList();
            if (person2 == null)
            {
                foreach (Person person3 in this.Persons)
                {
                    if (this.Prince != null && person3 == this.Prince && person3 != this.Leader)
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
                    if ((person3.Father != null) && (person3.Sex == this.Leader.Sex) && (this.Leader == person3.Father) && person3 != this.Leader)
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
                    if ((person3.Father != null) && (person3.Sex == this.Leader.Sex) && (this.Leader.Father == person3.Father)
                        && person3 != this.Leader)
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
                    if ((person3.Strain >= 0) && (person3.Sex == this.Leader.Sex) && (this.Leader.Strain == person3.Strain) && person3 != this.Leader)
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
                foreach (Person person3 in this.Leader.Brothers)
                {
                    if (person3 != this.Leader && person3.BelongedFaction == this)
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
                    if ((person3.Mother != null) && (person3.Sex == this.Leader.Sex) && ((this.Leader.Mother == person3.Mother) || (person3.Mother == this.Leader))
                        && person3 != this.Leader && person3.BelongedFaction == this)
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
            if (person2 == null && GlobalVariables.PermitFactionMerge && !this.IsAlien)
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
                    this.AfterChangeLeader(leader, maxFriendlyDiplomaticRelation.Leader);
                    return maxFriendlyDiplomaticRelation;
                }
            }
            if (person2 == null)
            {
                list.Clear();
                foreach (Person person3 in this.Persons)
                {
                    if ((this.Leader.Ideal == person3.Ideal) && (person3.Sex == this.Leader.Sex) && person3 != this.Leader)
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
                    if (person3.Sex == this.Leader.Sex && person3 != this.Leader)
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
                    if (person3 != this.Leader)
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
                base.Scenario.YearTable.addChangeKingEntry(base.Scenario.Date, this.Leader, this, leader);
                this.AfterChangeLeader(leader, this.Leader);
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
            if ((((((leader.LocationArchitecture != null) && (leader.LocationArchitecture.BelongedFaction == this.Leader.BelongedFaction)) 
                || ((leader.LocationTroop != null) && (leader.LocationTroop.BelongedFaction == this.Leader.BelongedFaction))) 
                && (GameObject.Random(leader.CaptiveAbility) < GameObject.Random(this.Leader.CaptiveAbility))) 
                && base.Scenario.IsPlayer(this)) && (this.OnAfterCatchLeader != null))
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
                section.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, true, false, true, true, false)[0] as SectionAIDetail;
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
            if (!this.Leader.Alive || !this.Leader.Available || this.Leader.BelongedFaction != this)
            {
                ChangeLeaderAfterLeaderDeath();
            }
           // this.SpyMessageCloseList.Clear();
            this.TechniquesDayEvent();
            this.InformationDayEvent();
            this.MilitaryDayEvent();
            if (!base.Scenario.IsPlayer(this))
            {
               // this.AISelectPrince();
                this.AIchaotingshijian();
                this.AIBecomeEmperor();
            }
            this.armyScale = this.ArmyScale; // 小写的是每天的缓存，因为被InternalSurplusRate叫很多次，不想每次都全部重新计算，大写的才是真正的值
            this.InternalSurplusRateCache = -1;
            this.visibleTroopsCache = null;
        }

        public MilitaryList TransferingMilitaries
        {
            get
            {
                MilitaryList list = new MilitaryList();
                foreach (Military m in this.Scenario.Militaries )
                {

                    if (m.StartingArchitecture != null && m.TargetArchitecture != null && m.ArrivingDays > 0  && m.StartingArchitecture.BelongedFaction != null && m.StartingArchitecture.BelongedFaction == this && m.BelongedArchitecture == null)
                    {
                        list.Add(m);
                    }   
                }
        
                return list;
            }
        }

        public List<string> LoadTransferingMilitariesFromString(MilitaryList militaries, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.TransferingMilitaries.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Military gameObject = militaries.GetGameObject(int.Parse(str)) as Military;
                    if (gameObject != null)
                    {
                        this.TransferingMilitaries.AddMilitary(gameObject);
                        this.AddMilitary(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("编队ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("编队列表一栏应为半型空格分隔的编队ID");
            }
            return errorMsg;
        }

        public List<string> LoadMilitariesFromString(MilitaryList militaries, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Militaries.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Military gameObject = militaries.GetGameObject(int.Parse(str)) as Military;
                    if (gameObject != null)
                    {
                        this.Militaries.AddMilitary(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("编队ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("编队列表一栏应为半型空格分隔的编队ID");
            }
            return errorMsg;
        }

        private void HandleMilitary(Military military)
        {
            if (military.ArrivingDays != 0)
            {
                military.ArrivingDays = 0;
            }
            military.StartingArchitecture = null;
            military.TargetArchitecture = null;
            this.TransferingMilitaries.Remove(military);
            this.TransferingMilitaryCount--;
        }

        private void MilitaryDayEvent()
        {
            //if (this.TransferingMilitaryCount == 0) return;

            foreach (Military m in this.TransferingMilitaries)
            {
                m.ArrivingDays--;


                if (m.ArrivingDays == 0)
                {
                    if (m.StartingArchitecture != null && m.TargetArchitecture != null  && m.TargetArchitecture.BelongedFaction != null 
                        && m.TargetArchitecture.BelongedFaction == this && m.BelongedArchitecture == null )
                        
                      
                    {
                       
                        m.TargetArchitecture.AddMilitary(m);
                        this.Scenario.GameScreen.TransferMilitaryArrivesAtArchitecture(m, m.TargetArchitecture);
                       
                    }
                   
                    this.HandleMilitary(m);
                }
                else 
                {
                    if (m.StartingArchitecture != null && m.TargetArchitecture != null && m.TargetArchitecture.BelongedFaction != null && m.TargetArchitecture.BelongedFaction != this) //运兵过程中目标建筑被占领，停止运输，编队返回出发建筑
                    {
                        
                            if (m.StartingArchitecture.BelongedFaction != null && m.BelongedArchitecture == null)
                            {
                                
                                m.StartingArchitecture.AddMilitary(m);
                            }
                            
                            this.HandleMilitary(m);
                        
                    }
                    else if (m.StartingArchitecture != null && m.TargetArchitecture != null && m.StartingArchitecture.BelongedFaction != null
                        && m.TargetArchitecture.BelongedFaction != null && m.TargetArchitecture.IsSurrounded())   //运兵过程中目标建筑被围城，停止运兵,编队返回出发建筑
                    {
                        if (m.BelongedArchitecture == null)
                        {
                            m.StartingArchitecture.AddMilitary(m);
                        }
                       
                        this.HandleMilitary(m);
                    }


                    else if (m.StartingArchitecture != null && m.StartingArchitecture.BelongedFaction == null) //势力灭亡，停止运兵，编队暂时消失
                    {
                        this.HandleMilitary(m);

                    }
                }

            }
           
        }

        private void AISelectPrince()
        {
            if (!base.Scenario.IsPlayer(this))
            {
                if (GameObject.Random(10) == 0 && (this.Capital != null) && this.Capital.SelectPrinceAvail())
                {
                    Person person = this.Leader.ChildrenCanBeSelectedAsPrince()[0] as Person;
                    this.PrinceID = person.ID;
                    this.Capital.DecreaseFund(Parameters.SelectPrinceCost);
                    this.Capital.SelectPrince(person); //AI立储年表和报告
                    //this.Scenario.GameScreen.xianshishijiantupian(this.Leader, person.Name, "SelectPrince", "", "", true);

                }
            }
        }

        

        private void AIAppointMayor()
        {
            if (!base.Scenario.IsPlayer(this))
            {
                if (GameObject.Random(10) == 0)
                {
                    foreach (Architecture a in this.Architectures)
                    {
                        if (a.AppointMayorAvail())
                        {
                            Person person = a.AIMayorCandicate[0] as Person;
                            a.MayorID = person.ID;
                            a.AppointMayor(person);
                        }
                    }
                }
            }
        }


        private Dictionary<PersonGeneratorType, int> count = new Dictionary<PersonGeneratorType, int>();

        public void IncrementGeneratorCount(PersonGeneratorType type)
        {
            if (count.ContainsKey(type))
            {
                count[type]++;
            }
            else
            {
                count.Add(type, 1);
            }
        }

        public int GetGeneratorPersonCount(PersonGeneratorType type)
        {
            return count.ContainsKey(type) ? count[type] : 0;
        }

         

       // private List<PersonGeneratorType> allTypes = new List<PersonGeneratorType>();
      //  private Dictionary<PersonGeneratorType, int> types = new Dictionary<PersonGeneratorType, int>();

        public string SaveGeneratorPersonCountToString()
        {
            
            StringBuilder sb = new StringBuilder();
            foreach (PersonGeneratorType type in base.Scenario.GameCommonData.AllPersonGeneratorTypes)
            {
                sb.AppendFormat("{0}:{1},", type.ID, count.ContainsKey(type) ? count[type] : 0);
            }
            return sb.Length > 0 ? sb.ToString(0, sb.Length - 1) : "";
        }

        public  void LoadGeneratorPersonCountFromString(String s)
        {
            count.Clear();
            string[] sArray = s.Split(',');
            foreach (string ss in sArray)
            {
                string[] arr = ss.Split(':');
                int typeID = int.Parse(arr[0]);
                int typeCount = int.Parse(arr[1]);
                PersonGeneratorType type = FindPersonGeneratorType(typeID);
                if (type == null || typeCount < 0)
                {
                    throw new Exception("Invaild Person Generator Count");
                }
                count.Add(type, typeCount);

            }
                
        }

        public PersonGeneratorType FindPersonGeneratorType(int id)
        {
            foreach (PersonGeneratorType type in base.Scenario.GameCommonData.AllPersonGeneratorTypes)
            {
                if (type.ID == id)
                {
                    return type;
                }
            }
            return null;
        }


        private void AIZhaoXian()
        {
            if (GlobalVariables.ZhaoXianSuccessRate <= 0) return;

            if (base.Scenario.IsPlayer(this)) return;

            if (GameObject.Random(10) != 0) return;

            foreach (Architecture a in this.Architectures)
            {
                while (a.CanZhaoXian() && !a.HasEnoughPeople)
                {
                    PersonGeneratorTypeList list = a.AvailGeneratorTypeList();
                    int max = 0;
                    PersonGeneratorType type = null;
                    foreach (PersonGeneratorType t in list) {
                        if (t.CostFund > max)
                        {
                            type = t;
                            max = t.CostFund;
                        }
                    }
                    a.DoZhaoXian(type);

                }
            }     
            
        }


        private void AIReward()
        {
            if (!base.Scenario.IsPlayer(this) && this.RewardTroopPersonAvail())
            {
                this.RewardTroopPerson();
            }
        }

        public bool RewardTroopPersonAvail()
        {
            return this.RewardableTroopPersons().Count > 0 && this.Capital.Fund > this.Capital .RewardPersonFund;
        }

        public PersonList RewardableTroopPersons()
        {
            PersonList list = new PersonList();
            foreach (Troop troop in this.Troops)
            {
                foreach (Person person in troop.Persons)
                {
                    if ((!person.RewardFinished && (person.Loyalty < 100)) && (person != this.Leader))
                    {
                        list.Add(person);
                    }
                }
            }
            return list;
        }
             

        public void RewardTroopPerson()
        {
            if (this.TroopCount == 0) return;

            if (this.Capital.Fund < this.Capital.RewardPersonFund) return;

            foreach (Person person in this.RewardableTroopPersons())
            {
                person.RewardFinished = true;
                this.Capital.DecreaseFund(this.Capital.RewardPersonFund);
                int idealOffset = Person.GetIdealOffset(person, this.Leader);
                person.IncreaseLoyalty((15 - (idealOffset / 5)) + 4 - (int)person.PersonalLoyalty);
            }

        }

        private void AIchaotingshijian()
        {
            if (base.Scenario.youhuangdi() && !base.Scenario.IsPlayer(this) && !this.IsAlien
                && (this.guanjue < this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1))
            {
                if (base.Scenario.Date.Month == 3)
                {
                    this.AIjingong();
                }
            }
        }

        public int FundToAdvance
        {
            get
            {
                int cashToGive = 0;
                foreach (guanjuezhongleilei g in this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhongleiliebiao())
                {
                    if (g.xuyaochengchi <= this.ArchitectureCount)
                    {
                        cashToGive = g.xuyaogongxiandu - this.chaotinggongxiandu;
                    }
                }
                return cashToGive;
            }
        }

        private void AIjingong()
        {
            if (this.IsAlien) return;

            int cashToGive = this.FundToAdvance;

            if (cashToGive > 0)
            {
                int givenValue = 0;
                Dictionary<Architecture, int> archGiveFund = new Dictionary<Architecture, int>();
                foreach (Architecture a in this.Architectures.GetRandomList())
                {
                    int canGiveFund = a.Fund - a.EnoughFund;
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
            this.Leader.Reputation /= 2;
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

        private void FactionDiplomaticRelation()
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
                if (this.getInformationLevel(point) > level)
                {
                    level = this.getInformationLevel(point);
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
            return this.getInformationLevel(position);
        }

        public InformationLevel GetKnownAreaDataNoCheck(Point position)
        {
            return this.getInformationLevel(position);
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

        public int GetMapCost(Troop troop, Point position, MilitaryKind kind)
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

            Architecture onArch = base.Scenario.GetArchitectureByPositionNoCheck(position);
            if (onArch == null)
            {
                terrainAdaptability = troop.GetTerrainAdaptability((TerrainKind)this.mapData[position.X, position.Y]);
            }
            int waterPunishment = 0;
            if (this.mapData[position.X, position.Y] == 6 && kind.Type != MilitaryType.水军 && onArch == null)
            {
                waterPunishment = 3;
            }
            return ((terrainAdaptability + base.Scenario.GetWaterPositionMapCost(kind, position)) + base.Scenario.GetPositionMapCost(this, position) + waterPunishment);
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
                return (((float)num) / ((float)num2));
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

        /*
        public int EachMilitaryKindCount(int id)
        {
            int count = 0;
            foreach (Military military in this.Militaries)
            {
                if (military.RealKindID == id)
                {
                    count++;
                }
            }
            MilitaryKind mk = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(id);
            return count;
        }
        */
         
        public bool IsMilitaryKindOverLimit(int id)
        {
            int count = 0;
            foreach (Military military in this.Militaries)
            {
                if (military.RealKindID == id)
                {
                    count++;
                }
            }
            

            MilitaryKind mk = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(id);
            return count >= mk.RecruitLimit;
            
            
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
            this.techniquePoint = (int)(this.techniquePoint + increment * GlobalVariables.TechniquePointMultiple);
        }

        private void InformationDayEvent()
        {
            InformationList list = new InformationList();
            foreach (Information information in this.Informations)
            {
                information.DaysLeft--;
                information.DaysStarted++;
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
                if (this.getInformationLevel(point) != InformationLevel.无)
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
            return ((faction == this) || (base.Scenario.GetDiplomaticRelation(base.ID, faction.ID) >= GlobalVariables.FriendlyDiplomacyThreshold) || (base.Scenario.GetDiplomaticRelationTruce(base.ID, faction.ID) > 0));
        }

        public bool IsFriendlyWithoutTruce(Faction faction)
        {
            if (faction == null)
            {
                return false;
            }
            return (faction == this) || (base.Scenario.GetDiplomaticRelation(base.ID, faction.ID) >= GlobalVariables.FriendlyDiplomacyThreshold);
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
            return (this.getInformationLevel(position) != InformationLevel.无);
        }

        private bool IsTechniqueUpgradable(Technique t)
        {
            return (!this.HasTechnique(t.ID) && ((t.PreID < 0) || this.HasTechnique(t.PreID))) && t.CanResearch(this);
        }

        public bool IsTechniqueUpgrading(int id)
        {
            return (id == this.UpgradingTechnique);
        }

        public List<string> LoadInformationsFromString(InformationList informations, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Informations.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Information gameObject = informations.GetGameObject(int.Parse(str)) as Information;
                    if (gameObject != null)
                    {
                        this.AddInformation(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("情报ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("情报列表应为半型空格分隔的情报ID");
            }
            return errorMsg;
        }

        public List<string> LoadLegionsFromString(LegionList legions, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Legions.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Legion gameObject = legions.GetGameObject(int.Parse(str)) as Legion;
                    if (gameObject != null)
                    {
                        this.AddLegion(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("LegionID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("Legion列表应为半型空格分隔的LegionID");
            }
            return errorMsg;
        }

        public List<string> LoadRoutewaysFromString(RoutewayList routeways, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Routeways.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Routeway gameObject = routeways.GetGameObject(int.Parse(str)) as Routeway;
                    if (gameObject != null)
                    {
                        this.AddRouteway(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("粮道ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("粮道列表应为半型空格分隔的粮道ID");
            }
            return errorMsg;
        }

        public List<string> LoadArchitecturesFromString(ArchitectureList architectures, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Architectures.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Architecture architecture = architectures.GetGameObject(int.Parse(str)) as Architecture;
                    if (architecture != null)
                    {
                        this.AddArchitecture(architecture);
                        this.AddArchitectureMilitaries(architecture);
                        
                    }
                    else
                    {
                        errorMsg.Add("建筑ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("建筑列表应为半型空格分隔的建筑ID");
            }
            return errorMsg;
        }

        public List<string> LoadSectionsFromString(SectionList sections, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Sections.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Section section = sections.GetGameObject(int.Parse(str)) as Section;
                    if (section != null)
                    {
                        this.AddSection(section);
                    }
                    else
                    {
                        errorMsg.Add("军区ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("军区列表应为半型空格分隔的军区ID");
            }
            if (this.SectionCount == 0)
            {
                // errorMsg.Add("没有军区");
            }
            return errorMsg;
        }

        public List<string> LoadTroopsFromString(TroopList troops, string dataString)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Troops.Clear();
            try
            {
                foreach (string str in strArray)
                {
                    Troop gameObject = troops.GetGameObject(int.Parse(str)) as Troop;
                    if (gameObject != null)
                    {
                        this.AddTroop(gameObject);
                        this.AddTroopMilitary(gameObject);
                    }
                    else
                    {
                        errorMsg.Add("部队ID" + str + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("部队列表应为半型空格分隔的部队ID");
            }
            return errorMsg;
        }

        public int getTechniqueActualPointCost(Technique technique)
        {
            if (this.techniquePointCostRateDecrease.Count == 0) return technique.PointCost;
            return (int)Math.Round(technique.PointCost * (1 - this.techniquePointCostRateDecrease.Max()));
        }

        public int getTechniqueActualReputation(Technique technique)
        {
            if (this.techniqueReputationRateDecrease.Count == 0) return technique.Reputation;
            return (int)Math.Round(technique.Reputation * (1 - this.techniqueReputationRateDecrease.Max()));
        }

        public int getTechniqueActualFundCost(Technique technique)
        {
            if (this.techniqueFundCostRateDecrease.Count == 0) return technique.FundCost;
            return (int)Math.Round(technique.FundCost * (1 - this.techniqueFundCostRateDecrease.Max()));
        }

        public int getTechniqueActualTime(Technique technique)
        {
            if (this.techniqueTimeRateDecrease.Count == 0) return technique.Days;
            return (int)Math.Round(technique.Days * (1 - techniqueTimeRateDecrease.Max()));
        }

        public bool MatchTechnique(Technique technique, Architecture architecture)
        {
            return (((((this.TotalTechniquePoint >= this.getTechniqueActualPointCost(technique)) &&
                (this.Reputation >= this.getTechniqueActualReputation(technique))) &&
                (architecture.Fund >= this.getTechniqueActualFundCost(technique))) &&
                (this.HasTechnique(technique.PreID) || (technique.PreID < 0))) && (this.UpgradingTechnique < 0)) && technique.CanResearch(this);
        }

        public void MonthEvent()
        {
            this.FactionDiplomaticRelation();
            powerCache = null;
            
        }

        private void PlayerAI()
        {
            base.Scenario.Threading = true;
            this.AIFinished = false;
            this.AIPrepare();
            this.PlayerAITransfer();
            this.PlayerTechniqueAI();
            this.PlayerAIArchitectures();
            this.PlayerAILegions();
            this.PlayerAIRewardTroopPerson();
            this.AIFinished = true;
            base.Scenario.Threading = false;
        }

        private void PlayerAIRewardTroopPerson()
        {
            if (base.Scenario.IsPlayer(this) && this.RewardTroopPersonAvail())
            {
                this.RewardTroopPerson();
            }
        }

        private void PlayerAIArchitectures()
        {
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                if (architecture.BelongedSection == null || architecture.BelongedSection.AIDetail.AutoRun)
                {
                    if (architecture.BelongedSection == null)
                    {
                        architecture.BelongedSection = architecture.BelongedFaction.FirstSection;
                    }
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
            this.knownAreaData = new Dictionary<Point, InformationTile>();
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
            if ((this.Capital != null) && (base.Scenario.GameScreen.LoadScenarioInInitialization || base.Scenario.Date.Day == 1 || this.SectionCount == 0))
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
                this.RemoveKnownAreaData(point, InformationLevel.全);
            }
            foreach (Point point in a.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    this.RemoveKnownAreaData(point, InformationLevel.高);
                }
            }
            if (a.Kind.HasLongView)
            {
                foreach (Point point in a.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        this.RemoveKnownAreaData(point, InformationLevel.中);
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
            /*if (this.militaryKindCounts.ContainsKey(military.Kind))
            {
                this.militaryKindCounts[military.Kind]--;
            }*/
            military.BelongedFaction = null;
        }

        /*
        public void MorphMilitary(MilitaryKind before, MilitaryKind after)
        {
            if (this.militaryKindCounts.ContainsKey(before))
            {
                this.militaryKindCounts[before]--;
            }
            if (this.militaryKindCounts.ContainsKey(after))
            {
                this.militaryKindCounts[after]++;
            }
            else
            {
                this.militaryKindCounts[after] = 1;
            }
        }
        */
        public void RemovePositionInformation(Point position, InformationLevel level)
        {
            if (!base.Scenario.PositionOutOfRange(position))
            {
                this.RemoveKnownAreaData(position, level);
            }
        }

        public void RemoveRouteway(Routeway routeway)
        {
            this.Routeways.Remove(routeway);
            this.Scenario.Routeways.Remove(routeway);
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
                    this.RemoveKnownAreaData(point, InformationLevel.全);
                }
                else
                {
                    this.RemoveKnownAreaData(point, troop.ScoutLevel);
                }
            }
        }

        public void RemoveTroopMilitary(Troop troop)
        {
            this.RemoveMilitary(troop.Army);
        }

        public bool adjacentTo(Faction f)
        {
            if (this == f) return false;
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

        public FactionList AdjecentFactionList
        {
            get
            {
               /* FactionList list = new FactionList();
                foreach (Faction f in this.GetAdjecentFactions())
                {
                    list.Add(f);
                }
                return list;
                */
                return this.GetAdjecentFactions();
            }
        }

        public FactionList GetAdjecentFactions()
        {
            FactionList result = new FactionList();
            foreach (Faction f in base.Scenario.Factions)
            {
                if (this.adjacentTo(f))
                {
                    result.Add(f);
                }
            }
            return result;
        }

        public FactionList GetAdjecentHostileFactions()
        {
            FactionList result = new FactionList();
            foreach (Faction f in base.Scenario.Factions)
            {
                if (this.adjacentTo(f) && this.IsHostile(f))
                {
                    result.Add(f);
                }
            }
            return result;
        }

        private bool hasNonFriendlyFrontline
        {
            get
            {
                foreach (Architecture i in this.Architectures)
                {
                    foreach (Architecture j in i.AILandLinks)
                    {
                        if (j.BelongedFaction == null) continue;
                        if (j.BelongedFaction.ID == this.ID) continue;
                        if (base.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, j.BelongedFaction.ID, this.ID).Relation < GlobalVariables.FriendlyDiplomacyThreshold)
                        {
                            return true;
                        }
                    }
                    foreach (Architecture j in i.AIWaterLinks)
                    {
                        if (j.BelongedFaction == null) continue;
                        if (j.BelongedFaction.ID == this.ID) continue;
                        if (base.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, j.BelongedFaction.ID, this.ID).Relation < GlobalVariables.FriendlyDiplomacyThreshold)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public FactionList GetEncircleFactionList(Faction target, bool simulate) 
        {
            FactionList encircleList = new FactionList();
            foreach (Faction f in base.Scenario.Factions)
            {
                if (base.Scenario.IsPlayer(f)) continue; // TODO let player choose whether to enter
                if ((f != target) && (f.Leader.StrategyTendency != PersonStrategyTendency.维持现状 || GlobalVariables.IgnoreStrategyTendency) && !f.IsAlien)
                {
                    if (((base.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, target.ID, f.ID).Relation +
                        Person.GetIdealOffset(target.Leader, f.Leader) * 1.5) < 0
                        && (GameObject.Chance(60) || simulate) && !f.IsFriendly(target) && (f.adjacentTo(target) || GameObject.Chance(30) || simulate))
                        )
                    {
                        encircleList.Add(f);
                    }
                }
            }
            if (encircleList.Count >= 3 && (!simulate || encircleList.Count >= 6))
            {
                return encircleList;
            }
            else
            {
                return null;
            }
        }

        public void CheckEncircleDiplomatic(Faction target)
        {
            FactionList encircleList = GetEncircleFactionList(target, false);
            if (encircleList != null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, TextMessageKind.EncircleDiplomaticRelation, "EncircleDiplomaticRelation", "EncircleDiplomaticRelation.jpg", "EncircleDiplomaticRelation.wav", target.Name, true);
                foreach (Faction i in encircleList)
                {
                    foreach (Faction j in encircleList)
                    {
                        if (i != j)
                        {
                            if (this.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, i.ID, j.ID).Truce < 180)
                            {
                                this.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, i.ID, j.ID).Truce = 180;
                            }
                        }
                    }
                }
            }
        }

        public void Encircle(Architecture encircler, Faction toEncircle)
        {
            this.Scenario.GameScreen.xianshishijiantupian(encircler.Scenario.NeutralPerson, encircler.BelongedFaction.Leader.Name, "DenounceDiplomaticRelation", "DenounceDiplomaticRelation.jpg", "DenounceDiplomaticRelation.wav", toEncircle.Name, true);

            if (encircler.Fund < 120000) return;
            encircler.Fund -= 120000;

            DiplomaticRelation rel = base.Scenario.DiplomaticRelations.GetDiplomaticRelation(base.Scenario, this.ID, toEncircle.ID);
            if (rel.Relation > -GlobalVariables.FriendlyDiplomacyThreshold)
            {
                rel.Relation -= 100;
            }
            else
            {
                rel.Relation -= 50;
            }
            //处理所有势力和被声讨方的关系
            foreach (DiplomaticRelation f in encircler.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(toEncircle.ID))
            {
                if (f.Relation < GlobalVariables.FriendlyDiplomacyThreshold / 2)
                {
                    f.Relation -= 20;
                }
            }
            //加入包围圈判定
            this.CheckEncircleDiplomatic(toEncircle);
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
                    if (i.Relation >= -GlobalVariables.FriendlyDiplomacyThreshold && base.Scenario.IsPlayer(opposite))
                    {
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
                    if (GameObject.Chance((int)((double)this.armyScale / opposite.ArmyScale * ((int)this.Leader.Ambition + 1) * 20))
                        && i.Relation < GlobalVariables.FriendlyDiplomacyThreshold)
                    {
                        i.Relation -= (7 + (int)Random(15)); //根据总兵力情况每月随机减少
                        i.Relation -= (Person.GetIdealOffset(this.Leader, opposite.Leader)) / 10;
                        relationBroken = true;
                        break;
                    }
                    //增加关系300以上，随机一个降低数值后主动解盟的情况
                    if (GameObject.Chance((int)(Person.GetIdealOffset(this.Leader, opposite.Leader) / 3)) && i.Relation >= 300)
                    {
                        i.Relation -= (7 + (int)Random(15));
                        i.Relation -= (Person.GetIdealOffset(this.Leader, opposite.Leader)) / 10;
                        relationBroken = true;
                        if (i.Relation < GlobalVariables.FriendlyDiplomacyThreshold)
                        {
                            //显示联盟破裂画面
                            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, TextMessageKind.BreakDiplomaticRelation, "BreakDiplomaticRelation", "BreakDiplomaticRelation.jpg", "BreakDiplomaticRelation.wav", opposite.Leader.Name, true);
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
                    this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.Leader.Name, TextMessageKind.ResetDiplomaticRelation, "ResetDiplomaticRelation", "ResetDiplomaticRelation.jpg", "ResetDiplomaticRelation.wav", minTroopFactionopposite.LeaderName, true);
                }
            }
        }

        public bool RoutewayPathAvail(Point start, Point end, bool hasEnd)
        {
            bool result = this.RoutewayPathBuilder.GetPath(start, end, hasEnd);
            return result;
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
            this.RefrehCreatePersonTimes();
            this.shizheshengguan();
        }

        private void RefrehCreatePersonTimes()
        {
            if (base.Scenario.Date.Day == 1)
            {
                this.ZhaoxianFailureCount = 0;
            }
        }

        internal bool BecomeEmperorLegallyAvail()  //可以禅位
        {
            if (this.IsAlien || !base.Scenario.youhuangdi())
            {
                return false;
            }
            if (this.guanjue != this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 2)  //不是王
            {
                return false;
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
                return false;
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
            if (this.Capital == null || this.Capital.Fund < 100000)
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
                            if (GameObject.Random((int)(((int)this.Leader.Ambition + 1) * 2 * (this.ArchitectureCount / (double)f.ArchitectureCount))) == 0)
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
                        if (GameObject.Random((int)((5 - (int)this.Leader.Ambition) * 100 / (double)this.ArchitectureCount)) == 0)
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
                else if (!this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfBecomeEmperor();
                }
            }

        }

        public void BecomeEmperorLegally()
        {
            this.guanjue++;
            base.Scenario.YearTable.addBecomeEmperorLegallyEntry(base.Scenario.Date, this.Scenario.Persons.GetGameObject(7000) as Person, this);
            this.Scenario.GameScreen.xianshishijiantupian(this.Scenario.Persons.GetGameObject(7000) as Person, this.LeaderName, TextMessageKind.BecomeEmperorLegally, "BecomeEmperorLegally", "shanwei.jpg", "",
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
            if (this.guanjue >= this.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 2)  //已经是王或者皇帝
            {
                return;
            }
            guanjuezhongleilei shengjiguanjue = new guanjuezhongleilei();
            shengjiguanjue = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue + 1);
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
                else if (!this.IsAlien && this.chengchigeshu() >= shengjiguanjue.xuyaochengchi)
                {
                    this.SelfAdvancement();
                }
            }



        }

        public void SelfBecomeEmperor()
        {
            this.guanjue++;
            base.Scenario.YearTable.addSelfBecomeEmperorEntry(base.Scenario.Date, this);
            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.LeaderName, TextMessageKind.BecomeEmperorIllegally, "Zili", "BecomeEmperor.jpg", "",
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
                person.Loyalty = (int)(person.Loyalty * loyaltyMultiplier);
            }
            this.Scenario.GameScreen.xianshishijiantupian(this.Leader, "", TextMessageKind.SelfBecomeInfluenceConsequence, "SelfBecomeEmperorInfluence", "", "", true);
        }


        private void Advancement()
        {
            this.guanjue++;

            guanjuezhongleilei gj = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue);
            if (base.Scenario.IsPlayer(this) || gj.ShowDialog)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.Scenario.Persons.GetGameObject(7000) as Person, this.LeaderName, TextMessageKind.RiseEmperorClass, "shengguan", "shengguan.jpg", "",
                   gj.Name, true);
                this.Scenario.GameScreen.xiejinxingjilu("shengguan", this.LeaderName,
                    gj.Name, this.Leader.Position);
            }

            base.Scenario.YearTable.addAdvanceGuanjueEntry(base.Scenario.Date, this, this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue));
            ExtensionInterface.call("Advancement", new Object[] { this.Scenario, this });
        }

        private void SelfAdvancement()
        {
            this.guanjue++;

            guanjuezhongleilei gj = this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue);
            if (base.Scenario.IsPlayer(this) || gj.ShowDialog)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.Leader, this.LeaderName, TextMessageKind.SelfRiseEmperorClass, "Zili", "", "",
                    this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, true);
                this.Scenario.GameScreen.xiejinxingjilu("Zili", this.LeaderName,
                    this.Scenario.GameCommonData.suoyouguanjuezhonglei.Getguanjuedezhonglei(this.guanjue).Name, this.Leader.Position);
            }
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
                if (this.IsAlien || !base.Scenario.youhuangdi())
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

        public int CityTotalSize
        {
            get 
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    if (architecture.Kind.ID != 2 || architecture.Kind.ID != 4)
                    {
                        num += architecture.JianzhuGuimo;
                    }
                }
                return num;
            }
        }

        public long Army
        {
            get
            {
                long num = 0;
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

        public int GetFacilityKindCount(int id)
        {
            int cnt = 0;
            foreach (Architecture a in this.Architectures)
            {
                cnt += a.GetFacilityKindCount(id);
            }
            return cnt;
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
                    if (relation.Relation >= GlobalVariables.FriendlyDiplomacyThreshold)
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
                    if (relation.Relation >= GlobalVariables.FriendlyDiplomacyThreshold)
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
                r += a.Feiziliebiao.Count;
            }
            return r;
        }

        public PersonList GetFeiziList()
        {
            PersonList result = new PersonList();
            foreach (Architecture a in this.Architectures)
            {
                foreach (Person p in a.Feiziliebiao)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public int meinvkongjian()
        {
            int r = 0;
            foreach (Architecture a in this.Architectures)
            {
                r += a.Meinvkongjian;
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

        private float InternalSurplusRateCache = -1;
        public float InternalSurplusRate
        {
            get
            {
                if (InternalSurplusRateCache >= 0)
                    return InternalSurplusRateCache;

                if ((!base.Scenario.IsPlayer(this) && !GlobalVariables.internalSurplusRateForAI) || (base.Scenario.IsPlayer(this) && !GlobalVariables.internalSurplusRateForPlayer))
                {
                    InternalSurplusRateCache = 1;
                    return 1;
                }

                float num = (Parameters.InternalSurplusFactor - this.Power) / (float) Parameters.InternalSurplusFactor;
                num = num * num;

                if (num < 0.2f)
                {
                    num = 0.2f;
                }

                InternalSurplusRateCache = num;
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

        public Person Prince
        {
            get
            {
                if (this.princeID == -1) return null;

                if (this.prince == null)
                {
                    this.prince = base.Scenario.Persons.GetGameObject(this.PrinceID) as Person;
                }

                //检查储君有效性
                if (this.prince != null && (this.prince == this.Leader || !this.prince.Alive || !this.prince.Available || this.prince.BelongedFaction != this 
                    || this.prince.BelongedFaction == null))
                {
                    this.Prince = null;
                }
                return this.prince;
            }
            set
            {
                this.prince = value;
                if (this.prince != null)
                {
                    this.PrinceID = this.prince.ID;
                }
                else
                {
                    this.PrinceID = -1;
                }
            }
        }

        public int PrinceID
        {
            get
            {
                return this.princeID;
            }
            set
            {
                this.princeID = value;
            }
        }

        public string PrinceName
        {
            get
            {
                return ((this.Prince != null) ? this.Prince.Name : "----");
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
                    if (relation.RelationFaction1 == null || relation.RelationFaction2 == null) continue;
                    if ((relation.Relation >= GlobalVariables.FriendlyDiplomacyThreshold) && (num < relation.Relation) &&
                        !relation.RelationFaction1.IsAlien && !relation.RelationFaction2.IsAlien)
                    {
                        num = relation.Relation;
                        diplomaticFaction = relation.GetDiplomaticFaction(base.ID);
                    }
                }
                return diplomaticFaction;
            }
        }

        public MilitaryList Militaries
        {
            get
            {
                MilitaryList list = new MilitaryList();
                /*
                foreach (Military military in base.Scenario.Militaries)
                {
                    if (military.BelongedArchitecture != null && military.BelongedArchitecture.BelongedFaction == this)
                    {
                        Militaries.Add(military);
                    }

                }*/
                foreach (Architecture a in this.Architectures)
                {
                    foreach (Military military in a.Militaries)
                    {
                        list.Add(military);
                    }
                }

                foreach (Military military in this.TransferingMilitaries)
                {
                    list.Add(military);
                }

                foreach (Troop troop in this.Troops)
                {
                    if (troop.Army != null)
                    {
                        if (troop.Army.ShelledMilitary == null)
                        {
                            list.Add(troop.Army);
                        }
                        else
                        {
                            list.Add(troop.Army.ShelledMilitary);
                        }
                    }
                }

                return list;

            }
        }


        public int MilitaryCount
        {
            get
            {
                return this.Militaries.Count ;
            }
            set
            {
                this.militarycount = value;
            }
        }

        public int TransferingMilitaryCount
        {
            get
            {
                return this.TransferingMilitaries.Count;
            }
            set
            {
                this.transferingmilitarycount = value;
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
            // 切记不要用this.Persons.Count，因为这样会把全势力人物一个一个加入PersonList，非常慢
            get
            {
                int result = 0;
                foreach (Architecture a in Architectures)
                {
                    result += a.Persons.Count;
                    result += a.MovingPersons.Count;
                }
                foreach (Troop t in Troops)
                {
                    result += t.PersonCount;
                }
                
                
                return result;
            }
        }

        public PersonList SelfOfficers //自势力野武将
        {
            get 
            {
                PersonList result = new PersonList();
                foreach (Person person in this.Persons)
                {
                    if (person.ID >= 25000)
                    {
                        result .Add (person);
                    }
                }
                return result;
            }
        }


        public int SelfOfficerCount //本势力野武将总数
        {
            get
            {
                return (this.SelfOfficers.Count);

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

        public int TroopCountExcludeTransport
        {
            get
            {
                int r = 0;
                foreach (Troop t in this.Troops)
                {
                    if (!t.IsTransport)
                    {
                        r++;
                    }
                }
                return r;
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
                this.isAlien = value;
            }
        }

        public int CityTotalSize
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.Architectures)
                {
                    if (architecture.Kind.ID != 2 || architecture.Kind.ID != 4)
                    {
                        num += architecture.JianzhuGuimo;
                    }
                }
                return num;
            }
        }

        public InformationList GetAllInformationList()
        {
            InformationList result = new InformationList();
            foreach (Information i in this.Informations)
            {
                result.Add(i);
            }
            foreach (Architecture a in this.Architectures)
            {
                foreach (Information i in a.Informations)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public bool HasInformation()
        {
            return this.GetAllInformationList().Count > 0;
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

        public float InfluenceKindValue(int id)
        {
            float result = 0;
            foreach (Influence i in base.Scenario.GameCommonData.AllInfluences.Influences.Values)
            {
                if (i.Kind.ID == id)
                {
                    foreach (ApplyingFaction j in i.appliedFaction)
                    {
                        if (j.faction == this)
                        {
                            result += i.Value;
                        }
                    }
                }
            }
            return result;
        }
    }
}

