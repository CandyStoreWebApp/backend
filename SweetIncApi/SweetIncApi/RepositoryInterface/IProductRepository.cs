using EntityFrameworkPaginateCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Product;

namespace SweetIncApi.RepositoryInterface
{
    public interface IProductRepository : IBaseRepository<PaymentDetail>
    {
        public new Page<Product> GetAll();
        public Page<Product> GetAll(ProductPagingVM queries);
    }
}
