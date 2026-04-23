using Microsoft.EntityFrameworkCore;
using LoveCalculatorApp.Models;

namespace LoveCalculatorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}