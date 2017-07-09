namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect810 : EventEffectKind
    {
        
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedCaptive != null)
            {
                person.SetBelongedCaptive(null, GameObjects.PersonDetail.PersonStatus.Normal);
            }
            if (person.BelongedFaction != null)
            {
                person.BelongedFaction.Leader.XuanZeMeiNv(person);
            }
        }
    }
}

