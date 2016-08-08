namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind121 : InfluenceKind
    {
        int i;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null) 
            {
                person.LocationArchitecture.InfluenceIncrementOfLoyalty += i;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                person.LocationArchitecture.InfluenceIncrementOfLoyalty -= i;
            }
        }

        public override void ApplyInfluenceKind(Troop troop)
        {
            foreach (Person p in troop.Persons)
            {
                p.InfluenceIncrementOfLoyalty += i;
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            foreach (Person p in troop.Persons)
            {
                p.InfluenceIncrementOfLoyalty -= i;
            }
        }
    }
}

