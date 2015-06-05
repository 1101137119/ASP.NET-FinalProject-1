using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class ActivityRowMapper : IRowMapper<Activity>
    {
        public Activity MapRow(IDataReader dataReader, int rowNum)
        {
            Activity target = new Activity();

            target.Activity_ID = dataReader.GetString(dataReader.GetOrdinal("Activity_ID"));
            target.Subject = dataReader.GetString(dataReader.GetOrdinal("Subject"));
            target.Host = dataReader.GetString(dataReader.GetOrdinal("Host"));
            target.Assist = dataReader.GetString(dataReader.GetOrdinal("Assist"));
            target.Location = dataReader.GetString(dataReader.GetOrdinal("Location"));
            target.Detail = dataReader.GetString(dataReader.GetOrdinal("Detail"));
            target.Date_Start = dataReader.GetDateTime(dataReader.GetOrdinal("Date_Start"));
            target.Date_End = dataReader.GetDateTime(dataReader.GetOrdinal("Date_End"));
            return target;
        }
    }
}
