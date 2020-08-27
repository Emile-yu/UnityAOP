using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityAOPDemo.Interception
{
    public class CachingBehavior : IInterceptionBehavior
    {
        private static Dictionary<string, object> CachingBehaviorProvider = new Dictionary<string, object>();

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
            Console.WriteLine("CachingBehavior");

            string key = $"{input.MethodBase.Name}_{Newtonsoft.Json.JsonConvert.SerializeObject(input.Inputs)}";

            if (CachingBehaviorProvider.ContainsKey(key))
            {
                return  input.CreateMethodReturn(CachingBehaviorProvider[key]);
            }
            else
            {
                IMethodReturn result = getNext().Invoke(input, getNext);

                CachingBehaviorProvider.Add(key, result.ReturnValue);

                return result;
            }
        }
    }
}
