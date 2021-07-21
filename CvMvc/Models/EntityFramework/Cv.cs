using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CvMvc.Models.EntityFramework
{
    public partial class Cv : DbContext
    {
        public Cv()
            : base("name=Cv")
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Appellation> Appellation { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<Me> Me { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<NoteDetail> NoteDetail { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<PortfolioCategory> PortfolioCategory { get; set; }
        public virtual DbSet<References> References { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Social> Social { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Time)
                .HasPrecision(2);
        }
    }
}
