using System.IO;

namespace FileSystemNotifier_Lib
{
    public class FileFixatorService
    {
        private string _path;
        private static object _locker = new object();
        public FileFixatorService(string path)
        {
            _path = path;
        }

        public void Fixate(string line)
        {
            lock (_locker)
            {
                using (StreamWriter file = File.AppendText(_path))
                {
                    file.WriteLine(line);
                }
            }
        }

    }
}
