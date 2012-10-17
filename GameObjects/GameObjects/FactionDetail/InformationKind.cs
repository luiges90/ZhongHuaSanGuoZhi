namespace GameObjects.FactionDetail
{
    using GameGlobal;
    using GameObjects;
    using System;

    public class InformationKind : GameObject
    {
        private int coolDown;
        private int costFund;
        private int days;
        private InformationLevel level;
        private bool oblique;
        private int radius;

        public bool Avail(Architecture a)
        {
            return (a.Fund >= this.costFund);
        }

        public int CoolDown
        {
            get
            {
                return this.coolDown;
            }
            set
            {
                this.coolDown = value;
            }
        }

        public int CostFund
        {
            get
            {
                return this.costFund;
            }
            set
            {
                this.costFund = value;
            }
        }

        public int Days
        {
            get
            {
                return this.days;
            }
            set
            {
                this.days = value;
            }
        }

        public int FightingWeighing
        {
            get
            {
                return ((((this.Days * this.Radius) *(int)  this.Level) * 100) / this.CostFund);
            }
        }

        public InformationLevel Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public bool Oblique
        {
            get
            {
                return this.oblique;
            }
            set
            {
                this.oblique = value;
            }
        }

        public string ObliqueString
        {
            get
            {
                return (this.Oblique ? "○" : "×");
            }
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
            }
        }
    }
}

