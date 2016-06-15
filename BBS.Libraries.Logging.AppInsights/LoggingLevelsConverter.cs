using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.DataContracts;

namespace BBS.Libraries.Logging.AppInsights
{
    internal static class LoggingLevelsConverter
    {
        public static SeverityLevel ToSeverityLevel(this LoggingLevels level)
        {
            switch (level)
            {
                case LoggingLevels.Critical:
                    return SeverityLevel.Critical;
                case LoggingLevels.Error:
                    return SeverityLevel.Error;
                case LoggingLevels.Information:
                    return SeverityLevel.Information;
                case LoggingLevels.Warning:
                    return SeverityLevel.Warning;
                default:
                    throw new ArgumentException("Not a valid logging level");
            }
        }
    }
}
