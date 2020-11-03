namespace ParcialWeb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Logica;
    using Microsoft.Extensions.Configuration;
    using Datos;
    

    [Route("api/[controller]")]
    [ApiController]

    public class PersonasTotalAyudasController : ControllerBase
    {
        private readonly PersonaService _personaService;


        public PersonasTotalAyudasController(EmergenciaContext context)
        {

            _personaService = new PersonaService(context);
        }

        //GET: Api/PersonasTotalAyudas
        [HttpGet]
        public ActionResult<decimal> GetTotalAyudas()
        {
            var response = _personaService.TotalAyudas();
            return Ok(response);
            
        }
    }
}