using AutoMapper;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;
using Refugio.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Profiles
{
    public class EvolucaoProfile: Profile
    {
        public EvolucaoProfile()
        {
            CreateMap<Evolucao, OutEvolucao>();
            CreateMap<InEvolucao, Evolucao>();

            CreateMap<Dificuldade, OutDificuldade>();
            CreateMap<InDificuldade, Dificuldade>();
        }
    }
}
