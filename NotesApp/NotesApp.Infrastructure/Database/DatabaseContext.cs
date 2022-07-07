using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using NotesApp.Domain.Aggregates.AccountAggregate.Concrete;
using NotesApp.Domain.Aggregates.AccountAggregate.ValueObjects;
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
            modelBuilder.ApplyConfiguration(new AdminTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NoteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TextNoteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImageNoteTypeConfiguration());
            SeedInitialData(modelBuilder);
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

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Admin user creation
            Email email = new Email("admin@admin.com");
            var passwordHash = Convert.FromBase64String("97MySvzTqZrdlOaZQzWWuV4sdXl3iRe8H5LE3IE3oAEbRBht9lYmp/JvPyTxB/LGpfxvHyQVTfJpUmNAR87kRQ==");
            var passwordSalt = Convert.FromBase64String("9ZgJS2X62mbVjrvhuroKdeq9tNTWYqkz4dxfbgJl4ki36dGhncMbGUNMN9RqtdyStjyp+1ND+QUe9KhAHjbgOqXRjyZl/9imkp8onD/IMXPo4Gg+ekwG52CumwpwjlnWc72XbT+4pQbjSANELErNXCBNifxDESn1PNPp5ZSDIko=");
            var accountId = Guid.NewGuid();
            modelBuilder.Entity<Admin>(admins =>
           {
               admins.HasData(new
               {
                   Id =accountId,
                   NickName = "admin",
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   CreatedAt = DateTime.UtcNow,
                   IsDeleted = false
               });
               admins.OwnsOne(x => x.Email).HasData(new 
               {
                   Value = "admin@admin.com",
                   AccountId =accountId,
               });
              
             
           });
        }
    }
}
