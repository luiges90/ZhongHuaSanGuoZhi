namespace GameObjects.PersonDetail.PersonMessages
{
    using GameObjects;
    using System;

    internal class SpyMessagePersonPack
    {
        public int Days;
        public Person MessagePerson;

        internal SpyMessagePersonPack(Person person, int days)
        {
            this.MessagePerson = person;
            this.Days = days;
        }
    }
}

