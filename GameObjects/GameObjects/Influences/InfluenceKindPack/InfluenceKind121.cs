namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind121 : InfluenceKind
    {
        int i;

        public override void ApplyInfluenceKind(Architecture person)
        {
            if (person != null) 
            {
                person.InfluenceIncrementOfLoyalty += i;
            }
        }

        public override void PurifyInfluenceKind(Architecture person)
        {
            if (person != null)
            {
                person.InfluenceIncrementOfLoyalty -= i;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.i = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

