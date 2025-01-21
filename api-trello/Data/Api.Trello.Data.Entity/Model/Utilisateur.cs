using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class Utilisateur
{
    public int Idutilisateur { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? MotDePasse { get; set; }

    public string? Poste { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<MembreProjet> MembreProjets { get; set; } = new List<MembreProjet>();

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
