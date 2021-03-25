using System;
using System.Collections.Generic;

namespace TestDaleSalesBE.Services.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitValue { get; set; }
    }
}
