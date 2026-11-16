using MusicRecordApi.Models;

namespace MusicRecordApi.Interfaces
{
    public interface IRecordInterface
    {
        List<Record> GetAllRecords(string? title = null, string? artist = null, string? genre = null, int? year = null);

        Record AddRecord(Record record);

        Record UpdateRecord(Record record);

        Record? DeleteRecord(int id);
    }
}
