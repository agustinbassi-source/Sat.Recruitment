using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
