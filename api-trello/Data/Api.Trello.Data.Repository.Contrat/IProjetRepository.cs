using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Data.Repository.Contrat
{
	public interface IProjetRepository
	{
        /// <summary>
        /// Cette methode permet de créer une Projet.
        /// </summary>
        /// <param name="Projet">Projet ajouté.</param>
        /// <returns></returns>
        Task<Projet> CreateProjet(Projet projetAdd);


        /// <summary>
        /// Cette methode permet de supprimer un Projet.
        /// </summary>
        /// <param name="Projet">Projet supprimer.</param>
        /// <returns></returns>
        Task<Projet> DeleteProjet(Projet projetDelete);


        /// <summary>
        /// Cette methode permet de modifier un Projet.
        /// </summary>
        /// <param name="Projet">Projet modifier.</param>
        /// <returns></returns>
        Task<Projet> UpdateProjet(Projet projetUpdate);


        /// <summary>
        /// Cette methode permet d'afficher tout les Projet sous forme de liste.
        /// </summary>
        /// <param name="Projet">Liste Projet.</param>
        /// <returns></returns>
        Task<List<Projet>> GetProjet();


        /// <summary>
        /// Cette methode permet d'afficher un Projet par son id.
        /// </summary>
        /// <param name="Projet">Projet.</param>
        /// <returns></returns>
        Task<Projet> GetProjetById(int id);

    }
}

