using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInTerm
{
    public class Filter
    {
        [PrimaryKey, AutoIncrement]
        public long FilterId { get; set; }
        public bool FilterCheck { get; set; }
        public int StatusFilter { get; set; } //xet 
        public int PriorityFilter { get; set; }
        public bool Priority_Cristical { get; set; }
        public bool Priority_High { get; set; }
        public bool Priority_Normal { get; set; }
        public bool Priority_Low { get; set; }
        public bool Priority_All { get; set; }
        public int TimeFilter { get; set; }
        public int SortPriority1 { get; set; }
        public int SortDeadline1 { get; set; }
        public bool ShowPriority { get; set; }
        public bool ShowDeadline { get; set; }

    }
}

//statusFilter,  priorityFilter,  timeFilter,  sortPriority1,  showPriority,  sortDeadline1, showDeadline