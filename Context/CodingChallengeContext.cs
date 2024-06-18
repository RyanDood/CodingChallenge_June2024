using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Context
{
    public class CodingChallengeContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public CodingChallengeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
