using AutoMapper;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;

namespace Refugio.WebApi.Profiles
{
    public class ObjetivosProfile : Profile
    {
        public ObjetivosProfile()
        {
            CreateMap<InObjetivosVM, Objetivo>();
            CreateMap<Objetivo, OutObjetivosVM>();
        }
    }
}
