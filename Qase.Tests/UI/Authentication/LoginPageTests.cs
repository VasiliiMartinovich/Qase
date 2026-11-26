using NUnit.Framework;
using Qase.Tests.Infrastructure;
using Qase.Tests.Configuration;
using Qase.Framework.Core.Pages.Authentication;

namespace Qase.Tests;

[TestFixture]
public class LoginPageTests : UiBaseTest
{
    [Test]
    public void SuccessLogin()
    {
        var loginPage = new LoginPage();
        var projectsPage = loginPage
            .EnterEmail(TestSettings.Username)
            .EnterPassword(TestSettings.Password)
            .LoginSuccessfully();
        Assert.That(projectsPage.IsDisplayed(), Is.True);
    }
    
    [Test]
    public void LoginWithInvalidPassword()
    {
        var loginPage = new LoginPage();
        var projectsPage = loginPage
            .EnterEmail(TestSettings.Username)
            .EnterPassword("1274948J!")
            .ClickSignInBtn();
        Assert.That(loginPage.IsInvalidCredentialsErrorDisplayed(), Is.True, "Invalid credentials error message was not displayed.");
    }
}