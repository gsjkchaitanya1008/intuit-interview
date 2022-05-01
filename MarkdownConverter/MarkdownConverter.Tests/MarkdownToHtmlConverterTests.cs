using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace MarkdownConverter.Tests
{
    [TestClass]
    public class MarkdownToHtmlConverterTests
    {
        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidParagraphHtmlWhenTheInputMarkdownIsParagraphMarkdown()
        {
            var input = "Sample paragraph text";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<p>Sample paragraph text</p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnH1HeaderHtmlWhenTheInputMarkdownContainsOneHashCharCount()
        {
            var input = "# Sample header";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<h1>Sample header</h1>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnParagraphHtmlWhenTheInputMarkdownContainsOneHashCharAndNoSpaceBetweenHashAndText()
        {
            var input = "#Sample header";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<p>#Sample header</p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnParagraphTagWhenTheInputMarkdownContainsOneHashCharAndTextAfterHashIsEmpty()
        {
            var input = "#";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<p>#</p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnParagraphTagWhenTheInputMarkdownContainsMoreThan6HashChars()
        {
            var input = "####### sample header";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<p>####### sample header</p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidHeaderTagWhenTheInputMarkdownContainsLessThan6HashChars()
        {
            var input = "##### sample header";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<h5>sample header</h5>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidAnchorHtmlWhenTheInputIsAnchorMarkdown()
        {
            var input = "[Link1](https://test.com)";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<a href=\"https://test.com\">Link1</a>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidHtmlWhenTheInputMarkdownIsValidParagaphWithMultipleLinks()
        {
            var input = "Sampe paragraph text [Link1](https://test.com) Sample Text 2 [Link2](https://test2.com)";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<p>Sampe paragraph text <a href=\"https://test.com\">Link1</a> Sample Text 2 <a href=\"https://test2.com\">Link2</a></p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidHtmlWhenTheInputMarkdownIsValidHeaderWithMultipleLinks()
        {
            var input = "# Sample header [Link1](https://test.com) Sample header text 2 [Link2](https://test2.com)";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<h1>Sample header <a href=\"https://test.com\">Link1</a> Sample header text 2 <a href=\"https://test2.com\">Link2</a></h1>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldReturnValidHtmlWhenTheInputMarkdownContainsMultipleLines()
        {
            var input = @"# Sample header
Sample paragraph
[Link1](https://test.com)
Paragraph with link [Link2](https://test2.com)";
            var converter = new MarkdownToHtmlConverter();
            var html = await converter.ConvertToHtml(input);
            var expected = "<h1>Sample header</h1>\r\n<p>Sample paragraph</p>\r\n<a href=\"https://test.com\">Link1</a>\r\n<p>Paragraph with link <a href=\"https://test2.com\">Link2</a></p>";
            Assert.AreEqual(expected, html);
        }

        [TestMethod]
        public async Task ConvertToHtmlShouldThrowExceptionWhenTheMarkupIsNull()
        {
            var converter = new MarkdownToHtmlConverter();
            _ = Assert.ThrowsExceptionAsync<NullReferenceException>(() => converter.ConvertToHtml(null));
        }
    }
}
