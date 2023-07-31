using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUResponsePageObject : BasePageObject
    {
        private readonly By _sendButton = By.XPath("//span[text()='Отправить']");
        private readonly By _cancelSendButton = By.CssSelector("[title = 'Отменить отправку']");
        private readonly By _textBox = By.CssSelector("[role='textbox']");
        public RUResponsePageObject() : base(By.XPath("//div[contains(@class, 'contactsContainer')]"))
        {
        }

        public RUOpenedEmailPageObject SendResponse(string emailBody)
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _textBox);
            WebDriver.FindElement(_textBox).SendKeys(emailBody);
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _sendButton);
            WebDriver.FindElement(_sendButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _cancelSendButton);
            return new RUOpenedEmailPageObject();
        }

    }
}
