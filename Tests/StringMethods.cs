using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests {
	[TestClass]
	public class StringMethods {
		[TestMethod]
		public void Base64ToUtf8() {
			try {
				string expected = StringNormalizationExtensions.Normalize("👻");
				string base64 = "8J+Ruw==";

				string result = Sion.Useful.StringMethods.Base64ToUtf8(base64);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToPascalCase() {
			try {
				string camelCase = "helloTesting";
				string expected = "HelloTesting";

				string result = Sion.Useful.StringMethods.CamelCaseToPascalCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToPascalCase_Empty() {
			try {
				string camelCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.CamelCaseToPascalCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToSnakeCase() {
			try {
				string camelCase = "helloTesting";
				string expected = "hello_testing";

				string result = Sion.Useful.StringMethods.CamelCaseToSnakeCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToSnakeCase_Empty() {
			try {
				string camelCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.CamelCaseToSnakeCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToCamelCase() {
			try {
				string pascalCase = "HelloTesting";
				string expected = "helloTesting";

				string result = Sion.Useful.StringMethods.PascalCaseToCamelCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToCamelCase_Empty() {
			try {
				string pascalCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.PascalCaseToCamelCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToSnakeCase() {
			try {
				string pascalCase = "HelloTesting";
				string expected = "hello_testing";

				string result = Sion.Useful.StringMethods.PascalCaseToSnakeCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToSnakeCase_Empty() {
			try {
				string pascalCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.PascalCaseToSnakeCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToCamelCase() {
			try {
				string snakeCase = "hello_testing";
				string expected = "helloTesting";

				string result = Sion.Useful.StringMethods.SnakeCaseToCamelCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToCamelCase_Empty() {
			try {
				string snakeCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.SnakeCaseToCamelCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToPascalCase() {
			try {
				string snakeCase = "hello_testing";
				string expected = "HelloTesting";

				string result = Sion.Useful.StringMethods.SnakeCaseToPascalCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToPascalCase_Empty() {
			try {
				string snakeCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.SnakeCaseToPascalCase(snakeCase);

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

				string result = Sion.Useful.StringMethods.Utf8ToBase64(utf8);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
