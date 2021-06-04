
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



    }
}
