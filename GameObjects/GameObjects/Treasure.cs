namespace GameObjects
{
    using GameObjects.Influences;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class Treasure : GameObject
    {
        #region 字段
        /// <summary>所属武将</summary>
        public Person BelongedPerson;

        /// <summary>隐藏地点</summary>
        public Architecture HidePlace;

        /// <summary>影响</summary>
        public InfluenceTable Influences = new InfluenceTable();
        #endregion

        #region 属性

        /// <value>??意义及用途不明??</value>
        public int TreasureGroup
        {
            get;
            set;
        }

        /// <value>出现年代</value>
        public int AppearYear
        {
            get
            {
                return this.appearYear;
            }
            set
            {
                this.appearYear = value;
            }
        }
        private int appearYear;

        /// <value>是否可用, 该属性的作用相当于是否被武将持有</value>
        public bool Available
        {
            get
            {
                return this.available;
            }
            set
            {
                this.available = value;
            }
        }
        private bool available;

        /// <value>所属武将的姓名, 无人持有时为"----"</value>
        public string BelongedPersonString
        {
            get
            {
                return ((this.BelongedPerson != null) ? this.BelongedPerson.Name : "----");
            }
        }

        /// <value>对宝物本身的描述</value>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        private string description;

        /// <value>隐藏地点的字符串</value>
        public string HidePlaceString
        {
            get
            {
                return ((this.HidePlace != null) ? this.HidePlace.Name : "----");
            }
        }

        /// <value>描述效果的字符串</value>
        public string InfluenceString
        {
            get
            {
                string str = "";
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    str = str + "•" + influence.Description;
                }
                return str;
            }
        }

        /// <value>宝物图片的编号</value>
        public int Pic
        {
            get
            {
                return this.pic;
            }
            set
            {
                this.pic = value;
            }
        }
        private int pic;

        /// <value>宝物图片的二维纹理</value>
        public Texture2D Picture
        {
            get
            {
                if (this.picture == null)
                {
                    try
                    {
                        this.picture = Texture2D.FromFile(base.Scenario.GameScreen.GraphicsDevice, "Resources/Treasure/" + this.Pic.ToString() + ".png");
                    }
                    catch
                    {
                        this.picture = new Texture2D(base.Scenario.GameScreen.GraphicsDevice, 0, 0);
                    }
                }
                return this.picture;
            }
        }
        private Texture2D picture;

        /// <value>价值</value>
        public int Worth
        {
            get
            {
                return this.worth;
            }
            set
            {
                this.worth = value;
            }
        }
        private int worth;

        #endregion

        #region 方法
        /// <summary>释放宝物图片的二维纹理</summary>
        public void disposeTexture()
        {
            if (this.picture != null)
            {
                this.picture.Dispose();
                this.picture = null;
            }
        }
        #endregion
    }
}

