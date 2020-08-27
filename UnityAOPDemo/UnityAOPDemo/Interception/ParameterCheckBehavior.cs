using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;
using UnityAOPDemo.Model;

namespace UnityAOPDemo.Interception
{
    public class ParameterCheckBehavior : IInterceptionBehavior
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

            Console.WriteLine("ParameterCheckBehavior");
            User user = input.Inputs[0] as User;

            if (user.MotPass.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("MotPass est inférieur au 10 chiffres"));
            }
            else
            {

                return getNext().Invoke(input, getNext);
            }
        }
    }
}
