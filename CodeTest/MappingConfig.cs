using AutoMapper;
using CodeTest.DTO;
using CodeTest.Model;

namespace Test
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Evouchers, EvoucherDTO>().ReverseMap();

            CreateMap<Payments, PaymentDTO>().ReverseMap();

            CreateMap<Items, ItemsDTO>().ReverseMap();

            CreateMap<Purchases, PurchaseDTO>().ReverseMap();
        }
    }
}
