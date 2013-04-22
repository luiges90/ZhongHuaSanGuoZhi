namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6620 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniqueTimeRateDecrease.Add(this.increment);
            }
        }

        public override void PurifyInfluenceKind(Person p)
        {
            if (p.BelongedFaction != null)
            {
                p.BelongedFaction.techniqueTimeRateDecrease.Remove(this.increment);
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

