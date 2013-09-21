namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind901 : ConditionKind
    {
        public virtual bool CheckConditionKind(Architecture architecture)
        {
            return true;
        }

        public virtual bool CheckConditionKind(Faction faction)
        {
            return true;
        }

        public virtual bool CheckConditionKind(Person person)
        {
            return true;
        }

        public virtual bool CheckConditionKind(Troop troop)
        {
            return true;
        }
    }
}

