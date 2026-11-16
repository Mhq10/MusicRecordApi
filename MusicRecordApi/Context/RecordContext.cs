using Microsoft.EntityFrameworkCore;
using MusicRecordApi.Models;

namespace MusicRecordApi.Context
{
    public class RecordContext : DbContext
    {
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {
        }
        public DbSet<Record> Record { get; set; }
    }
}
