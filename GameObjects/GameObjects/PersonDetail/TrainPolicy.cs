using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameObjects.PersonDetail
{
	public class TrainPolicy : GameObject
	{
        public String Description { get; set; }
        public float Command { get; set; }
        public float Strength { get; set; }
        public float Intelligence { get; set; }
        public float Politics { get; set; }
        public float Glamour { get; set; }
        public float Skill { get; set; }
        public float Stunt { get; set; }
        public float Title { get; set; }

        public Dictionary<int, float> Weighting
        {
            get
            {
                Dictionary<int, float> dict = new Dictionary<int, float>();
                dict.Add(1, this.Command);
                dict.Add(2, this.Strength);
                dict.Add(3, this.Intelligence);
                dict.Add(4, this.Politics);
                dict.Add(5, this.Glamour);
                dict.Add(6, this.Skill);
                dict.Add(7, this.Stunt);
                dict.Add(8, this.Title);
                return dict;
            }
        }
	}
}
