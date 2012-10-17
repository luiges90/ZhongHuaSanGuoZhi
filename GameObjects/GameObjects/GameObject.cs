namespace GameObjects
{
    using GameGlobal;
    using System;

    public class GameObject
    {
        private int id;
        private string name;
        public float Scale;
        public GameScenario Scenario = null;
        private bool selected;
        private string textDestinationString;
        private string textResultString;

        public static bool Chance(int chance)
        {
            if (chance <= 0)
            {
                return false;
            }
            return ((chance >= 100) || (Random(100) < chance));
        }

        public static bool Chance(int chance, int root)
        {
            if (chance <= 0)
            {
                return false;
            }
            return ((chance >= root) || (Random(root) < chance));
        }

        public GameObjectList GetGameObjectList()
        {
            GameObjectList list = new GameObjectList();
            list.Add(this);
            return list;
        }

        public static int Random(int maxValue)
        {
            return StaticMethods.Random(maxValue);
        }

        public static int Square(int num)
        {
            return (num * num);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
            }
        }

        public string TextDestinationString
        {
            get
            {
                return this.textDestinationString;
            }
            set
            {
                this.textDestinationString = value;
            }
        }

        public string TextResultString
        {
            get
            {
                return this.textResultString;
            }
            set
            {
                this.textResultString = value;
            }
        }
    }
}

