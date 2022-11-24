using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.Order
{
    public class OrderPagingVM : BasePagingVM
    {
        public int UserId { get; set; }
        public DateTime? DatetimeMin { get; set; }
        public DateTime? DatetimeMax { get; set; }
        public int Status { get; set; }
        public int? PaymentId { get; set; }
    }
}
