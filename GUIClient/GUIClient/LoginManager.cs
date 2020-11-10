using GUIClient.MainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GUIClient
{
    public class LoginManager
    {
        public static void IniciarSesion(Usuario usuario)
        {
            InstanceContext instanceContext = new InstanceContext(new LoginCallbackHandler());
            LoginManagerClient server = new LoginManagerClient(instanceContext);

            server.Login(usuario);
        }
    }
}
