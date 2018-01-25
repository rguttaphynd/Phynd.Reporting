using MySql.Data.MySqlClient;
using Phynd.Reporting.BusinessEntities;
using Phynd.Reporting.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.BusinessService
{
    public partial class ChangeLogBusinessService : IChangeLogBusinessService
    {
        private IChangeLogDataServiceWrite dataServiceWrite;
        private IChangeLogDataServiceRead dataServiceRead;

        public ChangeLogBusinessService(IChangeLogDataServiceWrite dataServiceWrite, IChangeLogDataServiceRead dataServiceRead)
        {
            this.dataServiceWrite = dataServiceWrite;
            this.dataServiceRead = dataServiceRead;
        }

        public async Task<int> CreateAsync(int userId, ChangeLog entity)
        {
            DataEntities.ChangeLog dataObj = MapToData(entity);
            return await dataServiceWrite.CreateAsync(userId, dataObj);
        }

        public async Task<bool> DeleteAsync(int userId, int id)
        {
            return await dataServiceWrite.DeleteAsync(userId, id);
        }

        public async Task<IEnumerable<ChangeLog>> GetAllAsync(int healthSystemId)
        {
            List<ChangeLog> entityList = new List<ChangeLog>();
            var dataObj = await dataServiceRead.GetAllAsync(healthSystemId);
            foreach (var obj in dataObj)
            {
                ChangeLog entity = MapToBusiness(obj);
                entityList.Add(entity);
            }
            return entityList;
        }

        public async Task<ChangeLog> GetByIdAsync(int id)
        {
            var dataObj = await dataServiceRead.GetByIdAsync(id);
            ChangeLog entity = MapToBusiness(dataObj);
            return entity;
        }

        public async Task<bool> UpdateAsync(int userId, ChangeLog entity)
        {
            DataEntities.ChangeLog dataObj = MapToData(entity);
            return await dataServiceWrite.UpdateAsync(userId, dataObj);
        }
        
        public ChangeLog MapToBusiness(DataEntities.ChangeLog dataObj)
        {
            ChangeLog businessObj = new ChangeLog();
				businessObj.ChangeApprovedUserId  = dataObj.ChangeApprovedUserId;
				businessObj.ChangeApprovedUserName  = dataObj.ChangeApprovedUserName;
				businessObj.ChangeLogId  = dataObj.ChangeLogId;
				businessObj.ChangeSubmittedDate  = dataObj.ChangeSubmittedDate;
				businessObj.Comments  = dataObj.Comments;
				businessObj.DataSourceId  = dataObj.DataSourceId;
				businessObj.EntityId  = dataObj.EntityId;
				businessObj.FieldName  = dataObj.FieldName;
				businessObj.HealthSystemId  = dataObj.HealthSystemId;
				businessObj.HealthSystemName  = dataObj.HealthSystemName;
				businessObj.IsEditedReverted  = dataObj.IsEditedReverted;
				businessObj.IsResolved  = dataObj.IsResolved;
				businessObj.NewValue  = dataObj.NewValue;
				businessObj.OldValue  = dataObj.OldValue;
				businessObj.ProviderId  = dataObj.ProviderId;
				businessObj.TableName  = dataObj.TableName;
				businessObj.updatedBy  = dataObj.updatedBy;
				businessObj.updatedDate  = dataObj.updatedDate;
				businessObj.VerificationNotRequiredFlag  = dataObj.VerificationNotRequiredFlag;
            return businessObj;
        }
        
        public DataEntities.ChangeLog MapToData(ChangeLog businessObj)
        {
            DataEntities.ChangeLog dataObj = new DataEntities.ChangeLog();
				dataObj.ChangeApprovedUserId  = businessObj.ChangeApprovedUserId;
				dataObj.ChangeApprovedUserName  = businessObj.ChangeApprovedUserName;
				dataObj.ChangeLogId  = businessObj.ChangeLogId;
				dataObj.ChangeSubmittedDate  = businessObj.ChangeSubmittedDate;
				dataObj.Comments  = businessObj.Comments;
				dataObj.DataSourceId  = businessObj.DataSourceId;
				dataObj.EntityId  = businessObj.EntityId;
				dataObj.FieldName  = businessObj.FieldName;
				dataObj.HealthSystemId  = businessObj.HealthSystemId;
				dataObj.HealthSystemName  = businessObj.HealthSystemName;
				dataObj.IsEditedReverted  = businessObj.IsEditedReverted;
				dataObj.IsResolved  = businessObj.IsResolved;
				dataObj.NewValue  = businessObj.NewValue;
				dataObj.OldValue  = businessObj.OldValue;
				dataObj.ProviderId  = businessObj.ProviderId;
				dataObj.TableName  = businessObj.TableName;
				dataObj.updatedBy  = businessObj.updatedBy;
				dataObj.updatedDate  = businessObj.updatedDate;
				dataObj.VerificationNotRequiredFlag  = businessObj.VerificationNotRequiredFlag;
            return dataObj;
        }

    }
}

