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
            InfluenceKind6050 temp = new InfluenceKind6050();
            temp.InitializeParameter(rate.ToString());
            foreach (Person p in troop.Persons)
            {
                temp.ApplyInfluenceKind(p);
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            InfluenceKind6050 temp = new InfluenceKind6050();
            temp.InitializeParameter(rate.ToString());
            foreach (Person p in troop.Persons)
            {
                temp.PurifyInfluenceKind(p);
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

