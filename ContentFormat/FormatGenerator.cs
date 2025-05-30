namespace ContentFormat;

public enum BlockType
{
    Text,
    Link,
    Webmark,
    Image,
    Video,
    Heading1,
    Heading2,
    Heading3,
    UnorderedList,
    OrderedList,
    CodeBlock,
    Integration
}

public class FormatGenerator
{
    public static string ExtractContent()
    {
        throw new NotImplementedException();
    }
}