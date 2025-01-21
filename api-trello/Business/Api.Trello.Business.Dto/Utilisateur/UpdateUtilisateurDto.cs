using System;
namespace Api.Trello.Business.Dto.UtilisateurDto
{
	public class UpdateUtilisateurDto
	{
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public string? MotDePasse { get; set; }

        public string? Poste { get; set; }

        public string? Description { get; set; }

        public string? Photo { get; set; }

    }
}

