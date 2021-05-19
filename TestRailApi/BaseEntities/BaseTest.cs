using NUnit.Framework;


namespace TestRailApi.BaseEntities
{
    public class BaseTest
    {
        protected string ProjectId =  "";
        protected string SuiteId = "";
        protected const int FakeProjectId = int.MaxValue;
        protected const string InvalidId = "id";
        
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }
        
    }
}
