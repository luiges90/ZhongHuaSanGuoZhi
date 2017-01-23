namespace PersonPortraitPlugin
{
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Resources;

    public class PersonPortrait
    {
        internal GraphicsDevice Device;
        internal Dictionary<float, PlayerImage> PlayerImages = new Dictionary<float, PlayerImage>();
        private Dictionary<float, PortraitItem> portraits = new Dictionary<float, PortraitItem>();
        internal string TempImageFileName;

        private PlayerImage defaultImage;

        public PersonPortrait()
        {
            defaultImage = LoadImage(9999);
        }

        public bool HasPortrait(float id) 
        {
            return GetImage(id) != defaultImage.Portrait;
        }

        internal Image GetImage(float id)
        {
            Image portrait = null;
            PlayerImage image = null;
            
            if (!this.PlayerImages.TryGetValue(id, out image))
            {
                image = this.LoadImage(id);
                if (image == null)
                {
                    image = defaultImage;
                    
                }
                this.PlayerImages.Add(id, image);
            }

            portrait = image.Portrait;

            return portrait;
        }

        private PortraitItem GetItem(float id)
        {
            PortraitItem item;
            this.portraits.TryGetValue(id, out item);
            if (item == null)
            {
                PlayerImage image = null;
                this.PlayerImages.TryGetValue(id, out image);
                if (image == null)
                {
                    image = this.LoadImage(id);
                    this.PlayerImages.Add(id, image);
                    if (image == null)
                    {
                        image = this.LoadImage((int)id);
                        if (image == null)
                        {
                            image = defaultImage;
                        }
                    }
                }
                item = new PortraitItem();
                image.Portrait.Save(this.TempImageFileName);
                item.PortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                image.SmallPortrait.Save(this.TempImageFileName);
                item.SmallPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                image.TroopPortrait.Save(this.TempImageFileName);
                item.TroopPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);

                this.portraits.Add(id, item);
            }
            return item;
        }

        internal Texture2D GetPortrait(float id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.PortraitTexture;
            }
            return null;
        }

        internal Texture2D GetSmallPortrait(float id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.SmallPortraitTexture;
            }
            return null;
        }

        internal Texture2D GetTroopPortrait(float id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.TroopPortraitTexture;
            }
            return null;
        }

        private PlayerImage LoadImage(string path, float id)
        {
            if (File.Exists(path + @"\" + id + "s.jpg"))
            {
                if (File.Exists(path + @"\" + id + "t.jpg"))
                {
                    PlayerImage image = new PlayerImage
                    {
                        Portrait = Image.FromFile(path + @"\" + id + ".jpg"),
                        SmallPortrait = Image.FromFile(path + @"\" + id + "s.jpg"),
                        TroopPortrait = Image.FromFile(path + @"\" + id + "t.jpg")
                    };
                    return image;
                }
                else
                {
                    PlayerImage image = new PlayerImage
                    {
                        Portrait = Image.FromFile(path + @"\" + id + ".jpg"),
                        SmallPortrait = Image.FromFile(path + @"\" + id + "s.jpg"),
                        TroopPortrait = Image.FromFile(path + @"\" + id + "s.jpg")
                    };
                    return image;
                }
            }
            return null;
        }

        private PlayerImage LoadImage(float id)
        {
            PlayerImage result = this.LoadImage(@"GameComponents\PersonPortrait\Images\Player", id);
            if (result == null)
            {
                result = this.LoadImage(@"GameComponents\PersonPortrait\Images\Default", id);
            }
            return result;
        }

    }
}

