
using Phynd.Reporting.BusinessService;
using Phynd.Reporting.DataService.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Collections;
using System.Linq;

namespace Phynd.Reporting.Test
{
    public class ChangeLogTest : TestBase
    {
        [Fact]
        public async Task TestGetOneChangeLog()
        {
            var dataSvc = new ChangeLogDataServiceRead(connStrRead);
            var svc = new ChangeLogBusinessService(null, dataSvc);
            var data = await svc.GetByIdAsync(24);
            Assert.True(data != null);
        }

        [Fact]
        public async Task TestGetAllChangeLogs()
        {
            var dataSvc = new ChangeLogDataServiceRead(connStrRead);
            var svc = new ChangeLogBusinessService(null, dataSvc);
            var data = await svc.GetAllAsync(33);
            Assert.True(data.Count() > 0);
        }

        [Fact]
        public async Task CreateChangeLog()
        {
            var dataSvc = new ChangeLogDataServiceWrite(connStrWrite);
            var svc = new ChangeLogBusinessService(dataSvc, null);
            var data = await svc.CreateAsync(1, new BusinessEntities.ChangeLog()
            {
                HealthSystemId = 1, 
                ChangeApprovedUserId = 1,
                ChangeApprovedUserName = "Joe",
                ChangeSubmittedDate = DateTime.Now,
                Comments = "Test Comments",
                EntityId = 1,
                FieldName = "Test Field Name",
                OldValue = "Test Old Value",
                NewValue = "Test New Value",
                TableName = "ChangeLog",
                ProviderId = 1
            });

            Assert.True(data == 1);
        }

        [Fact]
        public async Task UpdateChangeLog()
        {
            var dataSvc = new ChangeLogDataServiceWrite(connStrWrite);
            var svc = new ChangeLogBusinessService(dataSvc, null);
            var data = await svc.UpdateAsync(1, new BusinessEntities.ChangeLog()
            {
                HealthSystemId = 2,
                ChangeApprovedUserId = 2,
                ChangeApprovedUserName = "Joe",
                ChangeSubmittedDate = DateTime.Now,
                Comments = "Test Comments Update",
                EntityId = 2,
                FieldName = "Test Field Name Update",
                OldValue = "Test Old Value Update",
                NewValue = "Test New Value Update",
                TableName = "ChangeLog",
                ProviderId = 2
            });

            Assert.True(data);
        }
    }
}
