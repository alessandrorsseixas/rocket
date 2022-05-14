using AutoMapper;
using ClienteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApi.Mapper
{
    public class ClienteProfile:Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }
    }
}
