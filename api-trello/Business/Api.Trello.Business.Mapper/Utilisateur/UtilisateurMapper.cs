using System;
using Api.Trello.Business.Dto.TacheDto;
using Api.Trello.Business.Dto.UtilisateurDto;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Mapper.UtilisateurMapper
{
	public class UtilisateurMapper
	{
        /// <summary>
        /// Transforme CreateUtilisateurDto en entity Actions
        /// </summary>
        /// <param name="CreateUtilisateurDto"></param>
        /// <returns></returns>
        public static Utilisateur TransformCreateDTOToEntity(CreateUtilisateurDto createUtilisateurDTO)
        {
            return new Utilisateur()
            {


                Nom = createUtilisateurDTO.Nom,

                Prenom = createUtilisateurDTO.Prenom,

                MotDePasse = createUtilisateurDTO.MotDePasse,

                Poste = createUtilisateurDTO.Poste,

                Description = createUtilisateurDTO.Description,

                Photo = createUtilisateurDTO.Photo,

            };
        }

        /// <summary>
        /// Transforme ReadActionsDTO en entity Mesure
        /// </summary>
        /// <param name="ReadUtilisateurDTO"></param>
        /// <returns></returns>
        public static ReadUtilisateurDto TransformEntityToReadUtilisateurDTO(Utilisateur utilisateur)
        {
            var readUtilisateurDTO = new ReadUtilisateurDto()
            {
                Idutilisateur = utilisateur.Idutilisateur,

                Nom = utilisateur.Nom,

                Prenom = utilisateur.Prenom,

                MotDePasse = utilisateur.MotDePasse,

                Poste = utilisateur.Poste,

                Description = utilisateur.Description,

                Photo = utilisateur.Photo,
                
            };

            return readUtilisateurDTO;
        }


        /// <summary>
        /// Cette méthode prend un objet utilisateur et un objet UpdateutilisateurDto en entrée
        /// et met à jour les propriétés de l'objet utilisateur en utilisant les valeurs de l'objet UpdateutilisateurDto.
        /// </summary>
        /// <param name="utilisateur"></param>
        /// <param name="updateutilisateur"></param>
        public static void UpdateEntityFromUpdateDto(Utilisateur existingUtilisateur, UpdateUtilisateurDto updateUtilisateur)
        {
            existingUtilisateur.Nom = updateUtilisateur.Nom ?? existingUtilisateur.Nom;
            existingUtilisateur.Prenom = updateUtilisateur.Prenom ?? existingUtilisateur.Prenom;
            existingUtilisateur.MotDePasse = updateUtilisateur.MotDePasse ?? existingUtilisateur.MotDePasse;
            existingUtilisateur.Poste = updateUtilisateur.Poste ?? existingUtilisateur.Poste;
            existingUtilisateur.Description = updateUtilisateur.Description ?? existingUtilisateur.Description;
            existingUtilisateur.Photo = updateUtilisateur.Photo ?? existingUtilisateur.Photo;
            
        }
    }
}

