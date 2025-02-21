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

        return File.ReadAllLines(Path.Combine(folderPath, fileName));
    }

    public string getLastLine(string folderPath, string fileName)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        return File.ReadLines(Path.Combine(folderPath, fileName)).Last();
    }
}
