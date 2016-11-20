namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind50 : InfluenceKind
    {
        private float rate = 1f;

        public override void ApplyInfluenceKind(Architecture person)
        {
            person.DayRateIncrementOfInternal += this.rate;
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            person.DayRateIncrementOfInternal -= this.rate;
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

