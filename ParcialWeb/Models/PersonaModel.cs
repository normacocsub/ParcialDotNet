using System;
using Entity;

namespace ParcialWeb.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public Ayudas Ayudas { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }

        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Ayudas = persona.Ayudas;
        }
    }
}