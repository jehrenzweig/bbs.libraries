//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) Wednesday, June 29, 2016 1:15:39 PM Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace BBS.Libraries.Logging.AppInsights
{
    public class ApplicationInsightsLogging : BBS.Libraries.Contracts.ILog
    {
        private readonly TelemetryClient _telemetryClient;
        public string InstrumentationKey { get; private set; }

        public ApplicationInsightsLogging()
        {
            this._telemetryClient = new TelemetryClient();
        }

        public ApplicationInsightsLogging(string appInsightsInstrumentationConfigKey)
        {
            this.InstrumentationKey = ConfigurationManager.AppSettings[appInsightsInstrumentationConfigKey];

            if (!string.IsNullOrEmpty(this.InstrumentationKey))
            {
                this._telemetryClient.Context.InstrumentationKey = this.InstrumentationKey;
            }
        }

        public void Info(string value)
        {
            Info(value, null);
        }

        public void Info(object message)
        {
            Info(message, null);
        }

        public void Info(object message, Dictionary<string, string> customProperties)
        {
            var trace = new TraceTelemetry(message.ToString())
            {
                SeverityLevel = LoggingLevels.Information.ToSeverityLevel(),
            };

            if (customProperties != null)
            {
                foreach (var item in customProperties)
                {
                    trace.Properties.Add(item);
                }
            }

            _telemetryClient.Track(trace);
        }

        public void Error(string value)
        {
            Error(new Exception(value), null);
        }

        public void Error(Exception exception)
        {
            Error(exception, null);
        }
        
        public void Error(Exception exception, Dictionary<string, string> customProperties)
        {
            var exceptionTelemetry = new ExceptionTelemetry(exception)
            {
                SeverityLevel = LoggingLevels.Error.ToSeverityLevel()
            };

            if (customProperties != null)
            {
                foreach (var item in customProperties)
                {
                    exceptionTelemetry.Properties.Add(item);
                }
            }

            _telemetryClient.Track(exceptionTelemetry);
        }
    }
}
