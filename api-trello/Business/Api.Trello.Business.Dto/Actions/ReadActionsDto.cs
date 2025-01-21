using System;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Data.Entity.Model;

namespace Api.Trello.Business.Dto.ActionsDto
{
	public class ReadActionsDto : CreateActionsDto
    {

        /// <summary>
        /// Id Actions
        /// </summary>
        public int Idaction { get; set; }

    }
}

