using music_library_management_system.Configuration;
using music_library_management_system.Data;
using music_library_management_system.Models;
using music_library_management_system.Repositories;

namespace music_library_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DatabaseConfiguration config = new DatabaseConfiguration
            {
                Server = "localhost",
                Database = "music_library",
                Username = "root",
                Password = "levizao"
            };
           

           DatabaseConnection databaseConnection = new DatabaseConnection(config);

           ArtistRepository repository = new ArtistRepository(databaseConnection);

           List<Artist> artists = repository.GetAllArtists();
            
           foreach (Artist using music_library_management_system.Configuration;
using music_library_management_system.Data;
using music_library_management_system.Models;
using music_library_management_system.Repositories;

namespace music_library_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DatabaseConfiguration config = new DatabaseConfiguration
            {
                Server = "localhost",
                Database = "music_library",
                Username = "root",
                Password = "levizao"
            };
           

           DatabaseConnection databaseConnection = new DatabaseConnection(config);

           ArtistRepository repository = new ArtistRepository(databaseConnection);
           Artist artist = new Artist
           {
                    Name = "Michael Jackson",
                    DateOfBirth = new DateTime(1958, 8, 29),
                    Country = "United States",
                    Biography = "King of Pop"
           };
                repository.AddArtist(artist);


           List<Artist> artists = repository.GetAllArtists();
            
           foreach (Artist artist in artists)
           {
                Console.WriteLine($"Id: {artist.Id}");
                Console.WriteLine($"Name: {artist.Name}");
                Console.WriteLine($"Date of Birth: {artist.DateOfBirth:d}");
                Console.WriteLine($"Country: {artist.Country}");
                Console.WriteLine($"Biography: {artist.Biography}");
                Console.WriteLine("------------------------");
           }



            Artist artist = new Artist
            {
                Name = "Michael Jackson",
                DateOfBirth = new DateTime(1958, 8, 29),
                Country = "United States",
                Biography = "King of Pop"
            };

            repository.AddArtist(artist);

        }

        
    }
}
 in artists)
           {
                Console.WriteLine($"Id: {artist.Id}");
                Console.WriteLine($"Name: {artist.Name}");
                Console.WriteLine($"Date of Birth: {artist.DateOfBirth:d}");
                Console.WriteLine($"Country: {artist.Country}");
                Console.WriteLine($"Biography: {artist.Biography}");
                Console.WriteLine("------------------------");
           }



            Artist artist = new Artist
            {
                Name = "Michael Jackson",
                DateOfBirth = new DateTime(1958, 8, 29),
                Country = "United States",
                Biography = "King of Pop"
            };

            repository.AddArtist(artist);

        }

        
    }
}
