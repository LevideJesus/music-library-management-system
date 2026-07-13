using music_library_management_system.Data;
using music_library_management_system.Models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;


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

        public List<Artist> GetAllArtists()
        {
            List<Artist> artists = new List<Artist>();

            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = @"SELECT 
                                    Id, 
                                    Name, 
                                    DateOfBirth, 
                                    Country, 
                                    Biography
                                    FROM Artists;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Artist artist = new Artist();
                            artist.Id = reader.GetInt32("Id");
                            artist.Name = reader.GetString("Name");
                            artist.DateOfBirth = reader.GetDateTime("DateOfBirth");
                            artist.Country = reader.GetString("Country");
                            artist.Biography = reader.GetString("Biography");

                            artists.Add(artist);
                        }
                       
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error while reading artists: {ex.Message}");
                }
            }

            return artists;
        }

        public void UpdateArtist(Artist artist)
        {
            using (MySqlConnection connection = _databaseConnection.GetConnection())
            {
                try
                {
                    string query = @"UPDATE Artists 
                                    SET
                                     Name = @Name, 
                                     DateOfBirth = @DateOfBirth, 
                                     Country = @Country, 
                                     Biography = @Biography
                                    WHERE Id = @Id
                                    ;";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Id", artist.Id);
                        command.Parameters.AddWithValue("@Name", artist.Name);
                        command.Parameters.AddWithValue("@DateOfBirth", artist.DateOfBirth);
                        command.Parameters.AddWithValue("@Country", artist.Country);
                        command.Parameters.AddWithValue("@Biography", artist.Biography);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine($"Error while updating artists: {ex.Message}");

                }
            }
        }


    }
}
