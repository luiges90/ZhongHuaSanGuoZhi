namespace GameObjects.Conditions
{
    using GameObjects;
    using System;

    public abstract class ConditionKind : GameObject
    {
        public virtual bool CheckConditionKind(Architecture architecture, Event e)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Faction faction, Event e)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Person person, Event e)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Troop troop, Event e)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Architecture architecture)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Faction faction)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Person person)
        {
            return false;
        }

        public virtual bool CheckConditionKind(Troop troop)
        {
            return false;
        }

        public virtual void InitializeParameter(string parameter)
        {
        }

        public virtual void InitializeParameter2(string parameter)
        {
        }
    }
}

