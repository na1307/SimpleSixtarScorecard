using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SimpleSixtarScorecard;

internal sealed class ResultContext : DbContext {
    public ResultContext() { }

    public ResultContext(DbContextOptions<ResultContext> options) : base(options) { }

    public DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Results.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Result>(entity => {
            entity.HasKey(e => new {
                e.SongId,
                e.Mode,
                e.Difficulty
            });
            entity.ToTable("Result");
            entity.Property(e => e.SongId).HasColumnName("song_id").IsRequired();
            entity.Property(e => e.Mode).HasColumnName("mode").HasConversion<EnumToStringConverter<Mode>>().IsRequired();
            entity.Property(e => e.Difficulty).HasColumnName("difficulty").HasConversion<EnumToStringConverter<DifficultyType>>().IsRequired();
            entity.Property(e => e.Score).HasColumnName("score").IsRequired();
            entity.Property(e => e.FullCombo).HasColumnName("full_combo").IsRequired();
        });
}
