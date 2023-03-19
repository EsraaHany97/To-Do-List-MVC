using Microsoft.EntityFrameworkCore;

namespace QenaQ2MVC.Models
{
    public class LibraryContext:DbContext
    {
        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<CategoryTask> CategoryTasks { get; set; }
        public DbSet<User>Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryTaskConfigration().Configure(modelBuilder.Entity<CategoryTask>());
            new MyTaskConfigration().Configure(modelBuilder.Entity<MyTask>());
            new UserConfigration().Configure(modelBuilder.Entity<User>());
           
            modelBuilder.MapRelationship();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-2ACR2C9;Initial Catalog=ToDoList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
