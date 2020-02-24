using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCastService
{
    public partial class SuperCast : ServiceBase
    {
        public SuperCast()
        {
            InitializeComponent();
        }

        public void OnStartConsole()
        {
            OnStart(null);
            Task.Delay(Timeout.InfiniteTimeSpan).Wait();
        }

        protected override void OnStart(string[] Arguments)
        {
            Console.WriteLine("Starting Super Cast Service...");
            Task.Run(() => {




                






                new SuperCastWS();






            });
        }

        protected override void OnStop()
        {

        }
    }
}
