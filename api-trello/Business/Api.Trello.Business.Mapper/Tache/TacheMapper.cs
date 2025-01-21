using System;
using Api.Trello.Business.Dto.StatutTacheDto;
using Api.Trello.Business.Dto.TacheDto;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Mapper.TacheMapper
{
	public class TacheMapper
	{
        /// <summary>
        /// Transforme CreateActionsDto en entity Actions
        /// </summary>
        /// <param name="CreateActionsDto"></param>
        /// <returns></returns>
        public static Tache TransformCreateDTOToEntity(CreateTacheDto createTacheDTO)
        {
            return new Tache()
            {
                

                Description = createTacheDTO.Description,

                DateLimite = createTacheDTO.DateLimite,

                Idresponsable = createTacheDTO.Idresponsable,

                PourcentageProgression = createTacheDTO.PourcentageProgression,

                Idprojet = createTacheDTO.Idprojet,

                IdstatutTache = createTacheDTO.IdstatutTache,

            };
        }

        /// <summary>
        /// Transforme ReadActionsDTO en entity Mesure
        /// </summary>
        /// <param name="ReadTacheDTO"></param>
        /// <returns></returns>
        public static ReadTacheDto TransformEntityToReadTacheDTO(Tache tache)
        {
            var readTacheDTO = new ReadTacheDto()
            {
                Idtache = tache.Idtache,

                Description = tache.Description,

                DateLimite = tache.DateLimite,

                Idresponsable = tache.Idresponsable,

                PourcentageProgression = tache.PourcentageProgression,

                Idprojet = tache.Idprojet,

                IdstatutTache = tache.IdstatutTache,

            };

            return readTacheDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet tache et un objet UpdatetacheDto en entrée
        /// et met à jour les propriétés de l'objet tache en utilisant les valeurs de l'objet UpdatetacheDto.
        /// </summary>
        /// <param name="tache"></param>
        /// <param name="updatetache"></param>
        public static void UpdateEntityFromUpdateDto(Tache existingTache, UpdateTacheDto updateTache)
        {
            existingTache.Description = updateTache.Description ?? existingTache.Description;
            existingTache.DateLimite = updateTache.DateLimite ?? existingTache.DateLimite;
            existingTache.Idresponsable = updateTache.Idresponsable ?? existingTache.Idresponsable;
            existingTache.PourcentageProgression = updateTache.PourcentageProgression ?? existingTache.PourcentageProgression;
            existingTache.Idprojet = updateTache.Idprojet ?? existingTache.Idprojet;
            existingTache.IdstatutTache = updateTache.IdstatutTache ?? existingTache.IdstatutTache;

        }
    }
}

