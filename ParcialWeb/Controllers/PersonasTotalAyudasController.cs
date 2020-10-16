namespace Parcial1Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Logica;
    using Microsoft.Extensions.Configuration;
    using Entity;
    using ParcialWeb.Models;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]

    public class PersonasTotalAyudasController : ControllerBase
    {
        private readonly PersonaService _personaService;

        public IConfiguration Configuration { get; }

        public PersonasTotalAyudasController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
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