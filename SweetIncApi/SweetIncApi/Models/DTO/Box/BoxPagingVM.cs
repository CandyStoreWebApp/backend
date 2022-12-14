using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.Box
{
    public class BoxPagingVM : BasePagingVM
    {
        public int? QuantityMin { get; set; }
        public int? QuantityMax { get; set; }
        public bool? Status { get; set; }
        public int? BoxPatternId { get; set; }
    }
}
