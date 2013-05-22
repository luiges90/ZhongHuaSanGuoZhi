namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6440 : InfluenceKind
    {
        private float rate;

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (rate > a.facilityConstructionTimeRateDecrease)
            {
                a.facilityConstructionTimeRateDecrease = rate;
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.facilityConstructionTimeRateDecrease = 0;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

    }
}

