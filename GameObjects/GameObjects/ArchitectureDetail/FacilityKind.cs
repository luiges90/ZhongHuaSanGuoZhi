namespace GameObjects.ArchitectureDetail
{
    using GameObjects;
    using GameObjects.Influences;
    using GameObjects.Conditions;
    using System;

    public class FacilityKind : GameObject
    {
        private int days;
        private int endurance;
        private int fundCost;
        public InfluenceTable Influences = new InfluenceTable();
        public ConditionTable Conditions = new ConditionTable();
        private int maintenanceCost;
        private int pointCost;
        private bool populationRelated;
        private int positionOccupied;
        private int technologyNeeded;
        private bool uniqueInArchitecture;
        private bool uniqueInFaction;
        public bool bukechaichu
        {
            get;
            set;
        }
        public int rongna
        {
            get;
            set;
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public GameObjectList GetConditionList()
        {
            return this.Conditions.GetConditionList();
        }

        public double AIValue(Architecture a)
        {
            double influenceValue = double.MinValue;
            foreach (Influence i in this.Influences.GetInfluenceList())
            {
                double weight = i.AIFacilityValue(a);
                if (weight > influenceValue)
                {
                    influenceValue = weight;
                }
            }
            if (influenceValue < 0) return influenceValue;
            return (influenceValue - ((double) this.MaintenanceCost / a.ExpectedFund) * 30.0) * 1.0 / this.PositionOccupied;
        }

        public int Days
        {
            get
            {
                return this.days;
            }
            set
            {
                this.days = value;
            }
        }

        public string Description
        {
            get
            {
                string str = "";
                if (this.rongna > 0)
                {
                    str += "•可以容纳" + this.rongna + "名美女";
                }
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    str = str + "•" + influence.Description;
                }
                return str;
            }
        }

        public string ConditionString
        {
            get
            {
                string str = "";
                foreach (Condition i in this.Conditions.Conditions.Values)
                {
                    str = str + "•" + i.Name;
                }
                return str;
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                this.endurance = value;
            }
        }

        public int FundCost
        {
            get
            {
                return this.fundCost;
            }
            set
            {
                this.fundCost = value;
            }
        }

        public int InfluenceCount
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public int MaintenanceCost
        {
            get
            {
                return this.maintenanceCost;
            }
            set
            {
                this.maintenanceCost = value;
            }
        }

        public int PointCost
        {
            get
            {
                return this.pointCost;
            }
            set
            {
                this.pointCost = value;
            }
        }

        public bool PopulationRelated
        {
            get
            {
                return this.populationRelated;
            }
            set
            {
                this.populationRelated = value;
            }
        }

        public string PopulationRelatedString
        {
            get
            {
                return (this.PopulationRelated ? "○" : "×");
            }
        }

        public int PositionOccupied
        {
            get
            {
                return this.positionOccupied;
            }
            set
            {
                this.positionOccupied = value;
            }
        }

        public int TechnologyNeeded
        {
            get
            {
                return this.technologyNeeded;
            }
            set
            {
                this.technologyNeeded = value;
            }
        }

        public bool UniqueInArchitecture
        {
            get
            {
                return this.uniqueInArchitecture;
            }
            set
            {
                this.uniqueInArchitecture = value;
            }
        }

        public string UniqueInArchitectureString
        {
            get
            {
                return (this.UniqueInArchitecture ? "○" : "×");
            }
        }

        public bool UniqueInFaction
        {
            get
            {
                return this.uniqueInFaction;
            }
            set
            {
                this.uniqueInFaction = value;
            }
        }

        public string UniqueInFactionString
        {
            get
            {
                return (this.UniqueInFaction ? "○" : "×");
            }
        }


        public int NetFundIncrease
        {
            get
            {
                int fundIncrease = 0;
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 3000)
                    {
                        try
                        {
                            fundIncrease += int.Parse(i.Parameter);
                        }
                        catch
                        {
                        }
                    }
                }
                return fundIncrease - this.MaintenanceCost * 30;
            }
        }
    }
}

