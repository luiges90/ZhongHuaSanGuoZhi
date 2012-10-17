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
        internal ResourceManager PortraitRM;
        private Dictionary<int, PortraitItem> portraits = new Dictionary<int, PortraitItem>();
        internal ResourceManager SmallPortraitRM;
        internal string TempImageFileName;

        internal Image GetImage(int id)
        {
            string key = this.GetKey(id);
            Image portrait = (Image) this.PortraitRM.GetObject(key);
            if (portrait == null)
            {
                PlayerImage image2 = null;
                if (this.PlayerImages.TryGetValue(id, out image2))
                {
                    portrait = image2.Portrait;
                }
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
                item = new PortraitItem();
                if (image == null)
                {
                    string key = this.GetKey(id);
                    try
                    {
                        Image image2 = (Image) this.PortraitRM.GetObject(key);
                        if (image2 != null)
                        {
                            image2.Save(this.TempImageFileName);
                            item.PortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                            image2 = (Image) this.SmallPortraitRM.GetObject(key + "s");
                            if (image2 == null)
                            {
                                return null;
                            }
                            image2.Save(this.TempImageFileName);
                            item.SmallPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                            this.portraits.Add(id, item);
                            return item;
                        }
                        return null;
                    }
                    finally
                    {
                        File.Delete(this.TempImageFileName);
                    }
                    return item;
                }
                image.Portrait.Save(this.TempImageFileName);
                item.PortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                image.SmallPortrait.Save(this.TempImageFileName);
                item.SmallPortraitTexture = Texture2D.FromFile(this.Device, this.TempImageFileName);
                this.portraits.Add(id, item);
            }
            return item;
        }

        private string GetKey(int id)
        {
            string str = id.ToString();
            if (id < 10)
            {
                str = "000" + str;
            }
            else if (id < 100)
            {
                str = "00" + str;
            }
            else if (id < 0x3e8)
            {
                str = "0" + str;
            }
            return ("_" + str);
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
                for (int i = 0x1388; i <= 0x270f; i++)
                {
                    string str = path + @"\" + i.ToString() + ".jpg";
                    string str2 = path + @"\" + i.ToString() + "s.jpg";
                    if (File.Exists(str) && File.Exists(str2))
                    {
                        PlayerImage image = new PlayerImage {
                            Portrait = Image.FromFile(str),
                            SmallPortrait = Image.FromFile(str2)
                        };
                        this.PlayerImages.Add(i, image);
                    }
                }
            }
        }
    }
}

