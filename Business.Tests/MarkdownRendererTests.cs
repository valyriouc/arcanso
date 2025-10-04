using Xunit;

namespace Business.Tests;

public class MarkdownRendererTests
{
    [Fact]
    public void RenderHeading1_ShouldReturnCorrectMarkdown()
    {
        // Arrange
        // Act
        var result = MarkdownRenderer.RenderHeading1("Titel");
        // Assert
        Assert.Equal("# Titel", result);
    }
    
    [Fact]
    public void RenderHeading2_ShouldReturnCorrectMarkdown()
    {
        // Arrange
        // Act
        var result = MarkdownRenderer.RenderHeading2("Titel");
        // Assert
        Assert.Equal("## Titel", result);
    }
    
    [Fact]
    public void RenderHeading3_ShouldReturnCorrectMarkdown()
    {
        // Arrange
        // Act
        var result = MarkdownRenderer.RenderHeading3("Titel");
        // Assert
        Assert.Equal("### Titel", result);
    }

    

    [Fact]
    public void RenderUnorderedList_ShouldReturnCorrectMarkdown()
    {
        var items = new[] { "Item 1", "Item 2", "Item 3" };
        var result = MarkdownRenderer.RenderUnorderedList(items);
        Assert.Equal($"- Item 1{Environment.NewLine}- Item 2{Environment.NewLine}- Item 3{Environment.NewLine}", result);
    }

    [Fact]
    public void RenderOrderedList_ShouldReturnCorrectMarkdown()
    {
        var items = new[] { "First", "Second" };
        var result = MarkdownRenderer.RenderOrderedList(items);
        Assert.Equal($"1. First{Environment.NewLine}2. Second{Environment.NewLine}", result);
    }

    [Fact]
    public void RenderCodeBlock_ShouldReturnCorrectMarkdown()
    {
        var code = "Console.WriteLine(\"Hello\");";
        var result = MarkdownRenderer.RenderCodeBlock(code, "csharp");
        Assert.Equal($"```csharp{Environment.NewLine}Console.WriteLine(\"Hello\");{Environment.NewLine}```", result);
    }
    
    // [Fact]
    // public void RenderBold_ShouldReturnCorrectMarkdown()
    // {
    //     var result = Mar.RenderBold("fett");
    //     Assert.Equal("**fett**", result);
    // }

    // [Fact]
    // public void RenderItalic_ShouldReturnCorrectMarkdown()
    // {
    //     var renderer = new MarkdownRenderer();
    //     var result = renderer.RenderItalic("kursiv");
    //     Assert.Equal("*kursiv*", result);
    // }

    [Fact]
    public void RenderLink_ShouldReturnCorrectMarkdown()
    {
        var result = MarkdownRenderer.RenderLink("https://google.com", "Google");
        Assert.Equal("[Google](https://google.com)", result);
    }

    [Fact]
    public void RenderImage_ShouldReturnCorrectMarkdown()
    {
        var result = MarkdownRenderer.RenderImage("logo.png", "Logo");
        Assert.Equal("![Logo](logo.png)", result);
    }

//     [Fact]
//     public void RenderTable_ShouldReturnCorrectMarkdown()
//     {
//         var renderer = new MarkdownRenderer();
//         var headers = new[] { "Name", "Alter" };
//         var rows = new[] { new[] { "Anna", "30" }, new[] { "Bob", "25" } };
//         var result = renderer.RenderTable(headers, rows);
//         var expected = 
// @"| Name | Alter |
// | --- | --- |
// | Anna | 30 |
// | Bob | 25 |";
//         Assert.Equal(expected, result);
//     }
//
//     [Fact]
//     public void RenderBlockquote_ShouldReturnCorrectMarkdown()
//     {
//         var renderer = new MarkdownRenderer();
//         var result = renderer.RenderBlockquote("Zitat");
//         Assert.Equal("> Zitat", result);
//     }

    [Fact]
    public void RenderHorizontalRule_ShouldReturnCorrectMarkdown()
    {
        var result = MarkdownRenderer.RenderHorizontalRule();
        Assert.Equal("---", result);
    }
    //
    // [Fact]
    // public void RenderEscapedText_ShouldEscapeMarkdownCharacters()
    // {
    //     var renderer = new MarkdownRenderer();
    //     var result = renderer.RenderEscapedText("Text mit * und _ und `");
    //     Assert.Equal(@"Text mit \* und \_ und \`", result);
    // }
}
