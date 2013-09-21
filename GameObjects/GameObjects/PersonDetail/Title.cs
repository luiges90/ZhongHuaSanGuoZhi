namespace GameObjects.PersonDetail
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using GameObjects.TroopDetail;
    using System;
    using System.Collections.Generic;

    public class Title : GameObject
    {
        private bool combat;
        public ConditionTable Conditions = new ConditionTable();
        public InfluenceTable Influences = new InfluenceTable();
        private TitleKind kind;
        private int level;

        private bool? containsLeaderOnlyCache = null;
        public bool ContainsLeaderOnly
        {
            get
            {
                if (containsLeaderOnlyCache != null)
                {
                    return containsLeaderOnlyCache.Value;
                }
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 281)
                    {
                        containsLeaderOnlyCache = true;
                        return true;
                    }
                }
                containsLeaderOnlyCache = false;
                return false;
            }
        }

        public MilitaryType MilitaryTypeOnly
        {
            get
            {
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 290)
                    {
                        return (MilitaryType)Enum.Parse(typeof(MilitaryType), i.Parameter);
                    }
                }
                return MilitaryType.其他;
            }
        }


        public int MilitaryKindOnly
        {
            get
            {
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 300)
                    {
                        return int.Parse(i.Parameter);
                    }
                }
                return -1;
            }
        }

        public void AddInfluence(Influence influence)
        {
            this.Influences.AddInfluence(influence);
        }

        public virtual bool CanLearn(Person person)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (!condition.CheckCondition(person))
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool CanBeBorn(Person person)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (condition == base.Scenario.GameCommonData.AllConditions.GetCondition(901)) return false;
                if (new List<int> { 600, 610, 970, 971 }.Contains(condition.ID))
                {
                    if (!condition.CheckCondition(person))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public GameObjectList GetConditionList()
        {
            return this.Conditions.GetConditionList();
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public bool Combat
        {
            get
            {
                return this.combat;
            }
            set
            {
                this.combat = value;
            }
        }

        public int ConditionCount
        {
            get
            {
                return this.Conditions.Count;
            }
        }

        private string DescriptionCache;
        public string Description
        {
            get
            {
                if (DescriptionCache == null)
                {
                    string str = "";
                    foreach (Influence influence in this.Influences.Influences.Values)
                    {
                        str = str + "•" + influence.Description;
                    }
                    DescriptionCache = str;
                }
                return DescriptionCache;
            }
        }

        public int InfluenceCount
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public TitleKind Kind
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

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public int Merit
        {
            get
            {
                return (int) (Math.Pow(this.level, 1.5) * 15);
            }
        }

        private int? fightingMerit = null;
        public int FightingMerit
        {
            get
            {
                if (fightingMerit == null)
                {
                    int combatInfluences = 0;
                    foreach (Influence i in this.Influences.Influences.Values)
                    {
                        if (i.Kind.Combat)
                        {
                            combatInfluences++;
                        }
                    }
                    fightingMerit = (int) (this.Merit * ((double)combatInfluences / this.Influences.Count));
                }
                return fightingMerit.Value;
            }
        }

        private int? subOfficerMerit = null;
        public int SubOfficerMerit
        {
            get
            {
                if (subOfficerMerit == null)
                {
                    int subofficerInfluences = 0;
                    foreach (Influence i in this.Influences.Influences.Values)
                    {
                        if (i.Kind.ID == 281) break;
                        if (i.Kind.Combat)
                        {
                            subofficerInfluences++;
                        }
                    }
                    subOfficerMerit = (int)(this.Merit * ((double)subofficerInfluences / this.Influences.Count));
                }
                return subOfficerMerit.Value;
            }
        }

        public string Prerequisite
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.Conditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }

    }
}

