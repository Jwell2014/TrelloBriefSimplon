using System;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Dto.StatutTacheDto;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Mapper.StatutTacheMapper
{
	public class StatutTacheMapper
	{
        /// <summary>
        /// Transforme CreateActionsDto en entity Actions
        /// </summary>
        /// <param name="CreateActionsDto"></param>
        /// <returns></returns>
        public static StatutTache TransformCreateDTOToEntity(CreateStatutTacheDto createStatutTacheDTO)
        {
            return new StatutTache()
            {
                LibelleStatut = createStatutTacheDTO.LibelleStatut,
            };
        }

        /// <summary>
        /// Transforme ReadActionsDTO en entity Mesure
        /// </summary>
        /// <param name="ReadMesureDTO"></param>
        /// <returns></returns>
        public static ReadStatutTacheDto TransformEntityToReadStatutTacheDTO(StatutTache statutTache)
        {
            var readStatutTacheDTO = new ReadStatutTacheDto()
            {
                IdstatutTache = statutTache.IdstatutTache,
                LibelleStatut = statutTache.LibelleStatut,
                Taches = statutTache.Taches,


            };

            return readStatutTacheDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet Produit et un objet UpdateProduitDto en entrée
        /// et met à jour les propriétés de l'objet Produit en utilisant les valeurs de l'objet UpdateProduitDto.
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="updateProduit"></param>
        public static void UpdateEntityFromUpdateDto(StatutTache existingStatutTache, UpdateStatutTacheDto updateStatutTache)
        {
            existingStatutTache.LibelleStatut = updateStatutTache.LibelleStatut ?? existingStatutTache.LibelleStatut;
        }
    }
}

