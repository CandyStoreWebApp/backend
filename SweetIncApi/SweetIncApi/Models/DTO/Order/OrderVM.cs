using System;

namespace SweetIncApi.Models.DTO.Order
{
    public class OrderVM
    {
        public int UserId { get; set; }
        public DateTime? Datetime { get; set; }
        public int Status { get; set; }
        public int? PaymentId { get; set; }
    }
}
