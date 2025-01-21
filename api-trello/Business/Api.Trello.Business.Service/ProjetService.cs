using System;
using Api.Trello.Business.Dto.ProjetDto;
using Api.Trello.Business.Mapper.ProjetMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Repository.Contrat;

namespace Api.Trello.Business.Service
{
	public class ProjetService : IProjetService
	{
        private readonly IProjetRepository _projetRepository;


        public ProjetService(IProjetRepository ProjetRepository)
        {
            _projetRepository = ProjetRepository;
        }


        /// <summary>
        /// Permet tde récupérer la liste des Projet.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadProjetDto>> GetProjet()
        {
            var Projet = await _projetRepository.GetProjet().ConfigureAwait(false);

            List<ReadProjetDto> readProjetDto = new List<ReadProjetDto>();

            foreach (var pro in Projet)
            {
                readProjetDto.Add(ProjetMapper.TransformEntityToReadProjetDTO(pro));
            }

            return readProjetDto;
        }


        /// <summary>
        /// Permet de créer un Projet avec ses informations
        /// </summary>
        /// <param name="ProjetDTO">Info du Projet</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadProjetDto> CreacteProjet(CreateProjetDto projetDTO)
        {
            if (projetDTO == null)
            {
                throw new ArgumentNullException(nameof(projetDTO));
            }

            var ProjetAdd = ProjetMapper.TransformCreateDTOToEntity(projetDTO);

            var ProjetAdded = await _projetRepository.CreateProjet(ProjetAdd).ConfigureAwait(false);

            return ProjetMapper.TransformEntityToReadProjetDTO(ProjetAdded);

        }

        /// Cette méthode permet de supprimer un Projet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadProjetDto> DeleteProjet(int id)
        {
            var ProjetToDelete = await _projetRepository.GetProjetById(id).ConfigureAwait(false);

            if (ProjetToDelete == null)
            {
                throw new Exception($"Projet deletion failure: no Projet exists with this identifier {id}");
            }

            await _projetRepository.DeleteProjet(ProjetToDelete).ConfigureAwait(false);

            return ProjetMapper.TransformEntityToReadProjetDTO(ProjetToDelete);
        }

        /// <summary>
        /// Permet de récupérer une Projet par son ID.
        /// </summary>
        /// <param name="id">ID de la Projet à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la Projet.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la Projet.</exception>
        public async Task<ReadProjetDto> GetProjetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la Projet est invalide.");
            }

            var projet = await _projetRepository.GetProjetById(id).ConfigureAwait(false);

            if (projet == null)
            {
                throw new Exception($"Aucune Projet trouvée avec l'ID {id}");
            }

            return ProjetMapper.TransformEntityToReadProjetDTO(projet);
        }


        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadProjetDto> UpdateProjet(int projetId, UpdateProjetDto projetDto)
        {
            var projetToUpdate = await _projetRepository.GetProjetById(projetId).ConfigureAwait(false);

            if (projetToUpdate == null)
            {
                throw new Exception($"Action update failure: no action exists with this identifier {projetId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
            ProjetMapper.UpdateEntityFromUpdateDto(projetToUpdate, projetDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var projetUpdated = await _projetRepository.UpdateProjet(projetToUpdate).ConfigureAwait(false);

            return ProjetMapper.TransformEntityToReadProjetDTO(projetUpdated);
        }
    }
}

