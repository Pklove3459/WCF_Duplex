using GUIClient.MainService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUIClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MainServiceCallbackHandler : IMainServiceCallback
    {
        public void GetLoginResult(LoginResult resultado)
        {
            if (resultado == LoginResult.ExisteUsuario)
            {
                MainWindow ventanaInicio = App.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                ventanaInicio.Entrar();
                ventanaInicio.currentUser.Text = "Hola: " + (ventanaInicio.frameNavigation.Content as Login).nickname.Text;

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

            Console.WriteLine(misUsuarios);

            ventanaInicio.usuariosConectadosList.ItemsSource = misUsuarios;
        }

        public void ReceiveMessage(string source, string message)
        {
            //Mensaje ventanaMensaje = App.Current.Windows.OfType<Mensaje>().FirstOrDefault();
            MainWindow ventanaInicio = App.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            (ventanaInicio.frameNavigation.Content as Mensaje).AgregarMensaje(source, message);

            //ventanaMensaje.AgregarMensaje(source, message);
        }
    }
}
