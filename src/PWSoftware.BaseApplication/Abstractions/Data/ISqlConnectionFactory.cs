using System.Data;

namespace PWSoftware.BaseApplication.Abstractions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
