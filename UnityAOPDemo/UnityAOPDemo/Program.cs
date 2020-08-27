using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityAOPDemo.Model;

namespace UnityAOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config\\Unity.Config");
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                configSection.Configure(container, "aopContainer");


                User user = new User()
                {
                    Name = "Michael",
                    MotPass = "12345645646464"
                };
                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);
                Console.WriteLine("-------------------------------------------");
                User user1 = processor.GetUser(user);
                Console.WriteLine("-------------------------------------------");
                User user2 = processor.GetUser(user);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();

            }

        }
    }
}
