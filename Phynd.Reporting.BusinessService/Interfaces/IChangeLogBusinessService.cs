using Phynd.Reporting.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.BusinessService
{
    public partial interface IChangeLogBusinessService
    {
        Task<IEnumerable<ChangeLog>> GetAllAsync(int id);
        Task<int> CreateAsync(int userId, ChangeLog entity);
        Task<bool> UpdateAsync(int userId, ChangeLog entity);
        Task<ChangeLog> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int userId, int id);
    }
}

