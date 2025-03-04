using Microsoft.EntityFrameworkCore;
using NutriApp.Models.Users;
using NutriApp.Models.Children;
using NutriApp.Models.Consultations;
using NutriApp.Models.Logs;
using NutriApp.Models.Nutrition;
using NutriApp.Models.Recipes;
using NutriApp.Models.Statistics;
using NutriApp.Models.Subscriptions;
using NutriApp.Models.AI;
using NutriApp.Models.Feedbacks;
using NutriApp.Models.Meals;

namespace NutriApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSety dla modeli
        public DbSet<User> Users { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Intolerance> Intolerances { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MealLog> MealLogs { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<TriedFood> TriedFoods { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<AppUsageStats> AppUsageStats { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AIRecommendation> AIRecommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacje użytkownika z dziećmi
            modelBuilder.Entity<User>()
                .HasMany(u => u.Children)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z opiniami
            modelBuilder.Entity<User>()
                .HasMany(u => u.Feedbacks)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z konsultacjami
            modelBuilder.Entity<User>()
                .HasMany(u => u.Consultations)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z subskrypcjami
            modelBuilder.Entity<User>()
                .HasMany(u => u.Subscriptions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z logami zdarzeń
            modelBuilder.Entity<User>()
                .HasMany(u => u.EventLogs)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z danymi AI
            modelBuilder.Entity<User>()
                .HasMany(u => u.AIRecommendations)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja użytkownika z danymi statystyk
            modelBuilder.Entity<User>()
                .HasMany(u => u.AppUsageStats)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja MealPlan → Recipe
            modelBuilder.Entity<MealPlan>()
                .HasOne(mp => mp.Recipe)
                .WithMany()
                .HasForeignKey(mp => mp.RecipeId);

            // Relacja Recipe → RecipeIngredients
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId);

            // Relacja RecipeIngredient → FoodItem
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.FoodItem)
                .WithMany()
                .HasForeignKey(ri => ri.FoodItemId);

            // Relacja Recipe → Alergeny (bazujące na FoodItem z RecipeIngredients)
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Allergens)
                .WithMany()
                .UsingEntity(j => j.ToTable("RecipeAllergens"));

            // Unikalność tokenów resetu hasła
            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.Token)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}