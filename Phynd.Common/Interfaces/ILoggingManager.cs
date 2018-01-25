using System;
using System.Collections.Generic;
using System.Text;

namespace Phynd.Common.Interfaces
{
    public interface ILoggingManager
    {
        void LogException(Exception ex);
        void LogMessage(string message);
    }
}
