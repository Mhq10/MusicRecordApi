using MusicRecordApi.Interfaces;
using MusicRecordApi.Models;

namespace MusicRecordApi.Repositories
{
    public class RecordsRepository : IRecordInterface
    {
        private List<Record> _records = new List<Record>
        {
            new Record { Id = 1, Title = "Back in Black", Artist = "ACDC", Duration = 180, Genre = "Rock", Year = 2020 },
            new Record { Id = 2, Title = "Record 2", Artist = "Artist 2", Duration = 200, Genre = "Pop", Year = 2021 },
            new Record { Id = 3, Title = "Record 3", Artist = "Artist 3", Duration = 150, Genre = "Hip Hop", Year = 2019 }
        };
        public RecordsRepository()
        {
            
        }

        public List<Record> GetAllRecords()
        {
            return _records;
        }
    }
}
