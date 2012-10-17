namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind461 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Person person)
        {
            person.IncrementOfSpyDays = this.increment;
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

