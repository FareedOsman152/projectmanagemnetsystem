using ProjectTaskManagementSystem.Files.Validation.Interfacec;

namespace ProjectTaskManagementSystem.Files.Validation;

internal class DirectorValidator : IDirectorValidator
{
    public static void CheckIsDirectorExist(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            throw new Exception("Directory not found");
        }
    }    
}


