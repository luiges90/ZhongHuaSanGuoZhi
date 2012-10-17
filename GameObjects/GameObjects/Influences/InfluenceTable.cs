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

        public void ApplyInfluence(Architecture architecture)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(architecture);
            }
        }

        public void ApplyInfluence(Faction faction)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(faction);
            }
        }

        public void ApplyInfluence(Person person)
        {
            bool flag = false;
            bool flag2 = false;
            foreach (Influence influence in this.Influences.Values)
            {
                if ((influence.Type != InfluenceType.前提) && (influence.Type != InfluenceType.多选一))
                {
                    if (!flag || flag2)
                    {
                        influence.ApplyInfluence(person);
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

        public void DirectlyApplyInfluence(Troop troop)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.ApplyInfluence(troop);
            }
        }

        public void DirectlyPurifyInfluence(Troop troop)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(troop);
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

        public void LoadFromString(InfluenceTable allInfluences, string influenceIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
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

        public void PurifyInfluence(Architecture architecture)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(architecture);
            }
        }

        public void PurifyInfluence(Faction faction)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(faction);
            }
        }

        public void PurifyInfluence(Person p)
        {
            foreach (Influence influence in this.Influences.Values)
            {
                influence.PurifyInfluence(p);
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

