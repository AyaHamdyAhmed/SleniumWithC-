using System;
using System.IO;

namespace FrameWork.Logging
{
    public class Logger
    {
        private readonly string _filePath;
        public Logger(string testName, string filePath)
        {
            _filePath = filePath;
            using(var log= File.CreateText(_filePath))
            {
                log.WriteLine($"Starting TimeStamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testName}");
            }
        }
        public void Info(string message)
        {
            WriteLine($"[INFO]:  {message}");
        }

        public void Step(string message)
        {
            WriteLine($"    [STEP]:  {message}");
        }
        public void Warning(string message)
        {
            WriteLine($"[WARNING]:  {message}");
        }

        public void Error(string message)
        {
            WriteLine($"[ERROR]:  {message}");
        }
        public void Fatal(string message)
        {
            WriteLine($"[FATAL]:  {message}");
        }
        private void WriteLine(string text)
        {
            using(var log= File.AppendText(_filePath))
            {
                log.WriteLine(text);
            }
        }
        private void Write(string text)
        {
            using(var log= File.AppendText(_filePath))
            {
                log.Write(text);
            }
        }
    }
}