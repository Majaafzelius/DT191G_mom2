namespace uppgift1.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public string? Album { get; set; }
        public string Artist { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public SongModel() { }

        public SongModel(string name, string album, string artist, DateTime releaseDate)
        {
            Name = name;
            Album = album;
            Artist = artist;
            ReleaseDate = releaseDate;
        }
    }
}
