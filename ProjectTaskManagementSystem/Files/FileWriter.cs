using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.Files.Validation;

namespace ProjectTaskManagementSystem.Files;
/// <summary>
/// Write to a file.text
/// </summary>
internal class FileWriter :  IFileWriter
{   
    public void writeOneLine(string folderPath, string fileName, string line)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        File.AppendAllText(Path.Combine(folderPath, fileName), line+Environment.NewLine);
    }  
    public void writeAllLines(string folderPath, string fileName, string[] lines)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        File.AppendAllLines(Path.Combine(folderPath, fileName), lines);
    }
}
