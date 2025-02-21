namespace ProjectTaskManagementSystem.Files.Interfaces;

internal interface IFileReadre
{
    public string[] getAllLines(string folderPath, string fileName);  
    public string getLastLine(string folderPath, string fileName);      
}
