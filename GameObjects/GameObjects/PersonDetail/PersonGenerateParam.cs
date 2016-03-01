﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using GameObjects;


namespace GameObjects.PersonDetail
{
	public  class PersonGenerateParam
	{
        public PersonGenerateParam(GameScenario scenario, Architecture foundLocation, Person finder, bool inGame, PersonGeneratorType preferredType, bool isAI)
        {
            this.scenario = scenario;
            this.foundLocation = foundLocation;
            this.finder = finder;
            this.inGame = inGame;
            this.preferredType = preferredType;
            this.isAI = isAI;
        }

        public GameScenario Scenario { get { return scenario; } }

        public Architecture FoundLocation { get { return foundLocation; } }

        public Person Finder { get { return finder; } }

        public bool InGame { get { return inGame; } }

        public PersonGeneratorType PreferredType { get { return preferredType; } }

        public bool IsAI { get { return isAI; } }

        private readonly  GameScenario scenario;
        private readonly Architecture foundLocation;
        private readonly Person finder;
        private readonly bool inGame;
        private readonly PersonGeneratorType preferredType;
        private readonly bool isAI;
	}
}
