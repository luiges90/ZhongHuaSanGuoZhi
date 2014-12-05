using System;
using System.Collections.Generic;

namespace GameObjects
{
	public class OngoingBattle : GameObject
	{
        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int CalmDay { get; set; }
        public bool Skirmish { get; set; }

        public int OriginalArchitectureFactionID { get; set; }
        public Faction OriginalArchitectureFaction
        {
            get
            {
                return (Faction) base.Scenario.Factions.GetGameObject(OriginalArchitectureFactionID);
            }
        }

        public PersonList Persons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.Battle == this)
                    {
                        result.Add(p);
                    }
                }
                return result;
            }
        }

        public Architecture Architecture
        {
            get
            {
                Architecture battleArch = null;
                foreach (Architecture a in base.Scenario.Architectures)
                {
                    if (a.Battle == this)
                    {
                        battleArch = a;
                        break;
                    }
                }
                return battleArch;
            }
        }

	}
}
