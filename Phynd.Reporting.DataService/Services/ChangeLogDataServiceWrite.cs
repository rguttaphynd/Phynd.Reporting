using MySql.Data.MySqlClient;
using Phynd.Common.Models;
using Phynd.Reporting.DataEntities;
using Phynd.Reporting.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.DataService.Services
{
    public partial class ChangeLogDataServiceWrite : IChangeLogDataServiceWrite
    {
        public string ConnectionString { get; set; }

        public ChangeLogDataServiceWrite(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public async Task<int> CreateAsync(int userId, ChangeLog entity)
        {
            int nbrRows = 0;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Proc_Reporting_CreateChangeLog"
            };

            cmd.Parameters.AddWithValue("@p_ChangeApprovedUserId", entity.ChangeApprovedUserId);
            cmd.Parameters.AddWithValue("@p_ChangeApprovedUserName", entity.ChangeApprovedUserName);
            cmd.Parameters.AddWithValue("@p_ChangeLogId", entity.ChangeLogId);
            cmd.Parameters.AddWithValue("@p_ChangeSubmittedDate", entity.ChangeSubmittedDate);
            cmd.Parameters.AddWithValue("@p_Comments", entity.Comments);
            cmd.Parameters.AddWithValue("@p_DataSourceId", entity.DataSourceId);
            cmd.Parameters.AddWithValue("@p_EntityId", entity.EntityId);
            cmd.Parameters.AddWithValue("@p_FieldName", entity.FieldName);
            cmd.Parameters.AddWithValue("@p_HealthSystemId", entity.HealthSystemId);
            cmd.Parameters.AddWithValue("@p_HealthSystemName", entity.HealthSystemName);
            cmd.Parameters.AddWithValue("@p_IsEditedReverted", entity.IsEditedReverted);
            cmd.Parameters.AddWithValue("@p_IsResolved", entity.IsResolved);
            cmd.Parameters.AddWithValue("@p_NewValue", entity.NewValue);
            cmd.Parameters.AddWithValue("@p_OldValue", entity.OldValue);
            cmd.Parameters.AddWithValue("@p_ProviderId", entity.ProviderId);
            cmd.Parameters.AddWithValue("@p_TableName", entity.TableName);
            cmd.Parameters.AddWithValue("@p_updatedBy", entity.updatedBy);
            cmd.Parameters.AddWithValue("@p_updatedDate", entity.updatedDate);
            cmd.Parameters.AddWithValue("@p_VerificationNotRequiredFlag", entity.VerificationNotRequiredFlag);
             cmd.Parameters.AddWithValue("@p_CreatedDate", DateTime.Now);
             cmd.Parameters["@p_ChangeLogId"].Direction = ParameterDirection.Output;
            
            using (MySqlConnection conn = GetConnection())
            {
                cmd.Connection = conn;
                conn.Open();
                nbrRows = await cmd.ExecuteNonQueryAsync();
                //cmd.Parameters["@p_ChangeLogId"].Value
            }
            return nbrRows;
        }

        public async Task<bool> DeleteAsync(int userId, int id)
        {
            bool nbrRows = false;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Proc_Reporting_DeleteChangeLog"
            };
            
            cmd.Parameters.AddWithValue("@p_ChangeLogId", id);
            cmd.Parameters.AddWithValue("@p_ModifiedUserId", userId);
            
            using (MySqlConnection conn = GetConnection())
            {
                cmd.Connection = conn;
                conn.Open();
                nbrRows = await cmd.ExecuteNonQueryAsync() > 0;
            }
            return nbrRows;
        }

        public async Task<bool> UpdateAsync(int userId, ChangeLog entity)
        {
            bool retVal = false;
            try 
            {
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Proc_Reporting_UpdateChangeLog"
                };

                    cmd.Parameters.AddWithValue("@p_ChangeApprovedUserId", entity.ChangeApprovedUserId);
                    cmd.Parameters.AddWithValue("@p_ChangeApprovedUserName", entity.ChangeApprovedUserName);
                    cmd.Parameters.AddWithValue("@p_ChangeLogId", entity.ChangeLogId);
                    cmd.Parameters.AddWithValue("@p_ChangeSubmittedDate", entity.ChangeSubmittedDate);
                    cmd.Parameters.AddWithValue("@p_Comments", entity.Comments);
                    cmd.Parameters.AddWithValue("@p_DataSourceId", entity.DataSourceId);
                    cmd.Parameters.AddWithValue("@p_EntityId", entity.EntityId);
                    cmd.Parameters.AddWithValue("@p_FieldName", entity.FieldName);
                    cmd.Parameters.AddWithValue("@p_HealthSystemId", entity.HealthSystemId);
                    cmd.Parameters.AddWithValue("@p_HealthSystemName", entity.HealthSystemName);
                    cmd.Parameters.AddWithValue("@p_IsEditedReverted", entity.IsEditedReverted);
                    cmd.Parameters.AddWithValue("@p_IsResolved", entity.IsResolved);
                    cmd.Parameters.AddWithValue("@p_NewValue", entity.NewValue);
                    cmd.Parameters.AddWithValue("@p_OldValue", entity.OldValue);
                    cmd.Parameters.AddWithValue("@p_ProviderId", entity.ProviderId);
                    cmd.Parameters.AddWithValue("@p_TableName", entity.TableName);
                    cmd.Parameters.AddWithValue("@p_updatedBy", entity.updatedBy);
                    cmd.Parameters.AddWithValue("@p_updatedDate", entity.updatedDate);
                    cmd.Parameters.AddWithValue("@p_VerificationNotRequiredFlag", entity.VerificationNotRequiredFlag);
                    cmd.Parameters.AddWithValue("@p_ModifiedUserId", userId);
                
                using (MySqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    retVal = await cmd.ExecuteNonQueryAsync() > 0;
                }
            }
            catch (MySqlException ex)
            {
                throw new DBConcurrencyException("Optimistic Concurrency Error");
            }
            
            return retVal;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

