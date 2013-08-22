namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind919 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return !(person.BelongedFaction != null && (person.BelongedFaction.Leader.Father.ID == person.Father.ID || person.BelongedFaction.Leader.Mother == person.Mother));
        }
    }
}

