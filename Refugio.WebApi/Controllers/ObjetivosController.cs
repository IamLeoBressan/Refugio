using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.WebApi.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObjetivosController : ControllerBase
    {

        private readonly IObjetivosRepository _objetivosRepository;
        private readonly IMapper _mapper;
        public ObjetivosController(IObjetivosRepository objetivosRepository, IMapper mapper)
        {
            _objetivosRepository = objetivosRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OutObjetivosVM>> GetAll()
        {
            try
            {
                var usuario = User.Identity.Name;

                var objetivos = await _objetivosRepository.GetAllObjetivosByUser(usuario);

                if (objetivos == null || !objetivos.Any())
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<IEnumerable<OutObjetivosVM>>(objetivos));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutObjetivosVM>> Find(int id)
        {
            var usuario = User.Identity.Name;

            var objetivo = await _objetivosRepository.FindByUser<Objetivo>(id, usuario);

            if (objetivo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutObjetivosVM>(objetivo));
        }

        [HttpPost]
        public async Task<ActionResult<OutObjetivosVM>> Create(InObjetivosVM objetivo)
        {
            var usuario = User.Identity.Name;
            try
            {
                objetivo.Usuario = usuario;
                var estudoRetorno = await _objetivosRepository.Create(_mapper.Map<Objetivo>(objetivo));

                return Ok(_mapper.Map<OutObjetivosVM>(estudoRetorno));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OutObjetivosVM>> Update(InObjetivosVM objetivo)
        {
            try
            {
                var estudoRetorno = await _objetivosRepository.Update(_mapper.Map<Objetivo>(objetivo));

                return Ok(_mapper.Map<OutObjetivosVM>(estudoRetorno));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OutObjetivosVM>> Delete(int id)
        {
            try
            {
                await _objetivosRepository.Delete<Objetivo>(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
