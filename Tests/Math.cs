using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sion.Useful.Math;

namespace Tests {
	[TestClass]
	public class Math {
		[TestMethod]
		public void Truncate_Float() {
			try {
				float f = 2.456f;
				float expected = 2.4f;
				float actual = f.Truncate(1);

				Assert.AreEqual(expected, actual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Truncate_Decimal() {
			try {
				decimal d = 1324.67m;
				decimal expected = 1324m;
				decimal actual = d.Truncate(0);

				Assert.AreEqual(expected, actual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Truncate_Double() {
			try {
				double d = 62.5601248;
				double expected = 62.56012;
				double actual = d.Truncate(5);

				Assert.AreEqual(expected, actual);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
