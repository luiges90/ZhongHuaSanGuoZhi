namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect812 : EventEffectKind
    {
        
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFactionWithPrincess != null)
            {
                person.Marry(person.BelongedFactionWithPrincess.Leader, person.BelongedFactionWithPrincess.Leader);
            }
        }
    }
}

