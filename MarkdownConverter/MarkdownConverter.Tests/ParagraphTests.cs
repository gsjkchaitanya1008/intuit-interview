using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkdownConverter.Tests
{
    [TestClass]
    public class ParagraphTests
    {
        [TestMethod]
        public void ToStringShouldReturnValidParagraphHtmlWhenTheInputIsParagraphMarkdown()
        {
            var input = "Sample paragraph text";
            var tag = new ParagraphTag(input);
            var paragraphHtml = tag.ToString();
            var expected = "<p>Sample paragraph text</p>";
            Assert.AreEqual(expected, paragraphHtml);
        }

        [TestMethod]
        public void ToStringShouldReturnValidParagraphHtmlWhenTheInputIsParagraphMarkdownAndContainsAnchorMarkdown()
        {
            var input = "Sampe paragraph text [Link1](https://test.com)";
            var tag = new ParagraphTag(input);
            var paragraphHtml = tag.ToString();
            var expected = "<p>Sampe paragraph text <a href=\"https://test.com\">Link1</a></p>";
            Assert.AreEqual(expected, paragraphHtml);
        }

        [TestMethod]
        public void ToStringShouldReturnValidParagraphHtmlWhenTheInputIsParagraphMarkdownAndContainsMoreThanOneAnchorMarkdown()
        {
            var input = "Sampe paragraph text [Link1](https://test.com) Sample Text 2 [Link2](https://test2.com)";
            var tag = new ParagraphTag(input);
            var paragraphHtml = tag.ToString();
            var expected = "<p>Sampe paragraph text <a href=\"https://test.com\">Link1</a> Sample Text 2 <a href=\"https://test2.com\">Link2</a></p>";
            Assert.AreEqual(expected, paragraphHtml);
        }

        [TestMethod]
        public void ToStringShouldReturnEmptyWhenTheInputIsEmpty()
        {
            var input = string.Empty;
            var tag = new ParagraphTag(input);
            var paragraphHtml = tag.ToString();
            Assert.AreEqual(string.Empty, paragraphHtml);
        }

        [TestMethod]
        public void ToStringShouldReturnEmptyWhenTheInputIsNull()
        {
            string input = null;
            var tag = new ParagraphTag(input);
            var paragraphHtml = tag.ToString();
            Assert.AreEqual(string.Empty, paragraphHtml);
        }
    }
}
