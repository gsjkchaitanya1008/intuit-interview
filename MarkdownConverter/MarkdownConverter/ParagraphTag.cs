namespace MarkdownConverter
{
    /// <summary>
    /// Represents paragraph html tag.
    /// </summary>
    public class ParagraphTag : HtmlTag
    {
        /// <inheritdoc />
        public override string TagName => "p";

        /// <inheritdoc />
        public override string InnerText { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ParagraphTag"/>
        /// </summary>
        /// <param name="innerText"></param>
        public ParagraphTag(string innerText)
        {
            InnerText = innerText;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(InnerText) ? string.Empty : $"<{TagName}>{ReplaceAnchorHtml()}</{TagName}>";
        }
    }
}
