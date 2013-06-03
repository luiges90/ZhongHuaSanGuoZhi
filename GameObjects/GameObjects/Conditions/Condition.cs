namespace GameObjects.Conditions
{
    using GameObjects;
    using System;

    public class Condition : GameObject
    {
        public ConditionKind Kind;
        private string parameter;
        private string parameter2;

        public bool CheckCondition(Architecture architecture, Event e)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(architecture, e) || this.Kind.CheckConditionKind(architecture);
        }

        public bool CheckCondition(Faction faction, Event e)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(faction, e) || this.Kind.CheckConditionKind(faction);
        }

        public bool CheckCondition(Person person, Event e)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(person, e) || this.Kind.CheckConditionKind(person);
        }

        public bool CheckCondition(Troop troop, Event e)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(troop, e) || this.Kind.CheckConditionKind(troop);
        }

        public bool CheckCondition(Architecture architecture)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(architecture);
        }

        public bool CheckCondition(Faction faction)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(faction);
        }

        public bool CheckCondition(Person person)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(person);
        }

        public bool CheckCondition(Troop troop)
        {
            if (this.Kind == null) return false;
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.CheckConditionKind(troop);
        }

        public string Parameter
        {
            get
            {
                return this.parameter;
            }
            set
            {
                this.parameter = value;
            }
        }

        public string Parameter2
        {
            get
            {
                return this.parameter2;
            }
            set
            {
                this.parameter2 = value;
            }
        }
    }
}

