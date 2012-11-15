﻿namespace GameObjects
{
    using GameGlobal;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class TroopListWithQueue : TroopList
    {
        public TroopList AmbushList = new TroopList();
        public Queue<Troop> CurrentQueue = new Queue<Troop>();
        public Troop CurrentTroop;
        private bool queueEnded = true;
        private Queue<Troop> troopQueue = new Queue<Troop>();

        public void BuildQueue()
        {
            this.queueEnded = false;
            if (this.troopQueue.Count != 0)
            {
                throw new Exception("troopQueue is not empty before building");
            }
            this.AmbushList.Clear();
            GameObjectList randomList = base.GetRandomList();
            if (GlobalVariables.MilitaryKindSpeedValid && (randomList.Count > 1))
            {
                randomList.PropertyName = "Speed";
                randomList.IsNumber = true;
                randomList.SmallToBig = false;
                randomList.ReSort();
            }
            foreach (Troop troop in randomList)
            {
                if (troop.ControlAvail())
                {
                    troop.InitializeInQueue();
                    if (troop.Status == TroopStatus.埋伏)
                    {
                        this.AmbushList.Add(troop);
                    }
                    else
                    {
                        this.troopQueue.Enqueue(troop);
                    }
                }
                troop.Operated = false;
                troop.Controllable = true;
            }
        }

        private bool CheckAmbushList()
        {
            Troop gameObject = null;
            int count = this.AmbushList.Count;
            foreach (Troop troop2 in this.AmbushList)
            {
                if (troop2.ToDoCombatAction())
                {
                    troop2.DoCombatAction();
                    if (troop2.OperationDone)
                    {
                        gameObject = troop2;
                        break;
                    }
                }
            }
            this.AmbushList.Remove(gameObject);
            return (gameObject != null);
        }

        public void Clear()
        {
            base.GameObjects.Clear();
            this.troopQueue.Clear();
            this.CurrentQueue.Clear();
            this.AmbushList.Clear();
        }

        public void CurrentQueueTroopMove()
        {
            
            if (this.CurrentTroop != null)
            {

                this.TroopMoveThread(this.CurrentTroop);

                /*
                thread = new Thread(new ThreadStart(this.CurrentTroop.Move));
                thread.Start();
                thread.Join();
                */
                if (this.CurrentTroop.StepFinished || (this.CurrentTroop.MovabilityLeft <= 0))
                {
                    if (!this.CurrentTroop.OperationDone)
                    {
                        this.troopQueue.Enqueue(this.CurrentTroop);
                    }
                    this.CurrentTroop = null;
                }
            }
            else if (!this.CheckAmbushList())
            {
                Queue<Troop> queue = new Queue<Troop>();
                if ((this.CurrentQueue.Count == 0) && (this.troopQueue.Count > 0))
                {
                    this.CurrentQueue.Enqueue(this.troopQueue.Dequeue());
                }
                while (this.CurrentQueue.Count > 0)
                {
                    Troop item = this.CurrentQueue.Dequeue();
                    if (!item.Destroyed)
                    {
                        if (!(item.HasToDoCombatAction || !item.ToDoCombatAction()))
                        {
                            item.HasToDoCombatAction = true;
                            this.CurrentQueue.Enqueue(item);
                            break;
                        }
                        if (item.HasToDoCombatAction)
                        {
                            item.HasToDoCombatAction = false;
                            item.DoCombatAction();
                            this.CurrentQueue.Enqueue(item);
                            break;
                        }
                        if (this.troopQueue.Count > 0)
                        {
                            this.CurrentQueue.Enqueue(this.troopQueue.Dequeue());
                        }
                        if (item.Destroyed || (item.Status != TroopStatus.一般))
                        {
                            item.MovabilityLeft = -1;
                            item.OperationDone = true;
                        }
                        else if (item.MovabilityLeft > 0)
                        {
                            this.TroopChangeRealDestination(item);
                            this.TroopMoveThread(item);
                        }
                        if ((!item.OperationDone && item.OffenceOnlyBeforeMove) && (item.Position != item.PreviousPosition))
                        {
                            item.OperationDone = true;
                        }
                        if (!item.StepFinished || item.chongshemubiaoweizhibiaoji)
                        {
                            this.CurrentTroop = item;
                            break;
                        }
                        if (!this.queueEnded)
                        {
                            if (item.MovabilityLeft > 0)
                            {
                                item.WaitOnce = true;
                                queue.Enqueue(item);
                            }
                            else if (!(item.OperationDone || item.QueueEnded))
                            {
                                queue.Enqueue(item);
                            }
                        }
                    }
                }
                while (queue.Count > 0)
                {
                    this.troopQueue.Enqueue(queue.Dequeue());
                }
                if (!this.queueEnded && this.TotallyEmpty)
                {
                    this.queueEnded = true;
                    TroopList list = new TroopList();
                    foreach (Troop troop2 in base.GameObjects)
                    {
                        if (troop2.QueueEnded)
                        {
                            list.Add(troop2);
                        }
                    }
                    foreach (Troop troop2 in list.GetRandomList())
                    {
                        this.troopQueue.Enqueue(troop2);
                    }
                }
            }
        }
        private void TroopChangeRealDestination(Troop troop)
        {
            if (troop.mingling == "攻击军队" && troop.TargetTroop != null)
            {
                troop.RealDestination = troop.TargetTroop.Position;
            }
            else if (troop.mingling == "攻击军队" && troop.TargetTroop == null)
            {
                troop.RealDestination = troop.Position;
                troop.OperationDone = true;
            }
            /*
            else if (troop.mingling == "入城")
            {
                troop.RealDestination = troop.minglingweizhi;
            }
            */

        }


        private void TroopMoveThread(Troop troop)
        {
            troop.Move();
            /*
            Thread thread;

            thread = new Thread(new ThreadStart(troop.Move));
            thread.Start();
            thread.Join();

            thread = null;*/
        }



        public void FinalizeQueue()
        {
            foreach (Troop troop in base.GameObjects)
            {
                troop.FinalizeInQueue();
            }
        }

        public void MoveTroopsFromQueueToCurrentQueue(int n)
        {
            if (this.troopQueue.Count < n)
            {
                n = this.troopQueue.Count;
            }
            for (int i = 0; i < n; i++)
            {
                this.CurrentQueue.Enqueue(this.troopQueue.Dequeue());
            }
        }

        public void StepAnimationIndex(int steps)
        {
            if (this.CurrentTroop != null)
            {
                this.CurrentTroop.AddMoveAnimationIndex(steps);
            }
            foreach (Troop troop in this.CurrentQueue)
            {
                if (troop.Action != TroopAction.Stop)
                {
                    troop.AddMoveAnimationIndex(steps);
                }
            }
        }

        public bool CurrentQueueEmpty
        {
            get
            {
                return ((this.CurrentQueue.Count == 0) && (this.CurrentTroop == null));
            }
        }

        public bool QueueEmpty
        {
            get
            {
                return (this.troopQueue.Count == 0);
            }
        }

        public bool TotallyEmpty
        {
            get
            {
                return (this.QueueEmpty && this.CurrentQueueEmpty);
            }
        }
    }
}

