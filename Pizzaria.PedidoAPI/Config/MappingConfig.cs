﻿using AutoMapper;

using Pizzaria.PedidoAPI.Model;

namespace Pizzaria.ClienteAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PedidoVO, Pedido>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
