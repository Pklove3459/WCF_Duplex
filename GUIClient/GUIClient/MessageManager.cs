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
        public static void EnviarMensaje(string destinatario, string mensaje)
        {
            InstanceContext instanceContext = new InstanceContext(new MessageCallbackHandler());
            MainService.MessageManagerClient server = new MainService.MessageManagerClient(instanceContext);

            server.SendMessage(destinatario, mensaje);
        }
    }
}
