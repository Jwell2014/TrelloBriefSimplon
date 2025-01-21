using System;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;


namespace Api.Trello.Data.Repository
{
	public class ProjetRepository : IProjetRepository
    {
        private readonly ITrelloDBContext _trelloDBContext;

        public ProjetRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une Projet.
        /// </summary>
        /// <param name="Projet">Projet ajouté.</param>
        /// <returns></returns>
        public async Task<Projet> CreateProjet(Projet projetAdd)
        {
            var element = await _trelloDBContext.Projet.AddAsync(projetAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un Projet.
        /// </summary>
        /// <param name="Projet">Projet supprimer.</param>
        /// <returns></returns>
        public async Task<Projet> DeleteProjet(Projet projetDelete)
        {
            var element = _trelloDBContext.Projet.Remove(projetDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un Projet.
        /// </summary>
        /// <param name="Projet">Projet modifier.</param>
        /// <returns></returns>
        public async Task<Projet> UpdateProjet(Projet projetUpdate)
        {
            var element = _trelloDBContext.Projet.Update(projetUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les Projet sous forme de liste.
        /// </summary>
        /// <param name="Projet">Liste Projet.</param>
        /// <returns></returns>
        public async Task<List<Projet>> GetProjet()
        {
            return await _trelloDBContext.Projet
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un Projet par son id.
        /// </summary>
        /// <param name="Projet">Projet.</param>
        /// <returns></returns>
        public async Task<Projet> GetProjetById(int id)
        {
            

            return await _trelloDBContext.Projet
                .Include(e => e.Taches).ThenInclude(t => t.Actions)
                .Include(e => e.Taches).ThenInclude(t => t.IdstatutTacheNavigation)
                .Include(e => e.MembreProjets).ThenInclude(m => m.IdutilisateurNavigation)
                //.Include(e => e.Taches.Select(t => t.Title))
                .FirstOrDefaultAsync(x => x.Idprojet == id)
                .ConfigureAwait(false);

        }
    }
}

