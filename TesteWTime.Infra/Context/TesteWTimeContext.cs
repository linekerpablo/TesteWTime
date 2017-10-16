using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteWTime.Domain.Entities;
using TesteWTime.Infra.EntityConfig;

namespace TesteWTime.Infra.Context
    {
        public class TesteWTimeContext : DbContext
        {
            public TesteWTimeContext()
                : base("TesteWTime")
            {
                  this.Configuration.LazyLoadingEnabled = true;
            }

            public DbSet<Urls> Urlss { get; set; }
            public DbSet<Users> Userss { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

                modelBuilder.Properties()
                    .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                    .Configure(p => p.IsKey());

                modelBuilder.Properties<string>()
                    .Configure(p => p.HasColumnType("varchar"));

                modelBuilder.Properties<string>()
                    .Configure(p => p.HasMaxLength(80));

                modelBuilder.Configurations.Add(new UrlsConfiguration());
                modelBuilder.Configurations.Add(new UsersConfiguration());
            }

            public override int SaveChanges()
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }

                return base.SaveChanges();
            }
        }
    }

