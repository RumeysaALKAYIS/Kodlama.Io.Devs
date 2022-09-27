
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistense.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(k => k.Id).HasColumnName("Id");
                p.Property(k => k.Name).HasColumnName("Name");

            });


            ProgrammingLanguage[] languagesSeedData = { new (1,"C#")};
            modelBuilder.Entity<ProgrammingLanguage>().HasData(languagesSeedData);


            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(k => k.Id).HasColumnName("Id");
                t.Property(k => k.Name).HasColumnName("Name");
                t.Property(k => k.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.HasOne(k => k.ProgrammingLanguage);
            }
            );

            Technology[] technologiesSeedData = { new(1, "WPF", 1), new(2, "ASP.NET", 1), new(3, "Spring", 2) };
            modelBuilder.Entity<Technology>().HasData(technologiesSeedData);
        }
    }
}
