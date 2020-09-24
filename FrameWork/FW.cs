using System;
using System.IO;
using FrameWork.Logging;
using NUnit.Framework;

namespace FrameWork
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY= Path.GetFullPath(@"../../../../");
        public static Logger log => _logger ?? throw new NullReferenceException("_logger is NULL please setLogger() first");
        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;
        [ThreadStatic]
        private static Logger _logger;
        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var TestDirectory = WORKSPACE_DIRECTORY + "TestResults";
            if(Directory.Exists(TestDirectory))
            {
                Directory.Delete(TestDirectory, recursive: true);
            }
            return Directory.CreateDirectory(TestDirectory);
        }
        public static void setLogger()
        {

            lock(_setLoggerLock)
            {
                var testResultsDir = WORKSPACE_DIRECTORY + "TestResults";
                var testName= TestContext.CurrentContext.Test.Name;
                var fullPath= $"{testResultsDir}/{testName}";
                if(Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }
                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }
        }
        public static object _setLoggerLock = new object();
    }
}