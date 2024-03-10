using AutoMapper;
using DevTesteInovage.Application.Models;
using DevTesteInovage.Core.Entities;

namespace DevTesteInovage.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDetailsViewModel>();

            CreateMap<Purchase, PurchaseViewModel>();
            CreateMap<Purchase, PurchaseDetailsViewModel>();

            CreateMap<PurchaseItem, PurchaseItemViewModel>();

        }
    }
}
