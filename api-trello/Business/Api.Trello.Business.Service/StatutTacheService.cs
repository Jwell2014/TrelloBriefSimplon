using System;
using Api.Trello.Business.Dto.StatutTacheDto;
using Api.Trello.Business.Mapper.StatutTacheMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Repository.Contrat;

namespace Api.Trello.Business.Service
{
	public class StatutTacheService : IStatutTacheService
    {
        private readonly IStatusTacheRepository _statutTacheRepository;


        public StatutTacheService(IStatusTacheRepository statutTacheRepository)
        {
            _statutTacheRepository = statutTacheRepository;
        }


        /// <summary>
        /// Permet tde récupérer la liste des statutTache.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadStatutTacheDto>> GetStatutTache()
        {
            var statutTache = await _statutTacheRepository.GetStatutTache().ConfigureAwait(false);

            List<ReadStatutTacheDto> readStatutTacheDto = new List<ReadStatutTacheDto>();

            foreach (var statutTach in statutTache)
            {
                readStatutTacheDto.Add(StatutTacheMapper.TransformEntityToReadStatutTacheDTO(statutTach));
            }

            return readStatutTacheDto;
        }


        /// <summary>
        /// Permet de créer un statutTache avec ses informations
        /// </summary>
        /// <param name="statutTacheDTO">Info du statutTache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadStatutTacheDto> CreacteStatutTache(CreateStatutTacheDto statutTacheDTO)
        {
            if (statutTacheDTO == null)
            {
                throw new ArgumentNullException(nameof(statutTacheDTO));
            }

            var statutTacheAdd = StatutTacheMapper.TransformCreateDTOToEntity(statutTacheDTO);

            var statutTacheAdded = await _statutTacheRepository.CreateStatutTache(statutTacheAdd).ConfigureAwait(false);

            return StatutTacheMapper.TransformEntityToReadStatutTacheDTO(statutTacheAdded);

        }

        /// Cette méthode permet de supprimer un statutTache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadStatutTacheDto> DeleteStatutTache(int id)
        {
            var statutTacheToDelete = await _statutTacheRepository.GetStatutTacheById(id).ConfigureAwait(false);

            if (statutTacheToDelete == null)
            {
                throw new Exception($"StatutTache deletion failure: no StatutTache exists with this identifier {id}");
            }

            await _statutTacheRepository.DeleteStatutTache(statutTacheToDelete).ConfigureAwait(false);

            return StatutTacheMapper.TransformEntityToReadStatutTacheDTO(statutTacheToDelete);
        }

        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        public async Task<ReadStatutTacheDto> GetStatutTacheById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la statutTache est invalide.");
            }

            var statutTache = await _statutTacheRepository.GetStatutTacheById(id).ConfigureAwait(false);

            if (statutTache == null)
            {
                throw new Exception($"Aucune statutTache trouvée avec l'ID {id}");
            }

            return StatutTacheMapper.TransformEntityToReadStatutTacheDTO(statutTache);
        }


        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="StatutTacheId"></param>
        /// <param name="StatutTacheDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadStatutTacheDto> UpdateStatutTache(int statutTacheId, UpdateStatutTacheDto statutTacheDto)
        {
            var statutTacheToUpdate = await _statutTacheRepository.GetStatutTacheById(statutTacheId).ConfigureAwait(false);

            if (statutTacheToUpdate == null)
            {
                throw new Exception($"Action update failure: no action exists with this identifier {statutTacheId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
            StatutTacheMapper.UpdateEntityFromUpdateDto(statutTacheToUpdate, statutTacheDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var actionUpdated = await _statutTacheRepository.UpdateStatutTache(statutTacheToUpdate).ConfigureAwait(false);

            return StatutTacheMapper.TransformEntityToReadStatutTacheDTO(actionUpdated);
        }

        
    }
}

