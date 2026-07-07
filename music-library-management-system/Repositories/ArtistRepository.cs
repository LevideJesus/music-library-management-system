using music_library_management_system.Data;
using music_library_management_system.Models;
using MySql.Data.MySqlClient;


namespace music_library_management_system.Repositories
{
    public class ArtistRepository
    {
        private readonly DatabaseConnection _databaseConnection;


        public ArtistRepository(DatabaseConnection config)
        {
            _databaseConnection = config;
        }

        public void AddArtist(Artist artist)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query =
                        @"INSERT INTO Artists
                    (Name, DateOfBirth, Country, Biography)
                    VALUES
                    (@Name, @DateOfBirth, @Country, @Biography)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", artist.Name);
                        command.Parameters.AddWithValue("@DateOfBirth", artist.DateOfBirth);
                        command.Parameters.AddWithValue("@Country", artist.Country);
                        command.Parameters.AddWithValue("@Biography", artist.Biography);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    
                       
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error while adding artist: {ex.Message}");
                }
            }
        }
    }
}
