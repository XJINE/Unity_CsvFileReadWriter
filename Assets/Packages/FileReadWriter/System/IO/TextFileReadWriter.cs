using System.Text;

namespace System.IO
{
    public static class TextFileReadWriter
    {
        #region Method

        public static (string text, bool success) Write(string path, string text)
        {
            return Write(path, text, Encoding.UTF8);
        }

        public static (string text, bool success) Write(string path, string text, Encoding encoding, bool overwrite = true)
        {
            // NOTE:
            // Encoding is defined as class.

            // NOTE:
            // Use "Write", not "WriteLine".
            // Because of the line-break will be inserted.

            if (string.IsNullOrEmpty(path))
            {
                return (path + "\"path\" is null or empty.", false);
            }

            var dir = Path.GetDirectoryName(path);

            if (dir != null && Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            if (File.Exists(path) && !overwrite)
            {
                return (path + " already exists.", false);
            }

            try
            {
                using (var writer = new StreamWriter(path, false, encoding))
                {
                    writer.Write(text);
                }

                return (text, true);
            }
            catch (Exception exception)
            {
                return (exception.Message, false);
            }
        }

        public static (string text, bool success) Read(string path)
        {
            return Read(path, Encoding.UTF8);
        }

        public static (string text, bool success) Read(string path, Encoding encoding)
        {
            try
            {
                var fileInfo = new FileInfo(path);
                string text;

                using (var reader = new StreamReader(fileInfo.OpenRead(), encoding))
                {
                    text = reader.ReadToEnd();
                }

                return (text, true);
            }
            catch (Exception exception)
            {
                return (exception.Message, false);
            }
        }

        #endregion Method
    }
}