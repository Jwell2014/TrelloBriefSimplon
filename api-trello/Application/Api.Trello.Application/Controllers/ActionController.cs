using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Mapper.ActionsMapper;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]

    public class ActionController : Controller
    {
        private readonly IActionsService _actionService;

        public ActionController(IActionsService actionService)
        {
            _actionService = actionService;
        }

        /// <summary>
        /// Recupere un action
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadActionsDto>), 200)]

        public async Task<ActionResult> GetAction()
        {
            var actionDTO = await _actionService.GetAction().ConfigureAwait(false);
            return Ok(actionDTO);
        }

        /// <summary>
        /// Récupère une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la action ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadActionsDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetActionById(int id)
        {
            var action = await _actionService.GetActionById(id).ConfigureAwait(false);

            if (action == null)
            {
                return NotFound(); // Renvoie un code 404 si la action n'est pas trouvée.
            }

            return Ok(action);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un action
        /// </summary>
        /// <param name="actionDTO"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadActionsDto), 200)]

        public async Task<ActionResult> CreateAction([FromBody] CreateActionsDto actionDTO)
        {
            Console.WriteLine($"Received actionDTO: {actionDTO}");
            var actionAdd = await _actionService.CreateAction(actionDTO).ConfigureAwait(false);
            return Ok(actionAdd);
        }

        /// <summary>
        /// Cette méthode prend l'ID du action à mettre à jour et un objet UpdateactionDto
        /// contenant les nouvelles informations du action en entrée.
        /// l'attribut [FromBody] est recommandée pour les méthodes qui prennent des données complexes en entrée,
        /// car elle permet de garantir que les données sont correctement extraites et désérialisées
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        // PUT api/<actionController>/5
        // Dans votre contrôleur
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadActionsDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAction(int id, [FromBody] UpdateActionsDto actionDto)
        {
            var existingAction = await _actionService.GetActionById(id).ConfigureAwait(false);

            if (existingAction == null)
            {
                return NotFound();
            }

            var updatedAction = await _actionService.UpdateAction(id, actionDto).ConfigureAwait(false);

            return Ok(updatedAction);
        }






        /// <summary>
        /// Cette méthode permet de supprimer un action
        /// </summary>
        /// <param name = "id" > Id du meactionsure à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var actionDeleted = await _actionService.DeleteAction(id).ConfigureAwait(false);

            return Ok(actionDeleted);
        }

    
    }
}

