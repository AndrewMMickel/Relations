using Microsoft.EntityFrameworkCore;

namespace Relations.Models
{
    public class RelationsContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; } //new line
        public virtual DbSet<Item> Items { get; set; }          //changed

        public ToDoListContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}