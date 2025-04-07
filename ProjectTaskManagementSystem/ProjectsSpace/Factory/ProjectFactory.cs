using ProjectTaskManagementSystem.Files;
using ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Factory;


class ProjectFactory
{
    private readonly IProjectVliadtor _validator;
    private readonly IGetLastID _getLastId;

    public ProjectFactory(IProjectVliadtor validator, IGetLastID getLastId)
    {
        _validator = validator;
        _getLastId = getLastId;
    }

    private void Chick(string tilte,string discription)
    { 
        if(!_validator.IsTilteValid(tilte))
        {
            throw new Exception("Title Is Not Valied");
        }
        if (!_validator.IsTilteValid(discription))
        {
            throw new Exception("Discription Is Not Valied");
        }
    }

    public Project CreateNewProject(string ownerID, string title, string description, enStatus status)
    {
        Chick(title, description);
        string iD = (_getLastId.LastUniqueID()+1).ToString();
        return new Project(iD, ownerID, title, description, DateTime.Now, status);
    }
}

