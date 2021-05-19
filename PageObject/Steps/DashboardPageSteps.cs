using OpenQA.Selenium;
using PageObject.BaseEntities;
using PageObject.Pages;

namespace PageObject.Steps
{
    public class DashboardPageSteps : BaseStep
    {
        private DashboardPage _dashboardPage;
        
        public DashboardPageSteps(IWebDriver driver) : base(driver)
        {
            _dashboardPage = new DashboardPage(Driver);
        }

        public bool SelectUserDropdown()
        {
            _dashboardPage.UserDropdownButton.Click();
            return _dashboardPage.UserDropdown.Displayed;
        }
        
        public bool SelectHelpDropdown()
        {
            _dashboardPage.HelpDropdownButton.Click();
            return _dashboardPage.HelpDropdown.Displayed;
        }
        
        public bool SelectInProgressDropdown()
        {
            _dashboardPage.InProgressDropdownButton.Click();
            return _dashboardPage.InProgressDropdown.Displayed;
        }

        public void SelectOptionInUserDropdownByText(string text)
        {
            _dashboardPage.UserDropdown.SelectByText(text);
        }
        
        public void SelectOptionInHelpDropdownByText(string text)
        {
            _dashboardPage.HelpDropdown.SelectByText(text);
        }
        
        public string GetTextInProgressDropdown()
        {
            return  _dashboardPage.InProgressDropdown.Text;
        }
    }
}