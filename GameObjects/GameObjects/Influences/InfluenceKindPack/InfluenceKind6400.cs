namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6400 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Person person)
        {
            person.BelongedArchitecture.noFundToSustainFacility = true;
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            a.noFundToSustainFacility = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.BelongedArchitecture.noFundToSustainFacility = false;
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.noFundToSustainFacility = false;
        }

    }
}

