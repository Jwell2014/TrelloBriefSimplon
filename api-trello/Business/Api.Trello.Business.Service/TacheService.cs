using System;
using Api.Trello.Business.Dto.TacheDto;
using Api.Trello.Business.Mapper.TacheMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Repository.Contrat;

namespace Api.Trello.Business.Service
{
	public class TacheService : ITacheService
	{
        private readonly ITacheRepository _tacheRepository;


        public TacheService(ITacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }


        /// <summary>
        /// Permet tde récupérer la liste des Tache.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadTacheDto>> GetTache()
        {
            var tache = await _tacheRepository.GetTache().ConfigureAwait(false);

            List<ReadTacheDto> readTacheDto = new List<ReadTacheDto>();

            foreach (var tach in tache)
            {
                readTacheDto.Add(TacheMapper.TransformEntityToReadTacheDTO(tach));
            }

            return readTacheDto;
        }


        /// <summary>
        /// Permet de créer un Tache avec ses informations
        /// </summary>
        /// <param name="TacheDTO">Info du Tache</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadTacheDto> CreacteTache(CreateTacheDto tacheDTO)
        {
            if (tacheDTO == null)
            {
                throw new ArgumentNullException(nameof(tacheDTO));
            }

            var tacheAdd = TacheMapper.TransformCreateDTOToEntity(tacheDTO);

            var tacheAdded = await _tacheRepository.CreateTache(tacheAdd).ConfigureAwait(false);

            return TacheMapper.TransformEntityToReadTacheDTO(tacheAdded);

        }

        /// Cette méthode permet de supprimer un Tache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadTacheDto> DeleteTache(int id)
        {
            var tacheToDelete = await _tacheRepository.GetTacheById(id).ConfigureAwait(false);

            if (tacheToDelete == null)
            {
                throw new Exception($"Tache deletion failure: no Tache exists with this identifier {id}");
            }

            await _tacheRepository.DeleteTache(tacheToDelete).ConfigureAwait(false);

            return TacheMapper.TransformEntityToReadTacheDTO(tacheToDelete);
        }

        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        public async Task<ReadTacheDto> GetTacheById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la Tache est invalide.");
            }

            var tache = await _tacheRepository.GetTacheById(id).ConfigureAwait(false);

            if (tache == null)
            {
                throw new Exception($"Aucune Tache trouvée avec l'ID {id}");
            }

            return TacheMapper.TransformEntityToReadTacheDTO(tache);
        }


        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="StatutTacheId"></param>
        /// <param name="StatutTacheDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadTacheDto> UpdateTache(int tacheId, UpdateTacheDto tacheDto)
        {
            var tacheToUpdate = await _tacheRepository.GetTacheById(tacheId).ConfigureAwait(false);

            if (tacheToUpdate == null)
            {
                throw new Exception($"tache update failure: no tache exists with this identifier {tacheId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
           TacheMapper.UpdateEntityFromUpdateDto(tacheToUpdate, tacheDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var tacheUpdated = await _tacheRepository.UpdateTache(tacheToUpdate).ConfigureAwait(false);

            return TacheMapper.TransformEntityToReadTacheDTO(tacheUpdated);
        }
    }
}

