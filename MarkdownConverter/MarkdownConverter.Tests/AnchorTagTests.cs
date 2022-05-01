using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkdownConverter.Tests
{
    [TestClass]
    public class AnchorTagTests
    {
        [TestMethod]
        public void ToStringShouldReturnValidAnchorHtmlWhenTheInputIsAnchorMarkdown()
        {
            var input = "[Link1](https://test.com)";
            var tag = new AnchorTag(input);
            var html = tag.ToString();
            var expected = "<a href=\"https://test.com\">Link1</a>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public void ToStringShouldReturnEmptyStringWhenTheInnerTextIsEmpty()
        {
            var tag = new AnchorTag(string.Empty);
            var html = tag.ToString();
            Assert.AreEqual(string.Empty, html);
        }
    }
}
