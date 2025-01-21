using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class Tache
{
    public int Idtache { get; set; }

    public string? Titre { get; set; }

    public string? Description { get; set; }

    public DateOnly? DateLimite { get; set; }

    public int? Idresponsable { get; set; }

    public int? PourcentageProgression { get; set; }

    public int? Idprojet { get; set; }

    public int? IdstatutTache { get; set; }

    public virtual ICollection<Action> Actions { get; set; } = new List<Action>();

    public virtual Projet? IdprojetNavigation { get; set; }

    public virtual Utilisateur? IdresponsableNavigation { get; set; }

    public virtual StatutTache? IdstatutTacheNavigation { get; set; }
}
