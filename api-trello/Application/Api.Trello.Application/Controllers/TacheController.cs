using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Dto.StatutTacheDto;
using Api.Trello.Business.Dto.TacheDto;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class TacheController : Controller
    {
        private readonly ITacheService _tacheService;

        public TacheController(ITacheService tacheService)
        {
            _tacheService = tacheService;
        }

        /// <summary>
        /// Recupere un tache
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadTacheDto>), 200)]

        public async Task<ActionResult> GetTache()
        {
            var tacheDTO = await _tacheService.GetTache().ConfigureAwait(false);
            return Ok(tacheDTO);
        }

        /// <summary>
        /// Récupère une tache par son ID.
        /// </summary>
        /// <param name="id">ID de la tache à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la tache ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadTacheDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTacheById(int id)
        {
            var tache = await _tacheService.GetTacheById(id).ConfigureAwait(false);

            if (tache == null)
            {
                return NotFound(); // Renvoie un code 404 si la Tache n'est pas trouvée.
            }

            return Ok(tache);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un tache
        /// </summary>
        /// <param name="tacheDTO"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadTacheDto), 200)]

        public async Task<ActionResult> CreateTache([FromBody] CreateTacheDto tacheDTO)
        {
            var tacheAdd = await _tacheService.CreacteTache(tacheDTO).ConfigureAwait(false);
            return Ok(tacheAdd);
        }

        /// <summary>
        /// Cette méthode prend l'ID du action à mettre à jour et un objet UpdateactionDto
        /// contenant les nouvelles informations du action en entrée.
        /// l'attribut [FromBody] est recommandée pour les méthodes qui prennent des données complexes en entrée,
        /// car elle permet de garantir que les données sont correctement extraites et désérialisées
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tacheDTO"></param>
        /// <returns></returns>
        // PUT api/<actionController>/5
        // Dans votre contrôleur
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadTacheDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTache(int id, [FromBody] UpdateTacheDto tacheDto)
        {
            var existingTache = await _tacheService.GetTacheById(id).ConfigureAwait(false);

            if (existingTache == null)
            {
                return NotFound();
            }

            var updatedTache = await _tacheService.UpdateTache(id, tacheDto).ConfigureAwait(false);

            return Ok(updatedTache);
        }


        /// <summary>
        /// Cette méthode permet de supprimer un action
        /// </summary>
        /// <param name = "id" > Id du meactionsure à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTache(int id)
        {
            var tacheDeleted = await _tacheService.DeleteTache(id).ConfigureAwait(false);

            return Ok(tacheDeleted);
        }
    }
}

