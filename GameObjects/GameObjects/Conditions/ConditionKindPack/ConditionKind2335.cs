namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2335 : ConditionKind
    {
        private int val;

        public override bool CheckConditionKind(Architecture a)
        {
            return a.feiziliebiao.Count < val;
        }

        public override bool CheckConditionKind(Faction faction)
        {
            int result = 0;
            foreach (Architecture a in faction.Architectures)
            {
                result += a.feiziliebiao.Count;
            }
            return result < val;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.val = int.Parse(parameter);
            }
            catch
            {
            }
        }

    }
}

