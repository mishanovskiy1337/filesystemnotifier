using System.IO;

namespace FileSystemNotifier_Lib
{
    public interface IApplicationLogger
    {
        void Write(string data);
    }

    /// <summary>
    /// To write all the collected data into the text file
    /// </summary>
    public class ScanningResultsLogger : IApplicationLogger
    {
        private string _path;

        public ScanningResultsLogger(string path)
        {
            _path = path;
        }

        public void SetLogFile(string path)
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

    /// <summary>
    /// To write all the exceptions data into the text file
    /// </summary>
    public class ExceptionLogger : IApplicationLogger
    {
        public void Write(string data)
        {
            
        }
    }
}
