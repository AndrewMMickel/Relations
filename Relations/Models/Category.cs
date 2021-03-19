using System.Collections.Generic;

namespace Relations.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Relation> Relations { get; set; }

        public Category()
        {
            this.Relations = new HashSet<Relation>();
        }
    }
}