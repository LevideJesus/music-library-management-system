using music_library_management_system.Models;
using music_library_management_system.Repositories;

namespace music_library_management_system.Menus
{
    public class ShowMenu
    {
        private readonly ArtistRepository _repository;

        public ShowMenu(ArtistRepository repository)
        {
            _repository = repository;
        }

        private void AddArtistMenu()
        {
            Artist newArtist = new Artist();

            Console.Write("Name: ");
            newArtist.Name = Console.ReadLine();

            DateTime birthDate;

            Console.Write("Date of Birth (yyyy-MM-dd): ");

            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Write("Invalid date. Try again (yyyy-MM-dd): ");
            }

            newArtist.DateOfBirth = birthDate;

            Console.Write("Country: ");
            newArtist.Country = Console.ReadLine();

            Console.Write("Biography: ");
            newArtist.Biography = Console.ReadLine();

            _repository.AddArtist(newArtist);

            Console.WriteLine();
            Console.WriteLine("Artist added successfully.");
        }

        private void ListArtistMenu()
        {
            List<Artist> artists = _repository.GetAllArtists();

            if (artists.Count == 0)
            {
                Console.WriteLine("No artists found.");
                Pause();
                return;
            }

            foreach (Artist artist in artists)
            {
                Console.WriteLine($"Id: {artist.Id}");
                Console.WriteLine($"Name: {artist.Name}");
                Console.WriteLine($"Date of Birth: {artist.DateOfBirth:d}");
                Console.WriteLine($"Country: {artist.Country}");
                Console.WriteLine($"Biography: {artist.Biography}");
                Console.WriteLine("---------------------------");
            }
        }

        private void UpdateArtistMenu()
        {
            Console.Write("Enter the Id of the artist to update: ");

            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid Id.");
                Pause();
                return;
            }

            Artist artistToUpdate = _repository.GetArtistById(updateId);

            if (artistToUpdate == null)
            {
                Console.WriteLine("Artist not found.");
                Pause();
                return;
            }

            Console.Write($"Name ({artistToUpdate.Name}): ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
                artistToUpdate.Name = name;

            Console.Write($"Country ({artistToUpdate.Country}): ");
            string country = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(country))
                artistToUpdate.Country = country;

            Console.Write($"Biography ({artistToUpdate.Biography}): ");
            string bio = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(bio))
                artistToUpdate.Biography = bio;

            _repository.UpdateArtist(artistToUpdate);

            Console.WriteLine("Artist updated successfully.");
        }

        private void DeleteArtistMenu()
        {
            Console.Write("Enter the Id of the artist to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invalid Id.");
                Pause();
                return;
            }

            Artist artistToDelete = _repository.GetArtistById(deleteId);

            if (artistToDelete == null)
            {
                Console.WriteLine("Artist not found.");
                Pause();
                return;
            }

            Console.WriteLine($"Artist: {artistToDelete.Name}");
            Console.Write("Are you sure? (Y/N): ");

            string confirmation = Console.ReadLine();

            if (confirmation != null &&
                confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                _repository.DeleteArtist(deleteId);
                Console.WriteLine("Artist deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }
        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("===============================");
            Console.WriteLine("1 - Add Artist");
            Console.WriteLine("2 - List Artists");
            Console.WriteLine("3 - Update Artist");
            Console.WriteLine("4 - Delete Artist");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("===============================");
        }

        public void Run()
        {
            while (true)
            {
                PrintMenu();

                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int userOption))
                {
                    Console.WriteLine("Invalid option.");
                    Pause();
                    continue;
                }

                switch (userOption)
                {
                    case 1:

                        AddArtistMenu();
                        Pause();
                        break;

                    case 2:


                        ListArtistMenu();
                        Pause();
                        break;

                    case 3:

                        UpdateArtistMenu();
                        Pause();
                        break;

                    case 4:

                        DeleteArtistMenu();
                        Pause();
                        break;

                    case 0:

                        Console.WriteLine("Goodbye!");
                        return;

                    default:

                        Console.WriteLine("Invalid option.");
                        Pause();
                        break;
                }
            }
        }
    }


}
    