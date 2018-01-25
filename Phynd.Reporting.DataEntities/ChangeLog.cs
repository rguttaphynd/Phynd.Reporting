using System;
using System.Collections.Generic;
using System.Text;

namespace Phynd.Reporting.DataEntities
{
    public partial class ChangeLog
    {
        public int? ChangeApprovedUserId {get; set;}
        public string ChangeApprovedUserName {get; set;}
        public int ChangeLogId {get; set;}
        public DateTime? ChangeSubmittedDate {get; set;}
        public string Comments {get; set;}
        public int? DataSourceId {get; set;}
        public int? EntityId {get; set;}
        public string FieldName {get; set;}
        public int? HealthSystemId {get; set;}
        public string HealthSystemName {get; set;}
        public bool? IsEditedReverted {get; set;}
        public bool? IsResolved {get; set;}
        public string NewValue {get; set;}
        public string OldValue {get; set;}
        public int? ProviderId {get; set;}
        public string TableName {get; set;}
        public string updatedBy {get; set;}
        public DateTime? updatedDate {get; set;}
        public bool? VerificationNotRequiredFlag {get; set;}
    }
}
