using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Models
{
 public  class Command : BaseEntity
    {
        public enum DbCommand
        {
            Create,
            Update,
            Delete,
            View,
            Copy,
            Transfer,
            Assign,
            Inspection
        }
        public enum FormType
        {
            PopupForm,
            TabForm
        }
        public enum SeverityLevel
        {
            Critical,
            Major,
            Minor
        }
        public enum Status
        {
            Started,
            Paused,
            Held,
            Restart,
            Released,
            Completed,
            Waiting,
            Pending,
            Passed,
            Failed,
            InProgress,
            Rectified
        }
     

        public enum ReportType
        {
            
        }
    }
}
