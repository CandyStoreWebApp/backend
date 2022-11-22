using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;

namespace SweetIncApi.RepositoryInterface
{
    public interface IProductRepository : IBaseRepository<PaymentDetail>
    {
        public Page<Product> GetAll();
    }
}
