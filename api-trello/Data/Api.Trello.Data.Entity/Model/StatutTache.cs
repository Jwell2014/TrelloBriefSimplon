using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class StatutTache
{
    public int IdstatutTache { get; set; }

    public string? LibelleStatut { get; set; }

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
