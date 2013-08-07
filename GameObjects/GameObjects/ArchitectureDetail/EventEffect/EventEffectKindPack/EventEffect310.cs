namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect310 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person, Event e)
        {
            GameObjects.PersonDetail.Title title = person.Scenario.GameCommonData.AllTitles.GetTitle(increment);
            if (title.Combat)
            {
                person.RealCombatTitle = title;
                title.Influences.ApplyInfluence(person, GameObjects.Influences.Applier.CombatTitle, 0);
            }
            else
            {
                person.RealPersonalTitle = title;
                title.Influences.ApplyInfluence(person, GameObjects.Influences.Applier.PersonalTitle, 0);
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

