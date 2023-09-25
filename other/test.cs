using System.IO;
using System.IO.Compression;

class Bad
{
    public static void WriteToDirectory(ZipArchiveEntry entry,
                                        string destDirectory)
    {
        // Source: The 'entry' parameter represents a file from a zip archive.
        
        // Sanitize the 'destDirectory' to ensure it's a valid directory path.
        // Avoid using user-provided input directly in path manipulation to prevent directory traversal attacks.
        // Implement proper validation and sanitization as needed.
        
        string destFileName = Path.Combine(destDirectory, entry.FullName);
        
        // Sink: The 'destFileName' variable is used to specify the output file path.

        // Extract the file to the specified destination.
        // Ensure proper error handling, especially if the destination directory can be user-provided.
        entry.ExtractToFile(destFileName);
    }
}
