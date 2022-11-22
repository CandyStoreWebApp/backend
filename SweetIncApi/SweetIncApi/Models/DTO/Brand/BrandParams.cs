using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetIncApi.Models.DTO.Brand
{
    public class BrandParams : BaseParams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OriginId { get; set; }
    }
}
