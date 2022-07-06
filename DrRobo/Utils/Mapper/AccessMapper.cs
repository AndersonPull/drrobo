using System;
using AutoMapper;
using DrRobo.Modules.Access.Models;
using DrRobo.Modules.Access.Services.Request;
using DrRobo.Modules.Access.Services.Response;
using Unity;

namespace DrRobo.Utils.Mapper
{
    public static class AccessMapper
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessageModel, MessageResponseDto>();
                cfg.CreateMap<AccessRequestDto, AccessModel>();


            });
            return mapperConfiguration.CreateMapper();
        }

    }
}
