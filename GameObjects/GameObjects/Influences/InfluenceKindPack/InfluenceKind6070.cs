namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6070 : InfluenceKind
    {
        private float rate;

        public override void ApplyInfluenceKind(Person person)
        {
            InfluenceKind6050 temp = new InfluenceKind6050();
            temp.InitializeParameter(rate.ToString());
            temp.ApplyInfluenceKind(person.LocationArchitecture);
        }

        public override void PurifyInfluenceKind(Person person)
        {
            InfluenceKind6050 temp = new InfluenceKind6050();
            temp.InitializeParameter(rate.ToString());
            temp.PurifyInfluenceKind(person.LocationArchitecture);
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

