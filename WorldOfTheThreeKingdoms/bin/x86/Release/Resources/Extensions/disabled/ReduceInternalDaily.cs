using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class ReduceInternalDaily
{
	private double rate = 0.999;
	private double dominationRate = 0.99;
	public void DayEvent(GameScenario scen)
	{
		foreach (Architecture a in scen.Architectures)
		{
			a.Agriculture = (int) Math.Round(a.Agriculture * rate);
			a.Commerce = (int) Math.Round(a.Commerce * rate);
			a.Technology = (int) Math.Round(a.Technology * rate);
			a.Domination = (int) Math.Round(a.Domination * dominationRate);
			a.Morale = (int) Math.Round(a.Morale * rate);
			a.Endurance = (int) Math.Round(a.Endurance * rate);
		}
	}
}