using FrameWork;
using FrameWork.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Royal.Pages;

namespace Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeClass()
        {
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeTest()
        {
            FW.setLogger();
            Driver.InitDriver();
            Pages.Init();
            Driver.GoTO("https://statsroyale.com");
        }
        
        [TearDown]
        public virtual void AfterTest()
        {
          var outcome= TestContext.CurrentContext.Result.Outcome.Status;
          if(outcome == TestStatus.Passed)
          {
              FW.log.Info("Outcome: Passed");
          }
          else if(outcome == TestStatus.Failed)
          {
              FW.log.Info("Outcome: Failed");
          }
          else
          {
              FW.log.Warning("Outcome: "+ outcome);
          }
          Driver.Quit();
        }

    }
}