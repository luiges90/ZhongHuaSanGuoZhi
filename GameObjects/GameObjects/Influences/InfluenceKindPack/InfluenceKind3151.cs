namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3151 : InfluenceKind
    {
        private float rate = 1f;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.RateOfSpyArchitecture -= 1 - this.rate;
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

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.RateOfSpyArchitecture += 1 - this.rate;
        }

        public override double AIFacilityValue(Architecture a)
        {
            return this.rate * (a.HostileLine ? 2 : 1);
        }
    }
}

