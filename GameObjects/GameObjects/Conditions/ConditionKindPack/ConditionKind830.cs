namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;
    using System.Collections.Generic;

    internal class ConditionKind830 : ConditionKind
    {
        private int number = 0;

        public override bool CheckConditionKind(Person person)
        {
            HashSet<int> relatedPersons = new HashSet<int>();
            foreach (Person p in person.Scenario.Persons)
            {
                if (p.Father == person.ID)
                {
                    relatedPersons.Add(p.Mother);   
                }
                if (p.Mother == person.ID)
                {
                    relatedPersons.Add(p.Father);
                }
            }
            return relatedPersons.Count >= number;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.number = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

