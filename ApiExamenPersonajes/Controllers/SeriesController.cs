using ApiExamenPersonajes.Models;
using ApiExamenPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet("Personajes")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpPut("UpdatePersonaje")]
        public async Task<ActionResult> UpdatePersonaje
            (int idPersonaje, int idSerie)
        {
            await this.repo.UpdatePersonajeAsync(idPersonaje, idSerie);
            return Ok();
        }

        [HttpGet("Series")]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("FindSerie/{idserie}")]
        public async Task<ActionResult<Serie>> FindSerie(int idserie)
        {
            return await this.repo.FindSerieAsync(idserie);
        }

        [HttpGet("FindPersonajesBySerie/{idserie}")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesBySerie(int idserie)
        {
            var personajes = await this.repo.GetPersonajesBySerieAsync(idserie);
            return personajes;
        }

        [HttpPost("PersonajesBySeries")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajesBySeries([FromBody] List<int> idsSerie)
        {
            var personajes = await this.repo.GetPersonajesBySeriesAsync(idsSerie);
            return personajes;
        }
    }
}
