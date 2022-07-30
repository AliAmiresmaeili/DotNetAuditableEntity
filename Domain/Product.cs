using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

    }
}
