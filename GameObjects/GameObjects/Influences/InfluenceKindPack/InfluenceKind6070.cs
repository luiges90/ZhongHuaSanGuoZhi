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
            foreach (Person i in person.LocationArchitecture.Persons) 
            {
                i.ExperienceRate += rate;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            foreach (Person i in person.LocationArchitecture.Persons) 
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

