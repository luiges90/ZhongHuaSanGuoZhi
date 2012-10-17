namespace PersonTextDialogPlugin
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

    public class PersonTextDialogPlugin : GameObject, IPersonTextDialog, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\PersonTextDialog\Data\";
        private string description = "人物文本对话框";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\PersonTextDialog\";
        private PersonTextDialog personTextDialog = new PersonTextDialog();
        private string pluginName = "PersonTextDialogPlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "PersonTextDialogData.xml";

        public void Close()
        {
            this.personTextDialog.Close();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.personTextDialog.IsShowing)
            {
                this.personTextDialog.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
            this.personTextDialog.iPersonTextDialog = this;
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Microsoft.Xna.Framework.Graphics.Color color;
            Font font;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.personTextDialog.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonTextDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.personTextDialog.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personTextDialog.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.personTextDialog.PortraitClient = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            this.personTextDialog.ClientPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personTextDialog.RichText.ClientWidth = this.personTextDialog.ClientPosition.Width;
            this.personTextDialog.RichText.ClientHeight = this.personTextDialog.ClientPosition.Height;
            this.personTextDialog.RichText.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personTextDialog.RichText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personTextDialog.RichText.DefaultColor = color;
            this.personTextDialog.BuildingRichText.ClientWidth = this.personTextDialog.RichText.ClientWidth;
            this.personTextDialog.BuildingRichText.ClientHeight = this.personTextDialog.RichText.ClientHeight;
            this.personTextDialog.BuildingRichText.RowMargin = this.personTextDialog.RichText.RowMargin;
            this.personTextDialog.BuildingRichText.Builder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personTextDialog.BuildingRichText.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(3);
            this.personTextDialog.FirstPageButtonTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonTextDialog\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.personTextDialog.FirstPageButtonSelectedTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonTextDialog\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.personTextDialog.FirstPageButtonDisabledTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonTextDialog\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            this.personTextDialog.FirstPageButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(4);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personTextDialog.NameText = new FreeText(this.graphicsDevice, font, color);
            this.personTextDialog.NameText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personTextDialog.NameText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            /*node = nextSibling.ChildNodes.Item(5);
            this.personTextDialog.ShowingSeconds = int.Parse(node.Attributes.GetNamedItem("Time").Value);*/
            //this.personTextDialog.ShowingSeconds = GlobalVariables.DialogShowTime;
            this.personTextDialog.TextTree.LoadFromXmlFile(@"GameComponents\PersonTextDialog\Data\PersonTextTree.xml");
        }

        public void SetCloseFunction(GameDelegates.VoidFunction closeFunction)
        {
            this.personTextDialog.CloseFunction += closeFunction;
        }

        public void SetConfirmationDialog(IConfirmationDialog iConfirmationDialog, GameDelegates.VoidFunction yesFunction, GameDelegates.VoidFunction noFunction)
        {
            this.personTextDialog.iConfirmationDialog = iConfirmationDialog;
            this.personTextDialog.YesFunction = yesFunction;
            this.personTextDialog.NoFunction = noFunction;
            this.personTextDialog.HasConfirmationDialog = true;
        }

        public void SetContextMenu(IGameContextMenu iContextMenu)
        {
            this.personTextDialog.iContextMenu = iContextMenu;
        }

        public void SetGameObjectBranch(object person, object gameObject, string branchName)
        {
            this.personTextDialog.SetGameObjectBranch(person as Person, gameObject as GameObject, branchName);
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\PersonTextDialog\PersonTextDialogData.xml");
        }

        public void SetPosition(ShowPosition showPosition)
        {
            this.personTextDialog.SetPosition(showPosition);
        }

        public void SetScreen(object screen)
        {
            this.personTextDialog.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
            if (this.personTextDialog.IsShowing)
            {
                this.personTextDialog.Update();
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

        public bool IsShowing
        {
            get
            {
                return this.personTextDialog.IsShowing;
            }
            set
            {
                this.personTextDialog.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public FreeRichText RichText
        {
            get
            {
                return this.personTextDialog.RichText;
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

