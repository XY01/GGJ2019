using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EXPToolkit
{
    public static class FileUtils
    {
        // Search patterns "*.jpg"    "*.*"  
        public static string[] GetFiles(string filePath, string searchPattern, int numberOfFiles, bool includePath, bool dateAscending)
        {
            if (!filePath.EndsWith("\\"))
            { filePath += "\\"; }
            List<string> foundFiles = new List<string>();

            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            FileInfo[] files = null;

            if (dateAscending)
            {
                files = dirInfo.GetFiles(searchPattern).OrderBy(p => p.CreationTime).ToArray();
            }
            else
            {
                files = dirInfo.GetFiles(searchPattern).OrderByDescending(p => p.CreationTime).ToArray();
            }

            if (files != null)
            {
                int fileCount = 0;
                foreach (FileInfo fi in files)
                {
                    if (includePath)
                    {
                        foundFiles.Add(fi.FullName);
                    }
                    else
                    {
                        foundFiles.Add(fi.FullName.Replace(filePath, ""));
                    }
                    fileCount++;
                    if (fileCount >= numberOfFiles) break;
                }
            }
            return foundFiles.ToArray();
        }

        public static string[] GetFiles(string filePath, string searchPattern, bool includePath)
        {
            if (!filePath.EndsWith("\\"))
            { filePath += "\\"; }
            List<string> foundFiles = new List<string>();

            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            FileInfo[] files = null;

            files = dirInfo.GetFiles(searchPattern).OrderByDescending(p => p.CreationTime).ToArray();

            if (files != null)
            {
                int fileCount = 0;
                foreach (FileInfo fi in files)
                {
                    if (includePath)
                    {
                        foundFiles.Add(fi.FullName);
                    }
                    else
                    {
                        foundFiles.Add(fi.FullName.Replace(filePath, ""));
                    }
                    fileCount++;
                }
            }

            return foundFiles.ToArray();
        }
    }
}