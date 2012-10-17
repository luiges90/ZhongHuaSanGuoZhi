namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3210 : InfluenceKind
    {
        private int increment = 0;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.IncrementOfCommercePerDay += this.increment;
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
            architecture.IncrementOfCommercePerDay -= this.increment;
        }

        public override double AIFacilityValue(Architecture a)
        {
            if (!a.Kind.HasCommerce) return -1;
            if (a.Commerce / (double) a.CommerceCeiling > 0.8) return -1;
            int abilityTotal = 0;
            foreach (Person p in a.Persons)
            {
                abilityTotal += p.CommerceAbility;
            }
            return (2000.0 / abilityTotal) * this.increment;
        }
    }
}

