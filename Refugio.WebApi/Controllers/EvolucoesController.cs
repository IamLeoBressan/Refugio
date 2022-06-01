using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;
using Refugio.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var usuario = User.Identity.Name;

            var evolucoes = await _evolucaoRepository.GetAllCompleteByUser(usuario);

            evolucoes = evolucoes.OrderByDescending(e => e.DataMedicao).ToList();

            if (evolucoes == null || !evolucoes.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutEvolucao>>(evolucoes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutEvolucaoDetalhe>> Find(int id)
        {
            var usuario = User.Identity.Name;

            var evolucao = await _evolucaoRepository.FindCompleteByUser(usuario, id);

            if (evolucao == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutEvolucaoDetalhe>(evolucao));
        }

        [HttpPost]
        public async Task<ActionResult<OutEvolucao>> Create([FromForm] InEvolucao evolucao)
        {
            try
            {
                var usuario = User.Identity.Name;

                await ValidarEvolucao(usuario, evolucao.DataMedicao);


                var evolucaoEntidade = _mapper.Map<Evolucao>(evolucao);
                evolucaoEntidade.Usuario = usuario;



                PreencherImagensEvolucao(evolucao, evolucaoEntidade);

                var evolucaoRetorno = await _evolucaoRepository.Create(evolucaoEntidade);

                var outEvolucao = _mapper.Map<OutEvolucao>(evolucaoRetorno);

                if (Uri.TryCreate(nameof(Find), UriKind.Relative, out Uri url))
                    return Created(url, outEvolucao);


                return Ok(outEvolucao);
            }
            catch (ArgumentException ex)
            {
                var erro = BadRequest(ex.Message);

                return erro;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private async Task ValidarEvolucao(string usuario, DateTime dataMedicao)
        {
            var existeEvolucaoData = await _evolucaoRepository.ExisteEvolucaoNaData(usuario, dataMedicao);

            if (existeEvolucaoData)
                throw new ArgumentException("Já Existe medição na data informada.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _evolucaoRepository.Delete<Evolucao>(id);

                return NoContent();
            }
            catch (Exception)
            {

                

                return StatusCode(500);
            }
        }

        private static void PreencherImagensEvolucao(InEvolucao evolucao, Evolucao evolucaoEntidade)
        {
            if (evolucao.Files == null)
                return;


            foreach (var file in evolucao.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.OpenReadStream().CopyTo(ms);

                evolucaoEntidade.Imagens.Add(new Imagem
                {
                    Nome = file.FileName,
                    BytesImagem = ms.ToArray()
                });
            }
        }
    }
}
