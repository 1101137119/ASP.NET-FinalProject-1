using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class ActivityController : ApiController
    {

        public IActivityService ActivityService { get; set; }

        [HttpPost]
        public Activity AddActivity(Activity activity)
        {
            CheckActivityIsNotNullThrowException(activity);

            try
            {
                return ActivityService.AddActivity(activity);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Activity UpdateActivity(Activity actvitiy)
        {
            CheckActivityIsNullThrowException(actvitiy);

            try
            {
                ActivityService.UpdateActivity(actvitiy);
                return ActivityService.GetActivityById(actvitiy.Activity_ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteEmployee(Activity actvitiy)
        {
            try
            {
                ActivityService.DeleteActivity(actvitiy);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Activity> GetAllActivity()
        {
            return ActivityService.GetAllActivity();
        }

        [HttpGet]
        public Activity GetActivityById(string id)
        {
            var activity = ActivityService.GetActivityById(id);

            if (activity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return activity;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="activity">
        ///     課程資料.
        /// </param>
        private void CheckActivityIsNullThrowException(Activity activity)
        {
            Activity dbActivity = ActivityService.GetActivityById(activity.Activity_ID);

            if (dbActivity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="activity">
        ///     課程資料.
        /// </param>
        private void CheckActivityIsNotNullThrowException(Activity activity)
        {
            Activity dbactivity = ActivityService.GetActivityById(activity.Activity_ID);

            if (dbactivity != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}