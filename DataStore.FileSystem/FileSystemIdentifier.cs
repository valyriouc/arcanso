namespace DataStore.FileSystem;

public class FileIdentifier : IIdentifier
{
    private readonly string _rootPath;
    private readonly string[] _subPaths;

    public FileIdentifier(string rootPath, string[] subPaths)
    {
        if (string.IsNullOrWhiteSpace(rootPath))
        {
            throw new ArgumentException(nameof(rootPath));
        }

        if (!Directory.Exists(rootPath))
        {
            throw new DirectoryNotFoundException(rootPath);
        }
        
        this._rootPath = rootPath;
        this._subPaths = subPaths;
    }

    public FileIdentifier(string path) : this(path, []){}

    public object CreateId() => Path.Combine([_rootPath, .._subPaths]);
}

public class DirectoryIdentifier(string[] path) : IIdentifier
{
    public DirectoryIdentifier(string path) : this([path])
    {
        
    }
    
    public object CreateId() => Path.Combine(path);
}