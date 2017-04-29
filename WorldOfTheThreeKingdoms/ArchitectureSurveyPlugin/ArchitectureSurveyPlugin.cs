using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using GameGlobal;
using GameFreeText;
using GameObjects;
using PluginInterface;
using PluginInterface.BaseInterface;


namespace ArchitectureSurveyPlugin
{
    public class ArchitectureSurveyPlugin : GameObject, IArchitectureSurvey, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private ArchitectureSurvey architectureSurvey = new ArchitectureSurvey();
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\ArchitectureSurvey\Data\";
        private string description = "用来显示建筑概况窗口的各个属性";
        private bool enableUpdate;
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\ArchitectureSurvey\";
        private string pluginName = "ArchitectureSurveyPlugin";
        private bool showing;
        private string version = "1.0.1";
        private const string XMLFilename = "ArchitectureSurveyData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Showing)
            {
                this.architectureSurvey.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            System.Drawing.Font font;
            Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.architectureSurvey.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.BackgroundSize = new Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(1);
            this.architectureSurvey.FactionTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.FactionPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.NameText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.NameText.Position = rectangle;
            this.architectureSurvey.NameText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(3);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.KindText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.KindText.Position = rectangle;
            this.architectureSurvey.KindText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(4);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FactionText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FactionText.Position = rectangle;
            this.architectureSurvey.FactionText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(5);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.PopulationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.PopulationText.Position = rectangle;
            this.architectureSurvey.PopulationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(6);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.ArmyText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.ArmyText.Position = rectangle;
            this.architectureSurvey.ArmyText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(7);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.DominationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.DominationText.Position = rectangle;
            this.architectureSurvey.DominationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(8);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.EnduranceText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.EnduranceText.Position = rectangle;
            this.architectureSurvey.EnduranceText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.architectureSurvey.ControllingBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.architectureSurvey.ControllingBackgroundSize = new Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(10);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FundText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FundText.Position = rectangle;
            this.architectureSurvey.FundText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(11);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FoodText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FoodText.Position = rectangle;
            this.architectureSurvey.FoodText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(12);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.PersonCountText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.PersonCountText.Position = rectangle;
            this.architectureSurvey.PersonCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(13);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.NoFactionPersonCountText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.NoFactionPersonCountText.Position = rectangle;
            this.architectureSurvey.NoFactionPersonCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(14);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.AgricultureText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.AgricultureText.Position = rectangle;
            this.architectureSurvey.AgricultureText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(15);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.CommerceText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.CommerceText.Position = rectangle;
            this.architectureSurvey.CommerceText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(0x10);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.TechnologyText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.TechnologyText.Position = rectangle;
            this.architectureSurvey.TechnologyText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(0x11);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.MoraleText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.MoraleText.Position = rectangle;
            this.architectureSurvey.MoraleText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

            node = nextSibling.ChildNodes.Item(18);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.MilitaryPopulationText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.MilitaryPopulationText.Position = rectangle;
            this.architectureSurvey.MilitaryPopulationText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(19);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.FacilityCountText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.FacilityCountText.Position = rectangle;
            this.architectureSurvey.FacilityCountText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

            node = nextSibling.ChildNodes.Item(20);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.BuildingDaysLeftText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.BuildingDaysLeftText.Position = rectangle;
            this.architectureSurvey.BuildingDaysLeftText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(21);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.architectureSurvey.MayorNameText = new FreeText(this.graphicsDevice, font, color);
            this.architectureSurvey.MayorNameText.Position = rectangle;
            this.architectureSurvey.MayorNameText.Align = (TextAlign)Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);

            //以下新功能相关设定
            //↓功能开关
            node = nextSibling.ChildNodes.Item(22);
            this.architectureSurvey.Switch1 = node.Attributes.GetNamedItem("ArchitectureKinds").Value;
            this.architectureSurvey.Switch2 = node.Attributes.GetNamedItem("Bars").Value;            
            node = nextSibling.ChildNodes.Item(23);
            this.architectureSurvey.NewControllingMaskTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\" + node.Attributes.GetNamedItem("Mask").Value);
            this.architectureSurvey.NewControllingBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\" + node.Attributes.GetNamedItem("Background").Value);
            //↓建筑种类
            node = nextSibling.ChildNodes.Item(24);
            this.architectureSurvey.AKBackground0Client = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.AKBackground0Client.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.AKBackground0Client.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.AKBackground0Client.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.AKBackground0Client.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.AKindfor1 = node.Attributes.GetNamedItem("Name1").Value;
            this.architectureSurvey.AKindfor2 = node.Attributes.GetNamedItem("Name2").Value;
            this.architectureSurvey.AKindfor3 = node.Attributes.GetNamedItem("Name3").Value;
            this.architectureSurvey.AKindfor4 = node.Attributes.GetNamedItem("Name4").Value;
            this.architectureSurvey.AKindfor5 = node.Attributes.GetNamedItem("Name5").Value;
            this.architectureSurvey.AKindfor6 = node.Attributes.GetNamedItem("Name6").Value;
            this.architectureSurvey.AKindfor7 = node.Attributes.GetNamedItem("Name7").Value;
            this.architectureSurvey.AKindfor8 = node.Attributes.GetNamedItem("Name8").Value;
            this.architectureSurvey.AKindfor9 = node.Attributes.GetNamedItem("Name9").Value;
            this.architectureSurvey.AKindfor10 = node.Attributes.GetNamedItem("Name10").Value;
            this.architectureSurvey.AKindfor11 = node.Attributes.GetNamedItem("Name11").Value;
            this.architectureSurvey.AKindfor12 = node.Attributes.GetNamedItem("Name12").Value;
            this.architectureSurvey.AKindfor13 = node.Attributes.GetNamedItem("Name13").Value;
            this.architectureSurvey.AKindfor14 = node.Attributes.GetNamedItem("Name14").Value;
            this.architectureSurvey.AKindfor15 = node.Attributes.GetNamedItem("Name15").Value;
            this.architectureSurvey.AKindfor16 = node.Attributes.GetNamedItem("Name16").Value;
            this.architectureSurvey.AKindfor17 = node.Attributes.GetNamedItem("Name17").Value;
            this.architectureSurvey.AKindfor18 = node.Attributes.GetNamedItem("Name18").Value;
            this.architectureSurvey.AKindfor19 = node.Attributes.GetNamedItem("Name19").Value;
            this.architectureSurvey.AKindfor20 = node.Attributes.GetNamedItem("Name20").Value;
            this.architectureSurvey.AKindfor21 = node.Attributes.GetNamedItem("Name21").Value;
            this.architectureSurvey.AKindfor22 = node.Attributes.GetNamedItem("Name22").Value;
            this.architectureSurvey.AKindfor23 = node.Attributes.GetNamedItem("Name23").Value;
            this.architectureSurvey.AKindfor24 = node.Attributes.GetNamedItem("Name24").Value;
            this.architectureSurvey.AKindfor25 = node.Attributes.GetNamedItem("Name25").Value;
            this.architectureSurvey.AKindfor26 = node.Attributes.GetNamedItem("Name26").Value;
            this.architectureSurvey.AKindfor27 = node.Attributes.GetNamedItem("Name27").Value;
            this.architectureSurvey.AKindfor28 = node.Attributes.GetNamedItem("Name28").Value;
            this.architectureSurvey.AKBackground0Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.AKBackground1Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.AKBackground2Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.AKBackground3Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.AKBackground4Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.AKBackground5Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName5").Value);
            this.architectureSurvey.AKBackground6Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName6").Value);
            this.architectureSurvey.AKBackground7Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName7").Value);
            this.architectureSurvey.AKBackground8Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName8").Value);
            this.architectureSurvey.AKBackground9Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName9").Value);
            this.architectureSurvey.AKBackground10Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName10").Value);
            this.architectureSurvey.AKBackground11Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName11").Value);
            this.architectureSurvey.AKBackground12Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName12").Value);
            this.architectureSurvey.AKBackground13Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName13").Value);
            this.architectureSurvey.AKBackground14Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName14").Value);
            this.architectureSurvey.AKBackground15Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName15").Value);
            this.architectureSurvey.AKBackground16Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName16").Value);
            this.architectureSurvey.AKBackground17Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName17").Value);
            this.architectureSurvey.AKBackground18Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName18").Value);
            this.architectureSurvey.AKBackground19Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName19").Value);
            this.architectureSurvey.AKBackground20Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName20").Value);
            this.architectureSurvey.AKBackground21Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName21").Value);
            this.architectureSurvey.AKBackground22Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName22").Value);
            this.architectureSurvey.AKBackground23Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName23").Value);
            this.architectureSurvey.AKBackground24Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName24").Value);
            this.architectureSurvey.AKBackground25Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName25").Value);
            this.architectureSurvey.AKBackground26Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName26").Value);
            this.architectureSurvey.AKBackground27Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName27").Value);
            this.architectureSurvey.AKBackground28Texture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\ArchitectureKind\" + node.Attributes.GetNamedItem("FileName28").Value);
            //↓进度条           
            node = nextSibling.ChildNodes.Item(25);
            this.architectureSurvey.DominationBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.DominationBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.DominationBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.DominationBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.DominationBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Domination1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Domination2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Domination3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Domination4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Domination5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Domination6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(26);
            this.architectureSurvey.EnduranceBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.EnduranceBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.EnduranceBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.EnduranceBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.EnduranceBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Endurance1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Endurance2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Endurance3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Endurance4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Endurance5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Endurance6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(27);
            this.architectureSurvey.AgricultureBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.AgricultureBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.AgricultureBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.AgricultureBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.AgricultureBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Agriculture1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Agriculture2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Agriculture3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Agriculture4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Agriculture5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Agriculture6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(28);
            this.architectureSurvey.CommerceBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.CommerceBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.CommerceBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.CommerceBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.CommerceBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Commerce1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Commerce2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Commerce3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Commerce4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Commerce5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Commerce6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(29);
            this.architectureSurvey.TechnologyBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.TechnologyBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.TechnologyBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.TechnologyBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.TechnologyBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Technology1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Technology2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Technology3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Technology4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Technology5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Technology6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(30);
            this.architectureSurvey.MoraleBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.MoraleBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.MoraleBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.MoraleBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.MoraleBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.Morale1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.Morale2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.Morale3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.Morale4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.Morale5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.Morale6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);
            node = nextSibling.ChildNodes.Item(31);
            this.architectureSurvey.FacilityCountBarClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.architectureSurvey.FacilityCountBarClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.architectureSurvey.FacilityCountBarClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.architectureSurvey.FacilityCountBarClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.architectureSurvey.FacilityCountBarClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.architectureSurvey.FacilityCount1BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName0").Value);
            this.architectureSurvey.FacilityCount2BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName1").Value);
            this.architectureSurvey.FacilityCount3BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName2").Value);
            this.architectureSurvey.FacilityCount4BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName3").Value);
            this.architectureSurvey.FacilityCount5BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName4").Value);
            this.architectureSurvey.FacilityCount6BarTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\ArchitectureSurvey\Data\Backgrounds\Bar\" + node.Attributes.GetNamedItem("FileName5").Value);



        }

        public void SetArchitecture(object architecture, Point position)
        {
            this.enableUpdate = this.architectureSurvey.ArchitectureToSurvey != architecture;
            this.architectureSurvey.ArchitectureToSurvey = architecture as Architecture;
            this.architectureSurvey.CurrentPosition = position;
        }

        public void SetFaction(object faction)
        {
            this.architectureSurvey.ViewingFaction = faction as Faction;
            if (this.architectureSurvey.ViewingFaction != null)
            {
                InformationLevel knownAreaData = this.architectureSurvey.ViewingFaction.GetKnownAreaData(this.architectureSurvey.CurrentPosition);
                this.enableUpdate = this.enableUpdate || (this.architectureSurvey.Level != knownAreaData);
                this.architectureSurvey.Level = knownAreaData;
            }
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\ArchitectureSurvey\ArchitectureSurveyData.xml");
        }

        public void SetTopLeftPoint(int Left, int Top)
        {
            this.architectureSurvey.Left = Left;
            this.architectureSurvey.Top = Top;
        }

        public void Update(GameTime gameTime)
        {
            if (this.Showing && this.enableUpdate)
            {
                this.architectureSurvey.Update();
            }
        }

        public void Gengxin()
        {
            if (this.Showing)
            {
                this.architectureSurvey.Update();
            }
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

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public bool Showing
        {
            get
            {
                return ((this.architectureSurvey.ArchitectureToSurvey != null) && this.showing);
            }
            set
            {
                this.showing = value;
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
