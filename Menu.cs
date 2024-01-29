using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тортики
{
    internal class Menu
    {
        private List<string> options;
        private int selectedOption;

        public Menu(List<string> options)
        {
            this.options = options;
            this.selectedOption = 0;
        }

        public int Display()
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption--;
                    if (selectedOption < 0)
                    {
                        selectedOption = options.Count - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption++;
                    if (selectedOption >= options.Count)
                    {
                        selectedOption = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    return selectedOption;
                case ConsoleKey.Escape:
                    return -1;
            }

            return -2;
        }
    }
}

