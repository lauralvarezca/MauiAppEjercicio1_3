
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

using Microsoft.EntityFrameworkCore;
using MauiAppEjercicio1_3.DataAccess;
using MauiAppEjercicio1_3.DTOs;
using MauiAppEjercicio1_3.Utilidades;
using MauiAppEjercicio1_3.Modelos;

namespace MauiAppEjercicio1_3.ViewModels
{
    public partial class PersonaViewModel : ObservableObject, IQueryAttributable
    {
        private readonly PersonaDbContext _dbContext;

        [ObservableProperty]
        private PersonaDTO personaDto = new PersonaDTO();

        [ObservableProperty]
        private string tituloPagina;

        private int IdPersona;

        [ObservableProperty]
        private bool loadingEsVisible = false;

    
        public PersonaViewModel(PersonaDbContext context)
        {
            _dbContext = context;
        }




        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = int.Parse(query["id"].ToString());
            IdPersona = id;

            if (IdPersona == 0)
            {
                TituloPagina = "Nueva Persona";
            }
            else 
            {
                TituloPagina = "Editar Persona";
                LoadingEsVisible = true;
                await Task.Run(async () =>
                {
                    var encontrado = await _dbContext.Personas.FirstAsync(e => e.IdPersona == IdPersona);
                    PersonaDto.IdPersona = encontrado.IdPersona;
                    PersonaDto.Nombre = encontrado.Nombre;
                    PersonaDto.Apellido = encontrado.Apellido;
                    PersonaDto.Edad = encontrado.Edad;
                    PersonaDto.Correo = encontrado.Correo;
                    PersonaDto.Direccion = encontrado.Direccion;

                    MainThread.BeginInvokeOnMainThread(() => { LoadingEsVisible = false; });   

                });
            }
        }



        [RelayCommand]
        private async Task Guardar()
        {
            LoadingEsVisible = true;
            PersonaMensaje mensaje = new PersonaMensaje();

            await Task.Run(async () =>
            {
                if (IdPersona == 0)
                {
                    var tbPersona = new Persona
                    {
                        Nombre = PersonaDto.Nombre,
                        Apellido = PersonaDto.Apellido,
                        Edad = PersonaDto.Edad,
                        Correo = PersonaDto.Correo,
                        Direccion = PersonaDto.Direccion,
                    };

                    _dbContext.Personas.Add(tbPersona);
                    await _dbContext.SaveChangesAsync();

                    PersonaDto.IdPersona = tbPersona.IdPersona;
                    mensaje = new PersonaMensaje()
                    {
                        EsCrear = true,
                        PersonaDto = PersonaDto
                    };

                }
                else
                {
                    var encontrado = await _dbContext.Personas.FirstAsync(e => e.IdPersona == IdPersona);
                    encontrado.Nombre = PersonaDto.Nombre;
                    encontrado.Apellido = PersonaDto.Apellido;
                    encontrado.Edad = PersonaDto.Edad;
                    encontrado.Correo = PersonaDto.Correo;
                    encontrado.Direccion = PersonaDto.Direccion;

                    await _dbContext.SaveChangesAsync();

                    mensaje = new PersonaMensaje()
                    {
                        EsCrear = false,
                        PersonaDto = PersonaDto
                    };

                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    LoadingEsVisible = false;
                    WeakReferenceMessenger.Default.Send(new PersonaMensajeria(mensaje));
                    await Shell.Current.Navigation.PopAsync();
                });

            });
        }
    }
}
