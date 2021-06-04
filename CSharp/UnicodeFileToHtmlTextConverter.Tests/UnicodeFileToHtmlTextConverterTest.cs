
using System;
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
    }
}
