using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace beerOfThings.Models
{
    public partial class BeerOfThingsContext : DbContext
    {
        public BeerOfThingsContext()
        {
        }

        public BeerOfThingsContext(DbContextOptions<BeerOfThingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brewing> Brewings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientsList> IngredientsLists { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<TemperatureProbe> TemperatureProbes { get; set; }
        public virtual DbSet<WarmingHistory> WarmingHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EUP471Q\\SQLEXPRESS;Database=BeerOfThings;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Brewing>(entity =>
            {
                entity.ToTable("Brewing");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Brewings)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Brewing_Recipe");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Brewings)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_Brewing_Stage");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IngredientsList>(entity =>
            {
                entity.ToTable("IngredientsList");

                entity.Property(e => e.Entity)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientsLists)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_IngredientsList_Ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.IngredientsLists)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IngredientsList_Recipe");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("Password");

                entity.Property(e => e.HashedPassword)
                    .HasMaxLength(56)
                    .IsUnicode(false)
                    .HasColumnName("hashedPassword");

                entity.Property(e => e.Salt)
                    .HasMaxLength(56)
                    .IsUnicode(false)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(56)
                    .IsUnicode(false);

                entity.HasOne(d => d.Password)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.PasswordId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Profile_Password");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Recipe_Category");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemperatureProbe>(entity =>
            {
                entity.ToTable("TemperatureProbe");

                entity.Property(e => e.ProbeTime).HasColumnType("datetime");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.TemperatureProbes)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_TemperatureProbe_Stage");

                entity.HasOne(d => d.Warming)
                    .WithMany(p => p.TemperatureProbes)
                    .HasForeignKey(d => d.WarmingId)
                    .HasConstraintName("FK_TemperatureProbe_WarmingHistory");
            });

            modelBuilder.Entity<WarmingHistory>(entity =>
            {
                entity.ToTable("WarmingHistory");

                entity.Property(e => e.WarmingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.WarmingHistories)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_WarmingHistory_Profile");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.WarmingHistories)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_WarmingHistory_Recipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
