namespace PersonDetailPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;

    public class PersonDetailPlugin : GameObject, IPersonDetail, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\PersonDetail\Data\";
        private string description = "人物细节显示";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\PersonDetail\";
        private PersonDetail personDetail = new PersonDetail();
        private string pluginName = "PersonDetailPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "PersonDetailData.xml";

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.personDetail.IsShowing)
            {
                this.personDetail.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            XmlNode node3;
            Font font;
            Microsoft.Xna.Framework.Graphics.Color color;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.personDetail.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            Microsoft.Xna.Framework.Rectangle rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.SurNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.SurNameText.Position = rectangle;
            this.personDetail.SurNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(2);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.GivenNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.GivenNameText.Position = rectangle;
            this.personDetail.GivenNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(3);
            rectangle = StaticMethods.LoadRectangleFromXMLNode(node);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.CalledNameText = new FreeText(this.graphicsDevice, font, color);
            this.personDetail.CalledNameText.Position = rectangle;
            this.personDetail.CalledNameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.personDetail.PortraitClient = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(5);
            for (int i = 0; i < node.ChildNodes.Count; i += 2)
            {
                LabelText item = new LabelText();
                node3 = node.ChildNodes.Item(i);
                rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Label = new FreeText(this.graphicsDevice, font, color);
                item.Label.Position = rectangle;
                item.Label.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.Label.Text = node3.Attributes.GetNamedItem("Label").Value;
                node3 = node.ChildNodes.Item(i + 1);
                rectangle = StaticMethods.LoadRectangleFromXMLNode(node3);
                StaticMethods.LoadFontAndColorFromXMLNode(node3, out font, out color);
                item.Text = new FreeText(this.graphicsDevice, font, color);
                item.Text.Position = rectangle;
                item.Text.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node3.Attributes.GetNamedItem("Align").Value);
                item.PropertyName = node3.Attributes.GetNamedItem("PropertyName").Value;
                this.personDetail.LabelTexts.Add(item);
            }
            node = nextSibling.ChildNodes.Item(6);
            this.personDetail.TitleClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TitleText.ClientWidth = this.personDetail.TitleClient.Width;
            this.personDetail.TitleText.ClientHeight = this.personDetail.TitleClient.Height;
            this.personDetail.TitleText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.TitleText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.TitleText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(7);
            this.personDetail.SkillBlockSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.SkillBlockSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.SkillDisplayOffset.X = int.Parse(node.Attributes.GetNamedItem("OffsetX").Value);
            this.personDetail.SkillDisplayOffset.Y = int.Parse(node.Attributes.GetNamedItem("OffsetY").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.AllSkillTexts = new FreeTextList(this.graphicsDevice, font, color);
            this.personDetail.AllSkillTexts.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            Microsoft.Xna.Framework.Graphics.Color color2 = new Microsoft.Xna.Framework.Graphics.Color {
                PackedValue = uint.Parse(node.Attributes.GetNamedItem("SkillColor").Value)
            };
            this.personDetail.PersonSkillTexts = new FreeTextList(this.graphicsDevice, font, color2);
            this.personDetail.PersonSkillTexts.Align = this.personDetail.AllSkillTexts.Align;
            Microsoft.Xna.Framework.Graphics.Color color3 = new Microsoft.Xna.Framework.Graphics.Color {
                PackedValue = uint.Parse(node.Attributes.GetNamedItem("LearnableColor").Value)
            };
            this.personDetail.LearnableSkillTexts = new FreeTextList(this.graphicsDevice, font, color3);
            this.personDetail.LearnableSkillTexts.Align = this.personDetail.AllSkillTexts.Align;
            node = nextSibling.ChildNodes.Item(8);
            this.personDetail.StuntClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.StuntText.ClientWidth = this.personDetail.StuntClient.Width;
            this.personDetail.StuntText.ClientHeight = this.personDetail.StuntClient.Height;
            this.personDetail.StuntText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.StuntText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.StuntText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(9);
            this.personDetail.InfluenceClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.InfluenceText.ClientWidth = this.personDetail.InfluenceClient.Width;
            this.personDetail.InfluenceText.ClientHeight = this.personDetail.InfluenceClient.Height;
            this.personDetail.InfluenceText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.personDetail.InfluenceText.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.personDetail.InfluenceText.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            this.personDetail.InfluenceText.SubTitleColor2 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor2").Value);
            this.personDetail.InfluenceText.SubTitleColor3 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor3").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.InfluenceText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.InfluenceText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(10);
            this.personDetail.ConditionClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.ConditionText.ClientWidth = this.personDetail.ConditionClient.Width;
            this.personDetail.ConditionText.ClientHeight = this.personDetail.ConditionClient.Height;
            this.personDetail.ConditionText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.personDetail.ConditionText.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.personDetail.ConditionText.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            this.personDetail.ConditionText.PositiveColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("PositiveColor").Value);
            this.personDetail.ConditionText.NegativeColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("NegativeColor").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.ConditionText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.ConditionText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(11);
            this.personDetail.BiographyClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.BiographyText.ClientWidth = this.personDetail.BiographyClient.Width;
            this.personDetail.BiographyText.ClientHeight = this.personDetail.BiographyClient.Height;
            this.personDetail.BiographyText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.personDetail.BiographyText.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.personDetail.BiographyText.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            this.personDetail.BiographyText.SubTitleColor2 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor2").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.BiographyText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.BiographyText.DefaultColor = color;
            /*
            node = nextSibling.ChildNodes.Item(12);
            this.personDetail.GuanzhiClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.GuanzhiText.ClientWidth = this.personDetail.GuanzhiClient.Width;
            this.personDetail.GuanzhiText.ClientHeight = this.personDetail.GuanzhiClient.Height;
            this.personDetail.GuanzhiText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personDetail.GuanzhiText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personDetail.GuanzhiText.DefaultColor = color;
             */
            node = nextSibling.ChildNodes.Item(12);
            this.personDetail.TitleButtonClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TitleButtonClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TitleButtonClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TitleButtonClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TitleButtonClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TitleButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(13);
            this.personDetail.SkillButtonClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.SkillButtonClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.SkillButtonClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.SkillButtonClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.SkillButtonClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.SkillButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(14);
            this.personDetail.StuntButtonClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.StuntButtonClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.StuntButtonClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.StuntButtonClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.StuntButtonClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.StuntButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(15);
            this.personDetail.TreasureButtonClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TreasureButtonClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TreasureButtonClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TreasureButtonClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TreasureButtonClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TreasureButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(16);
            this.personDetail.BiographyButtonClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.BiographyButtonClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.BiographyButtonClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.BiographyButtonClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.BiographyButtonClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.BiographyButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(17);
            this.personDetail.TitleButtonPressedClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TitleButtonPressedClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TitleButtonPressedClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TitleButtonPressedClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TitleButtonPressedClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TitleButtonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(18);
            this.personDetail.SkillButtonPressedClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.SkillButtonPressedClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.SkillButtonPressedClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.SkillButtonPressedClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.SkillButtonPressedClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.SkillButtonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(19);
            this.personDetail.StuntButtonPressedClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.StuntButtonPressedClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.StuntButtonPressedClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.StuntButtonPressedClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.StuntButtonPressedClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.StuntButtonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(20);
            this.personDetail.TreasureButtonPressedClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TreasureButtonPressedClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TreasureButtonPressedClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TreasureButtonPressedClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TreasureButtonPressedClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TreasureButtonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(21);
            this.personDetail.BiographyButtonPressedClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.BiographyButtonPressedClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.BiographyButtonPressedClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.BiographyButtonPressedClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.BiographyButtonPressedClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.BiographyButtonPressedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(22);
            this.personDetail.TitleBackgroundClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TitleBackgroundClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TitleBackgroundClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TitleBackgroundClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TitleBackgroundClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TitleBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(23);
            this.personDetail.SkillBackgroundClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.SkillBackgroundClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.SkillBackgroundClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.SkillBackgroundClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.SkillBackgroundClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.SkillBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(24);
            this.personDetail.StuntBackgroundClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.StuntBackgroundClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.StuntBackgroundClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.StuntBackgroundClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.StuntBackgroundClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.StuntBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(25);
            this.personDetail.TreasureBackgroundClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.TreasureBackgroundClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.TreasureBackgroundClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.TreasureBackgroundClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.TreasureBackgroundClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.TreasureBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(26);
            this.personDetail.BiographyBackgroundClient = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personDetail.BiographyBackgroundClient.X = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.personDetail.BiographyBackgroundClient.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);
            this.personDetail.BiographyBackgroundClient.Width = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personDetail.BiographyBackgroundClient.Height = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personDetail.BiographyBackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonDetail\Data\" + node.Attributes.GetNamedItem("FileName").Value);

        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\PersonDetail\PersonDetailData.xml");
        }

        public void SetPerson(object person)
        {
            this.personDetail.SetPerson(person as Person);
        }

        public void SetPosition(ShowPosition showPosition)
        {
            this.personDetail.SetPosition(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.personDetail.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
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

        public bool IsShowing
        {
            get
            {
                return this.personDetail.IsShowing;
            }
            set
            {
                this.personDetail.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
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

