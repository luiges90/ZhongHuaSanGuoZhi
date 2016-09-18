namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6265 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Troop t)
        {
            t.MovabilityDecreaseInViewArea += this.increment;
        }

        public override void PurifyInfluenceKind(Troop t)
        {
            t.MovabilityDecreaseInViewArea -= this.increment;
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
    }
}

