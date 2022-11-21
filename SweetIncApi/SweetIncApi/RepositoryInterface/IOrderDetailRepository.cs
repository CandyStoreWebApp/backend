using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxProduct;
using SweetIncApi.Models.DTO.OrderDetail;
using System.Collections.Generic;

namespace SweetIncApi.RepositoryInterface
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        public List<OrderDetail> GetByOrderId(int id);
    }
}
