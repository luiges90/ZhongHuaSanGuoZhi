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
        internal Dictionary<int, PlayerImage> PlayerImages = new Dictionary<int, PlayerImage>();
        private Dictionary<int, PortraitItem> portraits = new Dictionary<int, PortraitItem>();
        internal string TempImageFileName;

        internal Image GetImage(int id)
        {
            Image portrait = null;
            PlayerImage image2 = null;
            if (this.PlayerImages.TryGetValue(id, out image2))
            {
                portrait = image2.Portrait;
            }
            return portrait;
        }

        private PortraitItem GetItem(int id)
        {
            PortraitItem item;
            this.portraits.TryGetValue(id, out item);
            if (item == null)
            {
                PlayerImage image = null;
                this.PlayerImages.TryGetValue(id, out image);
                if (image == null) return null;
                item = new PortraitItem();
                image.Portrait.Save(this.TempImageFileName);
                item.PortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                image.SmallPortrait.Save(this.TempImageFileName);
                item.SmallPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                this.portraits.Add(id, item);
            }
            return item;
        }

        internal Texture2D GetPortrait(int id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.PortraitTexture;
            }
            return null;
        }

        internal Texture2D GetSmallPortrait(int id)
        {
            PortraitItem item = this.GetItem(id);
            if (item != null)
            {
                return item.SmallPortraitTexture;
            }
            return null;
        }

        internal void LoadPlayerImages(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                for (int i = 0; i <= 32767; i++)
                {
                    string str = path + @"\" + i.ToString() + ".jpg";
                    string str2 = path + @"\" + i.ToString() + "s.jpg";
                    if (File.Exists(str) && File.Exists(str2))
                    {
                        PlayerImage image = new PlayerImage {
                            Portrait = Image.FromFile(str),
                            SmallPortrait = Image.FromFile(str2)
                        };
                        this.PlayerImages.Remove(i);
                        this.PlayerImages.Add(i, image);
                    }
                }
            }
        }
    }
}

