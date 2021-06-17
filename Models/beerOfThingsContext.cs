using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace beerOfThings.Models
{
    public partial class beerOfThingsContext : DbContext
    {
        public beerOfThingsContext()
        {
        }

        public beerOfThingsContext(DbContextOptions<beerOfThingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brewing> Brewings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientsList> IngredientsLists { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<Temperature> Temperatures { get; set; }
        public virtual DbSet<WarmingHistory> WarmingHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Brewing>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Brewing");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.StageId).HasColumnName("stageId");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeBrewing");

                entity.HasOne(d => d.Stage)
                    .WithMany()
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_StageBrewing");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<IngredientsList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IngredientsList");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Entity)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("entity");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Ingredient)
                    .WithMany()
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_Ingredients_Ingredient");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_Ingredients_Recipe");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CATEGORY");
            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("Stage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Minutes).HasColumnName("minutes");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OptimalTemperature).HasColumnName("optimalTemperature");
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.ToTable("Temperature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.StageId).HasColumnName("stageId");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("time");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.WarmingId).HasColumnName("warmingId");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.Temperatures)
                    .HasForeignKey(d => d.StageId)
                    .HasConstraintName("FK_Temperature_Stage");

                entity.HasOne(d => d.Warming)
                    .WithMany(p => p.Temperatures)
                    .HasForeignKey(d => d.WarmingId)
                    .HasConstraintName("FK_WARMINGHISTORY");
            });

            modelBuilder.Entity<WarmingHistory>(entity =>
            {
                entity.ToTable("WarmingHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.WarmingHistories)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RECIPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
