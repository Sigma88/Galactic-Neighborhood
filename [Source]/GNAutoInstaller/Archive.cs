using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;


namespace GNAutoInstallerPlugin
{
    internal static class Archive
    {
        internal static void UnZip(string archive, string find, string destination, string[] filter = null)
        {
            if (!File.Exists(archive))
            {
                return;
            }

            ZipInputStream mod = new ZipInputStream(File.OpenRead(archive));

            ZipEntry theEntry;

            while ((theEntry = mod.GetNextEntry()) != null)
            {
                string path = theEntry.Name;

                if (path.Valid(filter) && path.StartsWith(find))
                {
                    path = destination + path.Substring(find.Length);

                    string directoryName = Path.GetDirectoryName(path);
                    string fileName = Path.GetFileName(path);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(path))
                        {
                            int size = 2048;
                            byte[] data = new byte[size];

                            while (true)
                            {
                                size = mod.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        static bool Valid(this string path, string[] filter)
        {
            for (int i = 0; i < filter?.Length; i++)
            {
                if (path.StartsWith(filter[i]))
                    return false;
            }

            return true;
        }
    }
}
