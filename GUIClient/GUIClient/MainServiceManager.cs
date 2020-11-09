using GUIClient.MainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GUIClient
{
    public static class MainServiceManager
    {
        public static void IniciarSesion(Usuario usuario)
        {
            InstanceContext instanceContext = new InstanceContext(new MainServiceCallbackHandler());
            MainService.MainServiceClient server = new MainService.MainServiceClient(instanceContext);


            server.Login(usuario);
        }

        public static void EnviarMensaje(string destinatario, string mensaje)
        {
            InstanceContext instanceContext = new InstanceContext(new MainServiceCallbackHandler());
            MainService.MainServiceClient server = new MainService.MainServiceClient(instanceContext);

            server.SendMessage(destinatario, mensaje);
        }
    }
}
