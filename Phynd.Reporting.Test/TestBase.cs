using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phynd.Reporting.Test
{
    public abstract class TestBase
    {
        protected readonly string connStrRead = "server=dev-rds01.cluster-cvyktwbacelv.us-east-1.rds.amazonaws.com;port=3306;database=DEV_Phynd;user=csalee;password=Marnie11!;";
        protected readonly string connStrWrite = "server=dev-rds01.cluster-cvyktwbacelv.us-east-1.rds.amazonaws.com;port=3306;database=DEV_Phynd;user=csalee;password=Marnie11!;";

    }

}
