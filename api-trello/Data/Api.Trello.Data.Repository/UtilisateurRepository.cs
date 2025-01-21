using System;
using System.Security.Principal;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;


namespace Api.Trello.Data.Repository
{
	public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ITrelloDBContext _trelloDBContext;

        public UtilisateurRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur ajouté.</param>
        /// <returns></returns>
        public async Task<Utilisateur> CreateUtilisateur(Utilisateur utilisateurAdd)
        {
            var element = await _trelloDBContext.Utilisateur.AddAsync(utilisateurAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Tache Utilisateur.</param>
        /// <returns></returns>
        public async Task<Utilisateur> DeleteUtilisateur(Utilisateur utilisateurDelete)
        {
            var element = _trelloDBContext.Utilisateur.Remove(utilisateurDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur modifier.</param>
        /// <returns></returns>
        public async Task<Utilisateur> UpdateUtilisateur(Utilisateur utilisateurUpdate)
        {
            var element = _trelloDBContext.Utilisateur.Update(utilisateurUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les Utilisateur sous forme de liste.
        /// </summary>
        /// <param name="Utilisateur">Liste Utilisateur.</param>
        /// <returns></returns>
        public async Task<List<Utilisateur>> GetUtilisateur()
        {
            return await _trelloDBContext.Utilisateur
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un Utilisateur par son id.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur.</param>
        /// <returns></returns>
        public async Task<Utilisateur> GetUtilisateurById(int id)
        {
            return await _trelloDBContext.Utilisateur
                .FirstOrDefaultAsync(x => x.Idutilisateur == id)
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Get an account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Utilisateur> GetUtilisateurByUsernameAsync(string username)
        {
            return await _trelloDBContext.Utilisateur
                .FirstOrDefaultAsync(x => x.Nom == username)
                .ConfigureAwait(false);
        }
    }
}

