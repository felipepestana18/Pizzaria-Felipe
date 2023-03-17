using AutoMapper;
using Pizzaria.BebidaAPI.Data.ValueObjects;
using Pizzaria.BebidaAPI.Model;

namespace Pizzaria.BebidaAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<BebidaVO, Bebida>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
