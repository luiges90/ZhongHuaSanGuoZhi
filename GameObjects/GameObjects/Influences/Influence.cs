namespace GameObjects.Influences
{
    using GameObjects;
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;
    using System.Collections;
    using System.Collections.Generic;

    public class Influence : GameObject
    {
        private string description;
        public InfluenceKind Kind;
        private string parameter;
        private string parameter2;

        internal List<Architecture> appliedArch = new List<Architecture>();
        internal List<Person> appliedPerson = new List<Person>();
        internal List<Faction> appliedFaction = new List<Faction>();
        internal List<Troop> appliedTroop = new List<Troop>();

        public void ApplyInfluence(Architecture architecture)
        {
            if (appliedArch.Contains(architecture)) return;
            appliedArch.Add(architecture);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(architecture, this);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Faction faction)
        {
            if (appliedFaction.Contains(faction)) return;
            appliedFaction.Add(faction);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(faction, this);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Person person)
        {
            if (appliedPerson.Contains(person) && 
                (person.LocationTroop == null || appliedTroop.Contains(person.LocationTroop) || this.Type == InfluenceType.战斗)) return;
            appliedPerson.Add(person);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(person, this);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Troop troop)
        {
            if (appliedTroop.Contains(troop) && (this.ID < 390 || this.ID > 399)) return;
            appliedTroop.Add(troop);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(troop, this);
            }
            catch
            {
            }
        }

        public void DoWork(Architecture architecture)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            this.Kind.DoWork(architecture);
        }

        public int GetCredit(Troop source, Troop destination)
        {
            return this.Kind.GetCredit(source, destination);
        }

        public int GetCreditWithPosition(Troop source, out Point? position)
        {
            //position = 0;
            position = new Point(0, 0);
            return this.Kind.GetCreditWithPosition(source, out position);
        }

        public bool IsVaild(Person person)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.IsVaild(person);
        }

        public bool IsVaild(Troop troop)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            return this.Kind.IsVaild(troop);
        }

        public void PurifyInfluence(Architecture architecture)
        {
            if (!appliedArch.Contains(architecture)) return;
            appliedArch.RemoveAll((a) => { return architecture == a; });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(architecture, this);
            }
            catch
            {
            }
        }

        public void PurifyInfluence(Faction faction)
        {
            if (!appliedFaction.Contains(faction)) return;
            appliedFaction.RemoveAll((f) => { return faction == f; });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(faction, this);
            }
            catch
            {
            }
        }

        public void PurifyInfluence(Person person)
        {
            if (!appliedPerson.Contains(person)) return;
            appliedPerson.RemoveAll((p) => { return person == p; });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(person, this);
            }
            catch
            {
            }
        }

        public void PurifyInfluence(Troop troop)
        {
            if (!appliedTroop.Contains(troop)) return;
            appliedTroop.RemoveAll((p) => { return troop == p; });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(troop, this);
            }
            catch
            {
            }
        }

        public double AIFacilityValue(Architecture a)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                return this.Kind.AIFacilityValue(a);
            }
            catch
            {
            }
            return 0;
        }

        public override string ToString()
        {
            return this.Description;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
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

        public bool TroopLeaderValid
        {
            get
            {
                return this.Kind.TroopLeaderValid;
            }
        }

        public InfluenceType Type
        {
            get
            {
                return this.Kind.Type;
            }
        }
    }
}

