using System;
using System.Collections.Generic;

namespace Api.Trello.Data.Entity.Model;

public partial class Action
{
    public int Idaction { get; set; }

    public string? Description { get; set; }

    public bool? EstTerminee { get; set; }

    public int? Idtache { get; set; }

    public virtual Tache? IdtacheNavigation { get; set; }
}
