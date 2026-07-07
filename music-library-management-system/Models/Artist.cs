namespace music_library_management_system.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;
    }
}
