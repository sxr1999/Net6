using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }
        public DbSet<team> Team { get; set; }
    }
}
