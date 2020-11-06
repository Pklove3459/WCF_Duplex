﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contratos
{
    [ServiceContract(CallbackContract = typeof(ILoginManagerCallback))]
    interface ILoginManager
    {
        [OperationContract(IsOneWay = true)]
        void Login(Usuario usuario);
    }

    interface ILoginManagerCallback
    {
        [OperationContract(IsOneWay = true)]
        void GetLoginResult(LoginResult resultado);

        [OperationContract(IsOneWay = true)]
        void GetUsersOnline(Dictionary<string, ILoginManagerCallback> usuariosConectados);
    }
}