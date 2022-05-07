using System;
using System.IO;

namespace FileUploader.Services.Tests.Utils;

public static class FileManager
{
    public static Stream Load(string path)
    {
        if (!File.Exists(path))
            throw new Exception("File not found");

        return File.OpenRead(path);
    }
}