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
    public partial class MainService : ILoginManager
    {
        private Dictionary<string, ILoginManagerCallback> usuariosConectados = new Dictionary<string, ILoginManagerCallback>();
        //private Dictionary<string, IMessageManagerCallback> usuariosEnLinea = new Dictionary<string, IMessageManagerCallback>();
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
                    //usuariosEnLinea.Add(usuario.Nickname, OperationContext.Current.GetCallbackChannel<IMessageManagerCallback>());
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
                Console.WriteLine(_usuario.Key);
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

    public partial class MainService : IMessageManager
    {
        public void SendMessage(string destination, string message)
        {
            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Key.Equals(destination))
                {
                    (usuario.Value as IMessageManagerCallback).ReceiveMessage(GetSourceUser(), message);
                }
            }
      
        }

        private string GetSourceUser()
        {
            string sourceUser = "";
            //ILoginManagerCallback channel = OperationContext.Current.GetCallbackChannel<ILoginManagerCallback>();

            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Value == Callback)
                {
                    sourceUser = usuario.Key;
                    break;
                }
            }

            return sourceUser;
        }
    }
}
