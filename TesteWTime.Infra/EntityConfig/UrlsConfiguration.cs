using TesteWTime.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWTime.Infra.EntityConfig
{
    public class UrlsConfiguration : EntityTypeConfiguration<Urls>
   {
      public UrlsConfiguration()
      {
          HasKey(p => p.UrlId);

          Property(p => p.Hits)
                .IsRequired();

          Property(p => p.Url).IsMaxLength()
                .IsRequired();

          Property(p => p.ShortUrl).HasMaxLength(255)
                .IsRequired();
      }
   }
}


