using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TestInTerm
{
    
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public long TaskId { get; set; }
        [NotNull]
        public string TaskName { get; set; }
        public string DesShort { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime Deadline { get; set; }
        public bool Status { get; set; }
        public PriorityType Priority { get; set; }
        public string TimeDeadline => Deadline.Subtract(TimeStart).ToString();


    }
}
