using AutoMapper;
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
            var objetivos = await _objetivosRepository.GetALL<Objetivo>();

            if (objetivos == null || !objetivos.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutObjetivosVM>>(objetivos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutObjetivosVM>> Find(int id)
        {
            //Thread.Sleep(10000);

            var objetivo = await _objetivosRepository.Find<Objetivo>(id);

            if (objetivo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutObjetivosVM>(objetivo));
        }

        [HttpPost]
        public async Task<ActionResult<OutObjetivosVM>> Create(InObjetivosVM objetivo)
        {
            try
            {
                var estudoRetorno = await _objetivosRepository.Create(_mapper.Map<Objetivo>(objetivo));

                return Ok(_mapper.Map<OutObjetivosVM>(estudoRetorno));
            }
            catch (Exception ex)
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
