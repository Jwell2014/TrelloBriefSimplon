using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.MembreProjetDto
{
	public class UpdateMembreProjetDto
	{
        public int? Idutilisateur { get; set; }

        public int? Idprojet { get; set; }

    }
}

