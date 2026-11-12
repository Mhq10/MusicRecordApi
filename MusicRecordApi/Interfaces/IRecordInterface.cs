using MusicRecordApi.Models;

namespace MusicRecordApi.Interfaces
{
    public interface IRecordInterface
    {
        List<Record> GetAllRecords(string? title = null, string? artist = null, string? genre = null, int? year = null);
    }
}
