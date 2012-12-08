using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class EmperorFacility
{
	private void doWork(Faction f)
	{
		bool emperorExists = false;
		foreach (Faction i in f.Scenario.Factions)
		{
			if (i.guanjue == f.Scenario.GameCommonData.suoyouguanjuezhonglei.Count - 1) 
			{
				emperorExists = true;
			}
		}
		if (!emperorExists)
		{
			f.Capital.BuildFacility(f.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(68));
		}
	}

	public void BecomeEmperorLegally(GameScenario scen, Faction f)
	{
		doWork(f);
	}
	
	public void SelfBecomeEmperor(GameScenario scen, Faction f)
	{
		doWork(f);
	}
}