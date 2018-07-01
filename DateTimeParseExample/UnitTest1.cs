using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTimeParseExample
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-JP");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Trace.TraceInformation(DateTime.Now.ToLongDateString());
            DateTime.Parse("2000/1/1").Is(new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void TestJapaneseCulture_通常のケース()
        {
            DateTime.Parse("2000/1/1 12:00 AM").Is(new DateTime(2000, 1, 1, 00, 0, 0));
            DateTime.Parse("2000/1/1 01:00 AM").Is(new DateTime(2000, 1, 1, 01, 0, 0));
            DateTime.Parse("2000/1/1 11:00 AM").Is(new DateTime(2000, 1, 1, 11, 0, 0));
            DateTime.Parse("2000/1/1 12:00 PM").Is(new DateTime(2000, 1, 1, 12, 0, 0));
            DateTime.Parse("2000/1/1 01:00 PM").Is(new DateTime(2000, 1, 1, 13, 0, 0));
            DateTime.Parse("2000/1/1 11:00 PM").Is(new DateTime(2000, 1, 1, 23, 0, 0));
            DateTime.Parse("2000/1/2 12:00 AM").Is(new DateTime(2000, 1, 2, 00, 0, 0));

        }

        [TestMethod]
        public void TestJapaneseCulture_特殊ケース()
        {
            DateTime.Parse("2000/1/1 00:00 AM").Is(new DateTime(2000, 1, 1, 00, 0, 0));
            DateTime.Parse("2000/1/1 00:00 PM").Is(new DateTime(2000, 1, 1, 12, 0, 0));
            DateTime.Parse("2000/1/1 00:00"   ).Is(new DateTime(2000, 1, 1, 00, 0, 0));
            DateTime.Parse("2000/1/1 12:00"   ).Is(new DateTime(2000, 1, 1, 12, 0, 0));
            DateTime.Parse("2000/1/1 13:00 PM").Is(new DateTime(2000, 1, 1, 13, 0, 0));
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void TestJapaneseCulture_例外1()
        {
            DateTime.Parse("2000/1/1 24:00 AM");
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void TestJapaneseCulture_例外2()
        {
            DateTime.Parse("2000/1/1 24:00 PM");
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void TestJapaneseCulture_例外3()
        {
            DateTime.Parse("2000/1/1 13:00 AM");
        }
    }
}
