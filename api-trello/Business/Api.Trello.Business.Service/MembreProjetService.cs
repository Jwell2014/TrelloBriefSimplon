using System;
using Api.Trello.Business.Dto.MembreProjetDto;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.Business.Mapper.MembreProjetMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Business.Dto.UtilisateurDto;
using Api.Trello.Business.Mapper.UtilisateurMapper;
using Api.Trello.Data.Repository;

namespace Api.Trello.Business.Service
{
	public class MembreProjetService : IMembreProjetService
	{
        private readonly IMembreProjetRepository _membreProjetRepository;


        public MembreProjetService(IMembreProjetRepository membreProjetRepository)
        {
            _membreProjetRepository = membreProjetRepository;
        }


        /// <summary>
        /// Permet tde récupérer la liste des MembreProjet.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadMembreProjetDto>> GetMembreProjet()
        {
            var membreProjet = await _membreProjetRepository.GetMembreProjet().ConfigureAwait(false);

            List<ReadMembreProjetDto> readMembreProjetDto = new List<ReadMembreProjetDto>();

            foreach (var membrePro in membreProjet)
            {
                readMembreProjetDto.Add(MembreProjetMapper.TransformEntityToReadMembreProjetDTO(membrePro));
            }

            return readMembreProjetDto;
        }


        /// <summary>
        /// Permet de créer un MembreProjet avec ses informations
        /// </summary>
        /// <param name="MembreProjetDTO">Info du MembreProjet</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMembreProjetDto> CreateMembreProjet(CreateMembreProjetDto membreProjetDTO)
        {
            if (membreProjetDTO == null)
            {
                throw new ArgumentNullException(nameof(membreProjetDTO));
            }

            var membreProjetAdd = MembreProjetMapper.TransformCreateDTOToEntity(membreProjetDTO);

            var membreProjetAdded = await _membreProjetRepository.CreateMembreProjet(membreProjetAdd).ConfigureAwait(false);

            return MembreProjetMapper.TransformEntityToReadMembreProjetDTO(membreProjetAdded);

        }

        /// Cette méthode permet de supprimer un MembreProjet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMembreProjetDto> DeleteMembreProjet(int id)
        {
            var membreProjetToDelete = await _membreProjetRepository.GetMembreProjetById(id).ConfigureAwait(false);

            if (membreProjetToDelete == null)
            {
                throw new Exception($"MembreProjet deletion failure: no MembreProjet exists with this identifier {id}");
            }

            await _membreProjetRepository.DeleteMembreProjet(membreProjetToDelete).ConfigureAwait(false);

            return MembreProjetMapper.TransformEntityToReadMembreProjetDTO(membreProjetToDelete);
        }

        /// <summary>
        /// Permet de récupérer une MembreProjet par son ID.
        /// </summary>
        /// <param name="id">ID de la MembreProjet à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la MembreProjet.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la MembreProjet.</exception>
        public async Task<ReadMembreProjetDto> GetMembreProjetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la MembreProjet est invalide.");
            }

            var membreProjet = await _membreProjetRepository.GetMembreProjetById(id).ConfigureAwait(false);

            if (membreProjet == null)
            {
                throw new Exception($"Aucune MembreProjet trouvée avec l'ID {id}");
            }

            return MembreProjetMapper.TransformEntityToReadMembreProjetDTO(membreProjet);
        }


        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMembreProjetDto> UpdateMembreProjet(int membreProjetId, UpdateMembreProjetDto membreProjetDto)
        {
            var membreProjetToUpdate = await _membreProjetRepository.GetMembreProjetById(membreProjetId).ConfigureAwait(false);

            if (membreProjetToUpdate == null)
            {
                throw new Exception($"Action update failure: no action exists with this identifier {membreProjetId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
            MembreProjetMapper.UpdateEntityFromUpdateDto(membreProjetToUpdate, membreProjetDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var membreProjetUpdated = await _membreProjetRepository.UpdateMembreProjet(membreProjetToUpdate).ConfigureAwait(false);

            return MembreProjetMapper.TransformEntityToReadMembreProjetDTO(membreProjetUpdated);
        }
    }
}

