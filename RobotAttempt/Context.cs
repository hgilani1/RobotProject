using System;
using Microsoft.EntityFrameworkCore;

namespace RobotAttempt
{
    [Keyless]
    public class RobotContext : DbContext
    {
        public RobotContext(DbContextOptions<RobotContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}

