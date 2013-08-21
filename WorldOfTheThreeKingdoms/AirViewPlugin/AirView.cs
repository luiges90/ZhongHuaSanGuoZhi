﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameFreeText;
using		GameGlobal;
using		GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace AirViewPlugin
{
    internal class AirView : Tool
    {
        internal Texture2D ArchitectureTexture;
        internal Texture2D ArchitectureUnitTexture;
        internal FreeText Conment;
        internal Texture2D ConmentBackgroundTexture;
        internal int DefaultTileLength;
        private Rectangle framePosition;
        internal Texture2D FrameTexture;
        private bool isMapShowing;
        private bool isPreparedToJump = false;
        private Point MapDisplayOffset;
        internal int MapMaxHeight;
        internal int MapMaxWidth;
        internal ShowPosition MapShowPosition = ShowPosition.BottomRight;
        private Point mapSize;
        internal Texture2D MapTexture;
        internal GameScenario scenario;
        private Screen screen;
        internal int TileLength;
        internal int TileLengthMax;
        internal Texture2D ToolDisplayTexture;
        internal Rectangle ToolPosition;
        internal Texture2D ToolSelectedTexture;
        internal Texture2D ToolTexture;

        internal Texture2D TroopToolDisplayTexture;
        internal Rectangle TroopToolPosition;
        internal Texture2D TroopToolSelectedTexture;
        internal Texture2D TroopToolTexture;

        internal float Transparent = 1f;
        internal Texture2D TroopTexture;
        internal Texture2D TroopFactionColorTexture;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 240;
        bool drawTroopFlag = true;
        bool showTroop = true;

        internal void AddDisableRects()
        {
            this.screen.AddDisableRectangle(this.screen.LaterMouseEventDisableRects, this.MapPosition);
            this.screen.AddDisableRectangle(this.screen.SelectingDisableRects, this.MapPosition);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Rectangle? sourceRectangle = null;
            spriteBatch.Draw(this.ToolDisplayTexture, this.ToolDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.099f);
            if (this.IsMapShowing)
            {
                spriteBatch.Draw(this.TroopToolDisplayTexture, this.TroopToolDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.099f);

                if (this.MapTexture != null)
                {
                    sourceRectangle = null;
                    spriteBatch.Draw(this.MapTexture, this.MapPosition, sourceRectangle, new Color(1f, 1f, 1f, this.Transparent), 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
                }
                /*
                if (this.TroopTexture != null)
                {
                    sourceRectangle = null;
                    spriteBatch.Draw(this.TroopTexture, this.MapPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.09999f);
                }
                */
                if (this.showTroop)
                {
                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        //timeSinceLastFrame -= millisecondsPerFrame;
                        timeSinceLastFrame = 0;
                        this.drawTroopFlag = !this.drawTroopFlag;
                    }
                    if (this.drawTroopFlag)
                    {
                        this.drawTroop(spriteBatch, gameTime);
                    }
                }
                foreach (Architecture architecture in this.scenario.Architectures)
                {
                    Color white = Color.White;
                    if (architecture.BelongedFaction != null)
                    {
                        white = architecture.BelongedFaction.FactionColor;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        sourceRectangle = null;
                        spriteBatch.Draw(this.ArchitectureUnitTexture, new Rectangle(((point.X * this.TileLength) + this.MapDisplayOffset.X) - 1, ((point.Y * this.TileLength) + this.MapDisplayOffset.Y) - 1, this.TileLength + 2, this.TileLength + 2), sourceRectangle, white, 0f, Vector2.Zero, SpriteEffects.None, 0.09999f);
                    }
                }
                sourceRectangle = null;
                //spriteBatch.Draw(this.FrameTexture, this.FrameDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0998f);
                spriteBatch.Draw(this.FrameTexture, this.frameTopPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0998f);
                spriteBatch.Draw(this.FrameTexture, this.frameLeftPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0998f);
                spriteBatch.Draw(this.FrameTexture, this.frameBottomPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0998f);
                spriteBatch.Draw(this.FrameTexture, this.frameRightPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.0998f);
                if (this.Conment.Text != "")
                {
                    spriteBatch.Draw(this.ConmentBackgroundTexture, this.Conment.AlignedPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.09999f);
                    this.Conment.Draw(spriteBatch, 0.0999f);
                }
            }
        }

        private void drawTroop(SpriteBatch spriteBatch, GameTime gameTime)
        {

            for (int i = 0; i < this.scenario.ScenarioMap.MapDimensions.X; i++)
            {
                for (int j = 0; j < this.scenario.ScenarioMap.MapDimensions.Y; j++)
                {
                    if (GlobalVariables.SkyEye||this.scenario.CurrentPlayer.IsPositionKnown(new Microsoft.Xna.Framework.Point(i, j)))
                    {
                        Troop troopByPositionNoCheck = this.scenario.GetTroopByPositionNoCheck(new Microsoft.Xna.Framework.Point(i, j));
                        if ((troopByPositionNoCheck != null) && !troopByPositionNoCheck.Destroyed)
                        {
                            Color color = Color.White;
                            if (troopByPositionNoCheck.BelongedFaction != null)
                            {
                                color = troopByPositionNoCheck.BelongedFaction.FactionColor;
                            }
                            spriteBatch.Draw(TroopFactionColorTexture, new Rectangle(i * this.TileLength + this.MapDisplayOffset.X - 1, j * this.TileLength + this.MapDisplayOffset.Y - 1, this.TileLength * 4, this.TileLength * 4), null,color, 0f, Vector2.Zero, SpriteEffects.None, 0.09998f);

                        }
                    }
                }
            }
        }

        private Point GetTranslatedPosition(Point position)
        {
            int num = position.X - this.MapDisplayOffset.X;
            int num2 = position.Y - this.MapDisplayOffset.Y;
            return new Point((this.scenario.ScenarioMap.MapDimensions.X * num) / this.mapSize.X, (this.scenario.ScenarioMap.MapDimensions.Y * num2) / this.mapSize.Y);
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
            this.scenario = screen.Scenario;
            screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
            screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
        }

        private void JumpTo(Point position)
        {
            if (this.isPreparedToJump)
            {
                this.screen.JumpTo(this.GetTranslatedPosition(position));
            }
        }

        internal void RemoveDisableRects()
        {
            this.screen.RemoveDisableRectangle(this.screen.LaterMouseEventDisableRects, this.MapPosition);
            this.screen.RemoveDisableRectangle(this.screen.SelectingDisableRects, this.MapPosition);
        }

        internal void ResetFramePosition(Point viewportSize, int leftEdge, int topEdge, Point totalMapSize)
        {
            if ((this.framePosition.Width + this.framePosition.Height) == 0)
            {
                this.ResetFrameSize(viewportSize, totalMapSize);
            }
            int x = ((((viewportSize.X / 2) - leftEdge) * this.mapSize.X) / totalMapSize.X) - (this.framePosition.Width / 2);
            int y = ((((viewportSize.Y / 2) - topEdge) * this.mapSize.Y) / totalMapSize.Y) - (this.framePosition.Height / 2);
            if (x < 0)
            {
                x = 0;
            }
            if ((x + this.framePosition.Width) > this.mapSize.X)
            {
                x = this.mapSize.X - this.framePosition.Width;
            }
            if (y < 0)
            {
                y = 0;
            }
            if ((y + this.framePosition.Height) > this.mapSize.Y)
            {
                y = this.mapSize.Y - this.framePosition.Height;
            }
            this.framePosition = new Rectangle(x, y, this.framePosition.Width, this.framePosition.Height);
        }

        internal void ResetFrameSize(Point viewportSize, Point totalMapSize)
        {
            int width = (this.mapSize.X * viewportSize.X) / totalMapSize.X;
            int height = (this.mapSize.Y * viewportSize.Y) / totalMapSize.Y;
            this.framePosition = new Rectangle(0, 0, width, height);
        }

        private void ResetMapSize()
        {
            int x = this.scenario.ScenarioMap.MapDimensions.X;
            int y = this.scenario.ScenarioMap.MapDimensions.Y;
            if (x > y)
            {
                if (x > this.MapMaxWidth)
                {
                    y = (y * this.MapMaxWidth) / x;
                    x = this.MapMaxWidth;
                }
                if (y > this.MapMaxHeight)
                {
                    x = (x * this.MapMaxHeight) / y;
                    y = this.MapMaxHeight;
                }
            }
            else
            {
                if (y > this.MapMaxHeight)
                {
                    x = (x * this.MapMaxHeight) / y;
                    y = this.MapMaxHeight;
                }
                if (x > this.MapMaxWidth)
                {
                    y = (y * this.MapMaxWidth) / x;
                    x = this.MapMaxWidth;
                }
            }
            if ((x < this.MapMaxWidth) && (y < this.MapMaxHeight))
            {
                int tileLengthMax = this.MapMaxWidth / x;
                int num4 = this.MapMaxHeight / y;
                if (tileLengthMax < num4)
                {
                    tileLengthMax = num4;
                }
                if (tileLengthMax > this.TileLengthMax)
                {
                    tileLengthMax = this.TileLengthMax;
                }
                this.TileLength = tileLengthMax;
            }
            this.mapSize = new Point(x * this.TileLength, y * this.TileLength);
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (base.IsDrawing)
            {
                if (StaticMethods.PointInRectangle(position, this.ToolDisplayPosition))
                {
                    this.IsMapShowing = !this.IsMapShowing;
                    if (base.Enabled)
                    {
                        if (this.IsMapShowing)
                        {
                                this.ToolDisplayTexture = this.ToolSelectedTexture;
                        }
                        else
                        {
                            this.ToolDisplayTexture = this.ToolTexture;
                        }
                    }
                }
                else if (this.IsMapShowing && StaticMethods.PointInRectangle(position, this.TroopToolDisplayPosition))
                {
                    this.showTroop = !this.showTroop;
                    if (this.showTroop)
                    {
                        this.TroopToolDisplayTexture = this.TroopToolSelectedTexture;
                    }
                    else
                    {
                        this.TroopToolDisplayTexture = this.TroopToolTexture;
                    }
                }
                else if (this.IsMapShowing && StaticMethods.PointInRectangle(position, this.MapPosition))
                {
                    this.JumpTo(position);
                }
            }
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            if (base.IsDrawing)
            {
                if (!this.IsMapShowing)
                {
                    if (base.Enabled)
                    {

                            this.ToolDisplayTexture = this.ToolTexture;

                    }
                }
                else if (StaticMethods.PointInRectangle(position, this.MapPosition))
                {
                    this.isPreparedToJump = true;
                    if (GlobalVariables.FastBattleSpeed <= 1)
                    {
                        this.screen.ResetMouse();
                        if (leftDown)
                        {
                            this.JumpTo(position);
                        }
                        else if (this.isPreparedToJump)
                        {
                            Architecture architectureByPosition = this.scenario.GetArchitectureByPosition(this.GetTranslatedPosition(position));
                            if (architectureByPosition != null)
                            {
                                this.Conment.DisplayOffset = position;
                                this.Conment.Text = architectureByPosition.Name + " " + architectureByPosition.FactionString;
                            }
                            else
                            {
                                this.Conment.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    this.isPreparedToJump = false;
                }
            }
        }

        private void screen_OnMouseRightUp(Point position)
        {
            if ((base.IsDrawing && this.IsMapShowing) && StaticMethods.PointInRectangle(position, this.MapPosition))
            {
                this.IsMapShowing = false;
                this.ToolDisplayTexture = this.ToolTexture;
            }
        }

        internal void SetDisplayOffset(ShowPosition showPosition)
        {
            this.TileLength = this.DefaultTileLength;
            this.ResetMapSize();
            Rectangle rectDes = new Rectangle(0, 0, this.screen.viewportSize.X, this.screen.viewportSize.Y);
            Rectangle rect = new Rectangle(0, 0, this.mapSize.X, this.mapSize.Y);
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
            this.MapDisplayOffset = new Point(rect.X-30, rect.Y);
        }

        public override void Update()
        {
        }

        private Rectangle FrameDisplayPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X + this.framePosition.X, this.MapDisplayOffset.Y + this.framePosition.Y, this.framePosition.Width, this.framePosition.Height);
            }
        }

        private Rectangle frameTopPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X + this.framePosition.X, this.MapDisplayOffset.Y + this.framePosition.Y, this.framePosition.Width, 2);
            }
        }

        private Rectangle frameLeftPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X + this.framePosition.X, this.MapDisplayOffset.Y + this.framePosition.Y, 2, this.framePosition.Height);
            }
        }

        private Rectangle frameBottomPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X + this.framePosition.X, this.MapDisplayOffset.Y + this.framePosition.Y + this.framePosition.Height-1, this.framePosition.Width+1, 2);
            }
        }

        private Rectangle frameRightPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X + this.framePosition.X + this.framePosition.Width-1, this.MapDisplayOffset.Y + this.framePosition.Y, 2, this.framePosition.Height+1);
            }
        }

        internal bool IsMapShowing
        {
            get
            {
                return this.isMapShowing;
            }
            set
            {
                this.isMapShowing = value;
                if (value)
                {
                    this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    //this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);

                    this.SetDisplayOffset(this.MapShowPosition);
                    this.AddDisableRects();
                }
                else
                {
                    this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    //this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                    this.RemoveDisableRects();
                }
            }
        }

        private Rectangle MapPosition
        {
            get
            {
                return new Rectangle(this.MapDisplayOffset.X, this.MapDisplayOffset.Y, this.mapSize.X, this.mapSize.Y);
            }
        }

        private Rectangle ToolDisplayPosition
        {
            get
            {
                return new Rectangle(this.ToolPosition.X + this.DisplayOffset.X, this.ToolPosition.Y + this.DisplayOffset.Y, this.ToolPosition.Width, this.ToolPosition.Height);
            }
        }

        private Rectangle TroopToolDisplayPosition
        {
            get
            {
                return new Rectangle(this.TroopToolPosition.X + this.DisplayOffset.X, this.TroopToolPosition.Y + this.DisplayOffset.Y, this.TroopToolPosition.Width, this.TroopToolPosition.Height);
            }
        }
    }

 

}
