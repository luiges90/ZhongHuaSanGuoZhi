namespace PersonDetailPlugin
{
    using GameFreeText;
    using GameGlobal;
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using GameObjects.PersonDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;

    internal class PersonDetail
    {
        internal FreeTextList AllSkillTexts;
        internal Point BackgroundSize;
        internal Texture2D BackgroundTexture;
     
        internal Texture2D TitleButtonTexture;
        internal Texture2D SkillButtonTexture;
        internal Texture2D StuntButtonTexture;
        internal Texture2D TreasureButtonTexture;
        internal Texture2D BiographyButtonTexture;
        internal Texture2D TitleButtonPressedTexture;
        internal Texture2D SkillButtonPressedTexture;
        internal Texture2D StuntButtonPressedTexture;
        internal Texture2D TreasureButtonPressedTexture;
        internal Texture2D BiographyButtonPressedTexture;
        internal Texture2D TitleBackgroundTexture;
        internal Texture2D SkillBackgroundTexture;
        internal Texture2D StuntBackgroundTexture;
        internal Texture2D TreasureBackgroundTexture;
        internal Texture2D BiographyBackgroundTexture;
        internal Rectangle TitleButtonClient;
        internal Rectangle SkillButtonClient;
        internal Rectangle StuntButtonClient;
        internal Rectangle TreasureButtonClient;
        internal Rectangle BiographyButtonClient;
        internal Rectangle TitleButtonPressedClient;
        internal Rectangle SkillButtonPressedClient;
        internal Rectangle StuntButtonPressedClient;
        internal Rectangle TreasureButtonPressedClient;
        internal Rectangle BiographyButtonPressedClient;
        internal Rectangle TitleBackgroundClient;
        internal Rectangle SkillBackgroundClient;
        internal Rectangle StuntBackgroundClient;
        internal Rectangle TreasureBackgroundClient;
        internal Rectangle BiographyBackgroundClient;
         
        internal Rectangle BiographyClient;
        internal FreeRichText BiographyText = new FreeRichText();
        internal FreeText CalledNameText;
        internal Rectangle ConditionClient;
        internal FreeRichText ConditionText = new FreeRichText();
        private object current;
        private Point DisplayOffset;
        internal FreeText GivenNameText;
        internal Rectangle InfluenceClient;
        internal FreeRichText InfluenceText = new FreeRichText();
        private bool isShowing;
        internal List<LabelText> LabelTexts = new List<LabelText>();
        internal FreeTextList LearnableSkillTexts;
        internal List<Skill> LinkedSkills = new List<Skill>();
        internal Rectangle TitleClient;
       // internal Rectangle GuanzhiClient; //官职
        //internal FreeRichText GuanzhiText = new FreeRichText();
        internal FreeRichText TitleText = new FreeRichText();
        internal FreeTextList PersonSkillTexts;
        internal Rectangle PortraitClient;
        internal Screen screen;
        internal Person ShowingPerson;
        internal Point SkillBlockSize;
        internal Point SkillDisplayOffset;
        internal Rectangle StuntClient;
        internal FreeRichText StuntText = new FreeRichText();
        internal FreeText SurNameText;
        //下面是添加的内容
        bool TitleButton = false;
        bool SkillButton = true;
        bool StuntButton = false;
        bool TreasureButton = false;
        bool BiographyButton = false;
        //上面是添加的内容
        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.ShowingPerson != null)
            {
                Rectangle? sourceRectangle = null;
                spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.19f);
                try
                {
                    spriteBatch.Draw(this.ShowingPerson.Portrait, this.PortraitDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.18f);

                 if (TitleButton == true && SkillButton == false && StuntButton == false && TreasureButton == false && BiographyButton == false)
                    {
                        spriteBatch.Draw(this.TitleButtonTexture, this.TitleButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.SkillButtonTexture, this.SkillButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.StuntButtonTexture, this.StuntButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TreasureButtonTexture, this.TreasureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.BiographyButtonTexture, this.BiographyButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TitleButtonPressedTexture, this.TitleButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.SkillButtonPressedTexture, this.SkillButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.StuntButtonPressedTexture, this.StuntButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TreasureButtonPressedTexture, this.TreasureButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.BiographyButtonPressedTexture, this.BiographyButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TitleBackgroundTexture, this.TitleBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.187f);
                        spriteBatch.Draw(this.SkillBackgroundTexture, this.SkillBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.StuntBackgroundTexture, this.StuntBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.TreasureBackgroundTexture, this.TreasureBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.BiographyBackgroundTexture, this.BiographyBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        this.TitleText.Draw(spriteBatch, 0.185f);
                        this.AllSkillTexts.Draw(spriteBatch, (float)0.189f);
                        this.PersonSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.LearnableSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.StuntText.Draw(spriteBatch, 0.189f);
                        this.InfluenceText.Draw(spriteBatch, 0.185f);
                        this.ConditionText.Draw(spriteBatch, 0.185f);
                        this.BiographyText.Draw(spriteBatch, 0.189f);
                    }
                    else if (TitleButton == false && SkillButton == true && StuntButton == false && TreasureButton == false && BiographyButton == false)
                    {
                        spriteBatch.Draw(this.TitleButtonTexture, this.TitleButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.SkillButtonTexture, this.SkillButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.StuntButtonTexture, this.StuntButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TreasureButtonTexture, this.TreasureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.BiographyButtonTexture, this.BiographyButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TitleButtonPressedTexture, this.TitleButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.SkillButtonPressedTexture, this.SkillButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.StuntButtonPressedTexture, this.StuntButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TreasureButtonPressedTexture, this.TreasureButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.BiographyButtonPressedTexture, this.BiographyButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TitleBackgroundTexture, this.TitleBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.SkillBackgroundTexture, this.SkillBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.187f);
                        spriteBatch.Draw(this.StuntBackgroundTexture, this.StuntBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.TreasureBackgroundTexture, this.TreasureBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.BiographyBackgroundTexture, this.BiographyBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        this.TitleText.Draw(spriteBatch, 0.189f);
                        this.AllSkillTexts.Draw(spriteBatch, (float)0.185f);
                        this.PersonSkillTexts.Draw(spriteBatch, (float)0.184f);
                        this.LearnableSkillTexts.Draw(spriteBatch, (float)0.184f);
                        this.StuntText.Draw(spriteBatch, 0.189f);
                        this.InfluenceText.Draw(spriteBatch, 0.185f);
                        this.ConditionText.Draw(spriteBatch, 0.185f);
                        this.BiographyText.Draw(spriteBatch, 0.189f);
                    }
                    else if (TitleButton == false && SkillButton == false && StuntButton == true && TreasureButton == false && BiographyButton == false)
                    {
                        spriteBatch.Draw(this.TitleButtonTexture, this.TitleButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.SkillButtonTexture, this.SkillButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.StuntButtonTexture, this.StuntButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TreasureButtonTexture, this.TreasureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.BiographyButtonTexture, this.BiographyButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TitleButtonPressedTexture, this.TitleButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.SkillButtonPressedTexture, this.SkillButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.StuntButtonPressedTexture, this.StuntButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TreasureButtonPressedTexture, this.TreasureButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.BiographyButtonPressedTexture, this.BiographyButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TitleBackgroundTexture, this.TitleBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.SkillBackgroundTexture, this.SkillBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.StuntBackgroundTexture, this.StuntBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.187f);
                        spriteBatch.Draw(this.TreasureBackgroundTexture, this.TreasureBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.BiographyBackgroundTexture, this.BiographyBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        this.TitleText.Draw(spriteBatch, 0.189f);
                        this.AllSkillTexts.Draw(spriteBatch, (float)0.189f);
                        this.PersonSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.LearnableSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.StuntText.Draw(spriteBatch, 0.185f);
                        this.InfluenceText.Draw(spriteBatch, 0.185f);
                        this.ConditionText.Draw(spriteBatch, 0.185f);
                        this.BiographyText.Draw(spriteBatch, 0.189f);
                    }
                    else if (TitleButton == false && SkillButton == false && StuntButton == false && TreasureButton == true && BiographyButton == false)
                    {
                        spriteBatch.Draw(this.TitleButtonTexture, this.TitleButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.SkillButtonTexture, this.SkillButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.StuntButtonTexture, this.StuntButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TreasureButtonTexture, this.TreasureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.BiographyButtonTexture, this.BiographyButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TitleButtonPressedTexture, this.TitleButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.SkillButtonPressedTexture, this.SkillButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.StuntButtonPressedTexture, this.StuntButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TreasureButtonPressedTexture, this.TreasureButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.BiographyButtonPressedTexture, this.BiographyButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TitleBackgroundTexture, this.TitleBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.SkillBackgroundTexture, this.SkillBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.StuntBackgroundTexture, this.StuntBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.TreasureBackgroundTexture, this.TreasureBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.187f);
                        spriteBatch.Draw(this.BiographyBackgroundTexture, this.BiographyBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        this.TitleText.Draw(spriteBatch, 0.189f);
                        this.AllSkillTexts.Draw(spriteBatch, (float)0.189f);
                        this.PersonSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.LearnableSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.StuntText.Draw(spriteBatch, 0.189f);
                        this.InfluenceText.Draw(spriteBatch, 0.189f);
                        this.ConditionText.Draw(spriteBatch, 0.189f);
                        this.BiographyText.Draw(spriteBatch, 0.189f);
                    }
                    else if (TitleButton == false && SkillButton == false && StuntButton == false && TreasureButton == false && BiographyButton == true)
                    {
                        spriteBatch.Draw(this.TitleButtonTexture, this.TitleButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.SkillButtonTexture, this.SkillButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.StuntButtonTexture, this.StuntButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TreasureButtonTexture, this.TreasureButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.BiographyButtonTexture, this.BiographyButtonDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TitleButtonPressedTexture, this.TitleButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.SkillButtonPressedTexture, this.SkillButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.StuntButtonPressedTexture, this.StuntButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.TreasureButtonPressedTexture, this.TreasureButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.186f);
                        spriteBatch.Draw(this.BiographyButtonPressedTexture, this.BiographyButtonPressedDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.184f);
                        spriteBatch.Draw(this.TitleBackgroundTexture, this.TitleBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.SkillBackgroundTexture, this.SkillBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.StuntBackgroundTexture, this.StuntBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.TreasureBackgroundTexture, this.TreasureBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.188f);
                        spriteBatch.Draw(this.BiographyBackgroundTexture, this.BiographyBackgroundDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.187f);
                        this.TitleText.Draw(spriteBatch, 0.189f);
                        this.AllSkillTexts.Draw(spriteBatch, (float)0.189f);
                        this.PersonSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.LearnableSkillTexts.Draw(spriteBatch, (float)0.188f);
                        this.StuntText.Draw(spriteBatch, 0.189f);
                        this.InfluenceText.Draw(spriteBatch, 0.189f);
                        this.ConditionText.Draw(spriteBatch, 0.189f);
                        this.BiographyText.Draw(spriteBatch, 0.185f);
                    }
                    
                }
                catch
                {
                }
                this.SurNameText.Draw(spriteBatch, 0.18f);
                this.GivenNameText.Draw(spriteBatch, 0.18f);
                this.CalledNameText.Draw(spriteBatch, 0.18f);
                foreach (LabelText text in this.LabelTexts)
                {
                    text.Label.Draw(spriteBatch, 0.18f);
                    text.Text.Draw(spriteBatch, 0.18f);
                }
                
                /*this.TitleText.Draw(spriteBatch, 0.1999f);
                //this.GuanzhiText.Draw(spriteBatch, 0.1999f);
                this.AllSkillTexts.Draw(spriteBatch, (float) 0.1999f);
                this.PersonSkillTexts.Draw(spriteBatch, (float) 0.1998f);
                this.LearnableSkillTexts.Draw(spriteBatch, (float) 0.1998f);
                this.StuntText.Draw(spriteBatch, 0.1999f);
                this.InfluenceText.Draw(spriteBatch, 0.1999f);
                this.ConditionText.Draw(spriteBatch, 0.1999f);
                this.BiographyText.Draw(spriteBatch, 0.1999f);
                */
            }
        }

        internal void Initialize(Screen screen)
        {
            this.screen = screen;
        }

        private void screen_OnMouseLeftDown(Point position)
        {
            if (StaticMethods.PointInRectangle(position, new Rectangle(this.BiographyText.DisplayOffset.X, this.BiographyText.DisplayOffset.Y, this.BiographyClient.Width, this.BiographyClient.Height)))
            {
                if (this.BiographyText.CurrentPageIndex < (this.BiographyText.PageCount - 1))
                {
                    this.BiographyText.NextPage();
                }
                else if (this.BiographyText.CurrentPageIndex == (this.BiographyText.PageCount - 1))
                {
                    this.BiographyText.FirstPage();
                }
            }
            if (TitleButton == false && StaticMethods.PointInRectangle(position, new Rectangle(this.TitleButtonClient.X + this.DisplayOffset.X, this.TitleButtonClient.Y + this.DisplayOffset.Y, this.TitleButtonClient.Width, this.TitleButtonClient.Height)))
            {
                TitleButton = true;
                SkillButton = false;
                StuntButton = false;
                TreasureButton = false;
                BiographyButton = false;
            }
            if (SkillButton == false && StaticMethods.PointInRectangle(position, new Rectangle(this.SkillButtonClient.X + this.DisplayOffset.X, this.SkillButtonClient.Y + this.DisplayOffset.Y, this.SkillButtonClient.Width, this.SkillButtonClient.Height)))
            {
                TitleButton = false;
                SkillButton = true;
                StuntButton = false;
                TreasureButton = false;
                BiographyButton = false;
            }
            if (StuntButton == false && StaticMethods.PointInRectangle(position, new Rectangle(this.StuntButtonClient.X + this.DisplayOffset.X, this.StuntButtonClient.Y + this.DisplayOffset.Y, this.StuntButtonClient.Width, this.StuntButtonClient.Height)))
            {
                TitleButton = false;
                SkillButton = false;
                StuntButton = true;
                TreasureButton = false;
                BiographyButton = false;
            }
            if (TreasureButton == false && StaticMethods.PointInRectangle(position, new Rectangle(this.TreasureButtonClient.X + this.DisplayOffset.X, this.TreasureButtonClient.Y + this.DisplayOffset.Y, this.TreasureButtonClient.Width, this.TreasureButtonClient.Height)))
            {
                TitleButton = false;
                SkillButton = false;
                StuntButton = false;
                TreasureButton = true;
                BiographyButton = false;
            }
            if (BiographyButton == false && StaticMethods.PointInRectangle(position, new Rectangle(this.BiographyButtonClient.X + this.DisplayOffset.X, this.BiographyButtonClient.Y + this.DisplayOffset.Y, this.BiographyButtonClient.Width, this.BiographyButtonClient.Height)))
            {
                TitleButton = false;
                SkillButton = false;
                StuntButton = false;
                TreasureButton = false;
                BiographyButton = true;
            }

        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            bool flag = false;
            if (TitleButton == true && StaticMethods.PointInRectangle(position, this.TitleDisplayPosition))
            {
                int num2 = (position.Y - this.TitleText.DisplayOffset.Y) / this.TitleText.RowHeight;
                if (num2 >= 0)
                {
                    int num3 = num2;
                    if (this.ShowingPerson.Titles.Count > num3)
                    {
                        Title title = this.ShowingPerson.Titles[num3] as Title;
                        if (title != null)
                        {
                            if (this.current != title)
                            {
                                //this.BiographyText.Clear();
                                this.InfluenceText.Clear();
                                this.InfluenceText.AddText(title.DetailedName, this.InfluenceText.TitleColor);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in title.Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("修习条件", this.ConditionText.TitleColor);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in title.Conditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                foreach (Condition condition in title.ArchitectureConditions.Conditions.Values)
                                {
                                    if (this.ShowingPerson.LocationArchitecture != null && condition.CheckCondition(this.ShowingPerson.LocationArchitecture))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                foreach (Condition condition in title.FactionConditions.Conditions.Values)
                                {
                                    if (this.ShowingPerson.BelongedFaction != null && condition.CheckCondition(this.ShowingPerson.BelongedFaction))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                               
                                this.ConditionText.ResortTexts();
                                this.current = title;
                            }
                            flag = true;
                        }
                    }
                }
            }
           /* if (!flag && StaticMethods.PointInRectangle(position, this.GuanzhiDisplayPosition))
            {
                int num2 = (position.Y - this.GuanzhiText.DisplayOffset.Y / this.GuanzhiText.RowHeight);
                if (num2 > 1)
                {
                    int num3 = num2 - 2;
                    if (this.ShowingPerson.Guanzhis.Count > num3)
                    {
                        Guanzhi guanzhi = this.ShowingPerson.Guanzhis[num3] as Guanzhi;
                        if (guanzhi != null)
                        {
                            if (this.current != guanzhi)
                            {
                                this.BiographyText.Clear();
                                this.InfluenceText.Clear();
                                this.InfluenceText.AddText(guanzhi.DetailedName, this.InfluenceText.TitleColor);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in guanzhi.Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("授予条件", this.ConditionText.TitleColor);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in guanzhi.Conditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                foreach (Condition condition in guanzhi.LoseConditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                foreach (Condition condition in guanzhi.FactionConditions.Conditions.Values)
                                {
                                    if (this.ShowingPerson.BelongedFaction != null && condition.CheckCondition(this.ShowingPerson.BelongedFaction))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }

                                this.ConditionText.ResortTexts();
                                this.current = guanzhi;
                            }
                            flag = true;
                        }
                    }
                }
            }*/

            if (StuntButton == true && StaticMethods.PointInRectangle(position, this.StuntDisplayPosition))
            {
                int num2 = (position.Y - this.StuntText.DisplayOffset.Y) / this.StuntText.RowHeight;
                if (num2 > 1)
                {
                    int num3 = num2 - 2;
                    if (this.ShowingPerson.Stunts.Count > num3)
                    {
                        Stunt stunt = this.ShowingPerson.Stunts.GetStuntList()[num3] as Stunt;
                        if (stunt != null)
                        {
                            if (this.current != stunt)
                            {
                                //this.BiographyText.Clear();
                                this.InfluenceText.Clear();
                                this.InfluenceText.AddText("战斗特技", this.InfluenceText.TitleColor);
                                this.InfluenceText.AddText(stunt.Name, this.InfluenceText.SubTitleColor);
                                this.InfluenceText.AddNewLine();
                                this.InfluenceText.AddText("持续天数", this.InfluenceText.SubTitleColor2);
                                this.InfluenceText.AddText(stunt.Period.ToString(), this.InfluenceText.SubTitleColor3);
                                this.InfluenceText.AddText("天", this.InfluenceText.SubTitleColor2);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in stunt.Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("使用条件", this.ConditionText.TitleColor);
                                this.ConditionText.AddNewLine();
                                if ((this.ShowingPerson.LocationTroop != null) && (this.ShowingPerson == this.ShowingPerson.LocationTroop.Leader))
                                {
                                    foreach (Condition condition in stunt.CastConditions.Conditions.Values)
                                    {
                                        if (condition.CheckCondition(this.ShowingPerson.LocationTroop))
                                        {
                                            this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                        }
                                        else
                                        {
                                            this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                        }
                                        this.ConditionText.AddNewLine();
                                    }
                                }
                                else
                                {
                                    foreach (Condition condition in stunt.CastConditions.Conditions.Values)
                                    {
                                        this.ConditionText.AddText(condition.Name);
                                        this.ConditionText.AddNewLine();
                                    }
                                }
                                this.ConditionText.AddNewLine();
                                this.ConditionText.AddText("修习条件", this.ConditionText.SubTitleColor);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in stunt.LearnConditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                this.ConditionText.ResortTexts();
                                this.current = stunt;
                            }
                            flag = true;
                        }
                    }
                }
            }
            if (!flag)
            {
                for (int i = 0; i < this.AllSkillTexts.Count; i++)
                {
                    if (SkillButton == true && StaticMethods.PointInRectangle(position, this.AllSkillTexts[i].AlignedPosition))
                    {
                        if (this.current != this.LinkedSkills[i])
                        {
                            //this.BiographyText.Clear();
                            this.InfluenceText.Clear();
                            if (this.LinkedSkills[i].InfluenceCount > 0)
                            {
                                this.InfluenceText.AddText("技能", this.InfluenceText.TitleColor);
                                this.InfluenceText.AddText(this.LinkedSkills[i].Name, this.InfluenceText.SubTitleColor);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in this.LinkedSkills[i].Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("修习条件", this.ConditionText.TitleColor);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in this.LinkedSkills[i].Conditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.PositiveColor);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, this.ConditionText.NegativeColor);
                                    }
                                    this.ConditionText.AddNewLine();
                                }
                                this.ConditionText.ResortTexts();
                            }
                            this.current = this.LinkedSkills[i];
                        }
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag)
            {
                if (this.current != null)
                {
                    this.current = null;
                    this.InfluenceText.Clear();
                    this.ConditionText.Clear();
                    if (this.ShowingPerson.PersonBiography != null)
                    {
                        this.BiographyText.Clear();
                        this.BiographyText.AddText("列传", this.BiographyText.TitleColor);
                        this.BiographyText.AddNewLine();
                        this.BiographyText.AddText(this.ShowingPerson.PersonBiography.Brief);
                        this.BiographyText.AddNewLine();
                        this.BiographyText.AddText("演义", this.BiographyText.SubTitleColor);
                        this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.Romance);
                        this.BiographyText.AddNewLine();
                        this.BiographyText.AddText("历史", this.BiographyText.SubTitleColor2);
                        this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.History);
                        this.BiographyText.AddNewLine();
                        this.BiographyText.AddText("剧本", Color.Cyan);
                        this.BiographyText.AddText("：");
                        String[] lineBrokenText = ShowingPerson.PersonBiography.InGame.Split('\n');
                        foreach (String s in lineBrokenText)
                        {
                            this.BiographyText.AddText(s);
                            this.BiographyText.AddNewLine();
                        }
                        this.BiographyText.ResortTexts();
                    }
                }
            }
        }

        private void screen_OnMouseRightUp(Point position)
        {
            TitleButton = false;
            SkillButton = true;
            StuntButton = false;
            TreasureButton = false;
            BiographyButton = false;
            this.IsShowing = false;
        }

        internal void SetPerson(Person person)
        {
            this.PersonSkillTexts.SimpleClear();
            this.LearnableSkillTexts.SimpleClear();
            foreach (Skill skill in this.screen.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                Rectangle position = new Rectangle(this.SkillDisplayOffset.X + (skill.DisplayCol * this.SkillBlockSize.X), this.SkillDisplayOffset.Y + (skill.DisplayRow * this.SkillBlockSize.Y), this.SkillBlockSize.X, this.SkillBlockSize.Y);
                if (person.Skills.GetSkill(skill.ID) != null)
                {
                    this.PersonSkillTexts.AddText(skill.Name, position);
                }
                else if (skill.CanLearn(person))
                {
                    this.LearnableSkillTexts.AddText(skill.Name, position);
                }
                this.AllSkillTexts.AddText(skill.Name, position);
                this.LinkedSkills.Add(skill);
            }
            this.AllSkillTexts.ResetAllTextTextures();
            this.AllSkillTexts.ResetAllAlignedPositions();
            this.PersonSkillTexts.ResetAllTextTextures();
            this.PersonSkillTexts.ResetAllAlignedPositions();
            this.LearnableSkillTexts.ResetAllTextTextures();
            this.LearnableSkillTexts.ResetAllAlignedPositions();

            this.ShowingPerson = person;
            this.SurNameText.Text = person.SurName;
            this.GivenNameText.Text = person.GivenName;
            this.CalledNameText.Text = person.CalledName;
            foreach (LabelText text in this.LabelTexts)
            {
                text.Text.Text = StaticMethods.GetPropertyValue(person, text.PropertyName).ToString();
            }
            this.TitleText.Clear();
            foreach (Title title in person.Titles)
            {
                this.TitleText.AddText(title.DetailedName, Color.Lime);
                this.TitleText.AddNewLine();
            }
            this.TitleText.ResortTexts();
           // this.GuanzhiText.Clear();
           /* foreach (Guanzhi guanzhi in person.Guanzhis)
            {
                this.GuanzhiText.AddText(guanzhi.DetailedName, Color.Lime);
                this.GuanzhiText.AddNewLine();
            }
            this.GuanzhiText.ResortTexts();
            */
           
            this.StuntText.Clear();
            this.StuntText.AddText("战斗特技", Color.Yellow);
            this.StuntText.AddNewLine();
            this.StuntText.AddText(person.Stunts.Count.ToString() + "种", Color.Lime);
            this.StuntText.AddNewLine();
            foreach (Stunt stunt in person.Stunts.Stunts.Values)
            {
                this.StuntText.AddText(stunt.Name, Color.Red);
                this.StuntText.AddText(" 战意消耗" + stunt.Combativity.ToString(), Color.LightGreen);
                this.StuntText.AddNewLine();
            }
            this.StuntText.ResortTexts();
            this.BiographyText.Clear();
            if (person.PersonBiography != null)
            {
                this.BiographyText.Clear();
                this.BiographyText.AddText("列传", this.BiographyText.TitleColor);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText(this.ShowingPerson.PersonBiography.Brief);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText("演义", this.BiographyText.SubTitleColor);
                this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.Romance);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText("历史", this.BiographyText.SubTitleColor2);
                this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.History);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText("剧本", Color.Cyan);
                this.BiographyText.AddText("：");
                String[] lineBrokenText = ShowingPerson.PersonBiography.InGame.Split('\n');
                foreach (String s in lineBrokenText)
                {
                    this.BiographyText.AddText(s);
                    this.BiographyText.AddNewLine();
                }
                this.BiographyText.ResortTexts();
            }
        }

        internal void SetPosition(ShowPosition showPosition)
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
            this.SurNameText.DisplayOffset = this.DisplayOffset;
            this.GivenNameText.DisplayOffset = this.DisplayOffset;
            this.CalledNameText.DisplayOffset = this.DisplayOffset;
            foreach (LabelText text in this.LabelTexts)
            {
                text.Label.DisplayOffset = this.DisplayOffset;
                text.Text.DisplayOffset = this.DisplayOffset;
            }
            this.TitleText.DisplayOffset = new Point(this.DisplayOffset.X + this.TitleClient.X, this.DisplayOffset.Y + this.TitleClient.Y);
           // this.GuanzhiText.DisplayOffset = new Point(this.DisplayOffset.X + this.GuanzhiClient.X, this.DisplayOffset.Y + this.GuanzhiClient.Y);
            this.AllSkillTexts.DisplayOffset = this.DisplayOffset;
            this.PersonSkillTexts.DisplayOffset = this.DisplayOffset;
            this.LearnableSkillTexts.DisplayOffset = this.DisplayOffset;
            this.StuntText.DisplayOffset = new Point(this.DisplayOffset.X + this.StuntClient.X, this.DisplayOffset.Y + this.StuntClient.Y);
            this.InfluenceText.DisplayOffset = new Point(this.DisplayOffset.X + this.InfluenceClient.X, this.DisplayOffset.Y + this.InfluenceClient.Y);
            this.ConditionText.DisplayOffset = new Point(this.DisplayOffset.X + this.ConditionClient.X, this.DisplayOffset.Y + this.ConditionClient.Y);
            this.BiographyText.DisplayOffset = new Point(this.DisplayOffset.X + this.BiographyClient.X, this.DisplayOffset.Y + this.BiographyClient.Y);
        }

        private Rectangle BackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.DisplayOffset.X, this.DisplayOffset.Y, this.BackgroundSize.X, this.BackgroundSize.Y);
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
                    this.screen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.SubDialog, DialogKind.PersonDetail));
                    this.screen.OnMouseMove += new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown += new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp += new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                }
                else
                {
                    if (this.screen.PopUndoneWork().Kind != UndoneWorkKind.SubDialog)
                    {
                        throw new Exception("The UndoneWork is not a SubDialog.");
                    }
                    this.screen.OnMouseMove -= new Screen.MouseMove(this.screen_OnMouseMove);
                    this.screen.OnMouseLeftDown -= new Screen.MouseLeftDown(this.screen_OnMouseLeftDown);
                    this.screen.OnMouseRightUp -= new Screen.MouseRightUp(this.screen_OnMouseRightUp);
                    this.current = null;
                    this.InfluenceText.Clear();
                    this.ConditionText.Clear();
                }
            }
        }

        private Rectangle PortraitDisplayPosition
        {
            get
            {
                return new Rectangle(this.PortraitClient.X + this.DisplayOffset.X, this.PortraitClient.Y + this.DisplayOffset.Y, this.PortraitClient.Width, this.PortraitClient.Height);
            }
        }
          
        private Rectangle TitleButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.TitleButtonClient.X + this.DisplayOffset.X, this.TitleButtonClient.Y + this.DisplayOffset.Y, this.TitleButtonClient.Width, this.TitleButtonClient.Height);
            }
        }
        private Rectangle SkillButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.SkillButtonClient.X + this.DisplayOffset.X, this.SkillButtonClient.Y + this.DisplayOffset.Y, this.SkillButtonClient.Width, this.SkillButtonClient.Height);
            }
        }
        private Rectangle StuntButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.StuntButtonClient.X + this.DisplayOffset.X, this.StuntButtonClient.Y + this.DisplayOffset.Y, this.StuntButtonClient.Width, this.StuntButtonClient.Height);
            }
        }
        private Rectangle TreasureButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.TreasureButtonClient.X + this.DisplayOffset.X, this.TreasureButtonClient.Y + this.DisplayOffset.Y, this.TreasureButtonClient.Width, this.TreasureButtonClient.Height);
            }
        }
        private Rectangle BiographyButtonDisplayPosition
        {
            get
            {
                return new Rectangle(this.BiographyButtonClient.X + this.DisplayOffset.X, this.BiographyButtonClient.Y + this.DisplayOffset.Y, this.BiographyButtonClient.Width, this.BiographyButtonClient.Height);
            }
        }
        private Rectangle TitleButtonPressedDisplayPosition
        {
            get
            {
                return new Rectangle(this.TitleButtonPressedClient.X + this.DisplayOffset.X, this.TitleButtonPressedClient.Y + this.DisplayOffset.Y, this.TitleButtonPressedClient.Width, this.TitleButtonPressedClient.Height);
            }
        }
        private Rectangle SkillButtonPressedDisplayPosition
        {
            get
            {
                return new Rectangle(this.SkillButtonPressedClient.X + this.DisplayOffset.X, this.SkillButtonPressedClient.Y + this.DisplayOffset.Y, this.SkillButtonPressedClient.Width, this.SkillButtonPressedClient.Height);
            }
        }
        private Rectangle StuntButtonPressedDisplayPosition
        {
            get
            {
                return new Rectangle(this.StuntButtonPressedClient.X + this.DisplayOffset.X, this.StuntButtonPressedClient.Y + this.DisplayOffset.Y, this.StuntButtonPressedClient.Width, this.StuntButtonPressedClient.Height);
            }
        }
        private Rectangle TreasureButtonPressedDisplayPosition
        {
            get
            {
                return new Rectangle(this.TreasureButtonPressedClient.X + this.DisplayOffset.X, this.TreasureButtonPressedClient.Y + this.DisplayOffset.Y, this.TreasureButtonPressedClient.Width, this.TreasureButtonPressedClient.Height);
            }
        }
        private Rectangle BiographyButtonPressedDisplayPosition
        {
            get
            {
                return new Rectangle(this.BiographyButtonPressedClient.X + this.DisplayOffset.X, this.BiographyButtonPressedClient.Y + this.DisplayOffset.Y, this.BiographyButtonPressedClient.Width, this.BiographyButtonPressedClient.Height);
            }
        }
        private Rectangle TitleBackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.TitleBackgroundClient.X + this.DisplayOffset.X, this.TitleBackgroundClient.Y + this.DisplayOffset.Y, this.TitleBackgroundClient.Width, this.TitleBackgroundClient.Height);
            }
        }
        private Rectangle SkillBackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.SkillBackgroundClient.X + this.DisplayOffset.X, this.SkillBackgroundClient.Y + this.DisplayOffset.Y, this.SkillBackgroundClient.Width, this.SkillBackgroundClient.Height);
            }
        }
        private Rectangle StuntBackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.StuntBackgroundClient.X + this.DisplayOffset.X, this.StuntBackgroundClient.Y + this.DisplayOffset.Y, this.StuntBackgroundClient.Width, this.StuntBackgroundClient.Height);
            }
        }
        private Rectangle TreasureBackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.TreasureBackgroundClient.X + this.DisplayOffset.X, this.TreasureBackgroundClient.Y + this.DisplayOffset.Y, this.TreasureBackgroundClient.Width, this.TreasureBackgroundClient.Height);
            }
        }
        private Rectangle BiographyBackgroundDisplayPosition
        {
            get
            {
                return new Rectangle(this.BiographyBackgroundClient.X + this.DisplayOffset.X, this.BiographyBackgroundClient.Y + this.DisplayOffset.Y, this.BiographyBackgroundClient.Width, this.BiographyBackgroundClient.Height);
            }
        }

        private Rectangle TitleDisplayPosition
        {
            get
            {
                return new Rectangle(this.TitleText.DisplayOffset.X, this.TitleText.DisplayOffset.Y, this.TitleText.ClientWidth, this.TitleText.ClientHeight);
            }
        }
        /*
        private Rectangle GuanzhiDisplayPosition
        {
            get
            {
                return new Rectangle(this.GuanzhiText.DisplayOffset.X, this.GuanzhiText.DisplayOffset.Y, this.GuanzhiText.ClientWidth, this.GuanzhiText.ClientHeight);
            }
        }
        */
        private Rectangle StuntDisplayPosition
        {
            get
            {
                return new Rectangle(this.StuntText.DisplayOffset.X, this.StuntText.DisplayOffset.Y, this.StuntText.ClientWidth, this.StuntText.ClientHeight);
            }
        }
    }
}

