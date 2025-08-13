using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.Files.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.Files;
internal class FileReader : IFileReadre
{  
    public string[] getAllLines(string folderPath, string fileName)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);

        FileValidator.CheckIsFileExist(folderPath, fileName);

        if (new FileInfo(Path.Combine(folderPath, fileName)).Length == 0)
            return Array.Empty<string>();

        return File.ReadAllLines(Path.Combine(folderPath, fileName));
    }

    public string getLastLine(string folderPath, string fileName)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);
        if (new FileInfo(Path.Combine(folderPath, fileName)).Length == 0)
            return "";

        return File.ReadLines(Path.Combine(folderPath, fileName)).Last();
    }
}
