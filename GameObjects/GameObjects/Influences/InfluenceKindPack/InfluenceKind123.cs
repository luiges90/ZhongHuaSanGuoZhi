namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind123 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Architecture person)
        {
            person.DayAvoidPopulationEscape = true;
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            person.DayAvoidPopulationEscape = false;
        }
    }
}

