using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using Entity;
using ParcialWeb.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

[Route("api/[controller]")]
[ApiController]

public class PersonaController : ControllerBase
{
    private readonly PersonaService _personaService;

    public IConfiguration Configuration { get; }

    public PersonaController(IConfiguration configuration)
    {
        Configuration = configuration;
        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        _personaService = new PersonaService(connectionString);
    }


        // GET: api/Persona​
        [HttpGet]
        public ActionResult<PersonaViewModel> Gets()
        {
            var response = _personaService.Consultar();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Personas.Select(p=> new PersonaViewModel(p)));
        }

        

    //Post: Api/Persona

    [HttpPost]
    public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
    {
        Persona persona = MapearPersona(personaInput);
        var response = _personaService.Guardar(persona);
        if(response.Error)
        {
            ModelState.AddModelError("Error al guardar persona", response.Mensaje  );
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            if(response.TipoRespuesta == "Duplicado" || response.TipoRespuesta == "NoMoney")
            {
                detallesproblemas.Status = StatusCodes.Status400BadRequest;
            }
            else
            {
                detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            }
            
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Persona);
    }

    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona = new Persona
        {
            Identificacion = personaInput.Identificacion,
            Nombre = personaInput.Nombre,
            Apellidos = personaInput.Apellidos,
            Sexo = personaInput.Sexo,
            Edad = personaInput.Edad,
            Departamento = personaInput.Departamento,
            Ciudad = personaInput.Ciudad,
            ValorApoyo = personaInput.ValorApoyo,
            ModalidadApoyo = personaInput.ModalidadApoyo,
            Fecha = personaInput.Fecha
        };
        return persona;
    }
}