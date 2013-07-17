namespace GameObjects.PersonDetail.PersonMessages
{
    using GameObjects;
    using GameObjects.PersonDetail;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpyMessage : PersonMessage
    {
        private SpyMessageKind kind;
        public Architecture MessageArchitecture;
        public int MessageArchitectureID;
        public Faction MessageFaction;
        public int MessageFactionID;
        internal List<SpyMessagePersonPack> PersonPacks = new List<SpyMessagePersonPack>();

        public void AddPersonPack(Person person, int days)
        {
            SpyMessagePersonPack item = new SpyMessagePersonPack(person, days);
            this.PersonPacks.Add(item);
        }

        public void ClearPersonPacks()
        {
            this.PersonPacks.Clear();
        }

        public void DayEvent()
        {
            this.PersonPacksDayEvent();
            if (this.PersonPacks.Count == 0)
            {
                base.Scenario.SpyMessages.Remove(this);
            }
        }

        internal void LoadPersonPacksFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.PersonPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.PersonPacks.Add(new SpyMessagePersonPack(persons[int.Parse(strArray[i])], int.Parse(strArray[i + 1])));
            }
        }

        public void PersonPacksDayEvent()
        {
            for (int i = this.PersonPacks.Count - 1; i >= 0; i--)
            {
                SpyMessagePersonPack local1 = this.PersonPacks[i];
                local1.Days--;
                if (this.PersonPacks[i].Days == 0)
                {
                    if ((this.PersonPacks[i].MessagePerson != null) && (this.PersonPacks[i].MessagePerson.BelongedFaction != this.MessageFaction))
                    {
                        this.PersonPacks[i].MessagePerson.ShowPersonMessage(this);
                    }
                    this.PersonPacks.RemoveAt(i);
                }
            }
        }

        internal string SavePersonPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SpyMessagePersonPack pack in this.PersonPacks)
            {
                builder.Append(string.Concat(new object[] { pack.MessagePerson.ID, " ", pack.Days, " " }));
            }
            return builder.ToString();
        }

        public SpyMessageKind Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }
    }
}

