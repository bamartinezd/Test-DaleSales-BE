using System;
using System.Collections.Generic;

#nullable disable

namespace TestDaleSalesBE.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitValue { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
