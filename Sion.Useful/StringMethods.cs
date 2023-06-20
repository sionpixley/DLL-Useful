using System;
using System.Collections.Generic;
using System.Text;

namespace Sion.Useful {
	public static class StringMethods {
		public static string Base64ToUtf8(string base64) {
			byte[] raw = Convert.FromBase64String(base64);
			return Encoding.UTF8.GetString(raw);
		}

		public static string CamelCaseToPascalCase(string camelCase) {
			return camelCase.Length > 0 ? $"{Char.ToUpper(camelCase[0])}{camelCase[1..]}" : "";
		}

		public static string CamelCaseToSnakeCase(string camelCase) {
			if(camelCase.Length > 999) {
				return _BulkCamelCaseToSnakeCase(camelCase);
			}

			List<char> builder = new();
			foreach(var c in camelCase) {
				if(Char.IsUpper(c)) {
					builder.Add('_');
					builder.Add(Char.ToLower(c));
				}
				else {
					builder.Add(c);
				}
			}
			return String.Concat(builder);
		}

		public static string PascalCaseToCamelCase(string pascalCase) {
			return pascalCase.Length > 0 ? $"{Char.ToLower(pascalCase[0])}{pascalCase[1..]}" : "";
		}

		public static string PascalCaseToSnakeCase(string pascalCase) {
			if(pascalCase.Length > 999) {
				return _BulkPascalCaseToSnakeCase(pascalCase);
			}

			List<char> builder = new();
			bool firstChar = true;
			foreach(var c in pascalCase) {
				if(firstChar) {
					builder.Add(Char.ToLower(c));
					firstChar = false;
				}
				else if(Char.IsUpper(c)) {
					builder.Add('_');
					builder.Add(Char.ToLower(c));
				}
				else {
					builder.Add(c);
				}
			}
			return String.Concat(builder);
		}

		public static string SnakeCaseToCamelCase(string snakeCase) {
			if(snakeCase.Length > 999) {
				return _BulkSnakeCaseToCamelCase(snakeCase);
			}

			List<char> builder = new();
			bool newWord = false;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(newWord) {
					builder.Add(Char.ToUpper(c));
					newWord = false;
				}
				else {
					builder.Add(Char.ToLower(c));
				}
			}
			return String.Concat(builder);
		}

		public static string SnakeCaseToPascalCase(string snakeCase) {
			if(snakeCase.Length > 999) {
				return _BulkSnakeCaseToPascalCase(snakeCase);
			}

			List<char> builder = new();
			bool newWord = true;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(newWord) {
					builder.Add(Char.ToUpper(c));
					newWord = false;
				}
				else {
					builder.Add(Char.ToLower(c));
				}
			}
			return String.Concat(builder);
		}

		public static string Utf8ToBase64(string utf8) {
			byte[] raw = Encoding.UTF8.GetBytes(utf8);
			return Convert.ToBase64String(raw);
		}

		private static string _BulkCamelCaseToSnakeCase(string camelCase) {
			StringBuilder builder = new();
			foreach(var c in camelCase) {
				if(Char.IsUpper(c)) {
					builder.Append('_');
					builder.Append(Char.ToLower(c));
				}
				else {
					builder.Append(c);
				}
			}
			return builder.ToString();
		}

		private static string _BulkPascalCaseToSnakeCase(string pascalCase) {
			StringBuilder builder = new();
			bool firstChar = true;
			foreach(var c in pascalCase) {
				if(firstChar) {
					builder.Append(Char.ToLower(c));
					firstChar = false;
				}
				else if(Char.IsUpper(c)) {
					builder.Append('_');
					builder.Append(Char.ToLower(c));
				}
				else {
					builder.Append(c);
				}
			}
			return builder.ToString();
		}

		private static string _BulkSnakeCaseToCamelCase(string snakeCase) {
			StringBuilder builder = new();
			bool newWord = false;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(newWord) {
					builder.Append(Char.ToUpper(c));
					newWord = false;
				}
				else {
					builder.Append(Char.ToLower(c));
				}
			}
			return builder.ToString();
		}

		private static string _BulkSnakeCaseToPascalCase(string snakeCase) {
			StringBuilder builder = new();
			bool newWord = true;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(newWord) {
					builder.Append(Char.ToUpper(c));
					newWord = false;
				}
				else {
					builder.Append(Char.ToLower(c));
				}
			}
			return builder.ToString();
		}
	}
}
