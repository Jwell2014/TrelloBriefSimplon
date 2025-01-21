using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Data.Repository.Contrat
{
	public interface IUtilisateurRepository
	{
        /// <summary>
        /// Cette methode permet de créer une Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur ajouté.</param>
        /// <returns></returns>
        Task<Utilisateur> CreateUtilisateur(Utilisateur utilisateurAdd);


        /// <summary>
        /// Cette methode permet de supprimer un Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Tache Utilisateur.</param>
        /// <returns></returns>
        Task<Utilisateur> DeleteUtilisateur(Utilisateur utilisateurDelete);



        /// <summary>
        /// Cette methode permet de modifier un Utilisateur.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur modifier.</param>
        /// <returns></returns>
        Task<Utilisateur> UpdateUtilisateur(Utilisateur utilisateurUpdate);


        /// <summary>
        /// Cette methode permet d'afficher tout les Utilisateur sous forme de liste.
        /// </summary>
        /// <param name="Utilisateur">Liste Utilisateur.</param>
        /// <returns></returns>
        Task<List<Utilisateur>> GetUtilisateur();


        /// <summary>
        /// Cette methode permet d'afficher un Utilisateur par son id.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur.</param>
        /// <returns></returns>
        Task<Utilisateur> GetUtilisateurById(int id);

        /// <summary>
        /// Cette methode permet d'afficher un Utilisateur par son nom.
        /// </summary>
        /// <param name="Utilisateur">Utilisateur.</param>
        /// <returns></returns>
        Task<Utilisateur> GetUtilisateurByUsernameAsync(string username);

    }
}

