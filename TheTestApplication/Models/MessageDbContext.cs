using Microsoft.EntityFrameworkCore;

namespace TheTestApplication.Models
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
        {
        }

        public DbSet<MessageEntry> Messages { get; set; }
    }
}
