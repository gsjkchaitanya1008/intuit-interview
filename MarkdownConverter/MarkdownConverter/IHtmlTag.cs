namespace MarkdownConverter
{
    public interface IHtmlTag
    {
        /// <summary>
        /// Gets the html tag name.
        /// </summary>
        string TagName { get; }

        /// <summary>
        /// Gets the inner text of the html tag.
        /// </summary>
        string InnerText { get; }
    }
}
