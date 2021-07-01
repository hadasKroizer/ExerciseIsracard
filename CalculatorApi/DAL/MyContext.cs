using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public DbSet<Exercise> Exercises { get; set; }

    }
}
