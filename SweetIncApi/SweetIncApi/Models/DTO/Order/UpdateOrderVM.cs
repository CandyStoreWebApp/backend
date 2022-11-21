using System;

namespace SweetIncApi.Models.DTO.Order
{
    public class UpdateOrderVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Datetime { get; set; }
        public int Status { get; set; }
        public int? PaymentId { get; set; }
    }
}
