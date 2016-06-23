namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect350 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null && person != person.BelongedFaction.Leader)
            {
                int idealOffset = Person.GetIdealOffset(person , person.BelongedFaction.Leader);

                idealOffset += increment;
            }

        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}