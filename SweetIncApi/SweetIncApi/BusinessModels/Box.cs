using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class Box
    {
        public Box()
        {
            BoxProducts = new HashSet<BoxProduct>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? Quantity { get; set; }
        public bool? Status { get; set; }
        public int? BoxPatternId { get; set; }

        public virtual BoxPattern BoxPattern { get; set; }
        public virtual ICollection<BoxProduct> BoxProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
