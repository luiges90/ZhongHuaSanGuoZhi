namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind122 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Architecture person)
        {
            person.DayAvoidInfluenceByBattle = true;
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            person.DayAvoidInfluenceByBattle = false;
        }
    }
}

