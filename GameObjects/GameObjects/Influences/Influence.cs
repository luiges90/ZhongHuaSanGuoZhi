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

        internal HashSet<ApplyingArchitecture> appliedArch = new HashSet<ApplyingArchitecture>();
        internal HashSet<ApplyingPerson> appliedPerson = new HashSet<ApplyingPerson>();
        internal HashSet<ApplyingFaction> appliedFaction = new HashSet<ApplyingFaction>();
        internal HashSet<ApplyingTroop> appliedTroop = new HashSet<ApplyingTroop>();

        public void ApplyInfluence(Architecture architecture, Applier applier, int applierID)
        {
            ApplyingArchitecture a = new ApplyingArchitecture(architecture, applier, applierID);
            if (appliedArch.Contains(a)) return;
            appliedArch.Add(a);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(architecture, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Faction faction, Applier applier, int applierID)
        {
            ApplyingFaction a = new ApplyingFaction(faction, applier, applierID);
            if (appliedFaction.Contains(a)) return;
            appliedFaction.Add(a);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(faction, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Person person, Applier applier, int applierID)
        {
            ApplyingPerson a = new ApplyingPerson(person, applier, applierID);
            if (appliedPerson.Contains(a) && 
                (person.LocationTroop == null || appliedTroop.Contains(new ApplyingTroop(person.LocationTroop, applier, applierID)) 
                    || this.Type != InfluenceType.战斗)) return;
            appliedPerson.Add(a);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(person, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void ApplyInfluence(Troop troop, Applier applier, int applierID)
        {
            ApplyingTroop a = new ApplyingTroop(troop, applier, applierID);
            if (appliedTroop.Contains(a) && (this.ID < 390 || this.ID > 399)) return;
            appliedTroop.Add(a);
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.ApplyInfluenceKind(troop, this, applier, applierID);
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

        public void PurifyInfluence(Architecture architecture, Applier applier, int applierID)
        {
            ApplyingArchitecture a = new ApplyingArchitecture(architecture, applier, applierID);
            if (!appliedArch.Contains(a)) return;
            appliedArch.RemoveWhere((x) => { return x.Equals(a); });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(architecture, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void PurifyInfluence(Faction faction, Applier applier, int applierID)
        {
            ApplyingFaction a = new ApplyingFaction(faction, applier, applierID);
            if (!appliedFaction.Contains(a)) return;
            appliedFaction.RemoveWhere((x) => { return x.Equals(a); });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(faction, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void PurifyInfluence(Person person, Applier applier, int applierID)
        {
            ApplyingPerson a = new ApplyingPerson(person, applier, applierID);
            if (!appliedPerson.Contains(a)) return;
            appliedPerson.RemoveWhere((x) => { return x.Equals(a); });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(person, this, applier, applierID);
            }
            catch
            {
            }
        }

        public void TroopDestroyed(Troop troop)
        {
            appliedTroop.RemoveWhere((x) => { return x.troop.Equals(troop); });
        }

        public void PurifyInfluence(Troop troop, Applier applier, int applierID)
        {
            ApplyingTroop a = new ApplyingTroop(troop, applier, applierID);
            if (!appliedTroop.Contains(a)) return;
            appliedTroop.RemoveWhere((x) => { return x.Equals(a) || x.troop.Destroyed; });
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter2(this.Parameter2);
            try
            {
                this.Kind.PurifyInfluenceKind(troop, this, applier, applierID);
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

