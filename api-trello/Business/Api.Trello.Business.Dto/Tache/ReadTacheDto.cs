using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.TacheDto
{
	public class ReadTacheDto
	{
        public int Idtache { get; set; }

        public string? Titre { get; set; }

        public string? Description { get; set; }

        public DateOnly? DateLimite { get; set; }

        public int? Idresponsable { get; set; }

        public int? PourcentageProgression { get; set; }

        public int? Idprojet { get; set; }

        public int? IdstatutTache { get; set; }

        public virtual ICollection<Data.Entity.Model.Action> Actions { get; set; } = new List<Data.Entity.Model.Action>();

        public virtual Projet? IdprojetNavigation { get; set; }

        public virtual Data.Entity.Model.Utilisateur? IdresponsableNavigation { get; set; }

        public virtual StatutTache? IdstatutTacheNavigation { get; set; }
    }
}

