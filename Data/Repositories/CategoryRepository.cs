using Data.Contracts;
using Domain;

namespace Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext)
         : base(dbContext)
        {
        }
    }
}
