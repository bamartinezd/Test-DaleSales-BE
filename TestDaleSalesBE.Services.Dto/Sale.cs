using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDaleSalesBE.Services.Dto
{
    public class SaleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The clientID is required.")]
        public long ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime SaleDate { get; set; }

        public ICollection<SaleDetailDTO> SaleDetails { get; set; }
    }
}
