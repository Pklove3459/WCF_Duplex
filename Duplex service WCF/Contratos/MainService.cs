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
    public partial class MainService : IMainService
    {
        //private Dictionary<string, IMainServiceCallback> usuariosConectados = new Dictionary<string, IMainServiceCallback>();
        //private Dictionary<string, IMessageManagerCallback> usuariosEnLinea = new Dictionary<string, IMessageManagerCallback>();
        private Dictionary<IMainServiceCallback, string> usuariosConectados = new Dictionary<IMainServiceCallback, string>();
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
                    usuariosConectados.Add(Callback, usuario.Nickname);
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
                _usuario.Key.GetUsersOnline(usuariosMensaje);
            }
        }

        public void SendMessage(string destination, string message)
        {
            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Value.Equals(destination))
                {
                    usuario.Key.ReceiveMessage(GetSourceUser(), message);
                }
            }
        }

        private string GetSourceUser()
        {
            string sourceUser = "";

            foreach (var usuario in usuariosConectados)
            {
                if (usuario.Key == Callback)
                {
                    sourceUser = usuario.Value;
                }
                
            }

            return sourceUser;
        }

        IMainServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IMainServiceCallback>();
            }
        }
    }
}
