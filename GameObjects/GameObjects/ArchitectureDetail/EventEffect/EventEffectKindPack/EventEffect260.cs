namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect260 : EventEffectKind
    {
        private float  n;

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.n = float.Parse(parameter);
                //targetFaction = factions.GetGameObject(int.Parse(parameter)) as Faction;
            }
            catch
            {
                
            }
           
        }


        public override void ApplyEffectKind(Person person, Event e)
        {
            person.InjureRate += n;
        }

       

    }
}

