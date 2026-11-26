using NUnit.Framework;
using Qase.Framework.Core.Pages;
using Qase.Framework.Core.Pages.Authentication;
using Qase.Framework.Core.Pages.Projects;
using Qase.Tests.Configuration;
using Qase.Tests.Infrastructure;

namespace Qase.Tests.UI.Projects;

[TestFixture]
public class ProjectsPageTests : UiBaseTest
{
    private ProjectsPage _projectsPage = null!;

    [SetUp]
    public void SetUp()
    {
        var loginPage = new LoginPage();

        _projectsPage = loginPage
            .EnterEmail(TestSettings.Username)
            .EnterPassword(TestSettings.Password)
            .LoginSuccessfully();
    }

    [Test]
    public void OpenCreateProjectForm()
    {
        var createProjectForm = _projectsPage.ClickCreateNewProjectBtn();

        Assert.That(createProjectForm.CreateProjectFormIsDisplayed, Is.True);
    }
}