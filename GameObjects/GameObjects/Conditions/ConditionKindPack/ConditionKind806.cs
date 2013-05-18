namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind806 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            foreach (Architecture a in person.Scenario.Architectures)
            {
                if (a.Feiziliebiao.GameObjects.Contains(this))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

