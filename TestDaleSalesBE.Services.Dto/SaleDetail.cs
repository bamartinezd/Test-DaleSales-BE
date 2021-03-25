﻿using System;
using System.Collections.Generic;

namespace TestDaleSalesBE.Services.Dto
{
    public class SaleDetailDTO
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal ProductValue { get; set; }
    }
}
