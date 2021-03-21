using System;

namespace SpaceChecker.Net.Exceptions
{
    public class ConnectionError : Exception
    {
        public ConnectionError(Exception innerException) : base("Failed to connect", innerException)
        {
        }
    }
}