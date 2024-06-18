using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Context
{
    public class CodingChallengeContext : DbContext
    {
        public CodingChallengeContext(DbContextOptions options) : base(options)
        {

        }
    }
}
