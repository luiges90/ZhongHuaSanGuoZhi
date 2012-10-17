namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind959 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFaction != null && (person.BelongedFaction.Leader.Brother != person.Brother || person.Brother < 0);
        }
    }
}

