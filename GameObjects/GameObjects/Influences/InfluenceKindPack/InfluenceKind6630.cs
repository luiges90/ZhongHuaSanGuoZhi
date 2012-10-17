namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6630 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Faction f)
        {
            if (this.increment > f.techniqueFundCostRateDecrease)
            {
                f.techniqueFundCostRateDecrease = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Faction f)
        {
            f.techniqueFundCostRateDecrease = 0;
        }

        public override void ApplyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                if (this.increment > p.BelongedFaction.techniqueFundCostRateDecrease)
                {
                    p.BelongedFaction.techniqueFundCostRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniqueFundCostRateDecrease = 0;
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                if (this.increment > a.BelongedFaction.techniqueFundCostRateDecrease)
                {
                    a.BelongedFaction.techniqueFundCostRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniqueFundCostRateDecrease = 0;
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

