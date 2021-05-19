using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Saucedemo.Models;

namespace Saucedemo.Services
{
    public static class ModelService
    {
        private const string UsersFileName = "users";

        public static IEnumerable<User> Users => GenerateModels<User>(UsersFileName);
        private static List<T> GenerateModels<T>(string name)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = Path.Combine(basePath ?? string.Empty, $"TestData{Path.DirectorySeparatorChar}", $@"{name}.json");

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            var jsonStream = File.ReadAllText(fullPathToFile);
            
            return JsonSerializer.Deserialize<List<T>>(jsonStream);
        }
    }
}