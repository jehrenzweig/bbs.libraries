using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
