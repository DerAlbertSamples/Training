using System;
using System.Data.Entity;
using Training.Web.Entities;

namespace Training.Web.Data
{
    public class TrainingContext : DbContext
    {
        public IDbSet<Person> Personen { get; set; }
        public IDbSet<Firma> Firmen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Personen");
            modelBuilder.Entity<Firma>().ToTable("Firmen");
            modelBuilder.Entity<Dokument>().ToTable("Dokumente");
            modelBuilder.Entity<Abteilung>().ToTable("Abteilungen");

            modelBuilder.Entity<Abteilung>()
                        .HasMany(a => a.Personen);

            modelBuilder.Entity<Abteilung>()
                        .HasMany(a => a.Dokumente).WithMany();

            modelBuilder.Entity<Firma>()
                        .HasMany(f => f.Abteilungen);
        }
    }
}