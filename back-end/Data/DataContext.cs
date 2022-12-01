using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { }

        public DbSet<Categories> Categories { get; set; }
    }
}
