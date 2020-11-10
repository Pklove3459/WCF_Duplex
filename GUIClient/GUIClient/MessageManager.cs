using GUIClient.MainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GUIClient
{
    public static class MessageManager
    {
        private static readonly InstanceContext instanceContext = new InstanceContext(new MessageCallbackHandler());
        private static readonly MessageManagerClient server = new MessageManagerClient(instanceContext);

        public static void EnviarMensaje(string destinatario, string mensaje)
        {
            server.SendMessage(destinatario, mensaje);
        }

        public static void AgregarMessageCallback()
        {
            server.GetMessageCallback();
        }
    }
}
