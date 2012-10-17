namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect221 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            (person.Scenario.Persons.GetGameObject(person.Spouse) as Person).Spouse = -1;
            person.Spouse = -1;
        }

    }
}

