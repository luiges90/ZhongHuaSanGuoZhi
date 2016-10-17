using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using		GameGlobal;


using System.Windows.Forms;
using WorldOfTheThreeKingdoms.GameForms;



namespace WorldOfTheThreeKingdoms.GameProcesses
{
    internal class MainProcessManager
    {
        private Parameters gameParameters = new Parameters();
        private GlobalVariables globalVariables = new GlobalVariables();
        public static MainGame mainGame = new MainGame();

        public void Processing()
        {
            formMainMenu menu = new formMainMenu
            {
                mainGame = MainProcessManager.mainGame
            };
            mainGame.Player.currentPlaylist.clear();
            WMPLib.IWMPMedia media;
            string[] filePaths = Directory.GetFiles("GameMusic/Start/", "*.mp3");
            Random rd = new Random();
            int index = rd.Next(0, filePaths.Length);
            string path = filePaths[index];

            foreach (String s in filePaths)
            {
                media = mainGame.Player.newMedia(s);
                mainGame.Player.currentPlaylist.appendItem(media);
            }
            media = mainGame.Player.newMedia(path);
            mainGame.Player.currentPlaylist.appendItem(media);
            mainGame.Player.currentItem = media;
            mainGame.Player.play();
            mainGame.Player.settings.setMode("loop", true);

            if (menu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.globalVariables.InitialGlobalVariables();
                this.gameParameters.InitializeGameParameters();
                
                mainGame.jiazaitishi.Show();
                mainGame.jiazaitishi.Refresh();
                mainGame.Run();
            }
        }
        
        public void SaveGameWhenCrash(String _savePath)
        {
            mainGame.SaveGameWhenCrash(_savePath);
        }
    }
}
