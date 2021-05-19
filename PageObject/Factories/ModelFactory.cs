using System.Collections.Generic;
using PageObject.Extensions;
using PageObject.Models;
using PageObject.Services;

namespace PageObject.Factories
{
    public static class ModelFactory
    {
        public static List<Project> GetDbProjects()
        {
            DbConnectionFactory.CreateTransient("projects");
            return SqlService.ExecuteSql("select * from projects;").GetProjects();
        }
    }
}