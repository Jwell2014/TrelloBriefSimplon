using System;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;

namespace Api.Trello.Data.Repository
{
	public class MembreProjetRepository : IMembreProjetRepository
    {
        private readonly ITrelloDBContext _trelloDBContext;

        public MembreProjetRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">Projet MembreProjet.</param>
        /// <returns></returns>
        public async Task<MembreProjet> CreateMembreProjet(MembreProjet actionAdd)
        {
            var element = await _trelloDBContext.MembreProjet.AddAsync(actionAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet supprimer.</param>
        /// <returns></returns>
        public async Task<MembreProjet> DeleteMembreProjet(MembreProjet actionDelete)
        {
            var element = _trelloDBContext.MembreProjet.Remove(actionDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet modifier.</param>
        /// <returns></returns>
        public async Task<MembreProjet> UpdateMembreProjet(MembreProjet actionUpdate)
        {
            var element = _trelloDBContext.MembreProjet.Update(actionUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les MembreProjet sous forme de liste.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet Projet.</param>
        /// <returns></returns>
        public async Task<List<MembreProjet>> GetMembreProjet()
        {
            return await _trelloDBContext.MembreProjet
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un MembreProjet par son id.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet.</param>
        /// <returns></returns>
        public async Task<MembreProjet> GetMembreProjetById(int id)
        {
            return await _trelloDBContext.MembreProjet
                .FirstOrDefaultAsync(x => x.IdmembreProjet == id)
                .ConfigureAwait(false);

        }
    }
}

