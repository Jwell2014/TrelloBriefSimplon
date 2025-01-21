using System;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Data.Entity.Model;


namespace Api.Trello.Business.Mapper.ActionsMapper
{
	public class ActionsMapper
	{
        /// <summary>
        /// Transforme CreateActionsDto en entity Actions
        /// </summary>
        /// <param name="CreateActionsDto"></param>
        /// <returns></returns>
        public static Data.Entity.Model.Action TransformCreateDTOToEntity(CreateActionsDto createActionsDTO)
        {
            return new Data.Entity.Model.Action()
            {
                Description = createActionsDTO.Description,
                EstTerminee = createActionsDTO.EstTerminee,
                Idtache = createActionsDTO.Idtache,
            };
        }

        /// <summary>
        /// Transforme ReadActionsDTO en entity Mesure
        /// </summary>
        /// <param name="ReadMesureDTO"></param>
        /// <returns></returns>
        public static ReadActionsDto TransformEntityToReadActionDTO(Data.Entity.Model.Action actions)
        {
            var readActionsDTO = new ReadActionsDto()
            {
                Idaction = actions.Idaction,
                Description = actions.Description,
                EstTerminee = actions.EstTerminee,
                Idtache = actions.Idtache,
            };

            return readActionsDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet Produit et un objet UpdateProduitDto en entrée
        /// et met à jour les propriétés de l'objet Produit en utilisant les valeurs de l'objet UpdateProduitDto.
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="updateProduit"></param>
        public static void UpdateEntityFromUpdateDto(Data.Entity.Model.Action existingAction, UpdateActionsDto updateAction)
        {
            existingAction.Description = updateAction.Description ?? existingAction.Description;
            existingAction.EstTerminee = updateAction.EstTerminee ?? existingAction.EstTerminee;
            existingAction.Idtache = updateAction.Idtache ?? existingAction.Idtache;
        }

    }
}

