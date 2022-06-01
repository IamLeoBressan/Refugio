using AutoMapper;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;
using Refugio.WebApi.Models.Output;


namespace Refugio.WebApi.Profiles
{
    public class EvolucaoProfile: Profile
    {
        public EvolucaoProfile()
        {
            CreateMap<Imagem, OutImagem>();

            CreateMap<Evolucao, OutEvolucao>()
                .ForMember(dest => dest.QuantidadeImagens, opt => opt.MapFrom(org => org.Imagens.Count));

            CreateMap<Evolucao, OutEvolucaoDetalhe>();

            CreateMap<InEvolucao, Evolucao>();

            CreateMap<Dificuldade, OutDificuldade>();
            CreateMap<InDificuldade, Dificuldade>();
        }
    }
}
