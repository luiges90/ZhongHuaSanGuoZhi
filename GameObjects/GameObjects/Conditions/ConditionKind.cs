namespace GameObjects.Conditions
{
    using GameObjects;
    using System;

    public abstract class ConditionKind : GameObject
    {
        public virtual bool CheckConditionKind(Architecture architecture, Event e)
        {
            if (this.ID < 1000 || (this.ID >= 4000 && this.ID < 5000))
            {
                return architecture.Mayor != null && this.CheckConditionKind(architecture.Mayor, e);
            }
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return architecture.BelongedFaction != null && this.CheckConditionKind(architecture.BelongedFaction, e);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Faction faction, Event e)
        {
            if (this.ID < 1000 || (this.ID >= 4000 && this.ID < 5000))
            {
                return faction.Leader != null && this.CheckConditionKind(faction.Leader, e);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Person person, Event e)
        {
            if (this.ID >= 2000 && this.ID < 3000)
            {
                return person.LocationArchitecture != null && this.CheckConditionKind(person.LocationArchitecture, e);
            }
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return person.BelongedFaction != null && this.CheckConditionKind(person.BelongedFaction, e);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Troop troop, Event e)
        {
            if (this.ID < 1000 || (this.ID >= 4000 && this.ID < 5000))
            {
                return troop.Leader != null && this.CheckConditionKind(troop.Leader, e);
            }
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return troop.BelongedFaction != null && this.CheckConditionKind(troop.BelongedFaction, e);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Architecture architecture)
        {
            if (this.ID < 1000 || (this.ID >= 4000 && this.ID < 5000))
            {
                return architecture.Mayor != null && this.CheckConditionKind(architecture.Mayor);
            }
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return architecture.BelongedFaction != null && this.CheckConditionKind(architecture.BelongedFaction);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Faction faction)
        {
            if (this.ID < 1000 || (this.ID >= 4000 && this.ID < 5000))
            {
                return faction.Leader != null && this.CheckConditionKind(faction.Leader);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Person person)
        {
            if (this.ID >= 2000 && this.ID < 3000)
            {
                return person.LocationArchitecture != null && this.CheckConditionKind(person.LocationArchitecture);
            }
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return person.BelongedFaction != null && this.CheckConditionKind(person.BelongedFaction);
            }
            return false;
        }

        public virtual bool CheckConditionKind(Troop troop)
        {
            if (this.ID >= 3000 && this.ID < 4000)
            {
                return troop.BelongedFaction != null && this.CheckConditionKind(troop.BelongedFaction);
            }
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

