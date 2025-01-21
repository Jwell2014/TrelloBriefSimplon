using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.TacheDto
{
	public class CreateTacheDto
	{
        public string? Titre { get; set; }

        public string? Description { get; set; }

        public DateOnly? DateLimite { get; set; }

        public int? Idresponsable { get; set; }

        public int? PourcentageProgression { get; set; }

        public int? Idprojet { get; set; }

        public int? IdstatutTache { get; set; }

    }
}

