using System;
using System.Collections.Generic;

#nullable disable

namespace SweetIncApi.BusinessModels
{
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
