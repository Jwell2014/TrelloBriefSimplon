using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.ProjetDto
{
	public class CreateProjetDto
	{

        public string? NomProjet { get; set; }

        public int? Idresponsable { get; set; }

        public DateOnly? DateDebut { get; set; }

        public DateOnly? DateFinPrevue { get; set; }

        public string? DetailsDuProjet { get; set; }
    }
}

