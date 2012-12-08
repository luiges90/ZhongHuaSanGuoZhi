using System;
using System.Collections.Generic;
using GameObjects;
using GameObjects.TroopDetail;
using GameGlobal;

public class AIResourceGathering
{
	private int rate = 3000;
	private double architectureRate = 1.5;

	public void DayEvent(GameScenario scen)
	{
		foreach (Architecture a in scen.Architectures)
		{
			if (GameObject.Random((int) (rate / Math.Pow(((Faction) scen.PlayerFactions[0]).Architectures.Count, architectureRate))) == 0 && !scen.IsPlayer(a.BelongedFaction) && a.BelongedFaction != null)
			{
				MilitaryKindList mkl = (MilitaryKindList) scen.GameCommonData.AllMilitaryKinds.GetMilitaryKindList();
				MilitaryKind mk = (MilitaryKind) scen.GameCommonData.AllMilitaryKinds.GetMilitaryKind(GameObject.Random(3));
				Military military = Military.Create(scen, a, mk.findSuccessorCreatable(mkl, a));
				military.IncreaseQuantity(30000);
			}
		}
	}
}