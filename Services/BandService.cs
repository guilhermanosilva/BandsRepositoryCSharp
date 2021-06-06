using System;
using System.Collections.Generic;
using bands_repository_csharp.Entities;
using bands_repository_csharp.Repositories;

namespace bands_repository_csharp.Services
{
    public class BandService : IBandService
    {
        static BandRepository respository = new BandRepository();
        static Validations validate = new Validations();

        public void ListBands()
        {
            Console.Clear();

            Console.WriteLine("_____ LIST YOUR BANDS _____");

            var bands = respository.ListRepository();

            if (CheckIfEmptyRepository(bands) == true)
            {
                return;
            }

            foreach (var band in bands)
            {
                var deleted = band.getDeleted();

                if (deleted == false)
                {
                    Console.WriteLine($"#ID: {band.getId()} - {band.getName()} {(deleted ? "Deleted!" : "")}");
                }
            }

            Console.WriteLine("\nPress a key do return");
            Console.ReadKey();
        }

        private static bool CheckIfEmptyRepository(List<Band> bands)
        {
            if (bands.Count == 0)
            {
                Console.WriteLine("\n-> There are no registered bands.");
                validate.WaitPressKey();
                return true;
            }
            return false;
        }
    }
}