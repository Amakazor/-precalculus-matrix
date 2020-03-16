using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amakazor
{
    class Fraction : ILoggingInterface
    {
        private long Numerator;
        private long Denominator;

        public bool EnableLogging { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
