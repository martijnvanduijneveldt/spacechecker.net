using System;

namespace SpaceChecker.Net.Exceptions
{
    public class InvalidDriveException : Exception
    {
        public InvalidDriveException(string invalidDriveName) : base($"Invalid drive name {invalidDriveName}, drive name should be a single character between A and Z")
        {
        }
    }
}