using MusicRecordApi.Context;
using MusicRecordApi.Interfaces;
using MusicRecordApi.Models;

namespace MusicRecordApi.Repositories
{
    public class RecordsRepository : IRecordInterface
    {
        private RecordContext _context;
        
        
        public RecordsRepository(RecordContext context)
        {
            _context = context;
        }

        public Record AddRecord(Record record)
        {
            _context.Record.Add(record);
            _context.SaveChanges();
            return record;
        }

        public Record? DeleteRecord(int id)
        {
            var record = _context.Record.FirstOrDefault(r => r.Id == id);

            if (record != null)
            {
                _context.Record.Remove(record);
                _context.SaveChanges();
            }
            return record;
        }

        public List<Record> GetAllRecords(string? title = null, string? artist = null, string? genre = null, int? year = null)
        {

            List<Record> _records = _context.Record.ToList();

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

            var existingRecord = _context.Record.FirstOrDefault(r => r.Id == record.Id);
            if (existingRecord != null)
            {
                existingRecord.Title = record.Title;
                existingRecord.Artist = record.Artist;
                existingRecord.Duration = record.Duration;
                existingRecord.Genre = record.Genre;
                existingRecord.Year = record.Year;
                _context.Update(existingRecord);
                _context.SaveChanges();
            }

            return existingRecord ?? throw new ArgumentException("Record not found");
        }
    }
}
