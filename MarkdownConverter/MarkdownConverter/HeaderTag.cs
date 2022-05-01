namespace MarkdownConverter
{
    /// <summary>
    /// Represent header html tag.
    /// </summary>
    public class HeaderTag : HtmlTag
    {
        /// <inheritdoc />
        public override string TagName { get; } = "h";

        /// <inheritdoc />
        public override string InnerText { get; set; }

        /// <summary>
        /// Gets or sets the count to determine the header tag.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="HeaderTag"/>
        /// </summary>
        /// <param name="count">Count to determine the header tag.</param>
        /// <param name="innerText">Inner text of the header tag.</param>
        public HeaderTag(int count, string innerText)
        {
            Count = count;
            TagName = $"{TagName}{count}";
            InnerText = innerText;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(InnerText) ? string.Empty : $"<{TagName}>{ReplaceAnchorHtml()}</{TagName}>";
        }
    }
}
