namespace GameObjects.Influences
{
    using GameObjects;
    using System;

    public class InfluenceList : GameObjectList
    {
        public void LoadFromString(InfluenceTable allInfluences, string influenceIDs)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = influenceIDs.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Influence influence = null;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (allInfluences.Influences.TryGetValue(int.Parse(strArray[i]), out influence))
                {
                    base.Add(influence);
                }
            }
        }
    }
}

