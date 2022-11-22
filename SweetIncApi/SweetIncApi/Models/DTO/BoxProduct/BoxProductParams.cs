using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.BoxProduct
{
    public class BoxProductParams : BaseParams
    {
        public int BoxId { get; set; }
        public int QuantityMin { get; set; }
        public int QuantityMax { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public string ProductName { get; set; }
    }
}
