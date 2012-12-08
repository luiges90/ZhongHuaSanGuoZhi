using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class RelationAddPregnantChance
{
	public void GoForHouGong(GameScenario scen, Person king, Person nvren)
	{
		if (!nvren.huaiyun && !king.huaiyun && king.isLegalFeiZi(nvren) &&
		(king.LocationArchitecture.BelongedFaction.Leader.meichushengdehaiziliebiao().Count - king.LocationArchitecture.yihuaiyundefeiziliebiao().Count > 0 || GlobalVariables.createChildren))
		{
			int extraRate = 0;
			if (nvren.ClosePersons.Contains(king.ID))
			{
				extraRate += 5;
			}
			if (king.ClosePersons.Contains(nvren.ID))
			{
				extraRate += 5;
			}
			if (king.Ideal == nvren.Ideal)
			{
				extraRate += 10;
			}
			if (king.Spouse == nvren.ID)
			{
				extraRate += 30;
			}
			if (GameObject.Chance(extraRate))
			{
				nvren.suoshurenwu = king.ID;
				king.suoshurenwu = nvren.ID;
				if (nvren.Sex)
				{
					nvren.huaiyun = true;
					nvren.huaiyuntianshu = -GameObject.Random(king.ArrivingDays);
				}
				else
				{
					king.huaiyun = true;
					king.huaiyuntianshu = -GameObject.Random(king.ArrivingDays);
				}
			}
		}
	}
}