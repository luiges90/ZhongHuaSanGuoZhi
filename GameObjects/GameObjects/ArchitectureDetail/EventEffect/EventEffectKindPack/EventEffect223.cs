namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect223 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.Brother = null;
        }

    }
}

