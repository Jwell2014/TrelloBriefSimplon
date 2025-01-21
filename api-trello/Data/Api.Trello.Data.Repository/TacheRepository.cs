using System;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;

namespace Api.Trello.Data.Repository
{
	public class TacheRepository : ITacheRepository
    {
        private readonly ITrelloDBContext _trelloDBContext;

        public TacheRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une Tache.
        /// </summary>
        /// <param name="Tache">Tache ajouté.</param>
        /// <returns></returns>
        public async Task<Tache> CreateTache(Tache tacheAdd)
        {
            var element = await _trelloDBContext.Tache.AddAsync(tacheAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un Tache.
        /// </summary>
        /// <param name="Tache">Tache supprimer.</param>
        /// <returns></returns>
        public async Task<Tache> DeleteTache(Tache tacheDelete)
        {
            var element = _trelloDBContext.Tache.Remove(tacheDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un Tache.
        /// </summary>
        /// <param name="Tache">Tache modifier.</param>
        /// <returns></returns>
        public async Task<Tache> UpdateTache(Tache tacheUpdate)
        {
            var element = _trelloDBContext.Tache.Update(tacheUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les Tache sous forme de liste.
        /// </summary>
        /// <param name="Tache">Liste Tache.</param>
        /// <returns></returns>
        public async Task<List<Tache>> GetTache()
        {
            return await _trelloDBContext.Tache
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un Tache par son id.
        /// </summary>
        /// <param name="Tache">Tache.</param>
        /// <returns></returns>
        public async Task<Tache> GetTacheById(int id)
        {
            return await _trelloDBContext.Tache
                .FirstOrDefaultAsync(x => x.Idtache == id)
                .ConfigureAwait(false);

        }
    }
}

