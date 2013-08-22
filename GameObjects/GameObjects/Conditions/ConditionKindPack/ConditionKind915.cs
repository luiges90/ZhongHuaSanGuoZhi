namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind915 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return !(person.BelongedFaction != null && (person.Father.ID == person.BelongedFaction.LeaderID || person.Mother == person.BelongedFaction.Leader));
        }
    }
}

