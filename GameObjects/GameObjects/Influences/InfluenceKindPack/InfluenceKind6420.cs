namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6420 : InfluenceKind
    {
        private int increment;
        private int disasterId;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                if (person.LocationArchitecture.disasterChanceDecrease.ContainsKey(disasterId))
                {
                    person.LocationArchitecture.disasterChanceDecrease[disasterId] += this.increment;
                }
                else
                {
                    person.LocationArchitecture.disasterChanceDecrease[disasterId] = this.increment;
                }
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.disasterChanceDecrease.ContainsKey(disasterId))
            {
                a.disasterChanceDecrease[disasterId] += this.increment;
            }
            else
            {
                a.disasterChanceDecrease[disasterId] = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture.disasterChanceDecrease.ContainsKey(disasterId))
            {
                person.LocationArchitecture.disasterChanceDecrease[disasterId] -= this.increment;
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.disasterChanceDecrease.ContainsKey(disasterId))
            {
                a.disasterChanceDecrease[disasterId] -= this.increment;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.disasterId = int.Parse(parameter);
            }
            catch
            {
            }
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
    }
}

