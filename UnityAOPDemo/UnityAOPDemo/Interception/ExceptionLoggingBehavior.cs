using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOPDemo.Interception
{
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get { return true; }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodeReturn = getNext().Invoke(input, getNext);

             Console.WriteLine("ExecptionLoggingBehavior");

            if (methodeReturn.Exception == null)
            {
                Console.WriteLine("Pas de exception");
            }
            else
            {
                Console.WriteLine("Il y a des exception");
            }

            return methodeReturn;
        }
    }
}
