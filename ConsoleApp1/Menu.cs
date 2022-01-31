using System;
using static System.Console;
using static System.ConsoleColor;

namespace ProgrammeringUppgifter
{
    public class Menu
    {
        private int OptionIndex;
        private string[] MenuOptions;
        public Menu(string [] Options)
        {
            MenuOptions = Options;
            OptionIndex = 1;
        }

        private void DisplayOptions(bool MenuTextColor)
        {
            for(int i = 0; i < MenuOptions.Length; i++)
            {
                string currentOption = MenuOptions[i];
                if(i == OptionIndex)
                {
                    if (MenuTextColor)
                    {
                        ForegroundColor = Red;
                        BackgroundColor = White;
                    }
                    else
                    {
                        ForegroundColor = Black;
                        BackgroundColor = White;
                    }
                }
                else
                {
                    ForegroundColor = White;
                    BackgroundColor = Black;
                }
                WriteLine($"<< {currentOption} >>");
            }
            ResetColor();
        }
        public int RunMenu(bool MenuTextColor)
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                DisplayOptions(MenuTextColor);
                keyPressed = ReadKey(true).Key;

                if(keyPressed == ConsoleKey.UpArrow && OptionIndex > 0)
                {
                    OptionIndex--;
                }
                else if(keyPressed == ConsoleKey.DownArrow && OptionIndex < MenuOptions.Length - 1)
                {
                    OptionIndex++;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return OptionIndex;
        }
    }
}
