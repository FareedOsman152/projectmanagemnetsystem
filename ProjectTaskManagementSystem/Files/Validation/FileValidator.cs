using ProjectTaskManagementSystem.Files.Validation.Interfacec;

namespace ProjectTaskManagementSystem.Files.Validation;

internal class FileValidator : IFileValidator
{
    public static void CheckIsFileExist(string folderPath, string fileName)
    {
        if (!File.Exists(Path.Combine(folderPath, fileName)))
        {
            throw new Exception("File not found");
        }
    }
}


