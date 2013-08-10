﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GameFreeText;
using GameGlobal;
using GameObjects;

using GameObjects.FactionDetail;
using GameObjects.PersonDetail;
using GameObjects.PersonDetail.PersonMessages;
using GameObjects.SectionDetail;
using GameObjects.TroopDetail;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PluginInterface;
using WMPLib;
using WorldOfTheThreeKingdoms.GameLogic;
using WorldOfTheThreeKingdoms.GameScreens;
using WorldOfTheThreeKingdoms.GameScreens.ScreenLayers;
using WorldOfTheThreeKingdoms.Resources;

namespace WorldOfTheThreeKingdoms.GameScreens
{
    partial class MainGameScreen : Screen
    {
        public override void renwudaodatishi(Person person, Architecture architecture)
        {
            if (base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                person.TextResultString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonArrive", architecture.Position);
            }
        }

        public override void renwukaishitishi(Person person, Architecture architecture)
        {
            if (base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                person.TextResultString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonTravel", architecture.Position);
            }
        }

        public override void ArchitectureBeginRecentlyAttacked(Architecture architecture)
        {
            if (base.Scenario.IsCurrentPlayer(architecture.BelongedFaction) && architecture.BelongedFaction != null)
            {
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(architecture.BelongedFaction.Leader, architecture, "ArchitectureBeginRecentlyAttacked", "zaoshougongji.jpg", "");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
                /*architecture.BelongedFaction.Leader.TextResultString = architecture.Name;
                architecture.BelongedFaction.TextResultString = architecture.Name;
                this.xianshishijiantupian(architecture.BelongedFaction.Leader, architecture.BelongedFaction.Leader.TextResultString, "ArchitectureBeginRecentlyAttacked", "zaoshougongji.jpg", "", false);
                */
                architecture.BelongedFaction.TextResultString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(architecture.BelongedFaction, "zaoshougongji", architecture.Position);
                if (architecture.BelongedFaction.StopToControl)
                {
                    this.Plugins.DateRunnerPlugin.Pause();
                    architecture.BelongedFaction.StopToControl = false;


                }
            }

        }

        public override void ArchitectureFacilityCompleted(Architecture architecture, Facility facility)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                architecture.TextDestinationString = facility.Name;
                if (base.Scenario.IsCurrentPlayer(architecture.BelongedFaction) && architecture.BelongedFaction != null)
                {
                    if (!((facility.PositionOccupied <= 1) && GlobalVariables.NoHintOnSmallFacility))
                    {   /*
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(architecture.BelongedFaction.Leader, architecture, "ArchitectureFacilityCompleted");
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                         */
                        string sheshitupian = "../sheshi/sheshi" + facility.KindID.ToString() + ".jpg";
                        this.xianshishijiantupian(architecture.BelongedFaction.Leader,architecture.Name  , "ArchitectureFacilityCompleted", sheshitupian, "sheshiwancheng.wav",facility.Kind.Name,false ); 
                    }
                }
                else if (facility.UniqueInArchitecture && (facility.PositionOccupied > 4))
                {
                    this.Plugins.GameRecordPlugin.AddBranch(architecture, "FacilityCompleted", architecture.Position);
                }
            }
        }

        public override void Architecturefashengzainan(Architecture architecture, int zainanID)
        {
            if (((base.Scenario.CurrentPlayer != null) && architecture.BelongedFaction!=null  && base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                string zainanming = base.Scenario.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei(zainanID).Name;
                if (base.Scenario.IsCurrentPlayer(architecture.BelongedFaction) && architecture.BelongedFaction != null)
                {
                    this.xianshishijiantupian(architecture.BelongedFaction.Leader, architecture.Name, "fashengzainan", "zainan" + zainanID.ToString() + ".jpg", "zainan" + zainanID.ToString() + ".wav", zainanming, false);
                    /*
                    architecture.TextDestinationString = zainanming;
                    this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(architecture.BelongedFaction.Leader, architecture, "fashengzainan");
                    this.Plugins.tupianwenziPlugin.IsShowing = true;
                    */
                }
                architecture.TextDestinationString = zainanming;

                this.Plugins.GameRecordPlugin.AddBranch(architecture, "fashengzainan", architecture.Position);

            }
        }

        public override void ArchitectureHirePerson(PersonList personList)
        {
            Person person = personList[0] as Person;
            //if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            if ((base.Scenario.CurrentPlayer != null) && base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                foreach (Person person2 in personList)
                {
                    person2.TextResultString = person2.LocationArchitecture.Name;
                    person2.TextDestinationString = person2.BelongedFaction.Name;

                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person2, person2, "ArchitectureHirePerson");
                    this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                    this.Plugins.tupianwenziPlugin.IsShowing = true;

                    //this.Plugins.PersonBubblePlugin.AddPerson(person2, person2.Position, "HirePerson");
                    //person2.TextDestinationString = person2.BelongedFaction.Name;
                    this.Plugins.GameRecordPlugin.AddBranch(person2, "HirePerson", person2.Position);
                }
            }
        }



        public override void ArchitecturePopulationEnter(Architecture a, int quantity)
        {
            if ((GlobalVariables.HintPopulation && (GlobalVariables.HintPopulationUnder1000 || (quantity >= 0x3e8))) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(a)) || GlobalVariables.SkyEye))
            {
                a.TextResultString = quantity.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(a, "ArchitecturePopulationEnter", a.Position);
            }
        }

        public override void ArchitecturePopulationEscape(Architecture a, int quantity)
        {
            if ((GlobalVariables.HintPopulation && (GlobalVariables.HintPopulationUnder1000 || (quantity >= 0x3e8))) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(a)) || GlobalVariables.SkyEye))
            {
                a.TextResultString = quantity.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(a, "ArchitecturePopulationEscape", a.Position);
            }
        }

        public override void ArchitectureReleaseCaptiveAfterOccupied(Architecture architecture, PersonList persons)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(architecture)) || GlobalVariables.SkyEye)
            {
                Person person = persons[StaticMethods.Random(persons.Count)] as Person;
                architecture.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureReleaseCaptive", architecture.Position);
            }
        }

        public override void ArchitectureRewardPersons(Architecture architecture, GameObjectList personlist)
        {
            if ((personlist.Count > 0) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye))
            {
                this.Plugins.PersonBubblePlugin.AddPerson(personlist[GameObject.Random(personlist.Count)], architecture.Position, "RewardPerson");
            }
        }

        public override void CaptivePlayerRelease(Faction from, Faction to, Captive captive)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsPlayer(from))
            {
                this.Plugins.tupianwenziPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(captive.ReleaseCaptive), new GameDelegates.VoidFunction(captive.ReturnRansom));
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(from.Leader, captive, "ReleaseCaptive");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void CaptiveRelease(bool success, Faction from, Faction to, Person person)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(from)) || base.Scenario.IsCurrentPlayer(to)) || GlobalVariables.SkyEye)
            {
                to.TextDestinationString = from.Name;
                to.TextResultString = person.Name;
                if (success)
                {
                    this.Plugins.GameRecordPlugin.AddBranch(to, "CaptiveReleaseSuccess", from.Capital.Position);
                }
                else
                {
                    if ((base.Scenario.CurrentPlayer != null) && base.Scenario.IsCurrentPlayer(to))
                    {
                        this.Plugins.GameRecordPlugin.AddBranch(to, "CaptiveReleaseFailed", from.Capital.Position);
                    }
                }
            }
        }

        public override void FactionAfterCatchLeader(Person leader, Faction faction)
        {
            if (base.Scenario.IsPlayer(faction))
            {
                this.Plugins.tupianwenziPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(leader.PlayerKillLeader), null);
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(leader, leader, "FactionAfterCatchLeader");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void FactionDestroy(Faction faction)
        {
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionDestroy", (faction.Capital != null) ? faction.Capital.Position : base.Scenario.ScenarioMap.JumpPosition);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }

            this.xianshishijiantupian(neutralPerson, faction.Name, "FactionDestroy", "shilimiewang.jpg", "shilimiewang.wma",true );
            /*
            neutralPerson.TextDestinationString = faction.Name;
            this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.tupianwenziPlugin.SetGameObjectBranch(neutralPerson, neutralPerson, "FactionDestroy");
            this.Plugins.tupianwenziPlugin.IsShowing = true;
             */
        }

        public override void FactionForcedChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital)
        {
            faction.TextDestinationString = oldCapital.Name;
            faction.TextResultString = newCapital.Name;
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionForcedChangeCapital", newCapital.Position);
        }

        public override void FactionGetControl(Faction faction)
        {
            base.Scenario.CurrentPlayer = faction;
            this.Plugins.AirViewPlugin.ReloadTroopView();
            this.gengxinyoucelan();
            if (faction.IsPositionKnown(faction.Leader.Position) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(faction.Leader, faction.Leader.Position, "GetControl");
            }
            base.PlayNormalSound("GameSound/Control/Control.wav");
        }

        public override void FactionInitialtiveChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital)
        {
            if (oldCapital != null)
            {
                faction.TextDestinationString = oldCapital.Name;
            }
            else
            {
                faction.TextDestinationString = "----";
            }
            faction.TextResultString = newCapital.Name;
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionInitialtiveChangeCapital", newCapital.Position);
        }

        public override void FactionTechniqueFinished(Faction faction, Technique technique)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(faction)) || GlobalVariables.SkyEye)
            {
                faction.Leader.TextDestinationString = technique.Name;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(faction.Leader, faction.Leader, "FactionTechniqueFinished");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void FactionUpgradeTechnique(Faction faction, Technique technique, Architecture architecture)
        {
            if (!base.Scenario.IsCurrentPlayer(faction))
            {
                faction.TextDestinationString = technique.Name;
                this.Plugins.GameRecordPlugin.AddBranch(faction, "UpgradeTechnique", faction.Capital.Position);
            }
        }

        public override void shilijingong(Faction faction,int jingongzijin,string jingongzhonglei)
        {
            //this.xianshishijiantupian(faction.Leader, jingongzijin.ToString(), "shilijingong", "shilijingong.jpg", "");
            faction.TextResultString = jingongzijin.ToString();
            faction.TextDestinationString = jingongzhonglei;
            
            this.Plugins.GameRecordPlugin.AddBranch(faction, "shilijingong", faction.Capital.Position);


        }

        public override void GameEndWithUnite(Faction faction)
        {
            faction.TextResultString = base.Scenario.Date.ToDateString();
            this.Plugins.GameRecordPlugin.AddBranch(faction, "GameEndWithUnite", faction.Capital.Position);
            this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.tupianwenziPlugin.SetGameObjectBranch(faction.Leader, faction.Leader, "GameEndWithUnite");
            this.Plugins.tupianwenziPlugin.IsShowing = true;
            base.Scenario.YearTable.addGameEndWithUniteEntry(base.Scenario.Date, faction);
        }

        public override void PersonBeAwardedTreasure(Person person, Treasure t)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = t.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonBeAwardedTreasure");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;


            }
        }

        public override void faxianhuaiyun(Person person)
        {
            if (((base.Scenario.CurrentPlayer != null) && person.BelongedArchitecture != null && 
                    base.Scenario.IsCurrentPlayer(person.BelongedArchitecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                //person.TextResultString = t.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "faxianhuaiyun");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;


            }
        }

        public override void xiaohaichusheng(Person father, Person person)
        {
            if (((base.Scenario.CurrentPlayer != null) && father.BelongedArchitecture != null &&
                    base.Scenario.IsCurrentPlayer(father.BelongedArchitecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = person.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(father, father, "xiaohaichusheng");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;

            }

        }
        public override void haizizhangdachengren(Person father, Person person)
        {
            if (((base.Scenario.CurrentPlayer != null) && person.BelongedArchitecture != null &&
                    base.Scenario.IsCurrentPlayer(person.BelongedArchitecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                //person.TextResultString = t.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "haizizhangdachengren");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;


            }
        }

        public override void xianshishijiantupian(Person p, string TextResultString, string shijian, string tupian, string shengyin,bool zongshixianshi)
        {
            if (base.Scenario.CurrentPlayer == null) return;

            if (shijian == "CaptiveEscape")
            {
                if (p.BelongedFaction == base.Scenario.CurrentPlayer || base.Scenario.CurrentPlayer.Captives.HasGameObject(p.BelongedCaptive))
                {
                    zongshixianshi = true;
                    p.TextResultString = TextResultString;
                    this.Plugins.GameRecordPlugin.AddBranch(p, "CaptiveEscape", p.Position);
                }



            }
            if ((zongshixianshi) || p.BelongedFaction == base.Scenario.CurrentPlayer)
            {



                p.TextResultString = TextResultString;
                //p.TextDestinationString = architecture.BelongedFaction.LeaderName;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(p, p, shijian, tupian, shengyin);
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
                this.PauseMusic();
                this.tufashijianzantingyinyue = true;

            }
        }

        public override void xianshishijiantupian(Person p, string TextResultString, string shijian, string tupian, string shengyin, string TextDestinationString,bool zongshixianshi)
        {
            /*
            if (troop.BelongedFaction == base.Scenario.CurrentPlayer || architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {

            }
            */
            if (base.Scenario.CurrentPlayer == null) return;

            if ((zongshixianshi) || p.BelongedFaction == base.Scenario.CurrentPlayer)
            {



                p.TextResultString = TextResultString;
                p.TextDestinationString = TextDestinationString;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(p, p, shijian, tupian, shengyin);
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
                this.PauseMusic();
                this.tufashijianzantingyinyue = true;

            }
        }

        public override void PersonBeConfiscatedTreasure(Person person, Treasure t)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = t.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonBeConfiscatedTreasure");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }


        }

        public void PersonBeiDuoqi(Person person, Faction t)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(t)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = t.LeaderName;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "wujiangbeiduoqi");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }


        }


        public override void PersonBeKilled(Person person, Architecture location)
        {
            location.TextDestinationString = person.Name;
            this.Plugins.GameRecordPlugin.AddBranch(location, "PersonBeKilled", location.Position);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }
            this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.tupianwenziPlugin.SetGameObjectBranch(neutralPerson, location, "PersonBeKilled");
            this.Plugins.tupianwenziPlugin.IsShowing = true;
        }

        public override void PersonChangeLeader(Faction faction, Person leader, bool changeName, string oldName)
        {
            if (!changeName)
            {
                leader.TextDestinationString = oldName;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(leader, leader, "FactionChangeLeaderKeepName");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
            else
            {
                leader.TextDestinationString = oldName;
                leader.TextResultString = faction.Name;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(leader, leader, "FactionChangeLeaderChangeName");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonConvinceFailed(Person source, Person destination)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(source.BelongedFaction)) || base.Scenario.IsCurrentPlayer(destination.BelongedFaction))
            {
                source.TextDestinationString = destination.Name;
                this.Plugins.GameRecordPlugin.AddBranch(source, "PersonConvinceFailed", source.OutsideDestination.Value);
            }
        }

        public override void PersonConvinceSuccess(Person source, Person destination, Faction oldFaction)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(source.BelongedFaction)) || base.Scenario.IsCurrentPlayer(oldFaction)) || GlobalVariables.SkyEye)
            {
                source.TextDestinationString = destination.Name;
                this.Plugins.GameRecordPlugin.AddBranch(source, "PersonConvinceSuccess", source.OutsideDestination.Value);
            }
        }

        public override void PersonDeath(Person person, Architecture location)
        {
            location.TextDestinationString = person.Name;
            this.Plugins.GameRecordPlugin.AddBranch(location, "PersonDeath", location.Position);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }
            this.xianshishijiantupian(neutralPerson, person.Name, "renwusiwang", person.ID.ToString() , "renwusiwang.wav",location.Name ,true);
            /*
            this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.tupianwenziPlugin.SetGameObjectBranch(neutralPerson, location, "PersonDeath");
            this.Plugins.tupianwenziPlugin.IsShowing = true;
             */
        }

        public override void PersonDeathChangeFaction(Person dead, Person leader, string oldName)
        {
            leader.BelongedFaction.TextDestinationString = oldName;
            leader.BelongedFaction.TextResultString = leader.BelongedFaction.Name;
            this.Plugins.GameRecordPlugin.AddBranch(leader.BelongedFaction, "FactionLeaderDeathFactionChange", leader.BelongedFaction.Capital.Position);
            this.xianshishijiantupian(leader, dead.RespectfulName, "FactionLeaderDeathChangeFaction", "", "", oldName,true );
            /*
            leader.BelongedFaction.TextResultString = dead.RespectfulName;
            this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.tupianwenziPlugin.SetGameObjectBranch(leader, leader.BelongedFaction, "FactionLeaderDeathChangeFaction");
            this.Plugins.tupianwenziPlugin.IsShowing = true;
             */
 
        }

        public override void PersonDestroyFailed(Person person, Architecture architecture)
        {
            if (person.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonDestroyArchitectureFailed", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureDestroyedFailed", architecture.Position);
            }
        }

        public override void PersonDestroySuccess(Person person, Architecture architecture, int down)
        {
            if ((person.BelongedFaction == base.Scenario.CurrentPlayer) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonDestroyArchitectureSuccess", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                architecture.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureDestroyedSuccess", architecture.Position);
            }
        }

        public override void PersonGossipFailed(Person person, Architecture architecture)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction))
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonGossipFailed", person.OutsideDestination.Value);
            }
        }

        public override void PersonGossipSuccess(Person person, Architecture architecture)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonGossipSuccess", person.OutsideDestination.Value);
            }
        }

        public override void PersonInformationObtained(Person person, Information information)
        {
            if (base.Scenario.CurrentPlayer == person.BelongedFaction)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(person, person.Position, "InformationObtained");
                this.Plugins.GameRecordPlugin.AddBranch(person, "qingbaochenggong", person.Position);
            }
        }

        public override void qingbaoshibai(Person person)
        {
            if (base.Scenario.CurrentPlayer == person.BelongedFaction)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(person, person.Position, "qingbaoshibai");
                this.Plugins.GameRecordPlugin.AddBranch(person, "qingbaoshibai", person.Position);

            }
        }


        public override void PersonInstigateFailed(Person person, Architecture architecture)
        {
            if (person.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonInstigateArchitectureFailed", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureInstigatedFailed", architecture.Position);
            }
        }

        public override void PersonInstigateSuccess(Person person, Architecture architecture, int down)
        {
            if ((person.BelongedFaction == base.Scenario.CurrentPlayer) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonInstigateArchitectureSuccess", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                architecture.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureInstigatedSuccess", architecture.Position);
            }
        }

        public override void PersonLeave(Person person, Architecture location)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(location.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                location.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(location, "PersonLeave", location.Position);
                person.TextDestinationString = location.BelongedFaction.Name;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonLeave");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonSearchFinished(Person person, Architecture architecture, SearchResultPack resultPack)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                if (person.shoudongsousuo)
                {
                    switch (resultPack.Result)
                    {
                        case SearchResult.资金:
                            person.TextResultString = resultPack.Number.ToString();
                            //this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFundFound");
                            this.xianshishijiantupian(person, person.TextResultString, "SearchFundFound", "", "", architecture.Name,false );
                            break;

                        case SearchResult.粮草:
                            person.TextResultString = resultPack.Number.ToString();
                            //this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFoodFound");
                            this.xianshishijiantupian(person, person.TextResultString, "SearchFoodFound", "", "", architecture.Name,false );

                            break;

                        case SearchResult.技巧:
                            person.TextResultString = resultPack.Number.ToString();
                            //this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchTechniqueFound");
                            this.xianshishijiantupian(person, person.TextResultString, "SearchTechniqueFound", "", "", architecture.Name,false );

                            break;

                        case SearchResult.间谍:
                            person.TextResultString = resultPack.FoundPerson.Name;
                            //this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchSpyFound");
                            this.xianshishijiantupian(person, person.TextResultString, "SearchSpyFound", "", "", architecture.Name,false );

                            this.Plugins.GameRecordPlugin.AddBranch(person, "SearchSpyFound", person.Position);
                            break;

                        case SearchResult.隐士:
                            person.TextResultString = resultPack.FoundPerson.Name;
                            //this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchPersonFound");
                            this.xianshishijiantupian(person, person.TextResultString, "SearchPersonFound", "", "", architecture.Name,false );

                            this.Plugins.GameRecordPlugin.AddBranch(person, "SearchPersonFound", person.Position);
                            break;
                        case SearchResult.无:
                            //person.TextResultString = architecture.Name;
                            //this.xianshishijiantupian(person, person.TextResultString, "SearchPersonFound", "", "", architecture.Name);
                            //this.Plugins.GameRecordPlugin.AddBranch(person, "SearchNoFound", person.Position);
                            break;
                    }
                    person.shoudongsousuo = false;

                }
                else
                {
                    switch (resultPack.Result)
                    {
                        case SearchResult.资金:
                            person.TextResultString = resultPack.Number.ToString();
                            this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFundFound");
                            break;

                        case SearchResult.粮草:
                            person.TextResultString = resultPack.Number.ToString();
                            this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFoodFound");

                            break;

                        case SearchResult.技巧:
                            person.TextResultString = resultPack.Number.ToString();
                            this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchTechniqueFound");

                            break;

                        case SearchResult.间谍:
                            person.TextResultString = resultPack.FoundPerson.Name;
                            this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchSpyFound");

                            this.Plugins.GameRecordPlugin.AddBranch(person, "SearchSpyFound", person.Position);
                            break;

                        case SearchResult.隐士:
                            person.TextResultString = resultPack.FoundPerson.Name;
                            this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchPersonFound");

                            this.Plugins.GameRecordPlugin.AddBranch(person, "SearchPersonFound", person.Position);
                            break;
                    }

                }// end if (person.shoudongsousuo)
            }
        }

        public override void PersonShowMessage(Person person, PersonMessage message)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) && (message is SpyMessage))
            {
                SpyMessage gameObject = message as SpyMessage;
                switch (gameObject.Kind)
                {
                    case SpyMessageKind.NewMilitary:
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewMilitary");
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.MilitaryScale:
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageMilitaryScale");
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.NewFacility:
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewFacility");
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.NewTroop:
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewTroop");
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.HireNewPerson:
                        this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageHireNewPerson");
                        this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.tupianwenziPlugin.IsShowing = true;
                        break;
                }
            }
        }

        public override void PersonSpyFailed(Person person, Architecture architecture)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonSpyFailed", person.OutsideDestination.Value);
            }
        }

        public override void PersonSpyFound(Person person, Person spy)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(spy.BelongedFaction))
            {
                spy.TextDestinationString = person.TargetArchitecture.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(spy, spy, "PersonSpyFound");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonSpySuccess(Person person, Architecture architecture)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = person.SpyDays.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonSpySuccess", person.OutsideDestination.Value);
            }
        }

        public override void PersonStudySkillFinished(Person person, string skillString, bool success)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    person.TextDestinationString = skillString;
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudySkillSuccess");
                }
                else
                {
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudySkillFailed");
                }
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonStudyStuntFinished(Person person, Stunt stunt, bool success)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = stunt.Name;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudyStuntSuccess");
                }
                else
                {
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudyStuntFailed");
                }
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonStudyTitleFinished(Person person, Title title, bool success)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = title.Name;
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudyTitleSuccess");
                }
                else
                {
                    this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonStudyTitleFailed");
                }
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

        public override void PersonTreasureFound(Person person, Treasure treasure)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = person.TargetArchitecture.Name;
                person.TextResultString = treasure.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(person, person, "PersonTreasureFound");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
                this.Plugins.GameRecordPlugin.AddBranch(person, "SearchTreasureFound", person.Position);
            }
        }

        public override void PersonCapturedByArchitecture(Person person, Architecture architecture)
        {
            if (base.Scenario.CurrentPlayer == null || base.Scenario.IsCurrentPlayer(person.BelongedFaction) 
                || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "CapturedByArchitecture", person.Position);
            }
        }

        public override void PersonJailBreak(Person person, Captive captive)
        {
            if (base.Scenario.IsCurrentPlayer(person.BelongedFaction) || base.Scenario.IsCurrentPlayer(captive.BelongedFaction))
            {
                person.TextDestinationString = captive.LocationArchitecture.Name;
                person.TextResultString = captive.CaptivePerson.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonJailBreak", person.Position);
            }
        }

        public override void PersonJailBreakFailed(Person person, Architecture target)
        {
            if (base.Scenario.IsCurrentPlayer(person.BelongedFaction) || base.Scenario.IsCurrentPlayer(target.BelongedFaction))
            {
                person.TextDestinationString = target.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonJailBreakFailed", person.Position);
            }
        }

        public override void SelfCaptiveRelease(Captive captive)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(captive.BelongedFaction)) || base.Scenario.IsCurrentPlayer(captive.CaptiveFaction)) || GlobalVariables.SkyEye)
            {
                this.Plugins.GameRecordPlugin.AddBranch(captive, "SelfCaptiveRelease", captive.BelongedFaction.Capital.Position);
            }
        }

        public override void xiejinxingjilu(string shijian, string TextResultString, string TextDestinationString,Point point)
        {
            Person p = new Person();
            p.TextResultString = TextResultString;
            p.TextDestinationString = TextDestinationString;
            this.Plugins.GameRecordPlugin.AddBranch(p, shijian, point );


        }

        public override void AskWhenTransportArrived(Troop transport, Architecture destination)
        {
            if ((base.Scenario.CurrentPlayer == null) || (base.Scenario.IsCurrentPlayer(transport.BelongedFaction) &&
                transport.BelongedFaction == transport.StartingArchitecture.BelongedFaction && !transport.StartingArchitecture.BelongedSection.AIDetail.AutoRun))
            {
                transport.transportReturningTo = destination;
                this.Plugins.tupianwenziPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(transport.TransportReturn), new GameDelegates.VoidFunction(transport.TransportEnter));
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);

                transport.TextDestinationString = destination.Name;
                transport.TextResultString = transport.StartingArchitecture.Name;
                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(transport.Leader, transport, "TransportReturn");
                this.Plugins.tupianwenziPlugin.IsShowing = true;
            }
        }

    }
}
