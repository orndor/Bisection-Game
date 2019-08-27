using System;

namespace Bisection_Game
{
    class Bisection
    {
        static public void OneThruTen()
        {
            int[] numList = new int[10];

            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = i + 1;
            }
            var userInput = 0;
            do
            {
                try
                {
                    Console.Write("Please select a number from 1 to 10: ");
                    userInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Not a valid number.  Please try again");
                }
            } while (userInput < 1 || userInput > 10);

            BisectionSearch(userInput, numList);
        }
        static public void OneThruThousand()
        {
            int[] numList = new int[1000];
            var matchFound = false;

            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = i + 1;
            }
            Random random = new Random();
            int randomNumber = random.Next(1001);
            var listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;
            Console.Write($"The computer's picked a number between 1 - 1000.");
            do
            {
                try
                {
                    Console.Write($"Enter a guess: ");
                    var userInput = int.Parse(Console.ReadLine());
                    if (userInput == randomNumber)
                    {
                        Console.WriteLine("You guessed the number!");
                        matchFound = true;
                    }
                    else if (userInput > randomNumber && userInput >= 0 && userInput < 1000 /*<= numList[numList.Length - 1] && userInput >= numList[0]*/)
                    {
                        Console.WriteLine("Your guess was too high.");
                        numList = GuessTooHigh(numList);


                    }
                    else if (userInput < randomNumber && userInput >= 0 && userInput < 1000 /*numList[numList.Length - 1] && userInput >= numList[0]*/)
                    {
                        Console.WriteLine("Your guess was too low.");
                        numList = GuessTooLow(numList, listMiddleValue);


                    }
                    else
                    {
                        Console.WriteLine("Your guess isn't in the appropriate range.");
                    }
                    listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid option.");
                }

            } while (matchFound == false);
        }
        static public void OneThruHundred()
        {
            int[] numList = new int[100];

            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = i + 1;
            }

            var listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;
            var matchFound = false;
            var userInput = 0;
            var menuOption = 0;
            do
            {
                try
                {
                    Console.Write("Please select a number from 1 to 100: ");
                    userInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Not a valid number.  Please try again");
                }
            } while (userInput < 1 || userInput > 100);
            do
            {
                try
                {
                    do
                    {
                        Console.WriteLine($"\nThe computer guesses {listMiddleValue}");
                        if (userInput == listMiddleValue)
                        {
                            Console.WriteLine($"The computer found the number: {userInput}");
                            matchFound = true;
                            break;
                        }
                        else if (userInput > listMiddleValue)
                        {
                            numList = GuessTooLow(numList, listMiddleValue);
                            PrintListAsString(numList);
                        }
                        else if (userInput < listMiddleValue)
                        {
                            numList = GuessTooHigh(numList);
                            PrintListAsString(numList);
                        }
                        listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;
                        Console.Write("Please input 1 for too high or 2 for too low: ");
                        menuOption = int.Parse(Console.ReadLine());
                    } while (matchFound == false);
                }
                catch
                {
                    Console.WriteLine("Not a valid number.  Please try again");
                }
            } while (menuOption < 1 || menuOption > 2);
        }

        private static void BisectionSearch(int userinput, int[] numList)
        {

            var listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;
            var matchFound = false;

            PrintListAsString(numList);

            do
            {
                if (userinput == listMiddleValue)
                {
                    Console.WriteLine($"The value ({userinput}) was found as a match.");
                    matchFound = true;
                }
                else if (userinput < listMiddleValue)
                {
                    Console.WriteLine($"The value ({userinput}) is lower than {listMiddleValue}");
                    numList = GuessTooHigh(numList);
                }
                else if (userinput > listMiddleValue)
                {
                    Console.WriteLine($"The value ({userinput}) is higher than {listMiddleValue}");
                    numList = GuessTooLow(numList, listMiddleValue);
                }
                listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;

            } while (matchFound == false);

        }
        private static int[] GuessTooLow(int[] numList, int listMiddleValue)
        {
            var startNum = listMiddleValue + 1;
            int[] newList = new int[numList.Length / 2];
            for (int i = 0; i < newList.Length; i++)
            {
                newList[i] = startNum;
                startNum += 1;
            }
            numList = newList;

            return numList;
        }

        private static int[] GuessTooHigh(int[] numList)
        {
            var startNum = numList[0];
            int[] newList = new int[numList.Length / 2];
            for (int i = 0; i < newList.Length; i++)
            {
                newList[i] = startNum;
                startNum += 1;
            }
            numList = newList;

            return numList;
        }

        private static void PrintListAsString(int[] numList)
        {
            Console.Write("The list is currently: { ");
            string listStr = string.Empty;
            foreach (var item in numList)
            {
                listStr = listStr + item + ", ";
            }
            listStr = listStr.Remove(listStr.Length - 2);
            Console.Write($"{listStr} }} \n");
        }
    }
}
