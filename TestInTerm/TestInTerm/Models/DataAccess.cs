
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
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.StoreDateTimeAsTicks.Equals(false);

            dbConn.CreateTable<Task>();

        }
        public List<Task> GetAllTasks()
        {
            return dbConn.Query<Task>("Select * From [Task] order by Priority asc");
        }
        public int SaveTask(Task task)
        {
            return dbConn.Insert(task);
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
    }
}
