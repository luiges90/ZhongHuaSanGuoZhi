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

        public bool CanBeBorn()
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (condition.Kind.ID == 901) return false;
            }
            return true;
        }

        public bool CanBeBorn(Person person)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (condition.Kind.ID == 901) return false;
                if (new List<int> { 600, 610, 970, 971 }.Contains(condition.Kind.ID))
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

        public string KindName
        {
            get
            {
                return this.Kind.Name;
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

        public string DetailedName
        {
            get
            {
                return this.Level + "级" + this.KindName + "「" + this.Name + "」";
            }
        }

        private double? aiPersonValue = null;
        public double AIPersonValue
        {
            get
            {
                if (aiPersonValue != null)
                {
                    return aiPersonValue.Value;
                }

                double d = 1;
                bool hasKind = false;
                bool hasType = false;

                double result = 0;
                foreach (Influence i in this.Influences.GetInfluenceList())
                {
                    switch (i.Kind.ID)
                    {
                        case 281:
                            d *= 0.8;
                            break;
                        case 290:
                            if (hasKind)
                            {
                                d *= 1.2;
                            }
                            else
                            {
                                hasKind = true;
                                d *= 0.4;
                            }
                            break;
                        case 300:
                            if (hasType)
                            {
                                d *= 1.1;
                                if (d > 1)
                                {
                                    d = 1;
                                }
                            }
                            else
                            {
                                hasKind = true;
                                d *= 0.2;
                            }
                            break;
                    }
                    result += i.AIPersonValue * d;
                }

                aiPersonValue = result;
                return result;
            }
        }

        private int? aiPersonLevel = null;
        public int AIPersonLevel
        {
            get
            {
                if (aiPersonLevel != null)
                {
                    return aiPersonLevel.Value;
                }
                aiPersonLevel = (int)(Math.Sqrt(Math.Max(1, AIPersonValue - 15)) * 0.2828 + 1);
                return aiPersonLevel.Value;
            }
        }
    }
}

