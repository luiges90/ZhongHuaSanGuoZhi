using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;
using GameFreeText;
using		Microsoft.Xna.Framework;

using WorldOfTheThreeKingdoms;
using Microsoft.Xna.Framework.Graphics;
using GameObjects.Animations;
using WorldOfTheThreeKingdoms.Resources;


namespace WorldOfTheThreeKingdoms.GameScreens.ScreenLayers

{
    internal class ArchitectureLayer
    {
        private ArchitectureList Architectures;
        private GameScenario gameScenario;
        private MainMapLayer mainMapLayer;
        private MainGameScreen screen;
        static Point currentFrame = new Point(0, 0);
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 180;
        Point frameSize = new Point(100, 100);
        Point sheetSize = new Point(6, 1);


        

        public void Draw(SpriteBatch spriteBatch, Point viewportSize,  GameTime gameTime)
        {


            if (spriteBatch != null)
            {
                foreach (Architecture architecture in this.Architectures)
                {
                    Color zainanyanse = new Color();
                    if (architecture.youzainan )
                    {
                        zainanyanse=Color.Red ;
                    }
                    else
                    {
                        zainanyanse=Color.White;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        if (this.mainMapLayer.TileInScreen(point))
                        {
                            if ((point == architecture.zhongxindian || architecture.Scenario.ScenarioMap.UseSimpleArchImages) && (architecture.Kind.ID == 1 || architecture.Kind.ID == 2 ))
                            {
                                spriteBatch.Draw(this.huoqujianzhutupian(architecture), this.mainMapLayer.huoqujianzhujuxing(point, architecture), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                            }

                            if (point == architecture.dingdian  && point.Y>0)
                            {
                                //////////////////////////////////////////////////////////
                                //architecture.jianzhubiaoti.Position = this.mainMapLayer.GetDestination(point);
                                Point pointXiaYige = new Point(point.X, point.Y + 1);
                                Rectangle jianzhubiaotiPosition = this.mainMapLayer.GetDestination(point);
                                //////////architecture.jianzhubiaoti.DisplayOffset = new Point(0, -this.mainMapLayer.TileWidth / 2);
                                //architecture.jianzhubiaoti.Draw(spriteBatch, 0.7999f);

                                if (architecture.CaptionTexture == null)
                                {
                                    try
                                    {
                                        architecture.CaptionTexture = Texture2D.FromFile(this.screen.GraphicsDevice, "Resources/Architecture/Caption/" + architecture.CaptionID + ".png");
                                    }
                                    catch
                                    {
                                        architecture.CaptionTexture = Texture2D.FromFile(this.screen.GraphicsDevice, "Resources/Architecture/Caption/None.png");
                                    }
                                }

                                Rectangle jianzhubiaotibeijingweizhi;
                                jianzhubiaotibeijingweizhi = new Rectangle(jianzhubiaotiPosition.X + this.mainMapLayer.TileWidth / 2 - architecture.CaptionTexture.Width / 2, jianzhubiaotiPosition.Y + this.mainMapLayer.TileHeight / 2 - architecture.CaptionTexture.Height / 2, architecture.CaptionTexture.Width, architecture.CaptionTexture.Height);
                                //spriteBatch.Draw(this.screen.Textures.jianzhubiaotibeijing, jianzhubiaotibeijingweizhi, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.79996f);
                                spriteBatch.Draw(architecture.CaptionTexture , jianzhubiaotibeijingweizhi, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.79996f);

                                if (architecture.BelongedFaction != null && this.mainMapLayer.TileInScreen(architecture.jianzhuqizi.qizipoint))      //不是空城的话绘制旗子
                                {
                                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds; 
                                    if (timeSinceLastFrame > millisecondsPerFrame) 
                                    { 
                                         timeSinceLastFrame-= millisecondsPerFrame; 
                                        ++currentFrame.X;
                                        if (currentFrame.X >= sheetSize.X)
                                        {
                                            currentFrame.X = 0;
                                            //++currentFrame.Y;
                                            //if (currentFrame.Y >= sheetSize.Y)
                                            //    currentFrame.Y = 0;
                                        }
                                    }

                                    spriteBatch.Draw(this.screen.Textures.qizitupian , this.mainMapLayer.GetDestination(architecture.jianzhuqizi.qizipoint), 
                                        new Rectangle(currentFrame.X * frameSize.X,
                                          currentFrame.Y * frameSize.Y,
                                          frameSize.X,
                                          frameSize.Y),
                                    architecture.BelongedFaction.FactionColor, 0, Vector2.Zero, SpriteEffects.None, 0.79998f);

                                    this.screen.qizidezi.Text = architecture.BelongedFaction.ToString().Substring(0, 1);

                                    this.screen.qizidezi.Position = this.mainMapLayer.huoquqizijuxing (architecture.jianzhuqizi.qizipoint);
                                    this.screen.qizidezi.Draw(spriteBatch, 0.7999f, this.screen.qizidezi.Position);

                                    if (architecture.huangdisuozai)
                                    {
                                        spriteBatch.Draw(this.screen.Textures.huangditupian ,
                                            this.mainMapLayer.GetDestination(new Point(architecture.jianzhuqizi.qizipoint.X+1,architecture.jianzhuqizi.qizipoint.Y)),
                                            null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                        

                                    }
                                
                                }
                            } //end      if (point == architecture.ArchitectureArea.TopLeft && point.Y>0)
                            
                            
                            

                            if (architecture.Kind.ID == 2)  //绘制关隘
                            {
                                //spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.8f);
                                /*
                                if (architecture.ArchitectureArea.Area[0].X == architecture.ArchitectureArea.Area[1].X) //忽略了关只有一块的特例，可能产生BUG
                                {

                                    spriteBatch.Draw(gameScenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind(5).Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                }
                                else
                                {
                                    spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                                }
                                */
                            }

                            else if (architecture.Kind.ID != 1 && architecture.Kind.ID != 2) 
                            {
                                if (architecture.Texture == null)
                                {
                                    architecture.Kind.Texture = Texture2D.FromFile(this.screen.GraphicsDevice, "Resources/Architecture/" + architecture.Kind.ID.ToString() + ".png");
                                }
                                spriteBatch.Draw(architecture.Texture, this.mainMapLayer.GetDestination(point), null, zainanyanse, 0, Vector2.Zero, SpriteEffects.None, 0.8f);

                            }
                            
                            if ((GlobalVariables.SkyEye || this.gameScenario.NoCurrentPlayer) || this.gameScenario.CurrentPlayer.IsArchitectureKnown(architecture))
                            {
                                if (!architecture.IncrementNumberList.IsEmpty)
                                {
                                    architecture.IncrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                }
                                if (!architecture.DecrementNumberList.IsEmpty)
                                {
                                    architecture.DecrementNumberList.Draw(this.gameScenario.GameScreen, spriteBatch, this.mainMapLayer.screen.Scenario.GameCommonData.NumberGenerator, new GetDisplayRectangle(this.mainMapLayer.GetDestination), this.mainMapLayer.TileWidth, gameTime);
                                    //sourceRectangle = null;
                                    spriteBatch.Draw(this.mainMapLayer.screen.Textures.TileFrameTextures[2], this.mainMapLayer.GetDestination(point), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.799f);
                                }
                            }
                            else
                            {
                                architecture.IncrementNumberList.Clear();
                                architecture.DecrementNumberList.Clear();
                            }
                        }
                        else
                        {
                            architecture.IncrementNumberList.Clear();
                            architecture.DecrementNumberList.Clear();
                        }
                    }
                }
            }
        }

        private Texture2D huoqujianzhutupian(Architecture architecture)
        {
            Texture2D tupian=architecture.Texture;
            if (architecture.Scenario.ScenarioMap.UseSimpleArchImages)
            {
                return tupian;
            }
            if (architecture.Kind.ID == 1)
            {
                if (architecture.JianzhuGuimo == 13)
                {
                    tupian = this.screen.Textures.chengchitupian[0];
                }
                else if (architecture.JianzhuGuimo == 5)
                {
                    tupian = this.screen.Textures.chengchitupian[1];
                }
                else
                {
                    tupian = architecture.Texture;
                }
            }
            else if (architecture.Kind.ID == 2)
            {
                if (architecture.JianzhuGuimo == 1)
                {
                    tupian = architecture.Texture;
                }
                else if (architecture.JianzhuGuimo == 3)//小关
                {
                    if (architecture.ArchitectureArea.Area[0].X == architecture.ArchitectureArea.Area[1].X) //竖关
                    {

                        tupian = this.screen.Textures.guandetupian[1];
                    }
                    else //横关
                    {

                        tupian = this.screen.Textures.guandetupian[0];
                    }
                }
                else if (architecture.JianzhuGuimo == 5)//大关
                {
                    if (architecture.ArchitectureArea.Area[0].X == architecture.ArchitectureArea.Area[1].X) //竖关
                    {
                        tupian = this.screen.Textures.guandetupian[2];

                    }
                    else //横关
                    {
                        tupian = architecture.Texture;

                    }

                }

            }//end if (architecture.Kind.ID == 1)
            return tupian;
        }





        public void Initialize(MainMapLayer mainMapLayer, GameScenario scenario,MainGameScreen mainGameScreen)
        {
            this.screen  = mainGameScreen;
            this.mainMapLayer = mainMapLayer;
            this.Architectures = scenario.Architectures;
            this.gameScenario = scenario;
            
        }
    }

 

}
