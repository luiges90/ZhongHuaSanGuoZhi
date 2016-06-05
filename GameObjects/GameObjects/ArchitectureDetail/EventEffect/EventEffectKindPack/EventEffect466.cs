namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect466 : EventEffectKind
    {
        private int decrement;

        public override void ApplyEffectKind(Person person, Event e)
        {
            person.Ideal -= decrement;
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