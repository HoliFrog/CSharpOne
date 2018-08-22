using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bonjour;
using NMock;

namespace BonjourTest
{
    [TestClass]
    public class BonjourTest1
    {
        private MockFactory _mockFactory;
        private Mock<IDateTime> _mockIDateTime;

        [TestInitialize]
        public void Setup()
        {
            _mockFactory = new MockFactory();
            _mockIDateTime = _mockFactory.CreateMock<IDateTime>();
        }

        [TestCleanup]
        public void TearDown()
        {
            _mockFactory.VerifyAllExpectationsHaveBeenMet();
            _mockFactory.Dispose();
        }

        [TestMethod]
        public void TestBonjour()
        {
            FakeDate fakeDate = new FakeDate(2018, 8, 21, 10, 0, 0);
            Message target = new Message(fakeDate, 9, 13, 18);
            string excpected = "Bonjour";
            string message = target.DisplayDayMessage();
            Assert.IsTrue(message.Contains(excpected));
            Assert.IsTrue(message.Contains("mardi"));
        }

        [TestMethod]
        public void TestMockBonjour()
        {
            _mockIDateTime.Expects.Any.GetProperty(_ => _.date).WillReturn(new DateTime(2018, 8, 21, 10, 0, 0));
            Message target = new Message(_mockIDateTime.MockObject, 9, 13, 18);
            string excpected = "Bonjour";
            string message = target.DisplayDayMessage();
            Assert.IsTrue(message.Contains(excpected));
            Assert.IsTrue(message.Contains("mardi"));
        }

        [TestMethod]
        public void TestBonAprem()
        {

            FakeDate fakeDate = new FakeDate(2018, 8, 22, 14, 0, 0);

            Message target = new Message(fakeDate, 9, 13, 18);
            string excpected = "Bon après-midi";
            string message = target.DisplayDayMessage();
            Assert.IsTrue(message.Contains(excpected));
            Assert.IsTrue(message.Contains("mercredi"));
        }
        [TestMethod]

        public void TestBonWE()
        {

            FakeDate fakeDate = new FakeDate(2018, 8, 17, 23, 0, 1);

            Message target = new Message(fakeDate, 9, 13, 18);
            string excpected = "il faut arrêter de travailler";
            string message = target.DisplayDayMessage();
            Assert.IsTrue(message.Contains(excpected));
            Assert.IsTrue(message.Contains("vendredi"));

        }
    }
}
