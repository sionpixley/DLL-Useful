using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
	[TestClass]
	public class StringMethods {
		[TestMethod]
		public void Base64ToUtf8() {
			try {
				string expected = "👻";
				byte[] raw = Encoding.UTF8.GetBytes(expected);
				string base64 = Convert.ToBase64String(raw);

				string result = Sion.Useful.StringMethods.Base64ToUtf8(base64);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
