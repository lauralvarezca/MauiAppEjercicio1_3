using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppEjercicio1_3.DTOs
{
    public partial class PersonaDTO : ObservableObject
    {
        [ObservableProperty]
        public int idPersona;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string apellido;
        [ObservableProperty]
        public int edad;
        [ObservableProperty]
        public string correo;
        [ObservableProperty]
        public string direccion;
    }
}
