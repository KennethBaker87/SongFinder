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
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }
        public string ChordProgression { get; set; }
        public string Key { get; set; }
        public int Tempo { get; set; }
        public string Genre { get; set; }
        public string SubGenre { get; set; }
        public string TimeSignature { get; set; }
        public int ChordProgressionID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
