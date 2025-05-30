using System.Text;

namespace DataStore.FileSystem;

public class FileSystemOperator : ICrud
{
    public async Task<Memory<byte>> ReadAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken)
    {
        if (identifier is not FileIdentifier fsi)
        {
            throw new ArgumentException("Invalid identifier type");
        }
        
        var filepath = (string)identifier.CreateId();
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException(filepath);
        }
        
        return await File.ReadAllBytesAsync(
            filepath, 
            cancellationToken);
    }

    public async Task<string> ReadAsStringAsync(
        IIdentifier identifier,
        CancellationToken cancellationToken) =>
        Encoding.UTF8.GetString(
            (await ReadAsync(identifier, cancellationToken)).Span);

    public async Task WriteAsync(
        IIdentifier identifier, 
        Memory<byte> content, 
        CancellationToken cancellationToken)
    {
        if (identifier is not FileIdentifier fsi)
        {
            throw new ArgumentException("Invalid identifier type");
        }
        
        await File.WriteAllBytesAsync(
            (string)identifier.CreateId(), 
            content.ToArray(), 
            cancellationToken);
    }
    
    public async Task WriteAsync(
        IIdentifier identifier,
        string content,
        CancellationToken cancellationToken) =>
        await WriteAsync(
            identifier, 
            Encoding.UTF8.GetBytes(content),
            cancellationToken);

    public Task DeleteAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken)
    {
        if (identifier is not FileIdentifier fsi)
        {
            throw new ArgumentException("Invalid identifier type");
        }
        
        File.Delete((string)identifier.CreateId());
        return Task.CompletedTask;
    }
}