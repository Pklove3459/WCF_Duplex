using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class LoginService : ILoginManager
    {
        private Dictionary<string, ILoginManagerCallback> usuariosConectados;

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
                    Password = "virgen69"
                },

                new Usuario()
                {
                    Nickname = "el patron",
                    Password = "bobcholo"
                }
            };

            if (usuarios.Any(user => user.Nickname.Equals(usuario.Nickname)))
            {
                if (usuarios.Any(user => user.Nickname.Equals(usuario.Password)))
                {
                    resultado = LoginResult.ExisteUsuario;
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

            usuariosConectados.Add(usuario.Nickname, Callback);
            Callback.GetLoginResult(resultado);
            Callback.GetUsersOnline(usuariosConectados);
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
