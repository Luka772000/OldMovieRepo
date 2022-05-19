using AutoMapper;
using ProjektFinal.DTOs;
using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.DTOs
{
    public  class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap();
        }
        private  void CreateMap()
        {
            CreateMap<Film, FilmDto>();
            CreateMap<FilmDto, Film>();

            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();

            CreateMap<ProductionHouse, ProductionHouseDto>();
            CreateMap<ProductionHouseDto, ProductionHouse>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();


        }
    }
}
