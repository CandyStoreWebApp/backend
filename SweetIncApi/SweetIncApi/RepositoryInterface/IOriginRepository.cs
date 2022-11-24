using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Origin;

namespace SweetIncApi.RepositoryInterface
{
    public interface IOriginRepository : IBaseRepository<Origin>
    {
        public new Page<Origin> GetAll();
        public new Page<Origin> GetAll(OriginPagingVM queries);
    }
}
