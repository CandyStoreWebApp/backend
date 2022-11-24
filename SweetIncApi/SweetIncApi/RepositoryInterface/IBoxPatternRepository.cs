using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxPattern;

namespace SweetIncApi.RepositoryInterface
{
    public interface IBoxPatternRepository : IBaseRepository<BoxPattern>
    {
        public new Page<BoxPattern> GetAll();
        public Page<BoxPattern> GetAll(BoxPatternPagingVM queries);
    }
}
