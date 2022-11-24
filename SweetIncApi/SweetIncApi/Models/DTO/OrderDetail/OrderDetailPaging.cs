using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.OrderDetail
{
    public class OrderDetailPaging : BasePagingVM
    {
        public int OrderId { get; set; }
        public int BoxId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public int? Quantity { get; set; }
    }
}
