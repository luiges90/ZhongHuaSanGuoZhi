namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect315 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person, Event e)
        {
            GameObjects.PersonDetail.Title title = person.Scenario.GameCommonData.AllTitles.GetTitle(increment);
            if (person.CombatTitle == title)
            {
                person.CombatTitle = null;
                title.Influences.PurifyInfluence(person, GameObjects.Influences.Applier.CombatTitle, 0);
            }
            else if (person.PersonalTitle == title)
            {
                person.PersonalTitle = null;
                title.Influences.PurifyInfluence(person, GameObjects.Influences.Applier.PersonalTitle, 0);
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

