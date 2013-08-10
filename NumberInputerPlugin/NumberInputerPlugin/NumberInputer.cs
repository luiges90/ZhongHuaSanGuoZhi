﻿namespace NumberInputerPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    internal class NumberInputer
    {
        internal Point BackgroundSize;
        internal Texture2D BackgroundTexture;
        internal Rectangle BackspacePosition;
        internal Texture2D BackspaceTexture;
        internal Rectangle ClearPosition;
        internal Texture2D ClearTexture;
        private Keys currentKey;
        internal float DepthOffset;
        internal Point DisplayOffset;
        internal GameDelegates.VoidFunction EnterFunction;
        internal Rectangle EnterPosition;
        internal Texture2D EnterTexture;
        internal Rectangle ExitPosition;
        internal Texture2D ExitTexture;
        internal Rectangle FramePosition;
        internal FreeText FrameText;
        internal Texture2D FrameTexture;
        private bool isShowing;
        internal int Max = -1;
        internal Rectangle MaxPosition;
        internal Texture2D MaxTexture;
        internal int Num;
        internal List<Number> Numbers = new List<Number>();
        internal FreeText RangeText;
        private Screen screen;
        internal Rectangle SelectionDisplayPosition;
        internal Texture2D SelectionTexture;
        internal bool ShowSelection;
        internal string unit = "";

        private void Backspace()
        {
            this.Num /= 10;
            this.FrameText.Text = this.Num.ToString();
        }

        private void ClearNumber()
        {
            this.Num = 0;
            this.FrameText.Text = this.Num.ToString();
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            Rectangle? sourceRectangle = null;
            spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, this.DepthOffset + 0.2f);
            this.RangeText.Draw(spriteBatch, (this.DepthOffset + 0.2f) + -0.0001f);
            sourceRectangle = null;
            spriteBatch.Draw(this.FrameTexture, this.FrameDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -1E-05f);
            this.FrameText.Draw(spriteBatch, (this.DepthOffset + 0.2f) + -0.0001f);
            foreach (Number number in this.Numbers)
            {
                sourceRectangle = null;
                spriteBatch.Draw(number.Texture, number.GetDisplayPosition(this.DisplayOffset), sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            }
            sourceRectangle = null;
            spriteBatch.Draw(this.ClearTexture, this.ClearDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            sourceRectangle = null;
            spriteBatch.Draw(this.ExitTexture, this.ExitDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            sourceRectangle = null;
            spriteBatch.Draw(this.EnterTexture, this.EnterDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            sourceRectangle = null;
            spriteBatch.Draw(this.BackspaceTexture, this.BackspaceDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            sourceRectangle = null;
            spriteBatch.Draw(this.MaxTexture, this.MaxDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, (this.DepthOffset + 0.2f) + -0.001f);
            if (this.ShowSelection)
            {
                spriteBatch.Draw(this.SelectionTexture, this.SelectionDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, ((this.DepthOffset + 0.2f) + -0.001f) + -0.0002f);
            }
        }

        private void Enter()
        {
            if (this.EnterFunction != null)
            {
                this.EnterFunction();
                this.EnterFunction = null;
            }
            this.IsShowing = false;
        }

        private void Exit()
        {
            this.IsShowing = false;
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void InputDigit(int digit)
        {
            this.Num *= 10;
            this.Num += digit;
            if ((this.Max >= 0) && (this.Num > this.Max))
            {
                this.Num = this.Max;
            }
            this.FrameText.Text = this.Num.ToString();
        }

        private void MaxNumber()
        {
            if (this.Max >= 0)
            {
                this.Num = this.Max;
                this.FrameText.Text = this.Num.ToString();
            }
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Inputer)
            {
                if (StaticMethods.PointInRectangle(position, this.ClearDisplayPosition))
                {
                    this.ClearNumber();
                }
                else if (StaticMethods.PointInRectangle(position, this.BackspaceDisplayPosition))
                {
                    this.Backspace();
                }
                else if (StaticMethods.PointInRectangle(position, this.EnterDisplayPosition))
                {
                    this.Enter();
                }
                else if (StaticMethods.PointInRectangle(position, this.MaxDisplayPosition))
                {
                    this.MaxNumber();
                }
                else if (StaticMethods.PointInRectangle(position, this.ExitDisplayPosition))
                {
                    this.Exit();
                }
                else
                {
                    foreach (Number number in this.Numbers)
                    {
                        if (StaticMethods.PointInRectangle(position, number.GetDisplayPosition(this.DisplayOffset)))
                        {
                            this.InputDigit(number.Num);
                            break;
                        }
                    }
                }
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Inputer)
            {
                this.ShowSelection = false;
                foreach (Number number in this.Numbers)
                {
                    if (StaticMethods.PointInRectangle(position, number.GetDisplayPosition(this.DisplayOffset)))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = number.GetDisplayPosition(this.DisplayOffset);
                        break;
                    }
                }
                if (!this.ShowSelection)
                {
                    if (StaticMethods.PointInRectangle(position, this.ClearDisplayPosition))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = this.ClearDisplayPosition;
                    }
                    else if (StaticMethods.PointInRectangle(position, this.BackspaceDisplayPosition))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = this.BackspaceDisplayPosition;
                    }
                    else if (StaticMethods.PointInRectangle(position, this.EnterDisplayPosition))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = this.EnterDisplayPosition;
                    }
                    else if (StaticMethods.PointInRectangle(position, this.MaxDisplayPosition))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = this.MaxDisplayPosition;
                    }
                    else if (StaticMethods.PointInRectangle(position, this.ExitDisplayPosition))
                    {
                        this.ShowSelection = true;
                        this.SelectionDisplayPosition = this.ExitDisplayPosition;
                    }
                }
            }
        }

        private void screen_OnMouseRightDown(Point position)
        {
            if (this.screen.PeekUndoneWork().Kind == UndoneWorkKind.Inputer)
            {
                this.IsShowing = false;
            }
        }

        internal void SetDisplayOffset(ShowPosition showPosition)
        {
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            Rectangle rect = new Rectangle(0, 0, this.BackgroundSize.X, this.BackgroundSize.Y);
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
            }
            this.DisplayOffset = new Point(rect.X, rect.Y);
            this.RangeText.DisplayOffset = this.DisplayOffset;
            if (this.Max >= 0)
            {
                this.RangeText.Text = "0 - " + this.Max.ToString() + this.unit;
            }
            else
            {
                this.RangeText.Text = "0 - 任意";
            }
            this.FrameText.DisplayOffset = this.DisplayOffset;
            this.FrameText.Text = this.Num.ToString();
        }

        internal void Update()
        {
            if (this.currentKey != Keys.None)
            {
                if (!this.screen.KeyState.IsKeyUp(this.currentKey))
                {
                    return;
                }
                this.currentKey = Keys.None;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad0))
            {
                this.InputDigit(0);
                this.currentKey = Keys.NumPad0;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D0))
            {
                this.InputDigit(0);
                this.currentKey = Keys.D0;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad1))
            {
                this.InputDigit(1);
                this.currentKey = Keys.NumPad1;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D1))
            {
                this.InputDigit(1);
                this.currentKey = Keys.D1;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad2))
            {
                this.InputDigit(2);
                this.currentKey = Keys.NumPad2;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D2))
            {
                this.InputDigit(2);
                this.currentKey = Keys.D2;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad3))
            {
                this.InputDigit(3);
                this.currentKey = Keys.NumPad3;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D3))
            {
                this.InputDigit(3);
                this.currentKey = Keys.D3;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad4))
            {
                this.InputDigit(4);
                this.currentKey = Keys.NumPad4;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D4))
            {
                this.InputDigit(4);
                this.currentKey = Keys.D4;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad5))
            {
                this.InputDigit(5);
                this.currentKey = Keys.NumPad5;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D5))
            {
                this.InputDigit(5);
                this.currentKey = Keys.D5;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad6))
            {
                this.InputDigit(6);
                this.currentKey = Keys.NumPad6;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D6))
            {
                this.InputDigit(6);
                this.currentKey = Keys.D6;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad7))
            {
                this.InputDigit(7);
                this.currentKey = Keys.NumPad7;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D7))
            {
                this.InputDigit(7);
                this.currentKey = Keys.D7;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad8))
            {
                this.InputDigit(8);
                this.currentKey = Keys.NumPad8;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D8))
            {
                this.InputDigit(8);
                this.currentKey = Keys.D8;
            }
            if (this.screen.KeyState.IsKeyDown(Keys.NumPad9))
            {
                this.InputDigit(9);
                this.currentKey = Keys.NumPad9;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.D9))
            {
                this.InputDigit(9);
                this.currentKey = Keys.D9;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Delete))
            {
                this.ClearNumber();
                this.currentKey = Keys.Delete;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Enter))
            {
                this.Enter();
                this.currentKey = Keys.Enter;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Back))
            {
                this.Backspace();
                this.currentKey = Keys.Back;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
                this.currentKey = Keys.Escape;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Space))
            {
                this.MaxNumber();
                this.currentKey = Keys.Space;
            }
            else if (this.screen.KeyState.IsKeyDown(Keys.Add))
            {
                this.MaxNumber();
                this.currentKey = Keys.Add;
            }
        }

        private Rectangle BackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X, this.DisplayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
            }
        }

        private Rectangle BackspaceDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.BackspacePosition.X, this.DisplayOffset.Y + this.BackspacePosition.Y, this.BackspacePosition.Width, this.BackspacePosition.Height);
            }
        }

        private Rectangle ClearDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.ClearPosition.X, this.DisplayOffset.Y + this.ClearPosition.Y, this.ClearPosition.Width, this.ClearPosition.Height);
            }
        }

        private Rectangle EnterDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.EnterPosition.X, this.DisplayOffset.Y + this.EnterPosition.Y, this.EnterPosition.Width, this.EnterPosition.Height);
            }
        }

        private Rectangle ExitDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.ExitPosition.X, this.DisplayOffset.Y + this.ExitPosition.Y, this.ExitPosition.Width, this.ExitPosition.Height);
            }
        }

        private Rectangle FrameDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.FramePosition.X, this.DisplayOffset.Y + this.FramePosition.Y, this.FramePosition.Width, this.FramePosition.Height);
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.isShowing;
            }
            set
            {
                this.isShowing = value;
                if (value)
                {
                    this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Inputer, UndoneWorkSubKind.None));
                    this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseRightDown += new Screen.MouseRightDown(this.screen_OnMouseRightDown);
                    this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                }
                else
                {
                    this.Max = -1;
                    this.DepthOffset = 0f;
                    this.Num = 0;
                    this.unit = "";
                    if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.Inputer)
                    {
                        throw new Exception("The UndoneWork is not a NumberInputer.");
                    }
                    this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseRightDown -= new Screen.MouseRightDown(this.screen_OnMouseRightDown);
                    this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                }
            }
        }

        private Rectangle MaxDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X + this.MaxPosition.X, this.DisplayOffset.Y + this.MaxPosition.Y, this.MaxPosition.Width, this.MaxPosition.Height);
            }
        }
    }
}

