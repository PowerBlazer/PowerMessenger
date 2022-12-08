

namespace PowerMessenger.Core.Common
{
    public class AuthorizationResult
    {
        public AuthorizationResult()
        {
            IsSuccess= true;
            Errors = new List<string>();
        }

        public bool IsSuccess { get; protected set; }
        public IList<string> Errors { get; protected set; }
        public string? Token { get; set; }

        public void Failed(string[] errors)
        {
            IsSuccess = false;

            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }
    }
}
