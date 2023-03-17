using AutoMapper;
using Pizzaria.PizzaAPI.Data.ValueObjects;
using Pizzaria.PizzaAPI.Model;

namespace Pizzaria.PizzaAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<PizzaVO, Pizza>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
