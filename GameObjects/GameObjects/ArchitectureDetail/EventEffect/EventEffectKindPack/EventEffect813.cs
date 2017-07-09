namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect813 : EventEffectKind
    {
        
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.BeAvailable();
        }
    }
}

