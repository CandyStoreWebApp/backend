using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Brand;

namespace SweetIncApi.RepositoryInterface
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        public new Page<Brand> GetAll();
        public new Page<Brand> GetAll(BrandPagingVM queries);
    }
}
