using Datos;
using Entidades;

namespace Negocio
{
    public class NPersona
    {
        private readonly DPersona dPersona = new DPersona();

        public List<Persona> Listar()
        {
            return dPersona.Listar();
        }

        public List<Persona> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return dPersona.Listar();

            return dPersona.Buscar(texto.Trim());
        }

        public void Registrar(Persona persona)
        {
            Validar(persona);
            dPersona.Insertar(persona);
        }

        public void Actualizar(Persona persona)
        {
            if (persona.IdPersona <= 0)
                throw new ArgumentException("Seleccione una persona de la lista.");

            Validar(persona);
            dPersona.Actualizar(persona);
        }

        public void Eliminar(int idPersona)
        {
            if (idPersona <= 0)
                throw new ArgumentException("Seleccione una persona de la lista.");

            dPersona.Eliminar(idPersona);
        }

        private static void Validar(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombres))
                throw new ArgumentException("Los nombres son obligatorios.");

            if (string.IsNullOrWhiteSpace(persona.Apellidos))
                throw new ArgumentException("Los apellidos son obligatorios.");

            if (persona.Dni.Length != 8 || !persona.Dni.All(char.IsDigit))
                throw new ArgumentException("El DNI debe tener 8 dígitos.");

            if (!string.IsNullOrWhiteSpace(persona.Email) && !persona.Email.Contains('@'))
                throw new ArgumentException("El email no es válido.");
        }
    }
}
