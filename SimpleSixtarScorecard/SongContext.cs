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
            entity.HasKey(e => e.Id);
            entity.ToTable("Song");
            entity.Property(e => e.OrderNumber).HasColumnName("OrderNumber").IsRequired();
            entity.Property(e => e.Id).HasColumnName("Id").IsRequired();
            entity.Property(e => e.Title).HasColumnName("Title").IsRequired();
            entity.Property(e => e.Composer).HasColumnName("Composer").IsRequired();
            entity.Property(e => e.Dlc).HasColumnName("Dlc").HasConversion<EnumToStringConverter<Dlc>>().IsRequired();
            entity.Property(e => e.Category).HasColumnName("Category").HasConversion<EnumToStringConverter<Category>>().IsRequired();
            entity.Property(e => e.LunarComet).HasColumnName("LunarComet");
            entity.Property(e => e.LunarNova).HasColumnName("LunarNova");
            entity.Property(e => e.LunarSupernova).HasColumnName("LunarSupernova");
            entity.Property(e => e.LunarQuasar).HasColumnName("LunarQuasar");
            entity.Property(e => e.LunarStarlight).HasColumnName("LunarStarlight");
            entity.Property(e => e.SolarComet).HasColumnName("SolarComet");
            entity.Property(e => e.SolarNova).HasColumnName("SolarNova");
            entity.Property(e => e.SolarSupernova).HasColumnName("SolarSupernova");
            entity.Property(e => e.SolarQuasar).HasColumnName("SolarQuasar");
            entity.Property(e => e.SolarStarlight).HasColumnName("SolarStarlight");
        });
}
