using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages.Authentication;

public class LoginPage : LoadablePage
{
    private static readonly By LoginPageLocator = By.CssSelector(".GgylDN.O7zQSw");
    private static readonly By EmailField = By.CssSelector("Work email");
    private static readonly By PasswordField = By.CssSelector("Password");
    private static readonly By RememberCheckbox = By.CssSelector("[type='checkbox']");
    private static readonly By SignInBtn = By.CssSelector("[type='submit']");
    
    protected LoginPage(By pageReadyLocator) : base(LoginPageLocator)
    {
    }

    public LoginPage EnterEmail(string email)
    {
        Driver.FindElement(EmailField).SendKeys(email);
        return this;
    }
    
    public LoginPage EnterPassword(string password)
    {
        Driver.FindElement(PasswordField).SendKeys(password);
        return this;
    }
    
    public LoginPage ClickSigInBtn()
    {
        Driver.FindElement(SignInBtn).Click();
        return this;
    }
    
}