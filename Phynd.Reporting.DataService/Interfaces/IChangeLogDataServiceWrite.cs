using Phynd.Reporting.DataEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.DataService.Interfaces
{
    public partial interface IChangeLogDataServiceWrite
    {
        Task<int> CreateAsync(int userId, ChangeLog entity);
        Task<bool> UpdateAsync(int userId, ChangeLog entity);
        Task<bool> DeleteAsync(int userId, int id);
    }
}

