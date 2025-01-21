using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Data.Repository.Contrat
{
	public interface IStatusTacheRepository
	{

        /// <summary>
        /// Cette methode permet de créer une StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache ajouté.</param>
        /// <returns></returns>
        Task<StatutTache> CreateStatutTache(StatutTache statutTacheAdd);


        /// <summary>
        /// Cette methode permet de supprimer un StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache supprimer.</param>
        /// <returns></returns>
        Task<StatutTache> DeleteStatutTache(StatutTache statutTacheDelete);


        /// <summary>
        /// Cette methode permet de modifier un StatutTache.
        /// </summary>
        /// <param name="StatutTache">StatutTache modifier.</param>
        /// <returns></returns>
        Task<StatutTache> UpdateStatutTache(StatutTache statutTacheUpdate);


        /// <summary>
        /// Cette methode permet d'afficher tout les StatutTache sous forme de liste.
        /// </summary>
        /// <param name="StatutTache">Liste StatutTache.</param>
        /// <returns></returns>
        Task<List<StatutTache>> GetStatutTache();


        /// <summary>
        /// Cette methode permet d'afficher un StatutTache par son id.
        /// </summary>
        /// <param name="StatutTache">StatutTache.</param>
        /// <returns></returns>
        Task<StatutTache> GetStatutTacheById(int id);

    }
}
