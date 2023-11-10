using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiAppEjercicio1_3.Utilidades
{
    public class PersonaMensajeria : ValueChangedMessage<PersonaMensaje>
    {
        public PersonaMensajeria(PersonaMensaje value) : base(value) 
        {

        }
    }
}
