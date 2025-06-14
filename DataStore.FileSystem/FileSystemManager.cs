﻿using System.Text.Json;

namespace DataStore.FileSystem;

public class FileSystemManager
{
    private readonly FileSystemOperator _operator = new();

    public async Task<TEntity> ReadAsync<TEntity>(
        IIdentifier identifier,
        CancellationToken cancellationToken)
    {
        string content = await _operator.ReadAsStringAsync(identifier, cancellationToken);
        return JsonSerializer.Deserialize<TEntity>(content) ?? 
               throw new JsonException($"Could not deserialize type {typeof(TEntity)}");
    }
    
    public async Task<string> ReadAsStringAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken) =>
        await _operator.ReadAsStringAsync(identifier, cancellationToken);

    public async Task WriteAsync<TEntity>(
        IIdentifier identifier, 
        TEntity entity,
        CancellationToken cancellationToken)
    {
        string content = JsonSerializer.Serialize(entity);
        await _operator.WriteAsync(identifier, content, cancellationToken);
    }

    public async Task WriteAsync(
        IIdentifier identifier, 
        string content, 
        CancellationToken cancellationToken) => 
        await _operator.WriteAsync(identifier, content, cancellationToken);
    
    public Task DeleteAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken) =>
        _operator.DeleteAsync(identifier, cancellationToken);
    
    public Task CreateDirectoryAsync(
        IIdentifier identifier, 
        CancellationToken cancellationToken)
    {
        if (identifier is not DirectoryIdentifier dsi)
        {
            throw new ArgumentException("Invalid identifier type");
        }
        
        Directory.CreateDirectory((string)identifier.CreateId());
        return Task.CompletedTask;
    }

    public IEnumerable<IIdentifier> EnumerateIdentifiers(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException(nameof(path));
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
    
    public IEnumerable<IIdentifier> EnumerateIdentifiers(DirectoryIdentifier identifier) =>
        EnumerateIdentifiers((string)identifier.CreateId());
    
}