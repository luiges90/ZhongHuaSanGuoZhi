namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;
    using GameGlobal;

    internal class InfluenceKind120 : InfluenceKind
    {
        private int increment = 0;

        public override void ApplyInfluenceKind(Architecture person)
        {
            person.DayLearnTitleDay = this.increment;
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            person.DayLearnTitleDay = Parameters.LearnTitleDays;
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

