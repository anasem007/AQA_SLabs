using System;
using System.Linq;
using TestRailApi.Models.Suite;

namespace TestRailApi.Generators
{
    public static class SuiteGenerator
    {
        public static SuiteRequestModel GetSuite(string name)
        {
            foreach (var suite in TestData.Suites.Where(suite => suite.Name == name))
            {
                return suite;
            }

            throw new Exception();
        }
        
        public static SuiteRequestModel GetSuiteWithoutName(string name)
        {
            var suite = GetSuite(name);
            
            return new SuiteRequestModel
            {
                Description = suite.Description
            };
        }
        
        public static SuiteRequestModel GetSuiteWithoutDescription(string name)
        {
            var suite = GetSuite(name);
            
            return new SuiteRequestModel
            {
                Name = suite.Name
            };
        }
    }
}