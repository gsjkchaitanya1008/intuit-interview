using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MarkdownConverter.Tests
{
    [TestClass]
    public class HeaderTagTests
    {
        [TestMethod]
        public void ToStringShouldReturnH1HeaderTagWhenTheInputContainsOneHashCharCount()
        {
            var tag = new HeaderTag(1, "sample header");
            var html = tag.ToString();
            var expected = "<h1>sample header</h1>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public void ToStringShouldReturnValidHeaderTagWhenTheInputContainsMoreThanOneAndValidHashCharCount()
        {
            var tag = new HeaderTag(6, "sample header");
            var html = tag.ToString();
            var expected = "<h6>sample header</h6>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public void ToStringShouldReturnValidHeaderHtmlWhenTheInputIsHeaderMarkdownAndContainsAnchorMarkdown()
        {
            var tag = new HeaderTag(1, "Sample header [Link1](https://test.com)");
            var html = tag.ToString();
            var expected = "<h1>Sample header <a href=\"https://test.com\">Link1</a></h1>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public void ToStringShouldReturnValidHeaderHtmlWhenTheInputIsHeaderMarkdownAndContainsMoreThanOneAnchorMarkdown()
        {
            var tag = new HeaderTag(1, "Sample header [Link1](https://test.com) Sample header text 2 [Link2](https://test2.com)");
            var html = tag.ToString();
            var expected = "<h1>Sample header <a href=\"https://test.com\">Link1</a> Sample header text 2 <a href=\"https://test2.com\">Link2</a></h1>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public void ToStringShouldReturnEmptyWhenTheInputIsEmpty()
        {
            var tag = new HeaderTag(3, string.Empty);
            var html = tag.ToString();
            Assert.AreEqual(string.Empty, html);
        }

        [TestMethod]
        public void ToStringShouldReturnEmptyWhenTheInputIsNull()
        {
            var tag = new HeaderTag(3, null);
            var html = tag.ToString();
            Assert.AreEqual(string.Empty, html);
        }
    }
}
