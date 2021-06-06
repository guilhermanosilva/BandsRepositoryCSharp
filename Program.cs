using System;
using bands_repository_csharp.Services;

namespace bands_repository_csharp
{
    class Program
    {
        static BandService service = new BandService();
        static void Main(string[] args)
        {
            string userOption = Menu();

            while (true)
            {
                switch (userOption)
                {
                    case "1":
                        service.ListBands();
                        break;
                    case "2":
                        service.InsertBand();
                        break;
                    case "3":
                        Console.WriteLine("UpdateBand();");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("ShowBand();");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("DeleteBand();");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("\n--> Invalid option.");
                        Console.WriteLine("\nPress a key to return");
                        Console.ReadLine();
                        break;
                }
                userOption = Menu();
            }
        }

        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine("At any time press (ctrl + c) to exit!\n");
            Console.WriteLine("_____ REPOSITORY OF MY BEST BANDS _____");
            Console.WriteLine("\n_____ OPTIONS _____");

            Console.WriteLine("1 - List bands");
            Console.WriteLine("2 - Insert new band");
            Console.WriteLine("3 - Update band");
            Console.WriteLine("4 - Show band detail");
            Console.WriteLine("5 - Delete band");

            Console.WriteLine("\nWrite your option:");
            string userOption = Console.ReadLine();

            return userOption;
        }

    }
}
