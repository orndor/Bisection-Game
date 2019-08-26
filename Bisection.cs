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

        }
        static public void OneThruHundred()
        {
            //Random random = new Random();
            //int randomNumber = random.Next(10);
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
                    var startNum = numList[0];
                    int[] newList = new int[numList.Length / 2];
                    for (int i = 0; i < newList.Length; i++)
                    {
                        newList[i] = startNum;
                        startNum += 1;
                    }
                    numList = newList;

                    PrintListAsString(numList);
                }
                else if (userinput > listMiddleValue)
                {
                    Console.WriteLine($"The value ({userinput}) is higher than {listMiddleValue}");

                    var startNum = listMiddleValue + 1;
                    int[] newList = new int[numList.Length / 2];
                    for (int i = 0; i < newList.Length; i++)
                    {
                        newList[i] = startNum;
                        startNum += 1;
                    }
                    numList = newList;

                    PrintListAsString(numList);
                }
                listMiddleValue = (numList[0] + numList[numList.Length - 1]) / 2;

            } while (matchFound == false);

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
