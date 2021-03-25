using System;
using System.Collections.Generic;

#nullable disable

namespace TestDaleSalesBE.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public long? ClientId { get; set; }
        public decimal? TotalValue { get; set; }
        public DateTime? SaleDate { get; set; }

        public Client Client { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
