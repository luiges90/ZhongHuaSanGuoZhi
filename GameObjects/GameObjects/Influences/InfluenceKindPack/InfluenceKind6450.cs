namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6450 : InfluenceKind
    {
        private int increment;
        private int disasterId;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                foreach (LinkNode i in person.LocationArchitecture.AIAllLinkNodes.Values)
                {
                    if (i.A.disasterChanceIncrease.ContainsKey(disasterId))
                    {
                        i.A.disasterChanceIncrease[disasterId] += this.increment;
                    }
                    else
                    {
                        i.A.disasterChanceIncrease[disasterId] = this.increment;
                    }
                }
            }
        }

        public override void ApplyInfluenceKind(Architecture a)
        {
            foreach (LinkNode i in a.AIAllLinkNodes.Values)
            {
                if (i.A.disasterChanceIncrease.ContainsKey(disasterId))
                {
                    i.A.disasterChanceIncrease[disasterId] += this.increment;
                }
                else
                {
                    i.A.disasterChanceIncrease[disasterId] = this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationArchitecture != null)
            {
                foreach (LinkNode i in person.LocationArchitecture.AIAllLinkNodes.Values)
                {
                    i.A.disasterChanceIncrease[disasterId] -= this.increment;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            foreach (LinkNode i in a.AIAllLinkNodes.Values)
            {
                i.A.disasterChanceIncrease[disasterId] -= this.increment;
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

