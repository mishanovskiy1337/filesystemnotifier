using System.IO;

namespace FileSystemNotifier_Lib
{
    public interface IApplicationLogger
    {
        void Write(string data);
    }

    public class ScanningResultsLogger : IApplicationLogger
    {
        private string _path;

        public ScanningResultsLogger(string path)
        {
            _path = path;
        }

        public void Write(string data)
        {
            using (StreamWriter file = File.AppendText(_path))
            {
                file.WriteLine(data);
            }
        }
    }

    public class ExceptionLogger : IApplicationLogger
    {
        public void Write(string data)
        {
            
        }
    }
}
