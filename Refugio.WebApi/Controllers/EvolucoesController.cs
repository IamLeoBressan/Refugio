using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.Helpers;
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
        public async Task<ActionResult<OutEvolucoesPaginacao>> GetAllPaginacao(int QuantidadeItensPagina, int Pagina)
        {

            var filtro = new Paginacao
            {
                QuantidadeItensPagina = QuantidadeItensPagina,
                Pagina = Pagina
            };

            var usuario = User.Identity.Name;

            var filtroHelper = this._mapper.Map<Paginacao>(filtro);

            var evolucoes = _evolucaoRepository.GetAllCompleteByUser(usuario, filtroHelper, out int quantidadeTotalItens);

            if (evolucoes == null || !evolucoes.Any())
            {
                return NotFound();
            }

            var outEvolucoes = _mapper.Map<IEnumerable<OutEvolucao>>(evolucoes);

            var outPaginacao = new OutPaginacao(Pagina, QuantidadeItensPagina, quantidadeTotalItens);

            var outEvolucoesPaginacao = new OutEvolucoesPaginacao
            {
                Evolucoes = outEvolucoes,
                Paginacao = outPaginacao
            };

            return Ok(outEvolucoesPaginacao);
        }

        [HttpGet("grupoMeses")]
        public async Task<ActionResult> GetMonthGroup()
        {
            var usuario = User.Identity.Name;

            var grupoMeses = await _evolucaoRepository.GetGrupoMesesEvolucoes(usuario);

            if (grupoMeses == null || !grupoMeses.Any())
            {
                return NotFound();
            }

            return Ok(grupoMeses);
        }

        [HttpGet("grafico")]
        public async Task<ActionResult> GetEvolucoesFiltradas(int ano, int mes)
        {
            var usuario = User.Identity.Name;

            var evolucoes = await _evolucaoRepository.GetEvolucoesFiltradas(usuario, ano, mes);

            if (evolucoes == null || !evolucoes.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutEvolucoesFiltradasGrafico>>(evolucoes));
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

                await ValidarEvolucao(usuario, evolucao);


                var evolucaoEntidade = _mapper.Map<Evolucao>(evolucao);
                evolucaoEntidade.Usuario = usuario;



                PreencherImagensEvolucao(evolucao, evolucaoEntidade);

                var evolucaoRetorno = new Evolucao();

                if(evolucao.Edicao())
                    evolucaoRetorno = await _evolucaoRepository.UpdateEvolucao(evolucaoEntidade);
                else
                    evolucaoRetorno = await _evolucaoRepository.Create(evolucaoEntidade);

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

        private async Task ValidarEvolucao(string usuario, InEvolucao evolucao)
        {
            if (evolucao.Edicao())
                return;


            var existeEvolucaoData = await _evolucaoRepository.ExisteEvolucaoNaData(usuario, evolucao.DataMedicao);

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
            if (evolucao.FilesImg == null)
                return;


            foreach (var img in evolucao.FilesImg)
            {
                MemoryStream ms = new MemoryStream();
                img.File.OpenReadStream().CopyTo(ms);

                evolucaoEntidade.Imagens.Add(new Imagem
                {   
                    Id = img.Id > 0? img.Id: null,
                    Nome = img.File.FileName,
                    BytesImagem = ms.ToArray()
                });
            }
        }
    }
}
