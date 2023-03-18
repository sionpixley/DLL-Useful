using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests {
	[TestClass]
	public class DecimalMethods {
		[TestMethod]
		public void Truncate() {
			try {
				decimal d = 10.9872m;
				decimal trunc = Sion.Useful.DecimalMethods.Truncate(d, 2);
				Assert.AreEqual(trunc, 10.98m);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
