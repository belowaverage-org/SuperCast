using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SuperCastService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] Arguments)
        {
            if(Arguments.Length > 0 && Arguments.Contains("service"))
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new SuperCast()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                new SuperCast().OnStartConsole();
            }
        }
    }
}
