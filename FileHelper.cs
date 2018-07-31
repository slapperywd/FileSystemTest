using System;
using System.IO;

namespace FileSystemTest
{
    public class FileHelper
    {
        /// <summary>
        /// Waits until file is present in specific location
        /// </summary>
        /// <param name="filePath">path to file including file name</param>
        /// <param name="secondsTimeout">timeout</param>
        /// <returns>true if file is present</returns>
        public static bool WaitForFileDownload(string filePath, int secondsTimeout = 20)
        {
            string fileName = Path.GetFileName(filePath);

            var watcher = new FileSystemWatcher(Path.GetDirectoryName(filePath));
            watcher.Filter = fileName;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.EnableRaisingEvents = true;

            var result = watcher.WaitForChanged(
                WatcherChangeTypes.Renamed, 
                (int)TimeSpan.FromSeconds(secondsTimeout).TotalMilliseconds);
   
            if (result.TimedOut)
            {
                throw new Exception($"Download failed, timeout is {secondsTimeout} seconds, expected file name to be downloaded is {fileName}");
            }

            return true;
        }
    }
}
