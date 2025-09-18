// using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

// namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

// // Abstract Factory Pattern
// public abstract class DatabaseFactory
// {
//     public abstract IDatabase CreateDatabase(string connectionString);
//     public abstract IDbCommand CreateCommand();
//     public abstract IDbTransaction CreateTransaction();

//     public static DatabaseFactory GetFactory(DatabaseType type)
//     {
//         return type switch
//         {
//             DatabaseType.SqlServer => new SqlServerFactory(),
//             DatabaseType.MySQL => new MySqlFactory(),
//             DatabaseType.PostgreSQL => new PostgreSqlFactory(),
//             DatabaseType.SQLite => new SQLiteFactory(),
//             _ => throw new ArgumentException($"Unsupported database type: {type}")
//         };
//     }
// }

// // Concrete Factories
// public class SqlServerFactory : DatabaseFactory
// {
//     public override IDatabase CreateDatabase(string connectionString)
//     {
//         return new SqlServerDatabase(connectionString);
//     }

//     public override IDbCommand CreateCommand()
//     {
//         return new SqlServerCommand();
//     }

//     public override IDbTransaction CreateTransaction()
//     {
//         return new SqlServerTransaction();
//     }
// }

// public class MySqlFactory : DatabaseFactory
// {
//     public override IDatabase CreateDatabase(string connectionString)
//     {
//         return new MySqlDatabase(connectionString);
//     }

//     public override IDbCommand CreateCommand()
//     {
//         return new MySqlCommand();
//     }

//     public override IDbTransaction CreateTransaction()
//     {
//         return new MySqlTransaction();
//     }
// }

// public class PostgreSqlFactory : DatabaseFactory
// {
//     public override IDatabase CreateDatabase(string connectionString)
//     {
//         return new PostgreSqlDatabase(connectionString);
//     }

//     public override IDbCommand CreateCommand()
//     {
//         return new PostgreSqlCommand();
//     }

//     public override IDbTransaction CreateTransaction()
//     {
//         return new PostgreSqlTransaction();
//     }
// }

// public class SQLiteFactory : DatabaseFactory
// {
//     public override IDatabase CreateDatabase(string connectionString)
//     {
//         return new SQLiteDatabase(connectionString);
//     }

//     public override IDbCommand CreateCommand()
//     {
//         return new SQLiteCommand();
//     }

//     public override IDbTransaction CreateTransaction()
//     {
//         return new SQLiteTransaction();
//     }
// }

// // Concrete Database Implementations
// public class SqlServerDatabase : IDatabase
// {
//     public string ConnectionString { get; }
//     public DatabaseType Type => DatabaseType.SqlServer;
//     public bool IsConnected { get; private set; }

//     public SqlServerDatabase(string connectionString)
//     {
//         ConnectionString = connectionString;
//     }

//     public void Connect()
//     {
//         IsConnected = true;
//         Console.WriteLine($"Connected to SQL Server: {ConnectionString}");
//     }

//     public void Disconnect()
//     {
//         IsConnected = false;
//         Console.WriteLine("Disconnected from SQL Server");
//     }

//     public IDbCommand CreateCommand() => new SqlServerCommand();
//     public IDbTransaction BeginTransaction() => new SqlServerTransaction();

//     public override string ToString()
//     {
//         return $"SqlServerConnection to {ConnectionString.Split(';')[0]}";
//     }
// }

// public class MySqlDatabase : IDatabase
// {
//     public string ConnectionString { get; }
//     public DatabaseType Type => DatabaseType.MySQL;
//     public bool IsConnected { get; private set; }

//     public MySqlDatabase(string connectionString)
//     {
//         ConnectionString = connectionString;
//     }

//     public void Connect()
//     {
//         IsConnected = true;
//         Console.WriteLine($"Connected to MySQL: {ConnectionString}");
//     }

//     public void Disconnect()
//     {
//         IsConnected = false;
//         Console.WriteLine("Disconnected from MySQL");
//     }

//     public IDbCommand CreateCommand() => new MySqlCommand();
//     public IDbTransaction BeginTransaction() => new MySqlTransaction();
// }

// public class PostgreSqlDatabase : IDatabase
// {
//     public string ConnectionString { get; }
//     public DatabaseType Type => DatabaseType.PostgreSQL;
//     public bool IsConnected { get; private set; }

//     public PostgreSqlDatabase(string connectionString)
//     {
//         ConnectionString = connectionString;
//     }

//     public void Connect()
//     {
//         IsConnected = true;
//         Console.WriteLine($"Connected to PostgreSQL: {ConnectionString}");
//     }

//     public void Disconnect()
//     {
//         IsConnected = false;
//         Console.WriteLine("Disconnected from PostgreSQL");
//     }

//     public IDbCommand CreateCommand() => new PostgreSqlCommand();
//     public IDbTransaction BeginTransaction() => new PostgreSqlTransaction();
// }

// public class SQLiteDatabase : IDatabase
// {
//     public string ConnectionString { get; }
//     public DatabaseType Type => DatabaseType.SQLite;
//     public bool IsConnected { get; private set; }

//     public SQLiteDatabase(string connectionString)
//     {
//         ConnectionString = connectionString;
//     }

//     public void Connect()
//     {
//         IsConnected = true;
//         Console.WriteLine($"Connected to SQLite: {ConnectionString}");
//     }

//     public void Disconnect()
//     {
//         IsConnected = false;
//         Console.WriteLine("Disconnected from SQLite");
//     }

//     public IDbCommand CreateCommand() => new SQLiteCommand();
//     public IDbTransaction BeginTransaction() => new SQLiteTransaction();
// }

// // Command Implementations
// public class SqlServerCommand : IDbCommand
// {
//     public string CommandText { get; set; } = string.Empty;

//     public void Execute()
//     {
//         Console.WriteLine($"Executing SQL Server command: {CommandText}");
//     }

//     public T ExecuteScalar<T>()
//     {
//         Console.WriteLine($"Executing SQL Server scalar: {CommandText}");
//         return default(T)!;
//     }

//     public override string ToString() => "SqlServerCommand ready for execution";
// }

// public class MySqlCommand : IDbCommand
// {
//     public string CommandText { get; set; } = string.Empty;

//     public void Execute()
//     {
//         Console.WriteLine($"Executing MySQL command: {CommandText}");
//     }

//     public T ExecuteScalar<T>()
//     {
//         Console.WriteLine($"Executing MySQL scalar: {CommandText}");
//         return default(T)!;
//     }
// }

// public class PostgreSqlCommand : IDbCommand
// {
//     public string CommandText { get; set; } = string.Empty;

//     public void Execute()
//     {
//         Console.WriteLine($"Executing PostgreSQL command: {CommandText}");
//     }

//     public T ExecuteScalar<T>()
//     {
//         Console.WriteLine($"Executing PostgreSQL scalar: {CommandText}");
//         return default(T)!;
//     }
// }

// public class SQLiteCommand : IDbCommand
// {
//     public string CommandText { get; set; } = string.Empty;

//     public void Execute()
//     {
//         Console.WriteLine($"Executing SQLite command: {CommandText}");
//     }

//     public T ExecuteScalar<T>()
//     {
//         Console.WriteLine($"Executing SQLite scalar: {CommandText}");
//         return default(T)!;
//     }
// }

// // Transaction Implementations
// public class SqlServerTransaction : IDbTransaction
// {
//     public void Commit()
//     {
//         Console.WriteLine("SQL Server transaction committed");
//     }

//     public void Rollback()
//     {
//         Console.WriteLine("SQL Server transaction rolled back");
//     }

//     public void Dispose()
//     {
//         Console.WriteLine("SQL Server transaction disposed");
//     }

//     public override string ToString() => "SqlServerTransaction (Isolation: ReadCommitted)";
// }

// public class MySqlTransaction : IDbTransaction
// {
//     public void Commit() => Console.WriteLine("MySQL transaction committed");
//     public void Rollback() => Console.WriteLine("MySQL transaction rolled back");
//     public void Dispose() => Console.WriteLine("MySQL transaction disposed");
// }

// public class PostgreSqlTransaction : IDbTransaction
// {
//     public void Commit() => Console.WriteLine("PostgreSQL transaction committed");
//     public void Rollback() => Console.WriteLine("PostgreSQL transaction rolled back");
//     public void Dispose() => Console.WriteLine("PostgreSQL transaction disposed");
// }

// public class SQLiteTransaction : IDbTransaction
// {
//     public void Commit() => Console.WriteLine("SQLite transaction committed");
//     public void Rollback() => Console.WriteLine("SQLite transaction rolled back");
//     public void Dispose() => Console.WriteLine("SQLite transaction disposed");
// }

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