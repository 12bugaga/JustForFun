using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Xml;
using Test.Infrastructure.DataModels;
using Test.Infrastructure.DataModels.Common;

namespace Test.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<JsonTask> JsonTasks { get; set; }
        public DbSet<Log> Logs { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionLog>().Property(t => t.CreatedAt).HasColumnType("datetime2(7)").HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Log>().Property(t => t.CreatedAt).HasColumnType("datetime2(7)").HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Log>().Property(t => t.Id).HasColumnType("uniqueidentifier").HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<JsonTask>()
                        .Property(e => e.Id)
                        .ValueGeneratedNever();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(System.Console.WriteLine);
        }
    }
}
