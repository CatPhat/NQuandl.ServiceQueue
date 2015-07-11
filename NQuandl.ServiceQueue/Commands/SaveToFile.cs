using System.IO;
using System.Threading.Tasks;
using NQuandl.ServiceQueue.Api;

namespace NQuandl.ServiceQueue.Commands
{
    public class SaveToFile : IDefineCommand
    {
        public SaveToFile(string filePath, string fileName, string fileContent)
        {
            FileName = fileName;
            FilePath = filePath;
            FileContent = fileContent;
        }

        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileContent { get; private set; }
    }

    public class HandleSaveToFile : IHandleCommand<SaveToFile>
    {
        public Task Handle(SaveToFile command)
        {
            var filePath = Path.Combine(command.FilePath, command.FileName);
            File.WriteAllText(filePath, command.FileContent);
            return Task.FromResult(0);
        }
    }
}