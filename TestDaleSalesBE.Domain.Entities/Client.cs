using System;
using System.Collections.Generic;

#nullable disable

namespace TestDaleSalesBE.Domain.Entities
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
