namespace GameObjects.Influences
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class InfluenceTable
    {
        public Dictionary<int, Influence> Influences = new Dictionary<int, Influence>();

        public bool AddInfluence(Influence influence)
        {
            if (this.Influences.ContainsKey(influence.ID))
            {
                return false;
            }
            this.Influences.Add(influence.ID, influence);
            return true;
        }

        public void ApplyInfluence(Architecture architecture, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(architecture, applier, applierID);
            }
        }

        public void ApplyInfluence(Faction faction, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(faction, applier, applierID);
            }
        }

        public void ApplyInfluence(Person person, Applier applier, int applierID)
        {
            bool flag = false;
            bool flag2 = false;
            foreach (Influence influence in this.Influences.Values)
            {
                if ((influence.Type != InfluenceType.前提) && (influence.Type != InfluenceType.多选一))
                {
                    if (!flag || flag2)
                    {
                        influence.ApplyInfluence(person, applier, applierID);
                    }
                    continue;
                }
                if (!(flag || (influence.Type != InfluenceType.多选一)))
                {
                    flag = true;
                }
                if (influence.IsVaild(person))
                {
                    if (influence.Type == InfluenceType.多选一)
                    {
                        flag2 = true;
                        continue;
                    }
                }
                else if (influence.Type == InfluenceType.前提)
                {
                    break;
                }
            }
        }

        public void Clear()
        {
            this.Influences.Clear();
        }

        public void DirectlyApplyInfluence(Troop troop, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(troop, applier, applierID);
            }
        }

        public void DirectlyPurifyInfluence(Troop troop, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(troop, applier, applierID);
            }
        }

        public Influence GetInfluence(int influenceID)
        {
            Influence influence = null;
            this.Influences.TryGetValue(influenceID, out influence);
            return influence;
        }

        public GameObjectList GetInfluenceList()
        {
            GameObjectList list = new GameObjectList();
            foreach (Influence influence in this.Influences.Values)
            {
                list.Add(influence);
            }
            return list;
        }

        public bool HasInfluence(int influenceID)
        {
            return this.Influences.ContainsKey(influenceID);
        }

        public bool HasInfluenceKind(int id)
        {
            foreach (Influence i in this.Influences.Values)
            {
                if (i.Kind.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void LoadFromString(InfluenceTable allInfluences, string influenceIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = influenceIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Influence influence = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allInfluences.Influences.TryGetValue(int.Parse(strArray[i]), out influence))
                {
                    this.AddInfluence(influence);
                }
            }
        }

        public void PurifyInfluence(Architecture architecture, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(architecture, applier, applierID);
            }
        }

        public void PurifyInfluence(Faction faction, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(faction, applier, applierID);
            }
        }

        public void PurifyInfluence(Person p, Applier applier, int applierID)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(p, applier, applierID);
            }
        }

        public string SaveToString()
        {
            string str = "";
            foreach (Influence influence in this.Influences.Values)
            {
                str = str + influence.ID.ToString() + " ";
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public bool HasTroopLeaderValidInfluence
        {
            get
            {
                foreach (Influence influence in this.Influences.Values)
                {
                    if (influence.TroopLeaderValid)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

