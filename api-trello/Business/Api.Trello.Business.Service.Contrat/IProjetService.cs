using System;
using Api.Trello.Business.Dto.ProjetDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface IProjetService
	{

        /// <summary>
        /// Permet tde récupérer la liste des Projet.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadProjetDto>> GetProjet();

        /// <summary>
        /// Permet de créer un Projet avec ses informations
        /// </summary>
        /// <param name="ProjetDTO">Info du Projet</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadProjetDto> CreacteProjet(CreateProjetDto projetDTO);

        /// Cette méthode permet de supprimer un Projet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadProjetDto> DeleteProjet(int id);

        /// <summary>
        /// Permet de récupérer une Projet par son ID.
        /// </summary>
        /// <param name="id">ID de la Projet à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la Projet.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la Projet.</exception>
        Task<ReadProjetDto> GetProjetById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadProjetDto> UpdateProjet(int projetId, UpdateProjetDto projetDto);

    }
}

