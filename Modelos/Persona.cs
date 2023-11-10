using System.ComponentModel.DataAnnotations;

namespace MauiAppEjercicio1_3.Modelos
{
    public class Persona
    {
        [Key] 
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
