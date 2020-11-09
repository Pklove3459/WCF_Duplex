using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUIClient.MainService;

namespace GUIClient
{
    public class MessageCallbackHandler : IMessageManagerCallback
    {
        public void ReceiveMessage(string source, string message)
        {
            Mensaje ventanaMensaje = App.Current.Windows.OfType<Mensaje>().FirstOrDefault();

            ventanaMensaje.AgregarMensaje(source, message);
        }
    }
}
