using Phynd.Reporting.DataEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.DataService.Interfaces
{
    public partial interface IChangeLogDataServiceRead
    {
        Task<IEnumerable<ChangeLog>> GetAllAsync(int id);
        Task<ChangeLog> GetByIdAsync(int id);
    }
}

