using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Category;

namespace SweetIncApi.RepositoryInterface
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public new Page<Category> GetAll();
        public new Page<Category> GetAll(CategoryPagingVM queries);
    }
}
