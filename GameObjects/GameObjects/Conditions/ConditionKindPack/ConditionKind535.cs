namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind535 : ConditionKind
    {
        private int personID;

        public override bool CheckConditionKind(Person person)
        {
            Person p1 = person.Scenario.Persons.GetGameObject(personID) as Person;
            return !(person.BelongedFactionWithPrincess != null && p1.BelongedFactionWithPrincess != null && person.BelongedFactionWithPrincess == p1.BelongedFactionWithPrincess);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.personID = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}