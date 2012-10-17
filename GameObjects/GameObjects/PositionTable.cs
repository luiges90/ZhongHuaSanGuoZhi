namespace GameObjects
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PositionTable
    {
        public Dictionary<int, Point> Positions = new Dictionary<int, Point>();

        public void AddPosition(Point position)
        {
            int hashCode = position.ToString().GetHashCode();
            if (!this.Positions.ContainsKey(hashCode))
            {
                this.Positions.Add(hashCode, position);
            }
        }

        public void Clear()
        {
            this.Positions.Clear();
        }

        public bool HasPosition(Point position)
        {
            int hashCode = position.ToString().GetHashCode();
            return this.Positions.ContainsKey(hashCode);
        }

        public void LoadFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.AddPosition(new Point(int.Parse(strArray[i]), int.Parse(strArray[i + 1])));
            }
        }

        public bool RemovePosition(Point position)
        {
            int hashCode = position.ToString().GetHashCode();
            return this.Positions.Remove(hashCode);
        }

        public string SaveToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Point point in this.Positions.Values)
            {
                builder.Append(point.X.ToString() + " " + point.Y.ToString() + " ");
            }
            return builder.ToString();
        }

        public int Count
        {
            get
            {
                return this.Positions.Count;
            }
        }
    }
}

