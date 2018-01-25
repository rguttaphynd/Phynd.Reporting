using MySql.Data.MySqlClient;
using Phynd.Reporting.DataEntities;
using Phynd.Reporting.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Phynd.Reporting.DataService.Services
{
    public partial class ChangeLogDataServiceRead : IChangeLogDataServiceRead
    {
        public string ConnectionString { get; set; }

        public ChangeLogDataServiceRead(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public async Task<IEnumerable<ChangeLog>> GetAllAsync(int id)
        {
            var retObj = new List<ChangeLog>();
            MySqlCommand cmd = new MySqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "Proc_Reporting_SearchChangeLog"
            };

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@p_HealthSystemID",
                DbType = DbType.Int32,
                Value = id,
            });

            using (MySqlConnection conn = GetConnection())
            {
                cmd.Connection = conn;
                conn.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var dbObj = new ChangeLog()
                        {
                            EntityId= reader["EntityId"] as int?,
                            TableName= reader.GetString(reader.GetOrdinal("TableName")),
                            FieldName= reader.GetString(reader.GetOrdinal("FieldName")),
                            OldValue= reader.GetString(reader.GetOrdinal("OldValue")),
                            NewValue= reader.GetString(reader.GetOrdinal("NewValue")),
                            updatedBy= reader.GetString(reader.GetOrdinal("updatedBy")),
                            updatedDate= reader["updatedDate"] as DateTime?,
                            DataSourceId= reader["DataSourceId"] as int?,
                            ProviderId= reader["ProviderId"] as int?,
                            IsResolved= reader["IsResolved"] as bool?,
                            IsEditedReverted= reader["IsEditedReverted"] as bool?,
                            VerificationNotRequiredFlag= reader["VerificationNotRequiredFlag"] as bool?,
                            Comments= reader.GetString(reader.GetOrdinal("Comments")),
                            ChangeSubmittedDate= reader["ChangeSubmittedDate"] as DateTime?,
                            ChangeApprovedUserId= reader["ChangeApprovedUserId"] as int?,
                            ChangeApprovedUserName= reader.GetString(reader.GetOrdinal("ChangeApprovedUserName")),
                            HealthSystemId= reader["HealthSystemId"] as int?,
                            HealthSystemName= reader.GetString(reader.GetOrdinal("HealthSystemName")),
                        };
                        retObj.Add(dbObj);
                    }
                }
            }

            return retObj;
        }

        public async Task<ChangeLog> GetByIdAsync(int id)
        {
            var retObj = new List<ChangeLog>();
            
            try 
            {
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Proc_Reporting_ReadChangeLog"
                };

                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@p_ChangeLogId",
                    DbType = DbType.Int32,
                    Value = id,
                });

                using (MySqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var dbObj = new ChangeLog()
                            {
                                       EntityId= reader["EntityId"] as int?,
                                        TableName= reader.GetString(reader.GetOrdinal("TableName")),
                                        FieldName= reader.GetString(reader.GetOrdinal("FieldName")),
                                        OldValue= reader.GetString(reader.GetOrdinal("OldValue")),
                                        NewValue= reader.GetString(reader.GetOrdinal("NewValue")),
                                        updatedBy= reader.GetString(reader.GetOrdinal("updatedBy")),
                                       updatedDate= reader["updatedDate"] as DateTime?,
                                       DataSourceId= reader["DataSourceId"] as int?,
                                       ProviderId= reader["ProviderId"] as int?,
                                       IsResolved= reader["IsResolved"] as bool?,
                                       IsEditedReverted= reader["IsEditedReverted"] as bool?,
                                       VerificationNotRequiredFlag= reader["VerificationNotRequiredFlag"] as bool?,
                                        Comments= reader.GetString(reader.GetOrdinal("Comments")),
                                       ChangeSubmittedDate= reader["ChangeSubmittedDate"] as DateTime?,
                                       ChangeApprovedUserId= reader["ChangeApprovedUserId"] as int?,
                                        ChangeApprovedUserName= reader.GetString(reader.GetOrdinal("ChangeApprovedUserName")),
                                       HealthSystemId= reader["HealthSystemId"] as int?,
                                        HealthSystemName= reader.GetString(reader.GetOrdinal("HealthSystemName")),
                            };
                            retObj.Add(dbObj);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
    
            }

            return retObj.Count > 0 ? retObj[0] : null;
        }
        
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

