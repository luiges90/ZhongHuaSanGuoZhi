namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6620 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Faction f)
        {
            if (this.increment > f.techniqueTimeRateDecrease)
            {
                f.techniqueTimeRateDecrease = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Faction f)
        {
            f.techniqueTimeRateDecrease = 0;
        }

        public override void ApplyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                if (this.increment > p.BelongedFaction.techniqueTimeRateDecrease)
                {
                    p.BelongedFaction.techniqueTimeRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniqueTimeRateDecrease = 0;
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                if (this.increment > a.BelongedFaction.techniqueTimeRateDecrease)
                {
                    a.BelongedFaction.techniqueTimeRateDecrease = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniqueTimeRateDecrease = 0;
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

