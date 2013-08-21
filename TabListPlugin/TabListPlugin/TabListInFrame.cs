﻿namespace TabListPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Xml;

    internal class TabListInFrame : FrameContent
    {
        internal string checkboxDisplayName;
        internal string checkboxName;
        internal Texture2D checkboxSelectedTexture;
        internal Texture2D checkboxTexture;
        internal int checkboxWidth;
        internal int columnheaderHeight;
        internal Texture2D columnheaderTexture;
        internal int columnspliterHeight;
        internal Texture2D columnspliterTexture;
        internal int columnspliterWidth;
        internal TextAlign ColumnTextAlign;
        internal FreeTextBuilder ColumnTextBuilder = new FreeTextBuilder();
        internal Color ColumnTextColor;
        internal bool DrawFocused = false;
        private bool firstTimeMapViewSelector = true;
        internal int Focused;
        internal GameObject FocusedObject;
        internal Texture2D focusTrackTexture;
        internal Rectangle FullLowerClient;
        internal GameObjectList gameObjectList;
        internal GraphicsDevice graphicsDevice;
        private bool HeightCanShrink = true;
        internal IArchitectureDetail iArchitectureDetail;
        internal IFactionTechniques iFactionTechniques;
        internal IGameFrame iGameFrame;
        internal IMapViewSelector iMapViewSelector;
        internal IPersonDetail iPersonDetail;
        internal ITreasureDetail iTreasureDetail;
        internal ITroopDetail iTroopDetail;
        internal Texture2D leftArrowTexture;
        internal List<ListKind> ListKinds;
        private ListKind listKindToDisplay;
        internal bool MovingHorizontalScrollBar = false;
        internal bool MovingVerticalScrollBar = false;
        internal bool MultiSelecting = false;
        private Point oldMousePosition;
        internal int oldScrollValue;
        internal int PortraitHeight;
        internal int PortraitWidth;
        internal Texture2D rightArrowTexture;
        private bool RightClickClose = true;
        internal SubKind RootListKind;
        internal Texture2D roundcheckboxSelectedTexture;
        internal Texture2D roundcheckboxTexture;
        internal int rowHeight;
        internal List<Rectangle> RowRectangles;
        private Screen screen;
        internal Texture2D scrollbuttonTexture;
        internal int scrollbuttonWidth;
        internal Texture2D scrolltrackTexture;
        internal int scrolltrackWidth;
        internal GameObject SelectedItem;
        internal GameObjectList SelectedItemList;
        internal int SelectedItemMaxCount;
        internal bool SelectingBool = false;
        internal bool SelectingRows = false;
        internal string SelectSoundFile;
        internal bool ShowCheckBox = false;
        internal bool ShowHorizontalScrollBar = false;
        internal bool ShowVerticalScrollBar = false;
        private Stack<SubKind> SubKinds = new Stack<SubKind>();
        internal int tabbuttonHeight;
        internal Texture2D tabbuttonselectedTexture;
        internal Texture2D tabbuttonTexture;
        internal int tabbuttonWidth;
        internal TextAlign TabTextAlign;
        internal FreeTextBuilder TabTextBuilder = new FreeTextBuilder();
        internal Color TabTextColor;
        internal string Title = "";
        internal Rectangle VisibleLowerClient;
        private bool WidthCanShrink = true;

        public void AddRows()
        {
            if (this.gameObjectList != null)
            {
                this.RowRectangles.Clear();
                for (int i = 0; i < this.gameObjectList.Count; i++)
                {
                    this.RowRectangles.Add(new Rectangle(this.VisibleLowerClient.X, (this.VisibleLowerClient.Y + this.columnheaderHeight) + (this.rowHeight * i), this.VisibleLowerClient.Width - 1, this.rowHeight));
                }
            }
        }

        public void ClearData()
        {
            this.Title = "";
            this.RowRectangles.Clear();
            this.Focused = 0;
            this.WidthCanShrink = true;
            this.HeightCanShrink = true;
            if (this.listKindToDisplay != null)
            {
                this.listKindToDisplay.ClearData();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (this.listKindToDisplay != null)
            {
                this.listKindToDisplay.Draw(spriteBatch);
            }
        }

        public void EnlargeRectanglesHeight()
        {
            if (!this.HeightCanShrink)
            {
                this.VisibleLowerClient = new Rectangle(this.VisibleLowerClient.X, this.VisibleLowerClient.Y, this.VisibleLowerClient.Width, (this.VisibleLowerClient.Height + (2 * this.scrolltrackWidth)) + this.scrollbuttonWidth);
                this.HeightCanShrink = true;
            }
        }

        public void EnlargeRectanglesWidth()
        {
            if (!this.WidthCanShrink)
            {
                this.VisibleLowerClient = new Rectangle(this.VisibleLowerClient.X, this.VisibleLowerClient.Y, (this.VisibleLowerClient.Width + (2 * this.scrolltrackWidth)) + this.scrollbuttonWidth, this.VisibleLowerClient.Height);
                for (int i = 0; i < this.RowRectangles.Count; i++)
                {
                    this.RowRectangles[i] = new Rectangle(this.RowRectangles[i].X, this.RowRectangles[i].Y, (this.RowRectangles[i].Width + (2 * this.scrolltrackWidth)) + this.scrollbuttonWidth, this.RowRectangles[i].Height);
                }
                this.WidthCanShrink = true;
            }
        }

        public Tab FindTabByPosition(Point position)
        {
            foreach (Tab tab in this.listKindToDisplay.Tabs)
            {
                if (StaticMethods.PointInRectangle(position, tab.Position))
                {
                    return tab;
                }
            }
            return null;
        }

        private Column GetColumnByPosition(Point position)
        {
            if (this.listKindToDisplay.SelectedTab != null)
            {
                foreach (Column column in this.listKindToDisplay.SelectedTab.Columns)
                {
                    if (((column.DisplayPosition.Left >= this.VisibleLowerClient.Left) && (column.DisplayPosition.Right <= this.VisibleLowerClient.Right)) && StaticMethods.PointInRectangle(position, column.DisplayPosition))
                    {
                        return column;
                    }
                }
            }
            return null;
        }

        public override string GetCurrentTitle()
        {
            if ((this.Title == "") && (this.listKindToDisplay != null))
            {
                return this.listKindToDisplay.DisplayName;
            }
            return this.Title;
        }

        private GameObject GetGameObjectByPosition(Point position)
        {
            for (int i = 0; i < this.RowRectangles.Count; i++)
            {
                Rectangle rectangle = this.RowRectangles[i];
                if (((rectangle.Bottom <= this.VisibleLowerClient.Bottom) && ((rectangle = this.RowRectangles[i]).Top >= (this.VisibleLowerClient.Top + this.columnheaderHeight))) && StaticMethods.PointInRectangle(position, this.RowRectangles[i]))
                {
                    return this.gameObjectList[i];
                }
            }
            return null;
        }

        public ListKind GetListKindByID(int ID)
        {
            foreach (ListKind kind in this.ListKinds)
            {
                if (kind.ID == ID)
                {
                    return kind;
                }
            }
            return null;
        }

        public ListKind GetListKindByName(string Name)
        {
            foreach (ListKind kind in this.ListKinds)
            {
                if (kind.Name == Name)
                {
                    return kind;
                }
            }
            return null;
        }

        public Rectangle GetRealLowerVisibleClient()
        {
            return new Rectangle(base.RealClient.X, this.listKindToDisplay.ColumnsTop, base.RealClient.Width, base.RealClient.Bottom - this.listKindToDisplay.ColumnsTop);
        }

        public int GetRowTopByPosition(Point position)
        {
            foreach (Rectangle rectangle in this.RowRectangles)
            {
                if (((rectangle.Bottom <= this.VisibleLowerClient.Bottom) && (rectangle.Top >= (this.VisibleLowerClient.Top + this.columnheaderHeight))) && StaticMethods.PointInRectangle(position, rectangle))
                {
                    return rectangle.Top;
                }
            }
            return -1;
        }

        public override string GetTitleString()
        {
            if (this.listKindToDisplay != null)
            {
                return this.listKindToDisplay.DisplayName;
            }
            return "未知";
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
            this.ListKinds = new List<ListKind>();
            this.RowRectangles = new List<Rectangle>();
        }

        public override void InitializeMapViewSelectorButton()
        {
            GameDelegates.VoidFunction function = null;
            if (this.MapViewSelectorButtonEnabled)
            {
                if (function == null)
                {
                    function = delegate {
                        this.iMapViewSelector.SetMultiSelecting(this.MultiSelecting);
                        this.iMapViewSelector.SetGameObjectList(this.gameObjectList);
                        if (this.firstTimeMapViewSelector)
                        {
                            this.firstTimeMapViewSelector = false;
                            this.iMapViewSelector.SetMapPosition(ShowPosition.Center);
                        }
                        this.iMapViewSelector.IsShowing = true;
                    };
                }
                base.MapViewSelectorFunction = function;
            }
        }

        public void InitialValues(GameObjectList gameObjectList, GameObjectList selectedObjectList, int scrollValue, string title)
        {
            this.SubKinds.Clear();
            this.SetObjectList(gameObjectList);
            this.SetSelectedObjectList(selectedObjectList);
            this.oldScrollValue = scrollValue;
            this.Title = title;
        }

        public void LoadFromXMLNode(XmlNode rootNode)
        {
            this.rowHeight = int.Parse(rootNode.Attributes.GetNamedItem("RowHeight").Value);
            base.defaultFrameWidth = int.Parse(rootNode.Attributes.GetNamedItem("FrameWidth").Value);
            base.defaultFrameHeight = int.Parse(rootNode.Attributes.GetNamedItem("FrameHeight").Value);
            this.client.X = int.Parse(rootNode.Attributes.GetNamedItem("ClientX").Value);
            this.client.Y = int.Parse(rootNode.Attributes.GetNamedItem("ClientY").Value);
            this.client.Width = int.Parse(rootNode.Attributes.GetNamedItem("ClientWidth").Value);
            this.client.Height = int.Parse(rootNode.Attributes.GetNamedItem("ClientHeight").Value);
            this.defaultOKButtonPosition.X = int.Parse(rootNode.Attributes.GetNamedItem("OKButtonX").Value);
            this.defaultOKButtonPosition.Y = int.Parse(rootNode.Attributes.GetNamedItem("OKButtonY").Value);
            this.defaultCancelButtonPosition.X = int.Parse(rootNode.Attributes.GetNamedItem("CancelButtonX").Value);
            this.defaultCancelButtonPosition.Y = int.Parse(rootNode.Attributes.GetNamedItem("CancelButtonY").Value);
            this.defaultMapViewSelectorButtonPosition.X = int.Parse(rootNode.Attributes.GetNamedItem("MapViewSelectorButtonX").Value);
            this.defaultMapViewSelectorButtonPosition.Y = int.Parse(rootNode.Attributes.GetNamedItem("MapViewSelectorButtonY").Value);
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                ListKind item = new ListKind(this);
                item.ID = int.Parse(node.Attributes.GetNamedItem("ID").Value);
                item.Name = node.Attributes.GetNamedItem("Name").Value;
                item.DisplayName = node.Attributes.GetNamedItem("DisplayName").Value;
                item.ShowPortrait = bool.Parse(node.Attributes.GetNamedItem("ShowPortrait").Value);
                item.LoadFromXMLNode(node);
                this.ListKinds.Add(item);
            }
        }

        internal void PopSubKind()
        {
            if (this.SubKinds.Count > 0)
            {
                SubKind rootListKind;
                this.SubKinds.Pop();
                if (this.SubKinds.Count > 0)
                {
                    rootListKind = this.SubKinds.Peek();
                }
                else
                {
                    rootListKind = this.RootListKind;
                }
                this.SetObjectList(rootListKind.List);
                this.listKindToDisplay = rootListKind.Kind;
                this.ReCalculate();
            }
            else
            {
                this.RightClickClose = true;
            }
        }

        internal void PushSubKindByName(string name, GameObjectList list)
        {
            if ((list != null) && (list.Count != 0))
            {
                if (this.SubKinds.Count == 0)
                {
                    this.RightClickClose = false;
                    this.RootListKind.Kind = this.listKindToDisplay;
                    this.RootListKind.List = this.gameObjectList;
                }
                this.SetObjectList(list);
                this.listKindToDisplay = this.GetListKindByName(name);
                if (this.listKindToDisplay != null)
                {
                    this.ReCalculate();
                    SubKind item = new SubKind();
                    item.Kind = this.listKindToDisplay;
                    item.List = list;
                    this.SubKinds.Push(item);
                }
            }
        }

        public override void ReCalculate()
        {
            base.ReCalculate();
            if (this.listKindToDisplay != null)
            {
                this.listKindToDisplay.ReCalculate();
            }
            this.SelectDefaultTab();
        }

        internal void RefreshEditable()
        {
            this.ResetEditableTextures();
            base.OKButtonEnabled = this.gameObjectList.HasSelectedItem();
            if (this.MultiSelecting)
            {
                this.SelectedItemList = this.gameObjectList.GetSelectedList();
            }
            else if (base.OKButtonEnabled)
            {
                this.SelectedItem = this.gameObjectList.GetSelectedList()[0];
            }
        }

        internal void ResetEditableTextures()
        {
            if (this.listKindToDisplay != null)
            {
                this.listKindToDisplay.ResetEditableTextures();
            }
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if ((this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame) && StaticMethods.PointInRectangle(position, base.RealClient))
            {
                if (position.Y < this.listKindToDisplay.ColumnsTop)
                {
                }
                else if (position.Y < (this.listKindToDisplay.ColumnsTop + this.columnheaderHeight))
                {
                }
                else
                {
                    GameObject gameObjectByPosition;
                    if (this.ShowCheckBox)
                    {
                        gameObjectByPosition = this.GetGameObjectByPosition(position);
                        if (gameObjectByPosition != null)
                        {
                            if (this.listKindToDisplay.IsInEditableColumn(position))
                            {
                                if ((gameObjectByPosition.Selected || (this.SelectedItemMaxCount <= 0)) || (this.gameObjectList.GetSelectedList().Count < this.SelectedItemMaxCount))
                                {
                                    if (this.MultiSelecting)
                                    {
                                        gameObjectByPosition.Selected = !gameObjectByPosition.Selected;

                                        this.SelectingRows = true;
                                        this.SelectingBool = gameObjectByPosition.Selected;
                                        this.SelectedItemList = this.gameObjectList.GetSelectedList();
                                    }
                                    else
                                    {
                                    }
                                    base.OKButtonEnabled = this.gameObjectList.HasSelectedItem() || (gameObjectByPosition is Faction);
                                    this.ResetEditableTextures();
                                    if (gameObjectByPosition.Selected)
                                    {
                                        this.SelectedItem = gameObjectByPosition;
                                        if (!(this.MultiSelecting || !GlobalVariables.SingleSelectionOneClick))
                                        {
                                            //this.iGameFrame.OK();
                                        }
                                        else
                                        {
                                            this.screen.PlayNormalSound(this.SelectSoundFile);
                                        }
                                    }
                                    else
                                    {
                                        this.SelectedItem = null;
                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                    }
                }
            }


        }

        private void screen_OnMouseLeftUp(Point position)
        {
            if ((this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame) && StaticMethods.PointInRectangle(position, base.RealClient))
            {
                if (position.Y < this.listKindToDisplay.ColumnsTop)
                {
                    Tab tab = this.FindTabByPosition(position);
                    if (tab != null)
                    {
                        tab.Selected = true;
                    }
                }
                else if (position.Y < (this.listKindToDisplay.ColumnsTop + this.columnheaderHeight))
                {
                    Column columnByPosition = this.GetColumnByPosition(position);
                    if (columnByPosition != null)
                    {
                        PropertyComparer comparer = new PropertyComparer(columnByPosition.Name, columnByPosition.IsNumber, columnByPosition.SmallToBig, columnByPosition.ItemID);
                        this.gameObjectList.Sort(comparer);
                        this.listKindToDisplay.ResetAllTextures();
                        columnByPosition.SmallToBig = !columnByPosition.SmallToBig;
                    }
                }
                else
                {
                    GameObject gameObjectByPosition;
                    if (this.ShowCheckBox)
                    {
                        gameObjectByPosition = this.GetGameObjectByPosition(position);
                        if (gameObjectByPosition != null)
                        {
                            if (this.listKindToDisplay.IsInEditableColumn(position))
                            {
                                if ((gameObjectByPosition.Selected || (this.SelectedItemMaxCount <= 0)) || (this.gameObjectList.GetSelectedList().Count < this.SelectedItemMaxCount))
                                {
                                    if (this.MultiSelecting)
                                    {
                                        /*
                                        this.SelectingRows = true;
                                        this.SelectingBool = gameObjectByPosition.Selected;
                                        this.SelectedItemList = this.gameObjectList.GetSelectedList();
                                         */

                                    }
                                    else
                                    {
                                        gameObjectByPosition.Selected = !gameObjectByPosition.Selected;

                                        this.gameObjectList.SetOtherUnSelected(gameObjectByPosition);
                                    }
                                    base.OKButtonEnabled = this.gameObjectList.HasSelectedItem() || (gameObjectByPosition is Faction);
                                    this.ResetEditableTextures();
                                    if (gameObjectByPosition.Selected)
                                    {
                                        this.SelectedItem = gameObjectByPosition;
                                        if (!(this.MultiSelecting || !GlobalVariables.SingleSelectionOneClick))
                                        {
                                            this.iGameFrame.OK();
                                        }
                                        else
                                        {
                                            //this.screen.PlayNormalSound(this.SelectSoundFile);
                                        }
                                    }
                                    else
                                    {
                                        this.SelectedItem = null;
                                    }
                                }
                            }
                            else
                            {
                                if (gameObjectByPosition is Troop)
                                {
                                    if ((this.iTroopDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iTroopDetail.SetPosition(ShowPosition.Center);
                                        this.iTroopDetail.SetTroop(gameObjectByPosition);
                                        this.iTroopDetail.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Troop).Position);
                                }
                                else if (gameObjectByPosition is Person)
                                {
                                    if ((this.iPersonDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iPersonDetail.SetPosition(ShowPosition.Center);
                                        this.iPersonDetail.SetPerson(gameObjectByPosition);
                                        this.iPersonDetail.IsShowing = true;
                                    }
                                    if (!(gameObjectByPosition as Person).IsCaptive)
                                    {
                                        this.screen.JumpTo((gameObjectByPosition as Person).Position);
                                    }
                                }
                                else if (gameObjectByPosition is Architecture)
                                {
                                    if ((this.iArchitectureDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iArchitectureDetail.SetPosition(ShowPosition.Center);
                                        this.iArchitectureDetail.SetArchitecture(gameObjectByPosition);
                                        this.iArchitectureDetail.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Architecture).Position);
                                }
                                else if (gameObjectByPosition is Military)
                                {
                                    this.screen.JumpTo((gameObjectByPosition as Military).Position);
                                }
                                else if (gameObjectByPosition is Faction)
                                {
                                    if ((this.iFactionTechniques != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iFactionTechniques.SetArchitecture(null);
                                        this.iFactionTechniques.SetFaction(gameObjectByPosition, false);
                                        this.iFactionTechniques.SetPosition(ShowPosition.Center);
                                        this.iFactionTechniques.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Faction).Leader.Position);
                                }
                                else if (gameObjectByPosition is Captive)
                                {
                                    if ((this.iPersonDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iPersonDetail.SetPosition(ShowPosition.Center);
                                        this.iPersonDetail.SetPerson((gameObjectByPosition as Captive).CaptivePerson);
                                        this.iPersonDetail.IsShowing = true;
                                    }
                                }
                                else if (gameObjectByPosition is Treasure)
                                {
                                    if ((this.iTreasureDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iTreasureDetail.SetPosition(ShowPosition.Center);
                                        this.iTreasureDetail.SetTreasure(gameObjectByPosition);
                                        this.iTreasureDetail.IsShowing = true;
                                    }
                                    if ((gameObjectByPosition as Treasure).BelongedPerson != null)
                                    {
                                        this.screen.JumpTo((gameObjectByPosition as Treasure).BelongedPerson.Position);
                                    }
                                }
                                if (gameObjectByPosition != null)
                                {
                                    base.TriggerItemClick();
                                }
                            }
                        }
                    }
                    else
                    {
                        gameObjectByPosition = this.GetGameObjectByPosition(position);
                        if (gameObjectByPosition != null)
                        {
                            if (this.listKindToDisplay.SelectedTab.ListMethod != null)
                            {
                                this.PushSubKindByName(this.listKindToDisplay.SelectedTab.ListKind, StaticMethods.GetListMethodValue(gameObjectByPosition, this.listKindToDisplay.SelectedTab.ListMethod) as GameObjectList);
                            }
                            else
                            {
                                if (gameObjectByPosition is Troop)
                                {
                                    if ((this.iTroopDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iTroopDetail.SetPosition(ShowPosition.Center);
                                        this.iTroopDetail.SetTroop(gameObjectByPosition);
                                        this.iTroopDetail.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Troop).Position);
                                }
                                else if (gameObjectByPosition is Person)
                                {
                                    if ((this.iPersonDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iPersonDetail.SetPosition(ShowPosition.Center);
                                        this.iPersonDetail.SetPerson(gameObjectByPosition);
                                        this.iPersonDetail.IsShowing = true;
                                    }
                                    if (!(gameObjectByPosition as Person).IsCaptive)
                                    {
                                        this.screen.JumpTo((gameObjectByPosition as Person).Position);
                                    }
                                }
                                else if (gameObjectByPosition is Architecture)
                                {
                                    if ((this.iArchitectureDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iArchitectureDetail.SetPosition(ShowPosition.Center);
                                        this.iArchitectureDetail.SetArchitecture(gameObjectByPosition);
                                        this.iArchitectureDetail.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Architecture).Position);
                                }
                                else if (gameObjectByPosition is Military)
                                {
                                    this.screen.JumpTo((gameObjectByPosition as Military).Position);
                                }
                                else if (gameObjectByPosition is Faction)
                                {
                                    if ((this.iFactionTechniques != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iFactionTechniques.SetArchitecture(null);
                                        this.iFactionTechniques.SetFaction(gameObjectByPosition, false);
                                        this.iFactionTechniques.SetPosition(ShowPosition.Center);
                                        this.iFactionTechniques.IsShowing = true;
                                    }
                                    this.screen.JumpTo((gameObjectByPosition as Faction).Leader.Position);
                                }
                                else if (gameObjectByPosition is Captive)
                                {
                                    if ((this.iPersonDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iPersonDetail.SetPosition(ShowPosition.Center);
                                        this.iPersonDetail.SetPerson((gameObjectByPosition as Captive).CaptivePerson);
                                        this.iPersonDetail.IsShowing = true;
                                    }
                                }
                                else if (gameObjectByPosition is Treasure)
                                {
                                    if ((this.iTreasureDetail != null) && (base.Function != FrameFunction.Jump))
                                    {
                                        this.iTreasureDetail.SetPosition(ShowPosition.Center);
                                        this.iTreasureDetail.SetTreasure(gameObjectByPosition);
                                        this.iTreasureDetail.IsShowing = true;
                                    }
                                    if ((gameObjectByPosition as Treasure).BelongedPerson != null)
                                    {
                                        this.screen.JumpTo((gameObjectByPosition as Treasure).BelongedPerson.Position);
                                    }
                                }
                                if (gameObjectByPosition != null)
                                {
                                    base.TriggerItemClick();
                                }
                            }
                        }
                    }
                }
            }


            /////////////////////////////////////////////////

            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame)
            {
                this.MovingHorizontalScrollBar = false;
                this.MovingVerticalScrollBar = false;
                this.SelectingRows = false;
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if ((this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame) && (this.oldMousePosition != position))
            {
                if (leftDown)
                {
                    if (this.ShowCheckBox && ((this.MultiSelecting && !this.MovingHorizontalScrollBar) && !this.MovingVerticalScrollBar))
                    {
                        GameObject gameObjectByPosition = this.GetGameObjectByPosition(position);
                        if (gameObjectByPosition != null)
                        {
                            if (!this.SelectingRows)
                            {
                                this.SelectingRows = true;
                                this.SelectingBool = gameObjectByPosition.Selected;
                            }
                            if (this.SelectingRows)
                            {
                                if (this.SelectingBool)
                                {
                                    if ((this.SelectedItemMaxCount <= 0) || (this.gameObjectList.GetSelectedList().Count < this.SelectedItemMaxCount))
                                    {
                                        gameObjectByPosition.Selected = this.SelectingBool;
                                        this.ResetEditableTextures();
                                    }
                                }
                                else
                                {
                                    gameObjectByPosition.Selected = this.SelectingBool;
                                    this.ResetEditableTextures();
                                }
                            }
                            base.OKButtonEnabled = this.gameObjectList.HasSelectedItem();
                            this.SelectedItemList = this.gameObjectList.GetSelectedList();
                        }
                    }
                    if (this.ShowHorizontalScrollBar && (this.MovingHorizontalScrollBar || StaticMethods.PointInRectangle(position, this.listKindToDisplay.HorizontalScrollBar)))
                    {
                        this.listKindToDisplay.MoveHorizontal(position.X - this.oldMousePosition.X);
                        this.MovingHorizontalScrollBar = true;
                    }
                    if (this.ShowVerticalScrollBar && (this.MovingVerticalScrollBar || StaticMethods.PointInRectangle(position, this.listKindToDisplay.VerticalScrollBar)))
                    {
                        this.listKindToDisplay.MoveVertical(position.Y - this.oldMousePosition.Y);
                        this.MovingVerticalScrollBar = true;
                    }
                }
                else
                {
                    int rowTopByPosition = this.GetRowTopByPosition(position);
                    if (rowTopByPosition >= 0)
                    {
                        this.Focused = rowTopByPosition;
                        this.FocusedObject = this.GetGameObjectByPosition(position);
                        this.DrawFocused = true;
                    }
                    else
                    {
                        this.DrawFocused = false;
                    }
                }
                this.oldMousePosition = position;
            }
        }

        private void screen_OnMouseRightUp(Point position)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame)
            {
                this.PopSubKind();
            }
        }

        private void screen_OnMouseScroll(Point position, int scrollValue)
        {
            if (((this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Frame) && (!this.MovingHorizontalScrollBar && !this.MovingVerticalScrollBar)) && (this.listKindToDisplay != null))
            {
                if (this.ShowVerticalScrollBar)
                {
                    this.listKindToDisplay.MoveVertical((this.oldScrollValue - scrollValue) / 6);
                }
                else if (this.ShowHorizontalScrollBar)
                {
                    this.listKindToDisplay.MoveHorizontal((scrollValue - this.oldScrollValue) / 6);
                }
                this.oldScrollValue = scrollValue;
            }
        }

        private void SelectDefaultTab()
        {
            if (((this.listKindToDisplay != null) && (this.listKindToDisplay.Tabs.Count > 0)) && !this.listKindToDisplay.HasSelectedTab)
            {
                this.listKindToDisplay.Tabs[0].Selected = true;
            }
        }

        public void SetListKindByID(int ID, bool showCheckBox, bool multiSelecting)
        {
            this.listKindToDisplay = this.GetListKindByID(ID);
            this.MultiSelecting = multiSelecting;
            if (this.listKindToDisplay != null)
            {
                this.SetShowCheckBox(showCheckBox);
            }
        }

        public void SetListKindByName(string Name, bool showCheckBox, bool multiSelecting)
        {
            this.listKindToDisplay = this.GetListKindByName(Name);
            this.MultiSelecting = multiSelecting;
            if (this.listKindToDisplay != null)
            {
                this.SetShowCheckBox(showCheckBox);
            }
        }

        public void SetObjectList(GameObjectList gameObjectList)
        {
            this.ClearData();
            this.gameObjectList = gameObjectList;
            foreach (GameObject obj2 in gameObjectList)
            {
                obj2.Selected = false;
            }
            this.FullLowerClient.Height = (gameObjectList.Count * this.rowHeight) + this.columnheaderHeight;
        }

        private void SetSelectedObjectList(GameObjectList selectedObjectList)
        {
            if (selectedObjectList != null)
            {
                foreach (GameObject obj2 in selectedObjectList)
                {
                    obj2.Selected = true;
                }
            }
        }

        public void SetSelectedTab(string tabName)
        {
            if ((this.listKindToDisplay != null) && (this.listKindToDisplay.Tabs.Count > 0))
            {
                this.listKindToDisplay.SetSelectedTab(tabName);
            }
        }

        private void SetShowCheckBox(bool show)
        {
            this.ShowCheckBox = show;
            if (this.listKindToDisplay != null)
            {
                if (show)
                {
                    this.listKindToDisplay.AddCheckBoxColumn();
                }
                else
                {
                    this.listKindToDisplay.RemoveCheckBoxColumn();
                }
            }
        }

        public void ShrinkRectanglesHeight()
        {
            if (this.HeightCanShrink)
            {
                this.VisibleLowerClient = new Rectangle(this.VisibleLowerClient.X, this.VisibleLowerClient.Y, this.VisibleLowerClient.Width, (this.VisibleLowerClient.Height - (2 * this.scrolltrackWidth)) - this.scrollbuttonWidth);
                this.HeightCanShrink = false;
            }
        }

        public void ShrinkRectanglesWidth()
        {
            if (this.WidthCanShrink)
            {
                this.VisibleLowerClient = new Rectangle(this.VisibleLowerClient.X, this.VisibleLowerClient.Y, (this.VisibleLowerClient.Width - (2 * this.scrolltrackWidth)) - this.scrollbuttonWidth, this.VisibleLowerClient.Height);
                for (int i = 0; i < this.RowRectangles.Count; i++)
                {
                    this.RowRectangles[i] = new Rectangle(this.RowRectangles[i].X, this.RowRectangles[i].Y, (this.RowRectangles[i].Width - (2 * this.scrolltrackWidth)) - this.scrollbuttonWidth, this.RowRectangles[i].Height);
                }
                //this.WidthCanShrink = false;
            }
        }

        public override bool CanClose
        {
            get
            {
                return this.RightClickClose;
            }
        }

        public override bool IsShowing
        {
            get
            {
                bool isShowing = base.isShowing;
                if (isShowing && (this.iPersonDetail != null))
                {
                    isShowing = !this.iPersonDetail.IsShowing;
                }
                if (isShowing && (this.iTroopDetail != null))
                {
                    isShowing = !this.iTroopDetail.IsShowing;
                }
                if (isShowing && (this.iArchitectureDetail != null))
                {
                    isShowing = !this.iArchitectureDetail.IsShowing;
                }
                if (isShowing && (this.iFactionTechniques != null))
                {
                    isShowing = !this.iFactionTechniques.IsShowing;
                }
                return isShowing;
            }
            set
            {
                if (value != base.isShowing)
                {
                    base.isShowing = value;
                    if (value)
                    {
                        this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseLeftUp += new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                        this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                        this.screen.OnMouseScroll += new Screen.MouseScroll(this.screen_OnMouseScroll);
                    }
                    else
                    {
                        this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseLeftUp -= new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                        this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                        this.screen.OnMouseScroll -= new Screen.MouseScroll(this.screen_OnMouseScroll);
                        this.SelectedItemMaxCount = 0;
                    }
                }
            }
        }

        public override bool MapViewSelectorButtonEnabled
        {
            get
            {
                return ((((this.iMapViewSelector != null) && (this.gameObjectList.Count > 0)) && (this.gameObjectList[0] is Architecture)) && this.ShowCheckBox);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SubKind
        {
            internal ListKind Kind;
            internal GameObjectList List;
        }
    }
}

