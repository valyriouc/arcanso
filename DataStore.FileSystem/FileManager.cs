using System.Text;

namespace DataStore.FileSystem;

public class FileManager
{
    
    public async Task<Memory<byte>> ReadAsync(
        string filepath, 
        CancellationToken cancellationToken)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException(filepath);
        }
        
        return await File.ReadAllBytesAsync(
            filepath, 
            cancellationToken);
    }

    public async Task<string> ReadAsStringAsync(
        string filepath,
        CancellationToken cancellationToken) =>
        Encoding.UTF8.GetString(
            (await ReadAsync(filepath, cancellationToken)).Span);

    public async Task WriteAsync(
        string filepath,
        Memory<byte> content, 
        CancellationToken cancellationToken)
    {
        await File.WriteAllBytesAsync(
            filepath,
            content.ToArray(), 
            cancellationToken);
    }
    
    public async Task WriteAsync(
        string filepath,
        string content,
        CancellationToken cancellationToken) =>
        await WriteAsync(
            filepath,
            Encoding.UTF8.GetBytes(content),
            cancellationToken);

    public void Delete(
        string filepath) =>
        File.Delete(filepath);

    public async Task DeleteAsync(
        string filepath,
        CancellationToken cancellationToken)
    {
        if (File.Exists(filepath))
        {
            await Task.Run(() => File.Delete(filepath), cancellationToken);
        }
    }

    public async Task DeleteAsync(
        IIdentifier identifier,
        CancellationToken cancellationToken)
    {
        string filepath = identifier is FileIdentifier fileId
            ? (string)fileId.CreateId()
            : throw new ArgumentException("Identifier is not a FileIdentifier");
        await DeleteAsync(filepath, cancellationToken);
    }
}