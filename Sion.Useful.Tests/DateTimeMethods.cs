using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Tests {
	[TestClass]
	public class DateTimeMethods {
		[TestMethod]
		public void Test_ConvertToUnixMilliseconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long actual = 946684800000;
				long result = Methods.DateTimeMethods.ConvertToUnixMilliseconds(date);
				Assert.AreEqual(actual, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_ConvertToUnixSeconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long actual = 946684800;
				long result = Methods.DateTimeMethods.ConvertToUnixSeconds(date);
				Assert.AreEqual(actual, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
