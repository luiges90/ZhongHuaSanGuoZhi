﻿namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect1300 : EventEffectKind
    {
        private int id;

        public override void ApplyEffectKind(Architecture a, Event e)
        {
            a.zainan.zainanzhonglei = base.Scenario.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei(id);
            a.zainan.shengyutianshu = a.zainan.zainanzhonglei.shijianxiaxian + GameObject.Random(a.zainan.zainanzhonglei.shijianshangxian - a.zainan.zainanzhonglei.shijianxiaxian);
            a.youzainan = true;
            foreach (Military military in a.Militaries)//发生灾难时不能补充
            {
                military.StopRecruitment();
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.id = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

