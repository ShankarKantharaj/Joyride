﻿
namespace Joyride.Platforms.Android
{
    abstract public class AndroidMobileApplication : MobileApplication
    {
        protected static readonly ScreenFactory ScreenFactory = new AndroidScreenFactory();
    }
}
