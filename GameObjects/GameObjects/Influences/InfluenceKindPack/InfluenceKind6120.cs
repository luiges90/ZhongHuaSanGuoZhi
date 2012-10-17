namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6120 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                person.LocationArchitecture.noEscapeChance += this.increment;
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            a.noEscapeChance += this.increment;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                person.LocationArchitecture.noEscapeChance -= this.increment;
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.noEscapeChance -= this.increment;
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

