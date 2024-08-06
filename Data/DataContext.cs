using Microsoft.EntityFrameworkCore;
using StickyNotesAPI.Models;

namespace StickyNotesApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja dla z³o¿onych typów
            modelBuilder.Entity<Note>()
                .OwnsOne(n => n.Colors)
                .WithOwner()
                .HasForeignKey("NoteId"); // U¿yj "NoteId" lub innego klucza, jeœli jest wymagany

            modelBuilder.Entity<Note>()
                .OwnsOne(n => n.Position)
                .WithOwner()
                .HasForeignKey("NoteId"); // U¿yj "NoteId" lub innego klucza, jeœli jest wymagany
        }
    }
}
