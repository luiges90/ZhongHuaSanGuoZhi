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
        internal Rectangle BiographyClient;
        internal FreeRichText BiographyText = new FreeRichText();
        internal FreeText CalledNameText;
        internal LabelText CombatTitleLabelText = new LabelText();
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
        internal LabelText PersonalTitleLabelText = new LabelText();
        internal FreeTextList PersonSkillTexts;
        internal Rectangle PortraitClient;
        internal Screen screen;
        internal Person ShowingPerson;
        internal Point SkillBlockSize;
        internal Point SkillDisplayOffset;
        internal Rectangle StuntClient;
        internal FreeRichText StuntText = new FreeRichText();
        internal FreeText SurNameText;

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (this.ShowingPerson != null)
            {
                Rectangle? sourceRectangle = null;
                spriteBatch.Draw(this.BackgroundTexture, this.BackgroundDisplayPosition, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
                try
                {
                    spriteBatch.Draw(this.ShowingPerson.Portrait, this.PortraitDisplayPosition, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.199f);
                }
                catch
                {
                }
                this.SurNameText.Draw(spriteBatch, 0.1999f);
                this.GivenNameText.Draw(spriteBatch, 0.1999f);
                this.CalledNameText.Draw(spriteBatch, 0.1999f);
                foreach (LabelText text in this.LabelTexts)
                {
                    text.Label.Draw(spriteBatch, 0.1999f);
                    text.Text.Draw(spriteBatch, 0.1999f);
                }
                this.PersonalTitleLabelText.Label.Draw(spriteBatch, 0.1999f);
                this.PersonalTitleLabelText.Text.Draw(spriteBatch, 0.1999f);
                this.CombatTitleLabelText.Label.Draw(spriteBatch, 0.1999f);
                this.CombatTitleLabelText.Text.Draw(spriteBatch, 0.1999f);
                this.AllSkillTexts.Draw(spriteBatch, (float) 0.1999f);
                this.PersonSkillTexts.Draw(spriteBatch, (float) 0.1998f);
                this.LearnableSkillTexts.Draw(spriteBatch, (float) 0.1998f);
                this.StuntText.Draw(spriteBatch, 0.1999f);
                this.InfluenceText.Draw(spriteBatch, 0.1999f);
                this.ConditionText.Draw(spriteBatch, 0.1999f);
                this.BiographyText.Draw(spriteBatch, 0.1999f);
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
        }

        private void screen_OnMouseMove(Point position, bool leftDown)
        {
            bool flag = false;
            if ((!flag && (this.ShowingPerson.PersonalTitle != null)) && StaticMethods.PointInRectangle(position, this.PersonalTitleLabelText.Text.AlignedPosition))
            {
                if (this.current != this.ShowingPerson.PersonalTitle)
                {
                    this.InfluenceText.Clear();
                    if (this.ShowingPerson.PersonalTitle.InfluenceCount > 0)
                    {
                        this.InfluenceText.AddText("个人称号", Color.Yellow);
                        this.InfluenceText.AddText(this.ShowingPerson.PersonalTitleString, Color.Lime);
                        this.InfluenceText.AddNewLine();
                        foreach (Influence influence in this.ShowingPerson.PersonalTitle.Influences.Influences.Values)
                        {
                            this.InfluenceText.AddText(influence.Description);
                            this.InfluenceText.AddNewLine();
                        }
                        this.InfluenceText.ResortTexts();
                        this.ConditionText.Clear();
                        this.ConditionText.AddText("修习条件", Color.LightPink);
                        this.ConditionText.AddNewLine();
                        foreach (Condition condition in this.ShowingPerson.PersonalTitle.Conditions.Conditions.Values)
                        {
                            if (condition.CheckCondition(this.ShowingPerson))
                            {
                                this.ConditionText.AddText(condition.Name, Color.Lime);
                            }
                            else
                            {
                                this.ConditionText.AddText(condition.Name, Color.Red);
                            }
                            this.ConditionText.AddNewLine();
                        }
                        this.ConditionText.ResortTexts();
                    }
                    this.current = this.ShowingPerson.PersonalTitle;
                }
                flag = true;
            }
            if ((!flag && (this.ShowingPerson.CombatTitle != null)) && StaticMethods.PointInRectangle(position, this.CombatTitleLabelText.Text.AlignedPosition))
            {
                if (this.current != this.ShowingPerson.CombatTitle)
                {
                    this.InfluenceText.Clear();
                    if (this.ShowingPerson.CombatTitle.InfluenceCount > 0)
                    {
                        this.InfluenceText.AddText("战斗称号", Color.Yellow);
                        this.InfluenceText.AddText(this.ShowingPerson.CombatTitleString, Color.Red);
                        this.InfluenceText.AddNewLine();
                        foreach (Influence influence in this.ShowingPerson.CombatTitle.Influences.Influences.Values)
                        {
                            this.InfluenceText.AddText(influence.Description);
                            this.InfluenceText.AddNewLine();
                        }
                        this.InfluenceText.ResortTexts();
                        this.ConditionText.Clear();
                        this.ConditionText.AddText("修习条件", Color.LightPink);
                        this.ConditionText.AddNewLine();
                        foreach (Condition condition in this.ShowingPerson.CombatTitle.Conditions.Conditions.Values)
                        {
                            if (condition.CheckCondition(this.ShowingPerson))
                            {
                                this.ConditionText.AddText(condition.Name, Color.Lime);
                            }
                            else
                            {
                                this.ConditionText.AddText(condition.Name, Color.Red);
                            }
                            this.ConditionText.AddNewLine();
                        }
                        this.ConditionText.ResortTexts();
                    }
                    this.current = this.ShowingPerson.CombatTitle;
                }
                flag = true;
            }
            if (!flag)
            {
                for (int i = 0; i < this.AllSkillTexts.Count; i++)
                {
                    if (StaticMethods.PointInRectangle(position, this.AllSkillTexts[i].AlignedPosition))
                    {
                        if (this.current != this.LinkedSkills[i])
                        {
                            this.InfluenceText.Clear();
                            if (this.LinkedSkills[i].InfluenceCount > 0)
                            {
                                this.InfluenceText.AddText("技能", Color.Yellow);
                                this.InfluenceText.AddText(this.LinkedSkills[i].Name, Color.Lime);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in this.LinkedSkills[i].Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("修习条件", Color.LightPink);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in this.LinkedSkills[i].Conditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, Color.Lime);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, Color.Red);
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
            if (!flag && StaticMethods.PointInRectangle(position, this.StuntDisplayPosition))
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
                                this.InfluenceText.Clear();
                                this.InfluenceText.AddText("战斗特技", Color.Yellow);
                                this.InfluenceText.AddText(stunt.Name, Color.Red);
                                this.InfluenceText.AddNewLine();
                                this.InfluenceText.AddText("持续天数", Color.LightSteelBlue);
                                this.InfluenceText.AddText(stunt.Period.ToString(), Color.Lime);
                                this.InfluenceText.AddText("天", Color.LightSteelBlue);
                                this.InfluenceText.AddNewLine();
                                foreach (Influence influence in stunt.Influences.Influences.Values)
                                {
                                    this.InfluenceText.AddText(influence.Description);
                                    this.InfluenceText.AddNewLine();
                                }
                                this.InfluenceText.ResortTexts();
                                this.ConditionText.Clear();
                                this.ConditionText.AddText("使用条件", Color.LightSkyBlue);
                                this.ConditionText.AddNewLine();
                                if ((this.ShowingPerson.LocationTroop != null) && (this.ShowingPerson == this.ShowingPerson.LocationTroop.Leader))
                                {
                                    foreach (Condition condition in stunt.CastConditions.Conditions.Values)
                                    {
                                        if (condition.CheckCondition(this.ShowingPerson.LocationTroop))
                                        {
                                            this.ConditionText.AddText(condition.Name, Color.Lime);
                                        }
                                        else
                                        {
                                            this.ConditionText.AddText(condition.Name, Color.Red);
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
                                this.ConditionText.AddText("修习条件", Color.LightPink);
                                this.ConditionText.AddNewLine();
                                foreach (Condition condition in stunt.LearnConditions.Conditions.Values)
                                {
                                    if (condition.CheckCondition(this.ShowingPerson))
                                    {
                                        this.ConditionText.AddText(condition.Name, Color.Lime);
                                    }
                                    else
                                    {
                                        this.ConditionText.AddText(condition.Name, Color.Red);
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
                this.current = null;
                this.InfluenceText.Clear();
                this.ConditionText.Clear();
                if (this.ShowingPerson.PersonBiography != null)
                {
                    this.BiographyText.Clear();
                    this.BiographyText.AddText("列传", Color.Orange);
                    this.BiographyText.AddNewLine();
                    this.BiographyText.AddText(this.ShowingPerson.PersonBiography.Brief);
                    this.BiographyText.AddNewLine();
                    this.BiographyText.AddText("演义", Color.Green);
                    this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.Romance);
                    this.BiographyText.AddNewLine();
                    this.BiographyText.AddText("历史", Color.Red);
                    this.BiographyText.AddText("：" + this.ShowingPerson.PersonBiography.History);
                    this.BiographyText.AddNewLine();
                    this.BiographyText.ResortTexts();
                }
            }
        }

        private void screen_OnMouseRightUp(Point position)
        {
            this.IsShowing = false;
        }

        internal void SetPerson(Person person)
        {
            foreach (Skill skill in screen.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                Rectangle position = new Rectangle(this.SkillDisplayOffset.X + (skill.DisplayCol * this.SkillBlockSize.X), this.SkillDisplayOffset.Y + (skill.DisplayRow * this.SkillBlockSize.Y), this.SkillBlockSize.X, this.SkillBlockSize.Y);
                this.AllSkillTexts.AddText(skill.Name, position);
                this.LinkedSkills.Add(skill);
            }
            this.AllSkillTexts.ResetAllTextTextures();
            this.AllSkillTexts.ResetAllAlignedPositions();

            this.ShowingPerson = person;
            this.SurNameText.Text = person.SurName;
            this.GivenNameText.Text = person.GivenName;
            this.CalledNameText.Text = person.CalledName;
            foreach (LabelText text in this.LabelTexts)
            {
                text.Text.Text = StaticMethods.GetPropertyValue(person, text.PropertyName).ToString();
            }
            this.PersonalTitleLabelText.Text.Text = StaticMethods.GetPropertyValue(person, this.PersonalTitleLabelText.PropertyName).ToString();
            this.CombatTitleLabelText.Text.Text = StaticMethods.GetPropertyValue(person, this.CombatTitleLabelText.PropertyName).ToString();
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
            }
            this.PersonSkillTexts.ResetAllTextTextures();
            this.PersonSkillTexts.ResetAllAlignedPositions();
            this.LearnableSkillTexts.ResetAllTextTextures();
            this.LearnableSkillTexts.ResetAllAlignedPositions();
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
                this.BiographyText.AddText("列传", Color.Yellow);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText(person.PersonBiography.Brief);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText("演义", Color.Lime);
                this.BiographyText.AddText("：" + person.PersonBiography.Romance);
                this.BiographyText.AddNewLine();
                this.BiographyText.AddText("历史", Color.Red);
                this.BiographyText.AddText("：" + person.PersonBiography.History);
                this.BiographyText.AddNewLine();
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
            this.PersonalTitleLabelText.Label.DisplayOffset = this.DisplayOffset;
            this.PersonalTitleLabelText.Text.DisplayOffset = this.DisplayOffset;
            this.CombatTitleLabelText.Label.DisplayOffset = this.DisplayOffset;
            this.CombatTitleLabelText.Text.DisplayOffset = this.DisplayOffset;
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

        private Rectangle StuntDisplayPosition
        {
            get
            {
                return new Rectangle(this.StuntText.DisplayOffset.X, this.StuntText.DisplayOffset.Y, this.StuntText.ClientWidth, this.StuntText.ClientHeight);
            }
        }
    }
}

