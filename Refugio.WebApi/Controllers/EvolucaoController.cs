using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refugio.WebApi.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolucaoController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateNew(InEvolucao evolucao)
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
    }
}
