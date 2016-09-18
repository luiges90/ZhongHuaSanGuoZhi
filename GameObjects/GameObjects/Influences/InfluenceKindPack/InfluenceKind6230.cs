namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6230 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Troop t)
        {
            t.InCityOffenseRate += this.increment;
        }

        public override void PurifyInfluenceKind(Troop t)
        {
            t.InCityOffenseRate -= this.increment;
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

