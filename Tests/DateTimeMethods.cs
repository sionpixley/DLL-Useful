using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful;
using System;

namespace Tests {
	[TestClass]
	public class DateTimeMethods {
		[TestMethod]
		public void ConvertToUnixMilliseconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long expected = 946684800000;
				long result = date.ToUnixMilliseconds();
				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void ConvertToUnixSeconds() {
			try {
				DateTime date = Convert.ToDateTime("2000-01-01T00:00:00.000Z").ToUniversalTime();
				long expected = 946684800;
				long result = date.ToUnixSeconds();
				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
