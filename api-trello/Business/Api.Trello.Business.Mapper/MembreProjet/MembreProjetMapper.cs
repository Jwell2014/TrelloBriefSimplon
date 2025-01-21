using System;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Dto.MembreProjetDto;

namespace Api.Trello.Business.Mapper.MembreProjetMapper
{
	public class MembreProjetMapper
	{
        /// <summary>
        /// Transforme CreateActionsDto en entity MembreProjet
        /// </summary>
        /// <param name="createMembreProjetDTO"></param>
        /// <returns></returns>
        public static Data.Entity.Model.MembreProjet TransformCreateDTOToEntity(CreateMembreProjetDto createMembreProjetDTO)
        {
            return new Data.Entity.Model.MembreProjet()
            {
                Idutilisateur = createMembreProjetDTO.Idutilisateur,
                Idprojet = createMembreProjetDTO.Idprojet,
            };
        }

        /// <summary>
        /// Transforme readMembreProjetDtoDTO en entity MembreProjet
        /// </summary>
        /// <param name="readMembreProjetDtoDTO"></param>
        /// <returns></returns>
        public static ReadMembreProjetDto TransformEntityToReadMembreProjetDTO(Data.Entity.Model.MembreProjet membreProjet)
        {
            var readMembreProjetDtoDTO = new ReadMembreProjetDto()
            {
                IdmembreProjet = membreProjet.IdmembreProjet,
                Idutilisateur = membreProjet.Idutilisateur,
                Idprojet = membreProjet.Idprojet,
            };

            return readMembreProjetDtoDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet Produit et un objet UpdateProduitDto en entrée
        /// et met à jour les propriétés de l'objet Produit en utilisant les valeurs de l'objet UpdateProduitDto.
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="updateProduit"></param>
        public static void UpdateEntityFromUpdateDto(Data.Entity.Model.MembreProjet existingMembreProjet, UpdateMembreProjetDto updateMembreProjet)
        {
            existingMembreProjet.Idutilisateur = updateMembreProjet.Idutilisateur ?? existingMembreProjet.Idutilisateur;
            existingMembreProjet.Idprojet = updateMembreProjet.Idprojet ?? existingMembreProjet.Idprojet;
        }
    }
}

