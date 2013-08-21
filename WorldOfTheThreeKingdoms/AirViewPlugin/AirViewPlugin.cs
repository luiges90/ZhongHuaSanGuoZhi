﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using AirViewPlugin;
using GameFreeText;
using GameGlobal;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;

//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
//using Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework.Storage;
using PluginInterface;
using PluginInterface.BaseInterface;



namespace AirViewPlugin
{
    public class AirViewPlugin : GameObject, IAirView, IBasePlugin, IPluginXML, IPluginGraphics, IScreenDisableRects
    {
        private AirView airView = new AirView();
        private Image architectureImage;
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\AirView\Data\";
        private string description = "微缩地图";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\AirView\";
        private string pluginName = "AirViewPlugin";
        private List<Image> TerrainImages = new List<Image>();
        private Image troopFriendlyImage;
        private Image troopHostileImage;
        private Image troopImage;
        private string version = "1.0.0";
        private const string XMLFilename = "AirViewData.xml";

        public void AddDisableRects()
        {
            this.airView.AddDisableRects();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.airView.Draw(spriteBatch,gameTime);
        }

        public void Initialize()
        {
            for (int i = 0; i < Enum.GetValues(typeof(TerrainKind)).Length; i++)
            {
                string filename = "Resources/Terrain/" + i.ToString() + "/Basic01.bmp";
                this.TerrainImages.Add(Image.FromFile(filename));
            }
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.airView.Align = (ToolAlign)Enum.Parse(typeof(ToolAlign), node.Attributes.GetNamedItem("Align").Value);
            this.airView.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.airView.ToolTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.airView.ToolSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.airView.ToolDisplayTexture = this.airView.ToolTexture;
            this.airView.ToolPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            this.airView.Transparent = float.Parse(node.Attributes.GetNamedItem("Transparent").Value);
            this.airView.MapShowPosition = (ShowPosition)Enum.Parse(typeof(ShowPosition), node.Attributes.GetNamedItem("Position").Value);
            this.airView.MapMaxWidth = int.Parse(node.Attributes.GetNamedItem("MaxWidth").Value);
            this.airView.MapMaxHeight = int.Parse(node.Attributes.GetNamedItem("MaxHeight").Value);
            this.airView.DefaultTileLength = int.Parse(node.Attributes.GetNamedItem("TileLength").Value);
            this.airView.TileLength = this.airView.DefaultTileLength;
            this.airView.TileLengthMax = int.Parse(node.Attributes.GetNamedItem("TileLengthMax").Value);
            node = nextSibling.ChildNodes.Item(3);
            this.airView.FrameTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.airView.ArchitectureUnitTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.troopImage = Image.FromFile(@"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.troopFriendlyImage = Image.FromFile(@"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("Friendly").Value);
            this.troopHostileImage = Image.FromFile(@"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("Hostile").Value);
            this.airView.TroopFactionColorTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(6);
            this.airView.ConmentBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.airView.Conment = new FreeText(this.graphicsDevice, font, color);
            this.airView.Conment.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.airView.Conment.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

            node = nextSibling.ChildNodes.Item(7);
            this.airView.TroopToolTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.airView.TroopToolSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.airView.TroopToolDisplayTexture = this.airView.TroopToolSelectedTexture;
            this.airView.TroopToolPosition = StaticMethods.LoadRectangleFromXMLNode(node);
        }
        
        public void ReloadAirView()
        {
            if (this.airView.MapTexture != null)
            {
                this.airView.MapTexture.Dispose();
                this.airView.MapTexture = null;
            }
            Bitmap image = new Bitmap(this.airView.scenario.ScenarioMap.MapDimensions.X * this.airView.TileLength, this.airView.scenario.ScenarioMap.MapDimensions.Y * this.airView.TileLength, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(System.Drawing.Color.White);
            for (int i = 0; i < this.airView.scenario.ScenarioMap.MapDimensions.X; i++)
            {
                for (int j = 0; j < this.airView.scenario.ScenarioMap.MapDimensions.Y; j++)
                {
                    graphics.DrawImage(this.TerrainImages[this.airView.scenario.ScenarioMap.MapData[i, j]], new System.Drawing.Rectangle(i * this.airView.TileLength, j * this.airView.TileLength, this.airView.TileLength, this.airView.TileLength));
                }
            }
            try
            {
                image.Save(@"GameComponents\AirView\~tmp.image");
                this.airView.MapTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\~tmp.image");
                File.Delete(@"GameComponents\AirView\~tmp.image");
            }
            catch
            {
                this.airView.MapTexture = null;
            }
            //this.ReloadTroopView();
        }
        
        
        
        public void ReloadAirView(string dituwenjian)
        {
            if (this.airView.MapTexture != null)
            {
                this.airView.MapTexture.Dispose();
                this.airView.MapTexture = null;
            }

            try
            {
                
                this.airView.MapTexture = Texture2D.FromFile(this.graphicsDevice, @"Resources\ditu\_" + dituwenjian);
                
            }
            catch
            {
                this.airView.MapTexture = null;
            }
            //this.ReloadTroopView();
        }
        

        public void ReloadArchitectureView()  //以前的代码，现在已不用
        {
            if (this.airView.ArchitectureTexture != null)
            {
                this.airView.ArchitectureTexture.Dispose();
                this.airView.ArchitectureTexture = null;
            }
            Bitmap image = new Bitmap(this.airView.scenario.ScenarioMap.MapDimensions.X * this.airView.TileLength, this.airView.scenario.ScenarioMap.MapDimensions.Y * this.airView.TileLength, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.Clear(System.Drawing.Color.Transparent);
            for (int i = 0; i < this.airView.scenario.ScenarioMap.MapDimensions.X; i++)
            {
                for (int j = 0; j < this.airView.scenario.ScenarioMap.MapDimensions.Y; j++)
                {
                    if (this.airView.scenario.PositionIsArchitecture(new Microsoft.Xna.Framework.Point(i, j)))
                    {
                        graphics.DrawImage(this.architectureImage, new System.Drawing.Rectangle(i * this.airView.TileLength, j * this.airView.TileLength, this.airView.TileLength * 4, this.airView.TileLength * 4));
                    }
                }
            }
            try
            {
                image.Save(@"GameComponents\AirView\~tmp.image");
                this.airView.ArchitectureTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\~tmp.image");
                File.Delete(@"GameComponents\AirView\~tmp.image");
            }
            catch
            {
                this.airView.ArchitectureTexture = null;
            }
        }

        public void ReloadTroopView() //以前的代码，现在已不用
        {
            if (!this.airView.scenario.NoCurrentPlayer)
            {
                if (this.airView.TroopTexture != null)
                {
                    this.airView.TroopTexture.Dispose();
                    this.airView.TroopTexture = null;
                }
                Bitmap image = new Bitmap(this.airView.scenario.ScenarioMap.MapDimensions.X * this.airView.TileLength, this.airView.scenario.ScenarioMap.MapDimensions.Y * this.airView.TileLength, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(image);
                graphics.Clear(System.Drawing.Color.Transparent);
                for (int i = 0; i < this.airView.scenario.ScenarioMap.MapDimensions.X; i++)
                {
                    for (int j = 0; j < this.airView.scenario.ScenarioMap.MapDimensions.Y; j++)
                    {
                        if (this.airView.scenario.CurrentPlayer.IsPositionKnown(new Microsoft.Xna.Framework.Point(i, j)))
                        {
                            Troop troopByPositionNoCheck = this.airView.scenario.GetTroopByPositionNoCheck(new Microsoft.Xna.Framework.Point(i, j));
                            if ((troopByPositionNoCheck != null) && !troopByPositionNoCheck.Destroyed)
                            {
                                if (troopByPositionNoCheck.BelongedFaction == this.airView.scenario.CurrentPlayer)
                                {
                                    graphics.DrawImage(this.troopImage, new System.Drawing.Rectangle(i * this.airView.TileLength, j * this.airView.TileLength, this.airView.TileLength, this.airView.TileLength));
                                }
                                else if (troopByPositionNoCheck.IsFriendly(this.airView.scenario.CurrentPlayer))
                                {
                                    graphics.DrawImage(this.troopFriendlyImage, new System.Drawing.Rectangle(i * this.airView.TileLength, j * this.airView.TileLength, this.airView.TileLength, this.airView.TileLength));
                                }
                                else
                                {
                                    graphics.DrawImage(this.troopHostileImage, new System.Drawing.Rectangle(i * this.airView.TileLength, j * this.airView.TileLength, this.airView.TileLength, this.airView.TileLength));
                                }
                            }
                        }
                    }
                }
                try
                {
                    image.Save(@"GameComponents\AirView\~tmp.image");
                    this.airView.TroopTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\AirView\~tmp.image");
                    File.Delete(@"GameComponents\AirView\~tmp.image");
                }
                catch
                {
                    this.airView.TroopTexture = null;
                }
            }
        }

        public void RemoveDisableRects()
        {
            this.airView.RemoveDisableRects();
        }

        public void ResetFramePosition(Microsoft.Xna.Framework.Point viewportSize, int leftEdge, int topEdge, Microsoft.Xna.Framework.Point totalMapSize)
        {
            this.airView.ResetFramePosition(viewportSize, leftEdge, topEdge, totalMapSize);
        }

        public void ResetFrameSize(Microsoft.Xna.Framework.Point viewportSize, Microsoft.Xna.Framework.Point totalMapSize)
        {
            this.airView.ResetFrameSize(viewportSize, totalMapSize);
        }

        public void ResetMapPosition()
        {
            this.airView.SetDisplayOffset(this.airView.MapShowPosition);
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\AirView\AirViewData.xml");
        }

        public void SetMapPosition(ShowPosition showPosition)
        {
            this.airView.SetDisplayOffset(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.airView.Name = this.pluginName;
            this.airView.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        { 
            this.airView.Update();
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsMapShowing
        {
            get
            {
                return this.airView.IsMapShowing;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public object ToolInstance
        {
            get
            {
                return this.airView;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }

 

}
