using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase.Framework.Core.Pages;

namespace Qase.Framework.Core.Pages.Authentication;

public class LoginPage : LoadablePage
{
    private static readonly By LoginPageHeader = By.CssSelector(".GgylDN.O7zQSw");
    private static readonly By EmailField = By.CssSelector("input[placeholder='Work email']");
    private static readonly By PasswordField = By.CssSelector("input[placeholder='Password']");
    private static readonly By RememberCheckbox = By.CssSelector("[type='checkbox']");
    private static readonly By SignInBtn = By.CssSelector("[type='submit']");
    private static readonly By InvalidCredentialsError = By.CssSelector("span.mF0fFk");
    private static readonly By ForgotPasswordBtn = By.LinkText("Forgot password?");
    
    public LoginPage() : base(LoginPageHeader)
    {
    }

    public LoginPage EnterEmail(string email)
    {
        Type(EmailField, email);
        return this;
    }
    
    public LoginPage EnterPassword(string password)
    {
        Type(PasswordField, password);
        return this;
    }
    
    public LoginPage ClickSignInBtn()
    {
        Click(SignInBtn);
        return this;
    }
    
    public ProjectsPage LoginSuccessfully()
    {
        Click(SignInBtn);
        return new ProjectsPage();
    }

    public bool LogInPageIsDIsplayed()
    {
        return FindVisibleElement(LoginPageHeader).Displayed;
    }

    public bool IsInvalidCredentialsErrorDisplayed()
    {
        var errorMessage = FindVisibleElement(InvalidCredentialsError);

        return errorMessage.Text == "These credentials do not match our records.";
    }
    
    public ResetPasswordPage ClickForgotPassword()
    {
        Click(ForgotPasswordBtn);
        return new ResetPasswordPage();
    }
}