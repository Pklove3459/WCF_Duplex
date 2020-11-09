using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IMainServiceCallback))]
    public interface IMainService
    {
        [OperationContract(IsOneWay = true)]
        void Login(Usuario usuario);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string destination, string message);
    }

    /*
    public interface ILoginManagerCallback
    {
        [OperationContract(IsOneWay = true)]
        void GetLoginResult(LoginResult resultado);

        [OperationContract(IsOneWay = true)]
        void GetUsersOnline(List<string> usuariosConectados);
    }
    */
}
