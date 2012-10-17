namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind121 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.DayLocationLoyaltyNoChange = true;
            if (person.BelongedFaction != null)
            {
                if (person.LocationArchitecture != null)
                {
                    person.LocationArchitecture.DayLocationLoyaltyNoChange = true;
                }
                if (person.LocationTroop != null)
                {
                    person.LocationTroop.DayLocationLoyaltyNoChange = true;
                }
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.DayLocationLoyaltyNoChange = false;
            if (person.BelongedFaction != null)
            {
                if (person.LocationArchitecture != null)
                {
                    person.LocationArchitecture.DayLocationLoyaltyNoChange = false;
                }
                if (person.LocationTroop != null)
                {
                    person.LocationTroop.DayLocationLoyaltyNoChange = false;
                }
            }
        }
    }
}

