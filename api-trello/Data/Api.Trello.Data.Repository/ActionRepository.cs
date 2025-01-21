using System;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Api.Trello.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Api.Trello.Business.Dto.ActionsDto;

namespace Api.Trello.Data.Repository
{
	public class ActionRepository : IActionRepository
	{

        private readonly ITrelloDBContext _trelloDBContext;

        public ActionRepository(ITrelloDBContext TrelloDBContext)
        {
            _trelloDBContext = TrelloDBContext;
        }

        /// <summary>
        /// Cette methode permet de créer une Action.
        /// </summary>
        /// <param name="Action">Projet ajouté.</param>
        /// <returns></returns>
        public async Task<Entity.Model.Action> CreateAction(Entity.Model.Action actionAdd)
        {
            var element = await _trelloDBContext.Actions.AddAsync(actionAdd).ConfigureAwait(false);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }


        /// <summary>
        /// Cette methode permet de supprimer un Action.
        /// </summary>
        /// <param name="Action">Projet supprimer.</param>
        /// <returns></returns>
        public async Task<Entity.Model.Action> DeleteAction(Entity.Model.Action actionDelete)
        {
            var element = _trelloDBContext.Actions.Remove(actionDelete);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet de modifier un Action.
        /// </summary>
        /// <param name="Action">Projet modifier.</param>
        /// <returns></returns>
        public async Task<Entity.Model.Action> UpdateAction(Entity.Model.Action actionUpdate)
        {
            var element = _trelloDBContext.Actions.Update(actionUpdate);
            await _trelloDBContext.SaveChangesAsync().ConfigureAwait(false);

            return element.Entity;
        }

        /// <summary>
        /// Cette methode permet d'afficher tout les Action sous forme de liste.
        /// </summary>
        /// <param name="Action">Liste Action.</param>
        /// <returns></returns>
        public async Task<List<Entity.Model.Action>> GetAction()
        {
            return await _trelloDBContext.Actions
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet d'afficher un Projet par son id.
        /// </summary>
        /// <param name="Projet">Projet.</param>
        /// <returns></returns>
        public async Task<Entity.Model.Action> GetActionById(int id)
        {
            return await _trelloDBContext.Actions
                .FirstOrDefaultAsync(x => x.Idaction == id)
                .ConfigureAwait(false);

        }

    }
}

