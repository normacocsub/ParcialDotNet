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

    public class PersonaAyudasTotales : ControllerBase
    {
        private readonly PersonaService _personaService;

        public IConfiguration Configuration { get; }

        public PersonaAyudasTotales(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
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