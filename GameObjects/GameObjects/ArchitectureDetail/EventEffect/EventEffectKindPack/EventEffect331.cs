namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect331 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.CombatTitle.Influences.PurifyInfluence(person);
            person.CombatTitle = null;
        }
    }
}

