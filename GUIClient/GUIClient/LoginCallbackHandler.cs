using GUIClient.LoginService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace GUIClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LoginCallbackHandler : ILoginManagerCallback
    {

        public void GetLoginResult(LoginResult resultado)
        {
            if (resultado == LoginResult.ExisteUsuario)
            {
                MessageBox.Show("Iniciaste sesion");


            }
            else if (resultado == LoginResult.NoExisteUsuario)
            {
                MessageBox.Show("No existe usuario");
            }
            else
            {
                MessageBox.Show("Verifica tu contraseña");
            }
        }

        public void GetUsersOnline(string[] usuariosConectados)
        {
            MainWindow ventanaInicio = App.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            ObservableCollection<string> misUsuarios = new ObservableCollection<string>(usuariosConectados);

            ventanaInicio.usuariosConectadosList.ItemsSource = misUsuarios;
        }
    }
}
