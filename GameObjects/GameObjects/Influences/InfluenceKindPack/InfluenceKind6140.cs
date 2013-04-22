namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6140 : InfluenceKind
    {
        private int increment;
        private int threshold;

        public override void ApplyInfluenceKind(Architecture a)
        {
            a.captiveLoyaltyFall.Add(new System.Collections.Generic.KeyValuePair<int, int>(this.threshold, this.increment));
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.captiveLoyaltyFall.Remove(new System.Collections.Generic.KeyValuePair<int, int>(this.threshold, this.increment));
        }

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.threshold = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

