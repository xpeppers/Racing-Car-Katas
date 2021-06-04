
using System;
using System.IO;
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        [Fact]
        public void Check_Exception_With_An_Empty_String()
        {
            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter(string.Empty);
            Assert.Throws< ArgumentException>(() => converter.ConvertToHtml());
        }

        [Fact]
        public void Check_Reading_File()
        {
            string path = "D:\\Temp\\TestFile.txt";
            File.WriteAllText(path, "Ciao siamo i solidiBolidi");

            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter(path);
            string html = converter.ConvertToHtml();

            Assert.Equal("Ciao siamo i solidiBolidi<br />", html);
        }
    }
}
