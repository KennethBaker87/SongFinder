namespace SongFinder.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string ReleaseDate { get; set; }
        public int TrackNumber { get; set; }
        public string Label { get; set; }
        public string Producer { get; set; }
        public byte[] AlbumArt { get; set; }
    }
}
