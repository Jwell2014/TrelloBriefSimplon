using System;
using Api.Trello.Business.Dto.ActionsDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface IActionsService
	{

        /// <summary>
        /// Permet tde récupérer la liste des mesure.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadActionsDto>> GetAction();

        /// <summary>
        /// Permet de créer un action avec ses informations
        /// </summary>
        /// <param name="actionDTO">Info du action</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadActionsDto> CreateAction(CreateActionsDto actionDTO);

        /// Cette méthode permet de supprimer un action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadActionsDto> DeleteAction(int id);


        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        Task<ReadActionsDto> GetActionById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadActionsDto> UpdateAction(int actionId, UpdateActionsDto actionDto);
    }
}

