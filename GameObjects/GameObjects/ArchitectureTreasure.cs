namespace GameObjects
{
    // Trease相关
	public partial class Architecture
	{
        /// <summary>
        /// 获取建筑内所有武将(Normal + Moving)的宝物列表
        /// </summary>
        /// <returns>宝物列表</returns>
        public TreasureList GetAllTreasureInArchitecture()
        {
            TreasureList list = new TreasureList();
            foreach (Person person in this.GetAllPersons())
            {
                person.AddTreasureToList(list);
            }
            return list;
        }

        /// <summary>
        /// 获取建筑内所有武将(Normal, 非君主)的宝物列表
        /// </summary>
        /// <returns>宝物列表</returns>
        public TreasureList GetAllTreasureInArchitectureExceptLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person != this.BelongedFaction.Leader)
                    {
                        person.AddTreasureToList(list);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取建筑所属势力的君主的宝物列表
        /// </summary>
        /// <returns>宝物列表</returns>
        public TreasureList GetTreasureListOfLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.Leader.AddTreasureToList(list);
            }
            return list;
        }

        /// <summary>
        /// 获取建筑所属势力的宝物列表
        /// </summary>
        /// <returns>宝物列表</returns>
        public TreasureList GetAllTreasureInFaction()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.BelongedFaction.Persons)
                {
                    person.AddTreasureToList(list);
                }
            }
            return list;
        }

        /// <summary>
        /// 建筑内的武将(Noraml + Moving)是否持有宝物
        /// </summary>
        /// <returns>建筑内的武将(Normal + Moviing)持有宝物时返回true, 否则返回false</returns>
        public bool HasTreasure()
        {
            foreach (Person person in this.GetAllPersons())
            {
                if (person.TreasureCount > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 建筑所属势力是否有宝物可用来赏赐
        /// </summary>
        /// <returns>
        /// 当势力武将数 = 1(只有君主一人)，返回false
        /// 当势力武将数 > 1, 如果君主持有宝物则返回true, 否则返回false
        /// </returns>
        public bool HasTreasureToAward()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                if (this.BelongedFaction.PersonCount <= 1)
                {
                    return false;
                }
                return this.BelongedFaction.Leader.TreasureCount > 0;
            }
            return false;
        }

        /// <summary>
        /// 建筑所属势力是否有宝物可以没收
        /// </summary>
        /// <returns>有宝物可以没收返回true, 否则返回false</returns>
        public bool HasTreasureToConfiscate()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                return this.BelongedFaction.AllTreasuresExceptLeader.Count > 0;
            }
            return false;
        }

       
    }
}
