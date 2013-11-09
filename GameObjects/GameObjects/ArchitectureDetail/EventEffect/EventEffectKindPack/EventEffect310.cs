namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using GameObjects.PersonDetail;
    using System;
    using System.Collections.Generic;

    internal class EventEffect310 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person, Event e)
        {
            Title title = person.Scenario.GameCommonData.AllTitles.GetTitle(increment);

            List<Title> oldTitles = new List<Title>(person.RealTitles);
            foreach (Title t in oldTitles)
            {
                if (t.Kind == title.Kind)
                {
                    t.Influences.PurifyInfluence(person, GameObjects.Influences.Applier.Title, t.ID);
                    person.RealTitles.Remove(t);
                }
            }
            person.RealTitles.Add(title);
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

