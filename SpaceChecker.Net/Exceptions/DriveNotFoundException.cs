using System;

namespace SpaceChecker.Net.Exceptions
{
    public class DriveNotFoundException : Exception
    {
        public DriveNotFoundException(string driveName) : base("Could not find drive with name " + driveName)
        {
        }
    }
}