using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUResponsePageObject : BasePageObject
    {
        private Button endButton = new Button(By.XPath("//span[text()='Отправить']"));
        private Button _cancelSendButton = new Button(By.CssSelector("[title = 'Отменить отправку']"));
        private TextInput _textBox = new TextInput(By.CssSelector("[role='textbox']"));
        public RUResponsePageObject() : base(By.XPath("//div[contains(@class, 'contactsContainer')]"))
        {
        }

        public PageObjects.MailRuPageObjects.RUOpenedEmailPageObject SendResponse(string emailBody)
        {
            _textBox.SendKeys(emailBody);
            _sendButton.Click();
            if (_cancelSendButton.IsDisplayed()) ;
            return new PageObjects.MailRuPageObjects.RUOpenedEmailPageObject();
        }
    }
}