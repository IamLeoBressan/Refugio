using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Refugio.Entities;
using Refugio.Entities.Services.Interfaces;
using Refugio.WebApi.Models;
using Refugio.WebApi.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudosController : ControllerBase
    {
        private readonly IEstudosRepository _estudosRepository;
        private readonly IMapper _mapper;
        public EstudosController(IEstudosRepository estudosRepository, IMapper mapper)
        {
            _estudosRepository = estudosRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OutEstudoVM>> GetEstudos(string categoria, string tipo)
        {
            var estudos = await _estudosRepository.GetEstudos(categoria, tipo);

            if (estudos == null || !estudos.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutEstudoVM>>(estudos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutEstudoVM>> GetEstudos(Guid id)
        {

            var estudo = await _estudosRepository.BuscarEstudo(id);

            if (estudo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutEstudoVM>(estudo));
        }

        [HttpPost]
        public async Task<ActionResult<OutEstudoVM>> InserirEstudo(InInserirEstudo estudo)
        {
            try
            {
                var estudoRetorno = await _estudosRepository.InserirEstudo(_mapper.Map<Estudo>(estudo));

                return Ok(_mapper.Map<OutEstudoVM>(estudoRetorno));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OutEstudoVM>> AlterarEstudo(InEstudoVM estudo)
        {
            try
            {
                var estudoRetorno = await _estudosRepository.AlterarEstudo(_mapper.Map<Estudo>(estudo));

                return Ok(_mapper.Map<OutEstudoVM>(estudoRetorno));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OutEstudoVM>> DeletarEstudos(Guid id)
        {
            try
            {
                await _estudosRepository.DeletarEstudo(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
