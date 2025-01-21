using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class MembreProjet
{
    public int IdmembreProjet { get; set; }

    public int Idutilisateur { get; set; }

    public int Idprojet { get; set; }

    public virtual Projet? IdprojetNavigation { get; set; }

    public virtual Utilisateur? IdutilisateurNavigation { get; set; }
}
