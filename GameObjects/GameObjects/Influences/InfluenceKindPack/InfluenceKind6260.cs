namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6260 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Troop t)
        {
            t.MovabilityIncreaseInViewArea += this.increment;
        }

        public override void PurifyInfluenceKind(Troop t)
        {
            t.MovabilityIncreaseInViewArea -= this.increment;
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

