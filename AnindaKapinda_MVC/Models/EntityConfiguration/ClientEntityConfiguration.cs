using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Models.EntityConfiguration
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.ClientID).ValueGeneratedNever();
            builder.Ignore(x => x.PasswordConfirmation);
            builder.HasOne(x => x.Cart).WithOne(x => x.Client).HasForeignKey<Cart>(x => x.ClientID);
            builder.HasMany(x => x.Addresses).WithOne(x => x.Client);
            builder.HasMany(x => x.CreditCards).WithOne(x => x.Client);
        }
    }
}
