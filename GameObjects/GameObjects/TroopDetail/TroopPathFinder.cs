namespace GameObjects.TroopDetail
{
    using GameObjects;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    internal class TroopPathFinder
    {
        private PathSearcher conflictionPathSearcher;
        private Point CurrentDestination;
        private Point End;
        private TierPathFinder firstTierPathFinder;
        private AreaSearcher movableAreaSearcher;
        private TierPathFinder secondTierPathFinder;
        private TierPathFinder simplePathFinder;
        private Point Start;
        private TierPathFinder thirdTierPathFinder;
        private Troop troop;
        private AreaSearcher troopAreaSearcher;

        public TroopPathFinder(Troop troop)
        {
            this.troop = troop;
            this.firstTierPathFinder = new TierPathFinder();
            this.secondTierPathFinder = new TierPathFinder();
            this.thirdTierPathFinder = new TierPathFinder();
            this.simplePathFinder = new TierPathFinder();
            this.movableAreaSearcher = new AreaSearcher();
            this.troopAreaSearcher = new AreaSearcher();
            this.conflictionPathSearcher = new PathSearcher();
            this.firstTierPathFinder.OnGetCost += new TierPathFinder.GetCost(this.firstTierPathFinder_OnGetCost);
            this.firstTierPathFinder.OnGetPenalizedCost += new TierPathFinder.GetPenalizedCost(this.firstTierPathFinder_OnGetPenalizedCost);
            this.secondTierPathFinder.OnGetCost += new TierPathFinder.GetCost(this.secondTierPathFinder_OnGetCost);
            this.thirdTierPathFinder.OnGetCost += new TierPathFinder.GetCost(this.thirdTierPathFinder_OnGetCost);
            this.simplePathFinder.OnGetCost += new TierPathFinder.GetCost(this.simplePathFinder_OnGetCost);
            this.movableAreaSearcher.OnGetCost += new AreaSearcher.GetCost(this.movableAreaSearcher_OnGetCost);
            this.movableAreaSearcher.OnCompare += new AreaSearcher.Compare(this.movableAreaSearcher_OnCompare);
            this.troopAreaSearcher.OnGetCost += new AreaSearcher.GetCost(this.troopAreaSearcher_OnGetCost);
            this.conflictionPathSearcher.OnCheckPosition += new PathSearcher.CheckPosition(this.conflictionPathSearcher_OnCheckPosition);
        }

        private bool BuildFirstTierPath(Point start, Point end)
        {
            this.troop.ClearFirstTierPath();
            if (end == this.troop.Destination)
            {
                this.troop.ClearSecondTierPath();
            }
            if (this.firstTierPathFinder.GetPath(start, end))
            {
                this.troop.FirstTierPath = new List<Point>();
                this.firstTierPathFinder.SetPath(this.troop.FirstTierPath);
            }
            else
            {
                this.troop.Destination = this.troop.Position;
            }
            return true;
        }

        private List<Point> BuildFirstTierSimulatePath(Point start, Point end)
        {
            if (this.firstTierPathFinder.GetPath(start, end))
            {
                List<Point> path = new List<Point>();
                this.firstTierPathFinder.SetPath(path);
                return path;
            }
            return null;
        }

        private bool BuildModifyFirstTierPath(Point start, Point end, List<Point> middlePath)
        {
            if (this.firstTierPathFinder.GetPath(start, end))
            {
                this.firstTierPathFinder.SetPath(middlePath);
                return true;
            }
            middlePath = null;
            return false;
        }

        private PathResult conflictionPathSearcher_OnCheckPosition(Point position, List<Point> middlePath)
        {
            TroopList list = new TroopList();
            TroopList list2 = new TroopList();
            foreach (Troop troop in this.troop.BelongedFaction.KnownTroops.Values)
            {
                if (!troop.IsFriendly(this.troop.BelongedFaction))
                {
                    switch (this.troop.HostileAction)
                    {
                        case HostileActionKind.EvadeEffect:
                            if (troop.OffenceArea.HasPoint(position))
                            {
                                list.Add(troop);
                            }
                            break;

                        case HostileActionKind.EvadeView:
                            if (troop.ViewArea.HasPoint(position))
                            {
                                list.Add(troop);
                            }
                            break;
                    }
                }
                else if (troop.Position == position)
                {
                    list2.Add(troop);
                }
            }
            if ((list.Count > 0) || (list2.Count > 0))
            {
                bool flag = false;
                foreach (Troop troop in list)
                {
                    switch (this.troop.HostileAction)
                    {
                        case HostileActionKind.NotCare:
                            this.troop.Scenario.SetPenalizedMapDataByPosition(troop.Position, 0xdac);
                            break;

                        case HostileActionKind.Attack:
                            this.troop.Scenario.SetPenalizedMapDataByPosition(troop.Position, 0xdac);
                            break;

                        case HostileActionKind.EvadeEffect:
                            this.troop.Scenario.SetPenalizedMapDataByArea(troop.OffenceArea, 1);
                            break;

                        case HostileActionKind.EvadeView:
                            this.troop.Scenario.SetPenalizedMapDataByArea(troop.ViewArea, 1);
                            break;
                    }
                }
                /*foreach (Troop troop in list2)
                {
                    switch (this.troop.FriendlyAction)
                    {
                    }
                }*/
                flag = this.ModifyFirstTierPath(this.troop.Position, this.troop.FirstTierDestination, middlePath);
                foreach (Troop troop in list)
                {
                    switch (this.troop.HostileAction)
                    {
                        case HostileActionKind.NotCare:
                            this.troop.Scenario.ClearPenalizedMapDataByPosition(troop.Position);
                            break;

                        case HostileActionKind.Attack:
                            this.troop.Scenario.ClearPenalizedMapDataByPosition(troop.Position);
                            break;

                        case HostileActionKind.EvadeEffect:
                            this.troop.Scenario.ClearPenalizedMapDataByArea(troop.OffenceArea);
                            break;

                        case HostileActionKind.EvadeView:
                            this.troop.Scenario.ClearPenalizedMapDataByArea(troop.ViewArea);
                            break;
                    }
                }
                /*foreach (Troop troop in list2)
                {
                    switch (this.troop.FriendlyAction)
                    {
                    }
                }*/
                if (flag)
                {
                    return PathResult.Found;
                }
                return PathResult.NotFound;
            }
            return PathResult.Aborted;
        }

        public void FindFirstTierPath(Point start, Point end, List<Point> list)
        {
            this.Start = start;
            this.End = end;
            this.troop.MovabilityLeft = this.troop.Movability;
            if (this.troop.GetPossibleMoveByPosition(end) >= 0xdac)
            {
                if (this.movableAreaSearcher.Search(end, start, GameObjectConsts.FindMovableDestinationMaxCheckCount))
                {
                    if (this.CurrentDestination == this.End)
                    {
                        this.troop.MovabilityLeft = -1;
                        return;
                    }
                    if (this.firstTierPathFinder.GetPath(this.Start, this.CurrentDestination))
                    {
                        this.firstTierPathFinder.SetPath(list);
                    }
                }
                this.troop.MovabilityLeft = -1;
            }
            else
            {
                if (this.firstTierPathFinder.GetPath(this.Start, this.End))
                {
                    this.firstTierPathFinder.SetPath(list);
                }
                this.troop.MovabilityLeft = -1;
            }
        }

        private int firstTierPathFinder_OnGetCost(Point position, bool oblique, int DirectionCost)
        {
            return this.troop.GetCostByPosition(position, oblique, DirectionCost);
        }

        private int firstTierPathFinder_OnGetPenalizedCost(Point position)
        {
            if (this.troop.Scenario.PositionOutOfRange(position)) return 0;
            return this.troop.Scenario.PenalizedMapData[position.X, position.Y];
        }

        public GameArea GetDayArea(int Days)
        {
            return this.firstTierPathFinder.GetDayArea(this.troop, Days);
        }

        public bool GetFirstTierPath(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
            if (this.troop.GetPossibleMoveByPosition(end) >= 0xdac)
            {
                if (this.movableAreaSearcher.Search(end, start, GameObjectConsts.FindMovableDestinationMaxCheckCount))
                {
                    if (this.CurrentDestination == this.End)
                    {
                        this.troop.FirstTierPath = new List<Point>();
                        return true;
                    }
                    return this.BuildFirstTierPath(start, this.CurrentDestination);
                }
                return false;
            }
            return this.BuildFirstTierPath(start, end);
        }

        public List<Point> GetFirstTierSimulatePath(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
            if (this.troop.GetPossibleMoveByPosition(end) >= 0xdac)
            {
                if (this.movableAreaSearcher.Search(end, start, GameObjectConsts.FindMovableDestinationMaxCheckCount))
                {
                    return this.BuildFirstTierSimulatePath(start, this.CurrentDestination);
                }
                return null;
            }
            return this.BuildFirstTierSimulatePath(start, end);
        }

        public bool GetPath(Point start, Point end)
        {
            if (Troop.LaunchThirdPathFinder(start, end))
            {
                return this.GetThirdTierPath(start, end);
            }
            if (Troop.LaunchSecondPathFinder(start, end))
            {
                return this.GetSecondTierPath(start, end);
            }
            return this.GetFirstTierPath(start, end);
        }

        public bool GetSecondTierPath(Point start, Point end)
        {
            this.troop.ClearSecondTierPath();
            if (end == this.troop.Destination)
            {
                this.troop.ClearThirdTierPath();
            }
            Point point = new Point(start.X / GameObjectConsts.SecondTierSquareSize, start.Y / GameObjectConsts.SecondTierSquareSize);
            Point point2 = new Point(end.X / GameObjectConsts.SecondTierSquareSize, end.Y / GameObjectConsts.SecondTierSquareSize);
            this.troop.SecondTierPath = this.troop.BelongedFaction.GetSecondTierKnownPath(point, point2);
            if (this.troop.SecondTierPath == null)
            {
                if (this.secondTierPathFinder.GetPath(point, point2))
                {
                    this.troop.SecondTierPath = new List<Point>();
                    this.secondTierPathFinder.SetPath(this.troop.SecondTierPath);
                    this.troop.BelongedFaction.AddSecondTierKnownPath(this.troop.SecondTierPath);
                    return true;
                }
                this.troop.Destination = this.troop.Position;
                this.troop.ClearThirdTierPath();
            }
            return false;
        }

        public List<Point> GetSimplePath(Point start, Point end)
        {
            List<Point> path = new List<Point>();
            if (this.simplePathFinder.GetPath(start, end))
            {
                path = new List<Point>();
                this.simplePathFinder.SetPath(path);
                return path;
            }
            return path;
        }

        public bool GetThirdTierPath(Point start, Point end)
        {
            this.troop.ClearThirdTierPath();
            Point point = new Point(start.X / GameObjectConsts.ThirdTierSquareSize, start.Y / GameObjectConsts.ThirdTierSquareSize);
            Point point2 = new Point(end.X / GameObjectConsts.ThirdTierSquareSize, end.Y / GameObjectConsts.ThirdTierSquareSize);
            this.troop.ThirdTierPath = this.troop.BelongedFaction.GetThirdTierKnownPath(point, point2);
            if (this.troop.ThirdTierPath == null)
            {
                if (this.thirdTierPathFinder.GetPath(point, point2))
                {
                    this.troop.ThirdTierPath = new List<Point>();
                    this.thirdTierPathFinder.SetPath(this.troop.ThirdTierPath);
                    this.troop.BelongedFaction.AddThirdTierKnownPath(this.troop.ThirdTierPath);
                    return true;
                }
                this.troop.Destination = this.troop.Position;
            }
            return false;
        }

        private bool ModifyFirstTierPath(Point start, Point end, List<Point> middlePath)
        {
            this.Start = start;
            this.End = end;
            if (this.troop.GetPossibleMoveByPosition(end) >= 0xdac)
            {
                return (this.movableAreaSearcher.Search(end, start, GameObjectConsts.FindMovableDestinationMaxCheckCount) && this.BuildModifyFirstTierPath(start, this.CurrentDestination, middlePath));
            }
            return this.BuildModifyFirstTierPath(start, end, middlePath);
        }

        public bool ModifyPathByConfliction(Troop troop, int StartingIndex)
        {
            return this.conflictionPathSearcher.Search(troop, StartingIndex, troop.ViewRadius);
        }

        private bool movableAreaSearcher_OnCompare(Point position)
        {
            if (this.troop.GetPossibleMoveByPosition(position) >= 0xdac)
            {
                return false;
            }
            if (this.End == this.troop.Destination)
            {
                this.troop.Destination = position;
            }
            this.CurrentDestination = position;
            return true;
        }

        private int movableAreaSearcher_OnGetCost(Point position, bool oblique)
        {
            return this.troop.GetCostByPosition(position, false, -1);
        }

        private int secondTierPathFinder_OnGetCost(Point position, bool oblique, int DirectionCost)
        {
            return this.troop.GetCostBySecondTierPosition(position);
        }

        private int simplePathFinder_OnGetCost(Point position, bool Oblique, int DirectionCost)
        {
            return 1;
        }

        private int thirdTierPathFinder_OnGetCost(Point position, bool oblique, int DirectionCost)
        {
            return this.troop.GetCostByThirdTierPosition(position);
        }

        private int troopAreaSearcher_OnGetCost(Point position, bool oblique)
        {
            return this.troop.GetCostByPosition(position, oblique, -1);
        }
    }
}

