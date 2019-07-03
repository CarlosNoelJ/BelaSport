using BelaSport.Models;
using Microsoft.EntityFrameworkCore;

namespace BelaSport.Repository.SqlServer
{
    public partial class BelaSportContext : DbContext
    {
        public BelaSportContext()
        {
        }

        public BelaSportContext(DbContextOptions<BelaSportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventTitle> EventTitle { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Host> Host { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<EventTitle>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("pk_eventtitle");

                entity.ToTable("eventTitle");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.DniHost).HasColumnName("dniHost");

                entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");

                entity.Property(e => e.NameEvent)
                    .IsRequired()
                    .HasColumnName("name_event")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DniHostNavigation)
                    .WithMany(p => p.EventTitle)
                    .HasForeignKey(d => d.DniHost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventTitle_host");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.EventTitle)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_eventTitle_eventType");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("eventType");

                entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");

                entity.Property(e => e.NameEventType)
                    .IsRequired()
                    .HasColumnName("name_eventType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.HasKey(e => e.DniHost)
                    .HasName("pk_host");

                entity.ToTable("host");

                entity.Property(e => e.DniHost)
                    .HasColumnName("dniHost")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastNameHost)
                    .IsRequired()
                    .HasColumnName("lastNameHost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameHost)
                    .IsRequired()
                    .HasColumnName("nameHost")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
