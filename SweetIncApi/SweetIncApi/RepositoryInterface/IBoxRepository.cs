using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models;
using SweetIncApi.Models.DTO.Box;
using SweetIncApi.Models.DTO.Product;
using System.Collections.Generic;

namespace SweetIncApi.RepositoryInterface
{
    public interface IBoxRepository : IBaseRepository<Box>
    {
        public Page<Box> GetAll();
        public Page<Box> GetAll(BoxPagingVM queries);
    }
}
