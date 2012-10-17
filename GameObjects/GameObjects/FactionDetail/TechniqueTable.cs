namespace GameObjects.FactionDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class TechniqueTable
    {
        public Dictionary<int, Technique> Techniques = new Dictionary<int, Technique>();

        public bool AddTechnique(Technique technique)
        {
            if (this.Techniques.ContainsKey(technique.ID))
            {
                return false;
            }
            this.Techniques.Add(technique.ID, technique);
            return true;
        }

        public void Clear()
        {
            this.Techniques.Clear();
        }

        public Technique GetTechnique(int techniqueID)
        {
            Technique technique = null;
            this.Techniques.TryGetValue(techniqueID, out technique);
            return technique;
        }

        public GameObjectList GetTechniqueList()
        {
            GameObjectList list = new GameObjectList();
            foreach (Technique technique in this.Techniques.Values)
            {
                list.Add(technique);
            }
            return list;
        }

        public void LoadFromString(TechniqueTable allTechniques, string techniqueIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = techniqueIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Technique technique = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allTechniques.Techniques.TryGetValue(int.Parse(strArray[i]), out technique))
                {
                    this.AddTechnique(technique);
                }
            }
        }

        public bool RemoveTechniuqe(int id)
        {
            if (!this.Techniques.ContainsKey(id))
            {
                return false;
            }
            this.Techniques.Remove(id);
            return true;
        }

        public string SaveToString()
        {
            string str = "";
            foreach (Technique technique in this.Techniques.Values)
            {
                str = str + technique.ID.ToString() + " ";
            }
            return str;
        }

        public int Count
        {
            get
            {
                return this.Techniques.Count;
            }
        }
    }
}

