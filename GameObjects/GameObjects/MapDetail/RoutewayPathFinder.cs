namespace GameObjects.MapDetail
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class RoutewayPathFinder
    {
        private int BottomSquareCost;
        private Dictionary<Point, RoutewaySquare> closeDictionary = new Dictionary<Point, RoutewaySquare>();
        private List<RoutewaySquare> closeList = new List<RoutewaySquare>();
        public float ConsumptionMax = 0.7f;
        private int LeftSquareCost;
        public bool MultipleWaterCost;
        public bool MustUseWater;
        public Architecture startingArchitecture, targetArchitecture;
        private Dictionary<Point, RoutewaySquare> openDictionary = new Dictionary<Point, RoutewaySquare>();
        private List<RoutewaySquare> openList = new List<RoutewaySquare>();
        private int RightSquareCost;
        private int TopSquareCost;

        public event GetCost OnGetCost;

        public event GetPenalizedCost OnGetPenalizedCost;

        private RoutewaySquare AddToCloseList()
        {
            RoutewaySquare item = this.RemoveFromOpenList();
            if ((item != null) && !this.IsInCloseList(item.Position))
            {
                this.closeList.Add(item);
                this.closeDictionary.Add(item.Position, item);
            }
            return item;
        }

        private void AddToCloseList(RoutewaySquare square)
        {
            if (!this.closeDictionary.ContainsKey(square.Position))
            {
                this.closeList.Add(square);
                this.closeDictionary.Add(square.Position, square);
            }
        }

        private void AddToOpenList(RoutewaySquare square)
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

        private void CheckAdjacentSquares(RoutewaySquare currentSquare, Point end)
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
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            break;

                        case 0:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            break;

                        case 1:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            break;
                    }
                    break;

                case 0:
                    switch (num4)
                    {
                        case -1:
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            break;

                        case 0:
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            break;

                        case 1:
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            break;
                    }
                    break;

                case 1:
                    switch (num4)
                    {
                        case -1:
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            break;

                        case 0:
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            break;

                        case 1:
                            this.RightSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X + 1, currentSquare.Position.Y), end);
                            this.BottomSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y + 1), end);
                            this.LeftSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X - 1, currentSquare.Position.Y), end);
                            this.TopSquareCost = this.MakeSquare(currentSquare, new Point(currentSquare.Position.X, currentSquare.Position.Y - 1), end);
                            break;
                    }
                    break;
            }
        }

        private int GetCostByPosition(Point position, out float consumptionRate)
        {
            if (this.OnGetCost != null)
            {
                return this.OnGetCost(position, out consumptionRate);
            }
            consumptionRate = 0f;
            return 0x3e8;
        }

        public bool GetPath(Point start, Point end, bool hasEnd)
        {
            bool flag = false;
            this.openDictionary.Clear();
            this.closeDictionary.Clear();
            this.openList.Clear();
            this.closeList.Clear();
            RoutewaySquare square = new RoutewaySquare();
            square.Position = start;
            this.AddToCloseList(square);
            if (start == end)
            {
                return true;
            }
            do
            {
                this.CheckAdjacentSquares(square, end);
                if (this.openList.Count == 0)
                {
                    return flag;
                }
                square = this.AddToCloseList();
                if (square == null)
                {
                    return flag;
                }
                flag = square.Position == end;
                if (square.ConsumptionRate >= this.ConsumptionMax)
                {
                    if ((this.closeList.Count <= 1) || hasEnd)
                    {
                        return flag;
                    }
                    this.closeList.RemoveAt(this.closeList.Count - 1);
                    flag = true;
                }
            }
            while (!flag);
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

        private RoutewaySquare GetSquareFromOpenList(Point position)
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

        private int MakeSquare(RoutewaySquare currentSquare, Point position, Point end)
        {
            float consumptionRate = 0f;
            int costByPosition = this.GetCostByPosition(position, out consumptionRate);
            if (!this.IsInCloseList(position) && (costByPosition < 0x3e8))
            {
                RoutewaySquare square = new RoutewaySquare();
                int num3 = currentSquare.RealG + (5 * costByPosition);
                RoutewaySquare squareFromOpenList = this.GetSquareFromOpenList(position);
                if (squareFromOpenList == null)
                {
                    square.Parent = currentSquare;
                    square.Position = position;
                    square.PenalizedCost = this.GetPenalizedCostByPosition(position);
                    square.H = (Math.Abs((int) (end.X - position.X)) + Math.Abs((int) (end.Y - position.Y))) * 5;
                    square.RealG = num3;
                    square.ConsumptionRate = currentSquare.ConsumptionRate + consumptionRate;
                    this.AddToOpenList(square);
                }
                else if (num3 < squareFromOpenList.RealG)
                {
                    squareFromOpenList.Parent = currentSquare;
                    squareFromOpenList.RealG = num3;
                    squareFromOpenList.ConsumptionRate = currentSquare.ConsumptionRate + consumptionRate;
                    this.UpResortOpenList(squareFromOpenList, squareFromOpenList.Index);
                }
            }
            return costByPosition;
        }

        private RoutewaySquare RemoveFromOpenList()
        {
            if (this.openList.Count <= 0)
            {
                return null;
            }
            this.SwapSquare(0, this.openList.Count - 1, this.openList);
            RoutewaySquare square = this.openList[this.openList.Count - 1];
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
            RoutewaySquare parent = this.closeList[this.closeList.Count - 1];
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

        private void SwapSquare(int x, int y, List<RoutewaySquare> list)
        {
            RoutewaySquare square = list[x];
            list[x] = list[y];
            list[y] = square;
            list[x].Index = x;
            list[y].Index = y;
        }

        private void UpResortOpenList(RoutewaySquare square, int index)
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

        public float PathConsumptionRate
        {
            get
            {
                if (this.closeList.Count > 0)
                {
                    return this.closeList[this.closeList.Count - 1].ConsumptionRate;
                }
                return 0f;
            }
        }

        public delegate int GetCost(Point position, out float consumptionRate);

        public delegate int GetPenalizedCost(Point position);
    }
}

