using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages.Authentication;

public class ResetPasswordPage : LoadablePage
{
    private static readonly By ResetPasswordHeader = By.CssSelector(".GgylDN.O7zQSw");
    private static readonly By WorkEmailField = By.CssSelector("input[placeholder='Work email']");
    private static readonly By ResetPasswordBtn = By.CssSelector("[type='submit']");
    private static readonly By LogInBtn = By.LinkText("Log in");
    private static readonly By ResendTimer =  By.CssSelector("p.Qh9IGL");
    
    public ResetPasswordPage() : base(ResetPasswordHeader)
    {
    }
    
    public ResetPasswordPage ResetPassword(string email)
    {
        Type(WorkEmailField, email);
        Click(ResetPasswordBtn);
        return this;
    }
    
    public bool IsResendTimerDisplayed()
    {
        return FindVisibleElement(ResendTimer).Displayed;
    }
    
    public bool IsResendTimerFormatValid()
    {
        var timerText = FindVisibleElement(ResendTimer).Text;
        return Regex.IsMatch(timerText, @"^Resend in \d{2}:\d{2}$");
    }
    
    public bool IsEmailFieldDisabled()
    {
        return !FindVisibleElement(WorkEmailField).Enabled;
    }
    
    public bool IsResendTimerPresent()
    {
        return Driver.FindElements(ResendTimer).Any();
    }
    
    public LoginPage ClickLogInBtn()
    {
        Click(LogInBtn);
        return new LoginPage();
    }
}