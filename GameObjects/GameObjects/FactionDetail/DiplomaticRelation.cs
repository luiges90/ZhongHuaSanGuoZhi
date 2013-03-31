﻿namespace GameObjects.FactionDetail
{
    using GameObjects;
    using System;

    public class DiplomaticRelation : GameObject
    {
        private int relation;
        private Faction relationFaction1;
        private int relationFaction1ID;
        private Faction relationFaction2;
        private int relationFaction2ID;
        private int truce;

        public DiplomaticRelation()
        {
            this.relationFaction1ID = -1;
            this.relationFaction2ID = -1;
        }

        public DiplomaticRelation(GameScenario scenario, int faction1ID, int faction2ID, int relation)
        {
            this.relationFaction1ID = -1;
            this.relationFaction2ID = -1;
            base.Scenario = scenario;
            this.RelationFaction1ID = faction1ID;
            this.RelationFaction2ID = faction2ID;
            this.Relation = relation;
        }

        public Faction GetDiplomaticFaction(int factionID)
        {
            if (factionID == this.RelationFaction1ID)
            {
                return this.RelationFaction2;
            }
            if (factionID == this.RelationFaction2ID)
            {
                return this.RelationFaction1;
            }
            return null;
        }

        public override int GetHashCode()
        {
            return (this.RelationFaction1ID.ToString() + " " + this.RelationFaction2ID.ToString()).GetHashCode();
        }

        public int GetTheOtherFactionID(int factionID)
        {
            if (factionID == this.RelationFaction1ID)
            {
                return this.RelationFaction2ID;
            }
            return this.RelationFaction1ID;
        }

        public int Relation
        {
            get
            {
                return this.relation;
            }
            set
            {
                this.relation = value;
            }
        }

        public int Truce
        {
            get
            {
                return this.truce;
            }
            set
            {
                this.truce = value;
            }
        }

        public Faction RelationFaction1
        {
            get
            {
                if (this.relationFaction1 == null)
                {
                    this.relationFaction1 = base.Scenario.Factions.GetGameObject(this.relationFaction1ID) as Faction;
                }
                return this.relationFaction1;
            }
        }

        public int RelationFaction1ID
        {
            get
            {
                return this.relationFaction1ID;
            }
            set
            {
                this.relationFaction1ID = value;
            }
        }

        public string RelationFaction1String
        {
            get
            {
                if (this.RelationFaction1 != null)
                {
                    return this.RelationFaction1.Name;
                }
                return "----";
            }
        }

        public Faction RelationFaction2
        {
            get
            {
                if (this.relationFaction2 == null)
                {
                    this.relationFaction2 = base.Scenario.Factions.GetGameObject(this.relationFaction2ID) as Faction;
                }
                return this.relationFaction2;
            }
        }

        public int RelationFaction2ID
        {
            get
            {
                return this.relationFaction2ID;
            }
            set
            {
                this.relationFaction2ID = value;
            }
        }

        public string RelationFaction2String
        {
            get
            {
                if (this.RelationFaction2 != null)
                {
                    return this.RelationFaction2.Name;
                }
                return "----";
            }
        }
    }
}

