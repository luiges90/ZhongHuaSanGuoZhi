using System;
using System.Collections.Generic;

namespace GameObjects
{
	public class OngoingBattle : GameObject
	{
        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int StartDay { get; set; }
        public int CalmDay { get; set; }
        public bool Skirmish { get; set; }
	}
}
