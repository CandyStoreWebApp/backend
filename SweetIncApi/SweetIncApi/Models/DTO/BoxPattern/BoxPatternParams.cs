using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.BoxPattern
{
    public class BoxPatternParams : BaseParams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public int? LowerAge { get; set; }
        public int? UpperAge { get; set; }
    }
}
