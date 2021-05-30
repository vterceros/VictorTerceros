using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VictorTerceros.DBModel
{
    public partial class LinkedInModel : DbContext
    {
        public LinkedInModel()
            : base("name=VictorTerceros.Properties.Settings.LinkedInConnectionString")
        {
        }

        public virtual DbSet<People> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.CurrentRole)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<People>()
                .Property(e => e.Industry)
                .IsUnicode(false);
        }
    }
}
