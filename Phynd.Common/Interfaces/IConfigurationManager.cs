using System;
using System.Collections.Generic;
using System.Text;

namespace Phynd.Common.Interfaces
{
    public interface IConfigurationManager
    {
        string GetSetting(string environment, string key);
    }
}
