

namespace PowerMessenger.Core.Exceptions
{
    public class IsNullValueException:ArgumentException
    {

        public IsNullValueException(string message)
            : base(message)
        {
           
        }
    }
}
