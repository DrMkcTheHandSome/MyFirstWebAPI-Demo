using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class MyFirstWebAPIDbContext : DbContext
    {
        public MyFirstWebAPIDbContext(DbContextOptions<MyFirstWebAPIDbContext> options)
            : base(options)
        {

        }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
