using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class AITroopGathering
{
	private int rate = 10;

	public void DayEvent(GameScenario scen)
	{
		foreach (Architecture a in scen.Architectures)
		{
			if (!scen.IsPlayer(a.BelongedFaction) && a.BelongedFaction != null)
			{
				int count = ((Faction) scen.PlayerFactions[0]).Architectures.Count;
				a.IncreaseFund(rate * count);
				a.IncreaseFood(rate * 100 * count);
			}
		}
	}
}