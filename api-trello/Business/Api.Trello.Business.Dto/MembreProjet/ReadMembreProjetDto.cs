using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.MembreProjetDto
{
	public class ReadMembreProjetDto
	{
        public int IdmembreProjet { get; set; }

        public int Idutilisateur { get; set; }

        public int Idprojet { get; set; }

        public virtual Projet? IdprojetNavigation { get; set; }

        public virtual Data.Entity.Model.Utilisateur? IdutilisateurNavigation { get; set; }
    }
}

