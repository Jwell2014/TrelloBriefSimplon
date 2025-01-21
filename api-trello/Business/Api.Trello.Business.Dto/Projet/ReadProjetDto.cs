using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.ProjetDto
{
	public class ReadProjetDto
	{
        public int Idprojet { get; set; }

        public string? NomProjet { get; set; }

        public int? Idresponsable { get; set; }

        public DateOnly? DateDebut { get; set; }

        public DateOnly? DateFinPrevue { get; set; }

        public string? DetailsDuProjet { get; set; }

        public virtual Data.Entity.Model.Utilisateur? IdresponsableNavigation { get; set; }

        public virtual ICollection<Data.Entity.Model.MembreProjet> MembreProjets { get; set; } = new List<Data.Entity.Model.MembreProjet>();

        public virtual ICollection<Data.Entity.Model.Tache> Taches { get; set; } = new List<Data.Entity.Model.Tache>();
    }
}

