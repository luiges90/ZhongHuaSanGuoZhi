namespace GameObjects.TroopDetail
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;

    public class TroopAnimation
    {
        private Dictionary<Point, List<Point>> Animations = new Dictionary<Point, List<Point>>();

        public List<Point> GetDirectionAnimation(Point direction)
        {
            return this.Animations[direction];
        }

        public void UpdateDirectionAnimations(int width)
        {
            int num;
            this.Animations.Clear();
            List<Point> list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount)), 0));
            }
            this.Animations.Add(new Point(1, 0), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point(0, (int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(0, 1), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount)), 0));
            }
            this.Animations.Add(new Point(-1, 0), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point(0, (int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(0, -1), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount)), (int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(1, 1), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount)), (int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(-1, 1), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((width * num) / GlobalVariables.TroopMoveFrameCount)), (int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(1, -1), list);
            list = new List<Point>();
            for (num = 1; num < GlobalVariables.TroopMoveFrameCount; num++)
            {
                list.Add(new Point((int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount)), (int) Math.Round((decimal) ((-width * num) / GlobalVariables.TroopMoveFrameCount))));
            }
            this.Animations.Add(new Point(-1, -1), list);
        }
    }
}

