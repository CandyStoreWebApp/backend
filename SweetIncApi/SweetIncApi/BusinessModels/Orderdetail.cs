using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int BoxId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Box Box { get; set; }
        public virtual Order Order { get; set; }
    }
}
