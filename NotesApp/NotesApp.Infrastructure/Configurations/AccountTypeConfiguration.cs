using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesApp.Domain.Aggregates.AccountAggregate.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //Before defining, there are two different applications of abstractions in relational databases.
            //These are TPH and TPT. Efcore recommends TPT for performance,
            //but Horizontal growth of the Table is more of an issue than performance.
            //So I will use the TPT approach.
            builder.ToTable("accounts");
            // for performance 
            builder.HasIndex(x => x.Email).IsUnique(true);
            // Value object Settings
            builder.OwnsOne(x => x.Email);

        }
    }
}
