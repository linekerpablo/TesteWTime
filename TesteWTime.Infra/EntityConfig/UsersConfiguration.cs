using TesteWTime.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWTime.Infra.EntityConfig
{
    public class UsersConfiguration : EntityTypeConfiguration<Users>
   {
      public UsersConfiguration()
      {
          HasKey(p => p.UserId);

          Property(p => p.Name).HasMaxLength(255)
                .IsRequired();

      }
   }
}


