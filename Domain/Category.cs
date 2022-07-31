namespace Domain
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
