using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class Projet
{
    public int Idprojet { get; set; }

    public string? NomProjet { get; set; }

    public int? Idresponsable { get; set; }

    public DateOnly? DateDebut { get; set; }

    public DateOnly? DateFinPrevue { get; set; }

    public string? DetailsDuProjet { get; set; }

    public virtual Utilisateur? IdresponsableNavigation { get; set; }

    public virtual ICollection<MembreProjet> MembreProjets { get; set; } = new List<MembreProjet>();

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
