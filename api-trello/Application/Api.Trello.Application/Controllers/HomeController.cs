using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Trello.Business.Dto.Utilisateur;
using Api.Trello.Business.Dto.UtilisateurDto;
using Api.Trello.Business.Service.Contrat;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Trello.Application.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]

    public class HomeController : Controller
    {
        

        private readonly IUtilisateurService _utilisateurtService;

        public HomeController(IUtilisateurService utilisateurService)
        {
            _utilisateurtService = utilisateurService;
        }



        //POST: login/<AccountController>
        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<bool> loginAccount([FromBody] AuthUtilisateurDto accountDto)
        {
            var login = await _utilisateurtService.login(accountDto).ConfigureAwait(false);
            return login;
        }

    }
}

