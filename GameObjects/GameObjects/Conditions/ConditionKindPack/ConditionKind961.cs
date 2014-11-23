namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind961 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFaction != null && (person.Spouse.Father == person.BelongedFaction.Leader || person.Spouse.Mother == person.BelongedFaction.Leader);
        }
    }
}

