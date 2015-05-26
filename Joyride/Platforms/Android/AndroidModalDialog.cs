﻿using System;
using System.Collections.Generic;

namespace Joyride.Platforms.Android
{
    // testing... this approach
    abstract public class AndroidModalDialog : Component, IModalDialog
    {
        protected static ScreenFactory ScreenFactory = new AndroidScreenFactory();        
        public abstract string Body { get; }
        public abstract string Title { get; }
        public abstract Screen Accept();
        public abstract Screen Dismiss();
        public abstract Screen RespondWith(string response);
        public abstract bool IsOnScreen(int timoutSecs);

        protected void SetTransition(string response, Func<Screen> func) { TransitionMap[response] = func; }
        protected Screen TransitionFromResponse(string response) { return TransitionMap[response](); }
        protected Dictionary<string, Func<Screen>> TransitionMap = new Dictionary<string, Func<Screen>>();

    }

}
