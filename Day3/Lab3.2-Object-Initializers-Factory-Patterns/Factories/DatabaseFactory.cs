

using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

public abstract class DatabaseFactoryBase
{
    protected DatabaseFactoryBase(string database) => Database = database;
    protected string Database { get; }
    public abstract IDbConnection CreateConnection();
    public abstract IDbCommand CreateCommand(string sql);
    public abstract IDbTransaction CreateTransaction(string isolationLevel);
}

public sealed class SqlServerDatabaseFactory(string database) : DatabaseFactoryBase(database)
{
    public override IDbConnection CreateConnection() => new SqlConnection(Database);
    public override IDbCommand CreateCommand(string sql) => new SqlCommand(sql);
    public override IDbTransaction CreateTransaction(string isolationLevel) => new SqlTransaction(isolationLevel);
}

file sealed class SqlConnection(string db) : IDbConnection
{
    public string Provider => "SqlServer";
    public string Database => db;
    public override string ToString() => $"{Provider}Connection to {Database}";
}
file sealed class SqlCommand(string sql) : IDbCommand
{
    public string Provider => "SqlServer";
    public string CommandText => sql;
    public override string ToString() => $"{Provider}Command ready for execution";
}
file sealed class SqlTransaction(string iso) : IDbTransaction
{
    public string Provider => "SqlServer";
    public string IsolationLevel => iso;
    public override string ToString() => $"{Provider}Transaction (Isolation: {IsolationLevel})";
}
