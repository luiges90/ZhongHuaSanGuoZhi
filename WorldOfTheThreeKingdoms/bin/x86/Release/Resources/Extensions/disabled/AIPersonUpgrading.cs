using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class AIPersonUpgrading
{
	private int rate = 20000;
	private double architectureRate = 1.5;

	public void DayEvent(GameScenario scen)
	{
		foreach (Person p in scen.Persons)
		{
			if (GameObject.Random((int) (rate / Math.Pow(((Faction) scen.PlayerFactions[0]).Architectures.Count, architectureRate))) == 0 && !scen.IsPlayer(p.BelongedFaction) && p.BelongedFaction != null)
			{
				int type = GameObject.Random(5);
				switch (type)
				{
					case 0: p.Strength++; break;
					case 1: p.Command++; break;
					case 2: p.Intelligence++; break;
					case 3: p.Politics++; break;
					case 4: p.Glamour++; break;
				}
			}
		}
	}
}