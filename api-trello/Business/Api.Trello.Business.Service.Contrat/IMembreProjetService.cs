using System;
using Api.Trello.Business.Dto.MembreProjetDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface IMembreProjetService
	{
        /// <summary>
        /// Permet tde récupérer la liste des MembreProjet.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadMembreProjetDto>> GetMembreProjet();



        /// <summary>
        /// Permet de créer un MembreProjet avec ses informations
        /// </summary>
        /// <param name="MembreProjetDTO">Info du MembreProjet</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadMembreProjetDto> CreateMembreProjet(CreateMembreProjetDto membreProjetDTO);


        /// Cette méthode permet de supprimer un MembreProjet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadMembreProjetDto> DeleteMembreProjet(int id);


        /// <summary>
        /// Permet de récupérer une MembreProjet par son ID.
        /// </summary>
        /// <param name="id">ID de la MembreProjet à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la MembreProjet.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la MembreProjet.</exception>
        Task<ReadMembreProjetDto> GetMembreProjetById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadMembreProjetDto> UpdateMembreProjet(int membreProjetId, UpdateMembreProjetDto membreProjetDto);


    }
}

