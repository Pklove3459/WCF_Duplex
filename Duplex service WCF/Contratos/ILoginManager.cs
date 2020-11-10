using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(ILoginManagerCallback))]
    public interface ILoginManager
    {
        [OperationContract(IsOneWay = true)]
        void Login(Usuario usuario);
    }

    [ServiceContract]
    public interface ILoginManagerCallback
    {
        [OperationContract(IsOneWay = true)]
        void GetLoginResult(LoginResult resultado);

        [OperationContract(IsOneWay = true)]
        void GetUsersOnline(List<string> usuariosConectados);
    }
    
}
