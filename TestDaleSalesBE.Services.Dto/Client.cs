using System;
using System.Collections.Generic;

namespace TestDaleSalesBE.Services.Dto
{
    public class ClientDTO
    {

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Phone { get; set; }
        public string Email { get; set; }
    }
}
