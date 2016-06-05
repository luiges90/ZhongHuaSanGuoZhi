namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect355 : EventEffectKind
    {
        private int decrement;

        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null && person != person.BelongedFaction.Leader)
            {
                int idealOffset = Person.GetIdealOffset(person, person.BelongedFaction.Leader);

                idealOffset -= decrement;
            }

        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.decrement = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}