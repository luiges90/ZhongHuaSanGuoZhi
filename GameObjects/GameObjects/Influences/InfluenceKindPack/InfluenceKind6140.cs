namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6140 : InfluenceKind
    {
        private int increment;
        private int threshold;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                if (person.LocationArchitecture.captiveLoyaltyExtraFall < this.increment)
                {
                    person.LocationArchitecture.captiveLoyaltyExtraFall = this.increment;
                }
                if (person.LocationArchitecture.captiveLoyaltyFallThreshold < this.threshold)
                {
                    person.LocationArchitecture.captiveLoyaltyFallThreshold = this.threshold;
                }
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.captiveLoyaltyExtraFall < this.increment)
            {
                a.captiveLoyaltyExtraFall = this.increment;
            }
            if (a.captiveLoyaltyFallThreshold < this.threshold)
            {
                a.captiveLoyaltyFallThreshold = this.threshold;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                person.LocationArchitecture.captiveLoyaltyExtraFall = 0;
                person.LocationArchitecture.captiveLoyaltyFallThreshold = 0;
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            a.captiveLoyaltyExtraFall = 0;
            a.captiveLoyaltyFallThreshold = 0;
        }

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.threshold = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

