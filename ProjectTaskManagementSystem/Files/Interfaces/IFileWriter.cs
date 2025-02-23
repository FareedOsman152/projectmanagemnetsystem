namespace ProjectTaskManagementSystem.Files.Interfaces;

internal interface IFileWriter
{
    public void writeAllLines(string folderPath, string fileName, string[] lines);
    public void updateFile(string folderPath, string fileName, string[] line);
    public void writeOneLine(string folderPath, string fileName, string line);
}
