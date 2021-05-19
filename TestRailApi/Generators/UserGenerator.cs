using System;
using System.Linq;
using TestRailApi.Models.User;

namespace TestRailApi.Generators
{
    public static class UserGenerator
    {
        public static User GetUser(string id)
        {
            foreach (var user in TestData.Users.Where(user => user.Id == id))
            {
                return user;
            }

            throw new Exception();
        }
    }
}