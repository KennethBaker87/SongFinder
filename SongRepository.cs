using Dapper;
using System.Collections.Generic;
using SongFinder.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace SongFinder
{
    public class SongRepository :ISongRepository
    {
        private readonly IDbConnection _conn;

        public SongRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Song> GetAllSongs()
        {
            return _conn.Query<Song>("Select * From songinfo Order By Artist ASC");
        }
    }
}
