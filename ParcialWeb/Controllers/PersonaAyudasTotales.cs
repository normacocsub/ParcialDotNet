namespace Parcial1Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Logica;
    using Microsoft.Extensions.Configuration;
    using Entity;
    using ParcialWeb.Models;
    using System.Linq;
    using Datos;

    [Route("api/[controller]")]
    [ApiController]

    public class PersonaAyudasTotales : ControllerBase
    {
        private readonly PersonaService _personaService;


        public PersonaAyudasTotales(EmergenciaContext context)
        {

            _personaService = new PersonaService(context);
        }

        //GET: Api/PersonasAyudasTotales
        [HttpGet]
        public ActionResult<int> GetAyudaTotales()
        {
            var response = _personaService.AyudasTotales();
            return Ok(response);
        }
    }
}