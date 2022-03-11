using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ParseData
{
    class ManagerData
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\data.txt";
        private string DynamicPATH;

        public void Manager()
        {
            while (true)
            {
                Console.Write("Menu:" +
                              "\n1 - Parse data from console;" +
                              "\n2 - Parse data from file;" +
                              "\nr - Reload;" +
                              "\nq - exit." +
                              "\n");
                Console.WriteLine("Choose action:");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        ConsoleData();
                        break;
                    case ConsoleKey.NumPad2:
                        FileData();
                        break;
                    case ConsoleKey.R:
                        Reload();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ConsoleData()
        {
            var console = new ConsoleParse();
            console.Data();
        }

        private void FileData()
        {
            var file = new FileParse();
            Console.Write("1 - Input path to .txt file;" +
                            "\n2 - Use default path;" +
                            "\n3 - back;" +
                            "\n");
            Console.WriteLine("Choose action:");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            switch (key)
            {
                case ConsoleKey.NumPad1:
                    file.Data(Path.GetFullPath(Console.ReadLine()));
                    break;
                case ConsoleKey.NumPad2:
                    file.Data(PATH);
                    break;
                case ConsoleKey.NumPad3:
                    break;
                default:
                    break;
            }
        }

        private void Reload()
        {
            Console.Clear();
        }

    }
}
