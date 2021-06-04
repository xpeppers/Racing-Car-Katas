
using System.IO;
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverterTest
    {
        [Fact]
        public void CheckInputFileName()
        {
            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            Assert.Equal("foobar.txt", converter.GetFilename());
        }

        [Fact]
        public void ConvertFileName()
        {
            File.WriteAllText("foobar.txt", string.Empty);

            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            string result = converter.ConvertToHtml();
            Assert.Equal(string.Empty, result);
        }

    }
}
