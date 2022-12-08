

using System.Data;

namespace PowerMessenger.Core.Contexts
{
    public interface IApplicationContextDapper
    {
        public IDbConnection CreateConnection();
    }
}
