using System;
using Api.Trello.Business.Dto.Utilisateur;
using Api.Trello.Business.Dto.UtilisateurDto;
using Api.Trello.Business.Mapper.UtilisateurMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository.Contrat;

namespace Api.Trello.Business.Service
{
	public class UtilisateurService : IUtilisateurService
	{
        private readonly IUtilisateurRepository _utilisateurRepository;


        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }


        /// <summary>
        /// Permet de récupérer la liste des utilisateur.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadUtilisateurDto>> GetUtilisateur()
        {
            var utilisateur = await _utilisateurRepository.GetUtilisateur().ConfigureAwait(false);

            List<ReadUtilisateurDto> readUtilisateurDto = new List<ReadUtilisateurDto>();

            foreach (var util in utilisateur)
            {
                readUtilisateurDto.Add(UtilisateurMapper.TransformEntityToReadUtilisateurDTO(util));
            }

            return readUtilisateurDto;
        }


        /// <summary>
        /// Permet de créer un utilisateur avec ses informations
        /// </summary>
        /// <param name="UtilisateurDTO">Info du Tache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadUtilisateurDto> CreacteUtilisateur(CreateUtilisateurDto utilisateurDTO)
        {
            if (utilisateurDTO == null)
            {
                throw new ArgumentNullException(nameof(utilisateurDTO));
            }

            var utilisateurAdd = UtilisateurMapper.TransformCreateDTOToEntity(utilisateurDTO);

            var utilisateurAdded = await _utilisateurRepository.CreateUtilisateur(utilisateurAdd).ConfigureAwait(false);

            return UtilisateurMapper.TransformEntityToReadUtilisateurDTO(utilisateurAdded);

        }

        /// Cette méthode permet de supprimer un Utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadUtilisateurDto> DeleteUtilisateur(int id)
        {
            var utilisateurToDelete = await _utilisateurRepository.GetUtilisateurById(id).ConfigureAwait(false);

            if (utilisateurToDelete == null)
            {
                throw new Exception($"Utilisateur deletion failure: no Utilisateur exists with this identifier {id}");
            }

            await _utilisateurRepository.DeleteUtilisateur(utilisateurToDelete).ConfigureAwait(false);

            return UtilisateurMapper.TransformEntityToReadUtilisateurDTO(utilisateurToDelete);
        }

        /// <summary>
        /// Permet de récupérer une Utilisateur par son ID.
        /// </summary>
        /// <param name="id">ID de la Utilisateur à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la Utilisateur.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la Utilisateur.</exception>
        public async Task<ReadUtilisateurDto> GetUtilisateurById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la Utilisateur est invalide.");
            }

            var utilisateur = await _utilisateurRepository.GetUtilisateurById(id).ConfigureAwait(false);

            if (utilisateur == null)
            {
                throw new Exception($"Aucune Utilisateur trouvée avec l'ID {id}");
            }

            return UtilisateurMapper.TransformEntityToReadUtilisateurDTO(utilisateur);
        }


        /// <summary>
        /// Cette méthode permet de modifier un Utilisateur
        /// </summary>
        /// <param name="UtilisateurId"></param>
        /// <param name="UtilisateurDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadUtilisateurDto> UpdateUtilisateur(int utilisateurId, UpdateUtilisateurDto utilisateurDto)
        {
            var utilisateurToUpdate = await _utilisateurRepository.GetUtilisateurById(utilisateurId).ConfigureAwait(false);

            if (utilisateurToUpdate == null)
            {
                throw new Exception($"Utilisateur update failure: no Utilisateur exists with this identifier {utilisateurId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
            UtilisateurMapper.UpdateEntityFromUpdateDto(utilisateurToUpdate, utilisateurDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var utilisateurUpdated = await _utilisateurRepository.UpdateUtilisateur(utilisateurToUpdate).ConfigureAwait(false);

            return UtilisateurMapper.TransformEntityToReadUtilisateurDTO(utilisateurUpdated);
        }

        /// <summary>
        /// Return an Account by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ReadUtilisateurDto> GetUtilisateurByUsername(string username)
        {
            var account = await _utilisateurRepository.GetUtilisateurByUsernameAsync(username);
            return UtilisateurMapper.TransformEntityToReadUtilisateurDTO(account);
        }

        /// <summary>
        /// Allow login
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public async Task<bool> login(AuthUtilisateurDto utilisateurDto)
        {
            var account = await _utilisateurRepository.GetUtilisateurByUsernameAsync(utilisateurDto.Nom);

            if (account != null)
            {
                if (account.MotDePasse == utilisateurDto.MotDePasse)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

