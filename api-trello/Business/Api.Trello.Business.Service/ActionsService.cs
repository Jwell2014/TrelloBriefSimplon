using System;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Mapper.ActionsMapper;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Repository;
using Api.Trello.Data.Repository.Contrat;

namespace Api.Trello.Business.Service
{
	public class ActionsService : IActionsService
    {
        private readonly IActionRepository _actionRepository;


        public ActionsService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }


        /// <summary>
        /// Permet tde récupérer la liste des mesure.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadActionsDto>> GetAction()
        {
            var actions = await _actionRepository.GetAction().ConfigureAwait(false);

            List<ReadActionsDto> readActionsDto = new List<ReadActionsDto>();

            foreach (var action in actions)
            {
                readActionsDto.Add(ActionsMapper.TransformEntityToReadActionDTO(action));
            }

            return readActionsDto;
        }


        /// <summary>
        /// Permet de créer un action avec ses informations
        /// </summary>
        /// <param name="actionDTO">Info du action</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadActionsDto> CreateAction(CreateActionsDto actionDTO)
        {
            if (actionDTO == null)
            {
                throw new ArgumentNullException(nameof(actionDTO));
            }

            var actionAdd = ActionsMapper.TransformCreateDTOToEntity(actionDTO);

            var actionAdded = await _actionRepository.CreateAction(actionAdd).ConfigureAwait(false);

            return ActionsMapper.TransformEntityToReadActionDTO(actionAdded);

        }

        /// Cette méthode permet de supprimer un action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadActionsDto> DeleteAction(int id)
        {
            var actionToDelete = await _actionRepository.GetActionById(id).ConfigureAwait(false);

            if (actionToDelete == null)
            {
                throw new Exception($"Action deletion failure: no action exists with this identifier {id}");
            }

            await _actionRepository.DeleteAction(actionToDelete).ConfigureAwait(false);

            return ActionsMapper.TransformEntityToReadActionDTO(actionToDelete);
        }

        /// <summary>
        /// Permet de récupérer une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Une tâche asynchrone qui représente l'opération de récupération de la action.</returns>
        /// <exception cref="ArgumentNullException">Si l'ID est invalide.</exception>
        /// <exception cref="Exception">En cas d'erreur lors de la récupération de la action.</exception>
        public async Task<ReadActionsDto> GetActionById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id), "L'ID de la action est invalide.");
            }

            var action = await _actionRepository.GetActionById(id).ConfigureAwait(false);

            if (action == null)
            {
                throw new Exception($"Aucune action trouvée avec l'ID {id}");
            }

            return ActionsMapper.TransformEntityToReadActionDTO(action);
        }


        /// <summary>
        /// Cette méthode permet de modifier un action
        /// </summary>
        /// <param name="actiontId"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadActionsDto> UpdateAction(int actionId, UpdateActionsDto actionDto)
        {
            var actionToUpdate = await _actionRepository.GetActionById(actionId).ConfigureAwait(false);

            if (actionToUpdate == null)
            {
                throw new Exception($"Action update failure: no action exists with this identifier {actionId}");
            }

            // Met à jour les propriétés de l'action existante avec les nouvelles valeurs.
            ActionsMapper.UpdateEntityFromUpdateDto(actionToUpdate, actionDto);

            // Appelle le service pour effectuer la mise à jour dans la base de données
            var actionUpdated = await _actionRepository.UpdateAction(actionToUpdate).ConfigureAwait(false);

            return ActionsMapper.TransformEntityToReadActionDTO(actionUpdated);
        }


    }
}

