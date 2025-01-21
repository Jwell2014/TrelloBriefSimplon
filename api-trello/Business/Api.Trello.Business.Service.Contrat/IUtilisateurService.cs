using System;
using Api.Trello.Business.Dto.Utilisateur;
using Api.Trello.Business.Dto.UtilisateurDto;

namespace Api.Trello.Business.Service.Contrat
{
	public interface IUtilisateurService
	{

        /// <summary>
        /// Permet tde récupérer la liste des Tache.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadUtilisateurDto>> GetUtilisateur();

        /// <summary>
        /// Permet de créer un Tache avec ses informations
        /// </summary>
        /// <param name="UtilisateurDTO">Info du Tache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadUtilisateurDto> CreacteUtilisateur(CreateUtilisateurDto utilisateurDTO);

        /// Cette méthode permet de supprimer un Utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadUtilisateurDto> DeleteUtilisateur(int id);

        /// <summary>
        /// Permet de récupérer une Utilisateur par son ID.
        /// </summary>
        /// <param name="id">ID de la Utilisateur à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la Utilisateur.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la Utilisateur.</exception>
        Task<ReadUtilisateurDto> GetUtilisateurById(int id);

        /// <summary>
        /// Cette méthode permet de modifier un Utilisateur
        /// </summary>
        /// <param name="UtilisateurId"></param>
        /// <param name="UtilisateurDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadUtilisateurDto> UpdateUtilisateur(int utilisateurId, UpdateUtilisateurDto utilisateurDto);

        /// <summary>
        /// Return an Account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<ReadUtilisateurDto> GetUtilisateurByUsername(string username);


        /// <summary>
        /// Allow login
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        Task<bool> login(AuthUtilisateurDto utilisateurDto);



    }
}

