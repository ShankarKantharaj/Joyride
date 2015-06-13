﻿using Joyride.Platforms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Android.Native.SampleApp.ApiDemo.Screens.Views
{
    public class ViewsScreen : ApiDemoScreen
    {
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='android:id/text1' and @text='Animation']")]
        private IWebElement Animation;

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='android:id/text1' and @text='Layouts']")]
        private IWebElement Layouts;

        public override Screen Tap(string elementName, bool precise = false)
        {
            var screen = base.Tap(elementName, precise);

            switch (elementName)
            {
                case "Layouts":
                    return ScreenFactory.CreateScreen<LayoutsScreen>();

                default:
                    return screen;
            }
        }

        public override bool IsOnScreen(int timeOutSecs)
        {
            return ElementExists("Animation", timeOutSecs);
        }

        public override string Name
        {
            get { return "Views"; }
        }
    }
}