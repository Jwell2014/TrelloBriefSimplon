using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Dto.ProjetDto;
using Api.Trello.Business.Dto.StatutTacheDto;
using Api.Trello.Business.Service;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class StatutTacheController : Controller
    {
        private readonly IStatutTacheService _statutTacheService;

        public StatutTacheController(IStatutTacheService statutTacheService)
        {
            _statutTacheService = statutTacheService;
        }

        /// <summary>
        /// Recupere un action
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadStatutTacheDto>), 200)]

        public async Task<ActionResult> GetStatutTache()
        {
            var statutTacheDTO = await _statutTacheService.GetStatutTache().ConfigureAwait(false);
            return Ok(statutTacheDTO);
        }

        /// <summary>
        /// Récupère une action par son ID.
        /// </summary>
        /// <param name="id">ID de la action à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la action ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadStatutTacheDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStatutTacheById(int id)
        {
            var statutTache = await _statutTacheService.GetStatutTacheById(id).ConfigureAwait(false);

            if (statutTache == null)
            {
                return NotFound(); // Renvoie un code 404 si la statutTache n'est pas trouvée.
            }

            return Ok(statutTache);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un action
        /// </summary>
        /// <param name="actionDTO"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadStatutTacheDto), 200)]

        public async Task<ActionResult> CreateStatutTache([FromBody] CreateStatutTacheDto statutTacheDTO)
        {
            var statutTacheAdd = await _statutTacheService.CreacteStatutTache(statutTacheDTO).ConfigureAwait(false);
            return Ok(statutTacheAdd);
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
        public async Task<IActionResult> UpdateStatutTache(int id, [FromBody] UpdateStatutTacheDto statutTacheDto)
        {
            var existingStatutTache = await _statutTacheService.GetStatutTacheById(id).ConfigureAwait(false);

            if (existingStatutTache == null)
            {
                return NotFound();
            }

            var updatedAStatutTache = await _statutTacheService.UpdateStatutTache(id, statutTacheDto).ConfigureAwait(false);

            return Ok(updatedAStatutTache);
        }






        /// <summary>
        /// Cette méthode permet de supprimer un action
        /// </summary>
        /// <param name = "id" > Id du meactionsure à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatutTache(int id)
        {
            var statutTacheDeleted = await _statutTacheService.DeleteStatutTache(id).ConfigureAwait(false);

            return Ok(statutTacheDeleted);
        }
    }

}