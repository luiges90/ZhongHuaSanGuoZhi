namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class BiographyAdjectives : GameObject
    {
        public int ID { get; set; }
        public int Strength { get; set; }
        public int Command { get; set; }
        public int Intelligence { get; set; }
        public int Politics { get; set; }
        public int Glamour { get; set; }
        public int Braveness { get; set; }
        public int Calmness { get; set; }
        public int PersonalLoyalty { get; set; }
        public int Ambition { get; set; }
        public Boolean Male { get; set; }
        public Boolean Female { get; set; }
        public List<String> Text { get; set; }
        public List<String> SuffixText { get; set; }
    }
}

