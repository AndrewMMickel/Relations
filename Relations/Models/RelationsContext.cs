using Microsoft.EntityFrameworkCore;

namespace Relations.Models
{
    public class RelationsContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; } //new line
        public virtual DbSet<Relation> Relations { get; set; }          //changed

        public RelationsContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}