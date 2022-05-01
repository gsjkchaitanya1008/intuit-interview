// See https://aka.ms/new-console-template for more information
using MarkdownConverter;

string markdown = Console.ReadLine();
MarkdownToHtmlConverter converter = new MarkdownToHtmlConverter();
var html = await converter.ConvertToHtml(markdown);
Console.WriteLine(html);
