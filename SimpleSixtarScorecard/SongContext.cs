using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SimpleSixtarScorecard;

internal sealed class SongContext : DbContext {
    public SongContext() { }

    public SongContext(DbContextOptions<SongContext> options) : base(options) { }

    public DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Song.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Song>(entity => {
            entity.HasNoKey().ToTable("Song");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Composer).HasColumnName("composer");
            entity.Property(e => e.Dlc).HasColumnName("dlc").HasConversion<EnumToStringConverter<Dlc>>();
            entity.Property(e => e.Category).HasColumnName("category").HasConversion<EnumToStringConverter<Category>>();
            entity.Property(e => e.SolarComet).HasColumnName("solar_comet");
            entity.Property(e => e.SolarNova).HasColumnName("solar_nova");
            entity.Property(e => e.SolarSupernova).HasColumnName("solar_supernova");
            entity.Property(e => e.SolarQuasar).HasColumnName("solar_quasar");
            entity.Property(e => e.SolarStarlight).HasColumnName("solar_starlight");
            entity.Property(e => e.LunarComet).HasColumnName("lunar_comet");
            entity.Property(e => e.LunarNova).HasColumnName("lunar_nova");
            entity.Property(e => e.LunarSupernova).HasColumnName("lunar_supernova");
            entity.Property(e => e.LunarQuasar).HasColumnName("lunar_quasar");
            entity.Property(e => e.LunarStarlight).HasColumnName("lunar_starlight");
        });
}
