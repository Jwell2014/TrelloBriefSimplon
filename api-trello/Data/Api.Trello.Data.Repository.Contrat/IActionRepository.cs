using System;
namespace Api.Trello.Data.Repository.Contrat
{
	public interface IActionRepository
	{

        /// <summary>
        /// Cette methode permet de créer une Action.
        /// </summary>
        /// <param name="Action">Projet ajouté.</param>
        /// <returns></returns>
        Task<Entity.Model.Action> CreateAction(Entity.Model.Action actionAdd);

        /// <summary>
        /// Cette methode permet de supprimer un Action.
        /// </summary>
        /// <param name="Action">Projet supprimer.</param>
        /// <returns></returns>
        Task<Entity.Model.Action> DeleteAction(Entity.Model.Action actionDelete);


        /// <summary>
        /// Cette methode permet de modifier un Action.
        /// </summary>
        /// <param name="Action">Projet modifier.</param>
        /// <returns></returns>
        Task<Entity.Model.Action> UpdateAction(Entity.Model.Action actionUpdate);


        /// <summary>
        /// Cette methode permet d'afficher tout les Action sous forme de liste.
        /// </summary>
        /// <param name="Action">Liste Action.</param>
        /// <returns></returns>
        Task<List<Entity.Model.Action>> GetAction();

        /// <summary>
        /// Cette methode permet d'afficher un Projet par son id.
        /// </summary>
        /// <param name="Projet">Projet.</param>
        /// <returns></returns>
        Task<Entity.Model.Action> GetActionById(int id);


    }
}

