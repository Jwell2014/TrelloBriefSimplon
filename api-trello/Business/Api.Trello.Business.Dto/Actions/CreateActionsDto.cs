using System;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.ActionsDto
{
	public class CreateActionsDto
	{

        public string? Description { get; set; }

        public bool? EstTerminee { get; set; }

        public int? Idtache { get; set; }
    }
}

