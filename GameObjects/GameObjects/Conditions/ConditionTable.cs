namespace GameObjects.Conditions
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class ConditionTable
    {
        public Dictionary<int, Condition> Conditions = new Dictionary<int, Condition>();

        public bool AddCondition(Condition influence)
        {
            if (this.Conditions.ContainsKey(influence.ID))
            {
                return false;
            }
            this.Conditions.Add(influence.ID, influence);
            return true;
        }

        public void Clear()
        {
            this.Conditions.Clear();
        }

        public Condition GetCondition(int influenceID)
        {
            Condition condition = null;
            this.Conditions.TryGetValue(influenceID, out condition);
            return condition;
        }

        public GameObjectList GetConditionList()
        {
            GameObjectList list = new GameObjectList();
            foreach (Condition condition in this.Conditions.Values)
            {
                list.Add(condition);
            }
            return list;
        }

        public void LoadFromString(ConditionTable allConditions, string conditionIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = conditionIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Condition condition = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allConditions.Conditions.TryGetValue(int.Parse(strArray[i]), out condition))
                {
                    this.AddCondition(condition);
                }
            }
        }

        public string SaveToString()
        {
            string str = "";
            foreach (Condition condition in this.Conditions.Values)
            {
                str = str + condition.ID.ToString() + " ";
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.Conditions.Count;
            }
        }
    }
}

