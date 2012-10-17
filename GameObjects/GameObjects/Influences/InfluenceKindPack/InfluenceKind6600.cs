namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6600 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Faction f)
        {
            if (this.increment > f.techniqueReputationRateDecrease)
            {
                f.techniqueReputationRateDecrease = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Faction f)
        {
            f.techniqueReputationRateDecrease = 0;
        }

        public override void ApplyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                if (this.increment > p.BelongedFaction.techniqueReputationRateDecrease)
                {
                    p.BelongedFaction.techniqueReputationRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniqueReputationRateDecrease = 0;
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                if (this.increment > a.BelongedFaction.techniqueReputationRateDecrease)
                {
                    a.BelongedFaction.techniqueReputationRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniqueReputationRateDecrease = 0;
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

