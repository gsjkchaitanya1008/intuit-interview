namespace MarkdownConverter
{
    public abstract class HtmlTag : IHtmlTag
    {
        public abstract string TagName { get; }

        public abstract string InnerText { get; set; }

        public string ReplaceAnchorHtml()
        {
            if(string.IsNullOrWhiteSpace(InnerText))
            {
                return string.Empty;
            }

            var anchorTag = new AnchorTag(InnerText);
            return anchorTag.ToString();
        }
    }
}
