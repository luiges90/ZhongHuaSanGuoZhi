namespace GameObjects.Influences
{
    using GameObjects;
    using System;

    public class AreaInfluenceData
    {
        public AreaInfluenceKind Kind;
        public int Offset;
        public Troop Owner;
        public float Rate;

        public void ApplyAreaInfluence(Troop troop)
        {
            switch (this.Kind)
            {
                case AreaInfluenceKind.友军攻击力增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.OffenceRateIncrementByViewArea += this.Rate;
                    }
                    break;

                case AreaInfluenceKind.敌军攻击力减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.OffenceRateDecrementByViewArea -= this.Rate;
                    }
                    break;

                case AreaInfluenceKind.友军防御力增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.DefenceRateIncrementByViewArea += this.Rate;
                    }
                    break;

                case AreaInfluenceKind.敌军防御力减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.DefenceRateDecrementByViewArea -= this.Rate;
                    }
                    break;

                case AreaInfluenceKind.友军暴击几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceIncrementOfCriticalStrikeByViewArea += this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军暴击抵抗几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction) && (troop.ChanceDecrementOfCriticalStrikeByViewArea <= 0))
                    {
                        troop.ChanceDecrementOfCriticalStrikeByViewArea += this.Offset;
                        break;
                    }
                    break;

                case AreaInfluenceKind.友军计略成功几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceIncrementOfStratagemByViewArea += this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军计略抵抗几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceDecrementOfStratagemByViewArea += this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军战意每天增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.CombativityIncrementPerDayByViewArea += this.Offset;
                    }
                    break;

                case AreaInfluenceKind.敌军战意每天减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.CombativityDecrementPerDayByViewArea += this.Offset;
                    }
                    break;
            }
        }

        public void PurifyAreaInfluence(Troop troop)
        {
            switch (this.Kind)
            {
                case AreaInfluenceKind.友军攻击力增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.OffenceRateIncrementByViewArea -= this.Rate;
                    }
                    break;

                case AreaInfluenceKind.敌军攻击力减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.OffenceRateDecrementByViewArea += this.Rate;
                    }
                    break;

                case AreaInfluenceKind.友军防御力增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.DefenceRateIncrementByViewArea -= this.Rate;
                    }
                    break;

                case AreaInfluenceKind.敌军防御力减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.DefenceRateDecrementByViewArea += this.Rate;
                    }
                    break;

                case AreaInfluenceKind.友军暴击几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceIncrementOfCriticalStrikeByViewArea -= this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军暴击抵抗几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceDecrementOfCriticalStrikeByViewArea -= this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军计略成功几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceIncrementOfStratagemByViewArea -= this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军计略抵抗几率增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.ChanceDecrementOfStratagemByViewArea -= this.Offset;
                    }
                    break;

                case AreaInfluenceKind.友军战意每天增加:
                    if (this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.CombativityIncrementPerDayByViewArea -= this.Offset;
                    }
                    break;

                case AreaInfluenceKind.敌军战意每天减少:
                    if (!this.Owner.IsFriendly(troop.BelongedFaction))
                    {
                        troop.CombativityDecrementPerDayByViewArea -= this.Offset;
                    }
                    break;
            }
        }
    }
}

