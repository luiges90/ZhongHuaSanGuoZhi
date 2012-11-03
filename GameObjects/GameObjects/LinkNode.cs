﻿namespace GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework;
    using GameObjects.MapDetail;

    public class LinkNode
    {
        internal Architecture A;
        internal double Distance;
        internal LinkKind Kind;
        internal int Level;
        internal List<Architecture> Path = new List<Architecture>();
        internal List<Point> RoutewayPath = new List<Point>();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Concat(new object[] { this.Level, " ", this.Kind, " ", Math.Round(this.Distance, 1) }));
            foreach (Architecture architecture in this.Path)
            {
                builder.Append(" " + architecture.Name);
            }
            return builder.ToString();
        }

        public void createPath(Architecture starting)
        {
            
        }
    }
}

