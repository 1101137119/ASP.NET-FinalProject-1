using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class ActivityService : IActivityService
    {
        public IActivityDao ActivityDao { get; set; }

        public Activity AddActivity(Activity activity)
        {
            ActivityDao.AddActivity(activity);
            return GetActivityById(activity.Activity_ID);
        }

        public void UpdateActivity(Activity activity)
        {
            ActivityDao.UpdateActivity(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            activity = ActivityDao.GetActivityById(activity.Activity_ID);

            if (activity != null)
            {
                ActivityDao.DeleteActivity(activity);
            }
        }

        public IList<Activity> GetAllActivity()
        {
            return ActivityDao.GetAllActivity();
        }

        public Activity GetActivityById(string Activity_ID)
        {
            return ActivityDao.GetActivityById(Activity_ID);
        }
    }
}
