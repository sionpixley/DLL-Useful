using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful;
using System;

namespace Tests {
	[TestClass]
	public class StringMethods {
		[TestMethod]
		public void Base64ToUtf8() {
			try {
				string expected = StringNormalizationExtensions.Normalize("👻");
				string base64 = "8J+Ruw==";

				string result = base64.Base64ToUtf8();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Utf8ToBase64() {
			try {
				string expected = "8J+Ruw==";
				string utf8 = StringNormalizationExtensions.Normalize("👻");

				string result = utf8.Utf8ToBase64();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
