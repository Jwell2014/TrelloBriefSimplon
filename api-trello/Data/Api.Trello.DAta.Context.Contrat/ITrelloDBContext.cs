using System;
using System.Collections.Generic;
using System.Reflection;
using Api.Trello.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Trello.DAta.Context.Contrat
{
    public interface ITrelloDBContext : IDBContext
    {
        DbSet<Data.Entity.Model.Action> Actions { get; set; }

        DbSet<MembreProjet> MembreProjet { get; set; }
        DbSet<Projet> Projet { get; set; }

        DbSet<StatutTache> StatutTache { get; set; }
        DbSet<Tache> Tache { get; set; }

        DbSet<Utilisateur> Utilisateur { get; set; }
    }
}

