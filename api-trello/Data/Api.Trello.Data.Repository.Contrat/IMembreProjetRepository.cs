using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Data.Repository.Contrat
{
	public interface IMembreProjetRepository
	{

        /// <summary>
        /// Cette methode permet de créer une MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">Projet MembreProjet.</param>
        /// <returns></returns>
        Task<MembreProjet> CreateMembreProjet(MembreProjet actionAdd);

        /// <summary>
        /// Cette methode permet de supprimer un MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet supprimer.</param>
        /// <returns></returns>
        Task<MembreProjet> DeleteMembreProjet(MembreProjet actionDelete);

        /// <summary>
        /// Cette methode permet de modifier un MembreProjet.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet modifier.</param>
        /// <returns></returns>
        Task<MembreProjet> UpdateMembreProjet(MembreProjet actionUpdate);

        /// <summary>
        /// Cette methode permet d'afficher tout les MembreProjet sous forme de liste.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet Projet.</param>
        /// <returns></returns>
        Task<List<MembreProjet>> GetMembreProjet();

        /// <summary>
        /// Cette methode permet d'afficher un MembreProjet par son id.
        /// </summary>
        /// <param name="MembreProjet">MembreProjet.</param>
        /// <returns></returns>
        Task<MembreProjet> GetMembreProjetById(int id);

    }
}

