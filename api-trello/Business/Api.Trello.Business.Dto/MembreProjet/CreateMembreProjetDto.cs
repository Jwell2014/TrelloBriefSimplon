using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.MembreProjetDto
{
	public class CreateMembreProjetDto
	{
        //public int IdmembreProjet { get; set; }

        public int Idutilisateur { get; set; }

        public int Idprojet { get; set; }

    }
}

