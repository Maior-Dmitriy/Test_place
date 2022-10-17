using Microsoft.EntityFrameworkCore;
using Model.DL;

namespace DL.Context
{
    public class MsSqlContext : DbContext
    {
        public MsSqlContext(DbContextOptions<MsSqlContext> options)
            :base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<QuestionEntity > Questions { get; set; }
        public DbSet<OptionEntity> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<UserEntity>().ToTable("Users").HasKey(u => u.Id);
            modelBuilder.Entity<UserEntity>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<UserEntity>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<UserEntity>().HasMany(u => u.Roles).WithMany(r => r.Users).UsingEntity(userRole => userRole.ToTable("UserRole"));
            modelBuilder.Entity<TestEntity>().HasMany(t => t.Users).WithMany(u => u.Tests).UsingEntity(userTest => userTest.ToTable("UserTest"));

            //Role
            modelBuilder.Entity<RoleEntity>().ToTable("Roles").HasKey(r => r.Id);
            modelBuilder.Entity<RoleEntity>().Property(r => r.Title).IsRequired();

            //Test
            modelBuilder.Entity<TestEntity>().ToTable("Tests").HasKey(t => t.Id);
            modelBuilder.Entity<TestEntity>().Property(t => t.Name).IsRequired();
            
            //Question
            modelBuilder.Entity<QuestionEntity >().ToTable("Question").HasKey(q => q.Id);
            modelBuilder.Entity<QuestionEntity >().Property(q => q.Title).IsRequired();
            modelBuilder.Entity<QuestionEntity >().HasOne(q => q.Test).WithMany(t => t.Questions).HasForeignKey(q => q.TestId).OnDelete(DeleteBehavior.Cascade);

            //Option
            modelBuilder.Entity<OptionEntity>().ToTable("Options").HasKey(o => o.Id);
            modelBuilder.Entity<OptionEntity>().Property(o => o.Letter).IsRequired();
            modelBuilder.Entity<OptionEntity>().Property(o => o.Text).IsRequired();
            modelBuilder.Entity<OptionEntity>().HasOne(o => o.Question).WithMany(q => q.Options).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
