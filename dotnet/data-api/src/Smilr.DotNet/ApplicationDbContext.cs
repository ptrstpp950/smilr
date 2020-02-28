using Smilr.DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace Smilr.DotNet
{
    /// <summary>
    /// Application DB context :)
    /// </summary>
    public class ApplicationDbContext: DbContext
    {
        /// <summary>
        /// Feedback table
        /// </summary>
        public DbSet<Feedback> Feedback { get; set; }
        /// <summary>
        /// Events table
        /// </summary>
        public DbSet<Event> Events { get; set; }
        
        /// <inheritdoc />
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasKey(c => new { c.Id, c.EventId });
        }
    }
}