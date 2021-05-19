using OpenQA.Selenium;
using Saucedemo.Models;

namespace Saucedemo.Services
{
    public class UserService
    {
        public static User GetUser(string name)
        {
            var neededUser = new User();
            foreach (var user in ModelService.Users)
            {
                if (user.Username.Equals(name))
                {
                    return new User
                    {
                        Username = user.Username,
                        Password = user.Password
                    };
                }
            }

            throw new NotFoundException($"User with such name {name} not found.");
        }
    }
}