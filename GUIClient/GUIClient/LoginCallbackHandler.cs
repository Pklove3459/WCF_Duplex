using GUIClient.LoginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIClient
{
    public class LoginCallbackHandler : ILoginManagerCallback
    {
        private static Dictionary<string, object> usuarios;
        public void GetLoginResult(LoginResult resultado)
        {
            Console.WriteLine(resultado.ToString());
        }

        public void GetUsersOnline(Dictionary<string, object> usuariosConectados)
        {
            usuarios = usuariosConectados;
        }

        public static Dictionary<string, object> ObtenerUsuariosConectados()
        {
            return usuarios;
        }
    }
}
