using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BBS.Libraries.UnitTests.General
{
    [TestFixture]
    public class StatusTracker
    {
        [Test]
        public void AddToLog_AddsToLog()
        {
            // ARRANGE
            var statusTracker = new BBS.Libraries.Logging.StatusTracker();
            const string message = "this is a test message!";

            // ACT
            statusTracker.AddToLog(message);

            // ASSERT
            Assert.That(statusTracker.Log, Contains.Substring(message));
        }

        [Test]
        public void AddErrorToLog_AddsToLog()
        {
            // ARRANGE
            var statusTracker = new BBS.Libraries.Logging.StatusTracker();
            const string message = "Out of memory";
            var error = new OutOfMemoryException(message);

            // ACT
            statusTracker.AddToLog(error);

            // ASSERT
            Assert.That(statusTracker.Log, Contains.Substring($"EXCEPTION: "));
            Assert.That(statusTracker.Log, Contains.Substring(message));
        }
    }
}
