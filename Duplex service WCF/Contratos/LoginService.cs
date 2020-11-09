using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class LoginService : ILoginManager
    {
        private Dictionary<string, ILoginManagerCallback> usuariosConectados = new Dictionary<string, ILoginManagerCallback>();
        private List<string> usuariosMensaje = new List<string>();

        public void Login(Usuario usuario)
        {
            LoginResult resultado;
            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario()
                {
                    Nickname = "frews2",
                    Password = "belice20"
                },

                new Usuario()
                {
                    Nickname = "SammyGCh",
                    Password = "SammyGuayaba"
                },

                new Usuario()
                {
                    Nickname = "redditor420",
                    Password = "ganobiden"
                },

                new Usuario()
                {
                    Nickname = "el patron",
                    Password = "bobcholo"
                }
            };

            if (usuarios.Any(user => user.Nickname.Equals(usuario.Nickname)))
            {
                if (usuarios.Any(user => user.Password.Equals(usuario.Password)))
                {
                    resultado = LoginResult.ExisteUsuario;
                    usuariosConectados.Add(usuario.Nickname, Callback);
                    usuariosMensaje.Add(usuario.Nickname);

                    NotificarDeNuevoUsuario();
                    
                    
                }
                else
                {
                    resultado = LoginResult.PasswordIncorrecto;
                }
            }
            else
            {
                resultado = LoginResult.NoExisteUsuario;
            }
            
            
            Callback.GetLoginResult(resultado);
            
        }

        private void NotificarDeNuevoUsuario()
        {
            foreach (var _usuario in usuariosConectados)
            {
                _usuario.Value.GetUsersOnline(usuariosMensaje);
            }
        }

        ILoginManagerCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ILoginManagerCallback>();
            }
        }
    }
}
