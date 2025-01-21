using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.ActionsDto;
using Api.Trello.Business.Dto.MembreProjetDto;
using Api.Trello.Business.Service;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class MembreProjetController : Controller
    {
        private readonly IMembreProjetService _membreProjetService;

        public MembreProjetController(IMembreProjetService membreProjetService)
        {
            _membreProjetService = membreProjetService;
        }

        /// <summary>
        /// Recupere un MembreProjet
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadMembreProjetDto>), 200)]

        public async Task<ActionResult> GetMembreProjet()
        {
            var membreProjetServiceDTO = await _membreProjetService.GetMembreProjet().ConfigureAwait(false);
            return Ok(membreProjetServiceDTO);
        }

        /// <summary>
        /// Récupère une MembreProjet par son ID.
        /// </summary>
        /// <param name="id">ID de la MembreProjet à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la MembreProjet ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadMembreProjetDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMembreProjetById(int id)
        {
            var membreProjet = await _membreProjetService.GetMembreProjetById(id).ConfigureAwait(false);

            if (membreProjet == null)
            {
                return NotFound(); // Renvoie un code 404 si la membreProjet n'est pas trouvée.
            }

            return Ok(membreProjet);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un membreProjet
        /// </summary>
        /// <param name="membreProjetDTO"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadMembreProjetDto), 200)]
        public async Task<ActionResult> CreateMembreProjet([FromBody] CreateMembreProjetDto membreProjetDTO)
        {
            if (membreProjetDTO == null)
            {
                return BadRequest("Le DTO de création de membre de projet ne peut pas être null.");
            }

            var membreProjetAdd = await _membreProjetService.CreateMembreProjet(membreProjetDTO).ConfigureAwait(false);
            return Ok(membreProjetAdd);
        }

        /// <summary>
        /// Cette méthode prend l'ID du action à mettre à jour et un objet UpdateactionDto
        /// contenant les nouvelles informations du action en entrée.
        /// l'attribut [FromBody] est recommandée pour les méthodes qui prennent des données complexes en entrée,
        /// car elle permet de garantir que les données sont correctement extraites et désérialisées
        /// </summary>
        /// <param name="id"></param>
        /// <param name="membreProjetDTO"></param>
        /// <returns></returns>
        // PUT api/<actionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadMembreProjetDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMembreProjet(int id, [FromBody] UpdateMembreProjetDto membreProjetDto)
        {
            var existingMembreProjet = await _membreProjetService.GetMembreProjetById(id).ConfigureAwait(false);

            if (existingMembreProjet == null)
            {
                return NotFound();
            }

            var updatedMembreProjet = await _membreProjetService.UpdateMembreProjet(id, membreProjetDto).ConfigureAwait(false);

            return Ok(updatedMembreProjet);
        }



        /// <summary>
        /// Cette méthode permet de supprimer un membreProjet
        /// </summary>
        /// <param name = "id" > Id du membreProjet à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembreProjet(int id)
        {
            var membreProjetDeleted = await _membreProjetService.DeleteMembreProjet(id).ConfigureAwait(false);

            return Ok(membreProjetDeleted);
        }
    }
}

