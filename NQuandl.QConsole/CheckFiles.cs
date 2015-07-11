using System.IO;

namespace NQuandl.QConsole
{
    public static class CheckFiles
    {
        public static bool CheckIfFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}