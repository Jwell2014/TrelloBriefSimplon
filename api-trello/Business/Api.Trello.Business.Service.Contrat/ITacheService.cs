using System;
using Api.Trello.Business.Dto.TacheDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface ITacheService
	{

        /// <summary>
        /// Permet tde récupérer la liste des Tache.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadTacheDto>> GetTache();

        /// <summary>
        /// Permet de créer un Tache avec ses informations
        /// </summary>
        /// <param name="TacheDTO">Info du Tache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadTacheDto> CreacteTache(CreateTacheDto tacheDTO);

        /// Cette méthode permet de supprimer un Tache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadTacheDto> DeleteTache(int id);

        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        Task<ReadTacheDto> GetTacheById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="StatutTacheId"></param>
        /// <param name="StatutTacheDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadTacheDto> UpdateTache(int tacheId, UpdateTacheDto tacheDto);






    }
}

