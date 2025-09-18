namespace Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

public interface IDbConnection
{
    string Provider { get; }
    string Database { get; }
}
public interface IDbCommand
{
    string Provider { get; }
    string CommandText { get; }
}
public interface IDbTransaction
{
    string Provider { get; }
    string IsolationLevel { get; }
}