using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.UtilisateurDto
{
	public class CreateUtilisateurDto
	{
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public string? MotDePasse { get; set; }

        public string? Poste { get; set; }

        public string? Description { get; set; }

        public string? Photo { get; set; }

    }
}

