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
using System.Text;
using BBS.Libraries.Contracts;

namespace BBS.Libraries.Logging
{
    public class StatusTracker
    {
        private readonly StringBuilder _logBuilder;

        private BBS.Libraries.Contracts.ILog Logger;

        public string Log => _logBuilder.ToString();

        public override string ToString()
        {
            return Log;
        }

        public StatusTracker(ILog logger) : this()
        {
            Logger = logger;
        }

        public StatusTracker()
        {
            _logBuilder = new StringBuilder();

            if (Logger == null)
            {
                Logger = new SystemTraceLogging();
            }
        }

        public void AddToLog(string value)
        {
            var logString = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {value} \n";

            Logger.Info(logString);

            _logBuilder.Append(logString);
        }

        public void AddToLog(Exception exception)
        {
            var logString = $"EXCEPTION: {DateTime.Now:MM/dd/yyyy hh:mm:ss:fff} - {exception.Message} \n\t{exception.StackTrace}";

            Logger.Error(logString);

            _logBuilder.Append(logString);
        }
    }
}
