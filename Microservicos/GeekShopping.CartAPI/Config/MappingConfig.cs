using AutoMapper;
using GeekShopping.CuponAPI.Data.ValueObjects;
using GeekShopping.CuponAPI.Model;

namespace GeekShopping.CuponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
