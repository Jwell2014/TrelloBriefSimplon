using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.StatutTacheDto
{
	public class ReadStatutTacheDto
	{
        public int IdstatutTache { get; set; }

        public string? LibelleStatut { get; set; }

        public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();

    }
}

