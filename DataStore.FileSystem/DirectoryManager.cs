namespace DataStore.FileSystem;

/**
 * content - root
 * - a
 *     - a1
 * - b
 *     - b1
 */

public class DirectoryManager
{
    public Task CreateDirectoryAsync(
        DirectoryIdentifier identifier, 
        CancellationToken cancellationToken)
    {
        Directory.CreateDirectory((string)identifier.CreateId());
        return Task.CompletedTask;
    }

    public Task DeleteAsync(
        DirectoryIdentifier identifier,
        CancellationToken cancellationToken)
    {
        string dirPath = (string)identifier.CreateId();
        if (Directory.Exists(dirPath))
        {
            Directory.Delete(dirPath, true);
        }
        return Task.CompletedTask;
    }

    public IEnumerable<IIdentifier> EnumerateIdentifiers(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException(path);
        }
        foreach (var item in Directory.EnumerateFileSystemEntries(path))
        {
            if (Directory.Exists(item))
            {
                yield return new DirectoryIdentifier(item);
            }
            else
            {
                yield return new FileIdentifier(item);
            }
        }
    }
}