namespace GameObjects
{
    using GameObjects;
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class YearTable : GameObjectList
    {
        private Dictionary<String, String> yearTableStrings;

        public YearTable()
        {
            TextReader tr = new StreamReader("Resources/yearTableStrings.txt");
            yearTableStrings = new Dictionary<String, String>();
            while (tr.Peek() >= 0)
            {
                String line = tr.ReadLine();
                yearTableStrings[line.Substring(0, line.IndexOf(' '))] = line.Substring(line.IndexOf(' ') + 1);
            }
        }

        private void addTableEntry(GameDate date, FactionList faction, string content, bool global)
        {
            this.Add(new YearTableEntry(this.GetFreeGameObjectID(), date, faction, content, global) as GameObject);
        }

        public void addTableEntry(int id, GameDate date, FactionList faction, string content, bool global)
        {
            this.Add(new YearTableEntry(id, date, faction, content, global) as GameObject);
        }

        public static FactionList composeFactionList(params Faction[] f)
        {
            FactionList r = new FactionList();
            foreach (Faction i in f)
            {
                if (i != null)
                {
                    r.Add(i);
                }
            }
            return r;
        }

        public void addOccupyEntry(GameDate date, Troop occupier, Architecture occupied)
        {
            if (occupied.BelongedFaction != null)
            {
                this.addTableEntry(date, composeFactionList(occupier.BelongedFaction, occupied.BelongedFaction),
                    String.Format(yearTableStrings["occupy"], occupier.BelongedFaction.Name, occupier.DisplayName, occupied.BelongedFaction.Name,
                        occupied.Name), true);
            }
            else
            {
                this.addTableEntry(date, composeFactionList(occupier.BelongedFaction, occupied.BelongedFaction),
                    String.Format(yearTableStrings["occupyEmpty"], occupier.BelongedFaction.Name, occupier.DisplayName,
                        occupied.Name), true);
            }
        }

        public void addFactionTechniqueCompletedEntry(GameDate date, Faction f, FactionDetail.Technique t)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["upgradeTechniqueCompleted"], f.Name, t.Name), false);
        }

        public void addKingDeathEntry(GameDate date, Person p, Faction oldFaction)
        {
            this.addTableEntry(date, composeFactionList(oldFaction), 
                String.Format(yearTableStrings["kingDeath"], oldFaction.Name, p.Name), true);
        }

        public void addChangeKingEntry(GameDate date, Person p, Faction oldFaction)
        {
            this.addTableEntry(date, composeFactionList(oldFaction),
                String.Format(yearTableStrings["changeKing"], oldFaction.Name, p.Name), true);
        }

        public void addChangeFactionEntry(GameDate date, Faction oldFaction, Faction newFaction)
        {
            this.addTableEntry(date, composeFactionList(oldFaction, newFaction),
                String.Format(yearTableStrings["changeFaction"], oldFaction.Name, newFaction.Name), true);
        }

        public void addFactionDestroyedEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), String.Format(yearTableStrings["factionDestroyed"], f.Name), true);
        }

        public void addChangeCapitalEntry(GameDate date, Faction f, Architecture newCapital)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["changeCapital"], f.Name, newCapital.Name), true);
        }

        public void addNewFactionEntry(GameDate date, Faction oldFaction, Faction newFaction, Architecture foundLocation)
        {
            if (oldFaction != null)
            {
                this.addTableEntry(date, composeFactionList(oldFaction, newFaction),
                    String.Format(yearTableStrings["newFaction"], newFaction.Leader, oldFaction.Name, foundLocation.Name), true);
            }
            else
            {
                this.addTableEntry(date, composeFactionList(oldFaction, newFaction),
                    String.Format(yearTableStrings["newFactionOnEmpty"], newFaction.Leader, foundLocation.Name), true);
            }
        }

        public void addSelfBecomeEmperorEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["selfBecomeEmperor"], f.Name, f.Leader.Name), true);
        }

        public void addBecomeEmperorLegallyEntry(GameDate date, Person oldEmperor, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["becomeEmperorLegally"], oldEmperor.Name, f.Name, f.Leader.Name), true);
        }

        public void addExecuteEntry(GameDate date, Person executor, Person executed)
        {
            if (executed.BelongedFaction != null)
            {
                this.addTableEntry(date, composeFactionList(executor.BelongedFaction, executed.BelongedFaction),
                    String.Format(yearTableStrings["execute"], executor.Name, executed.BelongedFaction.Name, executed.Name), true);
            }
            else
            {
                this.addTableEntry(date, composeFactionList(executor.BelongedFaction),
                    String.Format(yearTableStrings["executeNoFaction"], executor.Name, executed.Name, ""), true);
            }
        }

        public void addChildrenBornEntry(GameDate date, Person factionLeader, Person feizi, Person born)
        {
            Faction faction = factionLeader.BelongedFaction;
            if (faction == null)
            {
                if (factionLeader.BelongedArchitecture != null)
                {
                    faction = factionLeader.BelongedArchitecture.BelongedFaction;
                }
                else if (factionLeader.BelongedTroop != null)
                {
                    faction = factionLeader.BelongedTroop.BelongedFaction;
                }
            }
            if (faction != null)
            {
                this.addTableEntry(date, composeFactionList(faction),
                    String.Format(yearTableStrings["childrenBorn"], faction.Name, factionLeader.Name, feizi.Name, (born.Sex ? "女" : "子"), born.Name), false);
            }
            else
            {
                this.addTableEntry(date, composeFactionList(faction),
                    String.Format(yearTableStrings["childrenBornNoFaction"], factionLeader.Name, feizi.Name, (born.Sex ? "女" : "子"), born.Name), false);
            }
        }

        public void addPersonDeathEntry(GameDate date, Person p)
        {
            String location = "";
            if (p.BelongedArchitecture != null)
            {
                location = p.BelongedArchitecture.Name;
            }
            else if (p.BelongedTroop != null)
            {
                location = p.BelongedTroop.Name;
            }
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["personDeath"], p.Name, location), true);
        }

        public void addGameEndWithUniteEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f),
                String.Format(yearTableStrings["gameEndWithUnite"], f.Name, f.Leader.Name), true);
        }

        public void addAdvanceGuanjueEntry(GameDate date, Faction f, guanjuezhongleilei guanjue)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["advanceGuanjue"], f.Name, guanjue.Name), true);
        }

        public void addSelfAdvanceGuanjueEntry(GameDate date, Faction f, guanjuezhongleilei guanjue)
        {
            this.addTableEntry(date, composeFactionList(f),
                String.Format(yearTableStrings["selfAdvanceGuanjue"], f.Name, guanjue.Name), true);
        }

        public void addCreateSpouseEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createSpouse"], p1.Name, p2.Name), false);
        }

        public void addCreateBrotherEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createBrother"], p1.Name, p2.Name), false);
        }

        public void addCreateSisterEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createSister"], p1.Name, p2.Name), false);
        }

        public void addKilledInBattleEntry(GameDate date, Person killer, Person killed)
        {
            String killerFaction = killer.BelongedFaction == null ? "" : killer.BelongedFaction.Name;
            String killedFaction = killed.BelongedFaction == null ? "" : killed.BelongedFaction.Name;
            this.addTableEntry(date, composeFactionList(killer.BelongedFaction, killed.BelongedFaction),
                String.Format(yearTableStrings["personKilledInBattle"], killedFaction, killed, killerFaction, killer), true);
        }

        public void addDefeatedManyTroopsEntry(GameDate date, Person p, int count)
        {
            if ((count < 100 && count % 10 == 0) || count % 50 == 0)
            {
                this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                    String.Format(yearTableStrings["defeatedManyTroops"], p.Name, count), false);
            }
        }

        public void addGrownBecomeAvailableEntry(GameDate date, Person p)
        {
            if (p.LocationArchitecture != null)
            {
                if (p.BelongedFaction == null)
                {
                    this.addTableEntry(date, composeFactionList(),
                        String.Format(yearTableStrings["grownBecomeAvailabeNoFaction"], p.Name, p.LocationArchitecture.Name), false);
                }
                else
                {
                    this.addTableEntry(date, composeFactionList(),
                        String.Format(yearTableStrings["grownBecomeAvailable"], p.Name, p.LocationArchitecture.Name, p.BelongedFaction.Name), false);
                }
            }
        }

        public void addBecomePrincessEntry(GameDate date, Person p, Person leader)
        {
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["becomePrincess"], p.Name, p.BelongedArchitecture.Name, leader.Name), false);
        }

        public void addOutOfPrincessEntry(GameDate date, Person p, Faction capturer)
        {
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["becomePrincess"], p.Name, p.BelongedArchitecture.Name, capturer == null ? "" : capturer.Name), false);
        }
    }
}
