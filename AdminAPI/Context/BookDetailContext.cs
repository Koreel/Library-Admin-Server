using Microsoft.EntityFrameworkCore;
using AdminAPI.Models;
namespace AdminAPI.Context
{
    public class BookDetailContext : DbContext
    {
        public BookDetailContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<BookDetail> BookDetails  { get; set; }
    }
}

