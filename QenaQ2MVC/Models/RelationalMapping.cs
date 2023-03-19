using Microsoft.EntityFrameworkCore;

namespace QenaQ2MVC.Models
{
    public static class RelationalMapping
    {
        public static void MapRelationship(this ModelBuilder builder)
        {
            builder.Entity<MyTask>().HasOne(t => t.Category).
                WithMany(t => t.MyTasks).
                HasForeignKey(i => i.CategoryTaskID).
                IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MyTask>().HasOne(t => t.Owner).
                WithMany(t => t.MyTasks).
                HasForeignKey(i => i.UserID).
                IsRequired().OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
