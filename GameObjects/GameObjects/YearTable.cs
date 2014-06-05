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

        private void addPersonInGameBiography(Person p, GameDate date, string content)
        {
            p.PersonBiography.InGame += date.Year + "年" + date.Month + "月：" + content + '\n';
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
                String.Format(yearTableStrings["kingDeath"], oldFaction.Name, p.Name, p.Age), true);
            this.addPersonInGameBiography(oldFaction.Leader, date,
                String.Format(yearTableStrings["kingDeath_p"], oldFaction.Name, p.Name, p.Age));
        }

        public void addChangeKingEntry(GameDate date, Person p, Faction oldFaction, Person oldLeader)
        {
            this.addTableEntry(date, composeFactionList(oldFaction),
                String.Format(yearTableStrings["changeKing"], oldFaction.Name, p.Name, oldLeader.Name), true);
            this.addPersonInGameBiography(p, date,
                String.Format(yearTableStrings["changeKing_p"], oldFaction.Name, p.Name, oldLeader.Name));
        }

        public void addChangeFactionEntry(GameDate date, Faction oldFaction, Faction newFaction)
        {
            this.addTableEntry(date, composeFactionList(oldFaction, newFaction),
                String.Format(yearTableStrings["changeFaction"], newFaction.Name, oldFaction.Name, oldFaction.Leader.Name), true);
            this.addPersonInGameBiography(newFaction.Leader, date,
                String.Format(yearTableStrings["changeFaction_p"], newFaction.Name, oldFaction.Name, oldFaction.Leader.Name));
        }

        public void addFactionDestroyedEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), String.Format(yearTableStrings["factionDestroyed"], f.Name), true);
            this.addPersonInGameBiography(f.Leader, date, String.Format(yearTableStrings["factionDestroyed_p"], f.Name));
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
                    String.Format(yearTableStrings["newFaction"], newFaction.Leader, oldFaction.Name, foundLocation.Name, newFaction.Name), true);
                this.addPersonInGameBiography(newFaction.Leader, date,
                    String.Format(yearTableStrings["newFaction_p"], newFaction.Leader, oldFaction.Name, foundLocation.Name, newFaction.Name));
            }
            else
            {
                this.addTableEntry(date, composeFactionList(oldFaction, newFaction),
                    String.Format(yearTableStrings["newFactionOnEmpty"], newFaction.Leader, foundLocation.Name, newFaction.Name), true);
                this.addPersonInGameBiography(newFaction.Leader, date,
                    String.Format(yearTableStrings["newFactionOnEmpty_p"], newFaction.Leader, foundLocation.Name, newFaction.Name));
            }
        }

        public void addSelfBecomeEmperorEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["selfBecomeEmperor"], f.Name, f.Leader.Name), true);
            this.addPersonInGameBiography(f.Leader, date,
                String.Format(yearTableStrings["selfBecomeEmperor_p"], f.Name, f.Leader.Name));
        }

        public void addBecomeEmperorLegallyEntry(GameDate date, Person oldEmperor, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["becomeEmperorLegally"], oldEmperor.Name, f.Name, f.Leader.Name), true);
            this.addPersonInGameBiography(f.Leader, date,
                String.Format(yearTableStrings["becomeEmperorLegally_p"], oldEmperor.Name, f.Name, f.Leader.Name));
        }

        public void addExecuteEntry(GameDate date, Person executor, Person executed)
        {
            if (executed.BelongedFaction != null)
            {
                this.addTableEntry(date, composeFactionList(executor.BelongedFaction, executed.BelongedFaction),
                    String.Format(yearTableStrings["execute"], executor.Name, executed.BelongedFaction.Name, executed.Name, executed.Age), true);
                this.addPersonInGameBiography(executor, date,
                    String.Format(yearTableStrings["execute_p"], executor.Name, executed.BelongedFaction.Name, executed.Name, executed.Age));
                this.addPersonInGameBiography(executed, date,
                    String.Format(yearTableStrings["execute_q"], executor.Name, executed.BelongedFaction.Name, executed.Name, executed.Age));
            }
            else
            {
                this.addTableEntry(date, composeFactionList(executor.BelongedFaction),
                    String.Format(yearTableStrings["executeNoFaction"], executor.Name, executed.Name, executed.Age), true);
                this.addPersonInGameBiography(executor, date,
                    String.Format(yearTableStrings["executeNoFaction_p"], executor.Name, executed.Name, executed.Age));
                this.addPersonInGameBiography(executed, date,
                    String.Format(yearTableStrings["executeNoFaction_q"], executor.Name, executed.Name, executed.Age));
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
                this.addPersonInGameBiography(factionLeader, date,
                    String.Format(yearTableStrings["childrenBorn_p"], faction.Name, factionLeader.Name, feizi.Name, (born.Sex ? "女" : "子"), born.Name));
                this.addPersonInGameBiography(feizi, date,
                    String.Format(yearTableStrings["childrenBorn_q"], faction.Name, factionLeader.Name, feizi.Name, (born.Sex ? "女" : "子"), born.Name));
            }
        }

        public void addGameEndWithUniteEntry(GameDate date, Faction f)
        {
            this.addTableEntry(date, composeFactionList(f),
                String.Format(yearTableStrings["gameEndWithUnite"], f.Name, f.Leader.Name), true);
            this.addPersonInGameBiography(f.Leader, date,
                String.Format(yearTableStrings["gameEndWithUnite_p"], f.Name, f.Leader.Name));
        }

        public void addAdvanceGuanjueEntry(GameDate date, Faction f, guanjuezhongleilei guanjue)
        {
            this.addTableEntry(date, composeFactionList(f), 
                String.Format(yearTableStrings["advanceGuanjue"], f.Name, guanjue.Name), true);
            this.addPersonInGameBiography(f.Leader, date,
                String.Format(yearTableStrings["advanceGuanjue_p"], f.Name, guanjue.Name));
        }

        public void addSelfAdvanceGuanjueEntry(GameDate date, Faction f, guanjuezhongleilei guanjue)
        {
            this.addTableEntry(date, composeFactionList(f),
                String.Format(yearTableStrings["selfAdvanceGuanjue"], f.Name, guanjue.Name), true);
            this.addPersonInGameBiography(f.Leader, date,
                String.Format(yearTableStrings["selfAdvanceGuanjue_p"], f.Name, guanjue.Name));
        }

        public void addCreateSpouseEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createSpouse"], p1.Name, p2.Name), false);
            this.addPersonInGameBiography(p1, date,
                String.Format(yearTableStrings["createSpouse_p"], p1.Name, p2.Name));
            this.addPersonInGameBiography(p2, date,
                String.Format(yearTableStrings["createSpouse_q"], p1.Name, p2.Name));
        }

        public void addCreateBrotherEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createBrother"], p1.Name, p2.Name), false);
            this.addPersonInGameBiography(p1, date,
                String.Format(yearTableStrings["createBrother_p"], p1.Name, p2.Name));
            this.addPersonInGameBiography(p2, date,
                String.Format(yearTableStrings["createBrother_q"], p1.Name, p2.Name));
        }

        public void addCreateSisterEntry(GameDate date, Person p1, Person p2)
        {
            this.addTableEntry(date, composeFactionList(p1.BelongedFaction, p2.BelongedFaction),
                String.Format(yearTableStrings["createSister"], p1.Name, p2.Name), false);
            this.addPersonInGameBiography(p1, date,
                String.Format(yearTableStrings["createSister_p"], p1.Name, p2.Name));
            this.addPersonInGameBiography(p2, date,
                String.Format(yearTableStrings["createSister_q"], p1.Name, p2.Name));
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
                String.Format(yearTableStrings["personDeath"], p.Name, location, p.Age), true);
            this.addPersonInGameBiography(p, date,
                String.Format(yearTableStrings["personDeath_p"], p.Name, location, p.Age));
        }

        public void addKilledInBattleEntry(GameDate date, Person killer, Person killed)
        {
            String killerFaction = killer.BelongedFaction == null ? "" : killer.BelongedFaction.Name;
            String killedFaction = killed.BelongedFaction == null ? "" : killed.BelongedFaction.Name;
            this.addTableEntry(date, composeFactionList(killer.BelongedFaction, killed.BelongedFaction),
                String.Format(yearTableStrings["personKilledInBattle"], killedFaction, killed, killerFaction, killer, killed.Age), true);
            this.addPersonInGameBiography(killer, date,
                String.Format(yearTableStrings["personKilledInBattle_p"], killedFaction, killed, killerFaction, killer, killed.Age));
            this.addPersonInGameBiography(killed, date,
                String.Format(yearTableStrings["personKilledInBattle_q"], killedFaction, killed, killerFaction, killer, killed.Age));
        }

        public void addDefeatedManyTroopsEntry(GameDate date, Person p, int count)
        {
            if ((count < 100 && count % 10 == 0) || count % 50 == 0)
            {
                this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                    String.Format(yearTableStrings["defeatedManyTroops"], p.Name, count), false);
                this.addPersonInGameBiography(p, date,
                    String.Format(yearTableStrings["defeatedManyTroops_p"], p.Name, count));
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
                    this.addPersonInGameBiography(p, date,
                        String.Format(yearTableStrings["grownBecomeAvailabeNoFaction_p"], p.Name, p.LocationArchitecture.Name));
                }
                else
                {
                    this.addTableEntry(date, composeFactionList(),
                        String.Format(yearTableStrings["grownBecomeAvailable"], p.Name, p.LocationArchitecture.Name, p.BelongedFaction.Name), false);
                    this.addPersonInGameBiography(p, date,
                        String.Format(yearTableStrings["grownBecomeAvailable_p"], p.Name, p.LocationArchitecture.Name, p.BelongedFaction.Name));
                }
            }
        }

        public void addBecomePrincessEntry(GameDate date, Person p, Person leader)
        {
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["becomePrincess"], p.Name, p.BelongedArchitecture.Name, leader.Name), false);
            this.addPersonInGameBiography(p, date,
                String.Format(yearTableStrings["becomePrincess_p"], p.Name, p.BelongedArchitecture.Name, leader.Name));
        }

        public void addOutOfPrincessEntry(GameDate date, Person p, Faction capturer)
        {
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["outOfPrincess"], p.Name, p.BelongedArchitecture.Name, capturer == null ? "贼军" : capturer.Name), false);
            this.addPersonInGameBiography(p, date,
                String.Format(yearTableStrings["outOfPrincess_p"], p.Name, p.BelongedArchitecture.Name, capturer == null ? "贼军" : capturer.Name));
        }

        public void addChangeFactionPrincessEntry(GameDate date, Person p, Faction capturer)
        {
            this.addTableEntry(date, composeFactionList(p.BelongedFaction),
                String.Format(yearTableStrings["changeFactionPrincess"], p.Name, p.BelongedArchitecture.Name, capturer == null ? "贼军" : capturer.Name, capturer == null ? "贼军" : capturer.Leader.Name), false);
            this.addPersonInGameBiography(p, date,
                String.Format(yearTableStrings["changeFactionPrincess_p"], p.Name, p.BelongedArchitecture.Name, capturer == null ? "贼军" : capturer.Name, capturer == null ? "贼军" : capturer.Leader.Name));
        }
    }
}
