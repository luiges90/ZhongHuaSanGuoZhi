namespace GameObjects.ArchitectureDetail
{
    using GameObjects;
    using System;

    public class Region : GameObject
    {
        public ArchitectureList Architectures = new ArchitectureList();
        public Architecture RegionCore;
        public int RegionCoreID;
        public StateList States = new StateList();

        public int GetFactionScale(Faction faction)
        {
            if (this.Architectures.Count <= 0)
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in this.Architectures)
            {
                if ((architecture.BelongedFaction == null) || (faction == architecture.BelongedFaction))
                {
                    num++;
                }
            }
            return ((num * 100) / this.Architectures.Count);
        }

        public int GetSectionScale(Section section)
        {
            if ((this.Architectures.Count <= 0) || (section.ArchitectureCount <= 0))
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.BelongedSection == section)
                {
                    num++;
                }
                if (num >= section.ArchitectureCount)
                {
                    return 100;
                }
            }
            return ((num * 100) / section.ArchitectureCount);
        }

        public void LoadStatesFromString(StateList states, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.States.Clear();
            foreach (string str in strArray)
            {
                State gameObject = states.GetGameObject(int.Parse(str)) as State;
                if (gameObject != null)
                {
                    this.States.Add(gameObject);
                    gameObject.LinkedRegion = this;
                }
            }
        }

        public string RegionCoreString
        {
            get
            {
                return ((this.RegionCore != null) ? this.RegionCore.Name : "----");
            }
        }

        public string StatesString
        {
            get
            {
                string str = "";
                foreach (State state in this.States)
                {
                    str = str + state.Name + " ";
                }
                return str;
            }
        }
    }
}

