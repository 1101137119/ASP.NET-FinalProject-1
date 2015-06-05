using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class ActivityDao : GenericDao<Activity>, IActivityDao
    {
        override protected IRowMapper<Activity> GetRowMapper()
        {
            return new ActivityRowMapper();
        }

        public void AddActivity(Activity activity)
        {
            string command = @"INSERT INTO Activity (Activity_ID, Subject, Host, Assist, Location, Detail, Date_Start, Date_End) VALUES (@Activity_ID, @Subject, @Host, @Assist, @Location, @Detail, @Date_Start, @Date_End);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Activity_ID", DbType.String).Value = activity.Activity_ID;
            parameters.Add("Subject", DbType.String).Value = activity.Subject;
            parameters.Add("Host", DbType.String).Value = activity.Host;
            parameters.Add("Assist", DbType.String).Value = activity.Assist;
            parameters.Add("Location", DbType.String).Value = activity.Location;
            parameters.Add("Detail", DbType.String).Value = activity.Detail;
            parameters.Add("Date_Start", DbType.String).Value = activity.Date_Start;
            parameters.Add("Date_End", DbType.String).Value = activity.Date_End;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateActivity(Activity activity)
        {
            string command = @"UPDATE Activity SET Subject = @Subject, Host = @Host, Assist = @Assist, Location = @Location, Detail = @Detail, Date_Start = @Date_Start, Date_End = @Date_End WHERE Activity_ID = @Activity_ID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Activity_ID", DbType.String).Value = activity.Activity_ID;
            parameters.Add("Subject", DbType.String).Value = activity.Subject;
            parameters.Add("Host", DbType.String).Value = activity.Host;
            parameters.Add("Assist", DbType.String).Value = activity.Assist;
            parameters.Add("Location", DbType.String).Value = activity.Location;
            parameters.Add("Detail", DbType.String).Value = activity.Detail;
            parameters.Add("Date_Start", DbType.String).Value = activity.Date_Start;
            parameters.Add("Date_End", DbType.String).Value = activity.Date_End;
            ExecuteNonQuery(command, parameters);
        }

        public void DeleteActivity(Activity activity)
        {
            string command = @"DELETE FROM Activity WHERE Activity_ID = @Activity_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Activity_ID", DbType.String).Value = activity.Activity_ID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Activity> GetAllActivity()
        {
            string command = @"SELECT * FROM Activity ORDER BY Activity_ID ASC";
            IList<Activity> activity = ExecuteQueryWithRowMapper(command);
            return activity;
        }

        public Activity GetActivityById(string Activity_ID)
        {
            string command = @"SELECT * FROM Activity WHERE Activity_ID = @Activity_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Activity_ID", DbType.String).Value = Activity_ID;

            IList<Activity> activity = ExecuteQueryWithRowMapper(command, parameters);
            if (activity.Count > 0)
            {
                return activity[0];
            }

            return null;
        }
    }
}
