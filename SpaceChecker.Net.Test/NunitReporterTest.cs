using System;
using System.IO;
using NUnit.Framework;
using SpaceChecker.Net;
using SpaceChecker.Net.Models;

namespace SpaceChecker.Net.Test
{
    [TestFixture]
    public class NunitReporterTest
    {
        [Test]
        public void ShouldBeAbleToWriteToRandomFolder()
        {
            var opts = new Options
            {
                NUnitOuputFile = Guid.NewGuid() + "/output.xml"
            };
            var testCase = new TestCase
            {
                Name = "CheckSpace",
            };
            NunitReporter.OutputAsFile(opts, testCase);

            var fileExists = File.Exists(opts.NUnitOuputFile);
            Assert.IsTrue(fileExists, "File should exist");
        }
    }
}