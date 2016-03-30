namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind540 : ConditionKind
    {

        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFactionWithPrincess != null && 
                person.LocationArchitecture == person.BelongedFactionWithPrincess.Leader.LocationArchitecture;
        }

    }
}