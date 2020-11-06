using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contratos;

namespace GUI_Cliente
{
    public class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine("Equals({0})", result);
        }

        public void Equation(string eqn)
        {
            Console.WriteLine("Equation({0})", eqn);
        }
        // Construct InstanceContext to handle messages on callback interface
        InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
    }
}
