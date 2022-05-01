using System.Text.RegularExpressions;

namespace MarkdownConverter
{
    /// <summary>
    /// Represents anchor html tag.
    /// </summary>
    public class AnchorTag : IHtmlTag
    {
        /// <summary>
        /// Anchor tag regex pattern.
        /// </summary>
        private const string anchorTagPattern = @"\[([^\]]+)\]\(([^\)]+)\)";

        /// <summary>
        /// Anchor tag format.
        /// </summary>
        private const string anchorTagFormat = "<a href=\"{1}\">{0}</a>";

        /// <inheritdoc />
        public string TagName => "a";

        /// <inheritdoc />
        public string InnerText { get; private set; }

        /// <summary>
        /// Intitializes a new instance of <see cref="AnchorTag"/>
        /// </summary>
        /// <param name="innerText">Inner text of an anchor tag.</param>
        public AnchorTag(string innerText)
        {
            InnerText = innerText;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(InnerText))
            {
                return string.Empty;
            }

            return Regex.Replace(InnerText, anchorTagPattern, match => string.Format(anchorTagFormat, match.Groups[1].Value, match.Groups[2].Value));
        }
    }
}
