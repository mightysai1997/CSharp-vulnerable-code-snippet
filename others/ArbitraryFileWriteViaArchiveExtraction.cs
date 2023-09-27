using System;
using System.IO;
using System.IO.Compression;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Path of Zip File to extract:");
            string zipPath = Console.ReadLine();
            
            Console.WriteLine("Enter Path of Destination Folder:");
            string extractPath = Console.ReadLine();

            if (File.Exists(zipPath) && Directory.Exists(extractPath))
            {
                try
                {
                    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), true);
                            Console.WriteLine($"Extracted: {entry.FullName}");
                        }
                    }
                    Console.WriteLine("Extraction completed successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid file or directory path.");
            }
        }
    }
}
