using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.ProjetDto;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class projetController : Controller
    {
        private readonly IProjetService _projetService;

        public projetController(IProjetService projetService)
        {
            _projetService = projetService;
        }

        /// <summary>
        /// Recupere un projet
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadProjetDto>), 200)]

        public async Task<ActionResult> GetProjet()
        {
            var projetServiceDTO = await _projetService.GetProjet().ConfigureAwait(false);
            return Ok(projetServiceDTO);
        }

        /// <summary>
        /// Récupère une projet par son ID.
        /// </summary>
        /// <param name="id">ID de la projet à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la projet ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadProjetDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProjetById(int id)
        {
            var projet = await _projetService.GetProjetById(id).ConfigureAwait(false);

            if (projet == null)
            {
                return NotFound(); // Renvoie un code 404 si la projet n'est pas trouvée.
            }

            return Ok(projet);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un projet
        /// </summary>
        /// <param name="actionDTO"></param>
        /// <returns></returns>
        // pOST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadProjetDto), 200)]

        public async Task<ActionResult> CreateProjet([FromBody] CreateProjetDto projetDTO)
        {
            var projetAdd = await _projetService.CreacteProjet(projetDTO).ConfigureAwait(false);
            return Ok(projetAdd);
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
        // pUT api/<actionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadProjetDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProjet(int id, [FromBody] UpdateProjetDto projetDto)
        {
            var existingProjet = await _projetService.GetProjetById(id).ConfigureAwait(false);

            if (existingProjet == null)
            {
                return NotFound();
            }

            var updatedProjet = await _projetService.UpdateProjet(id, projetDto).ConfigureAwait(false);

            return Ok(updatedProjet);
        }



        /// <summary>
        /// Cette méthode permet de supprimer un projet
        /// </summary>
        /// <param name = "id" > Id du projet à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var projetDeleted = await _projetService.DeleteProjet(id).ConfigureAwait(false);

            return Ok(projetDeleted);
        }
    }
}

