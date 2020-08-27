using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAOPDemo.Model
{
    public class UserProcessor : IUserProcessor
    {
        public User GetUser(User user)
        {
            return user;
        }

        public void RegUser(User user)
        {
            Console.WriteLine("Name : {0}, PassWord : {1}", user.Name, user.MotPass);
        }



    }
}
