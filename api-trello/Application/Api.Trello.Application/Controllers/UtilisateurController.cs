using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.TacheDto;
using Api.Trello.Business.Dto.UtilisateurDto;
using Api.Trello.Business.Service;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class UtilisateurController : Controller
    {
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

    
        /// <summary>
        /// Recupere un tache
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(List<ReadUtilisateurDto>), 200)]

        public async Task<ActionResult> GetUtilisateur()
        {
            var utilisateurDTO = await _utilisateurService.GetUtilisateur().ConfigureAwait(false);
            return Ok(utilisateurDTO);
        }

        /// <summary>
        /// Récupère une utilisateur par son ID.
        /// </summary>
        /// <param name="id">ID de la utilisateur à récupérer.</param>
        /// <returns>Un objet ActionResult contenant la utilisateur ou un code d'erreur.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadUtilisateurDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUtilisateurById(int id)
        {
            var utilisateur = await _utilisateurService.GetUtilisateurById(id).ConfigureAwait(false);

            if (utilisateur == null)
            {
                return NotFound(); // Renvoie un code 404 si la utilisateur n'est pas trouvée.
            }

            return Ok(utilisateur);
        }


        /// <summary>
        /// Ressources neccessaire pour l'ajout d'un utilisateur
        /// </summary>
        /// <param name="utilisateurDTO"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ReadUtilisateurDto), 200)]

        public async Task<ActionResult> CreateUtilisateur([FromBody] CreateUtilisateurDto utilisateurDTO)
        {
            
            var utilisateurAdd = await _utilisateurService.CreacteUtilisateur(utilisateurDTO).ConfigureAwait(false);
            return Ok(utilisateurAdd);
        }

        /// <summary>
        /// Cette méthode prend l'ID du utilisateur à mettre à jour et un objet utilisateur
        /// contenant les nouvelles informations du action en entrée.
        /// l'attribut [FromBody] est recommandée pour les méthodes qui prennent des données complexes en entrée,
        /// car elle permet de garantir que les données sont correctement extraites et désérialisées
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilisateurDTO"></param>
        /// <returns></returns>
        // PUT api/<actionController>/5
        // Dans votre contrôleur
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadUtilisateurDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUtilisateur(int id, [FromBody] UpdateUtilisateurDto tacheDto)
        {
            var existingUtilisateur = await _utilisateurService.GetUtilisateurById(id).ConfigureAwait(false);

            if (existingUtilisateur == null)
            {
                return NotFound();
            }

            var updatedUtilisateur = await _utilisateurService.UpdateUtilisateur(id, tacheDto).ConfigureAwait(false);

            return Ok(updatedUtilisateur);
        }


        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name = "id" > Id du utilisateur à supprimer</param>
        /// <returns></returns>
        // DELETE api/<MesuresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateurDeleted = await _utilisateurService.DeleteUtilisateur(id).ConfigureAwait(false);

            return Ok(utilisateurDeleted);
        }
    }
}

