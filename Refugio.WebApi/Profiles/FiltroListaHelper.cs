using AutoMapper;
using Refugio.Helpers;
using Refugio.WebApi.Models.Input;

namespace Refugio.WebApi.Profiles
{
    public class FiltroListaHelper: Profile
    {
        public FiltroListaHelper()
        {
            CreateMap<Paginacao, InPaginacao>();

            CreateMap<InPaginacao, Paginacao>();
        }

    }
}
