using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Role;

namespace SweetIncApi.RepositoryInterface
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        public Page<Role> GetAll();
        public Page<Role> GetAll(RolePagingVM queries);
    }
}
