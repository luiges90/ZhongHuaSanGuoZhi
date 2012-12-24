namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6060 : InfluenceKind
    {
        private float rate;

        public override void ApplyInfluenceKind(Troop troop)
        {
            return;
            foreach (Person i in troop.Persons)
            {
                i.ExperienceRate += rate;
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            return;
            foreach (Person i in troop.Persons)
            {
                i.ExperienceRate -= rate;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

