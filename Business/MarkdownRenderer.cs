using System.Text;

namespace Business;

public static class MarkdownRenderer
{
    public static string RenderUnorderedList(IEnumerable<string> items) 
    {
        StringBuilder builder = new StringBuilder();
        
        foreach (var item in items)
        {
            builder.AppendLine($"- {item}");
        }

        return builder.ToString();
    }
    
    public static string RenderOrderedList(IEnumerable<string> items) 
    {
        StringBuilder builder = new StringBuilder();
        int index = 1;
        
        foreach (var item in items)
        {
            builder.AppendLine($"{index++}. {item}");
        }

        return builder.ToString();
    }

    public static string RenderHeading1(string text) => $"# {text}";
    
    public static string RenderHeading2(string text) => $"## {text}";
    
    public static string RenderHeading3(string text) => $"### {text}";
    
    public static string RenderCodeBlock(string code, string language = "csharp") => $"```{language}{Environment.NewLine}{code}{Environment.NewLine}```";

    public static string RenderLink(string link, string text) => $"[{text}]({link})";

    public static string RenderImage(string image, string text) => $"![{text}]({image})";
    
    public static string RenderHorizontalRule() => "---";
}

public static class MarkdownExtensions
{
    public static string ToMarkdown(this KnowledgeItem self)
    {
        switch (self.Type)
        {
            case KnowledgeItemType.Heading1:
                return MarkdownRenderer.RenderHeading1(self.Content);
            case KnowledgeItemType.Heading2:
                return MarkdownRenderer.RenderHeading2(self.Content);
            case KnowledgeItemType.Heading3:
                return MarkdownRenderer.RenderHeading3(self.Content);
            case KnowledgeItemType.Text:
                return self.Content;
            case KnowledgeItemType.Bookmark:
                return MarkdownRenderer.RenderLink(self.Content, self.Guid.ToString());
            case KnowledgeItemType.Image:
                return MarkdownRenderer.RenderImage(self.Content, self.Guid.ToString());
            default:
                throw new NotImplementedException();
        }
    }
}