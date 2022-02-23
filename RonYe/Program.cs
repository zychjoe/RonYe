using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace RonYe
{
    class Program
    {
        static void Main(string[] args)
        {
            pickTheFunnyOne();
        }

        public static string interactionMaker()
        {
            string statement = QuoteGenerator.KanyeQuote();
            string response = QuoteGenerator.RonQuote();
            return $"{statement}\n{response}";
        }

        public static void optionPrinter(string[] choices)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("****************************************************");
                Console.WriteLine($"{i + 1}: ");
                Console.WriteLine(choices[i]);
                Console.WriteLine("****************************************************");

            }
        }

        public static int inputIntChecker(string input)
        {
            if(int.TryParse(input, out int result) && result > 0 && result < 4)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Try again! 1, 2 or 3?");
                return inputIntChecker(Console.ReadLine());
            }
        }

        public static string yOrNChecker(string input)
        {
            var yeses = new string[] { "y", "yes" };
            var nos = new string[] { "n", "no" };
            if (Array.IndexOf(yeses, input.ToLower()) != -1){
                return "y";
            }
            else if (Array.IndexOf(nos, input.ToLower()) != -1)
            {
                return "n";
            }
            {
                Console.WriteLine("Try again! y or n?");
                return yOrNChecker(Console.ReadLine());
            }
        }


        public static void pickAnotherFunnyOne(string reigningChamp, int streak)
        {
            var choices = new string[] { reigningChamp, interactionMaker(), interactionMaker() };

            Console.WriteLine("\n\nHere are some more interactions between Kanye and Ron Swanson.");
            Console.WriteLine("Which one do you think is the funniest? 1, 2 or 3?");
            optionPrinter(choices);
            int funnyIndex = inputIntChecker(Console.ReadLine()) - 1;
            string funniest = choices[funnyIndex];
            if (funnyIndex == 0)
            {
                Console.WriteLine("Woah! that first one again?");
                Console.WriteLine($"That's been the funniest {streak++} time(s) in a row!");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Wanna try to beat it? (y/n)");
                if (yOrNChecker(Console.ReadLine()) == "n")
                {
                    Console.WriteLine("Okay. Bye!");
                    return;
                }
                pickAnotherFunnyOne(funniest, streak);

            }
            else
            {
                Console.WriteLine("Ah a new winner! Wanna see if it can last?");
                Console.WriteLine("Wanna try to beat it? (y/n)");
                if (yOrNChecker(Console.ReadLine()) == "n")
                {
                    Console.WriteLine("Okay. Bye!");
                    return;
                }
                pickAnotherFunnyOne(funniest, 1);
            }

        }

        public static void pickTheFunnyOne()
        {
            var choices = new string[] { interactionMaker(), interactionMaker(), interactionMaker() };

            Console.WriteLine("Here are some interactions between Kanye and Ron Swanson.");
            Console.WriteLine("Which one do you think is the funniest? 1, 2 or 3?");
            optionPrinter(choices);
            string funniest = choices[inputIntChecker(Console.ReadLine())-1];
            Console.WriteLine("Awesome! You picked:");
            Console.WriteLine(funniest);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Wanna find something even funnier? (y/n)");
            if (yOrNChecker(Console.ReadLine()) == "n")
            {
                Console.WriteLine("Okay. Bye!");
                return;
            }
            else
                pickAnotherFunnyOne(funniest, 1);
        }
    }
}
