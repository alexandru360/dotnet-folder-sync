using System;
using System.IO;
using System.Reflection;

namespace dotnet_folder_sync
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (Array.IndexOf(args, "-v") > -1)
                {
                    Console.WriteLine(Assembly.GetEntryAssembly().
                        GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
                }
                else if (Array.IndexOf(args, "-h") > -1)
                {
                    Console.WriteLine(FileCopy.Help);
                }
                else if (Array.IndexOf(args, "-c") > -1 && args.Length == 3)
                {
                    if (Directory.Exists(args[1]))
                    {
                        Directory.CreateDirectory(args[2]);
                        FileCopy.Copy(args[1], args[2]);
                        Console.WriteLine("Done");
                    }
                }
                else
                {
                    Console.WriteLine(FileCopy.Help);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
