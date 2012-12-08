using System;
using System.Collections.Generic;
using GameObjects;
using GameGlobal;

public class ReduceInternalOnAttack
{
	private double rate = 0.97;
	public void ArchitectureReceiveDamage(GameScenario scen, Architecture a, ArchitectureDamage d)
	{
		if (a != null){
			a.Agriculture = (int) (a.Agriculture * rate);
			a.Commerce = (int) (a.Commerce * rate);
			a.Technology = (int) (a.Technology * rate);
			a.Morale = (int) (a.Morale * rate);
		}
	}
}