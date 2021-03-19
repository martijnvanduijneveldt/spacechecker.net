using NUnit.Framework;
using ScapeChecker.Net;
using ScapeChecker.Net.Exceptions;
using ScapeChecker.Net.Models;

namespace SpaceChecker.Net.Test
{
    [TestFixture]
    public class ConsoleReporterTest
    {
        [Test]
        public void InvalidMachineShouldThrow()
        {
            var opt = new Options
            {
                MachineName = "aazddsnofdbnjik..."
            };
            
            Assert.Throws<ConnectionError>(() =>
            {
                Runner.RunOptions(opt);
            });
        }
        
        [Test]
        public void InvalidDiskShouldThrow()
        {
            var opt = new Options
            {
                Size = 10,
                DriveName = "Z",
                MachineName = ".",
                Unit = SizeUnit.KB
            };
            
            Assert.Throws<DriveNotFoundException>(() =>
            {
                Runner.RunOptions(opt);
            });
        }

        [Test]
        public void CompareDiskSize()
        {
            
        }
    }
}