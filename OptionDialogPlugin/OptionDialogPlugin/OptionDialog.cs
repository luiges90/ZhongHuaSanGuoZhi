﻿namespace OptionDialogPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    internal class OptionDialog
    {
        private bool dragging;
        private bool isShowing;
        internal int ItemHeight;
        internal int ItemWidth;
        internal int Margin;
        private List<GameDelegates.VoidFunction> OptionFunctions = new List<GameDelegates.VoidFunction>();
        private List<object> OptionObjects = new List<object>();
        private List<bool> OptionObjectsSelected = new List<bool>();
        internal Texture2D OptionSelectedTexture;
        internal FreeTextList OptionTextList;
        internal Texture2D OptionTexture;
        private List<Texture2D> OptionTextures = new List<Texture2D>();
        internal GameDelegates.ObjectFunction ReturnObjectFunction;
        private Screen screen;
        internal Dictionary<string, OptionStyle> Styles = new Dictionary<string, OptionStyle>();
        private Rectangle TitleDisplayPosition;
        internal int TitleHeight;
        internal int TitleMargin;
        internal FreeText TitleText;
        internal Texture2D TitleTexture;
        internal int TitleWidth;

        internal void AddOptionItem(string Text, object obj, GameDelegates.VoidFunction optionFunction)
        {
            this.OptionTextList.AddText(Text);
            this.OptionObjects.Add(obj);
            this.OptionTextures.Add(this.OptionTexture);
            this.OptionFunctions.Add(optionFunction);
        }

        internal void Clear()
        {
            this.ReturnObjectFunction = null;
            this.OptionTextList.Clear();
            this.OptionObjects.Clear();
            this.OptionTextures.Clear();
            this.OptionFunctions.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.OptionTextList.Count != 0)
            {
                Rectangle? sourceRectangle = null;
                spriteBatch.Draw(this.TitleTexture, this.TitleDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                this.TitleText.Draw(spriteBatch, 0.1999f);
                for (int i = 0; i < this.OptionTextures.Count; i++)
                {
                    sourceRectangle = null;
                    spriteBatch.Draw(this.OptionTextures[i], this.OptionTextList.DisplayPosition(i), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                }
                this.OptionTextList.Draw(spriteBatch, (float) 0.1999f);
            }
        }

        internal void EndAddOptions()
        {
            this.OptionTextList.ResetAllTextTextures();
            this.ItemWidth = this.OptionTextList.MaxWidth + this.Margin;
            for (int i = 0; i < this.OptionTextures.Count; i++)
            {
                this.OptionTextList[i].Position = new Rectangle(0, i * this.ItemHeight, this.ItemWidth, this.ItemHeight);
            }
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void InvokeFunction(int i)
        {
            if (this.OptionFunctions[i] != null)
            {
                if (this.ReturnObjectFunction != null)
                {
                    this.ReturnObjectFunction(this.OptionObjects[i]);
                }
                this.OptionFunctions[i]();
            }
        }

        private void screen_OnMouseLeftDown(Point position)
        {

        }

        private void screen_OnMouseLeftUp(Point position)
        {
            for (int i = 0; i < this.OptionTextures.Count; i++)
            {
                if (StaticMethods.PointInRectangle(position, this.OptionTextList.DisplayPosition(i)))
                {
                    this.IsShowing = false;
                    this.InvokeFunction(i);
                    break;
                }
            }

            this.dragging = false;
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (StaticMethods.PointInRectangle(position, this.TitleDisplayPosition))
            {
                this.dragging = leftDown;
            }
            else
            {
                for (int i = 0; i < this.OptionTextures.Count; i++)
                {
                    if (StaticMethods.PointInRectangle(position, this.OptionTextList.DisplayPosition(i)))
                    {
                        this.OptionTextures[i] = this.OptionSelectedTexture;
                        if (this.OptionObjects[i] is GameObject)
                        {
                            (this.OptionObjects[i] as GameObject).Selected = true;
                        }
                    }
                    else
                    {
                        this.OptionTextures[i] = this.OptionTexture;
                        if (this.OptionObjects[i] is GameObject)
                        {
                            (this.OptionObjects[i] as GameObject).Selected = false;
                        }
                    }
                }
            }
            if (this.dragging)
            {
                this.OptionTextList.DisplayOffset = new Point(this.OptionTextList.DisplayOffset.X + this.screen.MouseOffset.X, this.OptionTextList.DisplayOffset.Y + this.screen.MouseOffset.Y);
                this.TitleDisplayPosition = StaticMethods.GetCenterRectangle(new Rectangle(this.OptionTextList.DisplayOffset.X, (this.OptionTextList.DisplayOffset.Y - this.TitleHeight) - this.TitleMargin, this.ItemWidth, this.TitleHeight), new Rectangle(0, 0, this.TitleWidth, this.TitleHeight));
                this.TitleText.DisplayOffset = new Point(this.TitleDisplayPosition.X, this.TitleDisplayPosition.Y);
            }
        }

        private void screen_OnMouseRightDown(Point position)
        {
            this.IsShowing = false;
        }

        internal void SetDisplayOffset(ShowPosition showPosition)
        {
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            switch (showPosition)
            {
                case ShowPosition.Center:
                    rect = StaticMethods.GetCenterRectangle(rectDes, rect);
                    break;

                case ShowPosition.Top:
                    rect = StaticMethods.GetTopRectangle(rectDes, rect);
                    break;

                case ShowPosition.Left:
                    rect = StaticMethods.GetLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.Right:
                    rect = StaticMethods.GetRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.Bottom:
                    rect = StaticMethods.GetBottomRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopLeft:
                    rect = StaticMethods.GetTopLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.TopRight:
                    rect = StaticMethods.GetTopRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomLeft:
                    rect = StaticMethods.GetBottomLeftRectangle(rectDes, rect);
                    break;

                case ShowPosition.BottomRight:
                    rect = StaticMethods.GetBottomRightRectangle(rectDes, rect);
                    break;

                case ShowPosition.Mouse:
                    rect.X = this.screen.MousePosition.X;
                    rect.Y = this.screen.MousePosition.Y;
                    break;
            }
            this.OptionTextList.DisplayOffset = new Point(rect.X, rect.Y);
            this.TitleDisplayPosition = StaticMethods.GetCenterRectangle(new Rectangle(rect.X, (rect.Y - this.TitleHeight) - this.TitleMargin, this.ItemWidth, this.TitleHeight), new Rectangle(0, 0, this.TitleWidth, this.TitleHeight));
            this.TitleText.DisplayOffset = new Point(this.TitleDisplayPosition.X, this.TitleDisplayPosition.Y);
        }

        internal void SetStyle(string style)
        {
            OptionStyle style2 = null;
            this.Styles.TryGetValue(style, out style2);
            if (style2 != null)
            {
                this.TitleTexture = style2.TitleTexture;
                this.TitleWidth = style2.TitleWidth;
                this.TitleHeight = style2.TitleHeight;
                this.TitleMargin = style2.TitleMargin;
                this.TitleText = style2.TitleText;
                this.OptionTextList = style2.OptionTextList;
                this.ItemHeight = style2.ItemHeight;
                this.Margin = style2.Margin;
                this.OptionTexture = style2.OptionTexture;
                this.OptionSelectedTexture = style2.OptionSelectedTexture;
            }
        }

        internal void SetTitle(string title)
        {
            this.TitleText.Text = title;
        }

        public void Update()
        {
        }

        internal Point DisplayOffset
        {
            get
            {
                return this.OptionTextList.DisplayOffset;
            }
            set
            {
                this.OptionTextList.DisplayOffset = value;
            }
        }

        internal int Height
        {
            get
            {
                return (this.ItemHeight * this.OptionTextures.Count);
            }
        }

        internal bool IsShowing
        {
            get
            {
                return this.isShowing;
            }
            set
            {
                if (this.isShowing != value)
                {
                    this.isShowing = value;
                    if (value)
                    {
                        this.OptionObjectsSelected.Clear();
                        foreach (GameObject obj2 in this.OptionObjects)
                        {
                            if (obj2 != null)
                            {
                                this.OptionObjectsSelected.Add(obj2.Selected);
                            }
                        }
                        this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Dialog, DialogKind.Options));
                        this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseLeftUp += new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                        this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.OnMouseRightDown += new Screen.MouseRightDown(this.screen_OnMouseRightDown);
                    }
                    else
                    {
                        this.screen.PopUndoneWork();
                        this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                        this.screen.OnMouseLeftUp -= new Screen.MouseLeftUp(this.screen_OnMouseLeftUp);
                        this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                        this.screen.OnMouseRightDown -= new Screen.MouseRightDown(this.screen_OnMouseRightDown);
                        foreach (GameObject obj2 in this.OptionObjects)
                        {
                            if (obj2 != null)
                            {
                                obj2.Selected = this.OptionObjectsSelected[0];
                                this.OptionObjectsSelected.RemoveAt(0);
                            }
                        }
                    }
                }
            }
        }

        internal int Width
        {
            get
            {
                return this.ItemWidth;
            }
        }
    }
}

