namespace Business;

// Basedir
//  - Blocks
//  - Pages 

public class Page
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public List<Guid> BlockOrder { get; set; } = new();
    
    public List<KnowledgeItem> Items { get; set; } = new();
}

public enum KnowledgeItemType
{
    Heading1,
    Heading2,
    Heading3,
    Text,
    Image,
    Video,
    Bookmark,
    File,
    PageLink,
}

public class KnowledgeItem(
    int id,
    Guid guid,
    KnowledgeItemType type,
    string content)
{
    public int Id { get; } = id;

    public Guid Guid { get; } = guid;

    public KnowledgeItemType Type { get; } = type;

    public string Content { get; } = content;
}



