namespace ProjectTaskManagementSystem.Files.Validation.Interfacec;

internal interface IFileValidator
{
    public abstract static void CheckIsFileExist(string folderPath, string fileName);
}

