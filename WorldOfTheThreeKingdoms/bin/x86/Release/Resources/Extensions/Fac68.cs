using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;
using GameObjects.PersonDetail;

public class Fac68
{
	private Architecture fac68Location;
	public void DayEvent(GameScenario scen)
	{
		if (fac68Location == null)
		{
			foreach (Facility f in scen.Facilities)
			{
				if (f.KindID == 68)
				{
					fac68Location = f.location;
					break;
				}
			}
		}
		if (fac68Location != null)
		{
			Person leader = fac68Location.BelongedFaction.Leader;
			foreach (Captive c in fac68Location.BelongedFaction.Captives)
			{
				if (leader.isLegalFeiZi(c.CaptivePerson))
				{
					Person p = c.CaptivePerson;
					c.Clear();
					p.LocationArchitecture = fac68Location;
					p.Status = PersonStatus.Princess;
					p.Loyalty = 0;
				}
			}
		}
	}
	
	public void GoForHouGong(GameScenario scen, Person king, Person nvren)
	{
		if (king.LocationArchitecture == fac68Location) 
		{
			if (!nvren.huaiyun && !king.huaiyun && king.isLegalFeiZi(nvren) &&
			(king.LocationArchitecture.BelongedFaction.Leader.meichushengdehaiziliebiao().Count - king.LocationArchitecture.yihuaiyundefeiziliebiao().Count > 0 || GlobalVariables.createChildren))
			{
				if (GameObject.Chance(10))
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
}