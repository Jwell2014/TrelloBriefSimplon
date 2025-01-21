using System;
using Api.Trello.Business.Dto.StatutTacheDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface IStatutTacheService
	{
        /// <summary>
        /// Permet tde récupérer la liste des statutTache.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadStatutTacheDto>> GetStatutTache();

        /// <summary>
        /// Permet de créer un statutTache avec ses informations
        /// </summary>
        /// <param name="statutTacheDTO">Info du statutTache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadStatutTacheDto> CreacteStatutTache(CreateStatutTacheDto statutTacheDTO);

        /// Cette méthode permet de supprimer un statutTache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadStatutTacheDto> DeleteStatutTache(int id);

        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        Task<ReadStatutTacheDto> GetStatutTacheById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadStatutTacheDto> UpdateStatutTache(int statutTacheId, UpdateStatutTacheDto statutTacheDto);
    }
}

