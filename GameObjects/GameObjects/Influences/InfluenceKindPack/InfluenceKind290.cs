namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind290 : InfluenceKind
    {
        private int militaryTypeID;

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.militaryTypeID = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override bool IsVaild(Person person)
        {
            return ((person.LocationTroop != null) && ((int) person.LocationTroop.Army.Kind.Type == this.militaryTypeID));
        }
    }
}

