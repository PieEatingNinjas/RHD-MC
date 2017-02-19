using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {

            app.Screenshot("First screen.");
        }

        [Test]
        public void Test_Launch_About()
        {
            app.Tap(c => c.Marked("aboutButton"));
            app.WaitForElement(c => c.Marked("callTextView"));
            app.Screenshot("About screen.");
        }

        [Test]
        public void Test_Launch_About2()
        {
            app.Tap(c => c.Marked("aboutButton"));
            app.WaitForElement(c => c.Marked("action_bar_title").Text("About Ray's Hot Dogs"));
            app.Screenshot("About screen 2.");
        }
    }
}

