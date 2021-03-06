﻿using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using Joyride.Extensions;
using Joyride.Specflow.Configuration;
using TechTalk.SpecFlow;

namespace Joyride.Specflow.Support
{
    public static class ScreenCapturer
    {
        private static string RemoveInvalidChars(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(CultureInfo.InvariantCulture), string.Empty));
        }

        private static string TruncateToAcceptableFileLength(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string CreateFilename(string extension)
        {
            var filename = RemoveInvalidChars(ScenarioContext.Current.ScenarioInfo.Title);
            filename = TruncateToAcceptableFileLength(filename, 250); // max. allowable is 255
            filename = AddIndexToFilename(filename, extension);
            return filename;
        }

        private static string AddIndexToFilename(string filename, string extension)
        {
            var i = 1;
            var pathAndFilename = JoyrideConfiguration.ScreenshotPath + filename;
            while (File.Exists(pathAndFilename + i + extension))
                i++;
            return pathAndFilename + i + extension;
        }

        public static void Capture()
        {
            try
            {
                if (Context.Driver != null)
                {
                    var filename = CreateFilename(".png");
                    Context.Driver.CaptureScreenshot(filename, ImageFormat.Png);
                    Trace.WriteLine("Screenshot saved for " + filename);
                }
                else
                    Trace.WriteLine("WARNING:  Skipping screen capture due to driver not initialized");

            }
            catch(Exception e)
            {
                Trace.WriteLine("Unencountered exception taking screen capture");
                Trace.WriteLine(e);
            }
        }

    }
}
