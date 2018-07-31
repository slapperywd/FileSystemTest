using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\FilesTest\test.txt";
            string moveToFolder = @"D:\FilesTest\FolderToMoveFilesTo\";
            string fileName = "Harbinger F And G LLC v OM Group (UK) Ltd.doc";

            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            var fi = new FileInfo(filePath);
            Console.WriteLine(fi.Exists);
            Console.WriteLine(fi.Name);
            Console.WriteLine(fi.CreationTime);
     
           // fi.CopyTo(moveToFolder + "test.txt");
            Console.WriteLine(FileHelper.WaitForFileDownload(Path.Combine(downloadsFolder, fileName)));
           // Console.ReadKey();
        }

        
    }
}
