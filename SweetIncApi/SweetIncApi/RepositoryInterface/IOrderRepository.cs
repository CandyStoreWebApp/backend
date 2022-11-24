using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Order;

namespace SweetIncApi.RepositoryInterface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public new Page<Order> GetAll();
        public new Page<Order> GetAll(OrderPagingVM queries);
    }
}
