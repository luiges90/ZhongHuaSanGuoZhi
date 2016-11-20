namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind124 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Architecture person)
        {
            person.DayAvoidInternalDecrementOnBattle = true;
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            person.DayAvoidInternalDecrementOnBattle = false;
        }
    }
}

