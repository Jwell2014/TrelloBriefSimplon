using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Data.Repository.Contrat
{
	public interface ITacheRepository
	{

        /// <summary>
        /// Cette methode permet de créer une Tache.
        /// </summary>
        /// <param name="Tache">Tache ajouté.</param>
        /// <returns></returns>
        Task<Tache> CreateTache(Tache tacheAdd);


        /// <summary>
        /// Cette methode permet de supprimer un Tache.
        /// </summary>
        /// <param name="Tache">Tache supprimer.</param>
        /// <returns></returns>
        Task<Tache> DeleteTache(Tache tacheDelete);


        /// <summary>
        /// Cette methode permet de modifier un Tache.
        /// </summary>
        /// <param name="Tache">Tache modifier.</param>
        /// <returns></returns>
        Task<Tache> UpdateTache(Tache tacheUpdate);


        /// <summary>
        /// Cette methode permet d'afficher tout les Tache sous forme de liste.
        /// </summary>
        /// <param name="Tache">Liste Tache.</param>
        /// <returns></returns>
        Task<List<Tache>> GetTache();


        /// <summary>
        /// Cette methode permet d'afficher un Tache par son id.
        /// </summary>
        /// <param name="Tache">Tache.</param>
        /// <returns></returns>
        Task<Tache> GetTacheById(int id);

    }
}

