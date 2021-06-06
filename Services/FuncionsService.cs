using System;
using System.Linq;
using bands_repository_csharp.Entities;
using bands_repository_csharp.Enums;
using bands_repository_csharp.Repositories;

namespace bands_repository_csharp.Services
{
    public class FunctionsService
    {
        public void WaitPressKey()
        {
            Console.WriteLine("Press a key to return.");
            Console.ReadKey();
        }

        public Band GetDataToInsert(BandRepository repository)
        {
            Console.WriteLine("-----  GENRES -----\n");
            ListGenres();

            Console.WriteLine();

            Console.WriteLine("\nSelect the genre of the band:");
            string genre = Console.ReadLine();
            genre = ValidateGenre(genre);

            Console.WriteLine("\nWrite the name of the band:");
            string inputName = Console.ReadLine();
            inputName = ValidadeName(inputName);

            Console.WriteLine("\nEnter the year of formation of the band:");
            string inputFormedYear = Console.ReadLine();
            inputFormedYear = ValidadeNumber(inputFormedYear);

            Console.WriteLine("\nEnter the number of albums of the band:");
            string inputNumberAlbums = Console.ReadLine();
            inputNumberAlbums = ValidadeNumber(inputNumberAlbums);

            Band band = new Band(
                Id: repository.NextId(),
                genre: (Genre)int.Parse(genre),
                name: inputName,
                formedYear: int.Parse(inputFormedYear),
                numberAlbums: int.Parse(inputNumberAlbums)
            );
            return band;
        }

        public void ListGenres()
        {
            var genreValues = Enum.GetValues(typeof(Genre));

            foreach (int i in genreValues)
            {
                Console.WriteLine($"{i}: {Enum.GetName(typeof(Genre), i)}");
            }
        }

        public string ValidateGenre(string genre)
        {
            while (CheckIfIsANumber(genre) == false || CheckIfIsAGenreNumber(int.Parse(genre)) == false)
            {
                Console.WriteLine("\n-> Please, insert a valid number:");
                genre = Console.ReadLine();
            }
            return genre;
        }

        public bool CheckIfIsAGenreNumber(int genre)
        {
            var genreValues = Enum.GetValues(typeof(Genre));

            if (genre >= 1 && genre <= genreValues.Length)
            {
                return true;
            }

            return false;
        }

        public bool CheckIfIsANumber(string value)
        {
            if (string.IsNullOrEmpty(value) || value.All(char.IsDigit) == false)
            {
                return false;
            }

            return true;
        }

        public string ValidadeName(string name)
        {
            while (string.IsNullOrEmpty(name) || name.StartsWith(" "))
            {
                Console.WriteLine("\n-> Plese, inserte a name:");
                name = Console.ReadLine();
            }

            return name;
        }

        public string ValidadeNumber(string number)
        {
            while (CheckIfIsANumber(number) == false)
            {
                Console.WriteLine("\n-> Plese, inserte a number:");
                number = Console.ReadLine();
            }

            return number;
        }
    }
}