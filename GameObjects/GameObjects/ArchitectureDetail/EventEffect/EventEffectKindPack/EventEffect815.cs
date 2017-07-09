namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect815 : EventEffectKind
    {
        
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null)
            {
                person.LeaveToNoFaction();
            }
        }
    }
}

