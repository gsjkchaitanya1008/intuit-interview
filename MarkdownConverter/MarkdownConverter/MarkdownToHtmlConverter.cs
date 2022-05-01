using System.Text;

namespace MarkdownConverter
{
    /// <summary>
    /// Represents markdown to html converter.
    /// </summary>
    public class MarkdownToHtmlConverter
    {
        /// <summary>
        /// Converts markdown text to html.
        /// </summary>
        /// <param name="markdown">Markdown text.</param>
        /// <returns>Html formatted text.</returns>
        public async Task<string> ConvertToHtml(string markdown)
        {
            // If the markdown is null or empty string, return arguement exception.
            if (markdown == null)
            {
                throw new ArgumentNullException("Markdown should not be null.", nameof(markdown));
            }

            StringBuilder htmlFormattedText = new StringBuilder();

            // Read markdown string to string reader to read line by line.
            using (StringReader reader = new StringReader(markdown))
            {
                string line;

                //Read until all the lines are parsed to html text.
                while (!string.IsNullOrWhiteSpace(value: line = reader.ReadLine()))
                {
                    // Parse each line to html text.
                    var parsedHtml = await ParseMarkdown(line);

                    // Append parsed html text to output html formmatted text.
                    htmlFormattedText.AppendLine(parsedHtml);
                }
            }

            return htmlFormattedText.ToString().TrimEnd('\n').TrimEnd('\r');
        }

        private async Task<string> ParseMarkdown(string markdown)
        {
            string? html = string.Empty;

            // Get html tag of the markdown.
            var htmlTag = GetHtmlTag(markdown);

            if (htmlTag != null)
            {
                // If the html tag is header. (h1/h2/h3/h4/h5/h6)
                if (htmlTag is HeaderTag)
                {
                    // Assign string format of header tag with inner text.
                    html = (htmlTag as HeaderTag)?.ToString();
                }
                // If the html tag is anchor tag (a)
                else if (htmlTag is AnchorTag)
                {
                    // Assign string format of anchor tag with inner text and href.
                    html = (htmlTag as AnchorTag)?.ToString();
                }
                // If the html tag is default paragraph (p)
                else
                {
                    // Assign string format of paragraph tag with inner text.
                    html = (htmlTag as ParagraphTag)?.ToString();
                }
            }

            return await Task.FromResult(html ?? string.Empty);
        }

        private IHtmlTag GetHtmlTag(string markdown)
        {
            // Default tag should be paragraph.
            IHtmlTag defaultTag = new ParagraphTag(markdown);

            switch (markdown[0])
            {
                // If the first character of the markdown is '#' then it is header tag.
                case '#':
                    // Find the count of '#' to determine the header tag.
                    int count = GetHeaderCount(markdown);

                    // If the markdown contains only '#s', default the tag to paragraph.
                    // if the count is greater than 6, default tag is paragraph.
                    // If there is no space after '#' need to consider it as a paragraph.
                    if (count == markdown.Length || count > 6 || markdown[count] != ' ' || string.IsNullOrWhiteSpace(markdown.Substring(count + 1)))
                    {
                        return defaultTag;
                    }
                    else
                    {
                        // Need to exclude the space after '#'.
                        return new HeaderTag(count, markdown.Substring(count + 1));
                    }
                // If the first character of the markdown is '[' or '(' then it is anchor tag.
                case '[':
                case '(':
                    return new AnchorTag(markdown);
                // Default tag is paragraph
                default:
                    return defaultTag;
            }
        }

        private int GetHeaderCount(string markdown)
        {
            int count;
            //Iterate through the count of '#' to determine the header tag.
            for (count = 0; count < markdown.Length; count++)
            {
                if (markdown[count] != '#')
                {
                    break;
                }
            }
            return count;
        }        
    }
}
