using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;

namespace SweetIncApi.Repository
{
    public class PaymentDetailRepository : BaseRepository<PaymentDetail>, IPaymentDetailRepository
    {
        public PaymentDetailRepository(CandyStoreContext context) : base(context)
        {
        }


    }
}
