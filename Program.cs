﻿using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge luuukes = new Challenge("How many clones of luke skywalker exist in the expanded universe?", 3, 20);
            Challenge runts = new Challenge(@"What is the worst flavor of runts
            
            1) Banana", 1, 40);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Initialize the adventurer's robe.
            Robe robe = new Robe()
            {
                Length = 64,
                Colors = new List<string>()
            {
                "Blue",
                "Silver"
            }
            };

            // Initialize the adventurer's hat.
            Hat hat = new Hat()
            {
                ShininessLevel = 10
            };

            // Initialize the PRIZE.
            Prize theOneRing = new Prize("The one ring...");

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.Write("What is your name, adventurer? ");
            string adventurer = Console.ReadLine();
            Adventurer theAdventurer = new Adventurer(adventurer, robe, hat);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> allChallenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                luuukes,
                runts
            };


            string choice;
            do
            {
                theAdventurer.Awesomeness += Challenge.successfulChallenges * 10;
                Console.WriteLine(theAdventurer.Awesomeness);
                Console.WriteLine(theAdventurer.GetDescription());

                // Selects a random int to use as an index, and adds it to the index list, we then use that to select the challenge
                List<int> selectedChallengeIndexes = new List<int>();
                while (selectedChallengeIndexes.Count < 5)
                {
                    int random = new Random().Next(0, allChallenges.Count);
                    if (!selectedChallengeIndexes.Contains(random))
                    {
                        selectedChallengeIndexes.Add(random);
                    }
                }

                // Loop through all the challenges and subject the Adventurer to them
                foreach (int challengeIndex in selectedChallengeIndexes)
                {
                    allChallenges[challengeIndex].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                theOneRing.ShowPrize(theAdventurer);
                Console.Write("You would like to play again, correct? ");
                choice = Console.ReadLine().ToLower();
            } while (choice == "yes");
        }
    }
}