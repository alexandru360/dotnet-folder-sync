using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace dotnet_folder_sync
{
    public static class FileCopy
    {
        public static bool Copy(string sourceDirectory, string targetDirectory)
        {
            var success = true;
            try
            {
                var src = sourceDirectory;
                var dest = targetDirectory;
                var cmp = CompressionLevel.NoCompression;
                var zip = sourceDirectory + ".zip";
                ZipFile.CreateFromDirectory(src, zip, cmp, includeBaseDirectory: false);
                ZipFile.ExtractToDirectory(zip, dest);

                File.Delete(zip);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }
            return success;
        }

        static public bool IsValidPath(string path)
        {
            Regex r = new Regex(@"^(([a-zA-Z]:)|(\))(\{1}|((\{1})[^\]([^/:*?<>""|]*))+)$");
            return r.IsMatch(path);
        }

        public static string CopyHelp = @"
                    -c      'folder-source' 'folder-destination'
                            program usage: dotnet_folder_sync.exe -c 'folder-source' 'folder-destination'
                            makes a zip and overrites the destination
                ";

        public static string Help = @$"
                    -h      this help

                    -v      version
                    
                    {CopyHelp}
                ";

    }
}
