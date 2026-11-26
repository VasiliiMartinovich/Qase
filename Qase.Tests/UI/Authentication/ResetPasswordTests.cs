using NUnit.Framework;
using Qase.Tests.Infrastructure;
using Qase.Framework.Core.Pages.Authentication;

namespace Qase.Tests;

[TestFixture]
public class ResetPasswordTests : UiBaseTest
{
    [Test]
    public void SuccessResetPassword()
    {
        var loginPage = new LoginPage();
        var resetPasswordPage = loginPage.ClickForgotPassword();
        resetPasswordPage.ResetPassword("test@user.com");
        Assert.That(resetPasswordPage.IsResendTimerPresent(), Is.True);
    }
    
    [Test]
    public void NavigationToLogInPage()
    {
        var loginPage = new LoginPage();
        var resetPasswordPage = loginPage.ClickForgotPassword();
        resetPasswordPage.ClickLogInBtn();
        Assert.That(loginPage.LogInPageIsDIsplayed(), Is.True,  "Login page should be displayed.");
    }
}