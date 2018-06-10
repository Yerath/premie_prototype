using System;

namespace LicentieService.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message)
            : base(message)
        {
        }
    }
}
