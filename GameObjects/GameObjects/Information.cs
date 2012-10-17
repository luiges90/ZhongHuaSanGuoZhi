namespace GameObjects
{
    using GameGlobal;
    using Microsoft.Xna.Framework;
    using System;

    public class Information : GameObject
    {
        private GameArea area;
        public Faction BelongedFaction;
        private int daysLeft;
        private InformationLevel level;
        private bool oblique;
        private Point position;
        private int radius;

        public void Apply()
        {
            foreach (Point point in this.Area.Area)
            {
                this.BelongedFaction.AddPositionInformation(point, this.Level);
                this.CheckAmbushTroop(point);
            }
        }

        public void CheckAmbushTroop()
        {
            foreach (Point point in this.Area.Area)
            {
                this.CheckAmbushTroop(point);
            }
        }

        private void CheckAmbushTroop(Point p)
        {
            Troop troopByPosition = base.Scenario.GetTroopByPosition(p);
            if (((troopByPosition != null) && (troopByPosition.Status == TroopStatus.埋伏)) && !this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
            {
                this.DetectAmbush(troopByPosition);
            }
        }

        private void DetectAmbush(Troop troop)
        {
            int chance = 40 - troop.Leader.Calmness;
            if (this.Level <= InformationLevel.中)
            {
                if (troop.OnlyBeDetectedByHighLevelInformation)
                {
                    return;
                }
            }
            else
            {
                chance *= 3;
            }
            if (GameObject.Chance(chance))
            {
                troop.AmbushDetected(troop);
            }
        }

        public void Initialize()
        {
            foreach (Point point in this.Area.Area)
            {
                this.BelongedFaction.AddPositionInformation(point, this.Level);
            }
        }

        public void Purify()
        {
            foreach (Point point in this.Area.Area)
            {
                this.BelongedFaction.RemovePositionInformation(point, this.Level);
            }
        }

        public GameArea Area
        {
            get
            {
                if (this.area == null)
                {
                    this.area = GameArea.GetViewArea(this.position, this.radius, this.oblique, base.Scenario, null);
                }
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }

        public int DaysLeft
        {
            get
            {
                return this.daysLeft;
            }
            set
            {
                this.daysLeft = value;
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

        public Point Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
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

