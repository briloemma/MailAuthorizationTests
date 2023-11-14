using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.BaseUIControls
{
    internal interface IControl
    {
        public bool IsDisplayed();
        public bool IsEnabled(); 
    }
}
