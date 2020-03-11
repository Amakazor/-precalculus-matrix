using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amakazor
{
    interface ILoggingInterface
    {
        bool EnableLogging { get; set; }

        void Log(string message);
    }
}
