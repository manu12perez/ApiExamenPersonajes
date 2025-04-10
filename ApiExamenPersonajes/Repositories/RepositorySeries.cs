using ApiExamenPersonajes.Data;
using ApiExamenPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenPersonajes.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }

        public async Task UpdatePersonajeAsync
            (int idPersonaje, int idSerie )
        {
            Personaje personaje = await this.FindPersonajeAsync(idPersonaje);
            personaje.IdSerie = idSerie;

            await this.context.SaveChangesAsync();
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }

        public async Task<List<Personaje>> GetPersonajesBySerie(int idSerie)
        {
            Serie serie = await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idSerie);
            List<Personaje> personajes = await this.context.Personajes.Where(x => x.IdSerie == serie.IdSerie).ToListAsync();
            return personajes;
        }

        public async Task<List<Personaje>> GetPersonajesBySeriesAsync(List<int> idsSerie)
        {
            return await this.context.Personajes
                .Where(p => idsSerie.Contains(p.IdSerie))
                .ToListAsync();
        }
    }
}
