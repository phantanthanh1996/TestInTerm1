
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

using SQLite.Net;

namespace TestInTerm
{
    public class DataAccess
    {
        

        public SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)

            dbConn.CreateTable<Task>();
            dbConn.CreateTable<Filter>();
        }
        public List<Task> GetAllTasks()
        {
            return dbConn.Query<Task>("Select * From [Task] order by Priority asc");
        }
        public List<Filter> GetAllFilter()
        {
            return dbConn.Query<Filter>("Select * From [Filter]");
        }
        public Filter GetFilter()
        {
            List<Filter> test = GetAllFilter();
            if (test.Count == 0)
                return null;
            else
            {
                long x = dbConn.Table<Filter>().Max(d => d.FilterId);


                Filter filter = dbConn.Get<Filter>(x); 
                return filter;
            }

        }
        public int SaveTask(Task task)
        {
            return dbConn.Insert(task);
        }
        public int SaveFilter(Filter filter)
        {
            return dbConn.Insert(filter);
        }
        public int DeleteTask(Task task)
        {
            return dbConn.Delete(task);
        }
        public int EditTask(Task task)
        {
            return dbConn.Update(task);
        }
        public int CountX(bool query)
        {

            var count = (from p in dbConn.Table<Task>()
                         where p.Status.Equals(query)
                         select p).Count();

            return count;
        }
        public int CountY(int priority, bool status)
        {
            var count = (
                from p in dbConn.Table<Task>()
                where p.Priority.Equals(priority) && p.Status.Equals(status) && p.Deadline == DateTime.Now
                select p).Count();
            return count;
        }
        public int CountY(int priority, bool status, Task t)
        {
            var count = (
                from p in dbConn.Table<Task>()
                where p.TaskId == t.TaskId && p.Priority.Equals(priority) && p.Status.Equals(status)
                select p).Count();
            return count;
        }
        public List<Task> ListTaskPriority(PriorityType t)
        {
            return dbConn.Query<Task>("Select * From [Task] where Priority = t ");
        }
        public List<Task> ListTaskStatus(bool t)
        {
            return dbConn.Query<Task>("Select * From [Task] where Status = t ");
        }

        public List<Task> ArrangeListTask(int t, string s)
        {
            if (t == 0)
            {
                string x = "Select * From [Task]  order by " + s + " desc";
                return dbConn.Query<Task>(x);
            }
            else
            {
                string x = "Select * From [Task]  order by " + s + " asc";
                return dbConn.Query<Task>(x);
            }

        }
        public List<Task> FilterAndSort(int statusFilter, int priorityFilter, int timeFilter, int sortPriority1, bool showPriority, int sortDeadline1, bool showDeadline)
        {
            string statuscheck = "";
            string timecheck = "";
            string prioritycheck = "";
            string sortprioritycheck = "";
            string sortdeadlinecheck = "";
            string t = DateTime.Now.Date.ToString();
            switch (statusFilter)
            {
                case 0:
                    statuscheck = "";
                    break;
                case 1:
                    statuscheck = "Status =" + true;
                    break;
                case 2:
                    statuscheck = "Status =" + false;
                    break;
            }
            //switch (timeFilter)
            //{
            //    case 0:

            //        break;
            //    case 1:
            //        timecheck =t;
            //        break;
            //    case 2:
            //        timecheck = " false ";
            //        break;
            //}
            int dem = 0;
            for(int i=1; i < 5; i++)
            {

                if(priorityFilter == i)
                {
                    dem++; // 1
                    if (dem >= 2)
                    {
                        prioritycheck += " and ";
                    }
                    prioritycheck += "Priority = " + i;
                }
            }

            //IF 
            switch (sortPriority1)
            {
                case 0:
                    sortprioritycheck = "Priority ASC";
                    break;
                case 1:
                    if (showPriority == false)
                    {
                        sortprioritycheck = "Priority ASC";
                    }
                    else
                    {
                        sortprioritycheck = "Priority DESC";
                    }
                    break;
            }
            switch (sortDeadline1)
            {
                case 0:
                    sortdeadlinecheck = "Deadline asc";
                    break;
                case 1:
                    if (showDeadline == false)
                    {
                        sortdeadlinecheck = "Deadline asc";
                    }
                    else
                    {
                        sortdeadlinecheck = "Deadline desc";
                    }
                    break;
            }
            string ShowListTaskFilter = "";
            if (prioritycheck.CompareTo("") != 0 && statuscheck.CompareTo("") != 0)
            {
                ShowListTaskFilter = "Select * From [Task] where " + prioritycheck + " order by " + sortprioritycheck + ", " + sortdeadlinecheck;
            }
            else if (prioritycheck.CompareTo("") != 0 || statuscheck.CompareTo("") != 0)
            {
                 ShowListTaskFilter = "Select * From [Task]  order by " + sortprioritycheck + ", " + sortdeadlinecheck;
            }
            else
            {
                 ShowListTaskFilter = "Select * From [Task] order by " + sortprioritycheck + ", " + sortdeadlinecheck;
            }

                return dbConn.Query<Task>(ShowListTaskFilter);

        }
    }
}
