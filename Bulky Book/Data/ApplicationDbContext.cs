using Bulky_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Book.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
