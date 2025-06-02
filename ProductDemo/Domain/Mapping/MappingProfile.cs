using AutoMapper;
using ProductDemo.Domain.DTO;
using ProductDemo.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductDemo.Domain.Mapping
{
    /// <summary>
    /// MappingProfile class, provides a named configuration for maps.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }

        /// <summary>
        /// To get IMapper from mapping profile.
        /// </summary>
        /// <param name="profile">Specify Profile.</param>
        /// <returns>IMapper.</returns>
        public static IMapper GetMapper(Profile profile)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });
            return config.CreateMapper();
        }
    }
}
