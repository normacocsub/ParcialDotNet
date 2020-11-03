using System;
using Entity;
using Datos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PersonaService
    {
        private readonly EmergenciaContext _context;

        public PersonaService(EmergenciaContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            string mensaje = "";
            try
            {
                if (_context.Personas.Find(persona.Identificacion) == null)
                {
                    decimal suma = _context.Personas.Include(p => p.Ayudas).ToList().Sum(p => p.Ayudas.ValorApoyo);
                    if ((0 + persona.Ayudas.ValorApoyo) > 60000000)
                    {
                        mensaje = "Error: Ayudas superadas. ";
                        return new GuardarPersonaResponse(mensaje, "NoMoney");
                    }
                    else
                    {
                        Ayudas ayuda = persona.Ayudas;
                        int numero = _context.Personas.Include(p => p.Ayudas).ToList().Count;
                        mensaje = "Se ha guardado la persona. ";
                        ayuda.Numero = (numero + 1)+("");
                        persona.AgregarAyuda(ayuda);
                        _context.Personas.Add(persona);
                        _context.SaveChanges();
                        return new GuardarPersonaResponse(mensaje, persona);
                    }
                }
                else
                {
                    mensaje = "Error: La persona ya se encuentra registrada. ";
                    return new GuardarPersonaResponse(mensaje, "Duplicado");
                }
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error en la aplicacion: {e.Message}", "ErrorAplication");
            }
        }

        public decimal TotalAyudas()
        {
            decimal suma = _context.Personas.Include(p => p.Ayudas).ToList().Sum(p => p.Ayudas.ValorApoyo);
            return suma;
        }

        public int AyudasTotales()
        {
            int totalayudas = 0;
            totalayudas = _context.Personas.Include(p => p.Ayudas).ToList().Count;
            return totalayudas;
        }

        public PersonaConsultaResponse Consultar()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = _context.Personas.Include(p => p.Ayudas).ToList();
                return new PersonaConsultaResponse(personas);
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse($"Error en la aplicacion: {e.Message}");
            }
        }
        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(string mensaje, Persona persona)
            {
                Error = false;
                Mensaje = mensaje;
                Persona = persona;
            }

            public GuardarPersonaResponse(string mensaje, string tipoerror)
            {
                Error = true;
                Mensaje = mensaje;
                TipoRespuesta = tipoerror;
            }
            public bool Error { get; set; }
            public string TipoRespuesta { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }

        public class PersonaConsultaResponse
        {
            public PersonaConsultaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public PersonaConsultaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }
    }
}
