using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests {
	[TestClass]
	public class DateTimeMethods {
		[TestMethod]
		public void ConvertToUnixMilliseconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long actual = 946684800000;
				long result = Sion.Useful.DateTimeMethods.ConvertToUnixMilliseconds(date);
				Assert.AreEqual(actual, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void ConvertToUnixSeconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long actual = 946684800;
				long result = Sion.Useful.DateTimeMethods.ConvertToUnixSeconds(date);
				Assert.AreEqual(actual, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
