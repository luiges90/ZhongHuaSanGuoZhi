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

        public virtual void ApplyInfluenceKind(Architecture a)
        {
        }

        public void ApplyInfluenceKind(Architecture architecture, Influence i)
        {
            ApplyInfluenceKind(architecture);
            foreach (Person p in architecture.Persons)
            {
                if (!i.appliedPerson.Contains(p))
                {
                    i.appliedPerson.Add(p);
                    ApplyInfluenceKind(p, i);
                }
            }
        }

        public virtual void ApplyInfluenceKind(Faction f)
        {
        }

        public void ApplyInfluenceKind(Faction faction, Influence i)
        {
            ApplyInfluenceKind(faction);
            foreach (Architecture a in faction.Architectures)
            {
                if (!i.appliedArch.Contains(a)){
                    i.appliedArch.Add(a);
                    ApplyInfluenceKind(a, i);
                }
            }
            foreach (Troop t in faction.Troops)
            {
                if (!i.appliedTroop.Contains(t))
                {
                    i.appliedTroop.Add(t);
                    ApplyInfluenceKind(t, i);
                }
            }
        }

        public virtual void ApplyInfluenceKind(Person p)
        {
        }

        public void ApplyInfluenceKind(Person person, Influence i)
        {
            ApplyInfluenceKind(person);
            if (person.LocationTroop != null && !i.appliedTroop.Contains(person.LocationTroop))
            {
                i.appliedTroop.Add(person.LocationTroop);
                ApplyInfluenceKind(person.LocationTroop, i);
            }
        }

        public virtual void ApplyInfluenceKind(Troop t)
        {
        }

        public void ApplyInfluenceKind(Troop troop, Influence i)
        {
            ApplyInfluenceKind(troop);
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

        public void PurifyInfluenceKind(Architecture architecture, Influence i)
        {
            PurifyInfluenceKind(architecture);
            foreach (Person p in architecture.Persons)
            {
                i.appliedPerson.RemoveAll((p2) => { return p == p2; });
                PurifyInfluenceKind(p, i);
            }
        }

        public virtual void PurifyInfluenceKind(Faction f)
        {
        }

        public void PurifyInfluenceKind(Faction faction, Influence i)
        {
            PurifyInfluenceKind(faction);
            foreach (Architecture a in faction.Architectures)
            {
                i.appliedArch.RemoveAll((a2) => { return a == a2; });
                PurifyInfluenceKind(a, i);
            }
            foreach (Troop t in faction.Troops)
            {
                PurifyInfluenceKind(t, i);
            }
        }

        public virtual void PurifyInfluenceKind(Person p)
        {
        }

        public void PurifyInfluenceKind(Person person, Influence i)
        {
            PurifyInfluenceKind(person);
            if (person.LocationTroop != null && i.appliedTroop.Contains(person.LocationTroop))
            {
                i.appliedTroop.RemoveAll((a2) => { return person.LocationTroop == a2; });
                PurifyInfluenceKind(person.LocationTroop, i);
            }
        }

        public virtual void PurifyInfluenceKind(Troop t)
        {
        }

        public void PurifyInfluenceKind(Troop troop, Influence i)
        {
            PurifyInfluenceKind(troop);
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

