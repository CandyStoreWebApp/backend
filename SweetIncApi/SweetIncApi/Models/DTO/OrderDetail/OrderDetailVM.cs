namespace SweetIncApi.Models.DTO.OrderDetail
{
    public class OrderDetailVM
    {
        public int OrderId { get; set; }
        public int BoxId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
