﻿namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;


    internal class EventEffect2300 : EventEffectKind
    {
        private int increment;
        private int targetFactionID;

        public override void ApplyEffectKind(Faction f, Event e)
        {
            GameObjectList d = base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(f.ID);
            Faction f2 = f.Scenario.Factions.GetGameObject(targetFactionID) as Faction;
            //GameObjectList c = base.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(f2.ID);
            foreach (GameObjects.FactionDetail.DiplomaticRelation i in d)
            {
                if ((i.RelationFaction1ID == f.ID && i.RelationFaction2ID == f2.ID) || (i.RelationFaction1ID == f2.ID && i.RelationFaction2ID == f.ID))
                {
                    base.Scenario.ChangeDiplomaticRelation(f.ID, f2.ID, increment);
                }
            }
               
            //throw new Exception("targetFactionID=" + targetFactionID + "f的ID=" + f.ID);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.targetFactionID = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}