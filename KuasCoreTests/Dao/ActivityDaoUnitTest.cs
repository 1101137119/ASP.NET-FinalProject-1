using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class ActivityDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IActivityDao ActivityDao { get; set; }


        [TestMethod]
        public void TestActivityDao_AddActivity()
        {
            Activity activity = new Activity();
            activity.Activity_ID = "UnitTests";
            activity.Subject = "單元測試";
            activity.Host = "請做出單元測試";
            ActivityDao.AddActivity(activity);

            Activity dbActivity = ActivityDao.GetActivityById(activity.Activity_ID);
            Assert.IsNotNull(dbActivity);
            Assert.AreEqual(activity.Activity_ID, dbActivity.Activity_ID);

            Console.WriteLine("活動編號為 = " + dbActivity.Activity_ID);
            Console.WriteLine("活動名稱為 = " + dbActivity.Subject);
            Console.WriteLine("活動主辦為 = " + dbActivity.Host);

            ActivityDao.DeleteActivity(dbActivity);
            dbActivity = ActivityDao.GetActivityById(activity.Activity_ID);
            Assert.IsNull(dbActivity);
        }

    }
}
