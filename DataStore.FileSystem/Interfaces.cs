namespace DataStore;

public interface IRead
{
    public Task<Memory<byte>> ReadAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken);
}

public interface IWrite
{
    public Task WriteAsync(
        IIdentifier identifier,
        Memory<byte> content, 
        CancellationToken cancellationToken);
}

public interface IDelete
{
    public Task DeleteAsync(
        IIdentifier identifier,
        CancellationToken cancellationToken);
}

public interface IReadWrite : IRead, IWrite;

public interface ICrud : IReadWrite, IDelete;

public interface IIdentifier
{
    public object CreateId();
}