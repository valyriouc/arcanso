namespace DataStore;

public interface IRead<T>
    where T : IIdentifier
{
    public Task<Memory<byte>> ReadAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken);
}

public interface IWrite<T> 
    where T : IIdentifier
{
    public Task WriteAsync(
        T identifier,
        Memory<byte> content, 
        CancellationToken cancellationToken);
}

public interface IDelete<T> 
    where  T : IIdentifier
{
    public Task DeleteAsync(
        T identifier,
        CancellationToken cancellationToken);
}

public interface IIdentifier
{
    
}