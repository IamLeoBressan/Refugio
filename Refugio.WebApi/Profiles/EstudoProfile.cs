using AutoMapper;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;

namespace Refugio.WebApi.Profiles
{
    public class EstudosProfile: Profile
    {
        public EstudosProfile()
        {
            CreateMap<Estudo, Models.OutEstudoVM>();

            CreateMap<Models.InEstudoVM, Estudo>();
            CreateMap<InInserirEstudo, Estudo>();
        }

    }

}
