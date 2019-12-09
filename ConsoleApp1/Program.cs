using System;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        
        Program()
        {
            Console.WriteLine("hello world");
        }
        static void Main(string[] args)

        {
            string fileName = @"D:\ErrorLog.txt";

            if (!File.Exists(fileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    
                }
            }

            string path = @"D:\C#";
            

            MonitorDirectory(path);

            Console.ReadKey();

        }

        private static void MonitorDirectory(string path)

        {

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.IncludeSubdirectories = true;

            fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Folder changed: {0}", e.Name);
            //System.IO.File.WriteAllText(@"D:\ErrorLog.txt", e.Name);
            using (StreamWriter sw = File.AppendText(@"D:\ErrorLog.txt"))
            {
                sw.WriteLine(e.Name);
            }
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File created: {0}", e.Name);
            //System.IO.File.WriteAllText(@"D:\ErrorLog.txt", e.Name);
            using (StreamWriter sw = File.AppendText(@"D:\ErrorLog.txt"))
            {
                sw.WriteLine(e.Name);
            }

        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File renamed: {0}", e.Name);
            //System.IO.File.WriteAllText(@"D:\ErrorLog.txt", e.Name);
            using (StreamWriter sw = File.AppendText(@"D:\ErrorLog.txt"))
            {
                sw.WriteLine(e.Name);
            }

        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File deleted: {0}", e.Name);
            //System.IO.File.WriteAllText(@"D:\ErrorLog.txt", e.Name);
            using (StreamWriter sw = File.AppendText(@"D:\ErrorLog.txt"))
            {
                sw.WriteLine(e.Name);
            }

        }
    }
}
