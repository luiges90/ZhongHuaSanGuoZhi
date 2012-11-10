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
    using System.Data;
    using System.Data.OleDb;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    //using GameFreeText;

    public class GameScenario
    {
        //public GameFreeText.FreeText GameProgressCaution;

        private Dictionary<int, Architecture> AllArchitectures = new Dictionary<int, Architecture>();
        private Dictionary<int, Person> AllPersons = new Dictionary<int, Person>();
        public ArchitectureList Architectures = new ArchitectureList();
        public Faction CurrentFaction;
        public Faction CurrentPlayer;
        public GameDate Date = new GameDate();
        public DiplomaticRelationTable DiplomaticRelations = new DiplomaticRelationTable();
        public bool EnableLoadAndSave = true;
        public FacilityList Facilities = new FacilityList();
        public FactionListWithQueue Factions = new FactionListWithQueue();
        public PositionTable FireTable = new PositionTable();
        public CommonData GameCommonData = new CommonData();
        public Screen GameScreen;
        public TileAnimationGenerator GeneratorOfTileAnimation;
        public InformationList Informations = new InformationList();
        public LegionList Legions = new LegionList();
        public TileData[,] MapTileData;
        public MilitaryList Militaries = new MilitaryList();
        private Person neutralPerson;
        public bool NewInfluence;
        public NoFoodTable NoFoodDictionary = new NoFoodTable();
        public int[,] PenalizedMapData;
        public PersonList Persons = new PersonList();
        public FactionList PlayerFactions = new FactionList();
        public PersonList PreparedAvailablePersons = new PersonList();
        public bool Preparing = false;
        public RegionList Regions = new RegionList();
        public RoutewayList Routeways = new RoutewayList();
        public string ScenarioDescription;
        public Map ScenarioMap = new Map();
        public string ScenarioTitle;
        public SectionList Sections = new SectionList();
        public GameMessageList SpyMessages = new GameMessageList();
        public StateList States = new StateList();
        public int[] TerrainAdaptability;
        public bool Threading;
        public TreasureList Treasures = new TreasureList();
        public TroopEventList TroopEvents = new TroopEventList();
        public Dictionary<TroopEvent, TroopList> TroopEventsToApply = new Dictionary<TroopEvent, TroopList>();
        public TroopListWithQueue Troops = new TroopListWithQueue();
        public YearTable YearTable = new YearTable();
        public Dictionary<Event, Architecture> EventsToApply = new Dictionary<Event, Architecture>();
        public EventList AllEvents = new EventList();

        public event AfterLoadScenario OnAfterLoadScenario;

        public event AfterSaveScenario OnAfterSaveScenario;

        public event NewFactionAppear OnNewFactionAppear;

        public int DaySince { get; set; }

        public GameScenario(Screen screen)
        {
            this.GameScreen = screen;
            this.GeneratorOfTileAnimation = new TileAnimationGenerator(this);
        }

        public CaptiveList Captives
        {
            get
            {
                CaptiveList result = new CaptiveList();
                foreach (Person i in this.Persons)
                {
                    if (i.Status == PersonStatus.Captive)
                    {
                        if (i.BelongedCaptive == null)
                        {
                            throw new Exception("Every captive must bear a BelongedCaptive Object!");
                        }
                        result.Add(i.BelongedCaptive);
                    }
                }
                return result;
            }
        }

        public PersonList AvailablePersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in this.Persons)
                {
                    if (i.Status != PersonStatus.None && i.Alive && i.Available)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public void AddPositionAreaInfluence(Troop troop, Point position, AreaInfluenceKind kind, int offset, float rate)
        {
            if (!this.PositionOutOfRange(position))
            {
                Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
                this.MapTileData[position.X, position.Y].AddAreaInfluence(troop, kind, offset, rate, troopByPositionNoCheck);
            }
        }

        public void AddPositionContactingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddContactingTroop(troop);
            }
        }

        public void AddPositionOffencingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddOffencingTroop(troop);
            }
        }

        public void AddPositionStratagemingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddStratagemingTroop(troop);
            }
        }

        public void AddPositionViewingTroopNoCheck(Troop troop, Point position)
        {
            this.MapTileData[position.X, position.Y].AddViewingTroop(troop);
        }
        /*
        private void AddPreparedAvailablePersons()
        {
            foreach (Person person in this.PreparedAvailablePersons)
            {
                Architecture gameObject = this.Architectures.GetGameObject(person.AvailableLocation) as Architecture;
                person.Available = true;
                foreach (Treasure treasure in person.Treasures)
                {
                    treasure.Available = true;
                }
                if (person.Father > 0)
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Father)
                        {
                            if (p.Available && p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null&&p.BelongedCaptive==null )
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                this.GameScreen.xianshishijiantupian(p.BelongedFaction.Leader,(this.Persons.GetGameObject(person.Father) as Person).Name,"ChildJoin","","",person.Name ,false);
                                this.GameScreen.xianshishijiantupian(person, p.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "",  false);

                            }
                        }
                    }
                }
                else if (person.Mother > 0)
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Mother)
                        {
                            if (p.Available && p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null && p.BelongedCaptive == null)
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                this.GameScreen.xianshishijiantupian(p.BelongedFaction.Leader, (this.Persons.GetGameObject(person.Mother) as Person).Name, "ChildJoin", "", "", person.Name, false);
                                this.GameScreen.xianshishijiantupian(person, p.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "", false);

                            }
                        }
                    }
                }
                else if (person.Spouse > 0 )
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Spouse)
                        {
                            if (p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null && p.BelongedCaptive == null)
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                if (person.Sex) //女的
                                {
                                    this.GameScreen.xianshishijiantupian(person, (this.Persons.GetGameObject(person.Spouse) as Person).Name, "FemaleSpouseJoin", "", "", false);
                                }
                                else
                                {
                                    this.GameScreen.xianshishijiantupian(person, (this.Persons.GetGameObject(person.Spouse) as Person).Name, "MaleSpouseJoin", "", "", false);

                                }

                            }
                        }
                    }
                }
                else
                {
                    gameObject.AddNoFactionPerson(person);
                }
                this.AvailablePersons.Add(person);
            }
            this.PreparedAvailablePersons.Clear();
        }
        */

        private void AddPreparedAvailablePersons()
        {
            foreach (Person person in this.PreparedAvailablePersons)
            {
                person.Available = true;
                foreach (Treasure treasure in person.Treasures)
                {
                    treasure.Available = true;
                }

                Person joinToPerson = this.Persons.GetGameObject(person.Father) as Person;

                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive &&  joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.LocationArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    this.GameScreen.xianshishijiantupian(joinToPerson.BelongedFaction.Leader, joinToPerson.Name, "ChildJoin", "", "", person.Name, false);
                    this.GameScreen.xianshishijiantupian(person, person.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "", false);
                    this.AvailablePersons.Add(person);
                    continue;
                }

                joinToPerson = this.Persons.GetGameObject(person.Mother) as Person;
                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive && joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.LocationArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    this.GameScreen.xianshishijiantupian(joinToPerson.BelongedFaction.Leader, joinToPerson.Name, "ChildJoin", "", "", person.Name, false);
                    this.GameScreen.xianshishijiantupian(person, person.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "", false);
                    this.AvailablePersons.Add(person);
                    continue;
                }

                joinToPerson = this.Persons.GetGameObject(person.Spouse) as Person;
                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive && joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.LocationArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    if (person.Sex) //女的
                    {
                        this.GameScreen.xianshishijiantupian(person, joinToPerson.Name, "FemaleSpouseJoin", "", "", false);
                    }
                    else
                    {
                        this.GameScreen.xianshishijiantupian(person, joinToPerson.Name, "MaleSpouseJoin", "", "", false);

                    }
                    this.AvailablePersons.Add(person);
                    continue;
                }

                person.LocationArchitecture = this.Architectures.GetGameObject(person.AvailableLocation) as Architecture;
                person.Status = PersonStatus.NoFaction;
            }
            this.PreparedAvailablePersons.Clear();
        }

        public void haizichusheng(Person person, Person muqin, bool doAffect)
        {
            person.Available = true;
            foreach (Treasure treasure in person.Treasures)
            {
                treasure.Available = true;
            }

            person.LocationArchitecture = muqin.BelongedArchitecture;
            person.ChangeFaction(muqin.BelongedFaction);

            if (GlobalVariables.lockChildrenLoyalty)
            {
                person.Loyalty = 120;
            }
            if (doAffect)
            {
                person.muqinyingxiangnengli(muqin);
            }
            this.GameScreen.haizizhangdachengren(person);
        }




        public void ApplyFireTable()
        {
            foreach (Point point in this.FireTable.Positions.Values)
            {
                this.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.火焰, point, true);
            }
        }

        public void ApplyTroopEvents()
        {
            if (this.TroopEventsToApply.Count != 0)
            {
                foreach (TroopEvent event2 in this.TroopEvents)
                {
                    TroopList list = null;
                    if (this.TroopEventsToApply.TryGetValue(event2, out list))
                    {
                        foreach (Troop troop in list.GetList())
                        {
                            event2.ApplyEventEffects(troop);
                        }
                    }
                }
                this.TroopEventsToApply.Clear();
            }
        }

        public void ApplyEvents()
        {
            foreach (KeyValuePair<Event, Architecture> i in this.EventsToApply)
            {
                i.Key.DoApplyEvent(i.Value);
            }
            this.EventsToApply.Clear();
        }

        public void ChangeDiplomaticRelation(int faction1, int faction2, int offset)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(faction1, faction2);
                if (diplomaticRelation != null)
                {
                    diplomaticRelation.Relation += offset;
                }
            }
        }

        public void SetDiplomaticRelationIfHigher(int faction1, int faction2, int value)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(faction1, faction2);
                if (diplomaticRelation != null)
                {
                    if (diplomaticRelation.Relation > value)
                    {
                        diplomaticRelation.Relation = value;
                    }
                }
            }
        }

        private void CheckGameEnd()
        {
            FactionList noArchFaction = new FactionList();
            foreach (Faction f in this.Factions)
            {
                if (f.ArchitectureCount == 0)
                {
                    noArchFaction.Add(f);
                }
            }

            foreach (Faction f in noArchFaction)
            {
                this.Factions.Remove(f);
            }

            if (this.Factions.Count == 1)
            {
                ExtensionInterface.call("GameEnd", new Object[]{this});
                this.GameScreen.GameEndWithUnite(this.Factions[0] as Faction);
            }
        }

        public void Clear()
        {
            this.AllEvents.Clear();
            this.TroopEvents.Clear();
            this.Persons.Clear();
            this.AvailablePersons.Clear();
            this.PreparedAvailablePersons.Clear();
            this.Captives.Clear();
            this.Facilities.Clear();
            this.Militaries.Clear();
            this.Treasures.Clear();
            this.Informations.Clear();
            this.SpyMessages.Clear();
            this.Routeways.Clear();
            this.Troops.Clear();
            this.Legions.Clear();
            this.Architectures.Clear();
            this.Sections.Clear();
            this.Factions.Clear();
            this.Regions.Clear();
            this.States.Clear();
            this.ScenarioMap.Clear();
            this.PlayerFactions.Clear();
            this.FireTable.Clear();
            this.NoFoodDictionary.Clear();
            this.DiplomaticRelations.Clear();
            this.GeneratorOfTileAnimation.Clear();
            this.YearTable.Clear();
            this.CurrentFaction = null;
            this.CurrentPlayer = null;
        }

        public void ClearPenalizedMapDataByArea(GameArea gameArea)
        {
            foreach (Point point in gameArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.PenalizedMapData[point.X, point.Y] = 0;
                }
            }
        }

        public void ClearPenalizedMapDataByPosition(Point position)
        {
            this.PenalizedMapData[position.X, position.Y] = 0;
        }

        public void ClearPositionFire(Point position)
        {
            this.FireTable.RemovePosition(position);
            this.GeneratorOfTileAnimation.RemoveTileAnimation(TileAnimationKind.火焰, position, true);
        }

        private void CreateNewFaction(Person leader)
        {
            Faction newFaction = new Faction();
            newFaction.Scenario = this;
            newFaction.ID = this.Factions.GetFreeGameObjectID();
            this.Factions.AddFactionWithEvent(newFaction);
            foreach (Faction faction2 in this.Factions)
            {
                if (faction2 != newFaction)
                {
                    this.DiplomaticRelations.AddDiplomaticRelation(this, newFaction.ID, faction2.ID, 0);
                }
            }
            newFaction.Leader = leader;
            leader.Loyalty = 100;
            newFaction.Reputation = leader.Reputation;
            newFaction.Name = leader.Name;
            if (leader.PersonBiography != null)
            {
                foreach (MilitaryKind kind in leader.PersonBiography.MilitaryKinds.MilitaryKinds.Values)
                {
                    newFaction.BaseMilitaryKinds.AddMilitaryKind(kind);
                }
                newFaction.ColorIndex = leader.PersonBiography.FactionColor;
            }
            else
            {
                newFaction.BaseMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKindList().GetGameObject(0) as MilitaryKind);
                newFaction.BaseMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKindList().GetGameObject(1) as MilitaryKind);
                newFaction.BaseMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKindList().GetGameObject(2) as MilitaryKind);
                newFaction.BaseMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKindList().GetGameObject(29) as MilitaryKind);
                newFaction.BaseMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKindList().GetGameObject(30) as MilitaryKind);
                newFaction.ColorIndex = -1;
            }

            List<int> allUnusedColors = new List<int>();
            for (int i = 0; i < this.GameCommonData.AllColors.Count; ++i)
            {
                allUnusedColors.Add(i);
            }
            foreach (Faction f in this.Factions)
            {
                allUnusedColors.Remove(f.ColorIndex);
            }
            if (allUnusedColors.Count == 0)
            {
                newFaction.ColorIndex = GameObject.Random(this.GameCommonData.AllColors.Count);
            }
            else
            {
                if (!allUnusedColors.Contains(newFaction.ColorIndex)){
                    newFaction.ColorIndex = allUnusedColors[GameObject.Random(allUnusedColors.Count)];
                }
            }

            newFaction.FactionColor = this.GameCommonData.AllColors[newFaction.ColorIndex];

            Architecture newFactionCapital = leader.LocationArchitecture;
            Faction oldFaction = newFactionCapital.BelongedFaction;

            if (leader.BelongedFaction == null)
            {
                leader.Status = PersonStatus.Normal;
            }
            else
            {
                this.ChangeDiplomaticRelation(newFaction.ID, newFactionCapital.BelongedFaction.ID, -500);
            }
            leader.MoveToArchitecture(newFactionCapital);

            newFactionCapital.ResetFaction(newFaction);
            newFaction.Capital = newFactionCapital;
            newFaction.PrepareData();
            newFaction.AddArchitectureKnownData(newFactionCapital);
            newFaction.FirstSection.AddArchitecture(newFactionCapital);
            newFactionCapital.CheckIsFrontLine();
            if (oldFaction != null && !GameObject.Chance((int) oldFaction.Leader.PersonalLoyalty * 10))
            {
                oldFaction.Leader.HatedPersons.Add(leader.ID);
            }
            foreach (Person p in this.AvailablePersons)
            {
                if ((p.BelongedFaction == null || p.BelongedFaction == oldFaction) && !p.IsCaptive && p.Status != PersonStatus.Princess)
                {
                    if (p.Father == leader.ID || p.Mother == leader.ID || p.ID == leader.Father || p.ID == leader.Mother ||
                        (p.Father != -1 && p.Father == leader.Father) || (p.Mother != -1 && p.Mother == leader.Mother) ||
                        (p.Spouse != -1 && p.Spouse == leader.ID) || (leader.Spouse != -1 && p.ID == leader.Spouse) || (leader.Strain == p.Strain) ||
                        (p.Brother != -1 && p.Brother == leader.Brother) || (GameObject.Chance(100 - (Person.GetIdealOffset(leader, p)) * 20)))
                    {
                        if (p.BelongedFaction == null || (GameObject.Chance(100 - ((int)p.PersonalLoyalty) * 25) && GameObject.Chance(220 - p.Loyalty * 2)))
                        {
                            /*if (p.BelongedFaction != null)
                            {
                                if (p.LocationArchitecture != null)
                                {
                                    p.BelongedFaction.RemovePerson(p);
                                    p.LocationArchitecture.RemovePerson(p);
                                }
                            }
                            else
                            {
                                if (p.LocationArchitecture != null)
                                {
                                    p.LocationArchitecture.RemoveNoFactionPerson(p);
                                }
                            }*/
                            if (p.BelongedFaction != null)
                            {
                                p.ChangeFaction(newFaction);
                            }
                            if ((p.Spouse != -1 && p.Spouse == leader.ID) || (leader.Spouse != -1 && p.ID == leader.Spouse) ||
                                (p.Brother != -1 && p.Brother == leader.Brother))
                            {
                                p.Loyalty = 150;
                            } else if ((p.Father == leader.ID || p.Mother == leader.ID || p.ID == leader.Father || p.ID == leader.Mother ||
                                (p.Father != -1 && p.Father == leader.Father) || (p.Mother != -1 && p.Mother == leader.Mother)))
                            {
                                p.Loyalty = 120;
                            } else {
                                p.Loyalty = (int)p.PersonalLoyalty * 5 + 80;
                                if (p.Ideal == leader.Ideal)
                                {
                                    p.Loyalty += 10;
                                }
                            }
                            p.MoveToArchitecture(newFactionCapital);
                            //faction.AddPerson(p);
                        }
                    }
                }
            }
            this.YearTable.addNewFactionEntry(this.Date, oldFaction, newFaction, newFactionCapital);
            if (this.OnNewFactionAppear != null)
            {
                this.OnNewFactionAppear(newFaction);
            }
        }

        public void DayPassedEvent()
        {
            ExtensionInterface.call("DayEvent", new Object[] { this });

            //this.GameProgressCaution.Text = "开始";
            Parameters.DayEvent(this.Date.Year);

            //clearupRepeatedOfficers();

            this.Troops.FinalizeQueue();
            this.Factions.BuildQueue(false);
            this.Architectures.NoFactionDevelop();
            this.FireDayEvent();
            this.NoFoodPositionDayEvent();
            this.NewFaction();
            //this.GameProgressCaution.Text = "运行势力";
            foreach (Faction faction in this.Factions.GetRandomList())
            {
                faction.DayEvent();
            }
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.DayEvent();
            }
            foreach (Routeway routeway in this.Routeways.GetRandomList())
            {
                routeway.DayEvent();
            }
            foreach (Legion legion in this.Legions.GetRandomList())
            {
                legion.DayEvent();
                if (legion.Troops.Count == 0)
                {
                    legion.Disband();
                    this.Legions.Remove(legion);
                }
            }
            //this.GameProgressCaution.Text = "运行军队";
            foreach (Troop troop in this.Troops.GetRandomList())
            {
                if (troop.BelongedFaction == null)
                {
                    troop.DayEvent();
                }
            }

            this.detectCurrentPlayerBattleState(this.CurrentPlayer);




            //this.GameProgressCaution.Text = "运行人物";
            foreach (Person person in this.AvailablePersons.GetList())
            {
                person.PreDayEvent();
            }
            foreach (Person person in this.AvailablePersons.GetRandomList())
            {
                person.DayEvent();
            }
            this.AddPreparedAvailablePersons();
            foreach (SpyMessage message in this.SpyMessages.GetRandomList())
            {
                message.DayEvent();
            }
            foreach (Captive captive in this.Captives.GetRandomList())
            {
                captive.DayEvent();
            }
            this.CheckGameEnd();

            this.DaySince++;

            this.GameScreen.LoadScenarioInInitialization = false;
        }

        private void detectCurrentPlayerBattleState(Faction faction)
        {
            
            if (faction == null) return;
            //defend
            ZhandouZhuangtai originalBattleState = faction.BattleState;
            bool fangshou = false;
            int fightingArchitectureCount = 0;
            foreach (Architecture architecture in faction.Architectures)
            {

                if (!architecture.FrontLine)
                {
                    continue;
                }
                if (architecture.FindHostileTroopInView())
                {
                    fightingArchitectureCount++;

                    if (architecture.RecentlyAttacked <= 0)
                    {
                        architecture.JustAttacked = true;
                        architecture.BelongedFaction.StopToControl = true;
                        architecture.RecentlyAttacked = 10;

                        this.GameScreen.ArchitectureBeginRecentlyAttacked(architecture);  //提示玩家建筑视野范围内出现敌军。

                    }
                }

            }
            if (fightingArchitectureCount == 0)
            {
                fangshou = false; 
            }
            else
            {
                fangshou=true;
            }
            //attack
            bool jingong = false;

            foreach (Troop t in faction.Troops)
            {
                if (t.HasHostileArchitectureInView())         //||t.HasHostileTroopInView())
                {
                    jingong = true;
                    break;
                }
            }

            if (!jingong && !fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.和平;
            }
            else if (jingong && !fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.进攻;

            }
            else if (!jingong && fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.防守;

            }
            else
            {
                faction.BattleState = ZhandouZhuangtai.攻守兼备;
            }



            if (originalBattleState != faction.BattleState)
            {
                this.GameScreen.SwichMusic(this.Date.Season);
            }

        }

        public void DayStartingEvent()
        {
            this.Factions.SetControlling(false);
            foreach (Troop troop in this.Troops.GetList())
            {
                if (troop.BelongedFaction == null)
                {
                    troop.AI();
                }
            }
            this.Troops.BuildQueue();
            foreach (Architecture architecture in this.Architectures.GetList())
            {
                architecture.HireFinished = false;
                architecture.HasManualHire = false;
                architecture.TodayPersonArriveNote = false;

            }
        }

        public void FireDayEvent()
        {
            List<Point> list = new List<Point>();
            foreach (Point point in this.FireTable.Positions.Values)
            {
                if (GameObject.Chance(Parameters.FireStayProb))
                {
                    list.Add(point);
                }
            }
            foreach (Point point in list)
            {
                this.ClearPositionFire(point);
            }
            list.Clear();
            foreach (Point point in this.FireTable.Positions.Values)
            {
                list.Add(point);
            }
            foreach (Point point in list)
            {
                this.FireSpread(point);
            }
        }

        public void FireSpread(Point position)
        {
            GameArea area = GameArea.GetArea(position, 1, false);
            foreach (Point point in area.Area)
            {
                if ((point != position) && this.IsFireVaild(point, false, MilitaryType.步兵))
                {
                    if (this.PositionIsOnFire(point))
                    {
                        continue;
                    }
                    int chance = 0;
                    switch (this.GetTerrainKindByPosition(position))
                    {
                        case TerrainKind.平原:
                            chance = 3;
                            break;

                        case TerrainKind.草原:
                            chance = 4;
                            break;

                        case TerrainKind.森林:
                            chance = 10;
                            break;

                        case TerrainKind.山地:
                            chance = 6;
                            break;
                    }
                    if (GameObject.Chance((int) (chance * Parameters.FireSpreadProbMultiply)))
                    {
                        this.SetPositionOnFire(point);
                        Troop troopByPosition = this.GetTroopByPosition(point);
                        if (troopByPosition != null)
                        {
                            troopByPosition.BurntBySpreadFire();
                        }
                    }
                }
            }
        }

        public RoutewayList GetActiveRoutewayListByPosition(Point position)
        {
            RoutewayList list = new RoutewayList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return list;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (routeway.IsActive || routeway.IsPointActive(position))
                    {
                        list.Add(routeway);
                    }
                }
            }
            return list;
        }

        public Architecture GetArchitectureByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileArchitecture;
        }

        public Architecture GetArchitectureByPositionNoCheck(Point position)
        {
            return this.MapTileData[position.X, position.Y].TileArchitecture;
        }

        public GameArea GetAreaWithinDistance(Point centre, int distance, bool includingCentre)
        {
            GameArea area = new GameArea();
            for (int i = -distance; i <= distance; i++)
            {
                for (int j = -distance; j <= distance; j++)
                {
                    Point fromPosition = new Point(centre.X + i, centre.Y + j);
                    if ((includingCentre || !(fromPosition == centre)) && (this.GetDistance(fromPosition, centre) <= distance))
                    {
                        area.AddPoint(fromPosition);
                    }
                }
            }
            return area;
        }

        public Point GetClosestPoint(GameArea area, Point fromPosition)
        {
            double distance = 0.0;
            double maxValue = double.MaxValue;
            Point point = new Point();
            foreach (Point point2 in area.Area)
            {
                distance = this.GetDistance(fromPosition, point2);
                if (distance < maxValue)
                {
                    maxValue = distance;
                    point = point2;
                }
            }
            return point;
        }

        public void GetClosestPointsBetweenTwoAreas(GameArea area1, GameArea area2, out Point? out1, out Point? out2)
        {
            //out1 = 0;
            out1 = new Point(0, 0);
            //out2 = 0;
            out2 = new Point(0, 0);
            double distance = 0.0;
            double maxValue = double.MaxValue;
            foreach (Point point in area1.Area)
            {
                foreach (Point point2 in area2.Area)
                {
                    distance = this.GetDistance(point, point2);
                    if (distance < maxValue)
                    {
                        maxValue = distance;
                        out1 = new Point?(point);
                        out2 = new Point?(point2);
                    }
                }
            }
        }

        public Point? GetClosestPosition(GameArea area, List<Point> orientations)
        {
            Point? nullable = null;
            int num = 0x7fffffff;
            foreach (Point point in area.Area)
            {
                int num2 = 0;
                foreach (Point point2 in orientations)
                {
                    num2 += this.GetSimpleDistance(point, point2);
                }
                if (num2 < num)
                {
                    num = num2;
                    nullable = new Point?(point);
                }
            }
            return nullable;
        }

        public string GetCoordinateString(Point position)
        {
            return (position.X + "," + position.Y);
        }

        public int GetDiplomaticRelation(int faction1, int faction2)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(faction1, faction2);
                if (diplomaticRelation != null)
                {
                    return diplomaticRelation.Relation;
                }
            }
            return 0;
        }

        public double GetDistance(GameArea fromArea, GameArea toArea)
        {
            double distance = 0.0;
            double maxValue = double.MaxValue;
            foreach (Point point in fromArea.Area)
            {
                distance = this.GetDistance(this.GetClosestPoint(toArea, point), point);
                if (distance < maxValue)
                {
                    maxValue = distance;
                }
            }
            return maxValue;
        }

        public double GetDistance(Point fromPosition, GameArea toArea)
        {
            return this.GetDistance(fromPosition, this.GetClosestPoint(toArea, fromPosition));
        }

        public double GetDistance(Point fromPosition, Point toPosition)
        {
            if (fromPosition == toPosition)
            {
                return 0.0;
            }
            return Math.Sqrt(Math.Pow((double) Math.Abs((int) (toPosition.X - fromPosition.X)), 2.0) + Math.Pow((double) Math.Abs((int) (toPosition.Y - fromPosition.Y)), 2.0));
        }

        public Point? GetFarthestPosition(GameArea area, List<Point> orientations)
        {
            Point? nullable = null;
            int num = -2147483648;
            foreach (Point point in area.Area)
            {
                int num2 = 0;
                foreach (Point point2 in orientations)
                {
                    num2 += this.GetSimpleDistance(point, point2);
                }
                if (num2 > num)
                {
                    num = num2;
                    nullable = new Point?(point);
                }
            }
            return nullable;
        }

        public static string GetGameSaveFileSurveyText(string connectionString)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select * From GameSurvey", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = reader["PlayerInfo"].ToString() + "  ";
                object obj2 = str;
                str = string.Concat(new object[] { obj2, reader["Title"].ToString(), " ", (short) reader["GYear"], "年", (short) reader["GMonth"], "月", (short) reader["GDay"], "日  " });
                str = str + reader["SaveTime"].ToString();
                connection.Close();
            }
            catch
            {
                connection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public static string GetGameScenarioDescription(OleDbConnection DbConnection)
        {
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select Description From GameSurvey", DbConnection);
                DbConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = reader["Description"].ToString();
                DbConnection.Close();
            }
            catch
            {
                DbConnection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public static FactionList GetGameScenarioFactions(OleDbConnection DbConnection)
        {
            DbConnection.Open();
            OleDbDataReader reader = new OleDbCommand("Select * From Faction", DbConnection).ExecuteReader();
            FactionList list = new FactionList();
            while (reader.Read())
            {
                Faction t = new Faction();
                t.ID = (short) reader["ID"];
                t.LeaderID = (short) reader["LeaderID"];
                t.Name = reader["FName"].ToString();
                list.Add(t);
            }
            DbConnection.Close();
            return list;
        }

        public static string GetGameScenarioSurveyText(OleDbConnection DbConnection)
        {
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select * From GameSurvey", DbConnection);
                DbConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = string.Concat(new object[] { reader["Title"].ToString(), " ", (short) reader["GYear"], "年", (short) reader["GMonth"], "月", (short) reader["GDay"], "日  " });
                DbConnection.Close();
            }
            catch
            {
                DbConnection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public ArchitectureList GetHighViewingArchitecturesByPosition(Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].HighViewingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].HighViewingArchitectures)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public string GetPlayerInfo()
        {
            if (this.CurrentPlayer != null)
            {
                if (this.PlayerFactions.Count > 1)
                {
                    return (this.CurrentPlayer.Name + " 等");
                }
                if (this.PlayerFactions.Count == 1)
                {
                    return this.CurrentPlayer.Name;
                }
                return "电脑";
            }
            return "电脑";
        }

        public Texture2D GetPortrait(int id)
        {
            return this.GameScreen.GetPortrait(id);
        }

        public int GetPositionHostileOffencingDiscredit(Troop troop, Point position)
        {
            return this.MapTileData[position.X, position.Y].GetPositionHostileOffencingDiscredit(troop);
        }

        public int GetPositionMapCost(Faction faction, Point position)
        {
            Architecture architectureByPositionNoCheck = this.GetArchitectureByPositionNoCheck(position);
            if (architectureByPositionNoCheck != null)
            {
                if ((architectureByPositionNoCheck.Endurance > 0) && (architectureByPositionNoCheck.BelongedFaction != faction))
                {
                    return 0xdac;
                }
                return 5;
            }
            Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
            if (troopByPositionNoCheck != null)
            {
                if (!((faction != null) && faction.IsFriendly(troopByPositionNoCheck.BelongedFaction)))
                {
                    return 0xdac;
                }
                return 0;
            }
            if (this.PositionIsOnFire(position))
            {
                return 10;
            }
            return 0;
        }

        public Point GetProperDestination(Point from, Point to)
        {
            double distance = this.GetDistance(from, to);
            if (distance > 15.0)
            {
                return new Point(from.X + ((int) (((double) ((to.X - from.X) * 15)) / distance)), from.Y + ((int) (((double) ((to.Y - from.Y) * 15)) / distance)));
            }
            return to;
        }

        public int GetReturnDays(Point destination, GameArea fromArea)
        {
            int num = (int) Math.Ceiling((double) (this.GetDistance(destination, this.GetClosestPoint(fromArea, destination)) / 10.0));
            num *= 2;
            if (num == 0)
            {
                num = 1;
            }
            return num;
        }

        public ArchitectureList GetRoutewayArchitecturesByPosition(Routeway routeway, Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                foreach (Architecture architecture in routeway.BelongedFaction.Architectures)
                {
                    if ((architecture != routeway.StartArchitecture) && architecture.GetRoutewayStartArea().HasPoint(position))
                    {
                        list.Add(architecture);
                    }
                }
            }
            return list;
        }

        public Routeway GetRoutewayByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            if (this.MapTileData[position.X, position.Y].TileRouteways == null)
            {
                return null;
            }
            if (this.MapTileData[position.X, position.Y].TileRouteways.Count == 0)
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileRouteways[0];
        }

        public Routeway GetRoutewayByPositionAndFaction(Point position, Faction faction)
        {
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return null;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (((routeway.BelongedFaction == faction) && (routeway.StartArchitecture != null)) && ((((routeway.DestinationArchitecture == null) || !routeway.StartArchitecture.BelongedSection.AIDetail.AutoRun) || routeway.Building) || (routeway.LastActivePointIndex >= 0)))
                    {
                        return routeway;
                    }
                }
            }
            return null;
        }

        public List<Routeway> GetRoutewaysByPositionAndFaction(Point position, Faction faction)
        {
            List<Routeway> list = new List<Routeway>();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return list;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (routeway.BelongedFaction == faction)
                    {
                        list.Add(routeway);
                    }
                }
            }
            return list;
        }

        public int GetSimpleDistance(Point from, Point to)
        {
            return (Math.Abs((int) (from.X - to.X)) + Math.Abs((int) (from.Y - to.Y)));
        }

        public int GetSingleWayDays(Point destination, GameArea fromArea)
        {
            int num = (int) Math.Ceiling((double) (this.GetDistance(destination, this.GetClosestPoint(fromArea, destination)) / 10.0));
            if (num == 0)
            {
                num = 1;
            }
            return num;
        }

        public Texture2D GetSmallPortrait(int id)
        {
            return this.GameScreen.GetSmallPortrait(id);
        }

        public ArchitectureList GetSupplyArchitecturesByPositionAndFaction(Point position, Faction faction)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].SupplyingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].SupplyingArchitectures)
                {
                    //if (faction.IsFriendly(architecture.BelongedFaction))
                    if (faction == architecture.BelongedFaction)
                    {
                        list.Add(architecture);
                    }
                }
            }
            return list;
        }

        public List<RoutePoint> GetSupplyRoutePointsByPositionAndFaction(Point position, Faction faction)
        {
            List<RoutePoint> list = new List<RoutePoint>();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].SupplyingRoutePoints == null)
                {
                    return list;
                }
                foreach (RoutePoint point in this.MapTileData[position.X, position.Y].SupplyingRoutePoints)
                {
                    if (point.BelongedRouteway.IsSupporting(faction))
                    {
                        list.Add(point);
                    }
                }
            }
            return list;
        }

        public TerrainDetail GetTerrainDetailByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]);
        }

        public TerrainDetail GetTerrainDetailByPositionNoCheck(Point position)
        {
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]);
        }

        public TerrainKind GetTerrainKindByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return TerrainKind.无;
            }
            return (TerrainKind) this.ScenarioMap.MapData[position.X, position.Y];
        }

        public TerrainKind GetTerrainKindByPositionNoCheck(Point position)
        {
            return (TerrainKind) this.ScenarioMap.MapData[position.X, position.Y];
        }

        public string GetTerrainNameByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return "----";
            }
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]).Name;
        }

        public int GetTranferFundDays(Architecture from, Architecture to)
        {
            return (int) Math.Ceiling((double) (this.GetDistance(from.ArchitectureArea, to.ArchitectureArea) / 5.0));
        }

        public Troop GetTroopByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileTroop;
        }

        public Troop GetTroopByPositionNoCheck(Point position)
        {
            return this.MapTileData[position.X, position.Y].TileTroop;
        }

        public ArchitectureList GetViewingArchitecturesByPosition(Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].ViewingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].ViewingArchitectures)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public int GetWaterPositionMapCost(MilitaryType militaryType, Point position)
        {
            return 0;
            if (this.ScenarioMap.MapData[position.X, position.Y] == 6)
            {
                if (this.GetArchitectureByPositionNoCheck(position) != null)
                {
                    return 0;
                }
                if (militaryType == MilitaryType.水军)
                {
                    return 0;
                }
                int num = 0;
                Point point = new Point(position.X - 1, position.Y);
                if (!(this.PositionOutOfRange(point) || (this.ScenarioMap.MapData[point.X, point.Y] != 6)))
                {
                    num++;
                }
                Point point2 = new Point(position.X, position.Y - 1);
                if (!(this.PositionOutOfRange(point2) || (this.ScenarioMap.MapData[point2.X, point2.Y] != 6)))
                {
                    num++;
                }
                Point point3 = new Point(position.X + 1, position.Y);
                if (!(this.PositionOutOfRange(point3) || (this.ScenarioMap.MapData[point3.X, point3.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return 0xdac;
                }
                Point point4 = new Point(position.X, position.Y + 1);
                if (!(this.PositionOutOfRange(point4) || (this.ScenarioMap.MapData[point4.X, point4.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return 0xdac;
                }
            }
            return 0;
        }

        private bool HasSameIdealFaction(Person person)
        {
            if ((person.BelongedFaction != null) && (person.BelongedFaction.Leader == person))
            {
                return true;
            }
            foreach (Faction faction in this.Factions)
            {
                if ((faction.Leader != null) && (faction.Leader.Ideal == person.Ideal))
                {
                    return true;
                }
            }
            return false;
        }

        public int HostileContactingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileContactingTroopsCount(faction);
        }

        public int HostileOffencingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileOffencingTroopsCount(faction);
        }

        public int HostileViewingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileViewingTroopsCount(faction);
        }

        public void InitialGameData()
        {
            this.InitializeSectionData();
            this.InitializeRoutewayData();
            this.InitializeArchitectureData();
            this.InitializeTroopData();
            this.InitializeCaptiveData();
            this.InitializePersonData();
            this.InitializeSpyMessageData();
            /*
            this.GameProgressCaution = new GameFreeText.FreeText(this.GameScreen.spriteBatch.GraphicsDevice,new System.Drawing.Font("宋体", 16f), new Color(1f, 1f, 1f));
            this.GameProgressCaution.Text = "——";
            this.GameProgressCaution.Align=TextAlign.Middle;
            */


        }

        private void InitializeArchitectureData()
        {
            foreach (Architecture architecture in this.Architectures)
            {
                this.SetMapTileArchitecture(architecture);
                if (architecture.PlanArchitectureID >= 0)
                {
                    architecture.PlanArchitecture = this.Architectures.GetGameObject(architecture.PlanArchitectureID) as Architecture;
                }
                if (architecture.TransferFundArchitectureID >= 0)
                {
                    architecture.TransferFundArchitecture = this.Architectures.GetGameObject(architecture.TransferFundArchitectureID) as Architecture;
                }
                if (architecture.TransferFoodArchitectureID >= 0)
                {
                    architecture.TransferFoodArchitecture = this.Architectures.GetGameObject(architecture.TransferFoodArchitectureID) as Architecture;
                }
                if (architecture.DefensiveLegionID >= 0)
                {
                    architecture.DefensiveLegion = this.Legions.GetGameObject(architecture.DefensiveLegionID) as Legion;
                }
                if (architecture.RobberTroopID >= 0)
                {
                    architecture.RobberTroop = this.Troops.GetGameObject(architecture.RobberTroopID) as Troop;
                }
            }

            bool redoLinks = false;
            foreach (Architecture architecture2 in this.Architectures)
            {
                architecture2.LoadAILandLinksFromString(this.Architectures, architecture2.AILandLinksString);
                architecture2.LoadAIWaterLinksFromString(this.Architectures, architecture2.AIWaterLinksString);
            }
            foreach (Architecture architecture2 in this.Architectures)
            {
                if (architecture2.AILandLinks.Count == 0 && architecture2.AIWaterLinks.Count == 0)
                {
                    redoLinks = true;
                    break;
                }
            }
            if (redoLinks)
            {
                foreach (Architecture architecture2 in this.Architectures)
                {
                    architecture2.AILandLinks.Clear();
                    architecture2.AIWaterLinks.Clear();
                }
                foreach (Architecture architecture2 in this.Architectures)
                {
                    architecture2.FindLinks(this.Architectures);
                }
            }

            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.BelongedFaction != null)
                {
                    architecture.CheckIsFrontLine();
                }
                architecture.GenerateAllAILinkNodes(3);
            }
        }

        private void InitializeCaptiveData()
        {
            foreach (Captive captive in this.Captives)
            {
                if (captive.CaptiveFactionID >= 0)
                {
                    captive.CaptiveFaction = this.Factions.GetGameObject(captive.CaptiveFactionID) as Faction;
                }
                if (captive.RansomArchitectureID >= 0)
                {
                    captive.RansomArchitecture = this.Architectures.GetGameObject(captive.RansomArchitectureID) as Architecture;
                }
            }
        }

        private void InitializeFactionData()
        {
            foreach (Faction faction in this.Factions)
            {
                faction.PrepareData();
            }
        }

        private void InitializeMapData()
        {
            this.MapTileData = new TileData[this.ScenarioMap.MapDimensions.X, this.ScenarioMap.MapDimensions.Y];
            this.PenalizedMapData = new int[this.ScenarioMap.MapDimensions.X, this.ScenarioMap.MapDimensions.Y];
        }

        private void InitializeMilitaryData()
        {
            foreach (Military military in this.Militaries)
            {
                if (military.ShelledMilitaryID >= 0)
                {
                    military.SetShelledMilitary(this.Militaries.GetGameObject(military.ShelledMilitaryID) as Military);
                }
            }
        }

        private void InitializePersonData()
        {
            foreach (Person person in this.Persons)
            {
                if (person.ConvincingPersonID >= 0)
                {
                    person.ConvincingPerson = this.Persons.GetGameObject(person.ConvincingPersonID) as Person;
                }
            }
        }

        private void InitializeRoutewayData()
        {
            foreach (Routeway routeway in this.Routeways)
            {
                routeway.RefreshRoutewayPointsData();
            }
        }

        public void InitializeScenarioPlayerFactions(List<int> factionIDs)
        {
            this.PlayerFactions.LoadFromString(this.Factions, StaticMethods.SaveToString(factionIDs));
        }

        private void InitializeSectionData()
        {
            foreach (Section section in this.Sections)
            {
                if (section.OrientationFactionID >= 0)
                {
                    section.OrientationFaction = this.Factions.GetGameObject(section.OrientationFactionID) as Faction;
                }
                if (section.OrientationSectionID >= 0)
                {
                    section.OrientationSection = this.Sections.GetGameObject(section.OrientationSectionID) as Section;
                }
                if (section.OrientationStateID >= 0)
                {
                    section.OrientationState = this.States.GetGameObject(section.OrientationStateID) as State;
                }
            }
        }

        private void InitializeSpyMessageData()
        {
            foreach (SpyMessage message in this.SpyMessages)
            {
                if (message.MessageFactionID >= 0)
                {
                    message.MessageFaction = this.Factions.GetGameObject(message.MessageFactionID) as Faction;
                }
                if (message.MessageArchitectureID >= 0)
                {
                    message.MessageArchitecture = this.Architectures.GetGameObject(message.MessageArchitectureID) as Architecture;
                }
            }
        }

        private void InitializeTroopData()
        {
            TroopList toRemove = new TroopList();
            foreach (Troop troop in this.Troops)
            {
                if (troop.Leader == null)
                {
                    toRemove.Add(troop);
                }
                else if (troop.Persons.Count == 0)
                {
                    troop.Leader.LocationTroop = troop;
                }
            }
            foreach (Troop troop in toRemove)
            {
                if (troop.BelongedFaction != null)
                {
                    troop.BelongedFaction.RemoveTroop(troop);
                }
                this.Troops.Remove(troop);
            }

            foreach (Troop troop in this.Troops)
            {
                troop.Initialize();
            }
            foreach (TroopEvent event2 in this.TroopEvents)
            {
                if (event2.AfterEventHappened >= 0)
                {
                    event2.AfterHappenedEvent = this.TroopEvents.GetGameObject(event2.AfterEventHappened) as TroopEvent;
                }
            }
        }

        public bool IsCurrentPlayer(Faction faction)
        {
            return (this.CurrentPlayer == faction);
        }

        private bool IsFather(PersonList list, Person p, Person subp)
        {
            for (Person person = list.GetGameObject(p.Father) as Person; person != null; person = list.GetGameObject(person.Father) as Person)
            {
                if (person.Father == subp.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFireVaild(Point position, bool typevalid, MilitaryType type)
        {
            if (this.GetArchitectureByPosition(position) != null)
            {
                return false;
            }
            TerrainKind terrainKindByPosition = this.GetTerrainKindByPosition(position);
            return (((typevalid && (type == MilitaryType.水军)) && (terrainKindByPosition == TerrainKind.水域)) || ((((terrainKindByPosition == TerrainKind.平原) || (terrainKindByPosition == TerrainKind.草原)) || (terrainKindByPosition == TerrainKind.森林)) || (terrainKindByPosition == TerrainKind.山地)));
        }

        public bool IsLastPlayer(Faction faction)
        {
            if (faction == null)
            {
                return false;
            }
            foreach (Faction faction2 in this.PlayerFactions)
            {
                if ((faction2 != faction) && !faction2.Passed)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPlayer(Faction faction)
        {
            return ((faction != null) && (this.PlayerFactions.GetGameObject(faction.ID) != null));
        }

        public bool IsPlayerControlling()
        {
            return (((this.CurrentPlayer != null) && (this.CurrentFaction == this.CurrentPlayer)) && this.CurrentPlayer.Controlling);
        }

        public bool IsPositionDisplayable(Point position)
        {
            return (this.GameScreen.TileInScreen(position) && ((GlobalVariables.SkyEye || (this.CurrentPlayer == null)) || this.CurrentPlayer.IsPositionKnown(position)));
        }

        public bool IsPositionEmpty(Point position)
        {
            if (this.PositionIsArchitecture(position))
            {
                return false;
            }
            if (this.PositionIsTroop(position))
            {
                return false;
            }
            return true;
        }

        public bool IsPositionMovable(Point position, Faction faction)
        {
            if (this.PositionIsTroop(position))
            {
                return false;
            }
            Architecture architectureByPosition = this.GetArchitectureByPosition(position);
            return ((architectureByPosition == null) || (architectureByPosition.BelongedFaction == faction));
        }

        public bool IsTheBottomTroop(Troop troop)
        {
            return (this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop == troop);
        }

        public bool IsTroopViewingPosition(Troop troop, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return false;
            }
            return this.MapTileData[position.X, position.Y].IsTroopViewing(troop);
        }

        public bool IsWaterPositionRoutewayable(Point position)
        {
            if (this.ScenarioMap.MapData[position.X, position.Y] == 6)
            {
                int num = 0;
                Point point = new Point(position.X - 1, position.Y);
                if (!(this.PositionOutOfRange(point) || (this.ScenarioMap.MapData[point.X, point.Y] != 6)))
                {
                    num++;
                }
                Point point2 = new Point(position.X, position.Y - 1);
                if (!(this.PositionOutOfRange(point2) || (this.ScenarioMap.MapData[point2.X, point2.Y] != 6)))
                {
                    num++;
                }
                Point point3 = new Point(position.X + 1, position.Y);
                if (!(this.PositionOutOfRange(point3) || (this.ScenarioMap.MapData[point3.X, point3.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return false;
                }
                Point point4 = new Point(position.X, position.Y + 1);
                if (!(this.PositionOutOfRange(point4) || (this.ScenarioMap.MapData[point4.X, point4.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return false;
                }
            }
            return true;
        }

        public bool LoadAndSaveAvail()
        {
            return (this.IsPlayerControlling() && this.EnableLoadAndSave);
        }

        public bool isInCaptiveList(int personId)
        {
            foreach (Captive i in this.Captives)
            {
                if (i.CaptivePerson.ID == personId)
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadGameDataFromDataBase(OleDbConnection DbConnection)  //读剧本和读存档都调用了此函数
        {
            OleDbCommand command = new OleDbCommand("Select * From Map", DbConnection);
            ////////////////////////////////////////////////////////////////////////////////////////////
            DbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            this.ScenarioMap.MapName = reader["FileName"].ToString();
            this.ScenarioMap.TileWidth = (short)reader["TileWidth"];
            try
            {
                this.ScenarioMap.NumberOfTiles = (short)reader["kuaishu"];
                this.ScenarioMap.NumberOfSquaresInEachTile = (short)reader["meikuaidexiaokuaishu"];
                this.ScenarioMap.UseSimpleArchImages = (bool)reader["useSimpleArchImages"];
            }
            catch
            {
                this.ScenarioMap.NumberOfTiles = 20;
                this.ScenarioMap.NumberOfSquaresInEachTile = 10;
                this.ScenarioMap.UseSimpleArchImages = false;
            }
            this.ScenarioMap.LoadMapData(reader["MapData"].ToString(), (short)reader["DimensionX"], (short)reader["DimensionY"]);
            DbConnection.Close();
            ///////////////////////////////////////////////////////////////////////////////////////////
            DbConnection.Open();
            reader = new OleDbCommand("Select * From State", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                State t = new State();
                t.ID = (short)reader["ID"];
                t.Name = reader["Name"].ToString();
                t.ContactStatesString = reader["ContactStates"].ToString();
                t.StateAdminID = (short)reader["StateAdmin"];
                this.States.Add(t);
            }
            DbConnection.Close();
            foreach (State state in this.States)
            {
                state.LoadContactStatesFromString(this.States, state.ContactStatesString);
            }
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Region", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Region region = new Region();
                region.ID = (short)reader["ID"];
                region.Name = reader["Name"].ToString();
                region.LoadStatesFromString(this.States, reader["States"].ToString());
                region.RegionCoreID = (short)reader["RegionCore"];
                this.Regions.Add(region);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Person", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Person person = new Person();
                person.Scenario = this;
                person.ID = (short)reader["ID"];
                person.PersonBiography = this.GameCommonData.AllBiographies.GetBiography(person.ID);
                person.PersonTextMessage = this.GameCommonData.AllTextMessages.GetTextMessage(person.ID);
                person.Available = (bool)reader["Available"];
                person.Alive = (bool)reader["Alive"];
                person.SurName = reader["SurName"].ToString();
                person.GivenName = reader["GivenName"].ToString();
                person.CalledName = reader["CalledName"].ToString();
                person.Sex = (bool)reader["Sex"];
                person.PictureIndex = (short)reader["Pic"];
                person.Ideal = (short)reader["Ideal"];
                person.IdealTendency = this.GameCommonData.AllIdealTendencyKinds.GetGameObject((short)reader["IdealTendency"]) as IdealTendencyKind;
                person.LeaderPossibility = (bool)reader["LeaderPossibility"];
                person.Character = this.GameCommonData.AllCharacterKinds[(short)reader["PCharacter"]];
                person.YearAvailable = (short)reader["YearAvailable"];
                person.YearBorn = (short)reader["YearBorn"];
                person.YearDead = (short)reader["YearDead"];
                person.DeadReason = (PersonDeadReason)((short)reader["DeadReason"]);
                person.BaseStrength = (short)reader["Strength"];
                person.BaseCommand = (short)reader["Command"];
                person.BaseIntelligence = (short)reader["Intelligence"];
                person.BasePolitics = (short)reader["Politics"];
                person.BaseGlamour = (short)reader["Glamour"];
                person.Reputation = (int)reader["Reputation"];
                person.StrengthExperience = (int)reader["StrengthExperience"];
                person.CommandExperience = (int)reader["CommandExperience"];
                person.IntelligenceExperience = (int)reader["IntelligenceExperience"];
                person.PoliticsExperience = (int)reader["PoliticsExperience"];
                person.GlamourExperience = (int)reader["GlamourExperience"];
                person.InternalExperience = (int)reader["InternalExperience"];
                person.TacticsExperience = (int)reader["TacticsExperience"];
                person.BubingExperience = (int)reader["BubingExperience"];
                person.NubingExperience = (int)reader["NubingExperience"];
                person.QibingExperience = (int)reader["QibingExperience"];
                person.ShuijunExperience = (int)reader["ShuijunExperience"];
                person.QixieExperience = (int)reader["QixieExperience"];
                person.StratagemExperience = (int)reader["StratagemExperience"];
                person.RoutCount = (int)reader["RoutCount"];
                person.RoutedCount = (int)reader["RoutedCount"];
                person.Braveness = (short)reader["Braveness"];
                person.Calmness = (short)reader["Calmness"];
                person.Loyalty = (short)reader["Loyalty"];
                person.BornRegion = (PersonBornRegion)((short)reader["BornRegion"]);
                person.AvailableLocation = (short)reader["AvailableLocation"];
                person.Strain = (short)reader["Strain"];
                person.Father = (short)reader["Father"];
                person.Mother = (short)reader["Mother"];
                person.Spouse = (short)reader["Spouse"];
                person.Brother = (short)reader["Brother"];
                person.Generation = (short)reader["Generation"];
                person.PersonalLoyalty = ((short)reader["PersonalLoyalty"]);
                person.Ambition = ((short)reader["Ambition"]);
                person.Qualification = (PersonQualification)((short)reader["Qualification"]);
                person.ValuationOnGovernment = (PersonValuationOnGovernment)((short)reader["ValuationOnGovernment"]);
                person.StrategyTendency = (PersonStrategyTendency)((short)reader["StrategyTendency"]);
                person.OldFactionID = (short)reader["OldFactionID"];
                person.ProhibitedFactionID = (short)reader["ProhibitedFactionID"];
                person.RewardFinished = (bool)reader["RewardFinished"];
                person.WorkKind = (ArchitectureWorkKind)((short)reader["WorkKind"]);
                person.OldWorkKind = (ArchitectureWorkKind)((short)reader["OldWorkKind"]);
                person.RecruitmentMilitary = null;
                person.ArrivingDays = (short)reader["ArrivingDays"];
                person.TaskDays = (short)reader["TaskDays"];
                person.OutsideTask = (OutsideTaskKind)((short)reader["OutsideTask"]);
                person.OutsideDestination = StaticMethods.LoadFromString(reader["OutsideDestination"].ToString());
                person.ConvincingPersonID = (short)reader["ConvincingPerson"];
                person.InformationKindID = (short)reader["InformationKind"];
                StaticMethods.LoadFromString(person.ClosePersons, reader["ClosePersons"].ToString());
                StaticMethods.LoadFromString(person.HatedPersons, reader["HatedPersons"].ToString());
                person.Skills.LoadFromString(this.GameCommonData.AllSkills, reader["Skills"].ToString());
                person.PersonalTitle = this.GameCommonData.AllTitles.GetTitle((short)reader["PersonalTitle"]);
                person.CombatTitle = this.GameCommonData.AllTitles.GetTitle((short)reader["CombatTitle"]);
                person.StudyingTitle = this.GameCommonData.AllTitles.GetTitle((short)reader["StudyingTitle"]);
                try
                {
                    person.huaiyun = (bool)reader["huaiyun"];
                    person.faxianhuaiyun = (bool)reader["faxianhuaiyun"];
                    person.huaiyuntianshu = (short)reader["huaiyuntianshu"];
                }
                catch
                {
                    person.huaiyun = false;
                    person.faxianhuaiyun = false;
                    person.huaiyuntianshu = -1;

                }

                try
                {
                    person.suoshurenwu = (short)reader["suoshurenwu"];
                }
                catch
                {


                }

                try
                {
                    person.Stunts.LoadFromString(this.GameCommonData.AllStunts, reader["Stunts"].ToString());
                    person.StudyingStunt = this.GameCommonData.AllStunts.GetStunt((short)reader["StudyingStunt"]);
                }
                catch
                {
                }

                try
                {
                    person.waitForFeiziId = (int)reader["WaitForFeizi"];
                    person.WaitForFeiZiPeriod = (int)reader["WaitForFeiziPeriod"];
                    person.preferredTroopPersonsString = reader["PreferredTroopPersons"].ToString();
                }
                catch 
                {
                    person.waitForFeiziId = -1;
                    person.WaitForFeiZiPeriod = 0;
                    person.preferredTroopPersonsString = "";
                }

                try
                {
                    person.YearJoin = (short)reader["YearJoin"];
                    person.TroopDamageDealt = (int)reader["TroopDamageDealt"];
                    person.TroopBeDamageDealt = (int)reader["TroopBeDamageDealt"];
                    person.ArchitectureDamageDealt = (int)reader["ArchitectureDamageDealt"];
                    person.RebelCount = (short)reader["RebelCount"];
                    person.ExecuteCount = (short)reader["ExecuteCount"];
                    person.FleeCount = (short)reader["FleeCount"];
                    person.HeldCaptiveCount = (short)reader["HeldCaptiveCount"];
                    person.CaptiveCount = (short)reader["CaptiveCount"];
                    person.StratagemSuccessCount = (int)reader["StratagemSuccessCount"];
                    person.StratagemFailCount = (int)reader["StratagemFailCount"];
                }
                catch
                {
                    // all zeroes.
                }

                this.Persons.AddPersonWithEvent(person);  //所有武将，并加载武将事件
                this.AllPersons.Add(person.ID, person);   //武将字典
                if (person.Available && person.Alive)
                {
                    this.AvailablePersons.Add(person);  //已出场武将
                }
            }
            DbConnection.Close();
            foreach (Person p in this.Persons)
            {
                p.WaitForFeiZi = this.Persons.GetGameObject(p.waitForFeiziId) as Person;
                p.preferredTroopPersons.LoadFromString(this.Persons, p.preferredTroopPersonsString);
            }
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Captive", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Captive captive = new Captive();
                captive.Scenario = this;
                captive.ID = (short)reader["ID"];
                captive.CaptivePerson = this.Persons.GetGameObject((short)reader["CaptivePerson"]) as Person;
                captive.CaptivePerson.BelongedCaptive = captive;
                captive.CaptiveFactionID = (short)reader["CaptiveFaction"];
                captive.RansomArchitectureID = (short)reader["RansomArchitecture"];
                captive.RansomFund = (int)reader["RansomFund"];
                captive.RansomArriveDays = (int)reader["RansomArriveDays"];
                captive.CaptivePerson.Status = PersonStatus.Captive;
                if (!isInCaptiveList(captive.CaptivePerson.ID))
                {
                    this.Captives.AddCaptiveWithEvent(captive);
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Military", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Military military = new Military();
                military.Scenario = this;
                military.ID = (short)reader["ID"];
                military.Name = reader["Name"].ToString();
                military.KindID = (short)reader["KindID"];
                military.Quantity = (int)reader["Quantity"];
                military.Morale = (int)reader["Morale"];
                military.Combativity = (int)reader["Combativity"];
                military.Experience = (int)reader["Experience"];
                military.InjuryQuantity = (int)reader["InjuryQuantity"];
                military.FollowedLeaderID = (short)reader["FollowedLeaderID"];
                military.LeaderID = (short)reader["LeaderID"];
                military.LeaderExperience = (int)reader["LeaderExperience"];
                int recruiter = (short)reader["RecruitmentPersonID"];
                foreach (Person p in this.Persons)
                {
                    if (p.ID == recruiter)
                    {
                        p.RecruitmentMilitary = military;
                    }
                }
                military.ShelledMilitaryID = (short)reader["ShelledMilitary"];
                this.Militaries.AddMilitary(military);
            }
            this.InitializeMilitaryData();
            DbConnection.Close();

            DbConnection.Open();
            reader = new OleDbCommand("Select * From Facility", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Facility facility = new Facility();
                facility.Scenario = this;
                facility.ID = (short)reader["ID"];
                facility.KindID = (short)reader["KindID"];
                facility.Endurance = (int)reader["Endurance"];
                this.Facilities.AddFacility(facility);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Information", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Information information = new Information();
                information.Scenario = this;
                information.ID = (short)reader["ID"];
                information.Level = (InformationLevel)((short)reader["iLevel"]);
                information.Position = new Point((short)reader["PositionX"], (short)reader["PositionY"]);
                information.Radius = (short)reader["Radius"];
                information.Oblique = (bool)reader["Oblique"];
                information.DaysLeft = (short)reader["DaysLeft"];
                this.Informations.AddInformation(information);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From SpyMessage", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                SpyMessage message = new SpyMessage();
                message.Scenario = this;
                message.ID = (int)reader["ID"];
                message.Kind = (SpyMessageKind)((short)reader["Kind"]);
                message.MessageFactionID = (short)reader["MessageFaction"];
                message.MessageArchitectureID = (short)reader["MessageArchitecture"];
                message.LoadPersonPacksFromString(this.AllPersons, reader["PersonPacks"].ToString());
                message.Message1 = reader["Message1"].ToString();
                message.Message2 = reader["Message2"].ToString();
                message.Message3 = reader["Message3"].ToString();
                message.Message4 = reader["Message4"].ToString();
                message.Message5 = reader["Message5"].ToString();
                this.SpyMessages.AddMessageWithEvent(message);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Architecture", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Architecture architecture = new Architecture();
                architecture.Scenario = this;
                architecture.ID = (short)reader["ID"];
                try
                {
                    architecture.CaptionID = (short)reader["CaptionID"];
                }
                catch
                {
                    architecture.CaptionID = 9999;

                }
                architecture.Name = reader["Name"].ToString();
                architecture.Kind = this.GameCommonData.AllArchitectureKinds.GetArchitectureKind((short)reader["Kind"]);
                architecture.IsStrategicCenter = (bool)reader["IsStrategicCenter"];
                architecture.LocationState = this.States.GetGameObject((short)reader["StateID"]) as State;
                architecture.LocationState.Architectures.Add(architecture);
                architecture.LocationState.LinkedRegion.Architectures.Add(architecture);
                if (architecture.LocationState.StateAdminID == architecture.ID)
                {
                    architecture.LocationState.StateAdmin = architecture;
                }
                if (architecture.LocationState.LinkedRegion.RegionCoreID == architecture.ID)
                {
                    architecture.LocationState.LinkedRegion.RegionCore = architecture;
                }
                architecture.Characteristics.LoadFromString(this.GameCommonData.AllInfluences, reader["Characteristics"].ToString());
                StaticMethods.LoadFromString(architecture.ArchitectureArea.Area, reader["Area"].ToString());
                architecture.LoadPersonsFromString(this.AllPersons, reader["Persons"].ToString());
                architecture.LoadMovingPersonsFromString(this.AllPersons, reader["MovingPersons"].ToString());
                architecture.LoadNoFactionPersonsFromString(this.AllPersons, reader["NoFactionPersons"].ToString());
                architecture.LoadNoFactionMovingPersonsFromString(this.AllPersons, reader["NoFactionMovingPersons"].ToString());
                architecture.Population = (int)reader["Population"];
                architecture.Fund = (int)reader["Fund"];
                architecture.Food = (int)reader["Food"];
                architecture.Agriculture = (int)reader["Agriculture"];
                architecture.Commerce = (int)reader["Commerce"];
                architecture.Technology = (int)reader["Technology"];
                architecture.Domination = (int)reader["Domination"];
                architecture.Morale = (int)reader["Morale"];
                architecture.Endurance = (int)reader["Endurance"];
                architecture.AutoHiring = (bool)reader["AutoHiring"];
                architecture.AutoRewarding = (bool)reader["AutoRewarding"];
                architecture.AutoWorking = (bool)reader["AutoWorking"];
                architecture.AutoSearching = (bool)reader["AutoSearching"];
                architecture.HireFinished = (bool)reader["HireFinished"];
                architecture.FacilityEnabled = (bool)reader["FacilityEnabled"];
                architecture.AgricultureWorkingPersons.LoadFromString(architecture.Persons, reader["AgricultureWorkingPersons"].ToString());
                architecture.CommerceWorkingPersons.LoadFromString(architecture.Persons, reader["CommerceWorkingPersons"].ToString());
                architecture.TechnologyWorkingPersons.LoadFromString(architecture.Persons, reader["TechnologyWorkingPersons"].ToString());
                architecture.DominationWorkingPersons.LoadFromString(architecture.Persons, reader["DominationWorkingPersons"].ToString());
                architecture.MoraleWorkingPersons.LoadFromString(architecture.Persons, reader["MoraleWorkingPersons"].ToString());
                architecture.EnduranceWorkingPersons.LoadFromString(architecture.Persons, reader["EnduranceWorkingPersons"].ToString());
                try
                {  //读存档,赈灾工作的人
                    architecture.zhenzaiWorkingPersons.LoadFromString(architecture.Persons, reader["zhenzaiWorkingPersons"].ToString());
                }
                catch
                {  //读剧本，剧本里没有这一项，所以会出错
                }
                try
                {  //读存档,训练工作的人
                    architecture.TrainingWorkingPersons.LoadFromString(architecture.Persons, reader["TrainingWorkingPersons"].ToString());
                }
                catch
                {  //读剧本，剧本里没有这一项，所以会出错
                }

                try
                {  //读存档
                    architecture.LoadfeiziPersonsFromString(this.AllPersons, reader["feiziliebiao"].ToString());
                }
                catch
                {  //读剧本，剧本里没有这一项，所以会出错
                }
                try
                {
                    architecture.MilitaryPopulation = (int)reader["MilitaryPopulation"];
                }
                catch
                {
                }

                architecture.LoadMilitariesFromString(this.Militaries, reader["Militaries"].ToString());
                architecture.LoadFacilitiesFromString(this.Facilities, reader["Facilities"].ToString());
                architecture.BuildingFacility = (int)reader["BuildingFacility"];
                architecture.BuildingDaysLeft = (int)reader["BuildingDaysLeft"];
                architecture.PlanFacilityKindID = (int)reader["PlanFacilityKind"];
                architecture.LoadFundPacksFromString(reader["FundPacks"].ToString());
                architecture.LoadSpyPacksFromString(reader["SpyPacks"].ToString());
                architecture.TodayNewMilitarySpyMessage = this.SpyMessages.GetGameObject((short)reader["TodayNewMilitarySpyMessage"]) as SpyMessage;
                architecture.TodayNewTroopSpyMessage = this.SpyMessages.GetGameObject((short)reader["TodayNewTroopSpyMessage"]) as SpyMessage;
                architecture.LoadPopulationPacksFromString(reader["PopulationPacks"].ToString());
                architecture.PlanArchitectureID = (int)reader["PlanArchitecture"];
                architecture.TransferFundArchitectureID = (int)reader["TransferFundArchitecture"];
                architecture.TransferFoodArchitectureID = (int)reader["TransferFoodArchitecture"];
                architecture.DefensiveLegionID = (int)reader["DefensiveLegion"];
                architecture.LoadCaptivesFromString(this.Captives, reader["Captives"].ToString());
                architecture.RobberTroopID = (short)reader["RobberTroop"];
                architecture.RecentlyAttacked = (short)reader["RecentlyAttacked"];
                architecture.RecentlyBreaked = (short)reader["RecentlyBreaked"];
                architecture.InformationCoolDown = (short)reader["InformationCoolDown"];
                architecture.AILandLinksString = reader["AILandLinks"].ToString();
                architecture.AIWaterLinksString = reader["AIWaterLinks"].ToString();

                try
                {
                    architecture.youzainan = (bool)reader["youzainan"];
                    architecture.zainan.zainanzhonglei = this.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei((short)reader["zainanleixing"]);
                    architecture.zainan.shengyutianshu = (short)reader["zainanshengyutianshu"];
                }
                catch
                {
                    architecture.youzainan = false;

                }
                try
                {
                    architecture.huangdisuozai = (bool)reader["Emperor"];
                }
                catch
                {
                    architecture.huangdisuozai = false;

                }

                this.Architectures.AddArchitectureWithEvent(architecture);
                this.AllArchitectures.Add(architecture.ID, architecture);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Routeway", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Routeway routeway = new Routeway();
                routeway.Scenario = this;
                routeway.ID = (short)reader["ID"];
                routeway.Building = (bool)reader["Building"];
                routeway.ShowArea = (bool)reader["ShowArea"];
                routeway.RemoveAfterClose = (bool)reader["RemoveAfterClose"];
                routeway.LastActivePointIndex = (int)reader["LastActivePointIndex"];
                routeway.InefficiencyDays = (int)reader["InefficiencyDays"];
                routeway.StartArchitecture = this.Architectures.GetGameObject((int)reader["StartArchitecture"]) as Architecture;
                if (routeway.StartArchitecture != null)
                {
                    routeway.StartArchitecture.Routeways.Add(routeway);
                }
                routeway.EndArchitecture = this.Architectures.GetGameObject((int)reader["EndArchitecture"]) as Architecture;
                routeway.DestinationArchitecture = this.Architectures.GetGameObject((int)reader["DestinationArchitecture"]) as Architecture;
                routeway.LoadRoutePointsFromString(reader["Points"].ToString());
                this.Routeways.AddRoutewayWithEvent(routeway);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Troop", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Troop troop = new Troop();
                troop.Scenario = this;
                troop.ID = (short)reader["ID"];
                troop.Controllable = (bool)reader["Controllable"];
                troop.SetStatus((TroopStatus)((short)reader["Status"]));
                troop.Direction = (TroopDirection)((short)reader["Direction"]);
                troop.Auto = (bool)reader["Auto"];
                troop.Operated = (bool)reader["Operated"];
                troop.Food = (int)reader["Food"];
                troop.zijin = (int)reader["zijin"];
                troop.StartingArchitecture = this.Architectures.GetGameObject((short)reader["StartingArchitecture"]) as Architecture;
                troop.LoadPersonsFromString(this.AllPersons, reader["Persons"].ToString(), (short)reader["LeaderID"]);
                troop.LoadPathInformation((short)reader["PositionX"], (short)reader["PositionY"], (short)reader["DestinationX"], (short)reader["DestinationY"], (short)reader["RealDestinationX"], (short)reader["RealDestinationY"], reader["FirstTierPath"].ToString(), reader["SecondTierPath"].ToString(), reader["ThirdTierPath"].ToString(), (short)reader["FirstIndex"], (short)reader["SecondIndex"], (short)reader["ThirdIndex"]);
                troop.MilitaryID = (short)reader["MilitaryID"];
                troop.AttackDefaultKind = (TroopAttackDefaultKind)((short)reader["AttackDefaultKind"]);
                troop.AttackTargetKind = (TroopAttackTargetKind)((short)reader["AttackTargetKind"]);
                troop.TargetTroopID = (short)reader["TargetTroopID"];
                troop.TargetArchitectureID = (short)reader["TargetArchitectureID"];
                troop.WillTroopID = (short)reader["WillTroopID"];
                troop.WillArchitectureID = (short)reader["WillArchitectureID"];
                troop.CurrentCombatMethodID = (short)reader["CurrentCombatMethodID"];
                troop.CurrentStratagemID = (short)reader["CurrentStratagemID"];
                troop.SelfCastPosition = new Point((short)reader["SelfCastPositionX"], (short)reader["SelfCastPositionY"]);
                troop.ChaosDayLeft = (short)reader["ChaosDayLeft"];
                troop.CutRoutewayDays = (short)reader["CutRoutewayDays"];
                troop.LoadCaptivesFromString(this.Captives, reader["Captives"].ToString());
                troop.RecentlyFighting = (short)reader["RecentlyFighting"];
                troop.TechnologyIncrement = (short)reader["TechnologyIncrement"];
                troop.EventInfluences.LoadFromString(this.GameCommonData.AllInfluences, reader["EventInfluences"].ToString());
                try
                {
                    troop.CurrentStunt = this.GameCommonData.AllStunts.GetStunt((short)reader["CurrentStunt"]);
                    troop.StuntDayLeft = (short)reader["StuntDayLeft"];
                }
                catch
                {
                }
                try
                {
                    troop.mingling = reader["mingling"].ToString();
                }
                catch
                {
                }
                troop.minglingweizhi = troop.RealDestination;
                this.Troops.AddTroopWithEvent(troop);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Legion", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Legion legion = new Legion();
                legion.Scenario = this;
                legion.ID = int.Parse(reader["ID"].ToString());
                legion.Kind = (LegionKind)((short)reader["Kind"]);
                legion.StartArchitecture = this.Architectures.GetGameObject((int)reader["StartArchitecture"]) as Architecture;
                legion.WillArchitecture = this.Architectures.GetGameObject((int)reader["WillArchitecture"]) as Architecture;
                legion.PreferredRouteway = this.Routeways.GetGameObject((int)reader["PreferredRouteway"]) as Routeway;
                legion.InformationDestination = StaticMethods.LoadFromString(reader["InformationDestination"].ToString());
                legion.CoreTroop = this.Troops.GetGameObject((int)reader["CoreTroop"]) as Troop;
                legion.LoadTroopsFromString(this.Troops, reader["Troops"].ToString());
                this.Legions.AddLegionWithEvent(legion);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Sections", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Section section = new Section();
                section.Scenario = this;
                section.ID = int.Parse(reader["ID"].ToString());
                section.Name = reader["Name"].ToString();
                section.AIDetail = this.GameCommonData.AllSectionAIDetails.GetSectionAIDetail((short)reader["AIDetail"]);
                section.OrientationFactionID = (short)reader["OrientationFaction"];
                section.OrientationSectionID = (short)reader["OrientationSection"];
                section.OrientationStateID = (short)reader["OrientationState"];
                section.LoadArchitecturesFromString(this.Architectures, reader["Architectures"].ToString());
                this.Sections.AddSectionWithEvent(section);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Faction", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Faction faction = new Faction();
                faction.Scenario = this;
                faction.ID = (short)reader["ID"];
                faction.Passed = (bool)reader["Passed"];
                faction.PreUserControlFinished = (bool)reader["PreUserControlFinished"];
                faction.Controlling = (bool)reader["Controlling"];
                faction.LeaderID = (short)reader["LeaderID"];
                faction.ColorIndex = (short)reader["ColorIndex"];
                faction.FactionColor = this.GameCommonData.AllColors[faction.ColorIndex];
                faction.Name = reader["FName"].ToString();
                faction.CapitalID = (short)reader["CapitalID"];
                faction.Reputation = (int)reader["Reputation"];
                faction.TechniquePoint = (int)reader["TechniquePoint"];
                faction.TechniquePointForTechnique = (int)reader["TechniquePointForTechnique"];
                faction.TechniquePointForFacility = (int)reader["TechniquePointForFacility"];
                faction.LoadArchitecturesFromString(this.Architectures, reader["Architectures"].ToString());
                faction.LoadTroopsFromString(this.Troops, reader["Troops"].ToString());
                faction.LoadInformationsFromString(this.Informations, reader["Informations"].ToString());
                faction.LoadRoutewaysFromString(this.Routeways, reader["Routeways"].ToString());
                faction.LoadLegionsFromString(this.Legions, reader["Legions"].ToString());
                faction.LoadSectionsFromString(this.Sections, reader["Sections"].ToString());
                faction.BaseMilitaryKinds.LoadFromString(this.GameCommonData.AllMilitaryKinds, reader["BaseMilitaryKinds"].ToString());
                faction.UpgradingTechnique = (short)reader["UpgradingTechnique"];
                faction.UpgradingDaysLeft = (short)reader["UpgradingDaysLeft"];
                faction.AvailableTechniques.LoadFromString(this.GameCommonData.AllTechniques, reader["AvailableTechniques"].ToString());
                StaticMethods.LoadFromString(faction.PreferredTechniqueKinds, reader["PreferredTechniqueKinds"].ToString());
                faction.PlanTechnique = this.GameCommonData.AllTechniques.GetTechnique((short)reader["PlanTechnique"]);
                faction.AutoRefuse = (bool)reader["AutoRefuse"];
                try
                {
                    faction.chaotinggongxiandu = (int)reader["chaotinggongxiandu"];
                }
                catch
                {
                    faction.chaotinggongxiandu = 0;

                }
                try
                {
                    faction.guanjue = (short)reader["guanjue"];
                }
                catch
                {
                    faction.guanjue = 0;

                }
                try
                {
                    faction.IsAlien = (bool)reader["IsAlien"];
                }
                catch
                {
                    faction.IsAlien = false;
                }
                this.Factions.AddFactionWithEvent(faction);
            }
            DbConnection.Close();
            DbConnection.Open();
            try
            {
                reader = new OleDbCommand("Select * From Treasure", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    Treasure treasure = new Treasure();
                    treasure.Scenario = this;
                    treasure.ID = (short)reader["ID"];
                    treasure.Name = reader["Name"].ToString();
                    treasure.Description = reader["Description"].ToString();
                    treasure.Pic = (short)reader["Pic"];
                    treasure.Worth = (short)reader["Worth"];
                    treasure.Available = (bool)reader["Available"];
                    treasure.AppearYear = (short)reader["AppearYear"];
                    int key = (short)reader["HidePlace"];
                    treasure.HidePlace = this.AllArchitectures.ContainsKey(key) ? this.AllArchitectures[key] : null;
                    int num2 = (short)reader["BelongedPerson"];
                    treasure.BelongedPerson = this.AllPersons.ContainsKey(num2) ? this.AllPersons[num2] : null;
                    if (treasure.BelongedPerson != null)
                    {
                        treasure.BelongedPerson.Treasures.Add(treasure);
                    }
                    treasure.Influences.LoadFromString(this.GameCommonData.AllInfluences, reader["Influences"].ToString());
                    this.Treasures.AddTreasure(treasure);
                }
            }
            catch
            {
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From DiplomaticRelation", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                DiplomaticRelation dr = new DiplomaticRelation();
                dr.Scenario = this;
                dr.RelationFaction1ID = (short)reader["Faction1ID"];
                dr.RelationFaction2ID = (short)reader["Faction2ID"];
                dr.Relation = (int)reader["Relation"];
                this.DiplomaticRelations.AddDiplomaticRelation(dr);
            }
            DbConnection.Close();
            command = new OleDbCommand("Select * From GameSurvey", DbConnection);
            DbConnection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            this.ScenarioTitle = reader["Title"].ToString();
            this.ScenarioDescription = reader["Description"].ToString();
            this.Date.LoadDateData((short)reader["GYear"], (short)reader["GMonth"], (short)reader["GDay"]);
            this.ScenarioMap.JumpPosition = StaticMethods.LoadFromString(reader["JumpPosition"].ToString()).Value;
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From TroopEvent", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                TroopEvent te = new TroopEvent();
                te.Scenario = this;
                te.ID = (short)reader["ID"];
                te.Name = reader["Name"].ToString();
                te.Happened = (bool)reader["Happened"];
                te.Repeatable = (bool)reader["Repeatable"];
                try
                {
                    te.AfterEventHappened = (short)reader["AfterEventHappened"];
                }
                catch
                {
                }
                te.LaunchPerson = this.Persons.GetGameObject((short)reader["LaunchPerson"]) as Person;
                te.Conditions.LoadFromString(this.GameCommonData.AllConditions, reader["Conditions"].ToString());
                te.HappenChance = (short)reader["Chance"];
                te.CheckArea = (EventCheckAreaKind)((short)reader["CheckAreaKind"]);
                te.LoadTargetPersonFromString(this.AllPersons, reader["TargetPersons"].ToString());
                te.LoadDialogFromString(this.AllPersons, reader["Dialogs"].ToString());
                te.LoadSelfEffectFromString(this.GameCommonData.AllTroopEventEffects, reader["EffectSelf"].ToString());
                te.LoadEffectPersonFromString(this.AllPersons, this.GameCommonData.AllTroopEventEffects, reader["EffectPersons"].ToString());
                te.LoadEffectAreaFromString(this.GameCommonData.AllTroopEventEffects, reader["EffectAreas"].ToString());
                this.TroopEvents.AddTroopEventWithEvent(te);
            }
            DbConnection.Close();
            try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From Event", DbConnection).ExecuteReader();
                
                while (reader.Read())
                {
                    try
                    {
                        Event e = new Event();
                        e.ID = (short)reader["ID"];
                        e.Name = reader["Name"].ToString();
                        e.repeatable = (bool)reader["Repeatable"];
                        e.AfterEventHappened = (short)reader["AfterEventHappened"];
                        e.happenChance = (short)reader["Chance"];
                        e.LoadPersonIdFromString(this.Persons, reader["PersonId"].ToString());
                        e.LoadPersonCondFromString(this.GameCommonData.AllConditions, reader["PersonCond"].ToString());
                        e.LoadArchitectureFromString(this.Architectures, reader["ArchitectureID"].ToString());
                        e.LoadArchitctureCondFromString(this.GameCommonData.AllConditions, reader["ArchitectureCond"].ToString());
                        e.LoadFactionFromString(this.Factions, reader["FactionID"].ToString());
                        e.LoadFactionCondFromString(this.GameCommonData.AllConditions, reader["FactionCond"].ToString());
                        e.LoadDialogFromString(reader["Dialog"].ToString());
                        e.LoadEffectFromString(this.GameCommonData.AllEventEffects, reader["Effect"].ToString());
                        e.LoadArchitectureEffectFromString(this.GameCommonData.AllEventEffects, reader["ArchitectureEffect"].ToString());
                        e.LoadFactionEffectFromString(this.GameCommonData.AllEventEffects, reader["FactionEffect"].ToString());
                        this.AllEvents.AddEventWithEvent(e);
                    }
                    catch
                    {
                        //ignore this event
                    }
                }
            }
            catch
            {
                //ignore, let there be empty event list
            }
            finally
            {
                DbConnection.Close();
            }
            try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From YearTable", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int year = (short)reader["GYear"];
                    int month = (short)reader["GMonth"];
                    int day = (short)reader["GDay"];
                    FactionList faction = new FactionList();
                    faction.LoadFromString(this.Factions, (string)reader["Faction"]);
                    string content = (string)reader["Content"];
                    bool isGlobal = (bool)reader["IsGloballyKnown"];
                    this.YearTable.addTableEntry(id, new GameDate(year, month, day), faction, content, isGlobal);
                }
            }
            catch
            {
                //ignore, let there be empty yeartable
            }
            finally
            {
                DbConnection.Close();
            }

            this.AllPersons.Clear();
            this.AllArchitectures.Clear();
            
        }  


        public bool LoadGameScenarioFromDatabase(string connectionString)  //读取剧本
        {
            this.Clear();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            this.LoadGameDataFromDataBase(dbConnection);
            OleDbCommand command = new OleDbCommand("Select * From GameData", dbConnection);
            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            this.PlayerFactions.LoadFromString(this.Factions, reader["PlayerList"].ToString());
            int iD = (short) reader["CurrentPlayer"];
            if (iD >= 0)
            {
                this.CurrentPlayer = this.Factions.GetGameObject(iD) as Faction;
                this.CurrentFaction = this.CurrentPlayer;
                this.Factions.RunningFaction = this.CurrentPlayer;
            }
            this.Factions.LoadQueueFromString(reader["FactionQueue"].ToString());
            this.FireTable.LoadFromString(reader["FireTable"].ToString());
            this.NoFoodDictionary.LoadFromString(reader["NoFoodTable"].ToString());
            try
            {
                this.DaySince = (int)reader["DaySince"];
            }
            catch
            {
            }
            dbConnection.Close();
            this.InitializeMapData();
            this.TroopAnimations.UpdateDirectionAnimations(this.ScenarioMap.TileWidth);
            this.ApplyFireTable();
            this.InitializeFactionData();
            this.Preparing = true;
            this.Factions.BuildQueue(true);
            this.Factions.ApplyInfluences();
            this.Architectures.ApplyInfluences();
            this.Persons.ApplyInfluences();
            this.Preparing = false;
            this.InitialGameData();
            if (this.OnAfterLoadScenario != null)
            {
                this.OnAfterLoadScenario(this);
            }
            return true;
        }

        public bool LoadSaveFileFromDatabase(string connectionString) //读取存档
        {
            this.Clear();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            this.LoadGameDataFromDataBase(dbConnection);
            OleDbCommand command = new OleDbCommand("Select * From GameData", dbConnection);
            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            this.PlayerFactions.LoadFromString(this.Factions, reader["PlayerList"].ToString());
            this.CurrentPlayer = this.Factions.GetGameObject((short) reader["CurrentPlayer"]) as Faction;
            this.CurrentFaction = this.CurrentPlayer;
            this.Factions.RunningFaction = this.CurrentPlayer;
            this.Factions.LoadQueueFromString(reader["FactionQueue"].ToString());
            this.FireTable.LoadFromString(reader["FireTable"].ToString());
            this.NoFoodDictionary.LoadFromString(reader["NoFoodTable"].ToString());
            dbConnection.Close();
            this.InitializeMapData();
            this.TroopAnimations.UpdateDirectionAnimations(this.ScenarioMap.TileWidth);
            this.ApplyFireTable();
            this.InitializeFactionData();
            this.Preparing = true;
            this.Factions.ApplyInfluences();
            this.Architectures.ApplyInfluences();
            this.Persons.ApplyInfluences();
            this.Preparing = false;
            this.InitialGameData();
            if (this.OnAfterLoadScenario != null)
            {
                this.OnAfterLoadScenario(this);
            }
            this.detectCurrentPlayerBattleState(this.CurrentPlayer);
            if (this.PlayerFactions.Count == 0)
            {
                oldDialogShowTime = GlobalVariables.DialogShowTime;
                GlobalVariables.DialogShowTime = 0;
            }
            else
            {
                if (oldDialogShowTime >= 0)
                {
                    GlobalVariables.DialogShowTime = oldDialogShowTime;
                }
            }
            return true;
        }
        private int oldDialogShowTime = -1;

        public void MonthPassedEvent()
        {
            foreach (Faction faction in this.Factions.GetRandomList())
            {
                faction.MonthEvent();
            }
            foreach (Person person in this.Persons)
            {
                person.TryToBeAvailable();
            }
            this.AddPreparedAvailablePersons();
            foreach (Person person in this.AvailablePersons.GetRandomList())
            {
                person.MonthEvent();
            }
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.MonthEvent();
            }
            foreach (MilitaryKind kind in this.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
            {
                bool flag = true;
                foreach (Troop troop in this.Troops)
                {
                    if ((troop.Army.Kind == kind) && this.GameScreen.TileInScreen(troop.Position))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    kind.Textures.Dispose();
                }
            }
        }

        public void MonthStartingEvent()
        {
        }

        public void SeasonChangeEvent()
        {
            if ((this.Date.Month == 3 || this.Date.Month == 6 || this.Date.Month == 9 || this.Date.Month == 12) && this.Date.Day == 1)
            {
                foreach (Faction faction in this.Factions.GetRandomList())
                {
                    faction.SeasonEvent();
                }
                foreach (Architecture architecture in this.Architectures.GetRandomList())
                {
                    architecture.DevelopSeason();
                }
            }
        }

        public bool MoreThanOneTroopOnPosition(Point position)
        {
            return (this.MapTileData[position.X, position.Y].TroopCount > 1);
        }

        private void NewFaction()
        {
            PersonList list = new PersonList();
            foreach (Person person in this.AvailablePersons)
            {
                if (person.YoukenengChuangjianXinShili())   //里面包含武将有可能独立的参数
                {
                    list.Add(person);
                }
            }
            if (list.Count > 0)
            {
                Person person3 = list[GameObject.Random(list.Count)] as Person;
                if (
                        (
                            (
                                (
                                    (person3.LocationArchitecture != null) && !person3.IsCaptive
                                 ) &&
                                (
                                    (person3.LocationArchitecture.RecentlyAttacked <= 0) 
                                    && (person3.LocationArchitecture.Population > (0x2710 * person3.LocationArchitecture.AreaCount))
                                 )
                            ) &&
                            !person3.LocationArchitecture.IsCapital
                        ) &&
                        (
                            (  //创建新势力
                                (person3.LocationArchitecture.BelongedFaction == null) 
                                && (GameObject.Random(person3.Reputation) > GameObject.Random(0xc350 * person3.LocationArchitecture.AreaCount))
                            ) ||
                            (  //独立
                                (
                                    (person3.BelongedFaction != null) && (Person.GetIdealOffset(person3, person3.BelongedFaction.Leader) > 10)
                                ) &&
                                (
                                    GameObject.Random
                                    (
                                        (
                                            (person3.LocationArchitecture.ArmyScale * 0x4e20)
                                            + (person3.LocationArchitecture.Domination * person3.LocationArchitecture.Morale)
                                        ) *
                                        person3.LocationArchitecture.AreaCount
                                    ) < GameObject.Random(person3.Reputation)
                                )
                            )
                         )
                    )
                {
                    this.CreateNewFaction(person3);
                }
            }
        }

        private void NoFoodPositionDayEvent()
        {
            List<NoFoodPosition> list = new List<NoFoodPosition>();
            foreach (NoFoodPosition position in this.NoFoodDictionary.Positions.Values)
            {
                position.Days--;
                if (position.Days <= 0)
                {
                    list.Add(position);
                }
            }
            foreach (NoFoodPosition position in list)
            {
                this.NoFoodDictionary.RemovePosition(position);
            }
        }

        public bool PositionIsArchitecture(Point position)
        {
            return (this.GetArchitectureByPosition(position) != null);
        }

        public bool PositionIsOnFire(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return false;
            }
            return this.FireTable.HasPosition(position);
        }

        public bool PositionIsOnFireNoCheck(Point position)
        {
            return this.FireTable.HasPosition(position);
        }

        public bool PositionIsTroop(Point position)
        {
            return (this.GetTroopByPosition(position) != null);
        }

        public bool PositionOutOfRange(Point position)
        {
            return this.ScenarioMap.PositionOutOfRange(position);
        }

        public string PositionString(Point position)
        {
            
            if (this.PositionIsArchitecture(position))
            {
                return this.GetArchitectureByPositionNoCheck(position).Name;
            }
            /*
            if (this.PositionIsTroop(position))
            {
                return this.GetTroopByPositionNoCheck(position).DisplayName;
            }
            */
            return (this.GetTerrainNameByPosition(position) + " " + this.GetCoordinateString(position));
        }

        public void ReflectDiplomaticRelations(int src, int des, int offset)
        {
            foreach (DiplomaticRelation relation in this.DiplomaticRelations.GetDiplomaticRelationListByFactionID(des))
            {
                int theOtherFactionID = relation.GetTheOtherFactionID(des);
                if ((theOtherFactionID != src) && (Math.Abs(relation.Relation) >= 100))
                {
                    int num2 = this.DiplomaticRelations.GetDiplomaticRelation(src, theOtherFactionID).Relation;
                    if ((num2 > -300) && (num2 < 300))
                    {
                        int num3 = relation.Relation;
                        if (num3 > 0x3e8)
                        {
                            num3 = 0x3e8;
                        }
                        else if (num3 < -0x3e8)
                        {
                            num3 = -0x3e8;
                        }
                        this.ChangeDiplomaticRelation(src, theOtherFactionID, (offset * num3) / 0x3e8);
                    }
                }
            }
        }

        public void RemovePositionAreaInfluence(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
                this.MapTileData[position.X, position.Y].RemoveAreaInfluence(troop, troopByPositionNoCheck);
                if (troopByPositionNoCheck != null)
                {
                    troopByPositionNoCheck.RefreshDataOfAreaInfluence();
                }
            }
        }

        public void RemovePositionContactingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveContactingTroop(troop);
            }
        }

        public void RemovePositionOffencingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveOffencingTroop(troop);
            }
        }

        public void RemovePositionStratagemingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveStratagemingTroop(troop);
            }
        }

        public void RemovePositionViewingTroopNoCheck(Troop troop, Point position)
        {
            this.MapTileData[position.X, position.Y].RemoveViewingTroop(troop);
        }

        public void RemoveRouteway(Routeway routeway)
        {
            if (routeway.FirstPoint != null)
            {
                routeway.CutAt(routeway.FirstPoint.Position);
            }
            if (routeway.StartArchitecture != null)
            {
                routeway.StartArchitecture.Routeways.Remove(routeway);
            }
            if (routeway.BelongedFaction != null)
            {
                routeway.BelongedFaction.RemoveRouteway(routeway);
            }
            this.Routeways.Remove(routeway);
        }

        public void ResetMapTileTroop(Point position)
        {
            if (this.MapTileData[position.X, position.Y].TileTroop != null)
            {
                TileData data1 = this.MapTileData[position.X, position.Y];
                data1.TroopCount--;
                this.MapTileData[position.X, position.Y].TileTroop = null;
            }
        }

        public bool SaveGameScenarioToDatabase(string connectionString)
        {
            try
            {
                OleDbConnection selectConnection = new OleDbConnection(connectionString);
                DataSet dataSet = new DataSet();
                DataRow row = null;
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Map", selectConnection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Map");
                row = dataSet.Tables["Map"].NewRow();
                row.BeginEdit();
                row["TileWidth"] = this.ScenarioMap.TileWidth;
                row["DimensionX"] = this.ScenarioMap.MapDimensions.X;
                row["DimensionY"] = this.ScenarioMap.MapDimensions.Y;
                row["MapData"] = this.ScenarioMap.SaveToString();
                row["FileName"] = this.ScenarioMap.MapName;
                row["kuaishu"] = this.ScenarioMap.NumberOfTiles;
                row["meikuaidexiaokuaishu"] = this.ScenarioMap.NumberOfSquaresInEachTile;
                row["useSimpleArchImages"] = this.ScenarioMap.UseSimpleArchImages;
                row.EndEdit();
                dataSet.Tables["Map"].Rows.Add(row);
                adapter.Update(dataSet, "Map");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from DiplomaticRelation", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "DiplomaticRelation");
                dataSet.Tables["DiplomaticRelation"].Rows.Clear();
                foreach (DiplomaticRelation relation in this.DiplomaticRelations.DiplomaticRelations.Values)
                {
                    row = dataSet.Tables["DiplomaticRelation"].NewRow();
                    row.BeginEdit();
                    row["Faction1ID"] = relation.RelationFaction1ID;
                    row["Faction2ID"] = relation.RelationFaction2ID;
                    row["Relation"] = relation.Relation;
                    row.EndEdit();
                    dataSet.Tables["DiplomaticRelation"].Rows.Add(row);
                }
                adapter.Update(dataSet, "DiplomaticRelation");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Faction", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Faction");
                dataSet.Tables["Faction"].Rows.Clear();
                foreach (Faction faction in this.Factions)
                {
                    row = dataSet.Tables["Faction"].NewRow();
                    row.BeginEdit();
                    row["ID"] = faction.ID;
                    row["Passed"] = faction.Passed;
                    row["PreUserControlFinished"] = faction.PreUserControlFinished;
                    row["Controlling"] = faction.Controlling;
                    row["LeaderID"] = faction.LeaderID;
                    row["ColorIndex"] = faction.ColorIndex;
                    row["FName"] = faction.Name;
                    row["CapitalID"] = faction.CapitalID;
                    row["Reputation"] = faction.Reputation;
                    row["TechniquePoint"] = faction.TechniquePoint;
                    row["TechniquePointForTechnique"] = faction.TechniquePointForTechnique;
                    row["TechniquePointForFacility"] = faction.TechniquePointForFacility;
                    row["Sections"] = faction.Sections.SaveToString();
                    row["Architectures"] = faction.Architectures.SaveToString();
                    row["Troops"] = faction.Troops.SaveToString();
                    row["Informations"] = faction.Informations.SaveToString();
                    row["Routeways"] = faction.Routeways.SaveToString();
                    row["Legions"] = faction.Legions.SaveToString();
                    row["BaseMilitaryKinds"] = faction.BaseMilitaryKinds.SaveToString();
                    row["UpgradingTechnique"] = faction.UpgradingTechnique;
                    row["UpgradingDaysLeft"] = faction.UpgradingDaysLeft;
                    row["AvailableTechniques"] = faction.AvailableTechniques.SaveToString();
                    row["PreferredTechniqueKinds"] = StaticMethods.SaveToString(faction.PreferredTechniqueKinds);
                    row["PlanTechnique"] = (faction.PlanTechnique != null) ? faction.PlanTechnique.ID : -1;
                    row["AutoRefuse"] = faction.AutoRefuse;
                    row["chaotinggongxiandu"] = faction.chaotinggongxiandu;
                    row["guanjue"] = faction.guanjue;
                    row["IsAlien"] = faction.IsAlien;
                    row.EndEdit();
                    dataSet.Tables["Faction"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Faction");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Sections", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Sections");
                dataSet.Tables["Sections"].Rows.Clear();
                foreach (Section section in this.Sections)
                {
                    section.EnsureSectionArchitecture();
                    row = dataSet.Tables["Sections"].NewRow();
                    row.BeginEdit();
                    row["ID"] = section.ID;
                    row["AIDetail"] = section.AIDetail.ID;
                    row["Name"] = section.Name;
                    row["OrientationFaction"] = (section.OrientationFaction != null) ? section.OrientationFaction.ID : -1;
                    row["OrientationSection"] = (section.OrientationSection != null) ? section.OrientationSection.ID : -1;
                    row["OrientationState"] = (section.OrientationState != null) ? section.OrientationState.ID : -1;
                    row["Architectures"] = section.Architectures.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Sections"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Sections");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Architecture", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Architecture");
                dataSet.Tables["Architecture"].Rows.Clear();
                foreach (Architecture architecture in this.Architectures)
                {
                    row = dataSet.Tables["Architecture"].NewRow();
                    row.BeginEdit();
                    row["ID"] = architecture.ID;
                    row["CaptionID"] = architecture.CaptionID;
                    row["Name"] = architecture.Name;
                    row["Kind"] = architecture.Kind.ID;
                    row["IsStrategicCenter"] = architecture.IsStrategicCenter;
                    row["StateID"] = architecture.LocationState.ID;
                    row["Characteristics"] = architecture.Characteristics.SaveToString();
                    row["Area"] = StaticMethods.SaveToString(architecture.ArchitectureArea.Area);
                    row["Persons"] = architecture.Persons.SaveToString();
                    row["MovingPersons"] = architecture.MovingPersons.SaveToString();
                    row["NoFactionPersons"] = architecture.NoFactionPersons.SaveToString();
                    row["NoFactionMovingPersons"] = architecture.NoFactionMovingPersons.SaveToString();
                    row["Population"] = architecture.Population;
                    row["Fund"] = architecture.Fund;
                    row["Food"] = architecture.Food;
                    row["Agriculture"] = architecture.Agriculture;
                    row["Commerce"] = architecture.Commerce;
                    row["Technology"] = architecture.Technology;
                    row["Domination"] = architecture.Domination;
                    row["Morale"] = architecture.Morale;
                    row["Endurance"] = architecture.Endurance;
                    row["AutoHiring"] = architecture.AutoHiring;
                    row["AutoRewarding"] = architecture.AutoRewarding;
                    row["AutoWorking"] = architecture.AutoWorking;
                    row["AutoSearching"] = architecture.AutoSearching;
                    row["HireFinished"] = architecture.HireFinished;
                    row["FacilityEnabled"] = architecture.FacilityEnabled;
                    row["AgricultureWorkingPersons"] = architecture.AgricultureWorkingPersons.SaveToString();
                    row["CommerceWorkingPersons"] = architecture.CommerceWorkingPersons.SaveToString();
                    row["TechnologyWorkingPersons"] = architecture.TechnologyWorkingPersons.SaveToString();
                    row["DominationWorkingPersons"] = architecture.DominationWorkingPersons.SaveToString();
                    row["MoraleWorkingPersons"] = architecture.MoraleWorkingPersons.SaveToString();
                    row["EnduranceWorkingPersons"] = architecture.EnduranceWorkingPersons.SaveToString();
                    row["zhenzaiWorkingPersons"] = architecture.zhenzaiWorkingPersons.SaveToString();
                    row["TrainingWorkingPersons"] = architecture.TrainingWorkingPersons.SaveToString();
                    row["feiziliebiao"] = architecture.feiziliebiao.SaveToString();

                    row["Militaries"] = architecture.Militaries.SaveToString();
                    row["Facilities"] = architecture.Facilities.SaveToString();
                    row["BuildingFacility"] = architecture.BuildingFacility;
                    row["BuildingDaysLeft"] = architecture.BuildingDaysLeft;
                    row["PlanFacilityKind"] = (architecture.PlanFacilityKind != null) ? architecture.PlanFacilityKind.ID : -1;
                    row["FundPacks"] = architecture.SaveFundPacksToString();
                    row["SpyPacks"] = architecture.SaveSpyPacksToString();
                    row["TodayNewMilitarySpyMessage"] = (architecture.TodayNewMilitarySpyMessage != null) ? architecture.TodayNewMilitarySpyMessage.ID : -1;
                    row["TodayNewTroopSpyMessage"] = (architecture.TodayNewTroopSpyMessage != null) ? architecture.TodayNewTroopSpyMessage.ID : -1;
                    row["PopulationPacks"] = architecture.SavePopulationPacksToString();
                    row["PlanArchitecture"] = (architecture.PlanArchitecture != null) ? architecture.PlanArchitecture.ID : -1;
                    row["TransferFundArchitecture"] = (architecture.TransferFundArchitecture != null) ? architecture.TransferFundArchitecture.ID : -1;
                    row["TransferFoodArchitecture"] = (architecture.TransferFoodArchitecture != null) ? architecture.TransferFoodArchitecture.ID : -1;
                    row["DefensiveLegion"] = (architecture.DefensiveLegion != null) ? architecture.DefensiveLegion.ID : -1;
                    row["Captives"] = architecture.Captives.SaveToString();
                    row["RobberTroop"] = (architecture.RobberTroop != null) ? architecture.RobberTroop.ID : -1;
                    row["RecentlyAttacked"] = architecture.RecentlyAttacked;
                    row["RecentlyBreaked"] = architecture.RecentlyBreaked;
                    row["InformationCoolDown"] = architecture.InformationCoolDown;
                    row["AILandLinks"] = architecture.AILandLinks.SaveToString();
                    row["AIWaterLinks"] = architecture.AIWaterLinks.SaveToString();
                    row["youzainan"] = architecture.youzainan;
                    row["zainanleixing"] = architecture.zainan.zainanzhonglei.ID;
                    row["zainanshengyutianshu"] = architecture.zainan.shengyutianshu;
                    row["Emperor"] = architecture.huangdisuozai;
                    row["MilitaryPopulation"] = architecture.MilitaryPopulation;
                    row.EndEdit();
                    dataSet.Tables["Architecture"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Architecture");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Legion", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Legion");
                dataSet.Tables["Legion"].Rows.Clear();
                foreach (Legion legion in this.Legions)
                {
                    row = dataSet.Tables["Legion"].NewRow();
                    row.BeginEdit();
                    row["ID"] = legion.ID;
                    row["Kind"] = (int)legion.Kind;
                    row["StartArchitecture"] = (legion.StartArchitecture != null) ? legion.StartArchitecture.ID : -1;
                    row["WillArchitecture"] = (legion.WillArchitecture != null) ? legion.WillArchitecture.ID : -1;
                    row["PreferredRouteway"] = (legion.PreferredRouteway != null) ? legion.PreferredRouteway.ID : -1;
                    row["InformationDestination"] = StaticMethods.SaveToString(legion.InformationDestination);
                    row["CoreTroop"] = (legion.CoreTroop != null) ? legion.CoreTroop.ID : -1;
                    row["Troops"] = legion.Troops.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Legion"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Legion");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Troop", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Troop");
                dataSet.Tables["Troop"].Rows.Clear();
                foreach (Troop troop in this.Troops)
                {
                    row = dataSet.Tables["Troop"].NewRow();
                    row.BeginEdit();
                    row["ID"] = troop.ID;
                    row["LeaderID"] = troop.Leader.ID;
                    row["Controllable"] = troop.Controllable;
                    row["Status"] = troop.Status;
                    row["Direction"] = troop.Direction;
                    row["Auto"] = troop.Auto;
                    row["Operated"] = troop.Operated;
                    row["Food"] = troop.Food;
                    row["zijin"] = troop.zijin;
                    row["StartingArchitecture"] = (troop.StartingArchitecture != null) ? troop.StartingArchitecture.ID : -1;
                    row["Persons"] = troop.SavePersonsToString();
                    row["PositionX"] = troop.Position.X;
                    row["PositionY"] = troop.Position.Y;
                    row["DestinationX"] = troop.Destination.X;
                    row["DestinationY"] = troop.Destination.Y;
                    row["RealDestinationX"] = troop.RealDestination.X;
                    row["RealDestinationY"] = troop.RealDestination.Y;
                    row["FirstTierPath"] = StaticMethods.SaveToString(troop.FirstTierPath);
                    row["SecondTierPath"] = StaticMethods.SaveToString(troop.SecondTierPath);
                    row["ThirdTierPath"] = StaticMethods.SaveToString(troop.ThirdTierPath);
                    row["FirstIndex"] = troop.FirstIndex;
                    row["SecondIndex"] = troop.SecondIndex;
                    row["ThirdIndex"] = troop.ThirdIndex;
                    row["MilitaryID"] = troop.MilitaryID;
                    row["AttackDefaultKind"] = troop.AttackDefaultKind;
                    row["AttackTargetKind"] = troop.AttackTargetKind;
                    row["TargetTroopID"] = troop.TargetTroopID;
                    row["TargetArchitectureID"] = troop.TargetArchitectureID;
                    row["WillTroopID"] = troop.WillTroopID;
                    row["WillArchitectureID"] = troop.WillArchitectureID;
                    row["CurrentCombatMethodID"] = troop.CurrentCombatMethodID;
                    row["CurrentStratagemID"] = troop.CurrentStratagemID;
                    row["SelfCastPositionX"] = troop.SelfCastPosition.X;
                    row["SelfCastPositionY"] = troop.SelfCastPosition.Y;
                    row["ChaosDayLeft"] = troop.ChaosDayLeft;
                    row["CutRoutewayDays"] = troop.CutRoutewayDays;
                    row["Captives"] = troop.Captives.SaveToString();
                    row["RecentlyFighting"] = troop.RecentlyFighting;
                    row["TechnologyIncrement"] = troop.TechnologyIncrement;
                    row["EventInfluences"] = troop.EventInfluences.SaveToString();
                    row["CurrentStunt"] = (troop.CurrentStunt != null) ? troop.CurrentStunt.ID : -1;
                    row["StuntDayLeft"] = troop.StuntDayLeft;
                    row["mingling"] = troop.mingling;
                    row.EndEdit();
                    dataSet.Tables["Troop"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Troop");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from TroopEvent", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "TroopEvent");
                dataSet.Tables["TroopEvent"].Rows.Clear();
                foreach (TroopEvent event2 in this.TroopEvents)
                {
                    row = dataSet.Tables["TroopEvent"].NewRow();
                    row.BeginEdit();
                    row["ID"] = event2.ID;
                    row["Name"] = event2.Name;
                    row["Happened"] = event2.Happened;
                    row["Repeatable"] = event2.Repeatable;
                    row["AfterEventHappened"] = (event2.AfterHappenedEvent != null) ? event2.AfterHappenedEvent.ID : -1;
                    row["LaunchPerson"] = (event2.LaunchPerson != null) ? event2.LaunchPerson.ID : -1;
                    row["Conditions"] = event2.Conditions.SaveToString();
                    row["Chance"] = event2.HappenChance;
                    row["CheckAreaKind"] = event2.CheckArea;
                    row["TargetPersons"] = event2.SaveTargetPersonToString();
                    row["Dialogs"] = event2.SaveDialogToString();
                    row["EffectSelf"] = event2.SaveSelfEffectToString();
                    row["EffectPersons"] = event2.SaveEffectPersonToString();
                    row["EffectAreas"] = event2.SaveEffectAreaToString();
                    row.EndEdit();
                    dataSet.Tables["TroopEvent"].Rows.Add(row);
                }
                adapter.Update(dataSet, "TroopEvent");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Routeway", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Routeway");
                dataSet.Tables["Routeway"].Rows.Clear();
                foreach (Routeway routeway in this.Routeways)
                {
                    if ((routeway.StartArchitecture != null) && ((routeway.Building || (routeway.LastActivePointIndex >= 0)) || (routeway.StartArchitecture.BelongedSection == null || (!routeway.StartArchitecture.BelongedSection.AIDetail.AutoRun && this.IsPlayer(routeway.StartArchitecture.BelongedFaction)))))
                    {
                        row = dataSet.Tables["Routeway"].NewRow();
                        row.BeginEdit();
                        row["ID"] = routeway.ID;
                        row["Building"] = routeway.Building;
                        row["ShowArea"] = routeway.ShowArea;
                        row["RemoveAfterClose"] = routeway.RemoveAfterClose;
                        row["InefficiencyDays"] = routeway.InefficiencyDays;
                        row["LastActivePointIndex"] = routeway.LastActivePointIndex;
                        row["StartArchitecture"] = (routeway.StartArchitecture != null) ? routeway.StartArchitecture.ID : -1;
                        row["EndArchitecture"] = (routeway.EndArchitecture != null) ? routeway.EndArchitecture.ID : -1;
                        row["DestinationArchitecture"] = (routeway.DestinationArchitecture != null) ? routeway.DestinationArchitecture.ID : -1;
                        row["Points"] = routeway.SaveRoutePointsToString();
                        row.EndEdit();
                        dataSet.Tables["Routeway"].Rows.Add(row);
                    }
                }
                adapter.Update(dataSet, "Routeway");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Information", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Information");
                dataSet.Tables["Information"].Rows.Clear();
                foreach (Information information in this.Informations)
                {
                    row = dataSet.Tables["Information"].NewRow();
                    row.BeginEdit();
                    row["ID"] = information.ID;
                    row["iLevel"] = information.Level;
                    row["PositionX"] = information.Position.X;
                    row["PositionY"] = information.Position.Y;
                    row["Radius"] = information.Radius;
                    row["Oblique"] = information.Oblique;
                    row["DaysLeft"] = information.DaysLeft;
                    row.EndEdit();
                    dataSet.Tables["Information"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Information");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from SpyMessage", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "SpyMessage");
                dataSet.Tables["SpyMessage"].Rows.Clear();
                foreach (SpyMessage message in this.SpyMessages)
                {
                    row = dataSet.Tables["SpyMessage"].NewRow();
                    row.BeginEdit();
                    row["ID"] = message.ID;
                    row["Kind"] = message.Kind;
                    row["MessageFaction"] = (message.MessageFaction != null) ? message.MessageFaction.ID : -1;
                    row["MessageArchitecture"] = (message.MessageArchitecture != null) ? message.MessageArchitecture.ID : -1;
                    row["PersonPacks"] = message.SavePersonPacksToString();
                    row["Message1"] = message.Message1;
                    row["Message2"] = message.Message2;
                    row["Message3"] = message.Message3;
                    row["Message4"] = message.Message4;
                    row["Message5"] = message.Message5;
                    row.EndEdit();
                    dataSet.Tables["SpyMessage"].Rows.Add(row);
                }
                adapter.Update(dataSet, "SpyMessage");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Military", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Military");
                dataSet.Tables["Military"].Rows.Clear();
                foreach (Military military in this.Militaries)
                {
                    row = dataSet.Tables["Military"].NewRow();
                    row.BeginEdit();
                    row["ID"] = military.ID;
                    row["Name"] = military.Name;
                    row["KindID"] = military.RealKindID;
                    row["Quantity"] = military.Quantity;
                    row["Morale"] = military.Morale;
                    row["Combativity"] = military.Combativity;
                    row["Experience"] = military.Experience;
                    row["InjuryQuantity"] = military.InjuryQuantity;
                    row["FollowedLeaderID"] = (military.FollowedLeader != null) ? military.FollowedLeader.ID : -1;
                    row["LeaderID"] = (military.Leader != null) ? military.Leader.ID : -1;
                    row["LeaderExperience"] = military.LeaderExperience;
                    row["TrainingPersonID"] = -1;
                    row["RecruitmentPersonID"] = military.RecruitmentPerson == null ? -1 : military.RecruitmentPerson.ID;
                    row["ShelledMilitary"] = (military.ShelledMilitary != null) ? military.ShelledMilitary.ID : -1;
                    row.EndEdit();
                    dataSet.Tables["Military"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Military");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Facility", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Facility");
                dataSet.Tables["Facility"].Rows.Clear();
                foreach (Facility facility in this.Facilities)
                {
                    row = dataSet.Tables["Facility"].NewRow();
                    row.BeginEdit();
                    row["ID"] = facility.ID;
                    row["KindID"] = facility.KindID;
                    row["Endurance"] = facility.Endurance;
                    row.EndEdit();
                    dataSet.Tables["Facility"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Facility");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Captive", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Captive");
                dataSet.Tables["Captive"].Rows.Clear();
                foreach (Captive captive in this.Captives)
                {
                    row = dataSet.Tables["Captive"].NewRow();
                    row.BeginEdit();
                    row["ID"] = captive.ID;
                    row["CaptivePerson"] = (captive.CaptivePerson != null) ? captive.CaptivePerson.ID : -1;
                    row["CaptiveFaction"] = (captive.CaptiveFaction != null) ? captive.CaptiveFaction.ID : -1;
                    row["RansomArchitecture"] = (captive.RansomArchitecture != null) ? captive.RansomArchitecture.ID : -1;
                    row["RansomFund"] = captive.RansomFund;
                    row["RansomArriveDays"] = captive.RansomArriveDays;
                    row.EndEdit();
                    dataSet.Tables["Captive"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Captive");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Person", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Person");
                dataSet.Tables["Person"].Rows.Clear();
                foreach (Person person in this.Persons)
                {
                    row = dataSet.Tables["Person"].NewRow();
                    row.BeginEdit();
                    row["ID"] = person.ID;
                    row["Available"] = person.Available;
                    row["Alive"] = person.Alive;
                    row["SurName"] = person.SurName;
                    row["GivenName"] = person.GivenName;
                    row["CalledName"] = person.CalledName;
                    row["Sex"] = person.Sex;
                    row["Pic"] = person.PictureIndex;
                    row["Ideal"] = person.Ideal;
                    row["IdealTendency"] = (person.IdealTendency != null) ? person.IdealTendency.ID : -1;
                    row["LeaderPossibility"] = person.LeaderPossibility;
                    row["PCharacter"] = person.Character.ID;
                    row["YearAvailable"] = person.YearAvailable;
                    row["YearBorn"] = person.YearBorn;
                    row["YearDead"] = person.YearDead;
                    row["DeadReason"] = (int)person.DeadReason;
                    row["Strength"] = person.BaseStrength;
                    row["Command"] = person.BaseCommand;
                    row["Intelligence"] = person.BaseIntelligence;
                    row["Politics"] = person.BasePolitics;
                    row["Glamour"] = person.BaseGlamour;
                    row["Reputation"] = person.Reputation;
                    row["StrengthExperience"] = person.StrengthExperience;
                    row["CommandExperience"] = person.CommandExperience;
                    row["IntelligenceExperience"] = person.IntelligenceExperience;
                    row["PoliticsExperience"] = person.PoliticsExperience;
                    row["GlamourExperience"] = person.GlamourExperience;
                    row["InternalExperience"] = person.InternalExperience;
                    row["TacticsExperience"] = person.TacticsExperience;
                    row["BubingExperience"] = person.BubingExperience;
                    row["NubingExperience"] = person.NubingExperience;
                    row["QibingExperience"] = person.QibingExperience;
                    row["ShuijunExperience"] = person.ShuijunExperience;
                    row["QixieExperience"] = person.QixieExperience;
                    row["StratagemExperience"] = person.StratagemExperience;
                    row["RoutCount"] = person.RoutCount;
                    row["RoutedCount"] = person.RoutedCount;
                    row["Braveness"] = person.Braveness;
                    row["Calmness"] = person.Calmness;
                    row["Loyalty"] = person.Loyalty;
                    row["BornRegion"] = (int)person.BornRegion;
                    row["AvailableLocation"] = person.AvailableLocation;
                    row["Strain"] = person.Strain;
                    row["Father"] = person.Father;
                    row["Mother"] = person.Mother;
                    row["Spouse"] = person.Spouse;
                    row["Brother"] = person.Brother;
                    row["Generation"] = person.Generation;
                    row["PersonalLoyalty"] = (int)person.PersonalLoyalty;
                    row["Ambition"] = (int)person.Ambition;
                    row["Qualification"] = (int)person.Qualification;
                    row["ValuationOnGovernment"] = (int)person.ValuationOnGovernment;
                    row["StrategyTendency"] = (int)person.StrategyTendency;
                    row["OldFactionID"] = person.OldFactionID;
                    row["ProhibitedFactionID"] = person.ProhibitedFactionID;
                    row["RewardFinished"] = person.RewardFinished;
                    row["WorkKind"] = person.WorkKind;
                    row["OldWorkKind"] = person.OldWorkKind;
                    row["TrainingMilitaryID"] = -1;
                    row["RecruitmentMilitaryID"] = person.RecruitmentMilitary == null ? -1 : person.RecruitmentMilitary.ID;
                    row["ArrivingDays"] = person.ArrivingDays;
                    row["TaskDays"] = person.TaskDays;
                    row["OutsideTask"] = person.OutsideTask;
                    row["OutsideDestination"] = StaticMethods.SaveToString(person.OutsideDestination);
                    row["ConvincingPerson"] = (person.ConvincingPerson != null) ? person.ConvincingPerson.ID : -1;
                    row["InformationKind"] = person.InformationKindID;
                    row["ClosePersons"] = StaticMethods.SaveToString(person.ClosePersons);
                    row["HatedPersons"] = StaticMethods.SaveToString(person.HatedPersons);
                    row["Skills"] = person.Skills.SaveToString();
                    row["PersonalTitle"] = (person.PersonalTitle != null) ? person.PersonalTitle.ID : -1;
                    row["CombatTitle"] = (person.CombatTitle != null) ? person.CombatTitle.ID : -1;
                    row["StudyingTitle"] = (person.StudyingTitle != null) ? person.StudyingTitle.ID : -1;
                    row["Stunts"] = person.Stunts.SaveToString();
                    row["StudyingStunt"] = (person.StudyingStunt != null) ? person.StudyingStunt.ID : -1;
                    row["huaiyun"] = person.huaiyun;
                    row["faxianhuaiyun"] = person.faxianhuaiyun;
                    row["huaiyuntianshu"] = person.huaiyuntianshu;
                    row["suoshurenwu"] = person.suoshurenwu;
                    row["WaitForFeizi"] = (person.WaitForFeiZi != null) ? person.WaitForFeiZi.ID : -1;
                    row["WaitForFeiziPeriod"] = person.WaitForFeiZiPeriod;
                    row["PreferredTroopPersons"] = person.preferredTroopPersons.SaveToString();
                    row["YearJoin"] = person.YearJoin;
                    row["TroopDamageDealt"] = person.TroopDamageDealt;
                    row["TroopBeDamageDealt"] = person.TroopBeDamageDealt;
                    row["ArchitectureDamageDealt"] = person.ArchitectureDamageDealt;
                    row["RebelCount"] = person.RebelCount;
                    row["ExecuteCount"] = person.ExecuteCount;
                    row["FleeCount"] = person.FleeCount;
                    row["CaptiveCount"] = person.CaptiveCount;
                    row["HeldCaptiveCount"] = person.HeldCaptiveCount;
                    row["StratagemSuccessCount"] = person.StratagemSuccessCount;
                    row["StratagemFailCount"] = person.StratagemFailCount;
                    row.EndEdit();
                    dataSet.Tables["Person"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Person");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Region", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Region");
                dataSet.Tables["Region"].Rows.Clear();
                foreach (Region region in this.Regions)
                {
                    row = dataSet.Tables["Region"].NewRow();
                    row.BeginEdit();
                    row["ID"] = region.ID;
                    row["Name"] = region.Name;
                    row["States"] = region.States.SaveToString();
                    row["RegionCore"] = (region.RegionCore != null) ? region.RegionCore.ID : -1;
                    row.EndEdit();
                    dataSet.Tables["Region"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Region");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from State", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "State");
                dataSet.Tables["State"].Rows.Clear();
                foreach (State state in this.States)
                {
                    row = dataSet.Tables["State"].NewRow();
                    row.BeginEdit();
                    row["ID"] = state.ID;
                    row["Name"] = state.Name;
                    row["ContactStates"] = state.ContactStates.SaveToString();
                    row["StateAdmin"] = (state.StateAdmin != null) ? state.StateAdmin.ID : -1;
                    row.EndEdit();
                    dataSet.Tables["State"].Rows.Add(row);
                }
                adapter.Update(dataSet, "State");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from Treasure", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Treasure");
                dataSet.Tables["Treasure"].Rows.Clear();
                foreach (Treasure treasure in this.Treasures)
                {
                    row = dataSet.Tables["Treasure"].NewRow();
                    row.BeginEdit();
                    row["ID"] = treasure.ID;
                    row["Name"] = treasure.Name;
                    row["Pic"] = treasure.Pic;
                    row["Available"] = treasure.Available;
                    row["AppearYear"] = treasure.AppearYear;
                    row["Worth"] = treasure.Worth;
                    row["Description"] = treasure.Description;
                    row["BelongedPerson"] = (treasure.BelongedPerson != null) ? treasure.BelongedPerson.ID : -1;
                    row["HidePlace"] = (treasure.HidePlace != null) ? treasure.HidePlace.ID : -1;
                    row["Influences"] = treasure.Influences.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Treasure"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Treasure");
                dataSet.Clear();

                adapter = new OleDbDataAdapter("Select * from YearTable", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "YearTable");
                dataSet.Tables["YearTable"].Rows.Clear();
                foreach (YearTableEntry yt in this.YearTable)
                {
                    row = dataSet.Tables["YearTable"].NewRow();
                    row.BeginEdit();
                    row["ID"] = yt.ID;
                    row["GYear"] = yt.Date.Year;
                    row["GMonth"] = yt.Date.Month;
                    row["GDay"] = yt.Date.Day;
                    string factionStr = "";
                    foreach (Faction f in yt.Factions)
                    {
                        factionStr += f.ID + " ";
                    }
                    row["Faction"] = factionStr;
                    row["Content"] = yt.Content;
                    row["IsGloballyKnown"] = yt.IsGloballyKnown;
                    row.EndEdit();
                    dataSet.Tables["YearTable"].Rows.Add(row);
                }
                adapter.Update(dataSet, "YearTable");
                dataSet.Clear();

                //try
                //{
                adapter = new OleDbDataAdapter("Select * from Event", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Event");
                dataSet.Tables["Event"].Rows.Clear();
                foreach (Event e in this.AllEvents)
                {
                    row = dataSet.Tables["Event"].NewRow();
                    row.BeginEdit();
                    row["ID"] = e.ID;
                    row["Name"] = e.Name;
                    row["Repeatable"] = e.repeatable;
                    row["AfterEventHappened"] = e.AfterEventHappened;
                    row["Chance"] = e.happenChance;
                    row["PersonId"] = e.SavePersonIdToString();
                    row["PersonCond"] = e.SavePersonCondToString();
                    row["ArchitectureID"] = e.architecture.SaveToString();
                    row["ArchitectureCond"] = e.SaveArchitecureCondToString();
                    row["FactionID"] = e.faction.SaveToString();
                    row["FactionCond"] = e.SaveFactionCondToString();
                    row["Dialog"] = e.SaveDialogToString();
                    row["Effect"] = e.SaveEventEffectToString();
                    row["ArchitectureEffect"] = e.SaveArchitectureEffectToString();
                    row["FactionEffect"] = e.SaveFactionEffectToString();
                    row.EndEdit();
                    dataSet.Tables["Event"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Event");
                dataSet.Clear();
                //}
                //catch
                //{
                //}

                adapter = new OleDbDataAdapter("Select * from GameData", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "GameData");
                row = dataSet.Tables["GameData"].NewRow();
                row.BeginEdit();
                row["CurrentPlayer"] = (this.CurrentPlayer != null) ? this.CurrentPlayer.ID : -1;
                row["PlayerList"] = this.PlayerFactions.SaveToString();
                row["FactionQueue"] = this.Factions.SaveQueueToString();
                row["FireTable"] = this.FireTable.SaveToString();
                row["NoFoodTable"] = this.NoFoodDictionary.SaveToString();
                row["DaySince"] = this.DaySince;
                row.EndEdit();
                dataSet.Tables["GameData"].Rows.Add(row);
                adapter.Update(dataSet, "GameData");
                dataSet.Clear();
                adapter = new OleDbDataAdapter("Select * from GameSurvey", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "GameSurvey");
                row = dataSet.Tables["GameSurvey"].NewRow();
                row.BeginEdit();
                row["Title"] = this.ScenarioTitle;
                row["Description"] = this.ScenarioDescription;
                row["GYear"] = (short)this.Date.Year;
                row["GMonth"] = (short)this.Date.Month;
                row["GDay"] = (short)this.Date.Day;
                DateTime now = DateTime.Now;
                row["SaveTime"] = string.Concat(new object[] { now.Year, "/", now.Month, "/", now.Day, " ", now.ToLongTimeString() });
                row["PlayerInfo"] = this.GetPlayerInfo();
                row["JumpPosition"] = StaticMethods.SaveToString(new Point?(this.ScenarioMap.JumpPosition));
                row.EndEdit();
                dataSet.Tables["GameSurvey"].Rows.Add(row);
                adapter.Update(dataSet, "GameSurvey");
                dataSet.Clear();
                if (this.OnAfterSaveScenario != null)
                {
                    this.OnAfterSaveScenario(this);
                }
            }
            catch (Exception)
            {
                //try to free as many memory as possible at this critical state
                foreach (MilitaryKind kind in this.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
                {
                    kind.Textures.Dispose();
                }
                foreach (Animation a in this.GameCommonData.AllTroopAnimations.Animations.Values)
                {
                    a.disposeTexture();
                }
                foreach (Architecture a in this.Architectures)
                {
                    if (a.CaptionTexture != null)
                    {
                        a.CaptionTexture.Dispose();
                        a.CaptionTexture = null;
                    }
                }
                foreach (ArchitectureKind k in this.GameCommonData.AllArchitectureKinds.ArchitectureKinds.Values)
                {
                    if (k.Texture != null)
                    {
                        k.Texture.Dispose();
                        k.Texture = null;
                    }
                }
                foreach (Treasure t in this.Treasures)
                {
                    t.disposeTexture();
                }
                foreach (TerrainDetail t in this.GameCommonData.AllTerrainDetails.TerrainDetails.Values)
                {
                    if (t.Textures != null)
                    {
                        foreach (Texture u in t.Textures.BasicTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomEdgeTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomLeftCornerTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomLeftTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomRightCornerTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomRightTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.BottomTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.CentreTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.LeftEdgeTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.LeftTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.RightEdgeTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.RightTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.LeftEdgeTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopEdgeTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopLeftCornerTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopLeftTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopRightCornerTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopRightTextures)
                        {
                            u.Dispose();
                        }
                        foreach (Texture u in t.Textures.TopTextures)
                        {
                            u.Dispose();
                        }
                    }
                    t.Textures = null;
                }

                GC.Collect();
                return false;
            }
            return true;
        }


        public bool SaveScenarioMapToDatabase(string connectionString)  //地图编辑器用
        {
            OleDbConnection selectConnection = new OleDbConnection(connectionString);
            DataSet dataSet = new DataSet();
            DataRow row = null;
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Map", selectConnection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Fill(dataSet, "Map");
            dataSet.Tables["Map"].Rows[0].Delete();
            row = dataSet.Tables["Map"].NewRow();

            row.BeginEdit();
            row["TileWidth"] = this.ScenarioMap.TileWidth;
            row["DimensionX"] = this.ScenarioMap.MapDimensions.X;
            row["DimensionY"] = this.ScenarioMap.MapDimensions.Y;
            row["MapData"] = this.ScenarioMap.SaveToString();
            row["FileName"] = this.ScenarioMap.MapName;
            row["kuaishu"] = this.ScenarioMap.NumberOfTiles;
            row["meikuaidexiaokuaishu"] = this.ScenarioMap.NumberOfSquaresInEachTile;
            row["useSimpleArchImages"] = this.ScenarioMap.UseSimpleArchImages;
            row.EndEdit();



            dataSet.Tables["Map"].Rows.Add(row);
            adapter.Update(dataSet, "Map");
            dataSet.Clear();


            /*
            if (this.OnAfterSaveScenario != null)
            {
                this.OnAfterSaveScenario(this);
            }
            */
            return true;
        }

        public void SetMapTileArchitecture(Architecture architecture)
        {
            foreach (Point point in architecture.ArchitectureArea.Area)
            {
                this.MapTileData[point.X, point.Y].TileArchitecture = architecture;
            }
            if (!architecture.AutoRefillFoodInLongViewArea)
            {
                architecture.AddBaseSupplyingArchitecture();
            }
            foreach (Point point in architecture.ViewArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.MapTileData[point.X, point.Y].AddHighViewingArchitecture(architecture);
                }
            }
            foreach (Point point in architecture.LongViewArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.MapTileData[point.X, point.Y].AddViewingArchitecture(architecture);
                }
            }
        }

        public void SetMapTileTroop(Troop troop)
        {
            if (this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TroopCount > 0)
            {
                TileData data1 = this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y];
                data1.TroopCount--;
            }
            if (this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TileTroop == troop)
            {
                this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TileTroop = null;
            }
            TileData data2 = this.MapTileData[troop.Position.X, troop.Position.Y];
            data2.TroopCount++;
            if (this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop == null)
            {
                this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop = troop;
            }
        }

        public void SetPenalizedMapDataByArea(GameArea gameArea, int cost)
        {
            foreach (Point point in gameArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.PenalizedMapData[point.X, point.Y] = cost;
                }
            }
            this.SetPenalizedMapDataByPosition(gameArea.Centre, 0xdac);
        }

        public void SetPenalizedMapDataByPosition(Point position, int cost)
        {
            this.PenalizedMapData[position.X, position.Y] = cost;
        }

        public void SetPlayerFactionList(GameObjectList factions)
        {
            this.PlayerFactions.Clear();
            foreach (Faction faction in factions)
            {
                this.PlayerFactions.Add(faction);
            }
        }

        public void SetPositionOnFire(Point position)
        {
            this.FireTable.AddPosition(position);
            this.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.火焰, position, true);
        }

        public void YearPassedEvent()
        {
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.YearEvent();
            }
        }

        public void YearStartingEvent()
        {
        }

        public bool Animating
        {
            get
            {
                return this.Troops.HasAnimatingTroop;
            }
        }

        public Person NeutralPerson
        {
            get
            {
                if (this.neutralPerson == null)
                {
                    this.neutralPerson = this.Persons.GetGameObject(0x1b5f) as Person;
                }
                return this.neutralPerson;
            }
        }

        public bool NoCurrentPlayer
        {
            get
            {
                return (this.CurrentPlayer == null);
            }
        }

        public TroopAnimation TroopAnimations
        {
            get
            {
                return this.GameCommonData.TroopAnimations;
            }
        }

        public Architecture huangdisuozaijianzhu()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai) return a; 
            }
            return null;
        }

        public bool youhuangdi()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai) return true; 
            }
            return false ;
        }

        public delegate void AfterLoadScenario(GameScenario scenario);

        public delegate void AfterSaveScenario(GameScenario scenario);

        public delegate void NewFactionAppear(Faction faction);



        internal void BecomeNoEmperor()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai)
                {
                    a.huangdisuozai = false;
                }
            }

            Person neutralPerson = this.NeutralPerson;
            if (neutralPerson == null)
            {
                if (this.CurrentPlayer != null)
                {
                    neutralPerson = this.CurrentPlayer.Leader;
                }
                else
                {
                    if (this.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (this.Factions[0] as Faction).Leader;
                }
            }

            this.GameScreen.xianshishijiantupian(neutralPerson, "汉朝", "FactionDestroy", "shilimiewang.jpg", "shilimiewang.wma", true);

        }

        public YearTable getFactionYearTable(Faction f)
        {
            YearTable result = new YearTable();
            foreach (YearTableEntry i in this.YearTable)
            {
                if (i.IsGloballyKnown || i.Factions.GameObjects.Contains(f) || GlobalVariables.SkyEye)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}

