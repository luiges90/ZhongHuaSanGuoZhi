namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3010 : InfluenceKind
    {
        private int increment = 0;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.IncrementOfMonthFood += this.increment;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.IncrementOfMonthFood -= this.increment;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (1 - Math.Pow((double)a.Food / a.FoodCeiling, 0.5) + (a.IsFoodEnough ? 0 : 1000) + (a.IsFoodAbundant ? 0 : 1)) * this.increment / 20000.0;
        }
    }
}

