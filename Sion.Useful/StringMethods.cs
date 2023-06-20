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
			List<string> builder = new();
			List<char> chars = new();
			foreach(var c in camelCase) {
				if(Char.IsUpper(c)) {
					builder.Add(String.Concat(chars));
					chars.Clear();
					chars.Add(Char.ToLower(c));
				}
				else {
					chars.Add(c);
				}
			}
			if(chars.Count > 0) {
				builder.Add(String.Concat(chars));
			}
			return String.Join("_", builder);
		}

		public static string PascalCaseToCamelCase(string pascalCase) {
			return pascalCase.Length > 0 ? $"{Char.ToLower(pascalCase[0])}{pascalCase[1..]}" : "";
		}

		public static string PascalCaseToSnakeCase(string pascalCase) {
			List<string> builder = new();
			List<char> chars = new();
			bool firstChar = true;
			foreach(var c in pascalCase) {
				if(firstChar) {
					chars.Add(Char.ToLower(c));
					firstChar = false;
				}
				else if(Char.IsUpper(c)) {
					builder.Add(String.Concat(chars));
					chars.Clear();
					chars.Add(Char.ToLower(c));
				}
				else {
					chars.Add(c);
				}
			}
			if(chars.Count > 0) {
				builder.Add(String.Concat(chars));
			}
			return String.Join("_", builder);
		}

		public static string SnakeCaseToCamelCase(string snakeCase) {
			List<string> builder = new();
			List<char> chars = new();
			bool firstChar = true;
			bool newWord = false;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(firstChar) {
					chars.Add(Char.ToLower(c));
					firstChar = false;
				}
				else if(newWord) {
					builder.Add(String.Concat(chars));
					chars.Clear();
					chars.Add(Char.ToUpper(c));
					newWord = false;
				}
				else {
					chars.Add(Char.ToLower(c));
				}
			}
			if(chars.Count > 0) {
				builder.Add(String.Concat(chars));
			}
			return String.Concat(builder);
		}

		public static string SnakeCaseToPascalCase(string snakeCase) {
			List<string> builder = new();
			List<char> chars = new();
			bool firstChar = true;
			bool newWord = false;
			foreach(var c in snakeCase) {
				if(c == '_') {
					newWord = true;
				}
				else if(firstChar) {
					chars.Add(Char.ToUpper(c));
					firstChar = false;
				}
				else if(newWord) {
					builder.Add(String.Concat(chars));
					chars.Clear();
					chars.Add(Char.ToUpper(c));
					newWord = false;
				}
				else {
					chars.Add(Char.ToLower(c));
				}
			}
			if(chars.Count > 0) {
				builder.Add(String.Concat(chars));
			}
			return String.Concat(builder);
		}

		public static string Utf8ToBase64(string utf8) {
			byte[] raw = Encoding.UTF8.GetBytes(utf8);
			return Convert.ToBase64String(raw);
		}
	}
}
