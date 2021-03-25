using System;
using System.Collections.Generic;

#nullable disable

namespace TestDaleSalesBE.Domain.Entities
{
    public partial class SaleDetail
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
