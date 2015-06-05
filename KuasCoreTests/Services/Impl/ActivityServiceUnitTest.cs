using Core;
using KuasCore.Models;
using KuasCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class ActivityServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IActivityService ActivityService { get; set; }

        [TestMethod]
        public void TestActivityService_AddActivity()
        {

            Activity activity = new Activity();
            activity.Activity_ID = "UnitTests";
            activity.Subject = "單元測試";
            activity.Host = "請做出單元測試";
            ActivityService.AddActivity(activity);

            Activity dbActivity = ActivityService.GetActivityById(activity.Activity_ID);
            Assert.IsNotNull(dbActivity);
            Assert.AreEqual(activity.Activity_ID, dbActivity.Activity_ID);

            Console.WriteLine("活動編號為 = " + dbActivity.Activity_ID);
            Console.WriteLine("活動名稱為 = " + dbActivity.Subject);
            Console.WriteLine("活動主辦為 = " + dbActivity.Host);

            ActivityService.DeleteActivity(dbActivity);
            dbActivity = ActivityService.GetActivityById(activity.Activity_ID);
            Assert.IsNull(dbActivity);
        }

    }
}
