namespace GameObjects
{
    using GameObjects;
    using System;

	public class YearTableEntry : GameObject
	{
        private GameDate date;
        private string content;
        private FactionList factions;
        private bool isGloballyKnown;

        public GameDate Date
        {
            get
            {
                return date;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
        }

        public FactionList Factions
        {
            get
            {
                return factions;
            }
        }

        public String FactionName1
        {
            get
            {
                if (factions.Count < 1) return "";
                return factions[0].Name;
            }
        }

        public String FactionName2
        {
            get
            {
                if (factions.Count < 2) return "";
                return factions[1].Name;
            }
        }

        public bool IsGloballyKnown
        {
            get
            {
                return isGloballyKnown;
            }
        }

        public YearTableEntry(int id, GameDate date, FactionList faction, string content, bool isGloballyKnown)
        {
            this.ID = id;
            this.date = new GameDate(date);
            this.content = content;
            this.factions = faction;
            this.isGloballyKnown = isGloballyKnown;
        }

        public override string ToString()
        {
            return this.content;
        }
	}
}
