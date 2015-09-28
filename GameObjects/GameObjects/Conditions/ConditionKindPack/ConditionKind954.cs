﻿namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind954 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFactionWithPrincess != null && person.BelongedFactionWithPrincess.Leader.Closes(person);
        }
    }
}

