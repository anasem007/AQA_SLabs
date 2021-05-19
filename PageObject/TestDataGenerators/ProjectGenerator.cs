using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using PageObject.Factories;
using PageObject.Models;

namespace PageObject.TestDataGenerators
{
    public class ProjectGenerator
    {
        private readonly List<Project> _projects;

        public ProjectGenerator()
        {
            _projects = ModelFactory.GetDbProjects();
        }

        public Project GetProjectByName(string name)
        {
            foreach (var project in _projects.Where(project => project.Name == name))
            {
                return project;
            }
            throw new NotFoundException();
        }
    }
}