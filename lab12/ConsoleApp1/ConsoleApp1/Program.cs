using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Linq;

namespace lab12
{
    public static class CNMLog
    {
        public static void WriteInTXT(string message)
        {
            using (var streamWrite = new StreamWriter(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt", true))
            {
                streamWrite.WriteLine($"{DateTime.Now.ToString()}\n{message}\n------------------------------");
            }
        }
        //public static void ReadFromTXT()
        //{
        //    using (var streamRead = new StreamReader(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt", true))
        //    {
        //        string? text = streamRead.ReadLine();
        //        Console.WriteLine(text);
        //    }
        //}
        //public static void Search(string message)
        //{
        //    using (var streamRead = new StreamReader(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt", true))
        //    {
        //        string? text = streamRead.ReadToEnd();
        //        if(text.Contains(message))
        //        {
        //            Console.WriteLine("Фрагмент найден");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Фрагмент не найден");
        //        }
        //    }
        //}
    }
    public static class CNMDiskInfo
    {
        public static event Action<string>? OnUpdate;
        public static void ShowFreeSpace(string driveName)
        {
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            Console.WriteLine($"Free space on the disk {currentDrive.Name} - {currentDrive.AvailableFreeSpace} bytes ");
            OnUpdate($"Free space on the disk {currentDrive.Name} - {currentDrive.AvailableFreeSpace} bytes ");
        }
        public static void ShowFileSystemInfo(string driveName)
        {
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            Console.WriteLine($"File system type and drive format of  {driveName} : {currentDrive.DriveType}, {currentDrive.DriveFormat}");
            OnUpdate($"File system type and drive format of  {driveName} : {currentDrive.DriveType}, {currentDrive.DriveFormat}");
        }
        public static void ShowAllDrivesInfo()
        {
            var message = new StringBuilder("All drives information : \n");
            Console.WriteLine("[");
            message.AppendFormat("[\n");
            foreach (var currentDrive in DriveInfo.GetDrives())
            {
                if (currentDrive.IsReady == false)
                    continue;

                Console.WriteLine(
                    $"Name - {currentDrive.Name},Total size - {currentDrive.TotalSize},Free space - {currentDrive.AvailableFreeSpace} , Volume label - {currentDrive.VolumeLabel}");

                message.AppendFormat(
                    $"Name - {currentDrive.Name},Total size - {currentDrive.TotalSize},Free space - {currentDrive.AvailableFreeSpace} , Volume label - {currentDrive.VolumeLabel}]\n");
            }

            Console.WriteLine("]");
            message.AppendFormat("]\n");
            OnUpdate(message.ToString());
        }
    }
    public class CNMFileInfo
    {
        public static event Action<string>? OnUpdate;

        public static void ShowFullPath(string path)
        {
            var currentFile = new FileInfo(path);

            Console.WriteLine($"Full path to the {currentFile.Name} - {currentFile.FullName}");
            OnUpdate($"Full path to the {currentFile.Name} - {currentFile.FullName}");
        }

        public static void ShowFileInfo(string path)
        {
            var currentFile = new FileInfo(path);

            Console.WriteLine($"[\nFile name: {currentFile.Name}\nSize: {currentFile.Length} bytes\nРасширение: {currentFile.Extension}\n]");

            OnUpdate($"[\nFile name: {currentFile.Name}\nSize: {currentFile.Length} bytes\nFile extension: {currentFile.Extension}\n]\n");
        }

        public static void ShowFileDates(string path)
        {
            var currentFile = new FileInfo(path);
            Console.WriteLine(
                $"File {currentFile.Name} : date of creation - {currentFile.CreationTime}, date of last edit - {currentFile.LastWriteTime}");
            OnUpdate($"File {currentFile.Name} : date of creation - {currentFile.CreationTime}, date of last edit - {currentFile.LastWriteTime}");
        }
    }
    public static class CNMDirInfo
    {
        public static event Action<string>? OnUpdate;

        public static void ShowNumberOfFiles(string path)
        {
            Console.WriteLine($"The number of files - {Directory.GetFiles(path).Length}");
            OnUpdate($"The number of files - {Directory.GetFiles(path).Length}");
        }

        public static void ShowCreationTime(string path)
        {
            Console.WriteLine($"Time of the directory creation - {Directory.GetCreationTime(path)}");
            OnUpdate($"Time of the directory creation - {Directory.GetCreationTime(path)}");
        }

        public static void ShowNumberOfSubdirectories(string path)
        {
            Console.WriteLine($"Number of subdirectories - {Directory.GetDirectories(path).Length}");
            OnUpdate($"Number of subdirectories - {Directory.GetDirectories(path).Length}");
        }

        public static void ShowParentDirectory(string path)
        {
            Console.WriteLine($"Parent Directory - {Directory.GetParent(path)}");
            OnUpdate($"Parent Directory - {Directory.GetParent(path)}");
        }
    }
    public class CNMFileManager
    {
        public static event Action<string>? OnUpdate;

        public static void InspectDrive(string driveName)
        {
            Directory.CreateDirectory(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory");

            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            OnUpdate($"File manager has inspected {currentDrive.Name}");

            File.Create(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory\\CNMdirInfo.txt").Close();

            using (var streamWriter = new StreamWriter(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory\\CNMdirInfo.txt"))
            {
                streamWriter.WriteLine("|Directories| [");
                foreach (var directoryInfo in currentDrive.RootDirectory.GetDirectories()) streamWriter.WriteLine(directoryInfo.Name);
                streamWriter.WriteLine("]");

                streamWriter.WriteLine("|Files| [");
                foreach (var fileInfo in currentDrive.RootDirectory.GetFiles()) streamWriter.WriteLine(fileInfo.Name);
                streamWriter.WriteLine("]");
            }

            File.Copy(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory\\CNMdirInfo.txt",
                @"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory\\CNMdirInfoCopy.txt", true);
            File.Delete(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMNewDirectory\\CNMdirInfo.txt");
        }

        public static void CopyFiles(string path, string extension)
        {
            OnUpdate($"File manager has copied {extension} files from {path}");

            var directory = new DirectoryInfo(path);
            Directory.CreateDirectory(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMFiles");
            Directory.CreateDirectory(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMInspect\\CNMFiles");

            foreach (var file in directory.GetFiles())
                if (file.Extension == extension)
                    file.CopyTo($@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMFiles\\{file.Name}", true);
            Directory.Delete($@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMInspect\\CNMFiles", true);
            Directory.Move($@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMFiles\\",
                $@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMInspect\\CNMFiles");
        }

        public static void Archive(string pathFrom, string pathTo)
        {
            OnUpdate($"File manager has archived files from {pathFrom} and unarchived");
            Directory.CreateDirectory(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\Unarchivetest");

            //Directory.Delete(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\UnarchiveFiles\\", true);

            if (!File.Exists($@"{pathFrom}.zip"))
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");

            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo);
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CNMDiskInfo.OnUpdate += CNMLog.WriteInTXT;
            CNMFileInfo.OnUpdate += CNMLog.WriteInTXT;
            CNMDirInfo.OnUpdate += CNMLog.WriteInTXT;
            CNMFileManager.OnUpdate += CNMLog.WriteInTXT;

            CNMDiskInfo.ShowFreeSpace(@"C:\");
            CNMDiskInfo.ShowFileSystemInfo(@"C:\");
            CNMDiskInfo.ShowAllDrivesInfo();

            CNMFileInfo.ShowFullPath(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt");
            CNMFileInfo.ShowFileInfo(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt");
            CNMFileInfo.ShowFileDates(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt");

            CNMDirInfo.ShowCreationTime(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР");
            CNMDirInfo.ShowNumberOfFiles(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР");
            CNMDirInfo.ShowNumberOfSubdirectories(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР");
            CNMDirInfo.ShowParentDirectory(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР");
            
            CNMFileManager.InspectDrive(@"C:\");
            CNMFileManager.CopyFiles(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\", ".cs");
            CNMFileManager.Archive(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMInspect",
                @"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\Unarchivetest");
            FindInfo();

        }
        public static void FindInfo()
        {
            var output = new StringBuilder();

            using (var stream = new StreamReader(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt"))
            {
                var textline = "";
                var isActual = false;
                while (stream.EndOfStream == false)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += "\n";
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "------------------------------")
                    {
                        if (isActual)
                        {
                            textline += "\n";
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual) output.AppendFormat("------------------------------\n");
                }
            }

            using (var stream = new StreamWriter(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab12\\ConsoleApp1\\ConsoleApp1\\CNMLog.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}