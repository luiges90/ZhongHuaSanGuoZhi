namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect213 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.LocationArchitecture != null)
            {
                person.LocationArchitecture.RemovePersonFromWorkingList(person);
                Architecture originalLocationArch = person.LocationArchitecture;
                originalLocationArch.RemovePerson(person);
                originalLocationArch.BelongedFaction.RemovePerson(person);
                originalLocationArch.feiziliebiao.Add(person);
                person.suozaijianzhu = originalLocationArch;
            }
        }

    }
}

