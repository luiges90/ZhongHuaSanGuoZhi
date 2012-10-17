namespace GameObjects.Animations
{
    using GameGlobal;
    using GameObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Runtime.InteropServices;

    public class Animation : GameObject
    {
        private bool back;
        public GraphicsDevice Device;
        private int frameCount;
        public string SoundPath;
        private int stayCount;
        private Texture2D texture;
        public string TextureFileName;

        public Rectangle GetCurrentDisplayRectangle(ref int frameIndex, ref int stayIndex, int width, int row, out bool EndLoop, bool hold)
        {
            EndLoop = false;
            if (!hold)
            {
                if ((stayIndex += 1) > this.StayCount)
                {
                    stayIndex = 0;
                    frameIndex++;
                    if (frameIndex >= (this.FrameCount - 1))
                    {
                        EndLoop = true;
                    }
                }
            }
            return new Rectangle(width * frameIndex, width * row, width, width);
        }

        public bool Back
        {
            get
            {
                return this.back;
            }
            set
            {
                this.back = value;
            }
        }

        public int FrameCount
        {
            get
            {
                return this.frameCount;
            }
            set
            {
                this.frameCount = value;
            }
        }

        public int StayCount
        {
            get
            {
                if (GlobalVariables.FastBattleSpeed)
                {
                    return (this.stayCount / 2);
                }
                return this.stayCount;
            }
            set
            {
                this.stayCount = value;
            }
        }

        public void disposeTexture()
        {
            if (this.texture != null)
            {
                this.texture.Dispose();
                this.texture = null;
            }
        }

        public Texture2D Texture
        {
            get
            {
                if (this.texture == null)
                {
                    this.texture = Texture2D.FromFile(this.Device, this.TextureFileName);
                }
                return this.texture;
            }
        }
    }
}

