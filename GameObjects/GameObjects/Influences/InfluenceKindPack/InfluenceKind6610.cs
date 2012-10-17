namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6610 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Faction f)
        {
            if (this.increment > f.techniquePointCostRateDecrease)
            {
                f.techniquePointCostRateDecrease = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Faction f)
        {
            f.techniquePointCostRateDecrease = 0;
        }

        public override void ApplyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                if (this.increment > p.BelongedFaction.techniquePointCostRateDecrease)
                {
                    p.BelongedFaction.techniquePointCostRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniquePointCostRateDecrease = 0;
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                if (this.increment > a.BelongedFaction.techniquePointCostRateDecrease)
                {
                    a.BelongedFaction.techniquePointCostRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniquePointCostRateDecrease = 0;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = float.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

