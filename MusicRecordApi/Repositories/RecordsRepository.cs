using MusicRecordApi.Interfaces;
using MusicRecordApi.Models;

namespace MusicRecordApi.Repositories
{
    public class RecordsRepository : IRecordInterface
    {
        private List<Record> _data = new List<Record>
        {
            new Record { Id = 1, Title = "Back in Black", Artist = "ACDC", Duration = 180, Genre = "Rock", Year = 2020 },
            new Record { Id = 2, Title = "Painkiller", Artist = "Judas Priest", Duration = 200, Genre = "Hard Rock", Year = 2021 },
            new Record { Id = 3, Title = "The Eminem Show", Artist = "Eminem", Duration = 150, Genre = "Hip Hop", Year = 2019 }
        };
        public RecordsRepository()
        {
            
        }

        public Record AddRecord(Record record)
        {
            _data.Add(record);
            return record;
        }

        public Record? DeleteRecord(int id)
        {
            var record = _data.FirstOrDefault(r => r.Id == id);

            if (record != null)
            {
                _data.Remove(record);
            }
            return record;
        }

        public List<Record> GetAllRecords(string? title = null, string? artist = null, string? genre = null, int? year = null)
        {

            List<Record> _records = _data;

            if (title != null)
            {
                _records = _records.Where(r => r.Title.Contains(title)).ToList();
            }
            if (artist != null)
            {
                _records = _records.Where(r => r.Artist.Contains(artist)).ToList();
            }
            if (genre != null)
            {
                _records = _records.Where(r => r.Genre.Contains(genre)).ToList();
            }
            if (year != null && year != 0)
            {
                _records = _records.Where(r => r.Year == year).ToList();
            }

            return _records;
        }

        public Record UpdateRecord(Record record)
        {

            var existingRecord = _data.FirstOrDefault(r => r.Id == record.Id);
            if (existingRecord != null)
            {
                existingRecord.Title = record.Title;
                existingRecord.Artist = record.Artist;
                existingRecord.Duration = record.Duration;
                existingRecord.Genre = record.Genre;
                existingRecord.Year = record.Year;
            }

            return existingRecord ?? throw new ArgumentException("Record not found");
        }
    }
}
