using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(IMessageManagerCallback))]
    public interface IMessageManager
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string destination, string message);

        [OperationContract(IsOneWay = true)]
        void GetMessageCallback();
    }

    [ServiceContract]
    public interface IMessageManagerCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string source, string message);
    }
}
