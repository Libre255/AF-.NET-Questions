using System;
using static System.Console;
using static System.ConsoleColor;
using System.IO;

namespace ProgrammeringUppgifter
{
    static public class Questions
    {
        static private string[] MenuOptions =
        {
            "1.Greet with a ''Hello World!''",
            "2.Present yourself!",
            "3.Change console Color",
            "4.Get current Date",
            "5.Check the highest number",
            "6.Guess the random Nr!",
            "7.Save your textline in your Harddrive",
            "8.Read your text file!",
            "9.Do some maths",
            "10.See the multiplication tabel",
            "11.Working with arrays algorithms",
            "12.Palidrome string",
            "13.Middle numbers separation",
            "14.Odd and even numbers",
            "15.Add all your numbers!",
            "16.Dragon Ball Z Fight!",
            "Exit"
        };
        static private bool ConsoleColorRed = false;

        static public void Run(bool MenuTextColor = false)
        {
            Menu MainMenu = new Menu(MenuOptions);

            int OptionIndex = MainMenu.RunMenu(MenuTextColor);

            switch (OptionIndex)
            {
                case 0: SayHello(); break;
                case 1: PresentYourself(); break;
                case 2: ChangeConsoleColor(); break;
                case 3: PrintCurrentDate(); break;
                case 4: CheckHighestNr(); break;
                case 5: GuessTheRandomNr(); break;
                case 6: SaveTextlineInHDD(); break;
                case 7: ReadTextFile(); break;
                case 8: DoSomeMaths(); break;
                case 9: MultiplicationTabel(); break;
                case 10: ArrayAlgorithms(); break;
                case 11: PalindromeString(); break;
                case 12: MiddleNrSeparation(); break;
                case 13: OddEvenNrs(); break;
                case 14: AddAllNrs(); break;
                case 15: DBZFight(); break;
                case 16: ExitMenu(); break;
            }
            Clear();
        }

        static private void ExitMenu()
        {
            WriteLine("Exited the console");
        }
        static private void ReRunMenu() {
            WriteLine("<< Press any key to go back to the menu >>");
            ReadKey(true);
            Run();
        }

        static private void SayHello()
        {
            Clear();
            WriteLine("Hello World");
            ReRunMenu();
        }
        static private void PresentYourself()
        {
            Clear();
            WriteLine("Please Write your first name");
            string name = ReadLine();
            WriteLine("Please Write your last name");
            string lastName = ReadLine();
            WriteLine("Please Write your Age");
            int ageAnswer = NrValidator();

            WriteLine($"Your full name is {name} {lastName} and your age is {ageAnswer}");
            ReRunMenu();
        }

        static private void ChangeConsoleColor()
        {
            ConsoleColorRed = !ConsoleColorRed;
            Run(ConsoleColorRed);
        }
        static private void PrintCurrentDate()
        {
            Clear();
            DateTime dateTime = DateTime.UtcNow.Date;
            WriteLine("Todays date is " + dateTime.ToString("yyyy/MM/dd"));
            ReRunMenu();
        }
        static private void CheckHighestNr()
        {
            Clear();
            WriteLine("Write your first number");
            var nr1 = NrValidator();
            WriteLine("Write your second number");
            var nr2 = NrValidator();
            if (nr1 > nr2)
            {
                WriteLine("Your highest number is " + nr1);
            } else
            {
                WriteLine("Your highest number is " + nr2);
            }

            ReRunMenu();
        }

        static private int NrValidator()
        {
            int checkRuns = 1;
            int numberOutput;
            string input;
            do
            {
                if (checkRuns >= 2)
                {
                    WriteLine("You can only write numbers, please try again");
                }
                input = ReadLine();
                checkRuns++;
            } while (int.TryParse(input, out numberOutput) == false);
            return numberOutput;
        }
        static private void GuessTheRandomNr()
        {
            Clear();
            int randomNr = new Random().Next(1, 6);
            WriteLine("Guess the random number! (From 1 to 5)");
            int userAnswer = NrValidator();
            int amountTries = 1;
            do
            {
                amountTries++;
                userAnswer = NrValidator();
            } while (randomNr != userAnswer);

            WriteLine("Congratulations! You found the correct number which was " + randomNr + ".");
            WriteLine("You tried " + amountTries + " Times");
            ReRunMenu();
        }
        static private void SaveTextlineInHDD()
        {
            Clear();
            WriteLine("Write the textline and then enter to save");
            string userInput = ReadLine();
            File.WriteAllText(@"D:\myTextFile.txt", userInput);

            WriteLine("You will see your file in the D harddrive");
            ReRunMenu();
        }
        static private void ReadTextFile()
        {
            Clear();
            string fileTxt = File.ReadAllText(@"D:\myTextFile.txt");
            WriteLine("Below you will see the text that you writed in your txt file");
            WriteLine(fileTxt);
            ReRunMenu();
        }
        static private void DoSomeMaths()
        {
            Clear();
            WriteLine("In todays math we gonna take the square of your number, elevated it by 2 and 10");
            WriteLine("Write your number below");
            double userNumber;
            while (!Double.TryParse(ReadLine(), out userNumber))
            {
                WriteLine("You can only write numbers with decimals, try again");
            }
            WriteLine("The square of your number is " + Math.Sqrt(userNumber));
            WriteLine("The raise of 2 of your number is " + Math.Pow(userNumber, 2));
            WriteLine("The raise of 10 of your number is " + Math.Pow(userNumber, 10));

            ReRunMenu();
        }
        static private void MultiplicationTabel()
        {
            Clear();
            WriteLine("Here you have the multiplication tabel from 1 to 10");
            WriteLine("(Make your window wider if the columns are desorganized)");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 1; i < 11; i++)
            {
                int checkDoubleDigit = numbers[0] * i;
                if (checkDoubleDigit > 9)
                {
                    WriteLine($"1 * {i} = {numbers[0] * i,0}| 2 * {i} = {numbers[1] * i,0}| 3 * {i} = {numbers[2] * i,0}" +
                    $"| 4 * {i} = {numbers[3] * i,0}| 5 * {i} = {numbers[4] * i,0}| 6 * {i} = {numbers[5] * i,0}" +
                    $"| 6 * {i} = {numbers[5] * i,0}| 7 * {i} = {numbers[6] * i,0}| 8 * {i} = {numbers[7] * i,0}" +
                    $"| 9 * {i} = {numbers[8] * i,0}| 10 * {i} = {numbers[9] * i,0}");
                }
                else
                {
                    WriteLine($"1 * {i} = {numbers[0] * i,-3}| 2 * {i} = {numbers[1] * i,-3}| 3 * {i} = {numbers[2] * i,-3}" +
                    $"| 4 * {i} = {numbers[3] * i,-3}| 5 * {i} = {numbers[4] * i,-3}| 6 * {i} = {numbers[5] * i,-3}" +
                    $"| 6 * {i} = {numbers[5] * i,-3}| 7 * {i} = {numbers[6] * i,-3}| 8 * {i} = {numbers[7] * i,-3}" +
                    $"| 9 * {i} = {numbers[8] * i,-3}| 10 * {i} = {numbers[9] * i,-3}");
                }
            }
            ReRunMenu();
        }
        static private void ArrayAlgorithms()
        {
            Clear();
            int[] randomArray = new int[3];
            int[] sortedArray = new int[3];
            int temp = 0;
            for (int i = 0; i < 3; i++)
            {
                Random rndNr = new Random();
                randomArray[i] = rndNr.Next(1, 10);
            }
            WriteLine("The random array");
            foreach (int i in randomArray)
            {
                WriteLine(" " + i);
            }

            for (int i = 0; i <= randomArray.Length - 1; i++)
            {
                for (int j = i + 1; j < randomArray.Length; j++)
                {
                    if (randomArray[i] > randomArray[j])
                    {
                        temp = randomArray[i];
                        randomArray[i] = randomArray[j];
                        randomArray[j] = temp;
                    }
                }
            }

            sortedArray = randomArray;
            WriteLine("The sorted array");
            foreach (int i in sortedArray)
            {
                WriteLine(" " + i);
            }

            ReRunMenu();
        }
        static private void PalindromeString()
        {
            Clear();
            WriteLine("Write your word and i will check if its a palindrome");
            string userInput = ReadLine();

            bool checkForWhiteSpace = userInput.Any(x => Char.IsWhiteSpace(x));

            while (checkForWhiteSpace)
            {
                WriteLine("You cant use space. Write only 1 word");
                userInput = ReadLine();
                checkForWhiteSpace = userInput.Any(x => Char.IsWhiteSpace(x));
            }

            string firstL = userInput.Substring(0, 1);
            string lastL = userInput.Substring(userInput.Length - 1);
            bool isPalindrome = firstL.Equals(lastL);

            if (isPalindrome)
            {
                WriteLine("Yes, your word is palindrome!");
            }
            else
            {
                WriteLine("No, your word is not palindrome");
            }


            ReRunMenu();
        }
        static private void MiddleNrSeparation()
        {
            Clear();
            WriteLine("Write the first number");
            int nr1 = NrValidator();
            WriteLine("Write the second number");
            int nr2 = NrValidator();

            int[] betweenNrs;
            if (nr1 < nr2)
            {
                betweenNrs = Enumerable.Range(nr1 + 1, nr2 - nr1).ToArray();
            }
            else
            {
                betweenNrs = Enumerable.Range(nr2 + 1, nr1 - nr2).ToArray();
            }

            WriteLine("The numbers in between are:");
            for (int i = 0; i < betweenNrs.Length -1; i++)
            {
                WriteLine("*" + betweenNrs[i]);
            }
           
            ReRunMenu();
        }
        static private void OddEvenNrs()
        {
            Clear();
            WriteLine("Write all your numbers separating them with comma");
            int[] userNrs = FindAllNrs();

            List<int> oddNrs = new List<int>();
            List<int> evenNrs = new List<int>();
            for (int i = 0; i < userNrs.Length; i++)
            {
                if (userNrs[i] % 2 != 0)
                {
                    oddNrs.Add(userNrs[i]);
                }
                else
                {
                    evenNrs.Add(userNrs[i]);
                }
            }
            WriteLine("the Odd numbers are:");
            foreach (int i in oddNrs)
            {
                WriteLine(" " + i);
            }
            WriteLine("The Even numbers are:");
            foreach (int i in evenNrs)
            {
                WriteLine(" " + i);
            }
            ReRunMenu();
        }
        static private void AddAllNrs()
        {
            Clear();
            WriteLine("Write all your numbers and separate them with comma");
            int[] userNrs = FindAllNrs();
            int theTotalSum = 0;
            foreach (int i in userNrs)
            {
                theTotalSum += i;
            }

            WriteLine("The total sum is " + theTotalSum);
            ReRunMenu();
        }

        static private int[] FindAllNrs()
        {
            string userInput = ReadLine();
            var cutNrs = userInput.Where(Char.IsDigit).ToArray();
            int[] cutNrsInt = Array.ConvertAll(cutNrs, c => (int)Char.GetNumericValue(c));
            return cutNrsInt;
        }
        static private void DBZFight()
        {
            Clear();
            int randomNr = new Random().Next(0, 2);

            WriteLine("Welcom to the Dragon Ball Z arena fight!");
            WriteLine("please write your name");
            
            Character user = new Character();
            string userName = ReadLine();
            user.name = userName;
            user.Turn = randomNr == 1 ? true : false;

            WriteLine("please write your oponent name");
            Character enemy = new Character();
            string enemyName = ReadLine();
            enemy.name = enemyName;
            enemy.Turn = !user.Turn;

            WriteLine("                   [Arena]                ");
            WriteLine($"..........{user.name}...........");
            WriteLine(" * Health: " + user.Health);
            WriteLine(" * Strenght: " + user.Strenght);
            WriteLine(" * Turn: " + user.Turn);
            WriteLine("------------------- VS -------------------");
            WriteLine($"..........{enemy.name}...........");
            WriteLine(" * Health: " + enemy.Health);
            WriteLine(" * Strenght: " + enemy.Strenght);
            WriteLine(" * Turn: " + enemy.Turn);
            ReRunMenu();
        }
    }
    public class Character{
        public string name;
        public int Health = new Random().Next(1,101);
        public int Strenght = new Random().Next(100, 9001);
        public bool Turn;
    }
}
