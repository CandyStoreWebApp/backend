namespace SweetIncApi.Models.DTO.Product
{
    public class ProductPagingVM : BasePagingVM
    {
        public string Name { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public bool? Status { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
