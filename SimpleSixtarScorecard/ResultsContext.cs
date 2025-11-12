using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SimpleSixtarScorecard;

internal sealed class ResultsContext : DbContext {
    public DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Results.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Result>(entity => {
            entity.HasKey(e => new {
                e.SongId,
                e.Mode,
                e.Difficulty
            });
            entity.Property(e => e.SongId).HasColumnName("SongId").IsRequired();
            entity.Property(e => e.Mode).HasColumnName("Mode").HasConversion<EnumToStringConverter<Mode>>().IsRequired();
            entity.Property(e => e.Difficulty).HasColumnName("Difficulty").HasConversion<EnumToStringConverter<DifficultyType>>().IsRequired();
            entity.Property(e => e.Score).HasColumnName("Score").IsRequired();
            entity.Property(e => e.FullCombo).HasColumnName("FullCombo").IsRequired();
        });
}
