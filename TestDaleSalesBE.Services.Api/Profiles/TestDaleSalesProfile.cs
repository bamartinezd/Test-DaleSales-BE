using AutoMapper;
using TestDaleSalesBE.Domain.Entities;
using TestDaleSalesBE.Services.Dto;

namespace TestDaleSalesBE.Services.Api.Profiles{
    public class MovieAPIProfile : Profile
    {
        public MovieAPIProfile(){
            this.CreateMap<Client, ClientDTO>().ReverseMap();
            this.CreateMap<Product, ProductDTO>().ReverseMap();
            this.CreateMap<Sale, SaleDTO>().ReverseMap();
            this.CreateMap<SaleDetail, SaleDetailDTO>().ReverseMap();
        }
    }
}