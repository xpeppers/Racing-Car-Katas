using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private string _fullFilenameWithPath;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public string GetFilename()
        {
            return _fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = File.OpenText(_fullFilenameWithPath))
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }

        public string ConvertToHtmlWithLineReader()
        {
            ILineReader reader = new FileLineReader(_fullFilenameWithPath);
            using (TextReader unicodeFileStream = File.OpenText(_fullFilenameWithPath))
            {
                string html = string.Empty;

                string line = reader.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = reader.ReadLine();
                }

                return html;
            }
        }
    }

    internal class FileLineReader : ILineReader
    {
        private string fullFilenameWithPath;

        public FileLineReader(string fullFilenameWithPath)
        {
            this.fullFilenameWithPath = fullFilenameWithPath;
        }

        public string ReadLine()
        {
            throw new System.NotImplementedException();
        }
    }

    internal interface ILineReader
    {
        string ReadLine();
    }

    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}
