using System;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;


namespace Api.Trello.Data.Repository
{
	public class StatusTacheRepository : IStatusTacheRepository
    {
        private readonly ITrelloDBContext _trelloDBContext;

        public StatusTacheRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache ajouté.</param>
        /// <returns></returns>
        public async Task<StatutTache> CreateStatutTache(StatutTache statutTacheAdd)
        {
            var element = await _trelloDBContext.StatutTache.AddAsync(statutTacheAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache supprimer.</param>
        /// <returns></returns>
        public async Task<StatutTache> DeleteStatutTache(StatutTache statutTacheDelete)
        {
            var element = _trelloDBContext.StatutTache.Remove(statutTacheDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache modifier.</param>
        /// <returns></returns>
        public async Task<StatutTache> UpdateStatutTache(StatutTache statutTacheUpdate)
        {
            var element = _trelloDBContext.StatutTache.Update(statutTacheUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les StatutTache sous forme de liste.
        /// </summary>
        /// <param name="StatutTache">Liste StatutTache.</param>
        /// <returns></returns>
        public async Task<List<StatutTache>> GetStatutTache()
        {
            return await _trelloDBContext.StatutTache
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un StatutTache par son id.
        /// </summary>
        /// <param name="StatutTache">StatutTache.</param>
        /// <returns></returns>
        public async Task<StatutTache> GetStatutTacheById(int id)
        {
            return await _trelloDBContext.StatutTache
                .FirstOrDefaultAsync(x => x.IdstatutTache == id)
                .ConfigureAwait(false);

        }
    }
}

