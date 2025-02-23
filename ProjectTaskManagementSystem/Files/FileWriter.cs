using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.Files.Validation;

namespace ProjectTaskManagementSystem.Files;
/// <summary>
/// Write to a file.text
/// </summary>
internal class FileWriter : IFileWriter
{
    public void writeOneLine(string folderPath, string fileName, string line)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, fileName), true))
        {
            writer.WriteLine(line);
        }
    }
    public void writeAllLines(string folderPath, string fileName, IEnumerable<string> lines)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        File.AppendAllLines(Path.Combine(folderPath, fileName), lines);
    }
    public void updateFile(string folderPath, string fileName, IEnumerable<string> lines)
    {
        DirectorValidator.CheckIsDirectorExist(folderPath);
        FileValidator.CheckIsFileExist(folderPath, fileName);

        using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, fileName), false))
        {
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }

}
