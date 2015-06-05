using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao
{
     public interface IActivityDao
    {
         void AddActivity(Activity activity);

         void UpdateActivity(Activity activity);

         void DeleteActivity(Activity activity);

         IList<Activity> GetAllActivity();

         Activity GetActivityById(string Activity_ID);

    }
}
