using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages.Projects;

public class ProjectPage : LoadablePage
{
    private static readonly By ProjectHeader = By.CssSelector("h1.ByXYSI");

    public ProjectPage() : base(ProjectHeader)
    {
    }

    public bool IsProjectUrlCorrect(string projectCode)
    {
        var expectedPath = $"/project/{projectCode}";

        return Wait.Until(driver =>
        {
            var currentPath = new Uri(driver.Url).AbsolutePath.TrimEnd('/');
            return currentPath.Equals(expectedPath, StringComparison.OrdinalIgnoreCase);
        });
    }

    public bool IsProjectHeaderCorrect(string projectCode)
    {
        var header = FindVisibleElement(ProjectHeader);
        return header.Text.Contains(projectCode);
    }
}