using Data.Contracts;
using Domain;

namespace Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext)
         : base(dbContext)
        {
        }
    }
}
