

namespace PowerMessenger.Core.Common
{
    public class AuthorizationResult
    {
        public AuthorizationResult()
        {
            IsSuccess = true;
        }

        public bool IsSuccess { get; protected set; }
        public IList<string> Errors { get; protected set; } = new List<string>();
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
