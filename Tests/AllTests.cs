using System;
using System.Collections;
using Amazon.AWSSupport.Model;
using NUnit.Core;
using NUnit.Framework;

namespace MailAuthorizationTests.Tests
{
    public class AllTests
    {
        public static IEnumerable Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(typeof(BasicLoginTest));
                suite.Add(typeof(CheckEmailIsSendAndReceived));
                return suite;
            }
        }
    }
}
