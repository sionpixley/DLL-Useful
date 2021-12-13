using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sion.Useful.Tests {
	[TestClass]
	public class DecimalMethods {
		[TestMethod]
		public void Test_Truncate() {
			try {
				decimal d = 10.9812M;
				decimal trunc = Sion.Useful.DecimalMethods.Truncate(d, 2);
				Assert.AreEqual(trunc, 10.98M);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
