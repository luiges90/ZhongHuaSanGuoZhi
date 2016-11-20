namespace GameObjects.Influences
{
    using GameObjects;
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    public abstract class InfluenceKind : GameObject
    {
        public bool TroopLeaderValid;
        private InfluenceType type;
        private bool combat;

        public float AIPersonValue { get; set; }
        public float AIPersonValuePow { get; set; }

        private float p1, p2;

        public bool Combat
        {
            get
            {
                return combat;
            }
            set
            {
                combat = value;
            }
        }

        public virtual void ApplyInfluenceKind(Architecture a)
        {
        }

        public void ApplyInfluenceKind(Architecture architecture, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                if (i.appliedArch.Add(new ApplyingArchitecture(architecture, applier, applierID)))
                {
                    ApplyInfluenceKind(architecture);
                }
            } 
            else if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in architecture.Persons)
                {
                    ApplyInfluenceKind(p, i, applier, applierID, false);
                }
            }
        }

        public virtual void ApplyInfluenceKind(Faction f)
        {
        }

        public void ApplyInfluenceKind(Faction faction, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.势力)
            {
                if (i.appliedFaction.Add(new ApplyingFaction(faction, applier, applierID)))
                {
                    ApplyInfluenceKind(faction);
                }
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                foreach (Architecture a in faction.Architectures)
                {
                    ApplyInfluenceKind(a, i, applier, applierID);
                }
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                foreach (Troop t in faction.Troops)
                {
                    ApplyInfluenceKind(t, i, applier, applierID);
                }
            }
            if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in faction.Persons)
                {
                    ApplyInfluenceKind(p, i, applier, applierID, false);
                }
            }
        }

        public virtual void ApplyInfluenceKind(Person p)
        {
        }

        public void ApplyInfluenceKind(Person person, Influence i, Applier applier, int applierID, bool excludePersonal)
        {
            if (this.Type == InfluenceType.个人)
            {
                if (i.appliedPerson.Add(new ApplyingPerson(person, applier, applierID)))
                {
                    ApplyInfluenceKind(person);
                }
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationTroop != null)
                {
                    ApplyInfluenceKind(person.LocationTroop, i, applier, applierID);
                }
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationArchitecture != null)
                {
                    ApplyInfluenceKind(person.LocationArchitecture, i, applier, applierID);
                }
            }
        }

        public virtual void ApplyInfluenceKind(Troop t)
        {
        }

        public void ApplyInfluenceKind(Troop troop, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                if (i.appliedTroop.Add(new ApplyingTroop(troop, applier, applierID)))
                {
                    troop.InfluencesApplying.Add(i);
                    ApplyInfluenceKind(troop);
                }
            }
        }

        public virtual void DoWork(Architecture architecture)
        {
        }

        public virtual int GetCredit(Troop source, Troop destination)
        {
            return 0;
        }

        public virtual int GetCreditWithPosition(Troop source, out Point? position)
        {
            //position = 0;
            position = new Point(0, 0);
            return 0;
        }

        public virtual void InitializeParameter(string parameter)
        {
        }

        public virtual void InitializeParameter2(string parameter)
        {
        }

        public virtual bool IsVaild(Person person)
        {
            return true;
        }

        public virtual bool IsVaild(Troop troop)
        {
            return true;
        }

        public virtual void PurifyInfluenceKind(Architecture a)
        {
        }

        public void PurifyInfluenceKind(Architecture architecture, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                if (i.appliedArch.Remove(new ApplyingArchitecture(architecture, applier, applierID)))
                {
                    PurifyInfluenceKind(architecture);
                }
            }
            else if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in architecture.Persons)
                {
                    PurifyInfluenceKind(p, i, applier, applierID, false);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Faction f)
        {
        }

        public void PurifyInfluenceKind(Faction faction, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.势力)
            {
                if (i.appliedFaction.Remove(new ApplyingFaction(faction, applier, applierID)))
                {
                    PurifyInfluenceKind(faction);
                }
                foreach (Architecture a in faction.Architectures)
                {
                    PurifyInfluenceKind(a, i, applier, applierID);
                }
                foreach (Troop t in faction.Troops)
                {
                    PurifyInfluenceKind(t, i, applier, applierID);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Person p)
        {
        }

        public void PurifyInfluenceKind(Person person, Influence i, Applier applier, int applierID, bool excludePersonal)
        {
            if (this.Type == InfluenceType.个人)
            {
                if (i.appliedPerson.Remove(new ApplyingPerson(person, applier, applierID)))
                {
                    PurifyInfluenceKind(person);
                }
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationTroop != null)
                {
                    PurifyInfluenceKind(person.LocationTroop, i, applier, applierID);
                }
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationArchitecture != null)
                {
                    PurifyInfluenceKind(person.LocationArchitecture, i, applier, applierID);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Troop t)
        {
        }

        public void PurifyInfluenceKind(Troop troop, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                if (i.appliedTroop.Remove(new ApplyingTroop(troop, applier, applierID)))
                {
                    PurifyInfluenceKind(troop);
                }
            }
        }

        public virtual double AIFacilityValue(Architecture a)
        {
            return 0;
        }

        public InfluenceType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

    }
}

