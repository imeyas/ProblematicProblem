using System;
using System.Collections.Generic;
using System.Threading;


namespace ProblematicProblem
{
   public class Program
    {
        Random rng;        
        public static bool cont = true;
        public static bool seeList = true;
        public static bool addToList = true;
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var goOnYesNo = Console.ReadLine().ToLower();
            //var cont = Convert.ToBoolean(Console.ReadLine());

            if (goOnYesNo == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
                Environment.Exit(0);
            }

            //cont = (goOnYesNo == "yes") ? true : false;

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            bool userAge = int.TryParse(Console.ReadLine(), out int userAgeInput);

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
        
            var seeListAnswer = (Console.ReadLine().ToLower());

            seeList = (seeListAnswer == "Sure") ? true : false;

            //if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var addActivity = (Console.ReadLine().ToLower());

                addToList = (addActivity == "yes") ? true : false;

                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);


                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    var addActivityAgain = (Console.ReadLine());

                    addToList = (addActivityAgain == "yes") ? true : false;

                }
               
            }
            
            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Random rng = new Random();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAgeInput < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    int randomNumber2 = rng.Next(activities.Count);

                    string randomActivity2 = activities[randomNumber];
                }


                Console.Write($"Ah got it!{userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                var contAnswer =(Console.ReadLine().ToLower());

                cont = (contAnswer == "redo") ? true : false;
            } 
        }
    }
}
