using music_library_management_system.Configuration;
using MySql.Data.MySqlClient;


namespace music_library_management_system.Data
{
    public class DatabaseConnection
    {
        private readonly DatabaseConfiguration _config;

        public DatabaseConnection(DatabaseConfiguration config)
        {
            _config = config;
        }
        public string GetConnectionString()
        {
            return $"Server={_config.Server};Database={_config.Database};Uid={_config.Username};Pwd={_config.Password};";

        }
        public MySqlConnection GetConnection()
        {
           
            return new MySqlConnection(GetConnectionString());
            
        }
        

    }
}
