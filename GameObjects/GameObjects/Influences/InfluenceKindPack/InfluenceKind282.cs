namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind282 : InfluenceKind
    {
        public override bool IsVaild(Person person)
        {
            return ((person.BelongedArchitecture != null) && (person.BelongedArchitecture.Mayor == person));
        }
    }
}

