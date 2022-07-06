using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Infrastructure.Configurations;
using SeedWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Database
{
    public class DatabaseContext:DbContext
    {
        public virtual DbSet<Account> Accounts { get; }
        public virtual DbSet<Note> Notes { get; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StandartUserTypeConfigurtion());
            modelBuilder.ApplyConfiguration(new NoteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TextNoteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImageNoteTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
                ((BaseModel)entityEntry.Entity).Updated();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
                ((BaseModel)entityEntry.Entity).Updated();

           return base.SaveChangesAsync(cancellationToken);
        }
    }
}
