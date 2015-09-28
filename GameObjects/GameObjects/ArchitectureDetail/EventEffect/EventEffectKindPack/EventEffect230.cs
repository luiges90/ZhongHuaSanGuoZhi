namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect230 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null) 
			{
				person.AdjustRelation(person.BelongedFaction.Leader, 0, increment);
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

