namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect222 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFactionWithPrincess != null)
            {
                person.Brothers.Add(person.BelongedFactionWithPrincess.Leader);
                person.BelongedFactionWithPrincess.Leader.Brothers.Add(person);
            }
        }

    }
}

