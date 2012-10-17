namespace GameObjects.TroopDetail
{
    using GameObjects;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class TierPathFinder
    {
        private int BottomSquareCost;
        private Dictionary<Point, GameSquare> closeDictionary = new Dictionary<Point, GameSquare>();
        private List<GameSquare> closeList = new List<GameSquare>();
        private int LeftSquareCost;
        private Dictionary<Point, GameSquare> openDictionary = new Dictionary<Point, GameSquare>();
        private List<GameSquare> openList = new List<GameSquare>();
        private int RightSquareCost;
        private int TopSquareCost;

        public event GetCost OnGetCost;

        public event GetPenalizedCost OnGetPenalizedCost;

        private GameSquare AddToCloseList()
        {
            GameSquare item = this.RemoveFromOpenList();
            if ((item != null) && !this.IsInCloseList(item.Position))
            {
                this.closeList.Add(item);
                this.closeDictionary.Add(item.Position, item);
            }
            return item;
        }

        private void AddToCloseList(GameSquare square)
        {
            if (!this.closeDictionary.ContainsKey(square.Position))
            {
                this.closeList.Add(square);
                this.closeDictionary.Add(square.Position, square);
            }
        }

        private void AddToOpenList(GameSquare square)
        {
            if (!this.IsInOpenList(square.Position))
            {
                this.openList.Add(square);
                int x = this.openList.Count - 1;
                square.Index = x;
                for (int i = (x - 1) / 2; this.openList[x].F < this.openList[i].F; i = (x - 1) / 2)
                {
                    this.SwapSquare(x, i, this.openList);
                    if (i == 0)
                    {
                        break;
                    }
                    x = i;
                }
                this.openDictionary.Add(square.Position, square);
            }
        }

        private void CheckAdjacentSquares(GameSquare currentSquare, Point end)
        {
            int num = end.X - currentSquare.Position.X;
            int num2 = end.Y - currentSquare.Position.Y;
            int num3 = (num > 0) ? 1 : -1;
            int num4 = (num2 > 0) ? 1 : -1;
            if (num2 == 0)
            {
                num4 = 0;
            }
            else if (Math.Abs((decimal) (num / num2)) > 2M)
            {
                num4 = 0;
            }
            if (num == 0)
            {
                num3 = 0;
            }
            else if (Math.Abs((decimal) (num2 / num)) > 2M)
            {
                num3 = 0;
            }
            switch (num3)
            {
                case -1:
                    switch (num4)
                    {
                        case -1:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            break;

                        case 0:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            break;

                        case 1:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            break;
                    }
                    break;

                case 0:
                    switch (num4)
                    {
                        case -1:
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            break;

                        case 0:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            break;

                        case 1:
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            break;
                    }
                    break;

                case 1:
                    switch (num4)
                    {
                        case -1:
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            break;

                        case 0:
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            break;

                        case 1:
                            this.RightSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end, -1);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end, -1);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end, -1);
                            this.TopSquareCost = this.MakeSquare(currentSquare, false, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end, -1);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.RightSquareCost) ? this.BottomSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y + 1), end, (this.BottomSquareCost > this.LeftSquareCost) ? this.BottomSquareCost : this.LeftSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.RightSquareCost) ? this.TopSquareCost : this.RightSquareCost);
                            this.MakeSquare(currentSquare, true, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y - 1), end, (this.TopSquareCost > this.LeftSquareCost) ? this.TopSquareCost : this.LeftSquareCost);
                            break;
                    }
                    break;
            }
        }

        private int GetCostByPosition(Point position, bool oblique, int DirectionCost)
        {
            if (this.OnGetCost != null)
            {
                return this.OnGetCost(position, oblique, DirectionCost);
            }
            return 0xdac;
        }

        public GameArea GetDayArea(Troop troop, int Days)
        {
            GameArea area = new GameArea();
            this.openDictionary.Clear();
            this.closeDictionary.Clear();
            this.openList.Clear();
            this.closeList.Clear();
            GameSquare square = new GameSquare();
            square.Position = troop.Position;
            this.AddToCloseList(square);
            int num = troop.Movability * Days;
            int movabilityLeft = troop.MovabilityLeft;
            int num3 = troop.RealMovability * Days;
            troop.MovabilityLeft = num;
            int num4 = 0;
            do
            {
                try
                {
                    this.CheckAdjacentSquares(square, troop.Position);
                    if (this.openList.Count == 0)
                    {
                        break;
                    }
                    square = this.AddToCloseList();
                    if (square == null)
                    {
                        break;
                    }
                    if (num >= square.G)
                    {
                        if (!troop.Scenario.PositionIsTroop(square.Position))
                        {
                            area.AddPoint(square.Position);
                        }
                        num4 = 0;
                    }
                    else
                    {
                        num4++;
                    }
                }
                catch (OutOfMemoryException)
                {
                    openList.Clear();
                    closeList.Clear();
                    return area;
                }
            }
            while (num4 < (num3 * 2));
            troop.MovabilityLeft = movabilityLeft;
            return area;
        }

        public bool GetPath(Point start, Point end)
        {
            bool flag = false;
            this.openDictionary.Clear();
            this.closeDictionary.Clear();
            this.openList.Clear();
            this.closeList.Clear();
            GameSquare square = new GameSquare();
            square.Position = start;
            this.AddToCloseList(square);
            if (start == end)
            {
                return true;
            }
            do
            {
                try
                {
                    this.CheckAdjacentSquares(square, end);
                    if (this.openList.Count == 0)
                    {
                        break;
                    }
                    square = this.AddToCloseList();
                    if (square == null)
                    {
                        break;
                    }
                    flag = square.Position == end;
                }
                catch (OutOfMemoryException)
                {
                    openList.Clear();
                    closeList.Clear();
                    return false;
                }
            }
            while (!flag && (square.RealG < 0xdac));
            return flag;
        }

        private int GetPenalizedCostByPosition(Point position)
        {
            if (this.OnGetPenalizedCost != null)
            {
                return this.OnGetPenalizedCost(position);
            }
            return 0;
        }

        private GameSquare GetSquareFromOpenList(Point position)
        {
            if (this.openDictionary.ContainsKey(position))
            {
                return this.openDictionary[position];
            }
            return null;
        }

        private bool IsInCloseList(Point position)
        {
            return this.closeDictionary.ContainsKey(position);
        }

        private bool IsInOpenList(Point position)
        {
            return this.openDictionary.ContainsKey(position);
        }

        private int MakeSquare(GameSquare currentSquare, bool oblique, Point position, Point end, int DirectionCost)
        {
            int num = this.GetCostByPosition(position, oblique, DirectionCost);
            if (!this.IsInCloseList(position))
            {
                int num2;
                if (num >= 0xdac)
                {
                    return num;
                }
                GameSquare square = new GameSquare();
                if (oblique)
                {
                    num2 = currentSquare.RealG + (7 * num);
                }
                else
                {
                    num2 = currentSquare.RealG + (5 * num);
                }
                GameSquare squareFromOpenList = this.GetSquareFromOpenList(position);
                if (squareFromOpenList == null)
                {
                    square.Parent = currentSquare;
                    square.Position = position;
                    square.PenalizedCost = this.GetPenalizedCostByPosition(position);
                    square.H = (Math.Abs((int) (end.X - position.X)) + Math.Abs((int) (end.Y - position.Y))) * 5;
                    square.RealG = num2;
                    this.AddToOpenList(square);
                }
                else if (num2 < squareFromOpenList.RealG)
                {
                    squareFromOpenList.Parent = currentSquare;
                    squareFromOpenList.RealG = num2;
                    this.UpResortOpenList(squareFromOpenList, squareFromOpenList.Index);
                }
            }
            return num;
        }

        private GameSquare RemoveFromOpenList()
        {
            if (this.openList.Count <= 0)
            {
                return null;
            }
            this.SwapSquare(0, this.openList.Count - 1, this.openList);
            GameSquare square = this.openList[this.openList.Count - 1];
            square.Index = -1;
            this.openList.RemoveAt(this.openList.Count - 1);
            this.openDictionary.Remove(square.Position);
            int x = 0;
            int y = x;
            while (true)
            {
                if (((x * 2) + 2) < this.openList.Count)
                {
                    if (this.openList[x].F > this.openList[(x * 2) + 1].F)
                    {
                        y = (x * 2) + 1;
                    }
                    if (this.openList[y].F > this.openList[y + 1].F)
                    {
                        y++;
                    }
                }
                else if ((((x * 2) + 1) < this.openList.Count) && (this.openList[x].F > this.openList[(x * 2) + 1].F))
                {
                    y = (x * 2) + 1;
                }
                if (y == x)
                {
                    return square;
                }
                this.SwapSquare(x, y, this.openList);
                x = y;
            }
        }

        public void SetPath(List<Point> path)
        {
            path.Clear();
            List<Point> list = new List<Point>();
            GameSquare parent = this.closeList[this.closeList.Count - 1];
            do
            {
                list.Add(parent.Position);
                parent = parent.Parent;
            }
            while (parent != null);
            for (int i = 1; i <= list.Count; i++)
            {
                path.Add(list[list.Count - i]);
            }
        }

        private void SwapSquare(int x, int y, List<GameSquare> list)
        {
            GameSquare square = list[x];
            list[x] = list[y];
            list[y] = square;
            list[x].Index = x;
            list[y].Index = y;
        }

        private void UpResortOpenList(GameSquare square, int index)
        {
            if (index != 0)
            {
                int x = index;
                int y = (x - 1) / 2;
                while (true)
                {
                    if (this.openList[x].F >= this.openList[y].F)
                    {
                        return;
                    }
                    this.SwapSquare(x, y, this.openList);
                    if (y == 0)
                    {
                        return;
                    }
                    x = y;
                    y = (x - 1) / 2;
                }
            }
        }

        public delegate int GetCost(Point position, bool Oblique, int DirectionCost);

        public delegate int GetPenalizedCost(Point position);
    }
}

