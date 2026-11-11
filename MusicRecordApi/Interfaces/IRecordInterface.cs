using MusicRecordApi.Models;

namespace MusicRecordApi.Interfaces
{
    public interface IRecordInterface
    {
        List<Record> GetAllRecords();
    }
}
