using System;
using Api.Trello.Business.Dto.MembreProjetDto;
using Api.Trello.Business.Dto.ProjetDto;

namespace Api.Trello.Business.Mapper.ProjetMapper
{
	public class ProjetMapper
	{
        /// <summary>
        /// Transforme CreateActionsDto en entity MembreProjet
        /// </summary>
        /// <param name="createProjetDTO"></param>
        /// <returns></returns>
        public static Data.Entity.Model.Projet TransformCreateDTOToEntity(CreateProjetDto createProjetDTO)
        {
            return new Data.Entity.Model.Projet()
            {
                NomProjet = createProjetDTO.NomProjet,
                Idresponsable = createProjetDTO.Idresponsable,
                DateDebut = createProjetDTO.DateDebut,
                DateFinPrevue = createProjetDTO.DateFinPrevue,
                DetailsDuProjet = createProjetDTO.DetailsDuProjet,

            };
        }

        /// <summary>
        /// Transforme readMembreProjetDtoDTO en entity MembreProjet
        /// </summary>
        /// <param name="readMembreProjetDtoDTO"></param>
        /// <returns></returns>
        public static ReadProjetDto TransformEntityToReadProjetDTO(Data.Entity.Model.Projet projet)
        {
            var readProjetDtoDTO = new ReadProjetDto()
            {
                Idprojet = projet.Idprojet,
                NomProjet = projet.NomProjet,
                Idresponsable = projet.Idresponsable,
                DateDebut = projet.DateDebut,
                DateFinPrevue = projet.DateFinPrevue,
                DetailsDuProjet = projet.DetailsDuProjet,
                MembreProjets = projet.MembreProjets,
                Taches = projet.Taches,

            };

            return readProjetDtoDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet Produit et un objet UpdateProduitDto en entrée
        /// et met à jour les propriétés de l'objet Produit en utilisant les valeurs de l'objet UpdateProduitDto.
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="updateProduit"></param>
        public static void UpdateEntityFromUpdateDto(Data.Entity.Model.Projet existingProjet, UpdateProjetDto updateProjet)
        {
            existingProjet.NomProjet = updateProjet.NomProjet ?? existingProjet.NomProjet;
            existingProjet.Idresponsable = updateProjet.Idresponsable ?? existingProjet.Idresponsable;
            existingProjet.DateDebut = updateProjet.DateDebut ?? existingProjet.DateDebut;
            existingProjet.DateFinPrevue = updateProjet.DateFinPrevue ?? existingProjet.DateFinPrevue;
            existingProjet.DetailsDuProjet = updateProjet.DetailsDuProjet ?? existingProjet.DetailsDuProjet;

        }
    }
}

