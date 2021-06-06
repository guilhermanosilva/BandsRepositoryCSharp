using System;
using System.Collections.Generic;
using bands_repository_csharp.Entities;
using bands_repository_csharp.Repositories;

namespace bands_repository_csharp.Services
{
    public class BandService : IBandService
    {
        static BandRepository repository = new BandRepository();
        static FunctionsService functionsService = new FunctionsService();

        public void ListBands()
        {
            Console.Clear();

            Console.WriteLine("_____ LIST YOUR BANDS _____");

            var bands = repository.ListRepository();

            if (CheckIfEmptyRepository(bands))
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

        public void InsertBand()
        {
            Console.Clear();

            Console.WriteLine("_____ INSERT NEW BAND _____");

            Band newBand = functionsService.GetDataToInsert(repository);

            repository.InsertBand(newBand);

        }

        public void UpdateBand()
        {
            var bands = repository.ListRepository();

            if (CheckIfEmptyRepository(bands))
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("_____ UPDATE BAND _____");

            Console.WriteLine("Enter the ID of the band:");
            string inputId = Console.ReadLine();
            inputId = functionsService.ValidadeNumber(inputId);

            int id = int.Parse(inputId);

            if (functionsService.VerifyIfBandExists(id, bands) == false)
            {
                Console.WriteLine("Band not found.");
                functionsService.WaitPressKey();
                return;
            }

            Console.WriteLine("\n_____ Band to update _____");
            Console.WriteLine(repository.ReturnBandId(id));
            Console.WriteLine();

            Band newBandUpdate = functionsService.GetDataToInsert(repository);
            repository.UpdateBand(id, newBandUpdate);
        }
        private static bool CheckIfEmptyRepository(List<Band> bands)
        {
            if (bands.Count == 0)
            {
                Console.WriteLine("\n-> There are no registered bands.");
                functionsService.WaitPressKey();
                return true;
            }
            return false;
        }

    }
}