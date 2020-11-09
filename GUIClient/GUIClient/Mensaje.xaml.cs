using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIClient
{
    /// <summary>
    /// Lógica de interacción para Mensaje.xaml
    /// </summary>
    public partial class Mensaje : Page
    {
        ObservableCollection<string> listaMensaje = new ObservableCollection<string>();

        public Mensaje()
        {
            InitializeComponent();
            mensajes.ItemsSource = listaMensaje;
        }

        private void EnviarMensaje(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaInicio = App.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            string destinatario = ventanaInicio.usuariosConectadosList.SelectedItem as string;
            MainServiceManager.EnviarMensaje(destinatario, mensaje.Text);
            listaMensaje.Add("Yo: " + mensaje.Text);
        }

        public void AgregarMensaje(string fuente, string mensaje)
        {
            listaMensaje.Add(fuente + ": " + mensaje);
        }
    }
}
