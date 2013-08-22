namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect222 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null)
            {
                if (person.Brother != null)
                {
                    person.BelongedFaction.Leader.Brother = person.Brother;
                }
                else if (person.BelongedFaction.Leader.Brother != null)
                {
                    person.Brother = person.BelongedFaction.Leader.Brother;
                }
                else
                {
                    person.Brother = person;
                    person.BelongedFaction.Leader.Brother = person;
                }
            }
        }

    }
}

