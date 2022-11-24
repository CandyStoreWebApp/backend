using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.BoxPattern
{
    public class BoxPatternPagingVM : BasePagingVM
    {
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
    }
}
