namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6110 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Architecture a)
        {
            a.captureChance += this.increment;
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.captureChance -= this.increment;
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

