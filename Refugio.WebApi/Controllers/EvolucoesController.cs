using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;
using Refugio.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EvolucoesController : ControllerBase
    {
        private readonly IEvolucaoRepository _evolucaoRepository;
        private readonly IMapper _mapper;

        public EvolucoesController(
            IEvolucaoRepository evolucaoRepository,
            IMapper mapper
            )
        {
            _evolucaoRepository = evolucaoRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OutEvolucao>> GetAll()
        {
            var evolucoes = await _evolucaoRepository.GetAllComplete();

            if (evolucoes == null || !evolucoes.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutEvolucao>>(evolucoes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutEvolucao>> Find(int id)
        {
            var evolucao = await _evolucaoRepository.Find<Evolucao>(id);

            if (evolucao == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutEvolucao>(evolucao));
        }

        [HttpPost]
        public async Task<ActionResult<OutEvolucao>> Create(InEvolucao evolucao)
        {
            try
            {
                var evolucaoRetorno = await _evolucaoRepository.Create(_mapper.Map<Evolucao>(evolucao));

                var outEvolucao = _mapper.Map<OutEvolucao>(evolucaoRetorno);

                if (Uri.TryCreate(nameof(Find), UriKind.Relative, out Uri url))
                    return Created(url, outEvolucao);


                return Ok(outEvolucao);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
