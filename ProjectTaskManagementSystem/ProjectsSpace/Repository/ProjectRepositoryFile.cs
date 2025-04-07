using ProjectTaskManagementSystem.Files.Interfaces;
using ProjectTaskManagementSystem.Files.ObjectsConverter;
using ProjectTaskManagementSystem.ProjectsSpace.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Repository;

class ProjectRepositoryFile : IProjectRepository
{
    IFileReadre _reader;
    IFileWriter _writer;
    IConvertor<Project> _converter;
    string _fileName;
    string _folderPath;

    public ProjectRepositoryFile(string folderPath, string fileName, IFileReadre reader, IFileWriter writer,
        IConvertor<Project> converter)
    {
        _reader = reader;
        _writer = writer;
        _converter = converter;
        _folderPath = folderPath;
        _fileName = fileName;
    }

    public void Add(Project project)
    {
        string projectString = _converter.ToString(project);
        _writer.writeOneLine(_folderPath,_fileName, projectString);
    }

    public void Delete(Project project)
    {
        var projectsStrings = _reader.getAllLines(_folderPath, _fileName);
        var projectsAfterDeleted = _converter.ToObjs(projectsStrings).Where(p=>p.ID!=project.ID);
        var projectsAfterDeletedStrings = _converter.ToStrings(projectsAfterDeleted);
        _writer.updateFile(_folderPath, _fileName, projectsAfterDeletedStrings);
    }

    public IEnumerable<Project> GetAll() => _converter.ToObjs(_reader.getAllLines(_folderPath, _fileName));

    public Project? GetById(int Id) 
        => _converter.ToObjs(_reader.getAllLines(_folderPath, _fileName)).FirstOrDefault(p => int.Parse(p.ID) == Id);

    public void Update(Project project)
    {
        var projectsAfterUpdated = _converter.ToObjs(_reader.getAllLines(_folderPath, _fileName)).Select(p =>
        {
            if (p.ID == project.ID)
                return project;
            else return p;
        });
        var projectsAfterUpatedStrings = _converter.ToStrings(projectsAfterUpdated);
        _writer.updateFile(_folderPath, _fileName, projectsAfterUpatedStrings);
    }    
}
