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
//using GameObjects.PersonDetail.PersonMessages;
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
        private bool AfterDayPassed(GameTime gameTime)
        {
            return this.RunTheFactions(gameTime);
        }

        private bool AfterDayStarting(GameTime gameTime)
        {

            return this.MoveTheTroops(gameTime);
        }


        private bool Date_OnDayPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.DayPassedEvent();
                //base.Scenario.CheckRepeatedPerson();
                //this.Plugins.AirViewPlugin.ReloadTroopView();

                this.gengxinyoucelan();
                //this.DrawAutoSavePicture();

                /*
                if (base.Scenario.Date.Day == 29 && GlobalVariables.doAutoSave)
                {
                    this.SaveGameAutoPosition();
                    shangciCundangShijian = DateTime.Now;
                }
                */



                cundangShijianJiange = DateTime.Now - shangciCundangShijian;

                if (cundangShijianJiange.Minutes >= GlobalVariables.AutoSaveFrequency)
                {
                    if (GlobalVariables.doAutoSave)
                    {
                        this.Scenario.Date.Go(1);
                        this.SaveGameAutoPosition();
                        this.Scenario.Date.Go(-1);
                    }
                    shangciCundangShijian = DateTime.Now;
                }

                return true;
            }
            return false;
        }

        private bool Date_OnDayStarting()
        {

            if (!base.Scenario.Threading)
            {
                base.Scenario.DayStartingEvent();

                return true;
            }
            return false;
        }

        private bool Date_OnMonthPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.MonthPassedEvent();
                return true;
            }
            return false;
        }

        public override void SwichMusic(GameSeason season)
        {
            if (this.Scenario.CurrentPlayer!=null && this.Scenario.CurrentPlayer.BattleState!=ZhandouZhuangtai.和平)
            {
                if (this.Scenario.CurrentPlayer.BattleState == ZhandouZhuangtai.进攻)
                {
                    Player.currentPlaylist.clear();
                    WMPLib.IWMPMedia media5;
                    string[] filePaths5 = Directory.GetFiles("GameMusic/Attack/", "*.mp3");
                    int index5 = GameObject.Random(filePaths5.Length);
                    string path5 = filePaths5[index5];
                    foreach (String s in filePaths5)
                    {
                        media5 = Player.newMedia(s);
                        Player.currentPlaylist.appendItem(media5);
                    }
                    media5 = Player.newMedia(path5);
                    Player.currentPlaylist.appendItem(media5);
                    Player.currentItem = media5;
                    Player.play();
                    Player.settings.setMode("loop", true);
                    //this.PlayMusic("GameMusic/Attack.mp3");
                }
                else if (this.Scenario.CurrentPlayer.BattleState == ZhandouZhuangtai.防守)
                {
                    Player.currentPlaylist.clear();
                    WMPLib.IWMPMedia media6;
                    string[] filePaths6 = Directory.GetFiles("GameMusic/Defend/", "*.mp3");
                    int index6 = GameObject.Random(filePaths6.Length);
                    string path6 = filePaths6[index6];
                    foreach (String s in filePaths6)
                    {
                        media6 = Player.newMedia(s);
                        Player.currentPlaylist.appendItem(media6);
                    }
                    media6 = Player.newMedia(path6);
                    Player.currentPlaylist.appendItem(media6);
                    Player.currentItem = media6;
                    Player.play();
                    Player.settings.setMode("loop", true);
                    // this.PlayMusic("GameMusic/Defend.mp3");
                }
                else
                {
                    Player.currentPlaylist.clear();
                    WMPLib.IWMPMedia media7;
                    string[] filePaths7 = Directory.GetFiles("GameMusic/Battle/", "*.mp3");
                    int index7 = GameObject.Random(filePaths7.Length);
                    string path7 = filePaths7[index7];
                    foreach (String s in filePaths7)
                    {
                        media7 = Player.newMedia(s);
                        Player.currentPlaylist.appendItem(media7);
                    }
                    media7 = Player.newMedia(path7);
                    Player.currentPlaylist.appendItem(media7);
                    Player.currentItem = media7;
                    Player.play();
                    Player.settings.setMode("loop", true);
                    //this.PlayMusic("GameMusic/Battle.mp3");
                }
            }
            else
            {
                switch (season)
                {
                    case GameSeason.春:
                        Player.currentPlaylist.clear();
                        WMPLib.IWMPMedia media;
                        string[] filePaths = Directory.GetFiles("GameMusic/Spring/", "*.mp3");
                        int index = GameObject.Random(filePaths.Length);
                        string path = filePaths[index];
                        foreach (String s in filePaths)
                        {
                            media = Player.newMedia(s);
                            Player.currentPlaylist.appendItem(media);
                        }
                        media = Player.newMedia(path);
                        Player.currentPlaylist.appendItem(media);
                        Player.currentItem = media;
                        Player.play();
                        Player.settings.setMode("loop", true);
                        //this.PlayMusic("GameMusic/Spring.mp3");
                        break;
                    case GameSeason.夏:
                        Player.currentPlaylist.clear();
                        WMPLib.IWMPMedia media2;
                        string[] filePaths2 = Directory.GetFiles("GameMusic/Summer/", "*.mp3");
                        int index2 = GameObject.Random(filePaths2.Length);
                        string path2 = filePaths2[index2];
                        foreach (String s in filePaths2)
                        {
                            media2 = Player.newMedia(s);
                            Player.currentPlaylist.appendItem(media2);
                        }
                        media2 = Player.newMedia(path2);
                        Player.currentPlaylist.appendItem(media2);
                        Player.currentItem = media2;
                        Player.play();
                        Player.settings.setMode("loop", true);
                        // this.PlayMusic("GameMusic/Summer.mp3");
                        break;

                    case GameSeason.秋:

                        Player.currentPlaylist.clear();
                        WMPLib.IWMPMedia media3;
                        string[] filePaths3 = Directory.GetFiles("GameMusic/Autumn/", "*.mp3");
                        int index3 = GameObject.Random(filePaths3.Length);
                        string path3 = filePaths3[index3];
                        foreach (String s in filePaths3)
                        {
                            media3 = Player.newMedia(s);
                            Player.currentPlaylist.appendItem(media3);
                        }
                        media3 = Player.newMedia(path3);
                        Player.currentPlaylist.appendItem(media3);
                        Player.currentItem = media3;
                        Player.play();
                        Player.settings.setMode("loop", true);
                        //this.PlayMusic("GameMusic/Autumn.mp3");
                        break;

                    case GameSeason.冬:

                        Player.currentPlaylist.clear();
                        WMPLib.IWMPMedia media4;
                        string[] filePaths4 = Directory.GetFiles("GameMusic/Winter/", "*.mp3");
                        int index4 = GameObject.Random(filePaths4.Length);
                        string path4 = filePaths4[index4];
                        foreach (String s in filePaths4)
                        {
                            media4 = Player.newMedia(s);
                            Player.currentPlaylist.appendItem(media4);
                        }
                        media4 = Player.newMedia(path4);
                        Player.currentPlaylist.appendItem(media4);
                        Player.currentItem = media4;
                        Player.play();
                        Player.settings.setMode("loop", true);
                        //this.PlayMusic("GameMusic/Winter.mp3");
                        break;
                }
            }
        }

        private void Date_OnSeasonChange(GameSeason season)
        {
            if (this.Scenario.CurrentPlayer == null || this.Scenario.CurrentPlayer.BattleState==ZhandouZhuangtai.和平)
            {
                this.SwichMusic(season);
            }
            if (!base.Scenario.Threading&&base.Scenario.Date.Day==1)
            {
                base.Scenario.SeasonChangeEvent();
                
            }
        }

        private bool Date_OnYearPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.YearPassedEvent();
                return true;
            }
            return false;
        }

        private bool Date_OnYearStarting()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.YearStartingEvent();
                return true;
            }
            return false;
        }

        public  void DateGo(int Days)
        {
            if (base.Scenario.CurrentPlayer != null)
            {
                base.Scenario.CurrentPlayer.Passed = true;
                if (base.Scenario.IsLastPlayer(base.Scenario.CurrentPlayer))
                {
                    this.Plugins.DateRunnerPlugin.RunDays(Days);
                }
            } else 
            if (base.Scenario.PlayerFactions.Count == 0)
            {
                this.Plugins.DateRunnerPlugin.RunDays(Days);
            }
        }

    }
}
