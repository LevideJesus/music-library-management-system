using music_library_management_system.Configuration;
using music_library_management_system.Data;
using music_library_management_system.Menus;
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

            ShowMenu menu = new ShowMenu(repository);

            menu.Run();
        }
    }
}





