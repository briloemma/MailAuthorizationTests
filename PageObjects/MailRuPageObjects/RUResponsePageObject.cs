using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUResponsePageObject : BasePageObject
    {
        private Button SendButton => new Button(By.XPath("//span[text()='Отправить']"));
        private Button CancelSendButton => new Button(By.CssSelector("[title = 'Отменить отправку']"));
        private TextInput TextBox => new TextInput(By.CssSelector("[role='textbox']"));
        public RUResponsePageObject() : base(By.XPath("//div[contains(@class, 'contactsContainer')]"))
        {
        }

        public PageObjects.MailRuPageObjects.RUOpenedEmailPageObject SendResponse(string emailBody)
        {
            TextBox.SendKeys(emailBody);
            SendButton.Click();
            if (CancelSendButton.IsDisplayed()) ;
            return new PageObjects.MailRuPageObjects.RUOpenedEmailPageObject();
        }
    }
}